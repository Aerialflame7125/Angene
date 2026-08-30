using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Angene.Audio.MiniAudio.Interop;
using Angene.Common;
using static Angene.Audio.MiniAudio.Interop.Methods;
using System.Collections.Concurrent;
using static Angene.Audio.Common.AudioDefs;

namespace Angene.Audio.MiniAudio;

public enum MiniAudioPlayerType
{
    Memory,
    File,
    Stream
}

public unsafe class MiniAudioPlayer : IAudioPlayer
{
    private MiniAudioPlayerType _type;
    private string _filePath;
    private byte[] _bytes;
    private Stream _stream;
    private bool _disposed = false;
    private float _playPosition = 0;
    
#region IAudioPlayer
    private volatile bool _isPlaying;
    private volatile bool _isPaused;
    private volatile float _volume = 1f;
    private volatile bool _loop = false;

    public bool IsPlaying => _isPlaying;
    public bool IsPaused => _isPaused;
    public float Volume => _volume;
    public bool Looping => _loop;
    
    public void Play() => Enqueue(AudioCommandType.Play);
    public void Stop() => Enqueue(AudioCommandType.Stop);
    public void Pause() => Enqueue(AudioCommandType.Pause);
    public void Resume() => Enqueue(AudioCommandType.Resume);
    public void SetVolume(float v) => Enqueue(AudioCommandType.Volume, System.Math.Clamp(v, 0f, 1f));
    public void SetLooping(bool loop) => Enqueue(AudioCommandType.Loop, loop ? 1f : 0f);
#endregion
#region Threading
    private readonly ConcurrentQueue<AudioCommand> _commands = new();
    private readonly ManualResetEventSlim _signal = new(false);
    private readonly CancellationTokenSource _cts = new();
    private readonly Thread _audioThread;
#endregion
#region MiniAudio stuff
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
    private ma_sound* _sound = null;
    private ma_decoder* _decoder;
    private ma_context* _context;
    private ma_log* _log;
    private ma_resource_manager_config resourceManagerConfig;
    private ma_resource_manager resourceManager;
    private ma_device_info* pPlaybackDeviceInfo;
    private uint playbackDeviceCount;
    private ma_engine* engine;
#endregion
#region Constructors
    public MiniAudioPlayer() { }

    private MiniAudioPlayer(MiniAudioPlayerType type, string filePath = "", byte[] bytes = null, Stream stream = null)
    {
        _type = type;
        _filePath = filePath;
        _bytes = bytes;
        _stream = stream;
        _audioThread = new Thread(AudioLoop)
        {
            IsBackground = true,
            Priority = ThreadPriority.AboveNormal,
            Name = "Angene.Audio"
        };
        _audioThread.Start();
    }
    
    private void AudioLoop()
    {
        try
        {
            switch (_type)
            {
                case MiniAudioPlayerType.File:
                    if (_filePath != "")
                        InitFile(_filePath);
                    break;
                case  MiniAudioPlayerType.Memory:
                    if (_bytes != null)
                        InitMemory(_bytes);
                    break;
                case MiniAudioPlayerType.Stream:
                    if (_stream != null)
                    {
                        using var ms = new MemoryStream();
                        _stream.CopyTo(ms);
                        InitMemory(ms.ToArray());
                    }
                    break;
            }
            while (!_cts.IsCancellationRequested)
            {
                while (_commands.TryDequeue(out var cmd))
                    ProcessCommand(cmd);

                if (_sound != null)
                {
                    float secs;
                    ma_sound* sound = _sound;
                    ma_sound_get_cursor_in_seconds(sound, &secs);
                    _playPosition = secs;
                }
                
                _signal.Wait(16);
                _signal.Reset();
            }
        }
        catch (Exception ex)
        {
            Logger.LogCritical(
                $"Angene.Audio thread crashed: {ex.Message}",
                LoggingTarget.Engine, ex);
            _isPlaying = false;
            _isPaused = false;
        }
    }
#endregion
#region Inits

