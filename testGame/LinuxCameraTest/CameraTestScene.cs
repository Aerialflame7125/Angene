using Angene.Common;
using Angene.Graphics;
using static Angene.Vulkan.Interop.Structs;
using static Angene.Vulkan.Interop.Enumerators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Angene.Essentials;
using Angene.Essentials.Components;
using Angene.Main;
using Angene.Math.Vectors;
using Angene.Graphics.SlangShader;
using Angene.Essentials.GraphicsContexts;

namespace Game.Scenes
{
    /// <summary>
    /// Renders a single 6-face cube and lets the person fly a camera around it with
    /// WASD + arrow keys, to exercise Angene.Essentials' camera components
    /// (Transform3D + VulkanCamera) end to end on the Vulkan/Linux backend.
    ///
    /// IMPORTANT CAVEATS (found while wiring this up against the current ECSWork source):
    ///   1. VkGraphicsContext's single shared pipeline layout is created with
    ///      pushConstantRangeCount = 0 and never binds a descriptor set, so there is no
    ///      GPU-side path today to upload a view/projection matrix. This scene instead
    ///      transforms every vertex on the CPU (Model * View * Projection + perspective
    ///      divide) using Transform3D/VulkanCamera each frame, and uploads already-NDC
    ///      positions. See Shaders.cs for the pass-through vertex shader this expects.
    ///   2. There is no depth buffer/depth test anywhere in the Vulkan backend
    ///      (no VkFormat_D32 image, no pDepthStencilState on the pipeline). To still get
    ///      correct occlusion, this scene sorts the cube's 12 triangles back-to-front
    ///      (painter's algorithm) every frame using view-space depth before uploading.
    ///   3. CreateVertexBuffer() has no matching "update" or public "destroy" call, so
    ///      rebuilding geometry every frame means allocating a fresh VMA buffer every
    ///      frame; buffers are only swept on Cleanup(). Fine for a short test session,
    ///      but this leaks GPU memory over a long play session -- flagging it rather than
    ///      hiding it. A real fix would add an UpdateVertexBuffer()/DestroyBuffer() pair
    ///      to IVkGraphicsContext.
    ///   4. The Vulkan backend has no sampler/descriptor-set/texture support at all yet,
    ///      so "material" here means a per-face vertex color loaded from a real .angpkg
    ///      package (Assets/CameraMaterials.angpkg via Angene.Main.Package) rather than a
    ///      sampled image -- see CameraMaterials.cs for why.
    /// </summary>
    public unsafe class CameraTestScene : IScene
    {
        public static object Instance { get; private set; }
        public List<Entity> Entities { get; private set; } = new List<Entity>();
        public string Name => "CameraTestScene";

        public Entity MainCamera => null;

        internal readonly Window _window;
        private readonly string _materialsPackagePath;
        private IVkGraphicsContext _gfx;

        private IntPtr _vertexShaderModule;
        private IntPtr _fragmentShaderModule;
        private IntPtr _pipeline;

        private Entity _cameraEntity;
        private Entity _cubeEntity;
        private Dictionary<string, FaceColor> _materials;

        private Angene.Audio.MiniAudio.MiniAudio mAudio = new Angene.Audio.MiniAudio.MiniAudio();

        private List<(Vec3 ndc0, Vec3 ndc1, Vec3 ndc2, float depth, FaceColor color)> triangles = new List<(Vec3 ndc0, Vec3 ndc1, Vec3 ndc2, float depth, FaceColor color)>();
        private List<float> verts = new();

        // Unit cube (half-extent 0.5) face definitions: 4 corner indices (fan order) + material key.
        private static readonly Vec3[] Corners =
        {
            new(-0.5f, -0.5f, -0.5f), // 0
            new( 0.5f, -0.5f, -0.5f), // 1
            new( 0.5f,  0.5f, -0.5f), // 2
            new(-0.5f,  0.5f, -0.5f), // 3
            new(-0.5f, -0.5f,  0.5f), // 4
            new( 0.5f, -0.5f,  0.5f), // 5
            new( 0.5f,  0.5f,  0.5f), // 6
            new(-0.5f,  0.5f,  0.5f), // 7
        };

        private static readonly (int a, int b, int c, int d, string material)[] Faces =
        {
            (1, 2, 6, 5, "posx"), // +X right
            (0, 4, 7, 3, "negx"), // -X left
            (3, 7, 6, 2, "posy"), // +Y top
            (0, 1, 5, 4, "negy"), // -Y bottom
            (4, 5, 6, 7, "posz"), // +Z front
            (1, 0, 3, 2, "negz"), // -Z back
        };

