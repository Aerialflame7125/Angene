using Angene.Common;
using System;
using System.Runtime.InteropServices;

namespace Angene.Graphics
{
    public class Defs
    {
        public struct Color { float r, g, b, a; }

        public struct Edge // rasteration and edge helpers
        {
            public int Y0, Y1;
            public float XAtY0;
            public float Slope;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Vertex
        {
            public float X, Y, Z;       // POSITION (3 floats = 12 bytes)
            public float R, G, B, A;    // COLOR    (4 floats = 16 bytes)
        }

    }
}
