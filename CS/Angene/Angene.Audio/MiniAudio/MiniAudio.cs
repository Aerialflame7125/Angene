using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Angene.Audio.MiniAudio.Interop;
using Angene.Common;
using static Angene.Audio.MiniAudio.Interop.Methods;

namespace Angene.Audio.MiniAudio;

public unsafe class MiniAudio
{
    public static MiniAudio Instance = new MiniAudio();
    // Heap-allocated so it survives after Play() returns.

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void data_callback(ma_device* pDevice, void* pOutput, void* pInput, uint frameCount)
    {
        ma_decoder* pDecoder = (ma_decoder*)pDevice->pUserData;
        if (pDecoder == null)
            return;

        ma_decoder_read_pcm_frames(pDecoder, pOutput, frameCount, null);
    }

    private ma_device* _device;
    private ma_decoder* _decoder;

    public bool Play(string path)
    {
        _decoder = (ma_decoder*)NativeMemory.Alloc((nuint)sizeof(ma_decoder));
        _device  = (ma_device*)NativeMemory.Alloc((nuint)sizeof(ma_device));

        sbyte* filepath = Main.Window.ToSBytePtr(path);
        if (ma_decoder_init_file(filepath, null, _decoder) != ma_result.MA_SUCCESS)
        {
            Logger.LogError("Could not load file", LoggingTarget.Engine);
            NativeMemory.Free(_decoder); NativeMemory.Free(_device);
            _decoder = null; _device = null;
            return false;
        }

        var deviceConfig = ma_device_config_init(ma_device_type.ma_device_type_playback);
        deviceConfig.playback.format   = _decoder->outputFormat;
        deviceConfig.playback.channels = _decoder->outputChannels;
        deviceConfig.sampleRate        = _decoder->outputSampleRate;
        deviceConfig.dataCallback      = &data_callback;
        deviceConfig.pUserData         = _decoder;

        if (ma_device_init(null, &deviceConfig, _device) != ma_result.MA_SUCCESS)
        {
            Logger.LogError("Failed to open playback device.", LoggingTarget.Engine);
            ma_decoder_uninit(_decoder);
            NativeMemory.Free(_decoder); NativeMemory.Free(_device);
            _decoder = null; _device = null;
            return false;
        }

        if (ma_device_start(_device) != ma_result.MA_SUCCESS)
        {
            Logger.LogError("Failed to start playback device.", LoggingTarget.Engine);
            ma_device_uninit(_device);
            ma_decoder_uninit(_decoder);
            NativeMemory.Free(_device); NativeMemory.Free(_decoder);
            _device = null; _decoder = null;
            return false;
        }

        return true;
    }

    public void Stop()
    {
        if (_device == null) return;

        ma_device_uninit(_device);
        ma_decoder_uninit(_decoder);
        NativeMemory.Free(_device);
        NativeMemory.Free(_decoder);
        _device = null;
        _decoder = null;
    }
}