        public CameraTestScene(Window window, string materialsPackagePath)
        {
            _window = window ?? throw new ArgumentNullException(nameof(window));
            _materialsPackagePath = materialsPackagePath ?? throw new ArgumentNullException(nameof(materialsPackagePath));
        }

        public void Initialize()
        {
            Instance = this;

            _gfx = _window.Graphics as IVkGraphicsContext;
            if (_gfx == null)
            {
                Logger.LogCritical("[CameraTestScene] Window is not using the Vulkan backend.", LoggingTarget.Graphics, new Exception("Window is not using the Vulkan rendering backend."));
                return;
            }

            _materials = CameraMaterials.Load(_materialsPackagePath);

            // NOTE: deliberately not using Angene.Input.KeyDetection here. It marshals
            // OnMessage's IntPtr as a Win32 WindowManagement.MSG and switches on
            // WM.KEYDOWN/WM.KEYUP, and on Linux, Engine.ProcessMessages() never forwards
            // individual X11 key events to any scene/script's OnMessage() in the first
            // place (it only special-cases the WM_DELETE_WINDOW ClientMessage). See
            // X11Keyboard.cs -- CameraControllerScript polls XQueryKeymap directly instead.

            // --- Camera entity: Transform3D (position) + VulkanCamera (lens/orientation) ---
            _cameraEntity = new Entity(new Vec3(0f, 1.5f, -4f), new Vec3(0, 0, 0), new Vec3(1, 1, 1), "MainCamera");
            _cameraEntity.AddComponent(new VulkanCamera
            {
                forward = new Vec3(0f, 0f, 1f), // looking toward the cube at the origin
                up = new Vec3(0f, 1f, 0f),
                fov = MathF.PI / 3f, // 60 degrees
                aspectRatio = _gfx.VkExtent2D.width / (float)_gfx.VkExtent2D.height,
                nearPlane = 0.1f,
                farPlane = 100f,
                isPrimary = true,
            });
            Entities.Add(_cameraEntity);

            var controller = _cameraEntity.AddScript<CameraControllerScript>();
            controller.Initialize(_cameraEntity);

            // --- Cube entity: just needs a Transform3D, geometry is generated in Render() ---
            _cubeEntity = new Entity(new Vec3(0, 0, 0), new Vec3(0, 0, 0), new Vec3(1, 1, 1), "Cube");
            Entities.Add(_cubeEntity);

            // --- Pipeline (position + color vertex layout, matches Shaders.cs) ---
            var vertexShader = Engine.Instance.ShaderCache[1] as VkShader;
            var fragmentShader = Engine.Instance.ShaderCache[2] as VkShader;

            if (vertexShader.NativeShaderModule == IntPtr.Zero || fragmentShader.NativeShaderModule == IntPtr.Zero)
                throw new Exception("Shader module handle is zero!");

            var attributes = new VkVertexInputAttributeDescription[]
            {
                new VkVertexInputAttributeDescription
                {
                    location = 0, binding = 0,
                    format = VkFormat.VK_FORMAT_R32G32B32_SFLOAT,
                    offset = 0
                },
                new VkVertexInputAttributeDescription
                {
                    location = 1, binding = 0,
                    format = VkFormat.VK_FORMAT_R32G32B32A32_SFLOAT,
                    offset = 12
                },
            };

            _pipeline = _gfx.CreatePipeline(vertexShader.NativeShaderModule, fragmentShader.NativeShaderModule,
                attributes, 7 * sizeof(float));
            
            Logger.LogInfo($"[MiniAudio] Linked native version: {new string((sbyte*)Angene.Audio.MiniAudio.Interop.Methods.ma_version_string())}", LoggingTarget.Engine);
            mAudio.Play("cake.mp3");
            Logger.LogInfo("[CameraTestScene] Initialized.", LoggingTarget.Graphics);
        }

        public void OnMessage(IntPtr msgPtr) { }
        IntPtr vertexBuffer = IntPtr.Zero;

        public void Render()
        {
            if (_gfx == null) return;
            if (vertexBuffer != IntPtr.Zero)
                _gfx.DestroyBuffer(vertexBuffer);

            var camTransform = _cameraEntity.GetComponent<Transform3D>();
            var vCam = _cameraEntity.GetComponent<VulkanCamera>();
            var cubeTransform = _cubeEntity.GetComponent<Transform3D>();

            Matrix4x4 model = cubeTransform.GetMatrix();
            Matrix4x4 view = vCam.LookTo(camTransform.pos, vCam.forward, vCam.up);
            Matrix4x4 modelView = view * model;
            Matrix4x4 proj = vCam.Perspective(vCam.fov, vCam.aspectRatio, vCam.nearPlane, vCam.farPlane);

            float[] vertexData = BuildSortedNdcVertexBuffer(modelView, proj, out int vertexCount);

            byte[] vertexBytes = new byte[vertexData.Length * sizeof(float)];
            Buffer.BlockCopy(vertexData, 0, vertexBytes, 0, vertexBytes.Length);

            // NOTE: allocates a fresh VMA vertex buffer every frame -- see caveat #3 above.
            vertexBuffer = _gfx.CreateVertexBuffer(vertexBytes, strideBytes: 7 * sizeof(float));

            _gfx.BeginFrame(0x00202020); // dark gray background

            _gfx.SetPipeline(_pipeline);
            _gfx.SetVertexBuffer(vertexBuffer, strideBytes: 7 * sizeof(float));
            _gfx.Draw((uint)vertexCount);

            _gfx.EndFrame();
            
        }

