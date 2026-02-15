// ==============================================================================
// Angene OpenGL 3D Rendering - Quick Start Guide
// ==============================================================================
//
// This guide shows you how to integrate 3D OpenGL rendering into your Angene
// game engine applications. The API is designed to be simple and intuitive
// while providing powerful 3D graphics capabilities.
//
// ==============================================================================

using Angene.Graphics.OpenGL;
using System;

namespace Angene.Examples
{
    /// <summary>
    /// Example: Basic 3D rendering with a spinning cube.
    /// This is the simplest way to get started with 3D graphics in Angene.
    /// </summary>
    public class Example1_BasicCube
    {
        private OpenGlRenderer renderer;
        private float rotation = 0;

        public void Initialize(IntPtr windowHandle, int width, int height)
        {
            // Create the OpenGL renderer for your window
            renderer = new OpenGlRenderer(windowHandle, width, height);

            // Optional: Change the background color
            renderer.SetClearColor(0.2f, 0.3f, 0.4f);
        }

        public void Update(float deltaTime)
        {
            // Animate the rotation
            rotation += 50 * deltaTime; // 50 degrees per second
        }

        public void Render()
        {
            // 1. Start the frame
            renderer.BeginFrame();

            // 2. Position the camera
            renderer.Translate(0, 0, -6); // Move back 6 units to see the cube

            // 3. Rotate the cube
            renderer.Rotate(rotation, 1, 1, 0); // Rotate around diagonal axis

            // 4. Draw the cube
            renderer.DrawCube();

            // 5. Present the frame
            renderer.EndFrame();
        }

        public void Cleanup()
        {
            renderer?.Dispose();
        }
    }

    /// <summary>
    /// Example: Drawing custom 3D shapes using primitives.
    /// Shows how to create your own geometry with triangles and quads.
    /// </summary>
    public class Example2_CustomShapes
    {
        private OpenGlRenderer renderer;
        private float time = 0;

        public void Initialize(IntPtr windowHandle, int width, int height)
        {
            renderer = new OpenGlRenderer(windowHandle, width, height);
            renderer.SetClearColor(0.1f, 0.1f, 0.15f);
        }

        public void Update(float deltaTime)
        {
            time += deltaTime;
        }

        public void Render()
        {
            renderer.BeginFrame();
            renderer.Translate(0, 0, -8);

            // Draw a custom triangle
            renderer.Rotate(time * 30, 0, 1, 0);

            renderer.BeginDraw(PrimitiveType.Triangles);

            // Top vertex (red)
            renderer.SetColor(1.0f, 0.0f, 0.0f);
            renderer.AddVertex(0, 1, 0);

            // Bottom-left vertex (green)
            renderer.SetColor(0.0f, 1.0f, 0.0f);
            renderer.AddVertex(-1, -1, 0);

            // Bottom-right vertex (blue)
            renderer.SetColor(0.0f, 0.0f, 1.0f);
            renderer.AddVertex(1, -1, 0);

            renderer.EndDraw();

            renderer.EndFrame();
        }

        public void Cleanup()
        {
            renderer?.Dispose();
        }
    }

    /// <summary>
    /// Example: Using helper shapes and camera control.
    /// Demonstrates the built-in shape library and camera system.
    /// </summary>
    public class Example3_ShapesAndCamera
    {
        private OpenGlRenderer renderer;
        private Camera3D camera;
        private float time = 0;

        public void Initialize(IntPtr windowHandle, int width, int height)
        {
            renderer = new OpenGlRenderer(windowHandle, width, height);
            renderer.SetClearColor(0.05f, 0.05f, 0.1f);

            // Create a camera positioned above and behind the scene
            camera = new Camera3D(0, 3, 10);
            camera.Pitch = -15; // Look down slightly
        }

        public void Update(float deltaTime)
        {
            time += deltaTime;

            // Simple camera controls (you'd wire these to actual input)
            // camera.MoveForward(speed * deltaTime);
            // camera.Strafe(speed * deltaTime);
            // camera.Yaw += rotationSpeed * deltaTime;
        }

        public void Render()
        {
            renderer.BeginFrame();

            // Apply camera transformation
            camera.Apply(renderer);

            // Draw a reference grid
            Shapes3D.DrawGrid(renderer, 20, 20, 0.3f, 0.3f, 0.3f);

            // Draw coordinate axes for reference
            Shapes3D.DrawAxes(renderer, 2.0f);

            // Draw various shapes
            renderer.PushMatrix();
            renderer.Translate(-3, 1, 0);
            renderer.Rotate(time * 45, 0, 1, 0);
            Shapes3D.DrawPyramid(renderer, 1.5f, 2.0f, 1.0f, 0.5f, 0.0f);
            renderer.PopMatrix();

            renderer.PushMatrix();
            renderer.Translate(3, 1, 0);
            renderer.Rotate(time * 60, 1, 1, 0);
            Shapes3D.DrawSphere(renderer, 1.0f, 16, 16, 0.0f, 0.7f, 1.0f);
            renderer.PopMatrix();

            renderer.PushMatrix();
            renderer.Translate(0, 0.5f, -3);
            Shapes3D.DrawWireCube(renderer, 1.5f, 0.5f, 1.0f, 0.5f);
            renderer.PopMatrix();

            renderer.EndFrame();
        }

        public void Cleanup()
        {
            renderer?.Dispose();
        }
    }

