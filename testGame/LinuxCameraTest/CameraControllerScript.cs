using System;
using System.Diagnostics;
using Angene.Common;
using Angene.Essentials;
using Angene.Essentials.Components;
using Angene.Math.Vectors;
using Latin1 = Angene.Input.Keys.IKeyCodeLangLinux.IKeyCodeLatin1;
using CursorKeys = Angene.Input.Keys.IKeyCodeCursorControlLinux;
using Game.Scenes;
using Angene.Input;
using static Angene.Essentials.Types;

namespace Game
{
    public class CameraControllerScript : IScreenPlay
    {
        private Transform3D _transform;
        internal VulkanCamera _camera;

        // Kept outside the components because VulkanCamera stores a raw forward vector,
        // not yaw/pitch angles -- these are the "source of truth" for orientation and we
        // rebuild _camera.forward from them every frame.
        private float _yaw = 0.0f;     // radians, 0 = looking down +Z
        private float _pitch = 0.0f;   // radians, clamped to avoid flipping over the poles

        private const float MoveSpeed = 3.0f;      // world units / second
        private const float LookSpeed = 1.6f;      // radians / second
        private const float PitchLimit = 1.5f;     // just under 90 degrees, in radians

        private KeyDetection keyDetection = new KeyDetection();
        //private MouseDetection mouseDetection = new MouseDetection();

        public void Initialize(Entity cameraEntity)
        {
            if (cameraEntity == null)
                throw new ArgumentNullException(nameof(cameraEntity));

            _transform = cameraEntity.GetComponent<Transform3D>();
            _camera = cameraEntity.GetComponent<VulkanCamera>();

            if (_transform == null || _camera == null)
            {
                Logger.LogError(
                    "[CameraControllerScript] Camera entity is missing a Transform3D or VulkanCamera component.",
                    LoggingTarget.MainGame);
                return;
            }


            keyDetection.Register(cameraEntity, true);
            //mouseDetection.Register(cameraEntity);

            // Derive the starting yaw/pitch from whatever forward vector was configured
            // when the VulkanCamera component was created, so the very first Update()
            // doesn't snap the view.
            Vec3 f = _camera.forward;
            _yaw = MathF.Atan2(f.X, f.Z);
            _pitch = MathF.Asin(Math.Clamp(f.Y, -1.0f, 1.0f));
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
                _yaw -= LookSpeed * delta;
            if (KeyDetection.IsKeyDown((uint)CursorKeys.Right))
                _yaw += LookSpeed * delta;
            if (KeyDetection.IsKeyDown((uint)CursorKeys.Up))
                _pitch += LookSpeed * delta;
            if (KeyDetection.IsKeyDown((uint)CursorKeys.Down))
                _pitch -= LookSpeed * delta;
            _pitch = Math.Clamp(_pitch, -PitchLimit, PitchLimit);

            Vec3 forward = new Vec3(
                MathF.Sin(_yaw) * MathF.Cos(_pitch),
                MathF.Sin(_pitch),
                MathF.Cos(_yaw) * MathF.Cos(_pitch)
            ).Normalized;

            Vec3 worldUp = new Vec3(0, 1, 0);
            Vec3 right = Vec3.Cross(forward, worldUp).Normalized;

            // --- Move (WASD + Space/C for vertical) ---
            Vec3 move = new Vec3(0, 0, 0);
            if (Angene.Input.KeyDetection.IsKeyDown((uint)Latin1.w)) move += forward;
            if (Angene.Input.KeyDetection.IsKeyDown((uint)Latin1.s)) move -= forward;
            if (Angene.Input.KeyDetection.IsKeyDown((uint)Latin1.d)) move += right;
            if (Angene.Input.KeyDetection.IsKeyDown((uint)Latin1.a)) move -= right;
            if (Angene.Input.KeyDetection.IsKeyDown((uint)Latin1.space)) move += worldUp;
            if (Angene.Input.KeyDetection.IsKeyDown((uint)Latin1.c)) move -= worldUp;

            /*
            if (MouseDetection.IsInWindow())
            {
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
                        case (uint)Keys.IKeyCodeMouseLinux.Button1Left:
                            kleft = true;
                            break;
                        case (uint)Keys.IKeyCodeMouseLinux.Button3Right:
                            kright = true;
                            break;
                        case (uint)Keys.IKeyCodeMouseLinux.Button2Middle:
                            kleft = true;
                            break;
                        case (uint)Keys.IKeyCodeMouseLinux.Button4ScrUp:
                            kup = true;
                            break;
                        case (uint)Keys.IKeyCodeMouseLinux.Button5ScrDown:
                            kdown = true;
                            break;
                    }
                }
                Logger.LogDebug($"Mouse X, Y: ({pos.Item1}, {pos.Item2}), Down Keys: left: {kleft}, right: {kright}, middle: {kmiddle}, up: {kup}, down: {kdown}", LoggingTarget.MainGame);
            }
            */

            if (move.Length > 0.0001f)
                _transform.pos += move.Normalized * (MoveSpeed * delta);

            // Push the recalculated orientation back onto the VulkanCamera component.
            _camera.forward = forward;
            _camera.up = worldUp;
        }
    }
}
