using System;
using System.Runtime.InteropServices;

namespace Angene.Graphics.OpenGL
    {
        /// <summary>
        /// OpenGL function imports from opengl32.dll and glu32.dll.
        /// Contains all the low-level OpenGL API calls needed for 3D rendering.
        /// </summary>
        internal static class OpenGL32
        {
            private const string OpenGL = "opengl32.dll";
            private const string Gdi = "gdi32.dll";
            private const string Glu = "glu32.dll";

            // Context management
            [DllImport(OpenGL)]
            internal static extern IntPtr wglCreateContext(IntPtr hdc);

            [DllImport(OpenGL)]
            internal static extern bool wglMakeCurrent(IntPtr hdc, IntPtr hglrc);

            [DllImport(OpenGL)]
            internal static extern bool wglDeleteContext(IntPtr hglrc);

            // Pixel format
            [DllImport(Gdi)]
            internal static extern int ChoosePixelFormat(IntPtr hdc, ref PixelFormatDescriptor pfd);

            [DllImport(Gdi)]
            internal static extern bool SetPixelFormat(IntPtr hdc, int format, ref PixelFormatDescriptor pfd);

            [DllImport(Gdi)]
            internal static extern bool SwapBuffers(IntPtr hdc);

            // Matrix operations
            [DllImport(OpenGL)]
            internal static extern void glMatrixMode(int mode);

            [DllImport(OpenGL)]
            internal static extern void glLoadIdentity();

            [DllImport(OpenGL)]
            internal static extern void glPushMatrix();

            [DllImport(OpenGL)]
            internal static extern void glPopMatrix();

            [DllImport(OpenGL)]
            internal static extern void glTranslatef(float x, float y, float z);

            [DllImport(OpenGL)]
            internal static extern void glRotatef(float angle, float x, float y, float z);

            [DllImport(OpenGL)]
            internal static extern void glScalef(float x, float y, float z);

            // Drawing operations
            [DllImport(OpenGL)]
            internal static extern void glBegin(int mode);

            [DllImport(OpenGL)]
            internal static extern void glEnd();

            [DllImport(OpenGL)]
            internal static extern void glVertex3f(float x, float y, float z);

            [DllImport(OpenGL)]
            internal static extern void glColor3f(float r, float g, float b);

            [DllImport(OpenGL)]
            internal static extern void glColor4f(float r, float g, float b, float a);

            [DllImport(OpenGL)]
            internal static extern void glNormal3f(float x, float y, float z);

            [DllImport(OpenGL)]
            internal static extern void glTexCoord2f(float s, float t);

            // Clearing and viewport
            [DllImport(OpenGL)]
            internal static extern void glClear(int mask);

            [DllImport(OpenGL)]
            internal static extern void glClearColor(float r, float g, float b, float a);

            [DllImport(OpenGL)]
            internal static extern void glViewport(int x, int y, int width, int height);

            // State management
            [DllImport(OpenGL)]
            internal static extern void glEnable(int cap);

            [DllImport(OpenGL)]
            internal static extern void glDisable(int cap);

            [DllImport(OpenGL)]
            internal static extern void glDepthFunc(int func);

            [DllImport(OpenGL)]
            internal static extern void glBlendFunc(int sfactor, int dfactor);

            [DllImport(OpenGL)]
            internal static extern void glCullFace(int mode);

            [DllImport(OpenGL)]
            internal static extern void glShadeModel(int mode);

            // Lighting
            [DllImport(OpenGL)]
            internal static extern void glLightfv(int light, int pname, float[] parameters);

            [DllImport(OpenGL)]
            internal static extern void glMaterialfv(int face, int pname, float[] parameters);

            // GLU functions for perspective
            [DllImport(Glu)]
            internal static extern void gluPerspective(double fovy, double aspect, double zNear, double zFar);

            [DllImport(Glu)]
            internal static extern void gluLookAt(
                double eyeX, double eyeY, double eyeZ,
                double centerX, double centerY, double centerZ,
                double upX, double upY, double upZ);
        }

        /// <summary>
        /// OpenGL constants for various operations.
        /// </summary>
        internal static class GL
        {
            // Matrix modes
            internal const int MODELVIEW = 0x1700;
            internal const int PROJECTION = 0x1701;
            internal const int TEXTURE = 0x1702;

            // Clear buffer bits
            internal const int COLOR_BUFFER_BIT = 0x00004000;
            internal const int DEPTH_BUFFER_BIT = 0x00000100;
            internal const int STENCIL_BUFFER_BIT = 0x00000400;

            // Depth functions
            internal const int NEVER = 0x0200;
            internal const int LESS = 0x0201;
            internal const int EQUAL = 0x0202;
            internal const int LEQUAL = 0x0203;
            internal const int GREATER = 0x0204;
            internal const int NOTEQUAL = 0x0205;
            internal const int GEQUAL = 0x0206;
            internal const int ALWAYS = 0x0207;

            // Capabilities
            internal const int DEPTH_TEST = 0x0B71;
            internal const int LIGHTING = 0x0B50;
            internal const int LIGHT0 = 0x4000;
            internal const int LIGHT1 = 0x4001;
            internal const int CULL_FACE = 0x0B44;
            internal const int BLEND = 0x0BE2;
            internal const int TEXTURE_2D = 0x0DE1;

            // Primitive types
            internal const int POINTS = 0x0000;
            internal const int LINES = 0x0001;
            internal const int LINE_LOOP = 0x0002;
            internal const int LINE_STRIP = 0x0003;
            internal const int TRIANGLES = 0x0004;
            internal const int TRIANGLE_STRIP = 0x0005;
            internal const int TRIANGLE_FAN = 0x0006;
            internal const int QUADS = 0x0007;
            internal const int QUAD_STRIP = 0x0008;
            internal const int POLYGON = 0x0009;

            // Blending factors
            internal const int ZERO = 0;
            internal const int ONE = 1;
            internal const int SRC_ALPHA = 0x0302;
            internal const int ONE_MINUS_SRC_ALPHA = 0x0303;

            // Culling modes
            internal const int FRONT = 0x0404;
            internal const int BACK = 0x0405;
            internal const int FRONT_AND_BACK = 0x0408;

            // Shading models
            internal const int FLAT = 0x1D00;
            internal const int SMOOTH = 0x1D01;
        }

        /// <summary>
        /// Pixel format descriptor flags for OpenGL context creation.
        /// </summary>
        internal static class PFD
        {
            internal const uint DRAW_TO_WINDOW = 0x00000004;
            internal const uint SUPPORT_OPENGL = 0x00000020;
            internal const uint DOUBLEBUFFER = 0x00000001;
            internal const byte TYPE_RGBA = 0;
            internal const byte MAIN_PLANE = 0;
        }

        /// <summary>
        /// Pixel format descriptor structure for OpenGL initialization.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct PixelFormatDescriptor
        {
            internal ushort nSize;
            internal ushort nVersion;
            internal uint dwFlags;
            internal byte iPixelType;
            internal byte cColorBits;
            internal byte cRedBits;
            internal byte cRedShift;
            internal byte cGreenBits;
            internal byte cGreenShift;
            internal byte cBlueBits;
            internal byte cBlueShift;
            internal byte cAlphaBits;
            internal byte cAlphaShift;
            internal byte cAccumBits;
            internal byte cAccumRedBits;
            internal byte cAccumGreenBits;
            internal byte cAccumBlueBits;
            internal byte cAccumAlphaBits;
            internal byte cDepthBits;
            internal byte cStencilBits;
            internal byte cAuxBuffers;
            internal byte iLayerType;
            internal byte bReserved;
            internal uint dwLayerMask;
            internal uint dwVisibleMask;
            internal uint dwDamageMask;
        }
    }

