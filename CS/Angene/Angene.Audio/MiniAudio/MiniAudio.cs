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

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static void OnLogCallback(void* arg1, uint arg2, sbyte* str)
    {
        string log = new string(str);

        Logger.LogDebug($"[MiniAudio|OnLogCallback] '{log}', level = {arg2}", LoggingTarget.Engine);
    }

    private ma_device* _device;
    private ma_decoder* _decoder;

    private ma_context* _context;

    private ma_log* _log;

    public bool Play(string path)
    {
        sbyte* filepath = Main.Window.ToSBytePtr(path);

        // miniaudio log
        _log = (ma_log*)NativeMemory.AllocZeroed(144);
        if (ma_log_init(null, _log) != ma_result.MA_SUCCESS)
            Logger.LogError("Failed to init MiniAudio log", LoggingTarget.Engine);

        // values grabbed from miniaudio.h (0.11.25)
        _device = (ma_device*)NativeMemory.AllocZeroed(3776);
        _decoder = (ma_decoder*)NativeMemory.AllocZeroed(552);

        if (ma_decoder_init_file(filepath, null, _decoder) != ma_result.MA_SUCCESS)
        {
            Logger.LogError("Could not load file", LoggingTarget.Engine);
            goto CleanupAndFail;
        }

        ma_format format;
        uint channels, sampleRate;
        if (ma_decoder_get_data_format(_decoder, &format, &channels, &sampleRate, null, 0) != ma_result.MA_SUCCESS)
        {
            Logger.LogError("Failed to get decoder format", LoggingTarget.Engine);
            goto CleanupAndFail;
        }

        var deviceConfig = ma_device_config_init(ma_device_type.ma_device_type_playback);
        deviceConfig.playback.format = format;
        deviceConfig.playback.channels = channels;
        deviceConfig.sampleRate = sampleRate;
        deviceConfig.dataCallback = &data_callback;
        deviceConfig.pUserData = _decoder;

        bool contextOk = false;
    #if LINUX
        ma_backend[] backends = { ma_backend.ma_backend_alsa, ma_backend.ma_backend_pulseaudio, ma_backend.ma_backend_jack };
    #elif WINDOWS
        ma_backend[] backends = { ma_backend.ma_backend_wasapi, ma_backend.ma_backend_winmm };
    #endif

        foreach (var backend in backends)
        {
            if (_context != null)
            {
                ma_context_uninit(_context);
                NativeMemory.Free(_context);
                _context = null;
            }

            _context = (ma_context*)NativeMemory.AllocZeroed(ma_context_sizeof());

            ma_context_config cfg = ma_context_config_init();
            cfg.pLog = _log;

            if (ma_context_init(&backend, 1, &cfg, _context) == ma_result.MA_SUCCESS)
            {
                contextOk = true;
                break;
            }

            ma_context_uninit(_context);
            NativeMemory.Free(_context);
            _context = null;
            Logger.LogWarning($"Failed {backend}, trying next...", LoggingTarget.Engine);
        }

        if (!contextOk)
        {
            Logger.LogError("All audio backends failed.", LoggingTarget.Engine);
            goto CleanupAndFail;
        }

        if (ma_device_init(_context, &deviceConfig, _device) != ma_result.MA_SUCCESS)
        {
            Logger.LogError("Failed to open playback device.", LoggingTarget.Engine);
            goto CleanupAndFail;
        }

        if (ma_device_start(_device) != ma_result.MA_SUCCESS)
        {
            Logger.LogError("Failed to start playback device.", LoggingTarget.Engine);
            // Device was initialized, so uninit it
            ma_device_uninit(_device);
            ma_decoder_uninit(_decoder);
            NativeMemory.Free(_device); NativeMemory.Free(_decoder);
            _device = null; _decoder = null;
            ma_context_uninit(_context);
            NativeMemory.Free(_context);
            _context = null;
            // Free log
            ma_log_uninit(_log);
            NativeMemory.Free(_log);
            _log = null;
            return false;
        }

        return true;

    CleanupAndFail:
        if (_decoder != null)
        {
            ma_decoder_uninit(_decoder);
            NativeMemory.Free(_decoder);
            _decoder = null;
        }
        if (_device != null)
        {
            // if device, free
            NativeMemory.Free(_device);
            _device = null;
        }
        if (_context != null)
        {
            ma_context_uninit(_context);
            NativeMemory.Free(_context);
            _context = null;
        }
        if (_log != null)
        {
            ma_log_uninit(_log);
            NativeMemory.Free(_log);
            _log = null;
        }
        return false;
    }

    public void Stop()
    {
        if (_device != null)
        {
            ma_device_uninit(_device);
            NativeMemory.Free(_device);
            _device = null;
        }
        if (_decoder != null)
        {
            ma_decoder_uninit(_decoder);
            NativeMemory.Free(_decoder);
            _decoder = null;
        }
        if (_context != null)
        {
            ma_context_uninit(_context);
            NativeMemory.Free(_context);
            _context = null;
        }
    }
}