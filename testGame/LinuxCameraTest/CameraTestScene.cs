using Angene.Common;
using Angene.Graphics;
using static Angene.Vulkan.Interop.Structs;
using static Angene.Vulkan.Interop.Enumerators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Angene.Essentials;
using Angene.Essentials.Components;
using Angene.Main;
using Angene.Math.Vectors;
using Angene.Graphics.SlangShader;
using Angene.Audio;
using Angene.Essentials.DefaultEntities;
using Angene.Essentials.GraphicsContexts;
using static Angene.Essentials.Types;

namespace Game.Scenes
{
    public unsafe class CameraTestScene : IScene
    {
        public static object Instance { get; private set; }
        public List<Entity> Entities { get; private set; } = new List<Entity>();
        public string Name => "CameraTestScene";

        public Entity MainCamera => _cameraEntity;

        internal readonly Window _window;
        private readonly string _materialsPackagePath;
        private IVkGraphicsContext _gfx;

        private IntPtr _vertexShaderModule;
        private IntPtr _fragmentShaderModule;
        private IntPtr _pipeline;

        private Entity _cameraEntity;
        private Entity _cubeEntity;
        private Entity _cubeEntity1;
        private float[] vertexData;
        private float[] vertexData1;
        private IntPtr vertexBuffer = IntPtr.Zero;
        private IntPtr vertexBuffer1 = IntPtr.Zero;
        private byte[] vertexBytes;
        private byte[] vertexBytes1;
        private int vertexCount;
        private int vertexCount1;

        private Dictionary<string, FaceColor> _materials;

        private AudioManager _manager;

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
            _cubeEntity = Cube.Instantiate(_gfx, new Vec3(0, 0, 0), new Vec3(0, 0, 0), new Vec3(1, 1, 1), "Cube");
            Entities.Add(_cubeEntity);

            _cubeEntity1 = Cube.Instantiate(_gfx, new Vec3(0f, 3f, 0f), new Vec3(0, 0, 0), new Vec3(2, 2, 1), "Cube1");
            Entities.Add(_cubeEntity1);
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
            AudioFile file = new("Assets/Audio.angpkg", "00_-_CAKE_Cake_n_Cake_.mp3", AudioFile.LoadType.loadOnInstantiate);
            _manager = new AudioManager(file, playOnLoad:false, loop: false, volume: 1f);
            Logger.LogInfo("[CameraTestScene] Initialized.", LoggingTarget.Graphics);
        }

        public void OnMessage(object msgPtr)
        {
            foreach (Entity e in Entities)
                foreach (IScreenPlay isp in e.GetScripts())
                    isp.OnMessage(msgPtr);
        }

        public void Render()
        {
            if (_gfx == null) return;

            Transform3D camT = MainCamera.Transform;
            VulkanCamera cam = MainCamera.GetComponent<VulkanCamera>()!;
            Matrix4x4 view = cam.LookTo(camT.pos, cam.forward, cam.up);
            Matrix4x4 proj = cam.Perspective(cam.fov, cam.aspectRatio, cam.nearPlane, cam.farPlane);
            
            List<(Entity e, Matrix4x4 mv)> cubes = Entities.Where(e => e.HasComponent<Mesh>()).Select(e => (e, mv: view * this.GetWorldMatrix(e)))
                .OrderBy(t => cam.TransformPoint(t.mv, new Vec3(0, 0, 0)).Z).ToList();
            
            _gfx.BeginFrame(0x00202020);
            _gfx.SetPipeline(_pipeline);

            foreach ((Entity e, Matrix4x4 mv) in cubes)
            {
                Mesh mesh = e.GetComponent<Mesh>()!;
                float[] data = BuildSortedNdcVertexBuffer(cam, mv, proj, out mesh.vertexCount);
                Buffer.BlockCopy(data, 0, mesh.bytes, 0, data.Length * sizeof(float));
                
                _gfx.UpdateVertexBuffer(mesh.vertexBuffer, mesh.bytes);
                _gfx.SetVertexBuffer(mesh.vertexBuffer, strideBytes: 7 * sizeof(float));
                _gfx.Draw((uint)mesh.vertexCount);
            }

            _gfx.EndFrame();
        }

        private float[] BuildSortedNdcVertexBuffer(VulkanCamera cam, Matrix4x4 modelView, Matrix4x4 proj, out int vertexCount)
        {
            triangles.Clear();
            foreach (var face in Faces)
            {
                FaceColor color = _materials.TryGetValue(face.material, out var c) ? c : new FaceColor(1, 1, 1, 1);
                cam.AddTriangle(Corners[face.a], Corners[face.b], Corners[face.c], color, modelView, proj, triangles);
                cam.AddTriangle(Corners[face.a], Corners[face.c], Corners[face.d], color, modelView, proj, triangles);
            }

            triangles.Sort((t1, t2) => t1.depth.CompareTo(t2.depth));

            verts.Clear();
            verts.Capacity = Math.Max(verts.Capacity, triangles.Count * 3 * 7);
            foreach (var tri in triangles)
            {
                cam.AppendVertex(verts, tri.ndc0, tri.color);
                cam.AppendVertex(verts, tri.ndc1, tri.color);
                cam.AppendVertex(verts, tri.ndc2, tri.color);
            }

            vertexCount = triangles.Count * 3;
            return verts.ToArray();
        }

        public void Cleanup()
        {
            // Pipeline/shader-module teardown belongs here once VkGraphicsContext exposes
            // per-resource destroy methods; today Cleanup() on the context sweeps
            // everything it tracked internally.
        }
    }
}