    public static MiniAudioPlayer InitAudioPlayer(string filePath = "", Stream stream = null, byte[] bytes = null)
    {
        return new MiniAudioPlayer()
    }
    public bool InitMemory(byte[] bytes)
    {
        ma_result result;
        
        ma_resource_manager_config _resourceManagerConfig = ma_resource_manager_config_init();
        _resourceManagerConfig.decodedFormat     = ma_format.ma_format_f32;
        _resourceManagerConfig.decodedChannels   = 0;
        _resourceManagerConfig.decodedSampleRate = 48000;
        ma_resource_manager _resourceManager;
        
        result = ma_resource_manager_init(&_resourceManagerConfig, &_resourceManager);
        if (result != ma_result.MA_SUCCESS) {
            Logger.LogError("[MiniAudio | ma_resource_manager_init] Failed to initialize resource manager.", LoggingTarget.Engine);
            return false;
        }
        
        result = ma_context_init(null, 0, null, _context);
        if (result != ma_result.MA_SUCCESS) {
            Logger.LogError("[MiniAudio | ma_context_init] Failed to initialize context.", LoggingTarget.Engine);
            return false;
        }
        
        ma_device_info* _pPlaybackDeviceInfo;
        uint _playbackDeviceCount;
        result = ma_context_get_devices(_context, &_pPlaybackDeviceInfo, &_playbackDeviceCount, null, null);
        if (result != ma_result.MA_SUCCESS) {
            Logger.LogError("[MiniAudio | ma_context_get_devices] Failed to enumerate playback devices.", LoggingTarget.Engine);
            ma_context_uninit(_context);
            return false;
        }

        playbackDeviceCount = _playbackDeviceCount;
        pPlaybackDeviceInfo = _pPlaybackDeviceInfo;
        
        // miniaudio log
        _log = (ma_log*)NativeMemory.AllocZeroed(144);
        if (ma_log_init(null, _log) != ma_result.MA_SUCCESS)
            Logger.LogError("Failed to init MiniAudio log", LoggingTarget.Engine);

        // values grabbed from miniaudio.h (0.11.25)
        _device = (ma_device*)NativeMemory.AllocZeroed(3776);
        _decoder = (ma_decoder*)NativeMemory.AllocZeroed(552);

        fixed (byte* pBytes = bytes)
        {
            if (ma_decoder_init_memory(pBytes, (nuint)bytes.Length, null, _decoder) != ma_result.MA_SUCCESS)
            {
                Logger.LogError("[MiniAudio | InitMemory] Could not load audio file from memory", LoggingTarget.Engine);
                goto CleanupAndFail;
            }

            var deviceConfig = ma_device_config_init(ma_device_type.ma_device_type_playback);
            deviceConfig.playback.format = resourceManager.config.decodedFormat;
            deviceConfig.playback.channels = resourceManager.config.decodedChannels;
            deviceConfig.sampleRate = resourceManager.config.decodedSampleRate;
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
            
            ma_engine_config engineConfig = ma_engine_config_init();
            engineConfig.pDevice = _device;
            engineConfig.pResourceManager = &_resourceManager;
            engineConfig.noAutoStart = 1;

            ma_engine* _engine = engine;
            result = ma_engine_init(&engineConfig, _engine);
            if (result != ma_result.MA_SUCCESS) {
                Logger.LogError($"[MiniAudio | ma_engine_init] Failed to initialize engine for {pPlaybackDeviceInfo->name}", LoggingTarget.Engine);
                ma_device_uninit(_device);
                return false;
            }

            return true;
        }

    CleanupAndFail:
        if (_decoder != null)
        {
            ma_decoder_uninit(_decoder);
            NativeMemory.Free(_decoder);
            _decoder = null;
        }

        if (engine != null)
        {
            ma_engine_uninit(engine);
            NativeMemory.Free(engine);
            engine = null;
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
        
    public bool InitFile(string path)
    {
        sbyte* filepath = Main.Window.ToSBytePtr(path);

        ma_result result;
        
        ma_resource_manager_config _resourceManagerConfig = ma_resource_manager_config_init();
        _resourceManagerConfig.decodedFormat     = ma_format.ma_format_f32;
        _resourceManagerConfig.decodedChannels   = 0;
        _resourceManagerConfig.decodedSampleRate = 48000;
        ma_resource_manager _resourceManager;
        
        result = ma_resource_manager_init(&_resourceManagerConfig, &_resourceManager);
        if (result != ma_result.MA_SUCCESS) {
            Logger.LogError("[MiniAudio | ma_resource_manager_init] Failed to initialize resource manager.", LoggingTarget.Engine);
            return false;
        }
        
        result = ma_context_init(null, 0, null, _context);
        if (result != ma_result.MA_SUCCESS) {
            Logger.LogError("[MiniAudio | ma_context_init] Failed to initialize context.", LoggingTarget.Engine);
            return false;
        }
        
        ma_device_info* _pPlaybackDeviceInfo;
        uint _playbackDeviceCount;
        result = ma_context_get_devices(_context, &_pPlaybackDeviceInfo, &_playbackDeviceCount, null, null);
        if (result != ma_result.MA_SUCCESS) {
            Logger.LogError("[MiniAudio | ma_context_get_devices] Failed to enumerate playback devices.", LoggingTarget.Engine);
            ma_context_uninit(_context);
            return false;
        }

        playbackDeviceCount = _playbackDeviceCount;
        pPlaybackDeviceInfo = _pPlaybackDeviceInfo;
        
        // miniaudio log
        _log = (ma_log*)NativeMemory.AllocZeroed(144);
        if (ma_log_init(null, _log) != ma_result.MA_SUCCESS)
            Logger.LogError("Failed to init MiniAudio log", LoggingTarget.Engine);

        // values grabbed from miniaudio.h (0.11.25)
        _device = (ma_device*)NativeMemory.AllocZeroed(3776);
        _decoder = (ma_decoder*)NativeMemory.AllocZeroed(552);
        
        if (ma_decoder_init_file(filepath, null, _decoder) != ma_result.MA_SUCCESS)
        {
            Logger.LogError("[MiniAudio | InitMemory] Could not load audio file from memory", LoggingTarget.Engine);
            goto CleanupAndFail;
        }

        var deviceConfig = ma_device_config_init(ma_device_type.ma_device_type_playback);
        deviceConfig.playback.format = resourceManager.config.decodedFormat;
        deviceConfig.playback.channels = resourceManager.config.decodedChannels;
        deviceConfig.sampleRate = resourceManager.config.decodedSampleRate;
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
        
        ma_engine_config engineConfig = ma_engine_config_init();
        engineConfig.pDevice = _device;
        engineConfig.pResourceManager = &_resourceManager;
        engineConfig.noAutoStart = 1;

        ma_engine* _engine = engine;
        result = ma_engine_init(&engineConfig, _engine);
        if (result != ma_result.MA_SUCCESS) {
            Logger.LogError($"[MiniAudio | ma_engine_init] Failed to initialize engine for {pPlaybackDeviceInfo->name}", LoggingTarget.Engine);
            ma_device_uninit(_device);
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

        if (engine != null)
        {
            ma_engine_uninit(engine);
            NativeMemory.Free(engine);
            engine = null;
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
#endregion
#region Methods
    private void Enqueue(AudioCommandType type, float value = 0f)
    {
        if (_disposed) return;
        _commands.Enqueue(new AudioCommand(type, value));
        _signal.Set();
    }

    private bool ProcessCommand(AudioCommand cmd)
    {
        switch (cmd.Type)
        {
            case AudioCommandType.Play:
                _playPosition = 0;
                if (ma_sound_start(_sound) != ma_result.MA_SUCCESS && ma_device_start(_device) != ma_result.MA_SUCCESS)
                    goto CleanupAndFail;

                _isPlaying = true;
                _isPaused = false;
                break;

            case AudioCommandType.Stop:
                _playPosition = 0;
                if (ma_sound_stop(_sound) != ma_result.MA_SUCCESS || ma_device_stop(_device) != ma_result.MA_SUCCESS)
                    goto CleanupAndFail;
                    
                _isPlaying = false;
                _isPaused = false;
                break;

            case AudioCommandType.Pause:
                if (ma_sound_stop(_sound) != ma_result.MA_SUCCESS)
                    goto CleanupAndFail;

                _isPlaying = false;
                _isPaused = true;
                break;

            case AudioCommandType.Resume:
                if (ma_sound_start(_sound) != ma_result.MA_SUCCESS && ma_sound_seek_to_second(_sound, _playPosition) != ma_result.MA_SUCCESS)
                    goto CleanupAndFail;
                _isPaused = false;
                break;

            case AudioCommandType.Volume:
                _volume = cmd.Value;
                if (ma_device_set_master_volume(_device, _volume) != ma_result.MA_SUCCESS)
                    goto CleanupAndFail;
                break;

            case AudioCommandType.Loop:
                _loop = cmd.Value > 0f;
                break;

            case AudioCommandType.Dispose:
                _cts.Cancel();
                break;
        }

        return true;
        
    CleanupAndFail:
        Logger.LogError("Failed to handle playback device.", LoggingTarget.Engine);
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
    
    public void StopPlayer()
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

    public void Dispose()
    {
        if (_decoder != null)
        {
            ma_decoder_uninit(_decoder);
            NativeMemory.Free(_decoder);
            _decoder = null;
        }

        if (engine != null)
        {
            ma_engine_uninit(engine);
            NativeMemory.Free(engine);
            engine = null;
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
    }
#endregion
}