        /// <summary>
        /// Builds the cube's 12 triangles (36 verts, position + color interleaved),
        /// transformed into NDC space and sorted back-to-front by view-space depth so
        /// the un-depth-tested Vulkan backend still draws faces in the right order.
        /// </summary>
        private float[] BuildSortedNdcVertexBuffer(Matrix4x4 modelView, Matrix4x4 proj, out int vertexCount)
        {
            triangles.Clear();
            foreach (var face in Faces)
            {
                FaceColor color = _materials.TryGetValue(face.material, out var c) ? c : new FaceColor(1, 1, 1, 1);

                AddTriangle(Corners[face.a], Corners[face.b], Corners[face.c], color, modelView, proj, triangles);
                AddTriangle(Corners[face.a], Corners[face.c], Corners[face.d], color, modelView, proj, triangles);
            }

            // Painter's algorithm: farthest (most negative view-space Z) first.
            triangles.Sort((t1, t2) => t1.depth.CompareTo(t2.depth));

            verts.Clear();
            verts.Append(triangles.Count * 3 * 7);
            foreach (var tri in triangles)
            {
                AppendVertex(verts, tri.ndc0, tri.color);
                AppendVertex(verts, tri.ndc1, tri.color);
                AppendVertex(verts, tri.ndc2, tri.color);
            }

            vertexCount = triangles.Count * 3;
            return verts.ToArray();
        }

        private static void AddTriangle(Vec3 p0, Vec3 p1, Vec3 p2, FaceColor color, Matrix4x4 modelView, Matrix4x4 proj,
            List<(Vec3, Vec3, Vec3, float, FaceColor)> outTriangles)
        {
            Vec3 v0 = TransformPoint(modelView, p0);
            Vec3 v1 = TransformPoint(modelView, p1);
            Vec3 v2 = TransformPoint(modelView, p2);

            float depth = (v0.Z + v1.Z + v2.Z) / 3f;

            Vec3 ndc0 = ProjectToNdc(proj, v0);
            Vec3 ndc1 = ProjectToNdc(proj, v1);
            Vec3 ndc2 = ProjectToNdc(proj, v2);

            outTriangles.Add((ndc0, ndc1, ndc2, depth, color));
        }

        private static void AppendVertex(List<float> verts, Vec3 pos, FaceColor color)
        {
            verts.Add(pos.X); verts.Add(pos.Y); verts.Add(pos.Z);
            verts.Add(color.R); verts.Add(color.G); verts.Add(color.B); verts.Add(color.A);
        }

        // Affine transform (view/model matrices always have row3 = (0,0,0,1), so w stays 1).
        private static Vec3 TransformPoint(Matrix4x4 m, Vec3 p) => new(
            m.M00 * p.X + m.M01 * p.Y + m.M02 * p.Z + m.M03,
            m.M10 * p.X + m.M11 * p.Y + m.M12 * p.Z + m.M13,
            m.M20 * p.X + m.M21 * p.Y + m.M22 * p.Z + m.M23
        );

        // Full projective transform + perspective divide (proj matrix has a non-trivial row3).
        private static Vec3 ProjectToNdc(Matrix4x4 m, Vec3 p)
        {
            float x = m.M00 * p.X + m.M01 * p.Y + m.M02 * p.Z + m.M03;
            float y = m.M10 * p.X + m.M11 * p.Y + m.M12 * p.Z + m.M13;
            float z = m.M20 * p.X + m.M21 * p.Y + m.M22 * p.Z + m.M23;
            float w = m.M30 * p.X + m.M31 * p.Y + m.M32 * p.Z + m.M33;

            if (MathF.Abs(w) > 1e-6f)
                return new Vec3(x / w, y / w, z / w);

            return new Vec3(x, y, z);
        }

        public void Cleanup()
        {
            // Pipeline/shader-module teardown belongs here once VkGraphicsContext exposes
            // per-resource destroy methods; today Cleanup() on the context sweeps
            // everything it tracked internally.
        }
    }
}
