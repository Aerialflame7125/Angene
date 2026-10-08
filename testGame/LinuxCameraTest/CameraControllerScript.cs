using System;
using System.Diagnostics;
using Angene.Common;
using Angene.Essentials;
using Angene.Essentials.Components;
using Angene.Math.Vectors;
using Latin1 = Angene.Linux.X11.X11InputKeys.IKeyCodeLangLinux.IKeyCodeLatin1;
using CursorKeys = Angene.Linux.X11.X11InputKeys.IKeyCodeCursorControlLinux;
using static Angene.Linux.Wayland.WaylandInputKeys;
using Game.Scenes;
using Angene.Input;
using Angene.Linux.Wayland;
using static Angene.Essentials.Types;

namespace Game
{
    public class CameraControllerScript : IScreenPlay
    {
        private Transform3D _transform, _parentTransform;
        internal VulkanCamera _camera;
        internal Entity cameraEntity;
        private Vec3 rotation;

        // Kept outside the components because VulkanCamera stores a raw forward vector,
        // not yaw/pitch angles -- these are the "source of truth" for orientation and we
        // rebuild _camera.forward from them every frame.
        private float _yaw = 0.0f;     // radians, 0 = looking down +Z
        private float _pitch = 0.0f;   // radians, clamped to avoid flipping over the poles

        private const float MoveSpeed = 3.0f;      // world units / second
        private const float LookSpeed = 1.6f;      // radians / second
        private const float PitchLimit = 1.5f;     // just under 90 degrees, in radians
        
        private float mx, my;

        private KeyDetection keyDetection = new KeyDetection();
        private MouseDetection mouseDetection = new MouseDetection();

        public void Initialize(Entity cameraEntity, Entity cameraParent)
        {
            if (cameraEntity == null)
                throw new ArgumentNullException(nameof(cameraEntity));
            this.cameraEntity = cameraEntity;

            _transform = cameraEntity.GetComponent<Transform3D>();
            _parentTransform = cameraParent.GetComponent<Transform3D>();
            _camera = (VulkanCamera)cameraEntity.GetComponent<OpenXRHmd>().cam;

            if (_transform == null || _camera == null)
            {
                Logger.LogError(
                    "[CameraControllerScript] Camera entity is missing a Transform3D or VulkanCamera component.",
                    LoggingTarget.MainGame);
                return;
            }

            keyDetection.Register(cameraEntity);
            mouseDetection.Register(cameraEntity);
            
            _yaw = 0;
            _pitch = 0;
        }

        public void Start()
        {
            Logger.LogInfo("[CameraControllerScript] Ready. WASD to move, arrow keys to look.", LoggingTarget.MainGame);
        }

        public void Update(double dt)
        {
            if (_transform == null || _camera == null)
                return;

            float delta = (float)dt;

            // --- Look (arrow keys) ---
            if (KeyDetection.IsKeyDown((uint)CursorKeys.Left))
                _yaw += LookSpeed * delta;
            if (KeyDetection.IsKeyDown((uint)CursorKeys.Right))
                _yaw -= LookSpeed * delta;
            if (KeyDetection.IsKeyDown((uint)CursorKeys.Up))
                _pitch += LookSpeed * delta;
            if (KeyDetection.IsKeyDown((uint)CursorKeys.Down))
                _pitch -= LookSpeed * delta;
            
            _parentTransform.rot = new Vec3(_pitch, -_yaw, 0);
            
            Vec3 forward = new Vec3(
                MathF.Sin(_yaw) * MathF.Cos(_pitch),
                MathF.Sin(_pitch),
                -MathF.Cos(_yaw) * MathF.Cos(_pitch)
            ).Normalized;

            Vec3 worldUp = new Vec3(0, 1, 0);
            Vec3 right = Vec3.Cross(forward, worldUp).Normalized;

            Vec3 move = new Vec3(0, 0, 0);
            if (KeyDetection.IsKeyDown((uint)Latin1.w)) move += forward;   // restored
            if (KeyDetection.IsKeyDown((uint)Latin1.s)) move -= forward;   // restored
            if (KeyDetection.IsKeyDown((uint)Latin1.d)) move += right;
            if (KeyDetection.IsKeyDown((uint)Latin1.a)) move -= right;
            if (KeyDetection.IsKeyDown((uint)Latin1.space)) move += worldUp;
            if (KeyDetection.IsKeyDown((uint)Latin1.c)) move -= worldUp;
            if (KeyDetection.IsKeyDown((uint)Latin1.e)) Logger.LogDebug($"X: {_transform.pos.X} Y: {_transform.pos.Y} Z: {_transform.pos.Z}, Rotation: X: {_transform.rot.X}, Y: {_transform.rot.Y}, Z: {_transform.rot.Z}", LoggingTarget.MainGame);
            
            (float, float) pos = MouseDetection.GetPosition();
            bool kleft = false;
            bool kright = false;
            bool kmiddle = false;
            bool kup = false;
            bool kdown = false;
            
            foreach (uint item in MouseDetection.GetDownButtons)
            {
                switch (item)
                {
                    case (uint)WaylandInputKeys.KeysAndButtons.BTN_LEFT:
                        kleft = true;
                        break;
                    case (uint)WaylandInputKeys.KeysAndButtons.BTN_RIGHT:
                        kright = true;
                        break;
                    case (uint)WaylandInputKeys.KeysAndButtons.BTN_MIDDLE:
                        kmiddle = true;
                        break;
                    /*
                    case (uint)WaylandInputKeys.KeysAndButtons.Button4ScrUp:
                        kup = true;
                        break;
                    case (uint)WaylandInputKeys.KeysAndButtons.Button5ScrDown:
                        kdown = true;
                        break;
                    */
                }
            }

            if (move.Length > 0.0001f)
                _parentTransform.pos = _parentTransform.pos + move.Normalized * (MoveSpeed * delta);
        }
    }
}
