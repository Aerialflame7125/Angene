using Angene.Graphics;
using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.Runtime.InteropServices;

namespace Angene.Graphics.OpenGL
    {
        /// <summary>
        /// Hardware-accelerated 3D renderer using OpenGL.
        /// Provides an easy-to-use interface for rendering 3D graphics with depth testing,
        /// perspective projection, and basic 3D primitives.
        /// </summary>
        public sealed class OpenGlRenderer : IDisposable
        {
            private readonly IntPtr _hwnd;
            private IntPtr _hdc;
            private IntPtr _hglrc;
            private int _width;
            private int _height;
            private bool _initialized;

            /// <summary>
            /// Gets whether the OpenGL context was successfully initialized.
            /// </summary>
            public bool IsInitialized => _initialized;

            /// <summary>
            /// Gets the width of the rendering viewport.
            /// </summary>
            public int Width => _width;

            /// <summary>
            /// Gets the height of the rendering viewport.
            /// </summary>
            public int Height => _height;

            /// <summary>
            /// Creates a new OpenGL renderer for the specified window.
            /// </summary>
            /// <param name="hwnd">Handle to the window to render into.</param>
            /// <param name="width">Initial viewport width in pixels.</param>
            /// <param name="height">Initial viewport height in pixels.</param>
            public OpenGlRenderer(IntPtr hwnd, int width, int height)
            {
                _hwnd = hwnd;
                _width = width;
                _height = height;

                Initialize();
            }

            /// <summary>
            /// Initializes the OpenGL rendering context with default settings.
            /// Sets up double buffering, depth testing, and a dark gray background.
            /// </summary>
            private void Initialize()
            {
                _hdc = Angene.Main.Win32.GetDC(_hwnd);
                if (_hdc == IntPtr.Zero)
                {
                    Console.WriteLine("Failed to get device context");
                    return;
                }

                // Setup pixel format for OpenGL
                var pfd = new PixelFormatDescriptor
                {
                    nSize = (ushort)Marshal.SizeOf<PixelFormatDescriptor>(),
                    nVersion = 1,
                    dwFlags = PFD.DRAW_TO_WINDOW | PFD.SUPPORT_OPENGL | PFD.DOUBLEBUFFER,
                    iPixelType = PFD.TYPE_RGBA,
                    cColorBits = 24,
                    cDepthBits = 16,
                    iLayerType = PFD.MAIN_PLANE
                };

                int pixelFormat = OpenGL32.ChoosePixelFormat(_hdc, ref pfd);
                if (pixelFormat == 0)
                {
                    Console.WriteLine("Failed to choose pixel format");
                    return;
                }

                if (!OpenGL32.SetPixelFormat(_hdc, pixelFormat, ref pfd))
                {
                    Console.WriteLine("Failed to set pixel format");
                    return;
                }

                // Create and activate OpenGL context
                _hglrc = OpenGL32.wglCreateContext(_hdc);
                if (_hglrc == IntPtr.Zero)
                {
                    Console.WriteLine("Failed to create OpenGL context");
                    return;
                }

                if (!OpenGL32.wglMakeCurrent(_hdc, _hglrc))
                {
                    Console.WriteLine("Failed to make OpenGL context current");
                    return;
                }

                // Configure OpenGL state
                OpenGL32.glEnable(GL.DEPTH_TEST);
                OpenGL32.glDepthFunc(GL.LESS);
                OpenGL32.glClearColor(0.1f, 0.1f, 0.1f, 1.0f);

                SetupPerspective(_width, _height);

                _initialized = true;
                Console.WriteLine("OpenGL renderer initialized successfully");
            }

            /// <summary>
            /// Updates the viewport size and perspective projection.
            /// Call this when the window is resized to maintain proper aspect ratio.
            /// </summary>
            /// <param name="width">New viewport width in pixels.</param>
            /// <param name="height">New viewport height in pixels.</param>
            public void Resize(int width, int height)
            {
                _width = width;
                _height = height;

                if (_initialized)
                {
                    SetupPerspective(width, height);
                }
            }

            /// <summary>
            /// Configures the perspective projection matrix with a 45-degree field of view.
            /// </summary>
            /// <param name="width">Viewport width for aspect ratio calculation.</param>
            /// <param name="height">Viewport height for aspect ratio calculation.</param>
            private void SetupPerspective(int width, int height)
            {
                OpenGL32.glViewport(0, 0, width, height);
                OpenGL32.glMatrixMode(GL.PROJECTION);
                OpenGL32.glLoadIdentity();

                double aspect = height > 0 ? (double)width / height : 1.0;
                OpenGL32.gluPerspective(45.0, aspect, 0.1, 100.0);

                OpenGL32.glMatrixMode(GL.MODELVIEW);
                OpenGL32.glLoadIdentity();
            }

            /// <summary>
            /// Begins a new rendering frame.
            /// Clears the color and depth buffers and resets the model-view matrix.
            /// Always call this before any drawing commands.
            /// </summary>
            public void BeginFrame()
            {
                if (!_initialized) return;

                OpenGL32.wglMakeCurrent(_hdc, _hglrc);
                OpenGL32.glClear(GL.COLOR_BUFFER_BIT | GL.DEPTH_BUFFER_BIT);
                OpenGL32.glLoadIdentity();
            }

            /// <summary>
            /// Finishes the current frame and presents it to the screen.
            /// Swaps the back buffer to the front buffer for display.
            /// Always call this after all drawing commands are complete.
            /// </summary>
            public void EndFrame()
            {
                if (!_initialized) return;

                OpenGL32.SwapBuffers(_hdc);
            }

            /// <summary>
            /// Sets the background clear color for subsequent frames.
            /// </summary>
            /// <param name="r">Red component (0.0 to 1.0).</param>
            /// <param name="g">Green component (0.0 to 1.0).</param>
            /// <param name="b">Blue component (0.0 to 1.0).</param>
            /// <param name="a">Alpha component (0.0 to 1.0), typically 1.0 for opaque.</param>
            public void SetClearColor(float r, float g, float b, float a = 1.0f)
            {
                if (!_initialized) return;
                OpenGL32.glClearColor(r, g, b, a);
            }

            /// <summary>
            /// Translates (moves) the current transformation matrix.
            /// Affects all subsequent drawing until the next BeginFrame or LoadIdentity call.
            /// </summary>
            /// <param name="x">Translation along the X axis.</param>
            /// <param name="y">Translation along the Y axis.</param>
            /// <param name="z">Translation along the Z axis (negative values move away from camera).</param>
            public void Translate(float x, float y, float z)
            {
                if (!_initialized) return;
                OpenGL32.glTranslatef(x, y, z);
            }

            /// <summary>
            /// Rotates the current transformation matrix around an arbitrary axis.
            /// </summary>
            /// <param name="angle">Rotation angle in degrees.</param>
            /// <param name="x">X component of the rotation axis (1.0 for X-axis rotation).</param>
            /// <param name="y">Y component of the rotation axis (1.0 for Y-axis rotation).</param>
            /// <param name="z">Z component of the rotation axis (1.0 for Z-axis rotation).</param>
            public void Rotate(float angle, float x, float y, float z)
            {
                if (!_initialized) return;
                OpenGL32.glRotatef(angle, x, y, z);
            }

            /// <summary>
            /// Pushes the current transformation matrix onto the stack.
            /// Use this to save the current transformation state before making temporary changes.
            /// </summary>
            public void PushMatrix()
            {
                if (!_initialized) return;
                OpenGL32.glPushMatrix();
            }

            /// <summary>
            /// Pops the top matrix from the stack, restoring the previous transformation state.
            /// Must be paired with a previous PushMatrix call.
            /// </summary>
            public void PopMatrix()
            {
                if (!_initialized) return;
                OpenGL32.glPopMatrix();
            }

            /// <summary>
            /// Draws a colored 3D cube centered at the origin.
            /// Each face has a different color for easy identification.
            /// The cube extends from -1 to +1 on each axis.
            /// </summary>
            public void DrawCube()
            {
                if (!_initialized) return;

                OpenGL32.glBegin(GL.QUADS);

                // Front face (red)
                OpenGL32.glColor3f(1.0f, 0.0f, 0.0f);
                OpenGL32.glVertex3f(-1.0f, -1.0f, 1.0f);
                OpenGL32.glVertex3f(1.0f, -1.0f, 1.0f);
                OpenGL32.glVertex3f(1.0f, 1.0f, 1.0f);
                OpenGL32.glVertex3f(-1.0f, 1.0f, 1.0f);

                // Back face (green)
                OpenGL32.glColor3f(0.0f, 1.0f, 0.0f);
                OpenGL32.glVertex3f(-1.0f, -1.0f, -1.0f);
                OpenGL32.glVertex3f(-1.0f, 1.0f, -1.0f);
                OpenGL32.glVertex3f(1.0f, 1.0f, -1.0f);
                OpenGL32.glVertex3f(1.0f, -1.0f, -1.0f);

                // Top face (blue)
                OpenGL32.glColor3f(0.0f, 0.0f, 1.0f);
                OpenGL32.glVertex3f(-1.0f, 1.0f, -1.0f);
                OpenGL32.glVertex3f(-1.0f, 1.0f, 1.0f);
                OpenGL32.glVertex3f(1.0f, 1.0f, 1.0f);
                OpenGL32.glVertex3f(1.0f, 1.0f, -1.0f);

                // Bottom face (yellow)
                OpenGL32.glColor3f(1.0f, 1.0f, 0.0f);
                OpenGL32.glVertex3f(-1.0f, -1.0f, -1.0f);
                OpenGL32.glVertex3f(1.0f, -1.0f, -1.0f);
                OpenGL32.glVertex3f(1.0f, -1.0f, 1.0f);
                OpenGL32.glVertex3f(-1.0f, -1.0f, 1.0f);

                // Right face (cyan)
                OpenGL32.glColor3f(0.0f, 1.0f, 1.0f);
                OpenGL32.glVertex3f(1.0f, -1.0f, -1.0f);
                OpenGL32.glVertex3f(1.0f, 1.0f, -1.0f);
                OpenGL32.glVertex3f(1.0f, 1.0f, 1.0f);
                OpenGL32.glVertex3f(1.0f, -1.0f, 1.0f);

                // Left face (magenta)
                OpenGL32.glColor3f(1.0f, 0.0f, 1.0f);
                OpenGL32.glVertex3f(-1.0f, -1.0f, -1.0f);
                OpenGL32.glVertex3f(-1.0f, -1.0f, 1.0f);
                OpenGL32.glVertex3f(-1.0f, 1.0f, 1.0f);
                OpenGL32.glVertex3f(-1.0f, 1.0f, -1.0f);

                OpenGL32.glEnd();
            }

            /// <summary>
            /// Begins drawing a custom primitive shape.
            /// Must be paired with EndDraw(). Use SetColor() and AddVertex() between Begin/End.
            /// </summary>
            /// <param name="mode">The primitive type to draw (Triangles, Quads, Lines, etc.).</param>
            public void BeginDraw(PrimitiveType mode)
            {
                if (!_initialized) return;
                OpenGL32.glBegin((int)mode);
            }

            /// <summary>
            /// Ends the current primitive drawing operation.
            /// Must be paired with a previous BeginDraw() call.
            /// </summary>
            public void EndDraw()
            {
                if (!_initialized) return;
                OpenGL32.glEnd();
            }

            /// <summary>
            /// Sets the current drawing color for subsequent vertices.
            /// </summary>
            /// <param name="r">Red component (0.0 to 1.0).</param>
            /// <param name="g">Green component (0.0 to 1.0).</param>
            /// <param name="b">Blue component (0.0 to 1.0).</param>
            public void SetColor(float r, float g, float b)
            {
                if (!_initialized) return;
                OpenGL32.glColor3f(r, g, b);
            }

            /// <summary>
            /// Adds a vertex at the specified 3D position.
            /// Must be called between BeginDraw() and EndDraw().
            /// </summary>
            /// <param name="x">X coordinate in world space.</param>
            /// <param name="y">Y coordinate in world space.</param>
            /// <param name="z">Z coordinate in world space.</param>
            public void AddVertex(float x, float y, float z)
            {
                if (!_initialized) return;
                OpenGL32.glVertex3f(x, y, z);
            }

            /// <summary>
            /// Releases all OpenGL resources including the rendering context.
            /// </summary>
            public void Dispose()
            {
                if (_hglrc != IntPtr.Zero)
                {
                    OpenGL32.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
                    OpenGL32.wglDeleteContext(_hglrc);
                    _hglrc = IntPtr.Zero;
                }

                if (_hdc != IntPtr.Zero)
                {
                    Angene.Main.Win32.ReleaseDC(_hwnd, _hdc);
                    _hdc = IntPtr.Zero;
                }

                _initialized = false;
            }
        }

        /// <summary>
        /// Primitive types for custom 3D shape drawing.
        /// </summary>
        public enum PrimitiveType
        {
            /// <summary>Individual points.</summary>
            Points = 0x0000,
            /// <summary>Connected line segments.</summary>
            Lines = 0x0001,
            /// <summary>Closed line loop.</summary>
            LineLoop = 0x0002,
            /// <summary>Series of connected lines.</summary>
            LineStrip = 0x0003,
            /// <summary>Individual triangles (3 vertices each).</summary>
            Triangles = 0x0004,
            /// <summary>Connected strip of triangles.</summary>
            TriangleStrip = 0x0005,
            /// <summary>Fan of triangles from first vertex.</summary>
            TriangleFan = 0x0006,
            /// <summary>Individual quads (4 vertices each).</summary>
            Quads = 0x0007,
            /// <summary>Connected strip of quads.</summary>
            QuadStrip = 0x0008,
            /// <summary>Convex polygon.</summary>
            Polygon = 0x0009
        }
    }
