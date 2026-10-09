using System.Runtime.InteropServices;
using static Angene.Extensions.Audio.Windows.WinMM;

namespace Angene.Extensions.Audio.Windows
{
    internal sealed class WaveHeader : IDisposable
    {
        public WinMM.WAVEHDR Header;
        public IntPtr DataPtr { get; }
        public bool IsDone { get; set; }

        private readonly GCHandle _handle;

        public WaveHeader(int size)
        {
            var data = new byte[size];
            _handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            DataPtr = _handle.AddrOfPinnedObject();

            Header = new WinMM.WAVEHDR
            {
                lpData = DataPtr,
                dwBufferLength = (uint)size,
                dwFlags = 0
            };
        }

        public void Dispose()
        {
            if (_handle.IsAllocated)
            {
                _handle.Free();
                Header.lpData = IntPtr.Zero;
            }
        }
    }
}