    /// <summary>
    /// Example: Complex scene with multiple objects and transformations.
    /// Shows advanced techniques like matrix push/pop for object hierarchy.
    /// </summary>
    public class Example4_ComplexScene
    {
        private OpenGlRenderer renderer;
        private Camera3D camera;
        private float sunAngle = 0;

        public void Initialize(IntPtr windowHandle, int width, int height)
        {
            renderer = new OpenGlRenderer(windowHandle, width, height);
            renderer.SetClearColor(0.1f, 0.1f, 0.2f);

            camera = new Camera3D(0, 5, 15);
            camera.Pitch = -20;
        }

        public void Update(float deltaTime)
        {
            sunAngle += 20 * deltaTime;

            // Rotate camera around the scene
            camera.Yaw += 10 * deltaTime;
        }

        public void Render()
        {
            renderer.BeginFrame();
            camera.Apply(renderer);

            // Draw ground plane
            renderer.PushMatrix();
            renderer.Translate(0, 0, 0);
            Shapes3D.DrawPlane(renderer, 30, 30, 0.2f, 0.3f, 0.2f);
            renderer.PopMatrix();

            // Draw central structure
            renderer.PushMatrix();
            renderer.Translate(0, 2, 0);
            renderer.Rotate(sunAngle, 0, 1, 0);
            renderer.DrawCube();

            // Draw orbiting satellite (relative to central structure)
            renderer.PushMatrix();
            renderer.Translate(3, 0, 0); // Move 3 units in local X
            renderer.Rotate(sunAngle * 2, 1, 0, 0);
            renderer.Rotate(sunAngle * 3, 0, 1, 0);
            Shapes3D.DrawSphere(renderer, 0.5f, 12, 12, 1.0f, 0.8f, 0.0f);
            renderer.PopMatrix(); // Back to central structure space

            renderer.PopMatrix(); // Back to world space

            // Draw corner markers
            for (int x = -1; x <= 1; x += 2)
            {
                for (int z = -1; z <= 1; z += 2)
                {
                    renderer.PushMatrix();
                    renderer.Translate(x * 8, 1, z * 8);
                    Shapes3D.DrawPyramid(renderer, 1.0f, 2.0f,
                        x > 0 ? 1.0f : 0.3f,
                        0.3f,
                        z > 0 ? 1.0f : 0.3f);
                    renderer.PopMatrix();
                }
            }

            renderer.EndFrame();
        }

        public void Cleanup()
        {
            renderer?.Dispose();
        }
    }
}

// ==============================================================================
// INTEGRATION WITH EXISTING ANGENE CODE
// ==============================================================================
//
// If you're using the existing GdiRenderer for 2D graphics, you can easily
// add 3D rendering alongside it:
//
// public class MyGame
// {
//     private GdiRenderer gdiRenderer;      // For 2D UI
//     private OpenGlRenderer glRenderer;     // For 3D world
//     
//     public void Initialize(IntPtr hwnd)
//     {
//         IntPtr hdc = Win32.GetDC(hwnd);
//         gdiRenderer = new GdiRenderer(hdc);
//         glRenderer = new OpenGlRenderer(hwnd, 800, 600);
//     }
//     
//     public void Render()
//     {
//         // Render 3D world first
//         glRenderer.BeginFrame();
//         // ... draw 3D stuff ...
//         glRenderer.EndFrame();
//         
//         // Then render 2D UI on top
//         gdiRenderer.BeginFrame(800, 600);
//         gdiRenderer.DrawText(10, 10, "Score: 100", 0xFFFFFF);
//         gdiRenderer.EndFrame();
//     }
// }
//
// ==============================================================================
// COMMON PATTERNS
// ==============================================================================
//
// 1. BASIC RENDERING LOOP:
//    - BeginFrame()
//    - Position camera (Translate/Rotate)
//    - Draw objects
//    - EndFrame()
//
// 2. OBJECT TRANSFORMATION:
//    - PushMatrix()          // Save current state
//    - Translate/Rotate      // Position the object
//    - Draw object
//    - PopMatrix()           // Restore state
//
// 3. CAMERA MOVEMENT:
//    - Update camera position based on input
//    - Apply camera transformation after BeginFrame()
//    - All subsequent draws use camera view
//
// 4. WINDOW RESIZE:
//    - Call renderer.Resize(newWidth, newHeight)
//    - Updates viewport and maintains proper aspect ratio
//
// ==============================================================================
// PERFORMANCE TIPS
// ==============================================================================
//
// 1. Group similar objects together to minimize state changes
// 2. Use PushMatrix/PopMatrix instead of recalculating transforms
// 3. Pre-calculate static geometry when possible
// 4. Keep vertex counts reasonable (1000s, not millions)
// 5. Use the built-in shapes for prototyping, create custom geometry for production
//
// ==============================================================================
// TROUBLESHOOTING
// ==============================================================================
//
// Q: I see nothing rendered
// A: Make sure you're calling BeginFrame/EndFrame and that objects are
//    positioned in front of the camera (negative Z values)
//
// Q: My objects look stretched
// A: Call renderer.Resize() when your window size changes to maintain
//    the correct aspect ratio
//
// Q: Colors look wrong
// A: Remember colors are in 0.0 to 1.0 range, not 0-255
//
// Q: Objects disappear when I rotate the camera
// A: You might be clipping near/far planes. Objects must be between
//    0.1 and 100.0 units from camera by default
//
// ==============================================================================