using System.Runtime.InteropServices;

namespace Angene.Audio.Windows
{
    internal static class WinMM
    {
        public const uint WAVE_MAPPER = unchecked((uint)-1);
        public const uint CALLBACK_NULL = 0x00000000;
        public const uint WHDR_DONE = 0x00000001;

        [DllImport("winmm.dll")]
        public static extern int waveOutOpen(
            out IntPtr hWaveOut,
            uint deviceId,
            ref WaveFormatEx pwfx,
            IntPtr dwCallback,
            IntPtr dwInstance,
            uint fdwOpen);

        [DllImport("winmm.dll")]
        public static extern int waveOutWrite(
            IntPtr hWaveOut,
            ref WAVEHDR pwh,
            int cbwh);

        [DllImport("winmm.dll")]
        public static extern int waveOutPrepareHeader(
            IntPtr hWaveOut,
            ref WAVEHDR pwh,
            int cbwh);

        [DllImport("winmm.dll")]
        public static extern int waveOutUnprepareHeader(
            IntPtr hWaveOut,
            ref WAVEHDR pwh,
            int cbwh);

        [DllImport("winmm.dll")]
        public static extern int waveOutReset(IntPtr hWaveOut);

        [DllImport("winmm.dll")]
        public static extern int waveOutClose(IntPtr hWaveOut);

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hWaveOut, uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutPause(IntPtr hWaveOut);

        [DllImport("winmm.dll")]
        public static extern int waveOutRestart(IntPtr hWaveOut);

        [StructLayout(LayoutKind.Sequential)]
        public struct WAVEHDR
        {
            public IntPtr lpData;
            public uint dwBufferLength;
            public uint dwBytesRecorded;
            public IntPtr dwUser;
            public uint dwFlags;
            public uint dwLoops;
            public IntPtr lpNext;
            public IntPtr reserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WaveFormatEx
        {
            public ushort wFormatTag;       
            public ushort nChannels;        
            public uint nSamplesPerSec;   
            public uint nAvgBytesPerSec;  
            public ushort nBlockAlign;      
            public ushort wBitsPerSample;   
            public ushort cbSize;           
        }
    }
}