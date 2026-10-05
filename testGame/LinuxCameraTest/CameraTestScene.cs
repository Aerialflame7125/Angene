using Angene.Common;
using Angene.Graphics;
using static Angene.Vulkan.Interop.Structs;
using static Angene.Vulkan.Interop.Enumerators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Angene.Extensions.XR;
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
        private IVkGraphicsContext _gfx;

        private IntPtr _vertexShaderModule;
        private IntPtr _fragmentShaderModule;
        private IntPtr _pipeline;

        private Entity _cameraEntity;
        private Entity _cubeEntity;
        private Entity _cubeEntity1;
        private Entity SpectatorCam;

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
            _cameraEntity.AddComponent(new VulkanCamera
            {
                forward = new Vec3(0f, 0f, -1f), // looking toward the cube at the origin
                up = new Vec3(0f, 1f, 0f),
                fov = MathF.PI / 3f, // 60 degrees
                aspectRatio = _gfx.VkExtent2D.width / (float)_gfx.VkExtent2D.height,
                nearPlane = 0.1f,
                farPlane = 100f,
                isPrimary = true,
            });
            cameraParent.AddChild(_cameraEntity);
            Entities.Add(_cameraEntity);

            VulkanCamera mainCamera = _cameraEntity.GetComponent<VulkanCamera>();

            SpectatorCam = new Entity(new Vec3(0, 0, 0), new Vec3(0, 0, 0), new Vec3(1, 1, 1), "spectatorCam");

            var controller = _cameraEntity.AddScript<CameraControllerScript>();
            controller.Initialize(_cameraEntity);
            Entities.Add(SpectatorCam);

            // --- Cube entity: just needs a Transform3D, geometry is generated in Render() ---
            _cubeEntity = Cube.Instantiate(_gfx, new Vec3(0, 0, 0), new Vec3(0, 0, 0), new Vec3(1, 1, 1), "Cube", CameraMaterials.DefaultColors().ToArray());
            Entities.Add(_cubeEntity);
            
            _cubeEntity1 = Cube.Instantiate(_gfx, new Vec3(0f, 3f, 0f), new Vec3(0, 0, 0), new Vec3(2, 2, 1), "Cube1", CameraMaterials.DefaultColors().ToArray());
            Entities.Add(_cubeEntity1);
            // --- Pipeline (position + color vertex layout, matches Shaders.cs) ---
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

            _pipeline = _gfx.CreatePipeline( attributes, 7 * sizeof(float));
            
            _leftControllerEntity  = Cube.Instantiate(_gfx, new Vec3(0, 0, 0), new Vec3(0, 0, 0), new Vec3(0.2f, 0.2f, 0.2f), "leftController", CameraMaterials.DefaultColors().ToArray());
            _rightControllerEntity = Cube.Instantiate(_gfx, new Vec3(0, 0, 0), new Vec3(0, 0, 0), new Vec3(0.2f, 0.2f, 0.2f), "rightController", CameraMaterials.DefaultColors().ToArray());
            OpenXRController l = _leftControllerEntity.AddComponent<OpenXRController>(new OpenXRController(OpenXRController.ControllerType.Left));
            OpenXRController r = _rightControllerEntity.AddComponent<OpenXRController>(new OpenXRController(OpenXRController.ControllerType.Right));
            l.ControllerTransform.ForceSetTransformVar(l.ControllerTransform.pos, l.ControllerTransform.rot,
                new Vec3(0.2f, 0.2f, 0.2f));
            r.ControllerTransform.ForceSetTransformVar(l.ControllerTransform.pos, l.ControllerTransform.rot,
                new Vec3(0.2f, 0.2f, 0.2f));
            Entities.Add(_leftControllerEntity);
            Entities.Add(_rightControllerEntity);
            _gfx.SetXrObjects(l, r);
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
            
            _gfx.BeginFrame(0x00202020);
            _gfx.EndFrame();
        }
        
        public void Cleanup()
        {
            // Pipeline/shader-module teardown belongs here once VkGraphicsContext exposes
            // per-resource destroy methods; today Cleanup() on the context sweeps
            // everything it tracked internally.
        }
    }
}
