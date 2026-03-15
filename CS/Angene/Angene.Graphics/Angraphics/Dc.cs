using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angene.Graphics.Angraphics
{
    public class Dc : IDisposable
    {
        public Swapchain Swapchain { get; private set; }
        private readonly bool _useGpu;

        public Dc(int width, int height, bool useGpu = false, int bufferCount = 2)
        {
            if (useGpu)
                throw new NotSupportedException("GPU path not yet implemented.");

            _useGpu = false;
            Swapchain = new Swapchain(width, height, PixelFormat.Bgra32, bufferCount);
        }

        public FrameBuffer GetBackBuffer() => Swapchain.BackBuffer;
        public void SwapBuffers() => Swapchain.Swap();

        public void Dispose() { /* future: release GPU resources */ }
    }
}
