using System;

namespace Angene.Graphics.OpenGL
    {
        /// <summary>
        /// Helper class for drawing common 3D shapes and primitives.
        /// Provides easy-to-use methods for standard geometric shapes.
        /// </summary>
        public static class Shapes3D
        {
            /// <summary>
            /// Draws a wireframe cube centered at the current position.
            /// </summary>
            /// <param name="renderer">The OpenGL renderer to use.</param>
            /// <param name="size">Size of the cube (edge length).</param>
            /// <param name="r">Red component (0.0 to 1.0).</param>
            /// <param name="g">Green component (0.0 to 1.0).</param>
            /// <param name="b">Blue component (0.0 to 1.0).</param>
            public static void DrawWireCube(OpenGlRenderer renderer, float size, float r, float g, float b)
            {
                float half = size / 2.0f;
                renderer.SetColor(r, g, b);
                renderer.BeginDraw(PrimitiveType.Lines);

                // Bottom square
                renderer.AddVertex(-half, -half, -half);
                renderer.AddVertex(half, -half, -half);

                renderer.AddVertex(half, -half, -half);
                renderer.AddVertex(half, -half, half);

                renderer.AddVertex(half, -half, half);
                renderer.AddVertex(-half, -half, half);

                renderer.AddVertex(-half, -half, half);
                renderer.AddVertex(-half, -half, -half);

                // Top square
                renderer.AddVertex(-half, half, -half);
                renderer.AddVertex(half, half, -half);

                renderer.AddVertex(half, half, -half);
                renderer.AddVertex(half, half, half);

                renderer.AddVertex(half, half, half);
                renderer.AddVertex(-half, half, half);

                renderer.AddVertex(-half, half, half);
                renderer.AddVertex(-half, half, -half);

                // Vertical edges
                renderer.AddVertex(-half, -half, -half);
                renderer.AddVertex(-half, half, -half);

                renderer.AddVertex(half, -half, -half);
                renderer.AddVertex(half, half, -half);

                renderer.AddVertex(half, -half, half);
                renderer.AddVertex(half, half, half);

                renderer.AddVertex(-half, -half, half);
                renderer.AddVertex(-half, half, half);

                renderer.EndDraw();
            }

            /// <summary>
            /// Draws a sphere using triangle approximation.
            /// </summary>
            /// <param name="renderer">The OpenGL renderer to use.</param>
            /// <param name="radius">Radius of the sphere.</param>
            /// <param name="slices">Number of horizontal divisions (more = smoother).</param>
            /// <param name="stacks">Number of vertical divisions (more = smoother).</param>
            /// <param name="r">Red component (0.0 to 1.0).</param>
            /// <param name="g">Green component (0.0 to 1.0).</param>
            /// <param name="b">Blue component (0.0 to 1.0).</param>
            public static void DrawSphere(OpenGlRenderer renderer, float radius, int slices, int stacks,
                float r, float g, float b)
            {
                renderer.SetColor(r, g, b);

                for (int i = 0; i < stacks; i++)
                {
                    float lat0 = (float)Math.PI * (-0.5f + (float)i / stacks);
                    float z0 = (float)Math.Sin(lat0);
                    float zr0 = (float)Math.Cos(lat0);

                    float lat1 = (float)Math.PI * (-0.5f + (float)(i + 1) / stacks);
                    float z1 = (float)Math.Sin(lat1);
                    float zr1 = (float)Math.Cos(lat1);

                    renderer.BeginDraw(PrimitiveType.QuadStrip);

                    for (int j = 0; j <= slices; j++)
                    {
                        float lng = 2 * (float)Math.PI * (float)j / slices;
                        float x = (float)Math.Cos(lng);
                        float y = (float)Math.Sin(lng);

                        renderer.AddVertex(x * zr0 * radius, y * zr0 * radius, z0 * radius);
                        renderer.AddVertex(x * zr1 * radius, y * zr1 * radius, z1 * radius);
                    }

                    renderer.EndDraw();
                }
            }

            /// <summary>
            /// Draws a flat plane (ground/floor) centered at the current position.
            /// </summary>
            /// <param name="renderer">The OpenGL renderer to use.</param>
            /// <param name="width">Width of the plane.</param>
            /// <param name="depth">Depth of the plane.</param>
            /// <param name="r">Red component (0.0 to 1.0).</param>
            /// <param name="g">Green component (0.0 to 1.0).</param>
            /// <param name="b">Blue component (0.0 to 1.0).</param>
            public static void DrawPlane(OpenGlRenderer renderer, float width, float depth,
                float r, float g, float b)
            {
                float halfW = width / 2.0f;
                float halfD = depth / 2.0f;

                renderer.SetColor(r, g, b);
                renderer.BeginDraw(PrimitiveType.Quads);

                renderer.AddVertex(-halfW, 0, -halfD);
                renderer.AddVertex(halfW, 0, -halfD);
                renderer.AddVertex(halfW, 0, halfD);
                renderer.AddVertex(-halfW, 0, halfD);

                renderer.EndDraw();
            }

            /// <summary>
            /// Draws a pyramid with a square base.
            /// </summary>
            /// <param name="renderer">The OpenGL renderer to use.</param>
            /// <param name="baseSize">Size of the square base.</param>
            /// <param name="height">Height of the pyramid.</param>
            /// <param name="r">Red component (0.0 to 1.0).</param>
            /// <param name="g">Green component (0.0 to 1.0).</param>
            /// <param name="b">Blue component (0.0 to 1.0).</param>
            public static void DrawPyramid(OpenGlRenderer renderer, float baseSize, float height,
                float r, float g, float b)
            {
                float half = baseSize / 2.0f;

                renderer.BeginDraw(PrimitiveType.Triangles);

                // Front face
                renderer.SetColor(r, g, b);
                renderer.AddVertex(0, height, 0);
                renderer.AddVertex(-half, 0, half);
                renderer.AddVertex(half, 0, half);

                // Right face
                renderer.SetColor(r * 0.8f, g * 0.8f, b * 0.8f);
                renderer.AddVertex(0, height, 0);
                renderer.AddVertex(half, 0, half);
                renderer.AddVertex(half, 0, -half);

                // Back face
                renderer.SetColor(r * 0.6f, g * 0.6f, b * 0.6f);
                renderer.AddVertex(0, height, 0);
                renderer.AddVertex(half, 0, -half);
                renderer.AddVertex(-half, 0, -half);

                // Left face
                renderer.SetColor(r * 0.7f, g * 0.7f, b * 0.7f);
                renderer.AddVertex(0, height, 0);
                renderer.AddVertex(-half, 0, -half);
                renderer.AddVertex(-half, 0, half);

                renderer.EndDraw();

                // Base
                renderer.SetColor(r * 0.5f, g * 0.5f, b * 0.5f);
                renderer.BeginDraw(PrimitiveType.Quads);
                renderer.AddVertex(-half, 0, -half);
                renderer.AddVertex(half, 0, -half);
                renderer.AddVertex(half, 0, half);
                renderer.AddVertex(-half, 0, half);
                renderer.EndDraw();
            }

            /// <summary>
            /// Draws 3D coordinate axes for debugging and orientation.
            /// X-axis is red, Y-axis is green, Z-axis is blue.
            /// </summary>
            /// <param name="renderer">The OpenGL renderer to use.</param>
            /// <param name="length">Length of each axis.</param>
            public static void DrawAxes(OpenGlRenderer renderer, float length)
            {
                renderer.BeginDraw(PrimitiveType.Lines);

                // X-axis (red)
                renderer.SetColor(1.0f, 0.0f, 0.0f);
                renderer.AddVertex(0, 0, 0);
                renderer.AddVertex(length, 0, 0);

                // Y-axis (green)
                renderer.SetColor(0.0f, 1.0f, 0.0f);
                renderer.AddVertex(0, 0, 0);
                renderer.AddVertex(0, length, 0);

                // Z-axis (blue)
                renderer.SetColor(0.0f, 0.0f, 1.0f);
                renderer.AddVertex(0, 0, 0);
                renderer.AddVertex(0, 0, length);

                renderer.EndDraw();
            }

            /// <summary>
            /// Draws a grid on the XZ plane for ground reference.
            /// </summary>
            /// <param name="renderer">The OpenGL renderer to use.</param>
            /// <param name="size">Total size of the grid.</param>
            /// <param name="divisions">Number of grid divisions.</param>
            /// <param name="r">Red component (0.0 to 1.0).</param>
            /// <param name="g">Green component (0.0 to 1.0).</param>
            /// <param name="b">Blue component (0.0 to 1.0).</param>
            public static void DrawGrid(OpenGlRenderer renderer, float size, int divisions,
                float r, float g, float b)
            {
                float step = size / divisions;
                float half = size / 2.0f;

                renderer.SetColor(r, g, b);
                renderer.BeginDraw(PrimitiveType.Lines);

                // Lines parallel to X-axis
                for (int i = 0; i <= divisions; i++)
                {
                    float z = -half + i * step;
                    renderer.AddVertex(-half, 0, z);
                    renderer.AddVertex(half, 0, z);
                }

                // Lines parallel to Z-axis
                for (int i = 0; i <= divisions; i++)
                {
                    float x = -half + i * step;
                    renderer.AddVertex(x, 0, -half);
                    renderer.AddVertex(x, 0, half);
                }

                renderer.EndDraw();
            }
        }

        /// <summary>
        /// Camera helper for easy 3D scene navigation.
        /// Manages camera position, rotation, and view matrix.
        /// </summary>
        public class Camera3D
        {
            /// <summary>Camera position in world space.</summary>
            public float X { get; set; }
            public float Y { get; set; }
            public float Z { get; set; }

            /// <summary>Camera rotation in degrees.</summary>
            public float Pitch { get; set; }  // Rotation around X-axis
            public float Yaw { get; set; }    // Rotation around Y-axis
            public float Roll { get; set; }   // Rotation around Z-axis

            /// <summary>
            /// Creates a new camera at the origin looking down the negative Z-axis.
            /// </summary>
            public Camera3D()
            {
                X = 0;
                Y = 0;
                Z = 0;
                Pitch = 0;
                Yaw = 0;
                Roll = 0;
            }

            /// <summary>
            /// Creates a new camera at the specified position.
            /// </summary>
            public Camera3D(float x, float y, float z)
            {
                X = x;
                Y = y;
                Z = z;
                Pitch = 0;
                Yaw = 0;
                Roll = 0;
            }

            /// <summary>
            /// Applies the camera transformation to the current OpenGL renderer.
            /// Call this after BeginFrame() and before drawing your scene.
            /// </summary>
            /// <param name="renderer">The OpenGL renderer to apply the camera to.</param>
            public void Apply(OpenGlRenderer renderer)
            {
                // Apply rotations
                renderer.Rotate(-Pitch, 1, 0, 0);
                renderer.Rotate(-Yaw, 0, 1, 0);
                renderer.Rotate(-Roll, 0, 0, 1);

                // Apply translation (inverted because we're moving the world, not the camera)
                renderer.Translate(-X, -Y, -Z);
            }

            /// <summary>
            /// Moves the camera forward/backward along its view direction.
            /// </summary>
            /// <param name="distance">Distance to move (positive = forward, negative = backward).</param>
            public void MoveForward(float distance)
            {
                float yawRad = Yaw * (float)Math.PI / 180.0f;
                X += (float)Math.Sin(yawRad) * distance;
                Z -= (float)Math.Cos(yawRad) * distance;
            }

            /// <summary>
            /// Moves the camera right/left perpendicular to its view direction.
            /// </summary>
            /// <param name="distance">Distance to move (positive = right, negative = left).</param>
            public void Strafe(float distance)
            {
                float yawRad = Yaw * (float)Math.PI / 180.0f;
                X += (float)Math.Cos(yawRad) * distance;
                Z += (float)Math.Sin(yawRad) * distance;
            }

            /// <summary>
            /// Moves the camera up/down in world space.
            /// </summary>
            /// <param name="distance">Distance to move (positive = up, negative = down).</param>
            public void MoveVertical(float distance)
            {
                Y += distance;
            }
        }
    }