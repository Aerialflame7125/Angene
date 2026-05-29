using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
