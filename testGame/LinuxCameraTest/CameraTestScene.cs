using Angene.Common;
using static Angene.Vulkan.Interop.Structs;
using static Angene.Vulkan.Interop.Enumerators;
using System;
using System.Collections.Generic;
using Angene.Essentials;
using Angene.Essentials.Components;
using Angene.Main;
using Angene.Math.Vectors;
using Angene.Essentials.DefaultEntities;
using Angene.Essentials.GraphicsContexts;
using Angene.Extensions.Input;
using Angene.Input;
using Angene.Linux.X11;

namespace Game.Scenes
{
    public class CameraTestScene : IScene
    {
        public static object Instance { get; private set; }
        public List<Entity> Entities { get; private set; } = new List<Entity>();
        public string Name => "CameraTestScene";

        internal readonly Window _window;
        private IVkGraphicsContext _gfx;

        private IntPtr _vertexShaderModule;
        private IntPtr _fragmentShaderModule;

        private Entity _cameraEntity;
        private Entity _cubeEntity;
        private Entity _cubeEntity1;
        private Entity SpectatorCam;
        private Entity stick, stick2;

        private Entity _leftControllerEntity, _rightControllerEntity;
        
        public CameraTestScene(Window window)
        {
            _window = window ?? throw new ArgumentNullException(nameof(window));
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

            // --- Camera entity: Transform3D (position) + VulkanCamera (lens/orientation) ---
            Entity cameraParent =
                new Entity(new Vec3(0f, 0, 0f), new Vec3(0, 0, 0), new Vec3(1, 1, 1), "CameraParent");
            _cameraEntity = new Entity(new Vec3(0f, 0f, 0f), new Vec3(0, 0, 0), new Vec3(1, 1, 1), "MainCamera");
            _cameraEntity.AddComponent(new OpenXRHmd(new VulkanCamera
            {
                forward = new Vec3(0f, 0f, 1f), // looking toward the cube at the origin
                up = new Vec3(0f, 1f, 0f),
                fov = MathF.PI / 3f,
                aspectRatio = _gfx.VkExtent2D.width / (float)_gfx.VkExtent2D.height,
                nearPlane = 0.1f,
                farPlane = 100f,
                isPrimary = true
            }));
            cameraParent.AddChild(_cameraEntity);
            Entities.Add(_cameraEntity);
            
            SpectatorCam = new Entity(new Vec3(0, 0, 0), new Vec3(0, 0, 0), new Vec3(1, 1, 1), "spectatorCam");
            SpectatorCam.AddComponent(new VulkanCamera {
                forward = new Vec3(0, 0, 1), up = new Vec3(0, 1, 0),
                fov = MathF.PI / 3f,
                nearPlane = 0.1f,
                farPlane = 100f,
                priority = 0,
                clearDepth = true
            });

            var controller = _cameraEntity.AddScript<CameraControllerScript>();
            
            var hmd = _cameraEntity.GetComponent<OpenXRHmd>()!;
            hmd.head.AddChild(SpectatorCam);
            //cameraParent.AddChild(SpectatorCam);
            controller.Initialize(_cameraEntity, cameraParent);
            _cameraEntity.AddChild(hmd.head);

            Entities.Add(SpectatorCam);
            Entities.Add(hmd.head);
            
            _cubeEntity = Cube.Instantiate(_gfx, new Vec3(0, 0, 0), new Vec3(0, 0, 0), new Vec3(1, 1, 1), "Cube", (SlangShaderResources.IShader)Engine.Instance.ShaderCache[5], CameraMaterials.DefaultColors().ToArray());
            Entities.Add(_cubeEntity);
            _cubeEntity1 = Cube.Instantiate(_gfx, new Vec3(0f, 3f, 0f), new Vec3(0, 0, 0), new Vec3(2, 2, 1), "Cube1", (SlangShaderResources.IShader)Engine.Instance.ShaderCache[5], CameraMaterials.DefaultColors().ToArray());
            Entities.Add(_cubeEntity1);
            Entity cubeEntity2 = Cube.Instantiate(_gfx, new Vec3(0f, 3f, 2f), new Vec3(0, 0, 0), new Vec3(1, 1, 1), "Cube1", (SlangShaderResources.IShader)Engine.Instance.ShaderCache[5], CameraMaterials.DefaultColors().ToArray());
            Entities.Add(cubeEntity2);
            
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

            _gfx.CreatePipeline( attributes, 7 * sizeof(float));
            
            _leftControllerEntity  = Cube.Instantiate(_gfx, new Vec3(0, 0, 0), new Vec3(0, 0, 0), new Vec3(0.2f, 0.2f, 0.2f), "leftController", (SlangShaderResources.IShader)Engine.Instance.ShaderCache[5], CameraMaterials.DefaultColors().ToArray());
            _rightControllerEntity = Cube.Instantiate(_gfx, new Vec3(0, 0, 0), new Vec3(0, 0, 0), new Vec3(0.2f, 0.2f, 0.2f), "rightController", (SlangShaderResources.IShader)Engine.Instance.ShaderCache[5], CameraMaterials.DefaultColors().ToArray());
            OpenXRController l = _leftControllerEntity.AddComponent<OpenXRController>(new OpenXRController(OpenXRController.ControllerType.Left));
            OpenXRController r = _rightControllerEntity.AddComponent<OpenXRController>(new OpenXRController(OpenXRController.ControllerType.Right));
            l.ControllerTransform.ForceSetTransformVar(l.ControllerTransform.pos, l.ControllerTransform.rot,
                new Vec3(0.2f, 0.2f, 0.2f));
            r.ControllerTransform.ForceSetTransformVar(l.ControllerTransform.pos, l.ControllerTransform.rot,
                new Vec3(0.2f, 0.2f, 0.2f));
            Entities.Add(_leftControllerEntity);
            Entities.Add(_rightControllerEntity);
            _gfx.SetXrObjects(l, r);
            stick = Cube.Instantiate(_gfx, new Vec3(0, 0, 1), new Vec3(0, 0, 0),
                new Vec3(0.1f, 0.1f, 1f), "stick", (SlangShaderResources.IShader)Engine.Instance.ShaderCache[5],
                CameraMaterials.DefaultColors().ToArray());
            stick2 = Cube.Instantiate(_gfx, new Vec3(0, 0, 1), new Vec3(0, 0, 0),
                new Vec3(0.1f, 0.1f, 1f), "stick 2", (SlangShaderResources.IShader)Engine.Instance.ShaderCache[5],
                CameraMaterials.DefaultColors().ToArray());
            _leftControllerEntity.AddChild(stick);
            _rightControllerEntity.AddChild(stick2);
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
            
            _gfx.BeginFrame();
            _gfx.EndFrame();
            if (KeyDetection.IsKeyDown((uint)X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin1.e))
            {
                Logger.LogDebug(
                    $"X: {_rightControllerEntity.Transform.pos.X} Y: {_rightControllerEntity.Transform.pos.Y} Z: {_rightControllerEntity.Transform.pos.Z}, Rotation: X: {_rightControllerEntity.Transform.rot.X}, Y: {_rightControllerEntity.Transform.rot.Y}, Z: {_rightControllerEntity.Transform.rot.Z}",
                    LoggingTarget.MainGame);
                
                var q = Quaternion.FromEuler(_rightControllerEntity.Transform.rot);
                var fwd = q.Rotate(new Vec3(0, 0, -1));
                Logger.LogDebug($"local -Z in world: {fwd.X:F2} {fwd.Y:F2} {fwd.Z:F2}", LoggingTarget.MainGame);
            }
        }
        
        public void Cleanup()
        {
            // Pipeline/shader-module teardown belongs here once VkGraphicsContext exposes
            // per-resource destroy methods; today Cleanup() on the context sweeps
            // everything it tracked internally.
        }
    }
}
