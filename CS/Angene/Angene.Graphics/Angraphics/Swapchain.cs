using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angene.Graphics.Angraphics
{
    public enum PixelFormat { Bgra32 }

    public class Swapchain
    {
        public int Width { get; }
        public int Height { get; }
        public PixelFormat Format { get; }
        public int BufferCount { get; }

        private readonly FrameBuffer[] _buffers;
        private int _backIndex;   // index being drawn into
        private int _frontIndex;  // index currently displayed

        public FrameBuffer BackBuffer => _buffers[_backIndex];
        public FrameBuffer FrontBuffer => _buffers[_frontIndex];

        public Swapchain(int width, int height,
                         PixelFormat format = PixelFormat.Bgra32,
                         int bufferCount = 2)
        {
            Width = width;
            Height = height;
            Format = format;
            BufferCount = bufferCount;

            _buffers = new FrameBuffer[bufferCount];
            for (int i = 0; i < bufferCount; i++)
                _buffers[i] = new FrameBuffer(width, height);

            _backIndex = 0;
            _frontIndex = bufferCount - 1;
        }

        /// <summary>Advance to the next buffer pair.</summary>
        public void Swap()
        {
            _frontIndex = _backIndex;
            _backIndex = (_backIndex + 1) % BufferCount;
        }
    }
}
