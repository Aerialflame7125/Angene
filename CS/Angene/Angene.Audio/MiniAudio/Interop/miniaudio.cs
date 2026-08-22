using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static Angene.Audio.MiniAudio.Interop.ma_format;

namespace Angene.Audio.MiniAudio.Interop
{
    public enum ma_log_level : uint
    {
        MA_LOG_LEVEL_DEBUG = 4,
        MA_LOG_LEVEL_INFO = 3,
        MA_LOG_LEVEL_WARNING = 2,
        MA_LOG_LEVEL_ERROR = 1,
    }

    public enum _ma_channel_position : uint
    {
        MA_CHANNEL_NONE = 0,
        MA_CHANNEL_MONO = 1,
        MA_CHANNEL_FRONT_LEFT = 2,
        MA_CHANNEL_FRONT_RIGHT = 3,
        MA_CHANNEL_FRONT_CENTER = 4,
        MA_CHANNEL_LFE = 5,
        MA_CHANNEL_BACK_LEFT = 6,
        MA_CHANNEL_BACK_RIGHT = 7,
        MA_CHANNEL_FRONT_LEFT_CENTER = 8,
        MA_CHANNEL_FRONT_RIGHT_CENTER = 9,
        MA_CHANNEL_BACK_CENTER = 10,
        MA_CHANNEL_SIDE_LEFT = 11,
        MA_CHANNEL_SIDE_RIGHT = 12,
        MA_CHANNEL_TOP_CENTER = 13,
        MA_CHANNEL_TOP_FRONT_LEFT = 14,
        MA_CHANNEL_TOP_FRONT_CENTER = 15,
        MA_CHANNEL_TOP_FRONT_RIGHT = 16,
        MA_CHANNEL_TOP_BACK_LEFT = 17,
        MA_CHANNEL_TOP_BACK_CENTER = 18,
        MA_CHANNEL_TOP_BACK_RIGHT = 19,
        MA_CHANNEL_AUX_0 = 20,
        MA_CHANNEL_AUX_1 = 21,
        MA_CHANNEL_AUX_2 = 22,
        MA_CHANNEL_AUX_3 = 23,
        MA_CHANNEL_AUX_4 = 24,
        MA_CHANNEL_AUX_5 = 25,
        MA_CHANNEL_AUX_6 = 26,
        MA_CHANNEL_AUX_7 = 27,
        MA_CHANNEL_AUX_8 = 28,
        MA_CHANNEL_AUX_9 = 29,
        MA_CHANNEL_AUX_10 = 30,
        MA_CHANNEL_AUX_11 = 31,
        MA_CHANNEL_AUX_12 = 32,
        MA_CHANNEL_AUX_13 = 33,
        MA_CHANNEL_AUX_14 = 34,
        MA_CHANNEL_AUX_15 = 35,
        MA_CHANNEL_AUX_16 = 36,
        MA_CHANNEL_AUX_17 = 37,
        MA_CHANNEL_AUX_18 = 38,
        MA_CHANNEL_AUX_19 = 39,
        MA_CHANNEL_AUX_20 = 40,
        MA_CHANNEL_AUX_21 = 41,
        MA_CHANNEL_AUX_22 = 42,
        MA_CHANNEL_AUX_23 = 43,
        MA_CHANNEL_AUX_24 = 44,
        MA_CHANNEL_AUX_25 = 45,
        MA_CHANNEL_AUX_26 = 46,
        MA_CHANNEL_AUX_27 = 47,
        MA_CHANNEL_AUX_28 = 48,
        MA_CHANNEL_AUX_29 = 49,
        MA_CHANNEL_AUX_30 = 50,
        MA_CHANNEL_AUX_31 = 51,
        MA_CHANNEL_POSITION_COUNT,
        MA_CHANNEL_LEFT = MA_CHANNEL_FRONT_LEFT,
        MA_CHANNEL_RIGHT = MA_CHANNEL_FRONT_RIGHT,
    }

    public enum ma_result
    {
        MA_SUCCESS = 0,
        MA_ERROR = -1,
        MA_INVALID_ARGS = -2,
        MA_INVALID_OPERATION = -3,
        MA_OUT_OF_MEMORY = -4,
        MA_OUT_OF_RANGE = -5,
        MA_ACCESS_DENIED = -6,
        MA_DOES_NOT_EXIST = -7,
        MA_ALREADY_EXISTS = -8,
        MA_TOO_MANY_OPEN_FILES = -9,
        MA_INVALID_FILE = -10,
        MA_TOO_BIG = -11,
        MA_PATH_TOO_LONG = -12,
        MA_NAME_TOO_LONG = -13,
        MA_NOT_DIRECTORY = -14,
        MA_IS_DIRECTORY = -15,
        MA_DIRECTORY_NOT_EMPTY = -16,
        MA_AT_END = -17,
        MA_NO_SPACE = -18,
        MA_BUSY = -19,
        MA_IO_ERROR = -20,
        MA_INTERRUPT = -21,
        MA_UNAVAILABLE = -22,
        MA_ALREADY_IN_USE = -23,
        MA_BAD_ADDRESS = -24,
        MA_BAD_SEEK = -25,
        MA_BAD_PIPE = -26,
        MA_DEADLOCK = -27,
        MA_TOO_MANY_LINKS = -28,
        MA_NOT_IMPLEMENTED = -29,
        MA_NO_MESSAGE = -30,
        MA_BAD_MESSAGE = -31,
        MA_NO_DATA_AVAILABLE = -32,
        MA_INVALID_DATA = -33,
        MA_TIMEOUT = -34,
        MA_NO_NETWORK = -35,
        MA_NOT_UNIQUE = -36,
        MA_NOT_SOCKET = -37,
        MA_NO_ADDRESS = -38,
        MA_BAD_PROTOCOL = -39,
        MA_PROTOCOL_UNAVAILABLE = -40,
        MA_PROTOCOL_NOT_SUPPORTED = -41,
        MA_PROTOCOL_FAMILY_NOT_SUPPORTED = -42,
        MA_ADDRESS_FAMILY_NOT_SUPPORTED = -43,
        MA_SOCKET_NOT_SUPPORTED = -44,
        MA_CONNECTION_RESET = -45,
        MA_ALREADY_CONNECTED = -46,
        MA_NOT_CONNECTED = -47,
        MA_CONNECTION_REFUSED = -48,
        MA_NO_HOST = -49,
        MA_IN_PROGRESS = -50,
        MA_CANCELLED = -51,
        MA_MEMORY_ALREADY_MAPPED = -52,
        MA_CRC_MISMATCH = -100,
        MA_FORMAT_NOT_SUPPORTED = -200,
        MA_DEVICE_TYPE_NOT_SUPPORTED = -201,
        MA_SHARE_MODE_NOT_SUPPORTED = -202,
        MA_NO_BACKEND = -203,
        MA_NO_DEVICE = -204,
        MA_API_NOT_FOUND = -205,
        MA_INVALID_DEVICE_CONFIG = -206,
        MA_LOOP = -207,
        MA_BACKEND_NOT_ENABLED = -208,
        MA_DEVICE_NOT_INITIALIZED = -300,
        MA_DEVICE_ALREADY_INITIALIZED = -301,
        MA_DEVICE_NOT_STARTED = -302,
        MA_DEVICE_NOT_STOPPED = -303,
        MA_FAILED_TO_INIT_BACKEND = -400,
        MA_FAILED_TO_OPEN_BACKEND_DEVICE = -401,
        MA_FAILED_TO_START_BACKEND_DEVICE = -402,
        MA_FAILED_TO_STOP_BACKEND_DEVICE = -403,
    }

    public enum ma_stream_format : uint
    {
        ma_stream_format_pcm = 0,
    }

    public enum ma_stream_layout : uint
    {
        ma_stream_layout_interleaved = 0,
        ma_stream_layout_deinterleaved,
    }

    public enum ma_dither_mode : uint
    {
        ma_dither_mode_none = 0,
        ma_dither_mode_rectangle,
        ma_dither_mode_triangle,
    }

    public enum ma_format : uint
    {
        ma_format_unknown = 0,
        ma_format_u8 = 1,
        ma_format_s16 = 2,
        ma_format_s24 = 3,
        ma_format_s32 = 4,
        ma_format_f32 = 5,
        ma_format_count,
    }

    public enum ma_standard_sample_rate : uint
    {
        ma_standard_sample_rate_48000 = 48000,
        ma_standard_sample_rate_44100 = 44100,
        ma_standard_sample_rate_32000 = 32000,
        ma_standard_sample_rate_24000 = 24000,
        ma_standard_sample_rate_22050 = 22050,
        ma_standard_sample_rate_88200 = 88200,
        ma_standard_sample_rate_96000 = 96000,
        ma_standard_sample_rate_176400 = 176400,
        ma_standard_sample_rate_192000 = 192000,
        ma_standard_sample_rate_16000 = 16000,
        ma_standard_sample_rate_11025 = 11025,
        ma_standard_sample_rate_8000 = 8000,
        ma_standard_sample_rate_352800 = 352800,
        ma_standard_sample_rate_384000 = 384000,
        ma_standard_sample_rate_min = ma_standard_sample_rate_8000,
        ma_standard_sample_rate_max = ma_standard_sample_rate_384000,
        ma_standard_sample_rate_count = 14,
    }

    public enum ma_channel_mix_mode : uint
    {
        ma_channel_mix_mode_rectangular = 0,
        ma_channel_mix_mode_simple,
        ma_channel_mix_mode_custom_weights,
        ma_channel_mix_mode_default = ma_channel_mix_mode_rectangular,
    }

    public enum ma_standard_channel_map : uint
    {
        ma_standard_channel_map_microsoft,
        ma_standard_channel_map_alsa,
        ma_standard_channel_map_rfc3551,
        ma_standard_channel_map_flac,
        ma_standard_channel_map_vorbis,
        ma_standard_channel_map_sound4,
        ma_standard_channel_map_sndio,
        ma_standard_channel_map_webaudio = ma_standard_channel_map_flac,
        ma_standard_channel_map_default = ma_standard_channel_map_microsoft,
    }

    public enum ma_performance_profile : uint
    {
        ma_performance_profile_low_latency = 0,
        ma_performance_profile_conservative,
    }

    public unsafe partial struct ma_allocation_callbacks
    {
        public void* pUserData;

            public delegate* unmanaged[Cdecl]<nuint, void*, void*> onMalloc;

            public delegate* unmanaged[Cdecl]<void*, nuint, void*, void*> onRealloc;

            public delegate* unmanaged[Cdecl]<void*, void*, void> onFree;
    }

    public partial struct ma_lcg
    {
            public uint state;
    }

    public partial struct ma_atomic_uint32
    {
            public uint value;
    }

    public partial struct ma_atomic_int32
    {
            public int value;
    }

    public partial struct ma_atomic_uint64
    {
            public ulong value;
    }

    public partial struct ma_atomic_float
    {
            public float value;
    }

    public partial struct ma_atomic_bool32
    {
            public uint value;
    }

    public enum ma_thread_priority
    {
        ma_thread_priority_idle = -5,
        ma_thread_priority_lowest = -4,
        ma_thread_priority_low = -3,
        ma_thread_priority_normal = -2,
        ma_thread_priority_high = -1,
        ma_thread_priority_highest = 0,
        ma_thread_priority_realtime = 1,
        ma_thread_priority_default = 0,
    }

    public partial struct ma_event
    {
            public uint value;

            public IntPtr @lock;

            public IntPtr cond;
    }

    public partial struct ma_semaphore
    {
        public int value;

            public IntPtr @lock;

            public IntPtr cond;
    }

    public unsafe partial struct ma_log_callback
    {
            public delegate* unmanaged[Cdecl]<void*, uint, sbyte*, void> onLog;

        public void* pUserData;
    }

    public partial struct ma_log
    {
            public _callbacks_e__FixedBuffer callbacks;

            public uint callbackCount;

        public ma_allocation_callbacks allocationCallbacks;

            public IntPtr @lock;

        [InlineArray(4)]
        public partial struct _callbacks_e__FixedBuffer
        {
            public ma_log_callback e0;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct ma_biquad_coefficient
    {
        [FieldOffset(0)]
        public float f32;

        [FieldOffset(0)]
            public int s32;
    }

    public partial struct ma_biquad_config
    {
        public ma_format format;

            public uint channels;

        public double b0;

        public double b1;

        public double b2;

        public double a0;

        public double a1;

        public double a2;
    }

    public unsafe partial struct ma_biquad
    {
        public ma_format format;

            public uint channels;

        public ma_biquad_coefficient b0;

        public ma_biquad_coefficient b1;

        public ma_biquad_coefficient b2;

        public ma_biquad_coefficient a1;

        public ma_biquad_coefficient a2;

        public ma_biquad_coefficient* pR1;

        public ma_biquad_coefficient* pR2;

        public void* _pHeap;

            public uint _ownsHeap;
    }

    public partial struct ma_lpf1_config
    {
        public ma_format format;

            public uint channels;

            public uint sampleRate;

        public double cutoffFrequency;

        public double q;
    }

    public unsafe partial struct ma_lpf1
    {
        public ma_format format;

            public uint channels;

        public ma_biquad_coefficient a;

        public ma_biquad_coefficient* pR1;

        public void* _pHeap;

            public uint _ownsHeap;
    }

    public partial struct ma_lpf2
    {
        public ma_biquad bq;
    }

    public partial struct ma_lpf_config
    {
        public ma_format format;

            public uint channels;

            public uint sampleRate;

        public double cutoffFrequency;

            public uint order;
    }

    public unsafe partial struct ma_lpf
    {
        public ma_format format;

            public uint channels;

            public uint sampleRate;

            public uint lpf1Count;

            public uint lpf2Count;

        public ma_lpf1* pLPF1;

        public ma_lpf2* pLPF2;

        public void* _pHeap;

            public uint _ownsHeap;
    }

    public partial struct ma_hpf1_config
    {
        public ma_format format;

            public uint channels;

            public uint sampleRate;

        public double cutoffFrequency;

        public double q;
    }

    public unsafe partial struct ma_hpf1
    {
        public ma_format format;

            public uint channels;

        public ma_biquad_coefficient a;

        public ma_biquad_coefficient* pR1;

        public void* _pHeap;

            public uint _ownsHeap;
    }

    public partial struct ma_hpf2
    {
        public ma_biquad bq;
    }

    public partial struct ma_hpf_config
    {
        public ma_format format;

            public uint channels;

            public uint sampleRate;

        public double cutoffFrequency;

            public uint order;
    }

    public unsafe partial struct ma_hpf
    {
        public ma_format format;

            public uint channels;

            public uint sampleRate;

            public uint hpf1Count;

            public uint hpf2Count;

        public ma_hpf1* pHPF1;

        public ma_hpf2* pHPF2;

        public void* _pHeap;

            public uint _ownsHeap;
    }

    public partial struct ma_bpf2_config
    {
        public ma_format format;

            public uint channels;

            public uint sampleRate;

        public double cutoffFrequency;

        public double q;
    }

    public partial struct ma_bpf2
    {
        public ma_biquad bq;
    }

    public partial struct ma_bpf_config
    {
        public ma_format format;

            public uint channels;

            public uint sampleRate;

        public double cutoffFrequency;

            public uint order;
    }

    public unsafe partial struct ma_bpf
    {
        public ma_format format;

            public uint channels;

            public uint bpf2Count;

        public ma_bpf2* pBPF2;

        public void* _pHeap;

            public uint _ownsHeap;
    }

    public partial struct ma_notch2_config
    {
        public ma_format format;

            public uint channels;

            public uint sampleRate;

        public double q;

        public double frequency;
    }

    public partial struct ma_notch2
    {
        public ma_biquad bq;
    }

    public partial struct ma_peak2_config
    {
        public ma_format format;

            public uint channels;

            public uint sampleRate;

        public double gainDB;

        public double q;

        public double frequency;
    }

    public partial struct ma_peak2
    {
        public ma_biquad bq;
    }

    public partial struct ma_loshelf2_config
    {
        public ma_format format;

            public uint channels;

            public uint sampleRate;

        public double gainDB;

        public double shelfSlope;

        public double frequency;
    }

    public partial struct ma_loshelf2
    {
        public ma_biquad bq;
    }

    public partial struct ma_hishelf2_config
    {
        public ma_format format;

            public uint channels;

            public uint sampleRate;

        public double gainDB;

        public double shelfSlope;

        public double frequency;
    }

    public partial struct ma_hishelf2
    {
        public ma_biquad bq;
    }

    public partial struct ma_delay_config
    {
            public uint channels;

            public uint sampleRate;

            public uint delayInFrames;

            public uint delayStart;

        public float wet;

        public float dry;

        public float decay;
    }

    public unsafe partial struct ma_delay
    {
        public ma_delay_config config;

            public uint cursor;

            public uint bufferSizeInFrames;

        public float* pBuffer;
    }

    public partial struct ma_gainer_config
    {
            public uint channels;

            public uint smoothTimeInFrames;
    }

    public unsafe partial struct ma_gainer
    {
        public ma_gainer_config config;

            public uint t;

        public float masterVolume;

        public float* pOldGains;

        public float* pNewGains;

        public void* _pHeap;

            public uint _ownsHeap;
    }

    public enum ma_pan_mode : uint
    {
        ma_pan_mode_balance = 0,
        ma_pan_mode_pan,
    }

    public partial struct ma_panner_config
    {
        public ma_format format;

            public uint channels;

        public ma_pan_mode mode;

        public float pan;
    }

    public partial struct ma_panner
    {
        public ma_format format;

            public uint channels;

        public ma_pan_mode mode;

        public float pan;
    }

    public partial struct ma_fader_config
    {
        public ma_format format;

            public uint channels;

            public uint sampleRate;
    }

    public partial struct ma_fader
    {
        public ma_fader_config config;

        public float volumeBeg;

        public float volumeEnd;

            public ulong lengthInFrames;

            public long cursorInFrames;
    }

    public partial struct ma_vec3f
    {
        public float x;

        public float y;

        public float z;
    }

    public partial struct ma_atomic_vec3f
    {
        public ma_vec3f v;

            public uint @lock;
    }

    public enum ma_attenuation_model : uint
    {
        ma_attenuation_model_none,
        ma_attenuation_model_inverse,
        ma_attenuation_model_linear,
        ma_attenuation_model_exponential,
    }

    public enum ma_positioning : uint
    {
        ma_positioning_absolute,
        ma_positioning_relative,
    }

    public enum ma_handedness : uint
    {
        ma_handedness_right,
        ma_handedness_left,
    }

    public unsafe partial struct ma_spatializer_listener_config
    {
            public uint channelsOut;

            public byte* pChannelMapOut;

        public ma_handedness handedness;

        public float coneInnerAngleInRadians;

        public float coneOuterAngleInRadians;

        public float coneOuterGain;

        public float speedOfSound;

        public ma_vec3f worldUp;
    }

    public unsafe partial struct ma_spatializer_listener
    {
        public ma_spatializer_listener_config config;

        public ma_atomic_vec3f position;

        public ma_atomic_vec3f direction;

        public ma_atomic_vec3f velocity;

            public uint isEnabled;

            public uint _ownsHeap;

        public void* _pHeap;
    }

    public unsafe partial struct ma_spatializer_config
    {
            public uint channelsIn;

            public uint channelsOut;

            public byte* pChannelMapIn;

        public ma_attenuation_model attenuationModel;

        public ma_positioning positioning;

        public ma_handedness handedness;

        public float minGain;

        public float maxGain;

        public float minDistance;

        public float maxDistance;

        public float rolloff;

        public float coneInnerAngleInRadians;

        public float coneOuterAngleInRadians;

        public float coneOuterGain;

        public float dopplerFactor;

        public float directionalAttenuationFactor;

        public float minSpatializationChannelGain;

            public uint gainSmoothTimeInFrames;
    }

    public unsafe partial struct ma_spatializer
    {
            public uint channelsIn;

            public uint channelsOut;

            public byte* pChannelMapIn;

        public ma_attenuation_model attenuationModel;

        public ma_positioning positioning;

        public ma_handedness handedness;

        public float minGain;

        public float maxGain;

        public float minDistance;

        public float maxDistance;

        public float rolloff;

        public float coneInnerAngleInRadians;

        public float coneOuterAngleInRadians;

        public float coneOuterGain;

        public float dopplerFactor;

        public float directionalAttenuationFactor;

            public uint gainSmoothTimeInFrames;

        public ma_atomic_vec3f position;

        public ma_atomic_vec3f direction;

        public ma_atomic_vec3f velocity;

        public float dopplerPitch;

        public float minSpatializationChannelGain;

        public ma_gainer gainer;

        public float* pNewChannelGainsOut;

        public void* _pHeap;

            public uint _ownsHeap;
    }

    public partial struct ma_linear_resampler_config
    {
        public ma_format format;

            public uint channels;

            public uint sampleRateIn;

            public uint sampleRateOut;

            public uint lpfOrder;

        public double lpfNyquistFactor;
    }

    public unsafe partial struct ma_linear_resampler
    {
        public ma_linear_resampler_config config;

            public uint inAdvanceInt;

            public uint inAdvanceFrac;

            public uint inTimeInt;

            public uint inTimeFrac;

            public _x0_e__Union x0;

            public _x1_e__Union x1;

        public ma_lpf lpf;

        public void* _pHeap;

            public uint _ownsHeap;

        [StructLayout(LayoutKind.Explicit)]
        public unsafe partial struct _x0_e__Union
        {
            [FieldOffset(0)]
            public float* f32;

            [FieldOffset(0)]
                    public short* s16;
        }

        [StructLayout(LayoutKind.Explicit)]
        public unsafe partial struct _x1_e__Union
        {
            [FieldOffset(0)]
            public float* f32;

            [FieldOffset(0)]
                    public short* s16;
        }
    }

    public unsafe partial struct ma_resampling_backend_vtable
    {
            public delegate* unmanaged[Cdecl]<void*, ma_resampler_config*, nuint*, ma_result> onGetHeapSize;

            public delegate* unmanaged[Cdecl]<void*, ma_resampler_config*, void*, void**, ma_result> onInit;

            public delegate* unmanaged[Cdecl]<void*, void*, ma_allocation_callbacks*, void> onUninit;

            public delegate* unmanaged[Cdecl]<void*, void*, void*, ulong*, void*, ulong*, ma_result> onProcess;

            public delegate* unmanaged[Cdecl]<void*, void*, uint, uint, ma_result> onSetRate;

            public delegate* unmanaged[Cdecl]<void*, void*, ulong> onGetInputLatency;

            public delegate* unmanaged[Cdecl]<void*, void*, ulong> onGetOutputLatency;

            public delegate* unmanaged[Cdecl]<void*, void*, ulong, ulong*, ma_result> onGetRequiredInputFrameCount;

            public delegate* unmanaged[Cdecl]<void*, void*, ulong, ulong*, ma_result> onGetExpectedOutputFrameCount;

            public delegate* unmanaged[Cdecl]<void*, void*, ma_result> onReset;
    }

    public enum ma_resample_algorithm : uint
    {
        ma_resample_algorithm_linear = 0,
        ma_resample_algorithm_custom,
    }

    public unsafe partial struct ma_resampler_config
    {
        public ma_format format;

            public uint channels;

            public uint sampleRateIn;

            public uint sampleRateOut;

        public ma_resample_algorithm algorithm;

        public ma_resampling_backend_vtable* pBackendVTable;

        public void* pBackendUserData;

            public _linear_e__Struct linear;

        public partial struct _linear_e__Struct
        {
                    public uint lpfOrder;
        }
    }

    public unsafe partial struct ma_resampler
    {
            public void* pBackend;

        public ma_resampling_backend_vtable* pBackendVTable;

        public void* pBackendUserData;

        public ma_format format;

            public uint channels;

            public uint sampleRateIn;

            public uint sampleRateOut;

            public _state_e__Union state;

        public void* _pHeap;

            public uint _ownsHeap;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _state_e__Union
        {
            [FieldOffset(0)]
            public ma_linear_resampler linear;
        }
    }

    public enum ma_channel_conversion_path : uint
    {
        ma_channel_conversion_path_unknown,
        ma_channel_conversion_path_passthrough,
        ma_channel_conversion_path_mono_out,
        ma_channel_conversion_path_mono_in,
        ma_channel_conversion_path_shuffle,
        ma_channel_conversion_path_weights,
    }

    public enum ma_mono_expansion_mode : uint
    {
        ma_mono_expansion_mode_duplicate = 0,
        ma_mono_expansion_mode_average,
        ma_mono_expansion_mode_stereo_only,
        ma_mono_expansion_mode_default = ma_mono_expansion_mode_duplicate,
    }

    public unsafe partial struct ma_channel_converter_config
    {
        public ma_format format;

            public uint channelsIn;

            public uint channelsOut;

            public byte* pChannelMapIn;

            public byte* pChannelMapOut;

        public ma_channel_mix_mode mixingMode;

            public uint calculateLFEFromSpatialChannels;

        public float** ppWeights;
    }

    public unsafe partial struct ma_channel_converter
    {
        public ma_format format;

            public uint channelsIn;

            public uint channelsOut;

        public ma_channel_mix_mode mixingMode;

        public ma_channel_conversion_path conversionPath;

            public byte* pChannelMapIn;

            public byte* pChannelMapOut;

            public byte* pShuffleTable;

            public _weights_e__Union weights;

        public void* _pHeap;

            public uint _ownsHeap;

        [StructLayout(LayoutKind.Explicit)]
        public unsafe partial struct _weights_e__Union
        {
            [FieldOffset(0)]
            public float** f32;

            [FieldOffset(0)]
                    public int** s16;
        }
    }

    public unsafe partial struct ma_data_converter_config
    {
        public ma_format formatIn;

        public ma_format formatOut;

            public uint channelsIn;

            public uint channelsOut;

            public uint sampleRateIn;

            public uint sampleRateOut;

            public byte* pChannelMapIn;

            public byte* pChannelMapOut;

        public ma_dither_mode ditherMode;

        public ma_channel_mix_mode channelMixMode;

            public uint calculateLFEFromSpatialChannels;

        public float** ppChannelWeights;

            public uint allowDynamicSampleRate;

        public ma_resampler_config resampling;
    }

    public enum ma_data_converter_execution_path : uint
    {
        ma_data_converter_execution_path_passthrough,
        ma_data_converter_execution_path_format_only,
        ma_data_converter_execution_path_channels_only,
        ma_data_converter_execution_path_resample_only,
        ma_data_converter_execution_path_resample_first,
        ma_data_converter_execution_path_channels_first,
    }

    public unsafe partial struct ma_data_converter
    {
        public ma_format formatIn;

        public ma_format formatOut;

            public uint channelsIn;

            public uint channelsOut;

            public uint sampleRateIn;

            public uint sampleRateOut;

        public ma_dither_mode ditherMode;

        public ma_data_converter_execution_path executionPath;

        public ma_channel_converter channelConverter;

        public ma_resampler resampler;

            public byte hasPreFormatConversion;

            public byte hasPostFormatConversion;

            public byte hasChannelConverter;

            public byte hasResampler;

            public byte isPassthrough;

            public byte _ownsHeap;

        public void* _pHeap;
    }

    public unsafe partial struct ma_data_source_vtable
    {
            public delegate* unmanaged[Cdecl]<void*, void*, ulong, ulong*, ma_result> onRead;

            public delegate* unmanaged[Cdecl]<void*, ulong, ma_result> onSeek;

            public delegate* unmanaged[Cdecl]<void*, ma_format*, uint*, uint*, byte*, nuint, ma_result> onGetDataFormat;

            public delegate* unmanaged[Cdecl]<void*, ulong*, ma_result> onGetCursor;

            public delegate* unmanaged[Cdecl]<void*, ulong*, ma_result> onGetLength;

            public delegate* unmanaged[Cdecl]<void*, uint, ma_result> onSetLooping;

            public uint flags;
    }

    public unsafe partial struct ma_data_source_config
    {
            public ma_data_source_vtable* vtable;
    }

    public unsafe partial struct ma_data_source_base
    {
            public ma_data_source_vtable* vtable;

            public ulong rangeBegInFrames;

            public ulong rangeEndInFrames;

            public ulong loopBegInFrames;

            public ulong loopEndInFrames;

            public void* pCurrent;

            public void* pNext;

            public delegate* unmanaged[Cdecl]<void*, void*> onGetNext;

            public uint isLooping;
    }

    public unsafe partial struct ma_audio_buffer_ref
    {
        public ma_data_source_base ds;

        public ma_format format;

            public uint channels;

            public uint sampleRate;

            public ulong cursor;

            public ulong sizeInFrames;

            public void* pData;
    }

    public unsafe partial struct ma_audio_buffer_config
    {
        public ma_format format;

            public uint channels;

            public uint sampleRate;

            public ulong sizeInFrames;

            public void* pData;

        public ma_allocation_callbacks allocationCallbacks;
    }

    public partial struct ma_audio_buffer
    {
        public ma_audio_buffer_ref @ref;

        public ma_allocation_callbacks allocationCallbacks;

            public uint ownsData;

            public __pExtraData_e__FixedBuffer _pExtraData;

        public partial struct __pExtraData_e__FixedBuffer
        {
            public byte e0;

            [UnscopedRef]
            public ref byte this[int index]
            {
                get
                {
                    return ref Unsafe.Add(ref e0, index);
                }
            }

            [UnscopedRef]
            public Span<byte> AsSpan(int length) => MemoryMarshal.CreateSpan(ref e0, length);
        }
    }

    public unsafe partial struct ma_paged_audio_buffer_page
    {
        public ma_paged_audio_buffer_page* pNext;

            public ulong sizeInFrames;

            public _pAudioData_e__FixedBuffer pAudioData;

        public partial struct _pAudioData_e__FixedBuffer
        {
            public byte e0;

            [UnscopedRef]
            public ref byte this[int index]
            {
                get
                {
                    return ref Unsafe.Add(ref e0, index);
                }
            }

            [UnscopedRef]
            public Span<byte> AsSpan(int length) => MemoryMarshal.CreateSpan(ref e0, length);
        }
    }

    public unsafe partial struct ma_paged_audio_buffer_data
    {
        public ma_format format;

            public uint channels;

        public ma_paged_audio_buffer_page head;

        public ma_paged_audio_buffer_page* pTail;
    }

    public unsafe partial struct ma_paged_audio_buffer_config
    {
        public ma_paged_audio_buffer_data* pData;
    }

    public unsafe partial struct ma_paged_audio_buffer
    {
        public ma_data_source_base ds;

        public ma_paged_audio_buffer_data* pData;

        public ma_paged_audio_buffer_page* pCurrent;

            public ulong relativeCursor;

            public ulong absoluteCursor;
    }

    public unsafe partial struct ma_rb
    {
        public void* pBuffer;

            public uint subbufferSizeInBytes;

            public uint subbufferCount;

            public uint subbufferStrideInBytes;

            public uint encodedReadOffset;

            public uint encodedWriteOffset;

            public byte ownsBuffer;

            public byte clearOnWriteAcquire;

        public ma_allocation_callbacks allocationCallbacks;
    }

    public partial struct ma_pcm_rb
    {
        public ma_data_source_base ds;

        public ma_rb rb;

        public ma_format format;

            public uint channels;

            public uint sampleRate;
    }

    public partial struct ma_duplex_rb
    {
        public ma_pcm_rb rb;
    }

    public partial struct ma_fence
    {
        public ma_event e;

            public uint counter;
    }

    public unsafe partial struct ma_async_notification_callbacks
    {
            public delegate* unmanaged[Cdecl]<void*, void> onSignal;
    }

    public partial struct ma_async_notification_poll
    {
        public ma_async_notification_callbacks cb;

            public uint signalled;
    }

    public partial struct ma_async_notification_event
    {
        public ma_async_notification_callbacks cb;

        public ma_event e;
    }

    public partial struct ma_slot_allocator_config
    {
            public uint capacity;
    }

    public partial struct ma_slot_allocator_group
    {
            public uint bitfield;
    }

    public unsafe partial struct ma_slot_allocator
    {
        public ma_slot_allocator_group* pGroups;

            public uint* pSlots;

            public uint count;

            public uint capacity;

            public uint _ownsHeap;

        public void* _pHeap;
    }

    public enum ma_job_type : uint
    {
        MA_JOB_TYPE_QUIT = 0,
        MA_JOB_TYPE_CUSTOM,
        MA_JOB_TYPE_RESOURCE_MANAGER_LOAD_DATA_BUFFER_NODE,
        MA_JOB_TYPE_RESOURCE_MANAGER_FREE_DATA_BUFFER_NODE,
        MA_JOB_TYPE_RESOURCE_MANAGER_PAGE_DATA_BUFFER_NODE,
        MA_JOB_TYPE_RESOURCE_MANAGER_LOAD_DATA_BUFFER,
        MA_JOB_TYPE_RESOURCE_MANAGER_FREE_DATA_BUFFER,
        MA_JOB_TYPE_RESOURCE_MANAGER_LOAD_DATA_STREAM,
        MA_JOB_TYPE_RESOURCE_MANAGER_FREE_DATA_STREAM,
        MA_JOB_TYPE_RESOURCE_MANAGER_PAGE_DATA_STREAM,
        MA_JOB_TYPE_RESOURCE_MANAGER_SEEK_DATA_STREAM,
        MA_JOB_TYPE_DEVICE_AAUDIO_REROUTE,
        MA_JOB_TYPE_COUNT,
    }

    public partial struct ma_job
    {
            public _toc_e__Union toc;

            public ulong next;

            public uint order;

            public _data_e__Union data;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _toc_e__Union
        {
            [FieldOffset(0)]
                    public _breakup_e__Struct breakup;

            [FieldOffset(0)]
                    public ulong allocation;

            public partial struct _breakup_e__Struct
            {
                            public ushort code;

                            public ushort slot;

                            public uint refcount;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _data_e__Union
        {
            [FieldOffset(0)]
                    public _custom_e__Struct custom;

            [FieldOffset(0)]
                    public _resourceManager_e__Union resourceManager;

            [FieldOffset(0)]
                    public _device_e__Union device;

            public unsafe partial struct _custom_e__Struct
            {
                            public delegate* unmanaged[Cdecl]<ma_job*, ma_result> proc;

                            public ulong data0;

                            public ulong data1;
            }

            [StructLayout(LayoutKind.Explicit)]
            public partial struct _resourceManager_e__Union
            {
                [FieldOffset(0)]
                            public _loadDataBufferNode_e__Struct loadDataBufferNode;

                [FieldOffset(0)]
                            public _freeDataBufferNode_e__Struct freeDataBufferNode;

                [FieldOffset(0)]
                            public _pageDataBufferNode_e__Struct pageDataBufferNode;

                [FieldOffset(0)]
                            public _loadDataBuffer_e__Struct loadDataBuffer;

                [FieldOffset(0)]
                            public _freeDataBuffer_e__Struct freeDataBuffer;

                [FieldOffset(0)]
                            public _loadDataStream_e__Struct loadDataStream;

                [FieldOffset(0)]
                            public _freeDataStream_e__Struct freeDataStream;

                [FieldOffset(0)]
                            public _pageDataStream_e__Struct pageDataStream;

                [FieldOffset(0)]
                            public _seekDataStream_e__Struct seekDataStream;

                public unsafe partial struct _loadDataBufferNode_e__Struct
                {
                    public void* pResourceManager;

                    public void* pDataBufferNode;

                                    public sbyte* pFilePath;

                                    public uint* pFilePathW;

                                    public uint flags;

                                    public void* pInitNotification;

                                    public void* pDoneNotification;

                    public ma_fence* pInitFence;

                    public ma_fence* pDoneFence;
                }

                public unsafe partial struct _freeDataBufferNode_e__Struct
                {
                    public void* pResourceManager;

                    public void* pDataBufferNode;

                                    public void* pDoneNotification;

                    public ma_fence* pDoneFence;
                }

                public unsafe partial struct _pageDataBufferNode_e__Struct
                {
                    public void* pResourceManager;

                    public void* pDataBufferNode;

                    public void* pDecoder;

                                    public void* pDoneNotification;

                    public ma_fence* pDoneFence;
                }

                public unsafe partial struct _loadDataBuffer_e__Struct
                {
                    public void* pDataBuffer;

                                    public void* pInitNotification;

                                    public void* pDoneNotification;

                    public ma_fence* pInitFence;

                    public ma_fence* pDoneFence;

                                    public ulong rangeBegInPCMFrames;

                                    public ulong rangeEndInPCMFrames;

                                    public ulong loopPointBegInPCMFrames;

                                    public ulong loopPointEndInPCMFrames;

                                    public uint isLooping;
                }

                public unsafe partial struct _freeDataBuffer_e__Struct
                {
                    public void* pDataBuffer;

                                    public void* pDoneNotification;

                    public ma_fence* pDoneFence;
                }

                public unsafe partial struct _loadDataStream_e__Struct
                {
                    public void* pDataStream;

                                    public sbyte* pFilePath;

                                    public uint* pFilePathW;

                                    public ulong initialSeekPoint;

                                    public void* pInitNotification;

                    public ma_fence* pInitFence;
                }

                public unsafe partial struct _freeDataStream_e__Struct
                {
                    public void* pDataStream;

                                    public void* pDoneNotification;

                    public ma_fence* pDoneFence;
                }

                public unsafe partial struct _pageDataStream_e__Struct
                {
                    public void* pDataStream;

                                    public uint pageIndex;
                }

                public unsafe partial struct _seekDataStream_e__Struct
                {
                    public void* pDataStream;

                                    public ulong frameIndex;
                }
            }

            [StructLayout(LayoutKind.Explicit)]
            public partial struct _device_e__Union
            {
                [FieldOffset(0)]
                            public _aaudio_e__Union aaudio;

                [StructLayout(LayoutKind.Explicit)]
                public partial struct _aaudio_e__Union
                {
                    [FieldOffset(0)]
                                    public _reroute_e__Struct reroute;

                    public unsafe partial struct _reroute_e__Struct
                    {
                        public void* pDevice;

                                            public uint deviceType;
                    }
                }
            }
        }
    }

    public enum ma_job_queue_flags : uint
    {
        MA_JOB_QUEUE_FLAG_NON_BLOCKING = 0x00000001,
    }

    public partial struct ma_job_queue_config
    {
            public uint flags;

            public uint capacity;
    }

    public unsafe partial struct ma_job_queue
    {
            public uint flags;

            public uint capacity;

            public ulong head;

            public ulong tail;

        public ma_semaphore sem;

        public ma_slot_allocator allocator;

        public ma_job* pJobs;

            public uint @lock;

        public void* _pHeap;

            public uint _ownsHeap;
    }

    public enum ma_device_state : uint
    {
        ma_device_state_uninitialized = 0,
        ma_device_state_stopped = 1,
        ma_device_state_started = 2,
        ma_device_state_starting = 3,
        ma_device_state_stopping = 4,
    }

    public partial struct ma_atomic_device_state
    {
        public ma_device_state value;
    }

    public enum ma_backend : uint
    {
        ma_backend_wasapi,
        ma_backend_dsound,
        ma_backend_winmm,
        ma_backend_coreaudio,
        ma_backend_sndio,
        ma_backend_audio4,
        ma_backend_oss,
        ma_backend_pulseaudio,
        ma_backend_alsa,
        ma_backend_jack,
        ma_backend_aaudio,
        ma_backend_opensl,
        ma_backend_webaudio,
        ma_backend_custom,
        ma_backend_null,
    }

    public partial struct ma_device_job_thread_config
    {
            public uint noThread;

            public uint jobQueueCapacity;

            public uint jobQueueFlags;
    }

    public partial struct ma_device_job_thread
    {
            public nuint thread;

        public ma_job_queue jobQueue;

            public uint _hasThread;
    }

    public enum ma_device_notification_type : uint
    {
        ma_device_notification_type_started,
        ma_device_notification_type_stopped,
        ma_device_notification_type_rerouted,
        ma_device_notification_type_interruption_began,
        ma_device_notification_type_interruption_ended,
        ma_device_notification_type_unlocked,
    }

    public unsafe partial struct ma_device_notification
    {
        public ma_device* pDevice;

        public ma_device_notification_type type;

            public _data_e__Union data;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _data_e__Union
        {
            [FieldOffset(0)]
                    public _started_e__Struct started;

            [FieldOffset(0)]
                    public _stopped_e__Struct stopped;

            [FieldOffset(0)]
                    public _rerouted_e__Struct rerouted;

            [FieldOffset(0)]
                    public _interruption_e__Struct interruption;

            public partial struct _started_e__Struct
            {
                public int _unused;
            }

            public partial struct _stopped_e__Struct
            {
                public int _unused;
            }

            public partial struct _rerouted_e__Struct
            {
                public int _unused;
            }

            public partial struct _interruption_e__Struct
            {
                public int _unused;
            }
        }
    }

    public enum ma_device_type : uint
    {
        ma_device_type_playback = 1,
        ma_device_type_capture = 2,
        ma_device_type_duplex = ma_device_type_playback | ma_device_type_capture,
        ma_device_type_loopback = 4,
    }

    public enum ma_share_mode : uint
    {
        ma_share_mode_shared = 0,
        ma_share_mode_exclusive,
    }

    public enum ma_ios_session_category : uint
    {
        ma_ios_session_category_default = 0,
        ma_ios_session_category_none,
        ma_ios_session_category_ambient,
        ma_ios_session_category_solo_ambient,
        ma_ios_session_category_playback,
        ma_ios_session_category_record,
        ma_ios_session_category_play_and_record,
        ma_ios_session_category_multi_route,
    }

    public enum ma_ios_session_category_option : uint
    {
        ma_ios_session_category_option_mix_with_others = 0x01,
        ma_ios_session_category_option_duck_others = 0x02,
        ma_ios_session_category_option_allow_bluetooth = 0x04,
        ma_ios_session_category_option_default_to_speaker = 0x08,
        ma_ios_session_category_option_interrupt_spoken_audio_and_mix_with_others = 0x11,
        ma_ios_session_category_option_allow_bluetooth_a2dp = 0x20,
        ma_ios_session_category_option_allow_air_play = 0x40,
    }

    public enum ma_opensl_stream_type : uint
    {
        ma_opensl_stream_type_default = 0,
        ma_opensl_stream_type_voice,
        ma_opensl_stream_type_system,
        ma_opensl_stream_type_ring,
        ma_opensl_stream_type_media,
        ma_opensl_stream_type_alarm,
        ma_opensl_stream_type_notification,
    }

    public enum ma_opensl_recording_preset : uint
    {
        ma_opensl_recording_preset_default = 0,
        ma_opensl_recording_preset_generic,
        ma_opensl_recording_preset_camcorder,
        ma_opensl_recording_preset_voice_recognition,
        ma_opensl_recording_preset_voice_communication,
        ma_opensl_recording_preset_voice_unprocessed,
    }

    public enum ma_wasapi_usage : uint
    {
        ma_wasapi_usage_default = 0,
        ma_wasapi_usage_games,
        ma_wasapi_usage_pro_audio,
    }

    public enum ma_aaudio_usage : uint
    {
        ma_aaudio_usage_default = 0,
        ma_aaudio_usage_media,
        ma_aaudio_usage_voice_communication,
        ma_aaudio_usage_voice_communication_signalling,
        ma_aaudio_usage_alarm,
        ma_aaudio_usage_notification,
        ma_aaudio_usage_notification_ringtone,
        ma_aaudio_usage_notification_event,
        ma_aaudio_usage_assistance_accessibility,
        ma_aaudio_usage_assistance_navigation_guidance,
        ma_aaudio_usage_assistance_sonification,
        ma_aaudio_usage_game,
        ma_aaudio_usage_assitant,
        ma_aaudio_usage_emergency,
        ma_aaudio_usage_safety,
        ma_aaudio_usage_vehicle_status,
        ma_aaudio_usage_announcement,
    }

    public enum ma_aaudio_content_type : uint
    {
        ma_aaudio_content_type_default = 0,
        ma_aaudio_content_type_speech,
        ma_aaudio_content_type_music,
        ma_aaudio_content_type_movie,
        ma_aaudio_content_type_sonification,
    }

    public enum ma_aaudio_input_preset : uint
    {
        ma_aaudio_input_preset_default = 0,
        ma_aaudio_input_preset_generic,
        ma_aaudio_input_preset_camcorder,
        ma_aaudio_input_preset_voice_recognition,
        ma_aaudio_input_preset_voice_communication,
        ma_aaudio_input_preset_unprocessed,
        ma_aaudio_input_preset_voice_performance,
    }

    public enum ma_aaudio_allowed_capture_policy : uint
    {
        ma_aaudio_allow_capture_default = 0,
        ma_aaudio_allow_capture_by_all,
        ma_aaudio_allow_capture_by_system,
        ma_aaudio_allow_capture_by_none,
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct ma_timer
    {
        [FieldOffset(0)]
            public long counter;

        [FieldOffset(0)]
        public double counterD;
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct ma_device_id
    {
        [FieldOffset(0)]
            public _wasapi_e__FixedBuffer wasapi;

        [FieldOffset(0)]
            public _dsound_e__FixedBuffer dsound;

        [FieldOffset(0)]
            public uint winmm;

        [FieldOffset(0)]
            public _alsa_e__FixedBuffer alsa;

        [FieldOffset(0)]
            public _pulse_e__FixedBuffer pulse;

        [FieldOffset(0)]
        public int jack;

        [FieldOffset(0)]
            public _coreaudio_e__FixedBuffer coreaudio;

        [FieldOffset(0)]
            public _sndio_e__FixedBuffer sndio;

        [FieldOffset(0)]
            public _audio4_e__FixedBuffer audio4;

        [FieldOffset(0)]
            public _oss_e__FixedBuffer oss;

        [FieldOffset(0)]
            public int aaudio;

        [FieldOffset(0)]
            public uint opensl;

        [FieldOffset(0)]
            public _webaudio_e__FixedBuffer webaudio;

        [FieldOffset(0)]
            public _custom_e__Union custom;

        [FieldOffset(0)]
        public int nullbackend;

        [StructLayout(LayoutKind.Explicit)]
        public unsafe partial struct _custom_e__Union
        {
            [FieldOffset(0)]
            public int i;

            [FieldOffset(0)]
                    public _s_e__FixedBuffer s;

            [FieldOffset(0)]
            public void* p;

            [InlineArray(256)]
            public partial struct _s_e__FixedBuffer
            {
                public sbyte e0;
            }
        }

        [InlineArray(64)]
        public partial struct _wasapi_e__FixedBuffer
        {
            public ushort e0;
        }

        [InlineArray(16)]
        public partial struct _dsound_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(256)]
        public partial struct _alsa_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(256)]
        public partial struct _pulse_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(256)]
        public partial struct _coreaudio_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(256)]
        public partial struct _sndio_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(256)]
        public partial struct _audio4_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(64)]
        public partial struct _oss_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(32)]
        public partial struct _webaudio_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public partial struct ma_device_info
    {
        public ma_device_id id;

            public _name_e__FixedBuffer name;

            public uint isDefault;

            public uint nativeDataFormatCount;

            public _nativeDataFormats_e__FixedBuffer nativeDataFormats;

        public partial struct _nativeDataFormats_e__Struct
        {
            public ma_format format;

                    public uint channels;

                    public uint sampleRate;

                    public uint flags;
        }

        [InlineArray(256)]
        public partial struct _name_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(64)]
        public partial struct _nativeDataFormats_e__FixedBuffer
        {
            public _nativeDataFormats_e__Struct e0;
        }
    }

    public unsafe partial struct ma_device_config
    {
        public ma_device_type deviceType;

            public uint sampleRate;

            public uint periodSizeInFrames;

            public uint periodSizeInMilliseconds;

            public uint periods;

        public ma_performance_profile performanceProfile;

            public byte noPreSilencedOutputBuffer;

            public byte noClip;

            public byte noDisableDenormals;

            public byte noFixedSizedCallback;

            public delegate* unmanaged[Cdecl]<ma_device*, void*, void*, uint, void> dataCallback;

            public delegate* unmanaged[Cdecl]<ma_device_notification*, void> notificationCallback;

            public delegate* unmanaged[Cdecl]<ma_device*, void> stopCallback;

        public void* pUserData;

        public ma_resampler_config resampling;

            public _playback_e__Struct playback;

            public _capture_e__Struct capture;

            public _wasapi_e__Struct wasapi;

            public _alsa_e__Struct alsa;

            public _pulse_e__Struct pulse;

            public _coreaudio_e__Struct coreaudio;

            public _opensl_e__Struct opensl;

            public _aaudio_e__Struct aaudio;

        public unsafe partial struct _playback_e__Struct
        {
                    public ma_device_id* pDeviceID;

            public ma_format format;

                    public uint channels;

                    public byte* pChannelMap;

            public ma_channel_mix_mode channelMixMode;

                    public uint calculateLFEFromSpatialChannels;

            public ma_share_mode shareMode;
        }

        public unsafe partial struct _capture_e__Struct
        {
                    public ma_device_id* pDeviceID;

            public ma_format format;

                    public uint channels;

                    public byte* pChannelMap;

            public ma_channel_mix_mode channelMixMode;

                    public uint calculateLFEFromSpatialChannels;

            public ma_share_mode shareMode;
        }

        public partial struct _wasapi_e__Struct
        {
            public ma_wasapi_usage usage;

                    public byte noAutoConvertSRC;

                    public byte noDefaultQualitySRC;

                    public byte noAutoStreamRouting;

                    public byte noHardwareOffloading;

                    public uint loopbackProcessID;

                    public byte loopbackProcessExclude;
        }

        public partial struct _alsa_e__Struct
        {
                    public uint noMMap;

                    public uint noAutoFormat;

                    public uint noAutoChannels;

                    public uint noAutoResample;
        }

        public unsafe partial struct _pulse_e__Struct
        {
                    public sbyte* pStreamNamePlayback;

                    public sbyte* pStreamNameCapture;

            public int channelMap;
        }

        public partial struct _coreaudio_e__Struct
        {
                    public uint allowNominalSampleRateChange;
        }

        public partial struct _opensl_e__Struct
        {
            public ma_opensl_stream_type streamType;

            public ma_opensl_recording_preset recordingPreset;

                    public uint enableCompatibilityWorkarounds;
        }

        public partial struct _aaudio_e__Struct
        {
            public ma_aaudio_usage usage;

            public ma_aaudio_content_type contentType;

            public ma_aaudio_input_preset inputPreset;

            public ma_aaudio_allowed_capture_policy allowedCapturePolicy;

                    public uint noAutoStartAfterReroute;

                    public uint enableCompatibilityWorkarounds;

                    public uint allowSetBufferCapacity;
        }
    }

    public unsafe partial struct ma_device_descriptor
    {
            public ma_device_id* pDeviceID;

        public ma_share_mode shareMode;

        public ma_format format;

            public uint channels;

            public uint sampleRate;

            public _channelMap_e__FixedBuffer channelMap;

            public uint periodSizeInFrames;

            public uint periodSizeInMilliseconds;

            public uint periodCount;

        [InlineArray(254)]
        public partial struct _channelMap_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public unsafe partial struct ma_backend_callbacks
    {
            public delegate* unmanaged[Cdecl]<ma_context*, ma_context_config*, ma_backend_callbacks*, ma_result> onContextInit;

            public delegate* unmanaged[Cdecl]<ma_context*, ma_result> onContextUninit;

            public delegate* unmanaged[Cdecl]<ma_context*, delegate* unmanaged[Cdecl]<ma_context*, ma_device_type, ma_device_info*, void*, uint>, void*, ma_result> onContextEnumerateDevices;

            public delegate* unmanaged[Cdecl]<ma_context*, ma_device_type, ma_device_id*, ma_device_info*, ma_result> onContextGetDeviceInfo;

            public delegate* unmanaged[Cdecl]<ma_device*, ma_device_config*, ma_device_descriptor*, ma_device_descriptor*, ma_result> onDeviceInit;

            public delegate* unmanaged[Cdecl]<ma_device*, ma_result> onDeviceUninit;

            public delegate* unmanaged[Cdecl]<ma_device*, ma_result> onDeviceStart;

            public delegate* unmanaged[Cdecl]<ma_device*, ma_result> onDeviceStop;

            public delegate* unmanaged[Cdecl]<ma_device*, void*, uint, uint*, ma_result> onDeviceRead;

            public delegate* unmanaged[Cdecl]<ma_device*, void*, uint, uint*, ma_result> onDeviceWrite;

            public delegate* unmanaged[Cdecl]<ma_device*, ma_result> onDeviceDataLoop;

            public delegate* unmanaged[Cdecl]<ma_device*, ma_result> onDeviceDataLoopWakeup;

            public delegate* unmanaged[Cdecl]<ma_device*, ma_device_type, ma_device_info*, ma_result> onDeviceGetInfo;
    }

    public unsafe partial struct ma_context_config
    {
        public ma_log* pLog;

        public ma_thread_priority threadPriority;

            public nuint threadStackSize;

        public void* pUserData;

        public ma_allocation_callbacks allocationCallbacks;

            public _dsound_e__Struct dsound;

            public _alsa_e__Struct alsa;

            public _pulse_e__Struct pulse;

            public _coreaudio_e__Struct coreaudio;

            public _jack_e__Struct jack;

        public ma_backend_callbacks custom;

        public unsafe partial struct _dsound_e__Struct
        {
                    public void* hWnd;
        }

        public partial struct _alsa_e__Struct
        {
                    public uint useVerboseDeviceEnumeration;
        }

        public unsafe partial struct _pulse_e__Struct
        {
                    public sbyte* pApplicationName;

                    public sbyte* pServerName;

                    public uint tryAutoSpawn;
        }

        public partial struct _coreaudio_e__Struct
        {
            public ma_ios_session_category sessionCategory;

                    public uint sessionCategoryOptions;

                    public uint noAudioSessionActivate;

                    public uint noAudioSessionDeactivate;
        }

        public unsafe partial struct _jack_e__Struct
        {
                    public sbyte* pClientName;

                    public uint tryStartServer;
        }
    }

    public unsafe partial struct ma_context_command__wasapi
    {
        public int code;

        public ma_event* pEvent;

            public _data_e__Union data;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _data_e__Union
        {
            [FieldOffset(0)]
                    public _quit_e__Struct quit;

            [FieldOffset(0)]
                    public _createAudioClient_e__Struct createAudioClient;

            [FieldOffset(0)]
                    public _releaseAudioClient_e__Struct releaseAudioClient;

            public partial struct _quit_e__Struct
            {
                public int _unused;
            }

            public unsafe partial struct _createAudioClient_e__Struct
            {
                public ma_device_type deviceType;

                public void* pAudioClient;

                public void** ppAudioClientService;

                public ma_result* pResult;
            }

            public unsafe partial struct _releaseAudioClient_e__Struct
            {
                public ma_device* pDevice;

                public ma_device_type deviceType;
            }
        }
    }

    public unsafe partial struct ma_context
    {
        public ma_backend_callbacks callbacks;

        public ma_backend backend;

        public ma_log* pLog;

        public ma_log log;

        public ma_thread_priority threadPriority;

            public nuint threadStackSize;

        public void* pUserData;

        public ma_allocation_callbacks allocationCallbacks;

            public IntPtr deviceEnumLock;

            public IntPtr deviceInfoLock;

            public uint deviceInfoCapacity;

            public uint playbackDeviceInfoCount;

            public uint captureDeviceInfoCount;

        public ma_device_info* pDeviceInfos;

            public _Anonymous1_e__Union Anonymous1;

            public _Anonymous2_e__Union Anonymous2;

        [UnscopedRef]
        public ref _Anonymous1_e__Union._alsa_e__Struct alsa
        {
            get
            {
                return ref Anonymous1.alsa;
            }
        }

        [UnscopedRef]
        public ref _Anonymous1_e__Union._pulse_e__Struct pulse
        {
            get
            {
                return ref Anonymous1.pulse;
            }
        }

        [UnscopedRef]
        public ref _Anonymous1_e__Union._jack_e__Struct jack
        {
            get
            {
                return ref Anonymous1.jack;
            }
        }

        [UnscopedRef]
        public ref _Anonymous1_e__Union._null_backend_e__Struct null_backend
        {
            get
            {
                return ref Anonymous1.null_backend;
            }
        }

        [UnscopedRef]
        public ref _Anonymous2_e__Union._posix_e__Struct posix
        {
            get
            {
                return ref Anonymous2.posix;
            }
        }

        [UnscopedRef]
        public ref int _unused
        {
            get
            {
                return ref Anonymous2._unused;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _Anonymous1_e__Union
        {
            [FieldOffset(0)]
                    public _alsa_e__Struct alsa;

            [FieldOffset(0)]
                    public _pulse_e__Struct pulse;

            [FieldOffset(0)]
                    public _jack_e__Struct jack;

            [FieldOffset(0)]
                    public _null_backend_e__Struct null_backend;

            public unsafe partial struct _alsa_e__Struct
            {
                            public void* asoundSO;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_open;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_close;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_sizeof;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_any;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_set_format;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_set_format_first;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_get_format_mask;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_set_channels;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_set_channels_near;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_set_channels_minmax;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_set_rate_resample;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_set_rate;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_set_rate_near;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_set_rate_minmax;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_set_buffer_size_near;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_set_periods_near;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_set_access;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_get_format;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_get_channels;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_get_channels_min;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_get_channels_max;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_get_rate;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_get_rate_min;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_get_rate_max;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_get_buffer_size;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_get_periods;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_get_access;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_test_format;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_test_channels;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params_test_rate;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_hw_params;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_sw_params_sizeof;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_sw_params_current;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_sw_params_get_boundary;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_sw_params_set_avail_min;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_sw_params_set_start_threshold;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_sw_params_set_stop_threshold;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_sw_params;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_format_mask_sizeof;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_format_mask_test;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_get_chmap;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_state;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_prepare;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_start;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_drop;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_drain;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_reset;

                            public delegate* unmanaged[Cdecl]<void> snd_device_name_hint;

                            public delegate* unmanaged[Cdecl]<void> snd_device_name_get_hint;

                            public delegate* unmanaged[Cdecl]<void> snd_card_get_index;

                            public delegate* unmanaged[Cdecl]<void> snd_device_name_free_hint;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_mmap_begin;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_mmap_commit;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_recover;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_readi;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_writei;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_avail;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_avail_update;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_wait;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_nonblock;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_info;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_info_sizeof;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_info_get_name;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_poll_descriptors;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_poll_descriptors_count;

                            public delegate* unmanaged[Cdecl]<void> snd_pcm_poll_descriptors_revents;

                            public delegate* unmanaged[Cdecl]<void> snd_config_update_free_global;

                            public IntPtr internalDeviceEnumLock;

                            public uint useVerboseDeviceEnumeration;
            }

            public unsafe partial struct _pulse_e__Struct
            {
                            public void* pulseSO;

                            public delegate* unmanaged[Cdecl]<void> pa_mainloop_new;

                            public delegate* unmanaged[Cdecl]<void> pa_mainloop_free;

                            public delegate* unmanaged[Cdecl]<void> pa_mainloop_quit;

                            public delegate* unmanaged[Cdecl]<void> pa_mainloop_get_api;

                            public delegate* unmanaged[Cdecl]<void> pa_mainloop_iterate;

                            public delegate* unmanaged[Cdecl]<void> pa_mainloop_wakeup;

                            public delegate* unmanaged[Cdecl]<void> pa_threaded_mainloop_new;

                            public delegate* unmanaged[Cdecl]<void> pa_threaded_mainloop_free;

                            public delegate* unmanaged[Cdecl]<void> pa_threaded_mainloop_start;

                            public delegate* unmanaged[Cdecl]<void> pa_threaded_mainloop_stop;

                            public delegate* unmanaged[Cdecl]<void> pa_threaded_mainloop_lock;

                            public delegate* unmanaged[Cdecl]<void> pa_threaded_mainloop_unlock;

                            public delegate* unmanaged[Cdecl]<void> pa_threaded_mainloop_wait;

                            public delegate* unmanaged[Cdecl]<void> pa_threaded_mainloop_signal;

                            public delegate* unmanaged[Cdecl]<void> pa_threaded_mainloop_accept;

                            public delegate* unmanaged[Cdecl]<void> pa_threaded_mainloop_get_retval;

                            public delegate* unmanaged[Cdecl]<void> pa_threaded_mainloop_get_api;

                            public delegate* unmanaged[Cdecl]<void> pa_threaded_mainloop_in_thread;

                            public delegate* unmanaged[Cdecl]<void> pa_threaded_mainloop_set_name;

                            public delegate* unmanaged[Cdecl]<void> pa_context_new;

                            public delegate* unmanaged[Cdecl]<void> pa_context_unref;

                            public delegate* unmanaged[Cdecl]<void> pa_context_connect;

                            public delegate* unmanaged[Cdecl]<void> pa_context_disconnect;

                            public delegate* unmanaged[Cdecl]<void> pa_context_set_state_callback;

                            public delegate* unmanaged[Cdecl]<void> pa_context_get_state;

                            public delegate* unmanaged[Cdecl]<void> pa_context_get_sink_info_list;

                            public delegate* unmanaged[Cdecl]<void> pa_context_get_source_info_list;

                            public delegate* unmanaged[Cdecl]<void> pa_context_get_sink_info_by_name;

                            public delegate* unmanaged[Cdecl]<void> pa_context_get_source_info_by_name;

                            public delegate* unmanaged[Cdecl]<void> pa_operation_unref;

                            public delegate* unmanaged[Cdecl]<void> pa_operation_get_state;

                            public delegate* unmanaged[Cdecl]<void> pa_channel_map_init_extend;

                            public delegate* unmanaged[Cdecl]<void> pa_channel_map_valid;

                            public delegate* unmanaged[Cdecl]<void> pa_channel_map_compatible;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_new;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_unref;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_connect_playback;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_connect_record;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_disconnect;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_get_state;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_get_sample_spec;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_get_channel_map;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_get_buffer_attr;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_set_buffer_attr;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_get_device_name;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_set_write_callback;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_set_read_callback;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_set_suspended_callback;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_set_moved_callback;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_is_suspended;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_flush;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_drain;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_is_corked;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_cork;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_trigger;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_begin_write;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_write;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_peek;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_drop;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_writable_size;

                            public delegate* unmanaged[Cdecl]<void> pa_stream_readable_size;

                            public void* pMainLoop;

                            public void* pPulseContext;

                            public sbyte* pApplicationName;

                            public sbyte* pServerName;
            }

            public unsafe partial struct _jack_e__Struct
            {
                            public void* jackSO;

                            public delegate* unmanaged[Cdecl]<void> jack_client_open;

                            public delegate* unmanaged[Cdecl]<void> jack_client_close;

                            public delegate* unmanaged[Cdecl]<void> jack_client_name_size;

                            public delegate* unmanaged[Cdecl]<void> jack_set_process_callback;

                            public delegate* unmanaged[Cdecl]<void> jack_set_buffer_size_callback;

                            public delegate* unmanaged[Cdecl]<void> jack_on_shutdown;

                            public delegate* unmanaged[Cdecl]<void> jack_get_sample_rate;

                            public delegate* unmanaged[Cdecl]<void> jack_get_buffer_size;

                            public delegate* unmanaged[Cdecl]<void> jack_get_ports;

                            public delegate* unmanaged[Cdecl]<void> jack_activate;

                            public delegate* unmanaged[Cdecl]<void> jack_deactivate;

                            public delegate* unmanaged[Cdecl]<void> jack_connect;

                            public delegate* unmanaged[Cdecl]<void> jack_port_register;

                            public delegate* unmanaged[Cdecl]<void> jack_port_name;

                            public delegate* unmanaged[Cdecl]<void> jack_port_get_buffer;

                            public delegate* unmanaged[Cdecl]<void> jack_free;

                            public sbyte* pClientName;

                            public uint tryStartServer;
            }

            public partial struct _null_backend_e__Struct
            {
                public int _unused;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _Anonymous2_e__Union
        {
            [FieldOffset(0)]
                    public _posix_e__Struct posix;

            [FieldOffset(0)]
            public int _unused;

            public partial struct _posix_e__Struct
            {
                public int _unused;
            }
        }
    }

    public unsafe partial struct ma_device
    {
        public ma_context* pContext;

        public ma_device_type type;

            public uint sampleRate;

        public ma_atomic_device_state state;

            public delegate* unmanaged[Cdecl]<ma_device*, void*, void*, uint, void> onData;

            public delegate* unmanaged[Cdecl]<ma_device_notification*, void> onNotification;

            public delegate* unmanaged[Cdecl]<ma_device*, void> onStop;

        public void* pUserData;

            public IntPtr startStopLock;

        public ma_event wakeupEvent;

        public ma_event startEvent;

        public ma_event stopEvent;

            public nuint thread;

        public ma_result workResult;

            public byte isOwnerOfContext;

            public byte noPreSilencedOutputBuffer;

            public byte noClip;

            public byte noDisableDenormals;

            public byte noFixedSizedCallback;

        public ma_atomic_float masterVolumeFactor;

        public ma_duplex_rb duplexRB;

            public _resampling_e__Struct resampling;

            public _playback_e__Struct playback;

            public _capture_e__Struct capture;

            public _Anonymous_e__Union Anonymous;

        [UnscopedRef]
        public ref _Anonymous_e__Union._alsa_e__Struct alsa
        {
            get
            {
                return ref Anonymous.alsa;
            }
        }

        [UnscopedRef]
        public ref _Anonymous_e__Union._pulse_e__Struct pulse
        {
            get
            {
                return ref Anonymous.pulse;
            }
        }

        [UnscopedRef]
        public ref _Anonymous_e__Union._jack_e__Struct jack
        {
            get
            {
                return ref Anonymous.jack;
            }
        }

        [UnscopedRef]
        public ref _Anonymous_e__Union._null_device_e__Struct null_device
        {
            get
            {
                return ref Anonymous.null_device;
            }
        }

        public unsafe partial struct _resampling_e__Struct
        {
            public ma_resample_algorithm algorithm;

            public ma_resampling_backend_vtable* pBackendVTable;

            public void* pBackendUserData;

                    public _linear_e__Struct linear;

            public partial struct _linear_e__Struct
            {
                            public uint lpfOrder;
            }
        }

        public unsafe partial struct _playback_e__Struct
        {
            public ma_device_id* pID;

            public ma_device_id id;

                    public _name_e__FixedBuffer name;

            public ma_share_mode shareMode;

            public ma_format format;

                    public uint channels;

                    public _channelMap_e__FixedBuffer channelMap;

            public ma_format internalFormat;

                    public uint internalChannels;

                    public uint internalSampleRate;

                    public _internalChannelMap_e__FixedBuffer internalChannelMap;

                    public uint internalPeriodSizeInFrames;

                    public uint internalPeriods;

            public ma_channel_mix_mode channelMixMode;

                    public uint calculateLFEFromSpatialChannels;

            public ma_data_converter converter;

            public void* pIntermediaryBuffer;

                    public uint intermediaryBufferCap;

                    public uint intermediaryBufferLen;

            public void* pInputCache;

                    public ulong inputCacheCap;

                    public ulong inputCacheConsumed;

                    public ulong inputCacheRemaining;

            [InlineArray(256)]
            public partial struct _name_e__FixedBuffer
            {
                public sbyte e0;
            }

            [InlineArray(254)]
            public partial struct _channelMap_e__FixedBuffer
            {
                public byte e0;
            }

            [InlineArray(254)]
            public partial struct _internalChannelMap_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct _capture_e__Struct
        {
            public ma_device_id* pID;

            public ma_device_id id;

                    public _name_e__FixedBuffer name;

            public ma_share_mode shareMode;

            public ma_format format;

                    public uint channels;

                    public _channelMap_e__FixedBuffer channelMap;

            public ma_format internalFormat;

                    public uint internalChannels;

                    public uint internalSampleRate;

                    public _internalChannelMap_e__FixedBuffer internalChannelMap;

                    public uint internalPeriodSizeInFrames;

                    public uint internalPeriods;

            public ma_channel_mix_mode channelMixMode;

                    public uint calculateLFEFromSpatialChannels;

            public ma_data_converter converter;

            public void* pIntermediaryBuffer;

                    public uint intermediaryBufferCap;

                    public uint intermediaryBufferLen;

            [InlineArray(256)]
            public partial struct _name_e__FixedBuffer
            {
                public sbyte e0;
            }

            [InlineArray(254)]
            public partial struct _channelMap_e__FixedBuffer
            {
                public byte e0;
            }

            [InlineArray(254)]
            public partial struct _internalChannelMap_e__FixedBuffer
            {
                public byte e0;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _Anonymous_e__Union
        {
            [FieldOffset(0)]
                    public _alsa_e__Struct alsa;

            [FieldOffset(0)]
                    public _pulse_e__Struct pulse;

            [FieldOffset(0)]
                    public _jack_e__Struct jack;

            [FieldOffset(0)]
                    public _null_device_e__Struct null_device;

            public unsafe partial struct _alsa_e__Struct
            {
                            public void* pPCMPlayback;

                            public void* pPCMCapture;

                public void* pPollDescriptorsPlayback;

                public void* pPollDescriptorsCapture;

                public int pollDescriptorCountPlayback;

                public int pollDescriptorCountCapture;

                public int wakeupfdPlayback;

                public int wakeupfdCapture;

                            public byte isUsingMMapPlayback;

                            public byte isUsingMMapCapture;
            }

            public unsafe partial struct _pulse_e__Struct
            {
                            public void* pMainLoop;

                            public void* pPulseContext;

                            public void* pStreamPlayback;

                            public void* pStreamCapture;
            }

            public unsafe partial struct _jack_e__Struct
            {
                            public void* pClient;

                            public void** ppPortsPlayback;

                            public void** ppPortsCapture;

                public float* pIntermediaryBufferPlayback;

                public float* pIntermediaryBufferCapture;
            }

            public partial struct _null_device_e__Struct
            {
                            public nuint deviceThread;

                public ma_event operationEvent;

                public ma_event operationCompletionEvent;

                public ma_semaphore operationSemaphore;

                            public uint operation;

                public ma_result operationResult;

                public ma_timer timer;

                public double priorRunTime;

                            public uint currentPeriodFramesRemainingPlayback;

                            public uint currentPeriodFramesRemainingCapture;

                            public ulong lastProcessedFramePlayback;

                            public ulong lastProcessedFrameCapture;

                public ma_atomic_bool32 isStarted;
            }
        }
    }

    public enum ma_open_mode_flags : uint
    {
        MA_OPEN_MODE_READ = 0x00000001,
        MA_OPEN_MODE_WRITE = 0x00000002,
    }

    public enum ma_seek_origin : uint
    {
        ma_seek_origin_start,
        ma_seek_origin_current,
        ma_seek_origin_end,
    }

    public partial struct ma_file_info
    {
            public ulong sizeInBytes;
    }

    public unsafe partial struct ma_vfs_callbacks
    {
            public delegate* unmanaged[Cdecl]<void*, sbyte*, uint, void**, ma_result> onOpen;

            public delegate* unmanaged[Cdecl]<void*, uint*, uint, void**, ma_result> onOpenW;

            public delegate* unmanaged[Cdecl]<void*, void*, ma_result> onClose;

            public delegate* unmanaged[Cdecl]<void*, void*, void*, nuint, nuint*, ma_result> onRead;

            public delegate* unmanaged[Cdecl]<void*, void*, void*, nuint, nuint*, ma_result> onWrite;

            public delegate* unmanaged[Cdecl]<void*, void*, long, ma_seek_origin, ma_result> onSeek;

            public delegate* unmanaged[Cdecl]<void*, void*, long*, ma_result> onTell;

            public delegate* unmanaged[Cdecl]<void*, void*, ma_file_info*, ma_result> onInfo;
    }

    public partial struct ma_default_vfs
    {
        public ma_vfs_callbacks cb;

        public ma_allocation_callbacks allocationCallbacks;
    }

    public enum ma_encoding_format : uint
    {
        ma_encoding_format_unknown = 0,
        ma_encoding_format_wav,
        ma_encoding_format_flac,
        ma_encoding_format_mp3,
        ma_encoding_format_vorbis,
    }

    public partial struct ma_decoding_backend_config
    {
        public ma_format preferredFormat;

            public uint seekPointCount;
    }

    public unsafe partial struct ma_decoding_backend_vtable
    {
            public delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void*, nuint, nuint*, ma_result>, delegate* unmanaged[Cdecl]<void*, long, ma_seek_origin, ma_result>, delegate* unmanaged[Cdecl]<void*, long*, ma_result>, void*, ma_decoding_backend_config*, ma_allocation_callbacks*, void**, ma_result> onInit;

            public delegate* unmanaged[Cdecl]<void*, sbyte*, ma_decoding_backend_config*, ma_allocation_callbacks*, void**, ma_result> onInitFile;

            public delegate* unmanaged[Cdecl]<void*, uint*, ma_decoding_backend_config*, ma_allocation_callbacks*, void**, ma_result> onInitFileW;

            public delegate* unmanaged[Cdecl]<void*, void*, nuint, ma_decoding_backend_config*, ma_allocation_callbacks*, void**, ma_result> onInitMemory;

            public delegate* unmanaged[Cdecl]<void*, void*, ma_allocation_callbacks*, void> onUninit;
    }

    public unsafe partial struct ma_decoder_config
    {
        public ma_format format;

            public uint channels;

            public uint sampleRate;

            public byte* pChannelMap;

        public ma_channel_mix_mode channelMixMode;

        public ma_dither_mode ditherMode;

        public ma_resampler_config resampling;

        public ma_allocation_callbacks allocationCallbacks;

        public ma_encoding_format encodingFormat;

            public uint seekPointCount;

        public ma_decoding_backend_vtable** ppCustomBackendVTables;

            public uint customBackendCount;

        public void* pCustomBackendUserData;
    }

    public unsafe partial struct ma_decoder
    {
        public ma_data_source_base ds;

            public void* pBackend;

            public ma_decoding_backend_vtable* pBackendVTable;

        public void* pBackendUserData;

            public delegate* unmanaged[Cdecl]<ma_decoder*, void*, nuint, nuint*, ma_result> onRead;

            public delegate* unmanaged[Cdecl]<ma_decoder*, long, ma_seek_origin, ma_result> onSeek;

            public delegate* unmanaged[Cdecl]<ma_decoder*, long*, ma_result> onTell;

        public void* pUserData;

            public ulong readPointerInPCMFrames;

        public ma_format outputFormat;

            public uint outputChannels;

            public uint outputSampleRate;

        public ma_data_converter converter;

        public void* pInputCache;

            public ulong inputCacheCap;

            public ulong inputCacheConsumed;

            public ulong inputCacheRemaining;

        public ma_allocation_callbacks allocationCallbacks;

            public _data_e__Union data;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _data_e__Union
        {
            [FieldOffset(0)]
                    public _vfs_e__Struct vfs;

            [FieldOffset(0)]
                    public _memory_e__Struct memory;

            public unsafe partial struct _vfs_e__Struct
            {
                            public void* pVFS;

                            public void* file;
            }

            public unsafe partial struct _memory_e__Struct
            {
                            public byte* pData;

                            public nuint dataSize;

                            public nuint currentReadPos;
            }
        }
    }

    public partial struct ma_encoder_config
    {
        public ma_encoding_format encodingFormat;

        public ma_format format;

            public uint channels;

            public uint sampleRate;

        public ma_allocation_callbacks allocationCallbacks;
    }

    public unsafe partial struct ma_encoder
    {
        public ma_encoder_config config;

            public delegate* unmanaged[Cdecl]<ma_encoder*, void*, nuint, nuint*, ma_result> onWrite;

            public delegate* unmanaged[Cdecl]<ma_encoder*, long, ma_seek_origin, ma_result> onSeek;

            public delegate* unmanaged[Cdecl]<ma_encoder*, ma_result> onInit;

            public delegate* unmanaged[Cdecl]<ma_encoder*, void> onUninit;

            public delegate* unmanaged[Cdecl]<ma_encoder*, void*, ulong, ulong*, ma_result> onWritePCMFrames;

        public void* pUserData;

        public void* pInternalEncoder;

            public _data_e__Union data;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _data_e__Union
        {
            [FieldOffset(0)]
                    public _vfs_e__Struct vfs;

            public unsafe partial struct _vfs_e__Struct
            {
                            public void* pVFS;

                            public void* file;
            }
        }
    }

    public enum ma_waveform_type : uint
    {
        ma_waveform_type_sine,
        ma_waveform_type_square,
        ma_waveform_type_triangle,
        ma_waveform_type_sawtooth,
    }

    public partial struct ma_waveform_config
    {
        public ma_format format;

            public uint channels;

            public uint sampleRate;

        public ma_waveform_type type;

        public double amplitude;

        public double frequency;
    }

    public partial struct ma_waveform
    {
        public ma_data_source_base ds;

        public ma_waveform_config config;

        public double advance;

        public double time;
    }

    public partial struct ma_pulsewave_config
    {
        public ma_format format;

            public uint channels;

            public uint sampleRate;

        public double dutyCycle;

        public double amplitude;

        public double frequency;
    }

    public partial struct ma_pulsewave
    {
        public ma_waveform waveform;

        public ma_pulsewave_config config;
    }

    public enum ma_noise_type : uint
    {
        ma_noise_type_white,
        ma_noise_type_pink,
        ma_noise_type_brownian,
    }

    public partial struct ma_noise_config
    {
        public ma_format format;

            public uint channels;

        public ma_noise_type type;

            public int seed;

        public double amplitude;

            public uint duplicateChannels;
    }

    public unsafe partial struct ma_noise
    {
        public ma_data_source_base ds;

        public ma_noise_config config;

        public ma_lcg lcg;

            public _state_e__Union state;

        public void* _pHeap;

            public uint _ownsHeap;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _state_e__Union
        {
            [FieldOffset(0)]
                    public _pink_e__Struct pink;

            [FieldOffset(0)]
                    public _brownian_e__Struct brownian;

            public unsafe partial struct _pink_e__Struct
            {
                public double** bin;

                public double* accumulation;

                            public uint* counter;
            }

            public unsafe partial struct _brownian_e__Struct
            {
                public double* accumulation;
            }
        }
    }

    public enum ma_resource_manager_data_source_flags : uint
    {
        MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_STREAM = 0x00000001,
        MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_DECODE = 0x00000002,
        MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_ASYNC = 0x00000004,
        MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_WAIT_INIT = 0x00000008,
        MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_UNKNOWN_LENGTH = 0x00000010,
        MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_LOOPING = 0x00000020,
    }

    public unsafe partial struct ma_resource_manager_pipeline_stage_notification
    {
            public void* pNotification;

        public ma_fence* pFence;
    }

    public partial struct ma_resource_manager_pipeline_notifications
    {
        public ma_resource_manager_pipeline_stage_notification init;

        public ma_resource_manager_pipeline_stage_notification done;
    }

    public enum ma_resource_manager_flags : uint
    {
        MA_RESOURCE_MANAGER_FLAG_NON_BLOCKING = 0x00000001,
        MA_RESOURCE_MANAGER_FLAG_NO_THREADING = 0x00000002,
    }

    public unsafe partial struct ma_resource_manager_data_source_config
    {
            public sbyte* pFilePath;

            public uint* pFilePathW;

            public ma_resource_manager_pipeline_notifications* pNotifications;

            public ulong initialSeekPointInPCMFrames;

            public ulong rangeBegInPCMFrames;

            public ulong rangeEndInPCMFrames;

            public ulong loopPointBegInPCMFrames;

            public ulong loopPointEndInPCMFrames;

            public uint flags;

            public uint isLooping;
    }

    public enum ma_resource_manager_data_supply_type : uint
    {
        ma_resource_manager_data_supply_type_unknown = 0,
        ma_resource_manager_data_supply_type_encoded,
        ma_resource_manager_data_supply_type_decoded,
        ma_resource_manager_data_supply_type_decoded_paged,
    }

    public partial struct ma_resource_manager_data_supply
    {
        public ma_resource_manager_data_supply_type type;

            public _backend_e__Union backend;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _backend_e__Union
        {
            [FieldOffset(0)]
                    public _encoded_e__Struct encoded;

            [FieldOffset(0)]
                    public _decoded_e__Struct decoded;

            [FieldOffset(0)]
                    public _decodedPaged_e__Struct decodedPaged;

            public unsafe partial struct _encoded_e__Struct
            {
                            public void* pData;

                            public nuint sizeInBytes;
            }

            public unsafe partial struct _decoded_e__Struct
            {
                            public void* pData;

                            public ulong totalFrameCount;

                            public ulong decodedFrameCount;

                public ma_format format;

                            public uint channels;

                            public uint sampleRate;
            }

            public partial struct _decodedPaged_e__Struct
            {
                public ma_paged_audio_buffer_data data;

                            public ulong decodedFrameCount;

                            public uint sampleRate;
            }
        }
    }

    public unsafe partial struct ma_resource_manager_data_buffer_node
    {
            public uint hashedName32;

            public uint refCount;

        public ma_result result;

            public uint executionCounter;

            public uint executionPointer;

            public uint isDataOwnedByResourceManager;

        public ma_resource_manager_data_supply data;

        public ma_resource_manager_data_buffer_node* pParent;

        public ma_resource_manager_data_buffer_node* pChildLo;

        public ma_resource_manager_data_buffer_node* pChildHi;
    }

    public unsafe partial struct ma_resource_manager_data_buffer
    {
        public ma_data_source_base ds;

        public ma_resource_manager* pResourceManager;

        public ma_resource_manager_data_buffer_node* pNode;

            public uint flags;

            public uint executionCounter;

            public uint executionPointer;

            public ulong seekTargetInPCMFrames;

            public uint seekToCursorOnNextRead;

        public ma_result result;

            public uint isLooping;

        public ma_atomic_bool32 isConnectorInitialized;

            public _connector_e__Union connector;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _connector_e__Union
        {
            [FieldOffset(0)]
            public ma_decoder decoder;

            [FieldOffset(0)]
            public ma_audio_buffer buffer;

            [FieldOffset(0)]
            public ma_paged_audio_buffer pagedBuffer;
        }
    }

    public unsafe partial struct ma_resource_manager_data_stream
    {
        public ma_data_source_base ds;

        public ma_resource_manager* pResourceManager;

            public uint flags;

        public ma_decoder decoder;

            public uint isDecoderInitialized;

            public ulong totalLengthInPCMFrames;

            public uint relativeCursor;

            public ulong absoluteCursor;

            public uint currentPageIndex;

            public uint executionCounter;

            public uint executionPointer;

            public uint isLooping;

        public void* pPageData;

            public _pageFrameCount_e__FixedBuffer pageFrameCount;

        public ma_result result;

            public uint isDecoderAtEnd;

            public _isPageValid_e__FixedBuffer isPageValid;

            public uint seekCounter;

        [InlineArray(2)]
        public partial struct _pageFrameCount_e__FixedBuffer
        {
            public uint e0;
        }

        [InlineArray(2)]
        public partial struct _isPageValid_e__FixedBuffer
        {
            public uint e0;
        }
    }

    public partial struct ma_resource_manager_data_source
    {
            public _backend_e__Union backend;

            public uint flags;

            public uint executionCounter;

            public uint executionPointer;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _backend_e__Union
        {
            [FieldOffset(0)]
            public ma_resource_manager_data_buffer buffer;

            [FieldOffset(0)]
            public ma_resource_manager_data_stream stream;
        }
    }

    public unsafe partial struct ma_resource_manager_config
    {
        public ma_allocation_callbacks allocationCallbacks;

        public ma_log* pLog;

        public ma_format decodedFormat;

            public uint decodedChannels;

            public uint decodedSampleRate;

            public uint jobThreadCount;

            public nuint jobThreadStackSize;

            public uint jobQueueCapacity;

            public uint flags;

            public void* pVFS;

        public ma_decoding_backend_vtable** ppCustomDecodingBackendVTables;

            public uint customDecodingBackendCount;

        public void* pCustomDecodingBackendUserData;

        public ma_resampler_config resampling;
    }

    public unsafe partial struct ma_resource_manager
    {
        public ma_resource_manager_config config;

        public ma_resource_manager_data_buffer_node* pRootDataBufferNode;

            public IntPtr dataBufferBSTLock;

            public _jobThreads_e__FixedBuffer jobThreads;

        public ma_job_queue jobQueue;

        public ma_default_vfs defaultVFS;

        public ma_log log;

        [InlineArray(64)]
        public partial struct _jobThreads_e__FixedBuffer
        {
            public nuint e0;
        }
    }

    public partial struct ma_stack
    {
            public nuint offset;

            public nuint sizeInBytes;

            public __data_e__FixedBuffer _data;

        public partial struct __data_e__FixedBuffer
        {
            public byte e0;

            [UnscopedRef]
            public ref byte this[int index]
            {
                get
                {
                    return ref Unsafe.Add(ref e0, index);
                }
            }

            [UnscopedRef]
            public Span<byte> AsSpan(int length) => MemoryMarshal.CreateSpan(ref e0, length);
        }
    }

    public enum ma_node_flags : uint
    {
        MA_NODE_FLAG_PASSTHROUGH = 0x00000001,
        MA_NODE_FLAG_CONTINUOUS_PROCESSING = 0x00000002,
        MA_NODE_FLAG_ALLOW_NULL_INPUT = 0x00000004,
        MA_NODE_FLAG_DIFFERENT_PROCESSING_RATES = 0x00000008,
        MA_NODE_FLAG_SILENT_OUTPUT = 0x00000010,
    }

    public enum ma_node_state : uint
    {
        ma_node_state_started = 0,
        ma_node_state_stopped = 1,
    }

    public unsafe partial struct ma_node_vtable
    {
            public delegate* unmanaged[Cdecl]<void*, float**, uint*, float**, uint*, void> onProcess;

            public delegate* unmanaged[Cdecl]<void*, uint, uint*, ma_result> onGetRequiredInputFrameCount;

            public byte inputBusCount;

            public byte outputBusCount;

            public uint flags;
    }

    public unsafe partial struct ma_node_config
    {
            public ma_node_vtable* vtable;

        public ma_node_state initialState;

            public uint inputBusCount;

            public uint outputBusCount;

            public uint* pInputChannels;

            public uint* pOutputChannels;
    }

    public unsafe partial struct ma_node_output_bus
    {
            public void* pNode;

            public byte outputBusIndex;

            public byte channels;

            public byte inputNodeInputBusIndex;

            public uint flags;

            public uint refCount;

            public uint isAttached;

            public uint @lock;

        public float volume;

        public ma_node_output_bus* pNext;

        public ma_node_output_bus* pPrev;

            public void* pInputNode;
    }

    public partial struct ma_node_input_bus
    {
        public ma_node_output_bus head;

            public uint nextCounter;

            public uint @lock;

            public byte channels;
    }

    public unsafe partial struct ma_node_base
    {
        public ma_node_graph* pNodeGraph;

            public ma_node_vtable* vtable;

            public uint inputBusCount;

            public uint outputBusCount;

        public ma_node_input_bus* pInputBuses;

        public ma_node_output_bus* pOutputBuses;

        public float* pCachedData;

            public ushort cachedDataCapInFramesPerBus;

            public ushort cachedFrameCountOut;

            public ushort cachedFrameCountIn;

            public ushort consumedFrameCountIn;

        public ma_node_state state;

            public _stateTimes_e__FixedBuffer stateTimes;

            public ulong localTime;

            public __inputBuses_e__FixedBuffer _inputBuses;

            public __outputBuses_e__FixedBuffer _outputBuses;

        public void* _pHeap;

            public uint _ownsHeap;

        [InlineArray(2)]
        public partial struct _stateTimes_e__FixedBuffer
        {
            public ulong e0;
        }

        [InlineArray(2)]
        public partial struct __inputBuses_e__FixedBuffer
        {
            public ma_node_input_bus e0;
        }

        [InlineArray(2)]
        public partial struct __outputBuses_e__FixedBuffer
        {
            public ma_node_output_bus e0;
        }
    }

    public partial struct ma_node_graph_config
    {
            public uint channels;

            public uint processingSizeInFrames;

            public nuint preMixStackSizeInBytes;
    }

    public unsafe partial struct ma_node_graph
    {
        public ma_node_base @base;

        public ma_node_base endpoint;

        public float* pProcessingCache;

            public uint processingCacheFramesRemaining;

            public uint processingSizeInFrames;

            public uint isReading;

        public ma_stack* pPreMixStack;
    }

    public unsafe partial struct ma_data_source_node_config
    {
        public ma_node_config nodeConfig;

            public void* pDataSource;
    }

    public unsafe partial struct ma_data_source_node
    {
        public ma_node_base @base;

            public void* pDataSource;
    }

    public partial struct ma_splitter_node_config
    {
        public ma_node_config nodeConfig;

            public uint channels;

            public uint outputBusCount;
    }

    public partial struct ma_splitter_node
    {
        public ma_node_base @base;
    }

    public partial struct ma_biquad_node_config
    {
        public ma_node_config nodeConfig;

        public ma_biquad_config biquad;
    }

    public partial struct ma_biquad_node
    {
        public ma_node_base baseNode;

        public ma_biquad biquad;
    }

    public partial struct ma_lpf_node_config
    {
        public ma_node_config nodeConfig;

        public ma_lpf_config lpf;
    }

    public partial struct ma_lpf_node
    {
        public ma_node_base baseNode;

        public ma_lpf lpf;
    }

    public partial struct ma_hpf_node_config
    {
        public ma_node_config nodeConfig;

        public ma_hpf_config hpf;
    }

    public partial struct ma_hpf_node
    {
        public ma_node_base baseNode;

        public ma_hpf hpf;
    }

    public partial struct ma_bpf_node_config
    {
        public ma_node_config nodeConfig;

        public ma_bpf_config bpf;
    }

    public partial struct ma_bpf_node
    {
        public ma_node_base baseNode;

        public ma_bpf bpf;
    }

    public partial struct ma_notch_node_config
    {
        public ma_node_config nodeConfig;

            public ma_notch2_config notch;
    }

    public partial struct ma_notch_node
    {
        public ma_node_base baseNode;

        public ma_notch2 notch;
    }

    public partial struct ma_peak_node_config
    {
        public ma_node_config nodeConfig;

            public ma_peak2_config peak;
    }

    public partial struct ma_peak_node
    {
        public ma_node_base baseNode;

        public ma_peak2 peak;
    }

    public partial struct ma_loshelf_node_config
    {
        public ma_node_config nodeConfig;

            public ma_loshelf2_config loshelf;
    }

    public partial struct ma_loshelf_node
    {
        public ma_node_base baseNode;

        public ma_loshelf2 loshelf;
    }

    public partial struct ma_hishelf_node_config
    {
        public ma_node_config nodeConfig;

            public ma_hishelf2_config hishelf;
    }

    public partial struct ma_hishelf_node
    {
        public ma_node_base baseNode;

        public ma_hishelf2 hishelf;
    }

    public partial struct ma_delay_node_config
    {
        public ma_node_config nodeConfig;

        public ma_delay_config delay;
    }

    public partial struct ma_delay_node
    {
        public ma_node_base baseNode;

        public ma_delay delay;
    }

    public enum ma_sound_flags : uint
    {
        MA_SOUND_FLAG_STREAM = 0x00000001,
        MA_SOUND_FLAG_DECODE = 0x00000002,
        MA_SOUND_FLAG_ASYNC = 0x00000004,
        MA_SOUND_FLAG_WAIT_INIT = 0x00000008,
        MA_SOUND_FLAG_UNKNOWN_LENGTH = 0x00000010,
        MA_SOUND_FLAG_LOOPING = 0x00000020,
        MA_SOUND_FLAG_NO_DEFAULT_ATTACHMENT = 0x00001000,
        MA_SOUND_FLAG_NO_PITCH = 0x00002000,
        MA_SOUND_FLAG_NO_SPATIALIZATION = 0x00004000,
    }

    public enum ma_engine_node_type : uint
    {
        ma_engine_node_type_sound,
        ma_engine_node_type_group,
    }

    public unsafe partial struct ma_engine_node_config
    {
        public ma_engine* pEngine;

        public ma_engine_node_type type;

            public uint channelsIn;

            public uint channelsOut;

            public uint sampleRate;

            public uint volumeSmoothTimeInPCMFrames;

        public ma_mono_expansion_mode monoExpansionMode;

            public byte isPitchDisabled;

            public byte isSpatializationDisabled;

            public byte pinnedListenerIndex;

        public ma_resampler_config resampling;
    }

    public unsafe partial struct ma_engine_node
    {
        public ma_node_base baseNode;

        public ma_engine* pEngine;

            public uint sampleRate;

            public uint volumeSmoothTimeInPCMFrames;

        public ma_mono_expansion_mode monoExpansionMode;

        public ma_fader fader;

        public ma_resampler resampler;

        public ma_spatializer spatializer;

        public ma_panner panner;

        public ma_gainer volumeGainer;

        public ma_atomic_float volume;

        public float pitch;

        public float oldPitch;

        public float oldDopplerPitch;

            public uint isPitchDisabled;

            public uint isSpatializationDisabled;

            public uint pinnedListenerIndex;

            public _fadeSettings_e__Struct fadeSettings;

            public byte _ownsHeap;

        public void* _pHeap;

        public partial struct _fadeSettings_e__Struct
        {
            public ma_atomic_float volumeBeg;

            public ma_atomic_float volumeEnd;

            public ma_atomic_uint64 fadeLengthInFrames;

            public ma_atomic_uint64 absoluteGlobalTimeInFrames;
        }
    }

    public unsafe partial struct ma_sound_config
    {
            public sbyte* pFilePath;

            public uint* pFilePathW;

            public void* pDataSource;

            public void* pInitialAttachment;

            public uint initialAttachmentInputBusIndex;

            public uint channelsIn;

            public uint channelsOut;

        public ma_mono_expansion_mode monoExpansionMode;

            public uint flags;

            public uint volumeSmoothTimeInPCMFrames;

            public ulong initialSeekPointInPCMFrames;

            public ulong rangeBegInPCMFrames;

            public ulong rangeEndInPCMFrames;

            public ulong loopPointBegInPCMFrames;

            public ulong loopPointEndInPCMFrames;

            public delegate* unmanaged[Cdecl]<void*, ma_sound*, void> endCallback;

        public void* pEndCallbackUserData;

        public ma_resampler_config pitchResampling;

        public ma_resource_manager_pipeline_notifications initNotifications;

        public ma_fence* pDoneFence;

            public uint isLooping;
    }

    public unsafe partial struct ma_sound
    {
        public ma_engine_node engineNode;

            public void* pDataSource;

            public ulong seekTarget;

            public uint atEnd;

            public delegate* unmanaged[Cdecl]<void*, ma_sound*, void> endCallback;

        public void* pEndCallbackUserData;

        public float* pProcessingCache;

            public uint processingCacheFramesRemaining;

            public uint processingCacheCap;

            public byte ownsDataSource;

        public ma_resource_manager_data_source* pResourceManagerDataSource;
    }

    public unsafe partial struct ma_sound_inlined
    {
        public ma_sound sound;

        public ma_sound_inlined* pNext;

        public ma_sound_inlined* pPrev;
    }

    public unsafe partial struct ma_engine_config
    {
        public ma_resource_manager* pResourceManager;

        public ma_context* pContext;

        public ma_device* pDevice;

        public ma_device_id* pPlaybackDeviceID;

            public delegate* unmanaged[Cdecl]<ma_device*, void*, void*, uint, void> dataCallback;

            public delegate* unmanaged[Cdecl]<ma_device_notification*, void> notificationCallback;

        public ma_log* pLog;

            public uint listenerCount;

            public uint channels;

            public uint sampleRate;

            public uint periodSizeInFrames;

            public uint periodSizeInMilliseconds;

            public uint gainSmoothTimeInFrames;

            public uint gainSmoothTimeInMilliseconds;

            public uint defaultVolumeSmoothTimeInPCMFrames;

            public uint preMixStackSizeInBytes;

        public ma_allocation_callbacks allocationCallbacks;

            public uint noAutoStart;

            public uint noDevice;

        public ma_mono_expansion_mode monoExpansionMode;

            public void* pResourceManagerVFS;

            public delegate* unmanaged[Cdecl]<void*, float*, ulong, void> onProcess;

        public void* pProcessUserData;

        public ma_resampler_config resourceManagerResampling;

        public ma_resampler_config pitchResampling;
    }

    public unsafe partial struct ma_engine
    {
        public ma_node_graph nodeGraph;

        public ma_resource_manager* pResourceManager;

        public ma_device* pDevice;

        public ma_log* pLog;

            public uint sampleRate;

            public uint listenerCount;

            public _listeners_e__FixedBuffer listeners;

        public ma_allocation_callbacks allocationCallbacks;

            public byte ownsResourceManager;

            public byte ownsDevice;

            public uint inlinedSoundLock;

        public ma_sound_inlined* pInlinedSoundHead;

            public uint inlinedSoundCount;

            public uint gainSmoothTimeInFrames;

            public uint defaultVolumeSmoothTimeInPCMFrames;

        public ma_mono_expansion_mode monoExpansionMode;

            public delegate* unmanaged[Cdecl]<void*, float*, ulong, void> onProcess;

        public void* pProcessUserData;

        public ma_resampler_config pitchResamplingConfig;

        [InlineArray(4)]
        public partial struct _listeners_e__FixedBuffer
        {
            public ma_spatializer_listener e0;
        }
    }

    public static unsafe partial class Methods
    {
        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_version(uint* pMajor, uint* pMinor, uint* pRevision);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern sbyte* ma_version_string();

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_log_callback ma_log_callback_init(delegate* unmanaged[Cdecl]<void*, uint, sbyte*, void> onLog, void* pUserData);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_log_init(ma_allocation_callbacks* pAllocationCallbacks, ma_log* pLog);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_log_uninit(ma_log* pLog);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_log_register_callback(ma_log* pLog, ma_log_callback callback);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_log_unregister_callback(ma_log* pLog, ma_log_callback callback);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_log_post(ma_log* pLog, uint level, sbyte* pMessage);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_log_postv(ma_log* pLog, uint level, sbyte* pFormat, IntPtr* args);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_log_postf(ma_log* pLog, uint level, sbyte* pFormat, __arglist);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_biquad_config ma_biquad_config_init(ma_format format, uint channels, double b0, double b1, double b2, double a0, double a1, double a2);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_biquad_get_heap_size(ma_biquad_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_biquad_init_preallocated(ma_biquad_config* pConfig, void* pHeap, ma_biquad* pBQ);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_biquad_init(ma_biquad_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_biquad* pBQ);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_biquad_uninit(ma_biquad* pBQ, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_biquad_reinit(ma_biquad_config* pConfig, ma_biquad* pBQ);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_biquad_clear_cache(ma_biquad* pBQ);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_biquad_process_pcm_frames(ma_biquad* pBQ, void* pFramesOut, void* pFramesIn, ulong frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_biquad_get_latency(ma_biquad* pBQ);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_lpf1_config ma_lpf1_config_init(ma_format format, uint channels, uint sampleRate, double cutoffFrequency);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ma_lpf1_config ma_lpf2_config_init(ma_format format, uint channels, uint sampleRate, double cutoffFrequency, double q);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_lpf1_get_heap_size(ma_lpf1_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_lpf1_init_preallocated(ma_lpf1_config* pConfig, void* pHeap, ma_lpf1* pLPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_lpf1_init(ma_lpf1_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_lpf1* pLPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_lpf1_uninit(ma_lpf1* pLPF, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_lpf1_reinit(ma_lpf1_config* pConfig, ma_lpf1* pLPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_lpf1_clear_cache(ma_lpf1* pLPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_lpf1_process_pcm_frames(ma_lpf1* pLPF, void* pFramesOut, void* pFramesIn, ulong frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_lpf1_get_latency(ma_lpf1* pLPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_lpf2_get_heap_size(ma_lpf1_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_lpf2_init_preallocated(ma_lpf1_config* pConfig, void* pHeap, ma_lpf2* pHPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_lpf2_init(ma_lpf1_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_lpf2* pLPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_lpf2_uninit(ma_lpf2* pLPF, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_lpf2_reinit(ma_lpf1_config* pConfig, ma_lpf2* pLPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_lpf2_clear_cache(ma_lpf2* pLPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_lpf2_process_pcm_frames(ma_lpf2* pLPF, void* pFramesOut, void* pFramesIn, ulong frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_lpf2_get_latency(ma_lpf2* pLPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_lpf_config ma_lpf_config_init(ma_format format, uint channels, uint sampleRate, double cutoffFrequency, uint order);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_lpf_get_heap_size(ma_lpf_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_lpf_init_preallocated(ma_lpf_config* pConfig, void* pHeap, ma_lpf* pLPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_lpf_init(ma_lpf_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_lpf* pLPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_lpf_uninit(ma_lpf* pLPF, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_lpf_reinit(ma_lpf_config* pConfig, ma_lpf* pLPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_lpf_clear_cache(ma_lpf* pLPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_lpf_process_pcm_frames(ma_lpf* pLPF, void* pFramesOut, void* pFramesIn, ulong frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_lpf_get_latency(ma_lpf* pLPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_hpf1_config ma_hpf1_config_init(ma_format format, uint channels, uint sampleRate, double cutoffFrequency);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ma_hpf1_config ma_hpf2_config_init(ma_format format, uint channels, uint sampleRate, double cutoffFrequency, double q);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hpf1_get_heap_size(ma_hpf1_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hpf1_init_preallocated(ma_hpf1_config* pConfig, void* pHeap, ma_hpf1* pLPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hpf1_init(ma_hpf1_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_hpf1* pHPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_hpf1_uninit(ma_hpf1* pHPF, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hpf1_reinit(ma_hpf1_config* pConfig, ma_hpf1* pHPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hpf1_process_pcm_frames(ma_hpf1* pHPF, void* pFramesOut, void* pFramesIn, ulong frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_hpf1_get_latency(ma_hpf1* pHPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hpf2_get_heap_size(ma_hpf1_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hpf2_init_preallocated(ma_hpf1_config* pConfig, void* pHeap, ma_hpf2* pHPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hpf2_init(ma_hpf1_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_hpf2* pHPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_hpf2_uninit(ma_hpf2* pHPF, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hpf2_reinit(ma_hpf1_config* pConfig, ma_hpf2* pHPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hpf2_process_pcm_frames(ma_hpf2* pHPF, void* pFramesOut, void* pFramesIn, ulong frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_hpf2_get_latency(ma_hpf2* pHPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_hpf_config ma_hpf_config_init(ma_format format, uint channels, uint sampleRate, double cutoffFrequency, uint order);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hpf_get_heap_size(ma_hpf_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hpf_init_preallocated(ma_hpf_config* pConfig, void* pHeap, ma_hpf* pLPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hpf_init(ma_hpf_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_hpf* pHPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_hpf_uninit(ma_hpf* pHPF, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hpf_reinit(ma_hpf_config* pConfig, ma_hpf* pHPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hpf_process_pcm_frames(ma_hpf* pHPF, void* pFramesOut, void* pFramesIn, ulong frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_hpf_get_latency(ma_hpf* pHPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_bpf2_config ma_bpf2_config_init(ma_format format, uint channels, uint sampleRate, double cutoffFrequency, double q);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_bpf2_get_heap_size(ma_bpf2_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_bpf2_init_preallocated(ma_bpf2_config* pConfig, void* pHeap, ma_bpf2* pBPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_bpf2_init(ma_bpf2_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_bpf2* pBPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_bpf2_uninit(ma_bpf2* pBPF, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_bpf2_reinit(ma_bpf2_config* pConfig, ma_bpf2* pBPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_bpf2_process_pcm_frames(ma_bpf2* pBPF, void* pFramesOut, void* pFramesIn, ulong frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_bpf2_get_latency(ma_bpf2* pBPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_bpf_config ma_bpf_config_init(ma_format format, uint channels, uint sampleRate, double cutoffFrequency, uint order);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_bpf_get_heap_size(ma_bpf_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_bpf_init_preallocated(ma_bpf_config* pConfig, void* pHeap, ma_bpf* pBPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_bpf_init(ma_bpf_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_bpf* pBPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_bpf_uninit(ma_bpf* pBPF, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_bpf_reinit(ma_bpf_config* pConfig, ma_bpf* pBPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_bpf_process_pcm_frames(ma_bpf* pBPF, void* pFramesOut, void* pFramesIn, ulong frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_bpf_get_latency(ma_bpf* pBPF);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_notch2_config ma_notch2_config_init(ma_format format, uint channels, uint sampleRate, double q, double frequency);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_notch2_get_heap_size(ma_notch2_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_notch2_init_preallocated(ma_notch2_config* pConfig, void* pHeap, ma_notch2* pFilter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_notch2_init(ma_notch2_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_notch2* pFilter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_notch2_uninit(ma_notch2* pFilter, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_notch2_reinit(ma_notch2_config* pConfig, ma_notch2* pFilter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_notch2_process_pcm_frames(ma_notch2* pFilter, void* pFramesOut, void* pFramesIn, ulong frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_notch2_get_latency(ma_notch2* pFilter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_peak2_config ma_peak2_config_init(ma_format format, uint channels, uint sampleRate, double gainDB, double q, double frequency);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_peak2_get_heap_size(ma_peak2_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_peak2_init_preallocated(ma_peak2_config* pConfig, void* pHeap, ma_peak2* pFilter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_peak2_init(ma_peak2_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_peak2* pFilter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_peak2_uninit(ma_peak2* pFilter, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_peak2_reinit(ma_peak2_config* pConfig, ma_peak2* pFilter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_peak2_process_pcm_frames(ma_peak2* pFilter, void* pFramesOut, void* pFramesIn, ulong frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_peak2_get_latency(ma_peak2* pFilter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_loshelf2_config ma_loshelf2_config_init(ma_format format, uint channels, uint sampleRate, double gainDB, double shelfSlope, double frequency);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_loshelf2_get_heap_size(ma_loshelf2_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_loshelf2_init_preallocated(ma_loshelf2_config* pConfig, void* pHeap, ma_loshelf2* pFilter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_loshelf2_init(ma_loshelf2_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_loshelf2* pFilter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_loshelf2_uninit(ma_loshelf2* pFilter, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_loshelf2_reinit(ma_loshelf2_config* pConfig, ma_loshelf2* pFilter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_loshelf2_process_pcm_frames(ma_loshelf2* pFilter, void* pFramesOut, void* pFramesIn, ulong frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_loshelf2_get_latency(ma_loshelf2* pFilter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_hishelf2_config ma_hishelf2_config_init(ma_format format, uint channels, uint sampleRate, double gainDB, double shelfSlope, double frequency);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hishelf2_get_heap_size(ma_hishelf2_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hishelf2_init_preallocated(ma_hishelf2_config* pConfig, void* pHeap, ma_hishelf2* pFilter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hishelf2_init(ma_hishelf2_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_hishelf2* pFilter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_hishelf2_uninit(ma_hishelf2* pFilter, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hishelf2_reinit(ma_hishelf2_config* pConfig, ma_hishelf2* pFilter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hishelf2_process_pcm_frames(ma_hishelf2* pFilter, void* pFramesOut, void* pFramesIn, ulong frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_hishelf2_get_latency(ma_hishelf2* pFilter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_delay_config ma_delay_config_init(uint channels, uint sampleRate, uint delayInFrames, float decay);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_delay_init(ma_delay_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_delay* pDelay);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_delay_uninit(ma_delay* pDelay, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_delay_process_pcm_frames(ma_delay* pDelay, void* pFramesOut, void* pFramesIn, uint frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_delay_set_wet(ma_delay* pDelay, float value);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_delay_get_wet(ma_delay* pDelay);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_delay_set_dry(ma_delay* pDelay, float value);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_delay_get_dry(ma_delay* pDelay);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_delay_set_decay(ma_delay* pDelay, float value);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_delay_get_decay(ma_delay* pDelay);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_gainer_config ma_gainer_config_init(uint channels, uint smoothTimeInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_gainer_get_heap_size(ma_gainer_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_gainer_init_preallocated(ma_gainer_config* pConfig, void* pHeap, ma_gainer* pGainer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_gainer_init(ma_gainer_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_gainer* pGainer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_gainer_uninit(ma_gainer* pGainer, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_gainer_process_pcm_frames(ma_gainer* pGainer, void* pFramesOut, void* pFramesIn, ulong frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_gainer_set_gain(ma_gainer* pGainer, float newGain);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_gainer_set_gains(ma_gainer* pGainer, float* pNewGains);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_gainer_set_master_volume(ma_gainer* pGainer, float volume);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_gainer_get_master_volume(ma_gainer* pGainer, float* pVolume);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_panner_config ma_panner_config_init(ma_format format, uint channels);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_panner_init(ma_panner_config* pConfig, ma_panner* pPanner);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_panner_process_pcm_frames(ma_panner* pPanner, void* pFramesOut, void* pFramesIn, ulong frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_panner_set_mode(ma_panner* pPanner, ma_pan_mode mode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_pan_mode ma_panner_get_mode(ma_panner* pPanner);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_panner_set_pan(ma_panner* pPanner, float pan);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_panner_get_pan(ma_panner* pPanner);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_fader_config ma_fader_config_init(ma_format format, uint channels, uint sampleRate);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_fader_init(ma_fader_config* pConfig, ma_fader* pFader);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_fader_process_pcm_frames(ma_fader* pFader, void* pFramesOut, void* pFramesIn, ulong frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_fader_get_data_format(ma_fader* pFader, ma_format* pFormat, uint* pChannels, uint* pSampleRate);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_fader_set_fade(ma_fader* pFader, float volumeBeg, float volumeEnd, ulong lengthInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_fader_set_fade_ex(ma_fader* pFader, float volumeBeg, float volumeEnd, ulong lengthInFrames, long startOffsetInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_fader_get_current_volume(ma_fader* pFader);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_spatializer_listener_config ma_spatializer_listener_config_init(uint channelsOut);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_spatializer_listener_get_heap_size(ma_spatializer_listener_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_spatializer_listener_init_preallocated(ma_spatializer_listener_config* pConfig, void* pHeap, ma_spatializer_listener* pListener);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_spatializer_listener_init(ma_spatializer_listener_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_spatializer_listener* pListener);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_listener_uninit(ma_spatializer_listener* pListener, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern byte* ma_spatializer_listener_get_channel_map(ma_spatializer_listener* pListener);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_listener_set_cone(ma_spatializer_listener* pListener, float innerAngleInRadians, float outerAngleInRadians, float outerGain);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_listener_get_cone(ma_spatializer_listener* pListener, float* pInnerAngleInRadians, float* pOuterAngleInRadians, float* pOuterGain);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_listener_set_position(ma_spatializer_listener* pListener, float x, float y, float z);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_vec3f ma_spatializer_listener_get_position(ma_spatializer_listener* pListener);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_listener_set_direction(ma_spatializer_listener* pListener, float x, float y, float z);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_vec3f ma_spatializer_listener_get_direction(ma_spatializer_listener* pListener);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_listener_set_velocity(ma_spatializer_listener* pListener, float x, float y, float z);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_vec3f ma_spatializer_listener_get_velocity(ma_spatializer_listener* pListener);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_listener_set_speed_of_sound(ma_spatializer_listener* pListener, float speedOfSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_spatializer_listener_get_speed_of_sound(ma_spatializer_listener* pListener);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_listener_set_world_up(ma_spatializer_listener* pListener, float x, float y, float z);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_vec3f ma_spatializer_listener_get_world_up(ma_spatializer_listener* pListener);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_listener_set_enabled(ma_spatializer_listener* pListener, uint isEnabled);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_spatializer_listener_is_enabled(ma_spatializer_listener* pListener);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_spatializer_config ma_spatializer_config_init(uint channelsIn, uint channelsOut);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_spatializer_get_heap_size(ma_spatializer_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_spatializer_init_preallocated(ma_spatializer_config* pConfig, void* pHeap, ma_spatializer* pSpatializer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_spatializer_init(ma_spatializer_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_spatializer* pSpatializer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_uninit(ma_spatializer* pSpatializer, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_spatializer_process_pcm_frames(ma_spatializer* pSpatializer, ma_spatializer_listener* pListener, void* pFramesOut, void* pFramesIn, ulong frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_spatializer_set_master_volume(ma_spatializer* pSpatializer, float volume);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_spatializer_get_master_volume(ma_spatializer* pSpatializer, float* pVolume);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_spatializer_get_input_channels(ma_spatializer* pSpatializer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_spatializer_get_output_channels(ma_spatializer* pSpatializer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_set_attenuation_model(ma_spatializer* pSpatializer, ma_attenuation_model attenuationModel);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_attenuation_model ma_spatializer_get_attenuation_model(ma_spatializer* pSpatializer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_set_positioning(ma_spatializer* pSpatializer, ma_positioning positioning);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_positioning ma_spatializer_get_positioning(ma_spatializer* pSpatializer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_set_rolloff(ma_spatializer* pSpatializer, float rolloff);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_spatializer_get_rolloff(ma_spatializer* pSpatializer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_set_min_gain(ma_spatializer* pSpatializer, float minGain);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_spatializer_get_min_gain(ma_spatializer* pSpatializer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_set_max_gain(ma_spatializer* pSpatializer, float maxGain);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_spatializer_get_max_gain(ma_spatializer* pSpatializer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_set_min_distance(ma_spatializer* pSpatializer, float minDistance);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_spatializer_get_min_distance(ma_spatializer* pSpatializer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_set_max_distance(ma_spatializer* pSpatializer, float maxDistance);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_spatializer_get_max_distance(ma_spatializer* pSpatializer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_set_cone(ma_spatializer* pSpatializer, float innerAngleInRadians, float outerAngleInRadians, float outerGain);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_get_cone(ma_spatializer* pSpatializer, float* pInnerAngleInRadians, float* pOuterAngleInRadians, float* pOuterGain);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_set_doppler_factor(ma_spatializer* pSpatializer, float dopplerFactor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_spatializer_get_doppler_factor(ma_spatializer* pSpatializer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_set_directional_attenuation_factor(ma_spatializer* pSpatializer, float directionalAttenuationFactor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_spatializer_get_directional_attenuation_factor(ma_spatializer* pSpatializer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_set_position(ma_spatializer* pSpatializer, float x, float y, float z);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_vec3f ma_spatializer_get_position(ma_spatializer* pSpatializer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_set_direction(ma_spatializer* pSpatializer, float x, float y, float z);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_vec3f ma_spatializer_get_direction(ma_spatializer* pSpatializer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_set_velocity(ma_spatializer* pSpatializer, float x, float y, float z);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_vec3f ma_spatializer_get_velocity(ma_spatializer* pSpatializer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_spatializer_get_relative_position_and_direction(ma_spatializer* pSpatializer, ma_spatializer_listener* pListener, ma_vec3f* pRelativePos, ma_vec3f* pRelativeDir);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_linear_resampler_config ma_linear_resampler_config_init(ma_format format, uint channels, uint sampleRateIn, uint sampleRateOut);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_linear_resampler_get_heap_size(ma_linear_resampler_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_linear_resampler_init_preallocated(ma_linear_resampler_config* pConfig, void* pHeap, ma_linear_resampler* pResampler);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_linear_resampler_init(ma_linear_resampler_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_linear_resampler* pResampler);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_linear_resampler_uninit(ma_linear_resampler* pResampler, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_linear_resampler_process_pcm_frames(ma_linear_resampler* pResampler, void* pFramesIn, ulong* pFrameCountIn, void* pFramesOut, ulong* pFrameCountOut);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_linear_resampler_set_rate(ma_linear_resampler* pResampler, uint sampleRateIn, uint sampleRateOut);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_linear_resampler_set_rate_ratio(ma_linear_resampler* pResampler, float ratioInOut);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ulong ma_linear_resampler_get_input_latency(ma_linear_resampler* pResampler);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ulong ma_linear_resampler_get_output_latency(ma_linear_resampler* pResampler);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_linear_resampler_get_required_input_frame_count(ma_linear_resampler* pResampler, ulong outputFrameCount, ulong* pInputFrameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_linear_resampler_get_expected_output_frame_count(ma_linear_resampler* pResampler, ulong inputFrameCount, ulong* pOutputFrameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_linear_resampler_reset(ma_linear_resampler* pResampler);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_resampler_config ma_resampler_config_init(ma_format format, uint channels, uint sampleRateIn, uint sampleRateOut, ma_resample_algorithm algorithm);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resampler_get_heap_size(ma_resampler_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resampler_init_preallocated(ma_resampler_config* pConfig, void* pHeap, ma_resampler* pResampler);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resampler_init(ma_resampler_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_resampler* pResampler);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_resampler_uninit(ma_resampler* pResampler, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resampler_process_pcm_frames(ma_resampler* pResampler, void* pFramesIn, ulong* pFrameCountIn, void* pFramesOut, ulong* pFrameCountOut);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resampler_set_rate(ma_resampler* pResampler, uint sampleRateIn, uint sampleRateOut);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resampler_set_rate_ratio(ma_resampler* pResampler, float ratio);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ulong ma_resampler_get_input_latency(ma_resampler* pResampler);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ulong ma_resampler_get_output_latency(ma_resampler* pResampler);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resampler_get_required_input_frame_count(ma_resampler* pResampler, ulong outputFrameCount, ulong* pInputFrameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resampler_get_expected_output_frame_count(ma_resampler* pResampler, ulong inputFrameCount, ulong* pOutputFrameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resampler_reset(ma_resampler* pResampler);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_channel_converter_config ma_channel_converter_config_init(ma_format format, uint channelsIn, byte* pChannelMapIn, uint channelsOut, byte* pChannelMapOut, ma_channel_mix_mode mixingMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_channel_converter_get_heap_size(ma_channel_converter_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_channel_converter_init_preallocated(ma_channel_converter_config* pConfig, void* pHeap, ma_channel_converter* pConverter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_channel_converter_init(ma_channel_converter_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_channel_converter* pConverter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_channel_converter_uninit(ma_channel_converter* pConverter, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_channel_converter_process_pcm_frames(ma_channel_converter* pConverter, void* pFramesOut, void* pFramesIn, ulong frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_channel_converter_get_input_channel_map(ma_channel_converter* pConverter, byte* pChannelMap, nuint channelMapCap);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_channel_converter_get_output_channel_map(ma_channel_converter* pConverter, byte* pChannelMap, nuint channelMapCap);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_data_converter_config ma_data_converter_config_init_default();

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_data_converter_config ma_data_converter_config_init(ma_format formatIn, ma_format formatOut, uint channelsIn, uint channelsOut, uint sampleRateIn, uint sampleRateOut);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_converter_get_heap_size(ma_data_converter_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_converter_init_preallocated(ma_data_converter_config* pConfig, void* pHeap, ma_data_converter* pConverter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_converter_init(ma_data_converter_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_data_converter* pConverter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_data_converter_uninit(ma_data_converter* pConverter, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_converter_process_pcm_frames(ma_data_converter* pConverter, void* pFramesIn, ulong* pFrameCountIn, void* pFramesOut, ulong* pFrameCountOut);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_converter_set_rate(ma_data_converter* pConverter, uint sampleRateIn, uint sampleRateOut);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_converter_set_rate_ratio(ma_data_converter* pConverter, float ratioInOut);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ulong ma_data_converter_get_input_latency(ma_data_converter* pConverter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ulong ma_data_converter_get_output_latency(ma_data_converter* pConverter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_converter_get_required_input_frame_count(ma_data_converter* pConverter, ulong outputFrameCount, ulong* pInputFrameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_converter_get_expected_output_frame_count(ma_data_converter* pConverter, ulong inputFrameCount, ulong* pOutputFrameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_converter_get_input_channel_map(ma_data_converter* pConverter, byte* pChannelMap, nuint channelMapCap);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_converter_get_output_channel_map(ma_data_converter* pConverter, byte* pChannelMap, nuint channelMapCap);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_converter_reset(ma_data_converter* pConverter);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_u8_to_s16(void* pOut, void* pIn, ulong count, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_u8_to_s24(void* pOut, void* pIn, ulong count, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_u8_to_s32(void* pOut, void* pIn, ulong count, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_u8_to_f32(void* pOut, void* pIn, ulong count, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_s16_to_u8(void* pOut, void* pIn, ulong count, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_s16_to_s24(void* pOut, void* pIn, ulong count, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_s16_to_s32(void* pOut, void* pIn, ulong count, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_s16_to_f32(void* pOut, void* pIn, ulong count, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_s24_to_u8(void* pOut, void* pIn, ulong count, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_s24_to_s16(void* pOut, void* pIn, ulong count, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_s24_to_s32(void* pOut, void* pIn, ulong count, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_s24_to_f32(void* pOut, void* pIn, ulong count, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_s32_to_u8(void* pOut, void* pIn, ulong count, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_s32_to_s16(void* pOut, void* pIn, ulong count, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_s32_to_s24(void* pOut, void* pIn, ulong count, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_s32_to_f32(void* pOut, void* pIn, ulong count, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_f32_to_u8(void* pOut, void* pIn, ulong count, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_f32_to_s16(void* pOut, void* pIn, ulong count, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_f32_to_s24(void* pOut, void* pIn, ulong count, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_f32_to_s32(void* pOut, void* pIn, ulong count, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_convert(void* pOut, ma_format formatOut, void* pIn, ma_format formatIn, ulong sampleCount, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_convert_pcm_frames_format(void* pOut, ma_format formatOut, void* pIn, ma_format formatIn, ulong frameCount, uint channels, ma_dither_mode ditherMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_deinterleave_pcm_frames(ma_format format, uint channels, ulong frameCount, void* pInterleavedPCMFrames, void** ppDeinterleavedPCMFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_interleave_pcm_frames(ma_format format, uint channels, ulong frameCount, void** ppDeinterleavedPCMFrames, void* pInterleavedPCMFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern byte ma_channel_map_get_channel(byte* pChannelMap, uint channelCount, uint channelIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_channel_map_init_blank(byte* pChannelMap, uint channels);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_channel_map_init_standard(ma_standard_channel_map standardChannelMap, byte* pChannelMap, nuint channelMapCap, uint channels);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_channel_map_copy(byte* pOut, byte* pIn, uint channels);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_channel_map_copy_or_default(byte* pOut, nuint channelMapCapOut, byte* pIn, uint channels);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_channel_map_is_valid(byte* pChannelMap, uint channels);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_channel_map_is_equal(byte* pChannelMapA, byte* pChannelMapB, uint channels);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_channel_map_is_blank(byte* pChannelMap, uint channels);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_channel_map_contains_channel_position(uint channels, byte* pChannelMap, byte channelPosition);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_channel_map_find_channel_position(uint channels, byte* pChannelMap, byte channelPosition, uint* pChannelIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern nuint ma_channel_map_to_string(byte* pChannelMap, uint channels, sbyte* pBufferOut, nuint bufferCap);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern sbyte* ma_channel_position_to_string(byte channel);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ulong ma_convert_frames(void* pOut, ulong frameCountOut, ma_format formatOut, uint channelsOut, uint sampleRateOut, void* pIn, ulong frameCountIn, ma_format formatIn, uint channelsIn, uint sampleRateIn);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ulong ma_convert_frames_ex(void* pOut, ulong frameCountOut, void* pIn, ulong frameCountIn, ma_data_converter_config* pConfig);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_data_source_config ma_data_source_config_init();

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_source_init(ma_data_source_config* pConfig, void* pDataSource);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_data_source_uninit(void* pDataSource);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_source_read_pcm_frames(void* pDataSource, void* pFramesOut, ulong frameCount, ulong* pFramesRead);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_source_seek_pcm_frames(void* pDataSource, ulong frameCount, ulong* pFramesSeeked);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_source_seek_to_pcm_frame(void* pDataSource, ulong frameIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_source_seek_seconds(void* pDataSource, float secondCount, float* pSecondsSeeked);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_source_seek_to_second(void* pDataSource, float seekPointInSeconds);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_source_get_data_format(void* pDataSource, ma_format* pFormat, uint* pChannels, uint* pSampleRate, byte* pChannelMap, nuint channelMapCap);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_source_get_cursor_in_pcm_frames(void* pDataSource, ulong* pCursor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_source_get_length_in_pcm_frames(void* pDataSource, ulong* pLength);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_source_get_cursor_in_seconds(void* pDataSource, float* pCursor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_source_get_length_in_seconds(void* pDataSource, float* pLength);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_source_set_looping(void* pDataSource, uint isLooping);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_data_source_is_looping(void* pDataSource);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_source_set_range_in_pcm_frames(void* pDataSource, ulong rangeBegInFrames, ulong rangeEndInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_data_source_get_range_in_pcm_frames(void* pDataSource, ulong* pRangeBegInFrames, ulong* pRangeEndInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_source_set_loop_point_in_pcm_frames(void* pDataSource, ulong loopBegInFrames, ulong loopEndInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_data_source_get_loop_point_in_pcm_frames(void* pDataSource, ulong* pLoopBegInFrames, ulong* pLoopEndInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_source_set_current(void* pDataSource, void* pCurrentDataSource);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern void* ma_data_source_get_current(void* pDataSource);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_source_set_next(void* pDataSource, void* pNextDataSource);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern void* ma_data_source_get_next(void* pDataSource);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_source_set_next_callback(void* pDataSource, delegate* unmanaged[Cdecl]<void*, void*> onGetNext);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern delegate* unmanaged[Cdecl]<void*, void*> ma_data_source_get_next_callback(void* pDataSource);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_audio_buffer_ref_init(ma_format format, uint channels, void* pData, ulong sizeInFrames, ma_audio_buffer_ref* pAudioBufferRef);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_audio_buffer_ref_uninit(ma_audio_buffer_ref* pAudioBufferRef);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_audio_buffer_ref_set_data(ma_audio_buffer_ref* pAudioBufferRef, void* pData, ulong sizeInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ulong ma_audio_buffer_ref_read_pcm_frames(ma_audio_buffer_ref* pAudioBufferRef, void* pFramesOut, ulong frameCount, uint loop);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_audio_buffer_ref_seek_to_pcm_frame(ma_audio_buffer_ref* pAudioBufferRef, ulong frameIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_audio_buffer_ref_map(ma_audio_buffer_ref* pAudioBufferRef, void** ppFramesOut, ulong* pFrameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_audio_buffer_ref_unmap(ma_audio_buffer_ref* pAudioBufferRef, ulong frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_audio_buffer_ref_at_end(ma_audio_buffer_ref* pAudioBufferRef);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_audio_buffer_ref_get_cursor_in_pcm_frames(ma_audio_buffer_ref* pAudioBufferRef, ulong* pCursor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_audio_buffer_ref_get_length_in_pcm_frames(ma_audio_buffer_ref* pAudioBufferRef, ulong* pLength);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_audio_buffer_ref_get_available_frames(ma_audio_buffer_ref* pAudioBufferRef, ulong* pAvailableFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_audio_buffer_config ma_audio_buffer_config_init(ma_format format, uint channels, ulong sizeInFrames, void* pData, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_audio_buffer_init(ma_audio_buffer_config* pConfig, ma_audio_buffer* pAudioBuffer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_audio_buffer_init_copy(ma_audio_buffer_config* pConfig, ma_audio_buffer* pAudioBuffer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_audio_buffer_alloc_and_init(ma_audio_buffer_config* pConfig, ma_audio_buffer** ppAudioBuffer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_audio_buffer_uninit(ma_audio_buffer* pAudioBuffer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_audio_buffer_uninit_and_free(ma_audio_buffer* pAudioBuffer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ulong ma_audio_buffer_read_pcm_frames(ma_audio_buffer* pAudioBuffer, void* pFramesOut, ulong frameCount, uint loop);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_audio_buffer_seek_to_pcm_frame(ma_audio_buffer* pAudioBuffer, ulong frameIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_audio_buffer_map(ma_audio_buffer* pAudioBuffer, void** ppFramesOut, ulong* pFrameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_audio_buffer_unmap(ma_audio_buffer* pAudioBuffer, ulong frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_audio_buffer_at_end(ma_audio_buffer* pAudioBuffer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_audio_buffer_get_cursor_in_pcm_frames(ma_audio_buffer* pAudioBuffer, ulong* pCursor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_audio_buffer_get_length_in_pcm_frames(ma_audio_buffer* pAudioBuffer, ulong* pLength);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_audio_buffer_get_available_frames(ma_audio_buffer* pAudioBuffer, ulong* pAvailableFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_paged_audio_buffer_data_init(ma_format format, uint channels, ma_paged_audio_buffer_data* pData);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_paged_audio_buffer_data_uninit(ma_paged_audio_buffer_data* pData, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_paged_audio_buffer_page* ma_paged_audio_buffer_data_get_head(ma_paged_audio_buffer_data* pData);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_paged_audio_buffer_page* ma_paged_audio_buffer_data_get_tail(ma_paged_audio_buffer_data* pData);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_paged_audio_buffer_data_get_length_in_pcm_frames(ma_paged_audio_buffer_data* pData, ulong* pLength);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_paged_audio_buffer_data_allocate_page(ma_paged_audio_buffer_data* pData, ulong pageSizeInFrames, void* pInitialData, ma_allocation_callbacks* pAllocationCallbacks, ma_paged_audio_buffer_page** ppPage);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_paged_audio_buffer_data_free_page(ma_paged_audio_buffer_data* pData, ma_paged_audio_buffer_page* pPage, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_paged_audio_buffer_data_append_page(ma_paged_audio_buffer_data* pData, ma_paged_audio_buffer_page* pPage);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_paged_audio_buffer_data_allocate_and_append_page(ma_paged_audio_buffer_data* pData, uint pageSizeInFrames, void* pInitialData, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_paged_audio_buffer_config ma_paged_audio_buffer_config_init(ma_paged_audio_buffer_data* pData);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_paged_audio_buffer_init(ma_paged_audio_buffer_config* pConfig, ma_paged_audio_buffer* pPagedAudioBuffer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_paged_audio_buffer_uninit(ma_paged_audio_buffer* pPagedAudioBuffer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_paged_audio_buffer_read_pcm_frames(ma_paged_audio_buffer* pPagedAudioBuffer, void* pFramesOut, ulong frameCount, ulong* pFramesRead);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_paged_audio_buffer_seek_to_pcm_frame(ma_paged_audio_buffer* pPagedAudioBuffer, ulong frameIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_paged_audio_buffer_get_cursor_in_pcm_frames(ma_paged_audio_buffer* pPagedAudioBuffer, ulong* pCursor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_paged_audio_buffer_get_length_in_pcm_frames(ma_paged_audio_buffer* pPagedAudioBuffer, ulong* pLength);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_rb_init_ex(nuint subbufferSizeInBytes, nuint subbufferCount, nuint subbufferStrideInBytes, void* pOptionalPreallocatedBuffer, ma_allocation_callbacks* pAllocationCallbacks, ma_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_rb_init(nuint bufferSizeInBytes, void* pOptionalPreallocatedBuffer, ma_allocation_callbacks* pAllocationCallbacks, ma_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_rb_uninit(ma_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_rb_reset(ma_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_rb_acquire_read(ma_rb* pRB, nuint* pSizeInBytes, void** ppBufferOut);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_rb_commit_read(ma_rb* pRB, nuint sizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_rb_acquire_write(ma_rb* pRB, nuint* pSizeInBytes, void** ppBufferOut);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_rb_commit_write(ma_rb* pRB, nuint sizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_rb_seek_read(ma_rb* pRB, nuint offsetInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_rb_seek_write(ma_rb* pRB, nuint offsetInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern int ma_rb_pointer_distance(ma_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_rb_available_read(ma_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_rb_available_write(ma_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern nuint ma_rb_get_subbuffer_size(ma_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern nuint ma_rb_get_subbuffer_stride(ma_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern nuint ma_rb_get_subbuffer_offset(ma_rb* pRB, nuint subbufferIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* ma_rb_get_subbuffer_ptr(ma_rb* pRB, nuint subbufferIndex, void* pBuffer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_pcm_rb_init_ex(ma_format format, uint channels, uint subbufferSizeInFrames, uint subbufferCount, uint subbufferStrideInFrames, void* pOptionalPreallocatedBuffer, ma_allocation_callbacks* pAllocationCallbacks, ma_pcm_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_pcm_rb_init(ma_format format, uint channels, uint bufferSizeInFrames, void* pOptionalPreallocatedBuffer, ma_allocation_callbacks* pAllocationCallbacks, ma_pcm_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_rb_uninit(ma_pcm_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_rb_reset(ma_pcm_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_pcm_rb_acquire_read(ma_pcm_rb* pRB, uint* pSizeInFrames, void** ppBufferOut);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_pcm_rb_commit_read(ma_pcm_rb* pRB, uint sizeInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_pcm_rb_acquire_write(ma_pcm_rb* pRB, uint* pSizeInFrames, void** ppBufferOut);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_pcm_rb_commit_write(ma_pcm_rb* pRB, uint sizeInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_pcm_rb_seek_read(ma_pcm_rb* pRB, uint offsetInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_pcm_rb_seek_write(ma_pcm_rb* pRB, uint offsetInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern int ma_pcm_rb_pointer_distance(ma_pcm_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_pcm_rb_available_read(ma_pcm_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_pcm_rb_available_write(ma_pcm_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_pcm_rb_get_subbuffer_size(ma_pcm_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_pcm_rb_get_subbuffer_stride(ma_pcm_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_pcm_rb_get_subbuffer_offset(ma_pcm_rb* pRB, uint subbufferIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* ma_pcm_rb_get_subbuffer_ptr(ma_pcm_rb* pRB, uint subbufferIndex, void* pBuffer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_format ma_pcm_rb_get_format(ma_pcm_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_pcm_rb_get_channels(ma_pcm_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_pcm_rb_get_sample_rate(ma_pcm_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pcm_rb_set_sample_rate(ma_pcm_rb* pRB, uint sampleRate);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_duplex_rb_init(ma_format captureFormat, uint captureChannels, uint sampleRate, uint captureInternalSampleRate, uint captureInternalPeriodSizeInFrames, ma_allocation_callbacks* pAllocationCallbacks, ma_duplex_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_duplex_rb_uninit(ma_duplex_rb* pRB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern sbyte* ma_result_description(ma_result result);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* ma_malloc(nuint sz, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* ma_calloc(nuint sz, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* ma_realloc(void* p, nuint sz, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_free(void* p, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* ma_aligned_malloc(nuint sz, nuint alignment, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_aligned_free(void* p, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern sbyte* ma_get_format_name(ma_format format);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_blend_f32(float* pOut, float* pInA, float* pInB, float factor, uint channels);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_get_bytes_per_sample(ma_format format);


        public static uint ma_get_bytes_per_frame(ma_format format, uint channels)
        {
            return ma_get_bytes_per_sample(format) * channels;
        }

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern sbyte* ma_log_level_to_string(uint logLevel);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_spinlock_lock(uint* pSpinlock);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_spinlock_lock_noyield(uint* pSpinlock);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_spinlock_unlock(uint* pSpinlock);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_mutex_init(IntPtr* pMutex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_mutex_uninit(IntPtr* pMutex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_mutex_lock(IntPtr* pMutex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_mutex_unlock(IntPtr* pMutex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_event_init(ma_event* pEvent);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_event_uninit(ma_event* pEvent);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_event_wait(ma_event* pEvent);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_event_signal(ma_event* pEvent);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_semaphore_init(int initialValue, ma_semaphore* pSemaphore);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_semaphore_uninit(ma_semaphore* pSemaphore);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_semaphore_wait(ma_semaphore* pSemaphore);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_semaphore_release(ma_semaphore* pSemaphore);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_fence_init(ma_fence* pFence);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_fence_uninit(ma_fence* pFence);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_fence_acquire(ma_fence* pFence);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_fence_release(ma_fence* pFence);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_fence_wait(ma_fence* pFence);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_async_notification_signal(void* pNotification);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_async_notification_poll_init(ma_async_notification_poll* pNotificationPoll);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_async_notification_poll_is_signalled(ma_async_notification_poll* pNotificationPoll);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_async_notification_event_init(ma_async_notification_event* pNotificationEvent);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_async_notification_event_uninit(ma_async_notification_event* pNotificationEvent);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_async_notification_event_wait(ma_async_notification_event* pNotificationEvent);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_async_notification_event_signal(ma_async_notification_event* pNotificationEvent);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_slot_allocator_config ma_slot_allocator_config_init(uint capacity);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_slot_allocator_get_heap_size(ma_slot_allocator_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_slot_allocator_init_preallocated(ma_slot_allocator_config* pConfig, void* pHeap, ma_slot_allocator* pAllocator);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_slot_allocator_init(ma_slot_allocator_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_slot_allocator* pAllocator);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_slot_allocator_uninit(ma_slot_allocator* pAllocator, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_slot_allocator_alloc(ma_slot_allocator* pAllocator, ulong* pSlot);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_slot_allocator_free(ma_slot_allocator* pAllocator, ulong slot);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_job ma_job_init(ushort code);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_job_process(ma_job* pJob);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_job_queue_config ma_job_queue_config_init(uint flags, uint capacity);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_job_queue_get_heap_size(ma_job_queue_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_job_queue_init_preallocated(ma_job_queue_config* pConfig, void* pHeap, ma_job_queue* pQueue);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_job_queue_init(ma_job_queue_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_job_queue* pQueue);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_job_queue_uninit(ma_job_queue* pQueue, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_job_queue_post(ma_job_queue* pQueue, ma_job* pJob);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_job_queue_next(ma_job_queue* pQueue, ma_job* pJob);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_device_job_thread_config ma_device_job_thread_config_init();

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_device_job_thread_init(ma_device_job_thread_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_device_job_thread* pJobThread);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_device_job_thread_uninit(ma_device_job_thread* pJobThread, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_device_job_thread_post(ma_device_job_thread* pJobThread, ma_job* pJob);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_device_job_thread_next(ma_device_job_thread* pJobThread, ma_job* pJob);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_device_id_equal(ma_device_id* pA, ma_device_id* pB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_context_config ma_context_config_init();

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_context_init(ma_backend* backends, uint backendCount, ma_context_config* pConfig, ma_context* pContext);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_context_uninit(ma_context* pContext);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern nuint ma_context_sizeof();

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_log* ma_context_get_log(ma_context* pContext);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_context_enumerate_devices(ma_context* pContext, delegate* unmanaged[Cdecl]<ma_context*, ma_device_type, ma_device_info*, void*, uint> callback, void* pUserData);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_context_get_devices(ma_context* pContext, ma_device_info** ppPlaybackDeviceInfos, uint* pPlaybackDeviceCount, ma_device_info** ppCaptureDeviceInfos, uint* pCaptureDeviceCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_context_get_device_info(ma_context* pContext, ma_device_type deviceType, ma_device_id* pDeviceID, ma_device_info* pDeviceInfo);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_context_is_loopback_supported(ma_context* pContext);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_device_config ma_device_config_init(ma_device_type deviceType);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_device_init(ma_context* pContext, ma_device_config* pConfig, ma_device* pDevice);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_device_init_ex(ma_backend* backends, uint backendCount, ma_context_config* pContextConfig, ma_device_config* pConfig, ma_device* pDevice);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_device_uninit(ma_device* pDevice);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_context* ma_device_get_context(ma_device* pDevice);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_log* ma_device_get_log(ma_device* pDevice);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_device_get_info(ma_device* pDevice, ma_device_type type, ma_device_info* pDeviceInfo);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_device_get_name(ma_device* pDevice, ma_device_type type, sbyte* pName, nuint nameCap, nuint* pLengthNotIncludingNullTerminator);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_device_start(ma_device* pDevice);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_device_stop(ma_device* pDevice);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_device_is_started(ma_device* pDevice);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_device_state ma_device_get_state(ma_device* pDevice);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_device_post_init(ma_device* pDevice, ma_device_type deviceType, ma_device_descriptor* pPlaybackDescriptor, ma_device_descriptor* pCaptureDescriptor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_device_set_master_volume(ma_device* pDevice, float volume);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_device_get_master_volume(ma_device* pDevice, float* pVolume);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_device_set_master_volume_db(ma_device* pDevice, float gainDB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_device_get_master_volume_db(ma_device* pDevice, float* pGainDB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_device_handle_backend_data_callback(ma_device* pDevice, void* pOutput, void* pInput, uint frameCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_calculate_buffer_size_in_frames_from_descriptor(ma_device_descriptor* pDescriptor, uint nativeSampleRate, ma_performance_profile performanceProfile);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern sbyte* ma_get_backend_name(ma_backend backend);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_get_backend_from_name(sbyte* pBackendName, ma_backend* pBackend);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_is_backend_enabled(ma_backend backend);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_get_enabled_backends(ma_backend* pBackends, nuint backendCap, nuint* pBackendCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_is_loopback_supported(ma_backend backend);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_calculate_buffer_size_in_milliseconds_from_frames(uint bufferSizeInFrames, uint sampleRate);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_calculate_buffer_size_in_frames_from_milliseconds(uint bufferSizeInMilliseconds, uint sampleRate);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_copy_pcm_frames(void* dst, void* src, ulong frameCount, ma_format format, uint channels);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_silence_pcm_frames(void* p, ulong frameCount, ma_format format, uint channels);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* ma_offset_pcm_frames_ptr(void* p, ulong offsetInFrames, ma_format format, uint channels);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern void* ma_offset_pcm_frames_const_ptr(void* p, ulong offsetInFrames, ma_format format, uint channels);

        public static float* ma_offset_pcm_frames_ptr_f32(float* p, ulong offsetInFrames, uint channels)
        {
            return (float*)(ma_offset_pcm_frames_ptr((void*)(p), offsetInFrames, ma_format_f32, channels));
        }


        public static float* ma_offset_pcm_frames_const_ptr_f32(float* p, ulong offsetInFrames, uint channels)
        {
            return (float*)(ma_offset_pcm_frames_const_ptr((void*)(p), offsetInFrames, ma_format_f32, channels));
        }

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_clip_samples_u8(byte* pDst, short* pSrc, ulong count);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_clip_samples_s16(short* pDst, int* pSrc, ulong count);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_clip_samples_s24(byte* pDst, long* pSrc, ulong count);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_clip_samples_s32(int* pDst, long* pSrc, ulong count);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_clip_samples_f32(float* pDst, float* pSrc, ulong count);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_clip_pcm_frames(void* pDst, void* pSrc, ulong frameCount, ma_format format, uint channels);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_copy_and_apply_volume_factor_u8(byte* pSamplesOut, byte* pSamplesIn, ulong sampleCount, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_copy_and_apply_volume_factor_s16(short* pSamplesOut, short* pSamplesIn, ulong sampleCount, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_copy_and_apply_volume_factor_s24(void* pSamplesOut, void* pSamplesIn, ulong sampleCount, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_copy_and_apply_volume_factor_s32(int* pSamplesOut, int* pSamplesIn, ulong sampleCount, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_copy_and_apply_volume_factor_f32(float* pSamplesOut, float* pSamplesIn, ulong sampleCount, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_apply_volume_factor_u8(byte* pSamples, ulong sampleCount, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_apply_volume_factor_s16(short* pSamples, ulong sampleCount, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_apply_volume_factor_s24(void* pSamples, ulong sampleCount, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_apply_volume_factor_s32(int* pSamples, ulong sampleCount, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_apply_volume_factor_f32(float* pSamples, ulong sampleCount, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_copy_and_apply_volume_factor_pcm_frames_u8(byte* pFramesOut, byte* pFramesIn, ulong frameCount, uint channels, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_copy_and_apply_volume_factor_pcm_frames_s16(short* pFramesOut, short* pFramesIn, ulong frameCount, uint channels, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_copy_and_apply_volume_factor_pcm_frames_s24(void* pFramesOut, void* pFramesIn, ulong frameCount, uint channels, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_copy_and_apply_volume_factor_pcm_frames_s32(int* pFramesOut, int* pFramesIn, ulong frameCount, uint channels, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_copy_and_apply_volume_factor_pcm_frames_f32(float* pFramesOut, float* pFramesIn, ulong frameCount, uint channels, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_copy_and_apply_volume_factor_pcm_frames(void* pFramesOut, void* pFramesIn, ulong frameCount, ma_format format, uint channels, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_apply_volume_factor_pcm_frames_u8(byte* pFrames, ulong frameCount, uint channels, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_apply_volume_factor_pcm_frames_s16(short* pFrames, ulong frameCount, uint channels, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_apply_volume_factor_pcm_frames_s24(void* pFrames, ulong frameCount, uint channels, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_apply_volume_factor_pcm_frames_s32(int* pFrames, ulong frameCount, uint channels, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_apply_volume_factor_pcm_frames_f32(float* pFrames, ulong frameCount, uint channels, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_apply_volume_factor_pcm_frames(void* pFrames, ulong frameCount, ma_format format, uint channels, float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_copy_and_apply_volume_factor_per_channel_f32(float* pFramesOut, float* pFramesIn, ulong frameCount, uint channels, float* pChannelGains);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_copy_and_apply_volume_and_clip_samples_u8(byte* pDst, short* pSrc, ulong count, float volume);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_copy_and_apply_volume_and_clip_samples_s16(short* pDst, int* pSrc, ulong count, float volume);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_copy_and_apply_volume_and_clip_samples_s24(byte* pDst, long* pSrc, ulong count, float volume);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_copy_and_apply_volume_and_clip_samples_s32(int* pDst, long* pSrc, ulong count, float volume);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_copy_and_apply_volume_and_clip_samples_f32(float* pDst, float* pSrc, ulong count, float volume);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_copy_and_apply_volume_and_clip_pcm_frames(void* pDst, void* pSrc, ulong frameCount, ma_format format, uint channels, float volume);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_volume_linear_to_db(float factor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_volume_db_to_linear(float gain);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_mix_pcm_frames_f32(float* pDst, float* pSrc, ulong frameCount, uint channels, float volume);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_vfs_open(void* pVFS, sbyte* pFilePath, uint openMode, void** pFile);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_vfs_open_w(void* pVFS, uint* pFilePath, uint openMode, void** pFile);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_vfs_close(void* pVFS, void* file);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_vfs_read(void* pVFS, void* file, void* pDst, nuint sizeInBytes, nuint* pBytesRead);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_vfs_write(void* pVFS, void* file, void* pSrc, nuint sizeInBytes, nuint* pBytesWritten);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_vfs_seek(void* pVFS, void* file, long offset, ma_seek_origin origin);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_vfs_tell(void* pVFS, void* file, long* pCursor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_vfs_info(void* pVFS, void* file, ma_file_info* pInfo);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_vfs_open_and_read_file(void* pVFS, sbyte* pFilePath, void** ppData, nuint* pSize, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_default_vfs_init(ma_default_vfs* pVFS, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_decoding_backend_config ma_decoding_backend_config_init(ma_format preferredFormat, uint seekPointCount);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_decoder_config ma_decoder_config_init(ma_format outputFormat, uint outputChannels, uint outputSampleRate);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_decoder_config ma_decoder_config_init_default();

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_decoder_init(delegate* unmanaged[Cdecl]<ma_decoder*, void*, nuint, nuint*, ma_result> onRead, delegate* unmanaged[Cdecl]<ma_decoder*, long, ma_seek_origin, ma_result> onSeek, void* pUserData, ma_decoder_config* pConfig, ma_decoder* pDecoder);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_decoder_init_memory(void* pData, nuint dataSize, ma_decoder_config* pConfig, ma_decoder* pDecoder);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_decoder_init_vfs(void* pVFS, sbyte* pFilePath, ma_decoder_config* pConfig, ma_decoder* pDecoder);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_decoder_init_vfs_w(void* pVFS, uint* pFilePath, ma_decoder_config* pConfig, ma_decoder* pDecoder);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_decoder_init_file(sbyte* pFilePath, ma_decoder_config* pConfig, ma_decoder* pDecoder);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_decoder_init_file_w(uint* pFilePath, ma_decoder_config* pConfig, ma_decoder* pDecoder);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_decoder_uninit(ma_decoder* pDecoder);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_decoder_read_pcm_frames(ma_decoder* pDecoder, void* pFramesOut, ulong frameCount, ulong* pFramesRead);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_decoder_seek_to_pcm_frame(ma_decoder* pDecoder, ulong frameIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_decoder_get_data_format(ma_decoder* pDecoder, ma_format* pFormat, uint* pChannels, uint* pSampleRate, byte* pChannelMap, nuint channelMapCap);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_decoder_get_cursor_in_pcm_frames(ma_decoder* pDecoder, ulong* pCursor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_decoder_get_length_in_pcm_frames(ma_decoder* pDecoder, ulong* pLength);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_decoder_get_available_frames(ma_decoder* pDecoder, ulong* pAvailableFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_decode_from_vfs(void* pVFS, sbyte* pFilePath, ma_decoder_config* pConfig, ulong* pFrameCountOut, void** ppPCMFramesOut);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_decode_file(sbyte* pFilePath, ma_decoder_config* pConfig, ulong* pFrameCountOut, void** ppPCMFramesOut);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_decode_memory(void* pData, nuint dataSize, ma_decoder_config* pConfig, ulong* pFrameCountOut, void** ppPCMFramesOut);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_encoder_config ma_encoder_config_init(ma_encoding_format encodingFormat, ma_format format, uint channels, uint sampleRate);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_encoder_init(delegate* unmanaged[Cdecl]<ma_encoder*, void*, nuint, nuint*, ma_result> onWrite, delegate* unmanaged[Cdecl]<ma_encoder*, long, ma_seek_origin, ma_result> onSeek, void* pUserData, ma_encoder_config* pConfig, ma_encoder* pEncoder);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_encoder_init_vfs(void* pVFS, sbyte* pFilePath, ma_encoder_config* pConfig, ma_encoder* pEncoder);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_encoder_init_vfs_w(void* pVFS, uint* pFilePath, ma_encoder_config* pConfig, ma_encoder* pEncoder);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_encoder_init_file(sbyte* pFilePath, ma_encoder_config* pConfig, ma_encoder* pEncoder);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_encoder_init_file_w(uint* pFilePath, ma_encoder_config* pConfig, ma_encoder* pEncoder);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_encoder_uninit(ma_encoder* pEncoder);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_encoder_write_pcm_frames(ma_encoder* pEncoder, void* pFramesIn, ulong frameCount, ulong* pFramesWritten);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_waveform_config ma_waveform_config_init(ma_format format, uint channels, uint sampleRate, ma_waveform_type type, double amplitude, double frequency);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_waveform_init(ma_waveform_config* pConfig, ma_waveform* pWaveform);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_waveform_uninit(ma_waveform* pWaveform);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_waveform_read_pcm_frames(ma_waveform* pWaveform, void* pFramesOut, ulong frameCount, ulong* pFramesRead);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_waveform_seek_to_pcm_frame(ma_waveform* pWaveform, ulong frameIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_waveform_set_amplitude(ma_waveform* pWaveform, double amplitude);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_waveform_set_frequency(ma_waveform* pWaveform, double frequency);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_waveform_set_type(ma_waveform* pWaveform, ma_waveform_type type);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_waveform_set_sample_rate(ma_waveform* pWaveform, uint sampleRate);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_pulsewave_config ma_pulsewave_config_init(ma_format format, uint channels, uint sampleRate, double dutyCycle, double amplitude, double frequency);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_pulsewave_init(ma_pulsewave_config* pConfig, ma_pulsewave* pWaveform);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_pulsewave_uninit(ma_pulsewave* pWaveform);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_pulsewave_read_pcm_frames(ma_pulsewave* pWaveform, void* pFramesOut, ulong frameCount, ulong* pFramesRead);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_pulsewave_seek_to_pcm_frame(ma_pulsewave* pWaveform, ulong frameIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_pulsewave_set_amplitude(ma_pulsewave* pWaveform, double amplitude);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_pulsewave_set_frequency(ma_pulsewave* pWaveform, double frequency);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_pulsewave_set_sample_rate(ma_pulsewave* pWaveform, uint sampleRate);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_pulsewave_set_duty_cycle(ma_pulsewave* pWaveform, double dutyCycle);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_noise_config ma_noise_config_init(ma_format format, uint channels, ma_noise_type type, int seed, double amplitude);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_noise_get_heap_size(ma_noise_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_noise_init_preallocated(ma_noise_config* pConfig, void* pHeap, ma_noise* pNoise);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_noise_init(ma_noise_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_noise* pNoise);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_noise_uninit(ma_noise* pNoise, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_noise_read_pcm_frames(ma_noise* pNoise, void* pFramesOut, ulong frameCount, ulong* pFramesRead);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_noise_set_amplitude(ma_noise* pNoise, double amplitude);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_noise_set_seed(ma_noise* pNoise, int seed);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_noise_set_type(ma_noise* pNoise, ma_noise_type type);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_resource_manager_pipeline_notifications ma_resource_manager_pipeline_notifications_init();

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_resource_manager_data_source_config ma_resource_manager_data_source_config_init();

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_resource_manager_config ma_resource_manager_config_init();

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_init(ma_resource_manager_config* pConfig, ma_resource_manager* pResourceManager);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_resource_manager_uninit(ma_resource_manager* pResourceManager);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_log* ma_resource_manager_get_log(ma_resource_manager* pResourceManager);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_register_file(ma_resource_manager* pResourceManager, sbyte* pFilePath, uint flags);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_register_file_w(ma_resource_manager* pResourceManager, uint* pFilePath, uint flags);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_register_decoded_data(ma_resource_manager* pResourceManager, sbyte* pName, void* pData, ulong frameCount, ma_format format, uint channels, uint sampleRate);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_register_decoded_data_w(ma_resource_manager* pResourceManager, uint* pName, void* pData, ulong frameCount, ma_format format, uint channels, uint sampleRate);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_register_encoded_data(ma_resource_manager* pResourceManager, sbyte* pName, void* pData, nuint sizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_register_encoded_data_w(ma_resource_manager* pResourceManager, uint* pName, void* pData, nuint sizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_unregister_file(ma_resource_manager* pResourceManager, sbyte* pFilePath);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_unregister_file_w(ma_resource_manager* pResourceManager, uint* pFilePath);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_unregister_data(ma_resource_manager* pResourceManager, sbyte* pName);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_unregister_data_w(ma_resource_manager* pResourceManager, uint* pName);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_buffer_init_ex(ma_resource_manager* pResourceManager, ma_resource_manager_data_source_config* pConfig, ma_resource_manager_data_buffer* pDataBuffer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_buffer_init(ma_resource_manager* pResourceManager, sbyte* pFilePath, uint flags, ma_resource_manager_pipeline_notifications* pNotifications, ma_resource_manager_data_buffer* pDataBuffer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_buffer_init_w(ma_resource_manager* pResourceManager, uint* pFilePath, uint flags, ma_resource_manager_pipeline_notifications* pNotifications, ma_resource_manager_data_buffer* pDataBuffer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_buffer_init_copy(ma_resource_manager* pResourceManager, ma_resource_manager_data_buffer* pExistingDataBuffer, ma_resource_manager_data_buffer* pDataBuffer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_buffer_uninit(ma_resource_manager_data_buffer* pDataBuffer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_buffer_read_pcm_frames(ma_resource_manager_data_buffer* pDataBuffer, void* pFramesOut, ulong frameCount, ulong* pFramesRead);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_buffer_seek_to_pcm_frame(ma_resource_manager_data_buffer* pDataBuffer, ulong frameIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_buffer_get_data_format(ma_resource_manager_data_buffer* pDataBuffer, ma_format* pFormat, uint* pChannels, uint* pSampleRate, byte* pChannelMap, nuint channelMapCap);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_buffer_get_cursor_in_pcm_frames(ma_resource_manager_data_buffer* pDataBuffer, ulong* pCursor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_buffer_get_length_in_pcm_frames(ma_resource_manager_data_buffer* pDataBuffer, ulong* pLength);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_buffer_result(ma_resource_manager_data_buffer* pDataBuffer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_buffer_set_looping(ma_resource_manager_data_buffer* pDataBuffer, uint isLooping);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_resource_manager_data_buffer_is_looping(ma_resource_manager_data_buffer* pDataBuffer);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_buffer_get_available_frames(ma_resource_manager_data_buffer* pDataBuffer, ulong* pAvailableFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_stream_init_ex(ma_resource_manager* pResourceManager, ma_resource_manager_data_source_config* pConfig, ma_resource_manager_data_stream* pDataStream);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_stream_init(ma_resource_manager* pResourceManager, sbyte* pFilePath, uint flags, ma_resource_manager_pipeline_notifications* pNotifications, ma_resource_manager_data_stream* pDataStream);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_stream_init_w(ma_resource_manager* pResourceManager, uint* pFilePath, uint flags, ma_resource_manager_pipeline_notifications* pNotifications, ma_resource_manager_data_stream* pDataStream);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_stream_uninit(ma_resource_manager_data_stream* pDataStream);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_stream_read_pcm_frames(ma_resource_manager_data_stream* pDataStream, void* pFramesOut, ulong frameCount, ulong* pFramesRead);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_stream_seek_to_pcm_frame(ma_resource_manager_data_stream* pDataStream, ulong frameIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_stream_get_data_format(ma_resource_manager_data_stream* pDataStream, ma_format* pFormat, uint* pChannels, uint* pSampleRate, byte* pChannelMap, nuint channelMapCap);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_stream_get_cursor_in_pcm_frames(ma_resource_manager_data_stream* pDataStream, ulong* pCursor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_stream_get_length_in_pcm_frames(ma_resource_manager_data_stream* pDataStream, ulong* pLength);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_stream_result(ma_resource_manager_data_stream* pDataStream);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_stream_set_looping(ma_resource_manager_data_stream* pDataStream, uint isLooping);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_resource_manager_data_stream_is_looping(ma_resource_manager_data_stream* pDataStream);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_stream_get_available_frames(ma_resource_manager_data_stream* pDataStream, ulong* pAvailableFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_source_init_ex(ma_resource_manager* pResourceManager, ma_resource_manager_data_source_config* pConfig, ma_resource_manager_data_source* pDataSource);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_source_init(ma_resource_manager* pResourceManager, sbyte* pName, uint flags, ma_resource_manager_pipeline_notifications* pNotifications, ma_resource_manager_data_source* pDataSource);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_source_init_w(ma_resource_manager* pResourceManager, uint* pName, uint flags, ma_resource_manager_pipeline_notifications* pNotifications, ma_resource_manager_data_source* pDataSource);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_source_init_copy(ma_resource_manager* pResourceManager, ma_resource_manager_data_source* pExistingDataSource, ma_resource_manager_data_source* pDataSource);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_source_uninit(ma_resource_manager_data_source* pDataSource);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_source_read_pcm_frames(ma_resource_manager_data_source* pDataSource, void* pFramesOut, ulong frameCount, ulong* pFramesRead);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_source_seek_to_pcm_frame(ma_resource_manager_data_source* pDataSource, ulong frameIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_source_get_data_format(ma_resource_manager_data_source* pDataSource, ma_format* pFormat, uint* pChannels, uint* pSampleRate, byte* pChannelMap, nuint channelMapCap);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_source_get_cursor_in_pcm_frames(ma_resource_manager_data_source* pDataSource, ulong* pCursor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_source_get_length_in_pcm_frames(ma_resource_manager_data_source* pDataSource, ulong* pLength);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_source_result(ma_resource_manager_data_source* pDataSource);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_source_set_looping(ma_resource_manager_data_source* pDataSource, uint isLooping);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_resource_manager_data_source_is_looping(ma_resource_manager_data_source* pDataSource);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_data_source_get_available_frames(ma_resource_manager_data_source* pDataSource, ulong* pAvailableFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_post_job(ma_resource_manager* pResourceManager, ma_job* pJob);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_post_job_quit(ma_resource_manager* pResourceManager);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_next_job(ma_resource_manager* pResourceManager, ma_job* pJob);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_process_job(ma_resource_manager* pResourceManager, ma_job* pJob);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_resource_manager_process_next_job(ma_resource_manager* pResourceManager);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_node_config ma_node_config_init();

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_node_get_heap_size(ma_node_graph* pNodeGraph, ma_node_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_node_init_preallocated(ma_node_graph* pNodeGraph, ma_node_config* pConfig, void* pHeap, void* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_node_init(ma_node_graph* pNodeGraph, ma_node_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, void* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_node_uninit(void* pNode, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_node_graph* ma_node_get_node_graph(void* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_node_get_input_bus_count(void* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_node_get_output_bus_count(void* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_node_get_input_channels(void* pNode, uint inputBusIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_node_get_output_channels(void* pNode, uint outputBusIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_node_attach_output_bus(void* pNode, uint outputBusIndex, void* pOtherNode, uint otherNodeInputBusIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_node_detach_output_bus(void* pNode, uint outputBusIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_node_detach_all_output_buses(void* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_node_set_output_bus_volume(void* pNode, uint outputBusIndex, float volume);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_node_get_output_bus_volume(void* pNode, uint outputBusIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_node_set_state(void* pNode, ma_node_state state);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_node_state ma_node_get_state(void* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_node_set_state_time(void* pNode, ma_node_state state, ulong globalTime);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ulong ma_node_get_state_time(void* pNode, ma_node_state state);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_node_state ma_node_get_state_by_time(void* pNode, ulong globalTime);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_node_state ma_node_get_state_by_time_range(void* pNode, ulong globalTimeBeg, ulong globalTimeEnd);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ulong ma_node_get_time(void* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_node_set_time(void* pNode, ulong localTime);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_node_graph_config ma_node_graph_config_init(uint channels);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_node_graph_init(ma_node_graph_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_node_graph* pNodeGraph);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_node_graph_uninit(ma_node_graph* pNodeGraph, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern void* ma_node_graph_get_endpoint(ma_node_graph* pNodeGraph);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_node_graph_read_pcm_frames(ma_node_graph* pNodeGraph, void* pFramesOut, ulong frameCount, ulong* pFramesRead);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_node_graph_get_channels(ma_node_graph* pNodeGraph);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ulong ma_node_graph_get_time(ma_node_graph* pNodeGraph);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_node_graph_set_time(ma_node_graph* pNodeGraph, ulong globalTime);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_node_graph_get_processing_size_in_frames(ma_node_graph* pNodeGraph);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_data_source_node_config ma_data_source_node_config_init(void* pDataSource);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_source_node_init(ma_node_graph* pNodeGraph, ma_data_source_node_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_data_source_node* pDataSourceNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_data_source_node_uninit(ma_data_source_node* pDataSourceNode, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_data_source_node_set_looping(ma_data_source_node* pDataSourceNode, uint isLooping);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_data_source_node_is_looping(ma_data_source_node* pDataSourceNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_splitter_node_config ma_splitter_node_config_init(uint channels);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_splitter_node_init(ma_node_graph* pNodeGraph, ma_splitter_node_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_splitter_node* pSplitterNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_splitter_node_uninit(ma_splitter_node* pSplitterNode, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_biquad_node_config ma_biquad_node_config_init(uint channels, float b0, float b1, float b2, float a0, float a1, float a2);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_biquad_node_init(ma_node_graph* pNodeGraph, ma_biquad_node_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_biquad_node* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_biquad_node_reinit(ma_biquad_config* pConfig, ma_biquad_node* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_biquad_node_uninit(ma_biquad_node* pNode, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_lpf_node_config ma_lpf_node_config_init(uint channels, uint sampleRate, double cutoffFrequency, uint order);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_lpf_node_init(ma_node_graph* pNodeGraph, ma_lpf_node_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_lpf_node* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_lpf_node_reinit(ma_lpf_config* pConfig, ma_lpf_node* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_lpf_node_uninit(ma_lpf_node* pNode, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_hpf_node_config ma_hpf_node_config_init(uint channels, uint sampleRate, double cutoffFrequency, uint order);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hpf_node_init(ma_node_graph* pNodeGraph, ma_hpf_node_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_hpf_node* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hpf_node_reinit(ma_hpf_config* pConfig, ma_hpf_node* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_hpf_node_uninit(ma_hpf_node* pNode, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_bpf_node_config ma_bpf_node_config_init(uint channels, uint sampleRate, double cutoffFrequency, uint order);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_bpf_node_init(ma_node_graph* pNodeGraph, ma_bpf_node_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_bpf_node* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_bpf_node_reinit(ma_bpf_config* pConfig, ma_bpf_node* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_bpf_node_uninit(ma_bpf_node* pNode, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_notch_node_config ma_notch_node_config_init(uint channels, uint sampleRate, double q, double frequency);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_notch_node_init(ma_node_graph* pNodeGraph, ma_notch_node_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_notch_node* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_notch_node_reinit(ma_notch2_config* pConfig, ma_notch_node* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_notch_node_uninit(ma_notch_node* pNode, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_peak_node_config ma_peak_node_config_init(uint channels, uint sampleRate, double gainDB, double q, double frequency);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_peak_node_init(ma_node_graph* pNodeGraph, ma_peak_node_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_peak_node* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_peak_node_reinit(ma_peak2_config* pConfig, ma_peak_node* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_peak_node_uninit(ma_peak_node* pNode, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_loshelf_node_config ma_loshelf_node_config_init(uint channels, uint sampleRate, double gainDB, double q, double frequency);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_loshelf_node_init(ma_node_graph* pNodeGraph, ma_loshelf_node_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_loshelf_node* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_loshelf_node_reinit(ma_loshelf2_config* pConfig, ma_loshelf_node* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_loshelf_node_uninit(ma_loshelf_node* pNode, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_hishelf_node_config ma_hishelf_node_config_init(uint channels, uint sampleRate, double gainDB, double q, double frequency);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hishelf_node_init(ma_node_graph* pNodeGraph, ma_hishelf_node_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_hishelf_node* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_hishelf_node_reinit(ma_hishelf2_config* pConfig, ma_hishelf_node* pNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_hishelf_node_uninit(ma_hishelf_node* pNode, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_delay_node_config ma_delay_node_config_init(uint channels, uint sampleRate, uint delayInFrames, float decay);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_delay_node_init(ma_node_graph* pNodeGraph, ma_delay_node_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_delay_node* pDelayNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_delay_node_uninit(ma_delay_node* pDelayNode, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_delay_node_set_wet(ma_delay_node* pDelayNode, float value);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_delay_node_get_wet(ma_delay_node* pDelayNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_delay_node_set_dry(ma_delay_node* pDelayNode, float value);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_delay_node_get_dry(ma_delay_node* pDelayNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_delay_node_set_decay(ma_delay_node* pDelayNode, float value);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_delay_node_get_decay(ma_delay_node* pDelayNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_engine_node_config ma_engine_node_config_init(ma_engine* pEngine, ma_engine_node_type type, uint flags);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_engine_node_get_heap_size(ma_engine_node_config* pConfig, nuint* pHeapSizeInBytes);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_engine_node_init_preallocated(ma_engine_node_config* pConfig, void* pHeap, ma_engine_node* pEngineNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_engine_node_init(ma_engine_node_config* pConfig, ma_allocation_callbacks* pAllocationCallbacks, ma_engine_node* pEngineNode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_engine_node_uninit(ma_engine_node* pEngineNode, ma_allocation_callbacks* pAllocationCallbacks);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_sound_config ma_sound_config_init();

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_sound_config ma_sound_config_init_2(ma_engine* pEngine);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ma_sound_config ma_sound_group_config_init();

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ma_sound_config ma_sound_group_config_init_2(ma_engine* pEngine);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_engine_config ma_engine_config_init();

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_engine_init(ma_engine_config* pConfig, ma_engine* pEngine);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_engine_uninit(ma_engine* pEngine);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_engine_read_pcm_frames(ma_engine* pEngine, void* pFramesOut, ulong frameCount, ulong* pFramesRead);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_node_graph* ma_engine_get_node_graph(ma_engine* pEngine);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_resource_manager* ma_engine_get_resource_manager(ma_engine* pEngine);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_device* ma_engine_get_device(ma_engine* pEngine);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_log* ma_engine_get_log(ma_engine* pEngine);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern void* ma_engine_get_endpoint(ma_engine* pEngine);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ulong ma_engine_get_time_in_pcm_frames(ma_engine* pEngine);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ulong ma_engine_get_time_in_milliseconds(ma_engine* pEngine);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_engine_set_time_in_pcm_frames(ma_engine* pEngine, ulong globalTime);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_engine_set_time_in_milliseconds(ma_engine* pEngine, ulong globalTime);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ulong ma_engine_get_time(ma_engine* pEngine);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_engine_set_time(ma_engine* pEngine, ulong globalTime);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_engine_get_channels(ma_engine* pEngine);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_engine_get_sample_rate(ma_engine* pEngine);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_engine_start(ma_engine* pEngine);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_engine_stop(ma_engine* pEngine);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_engine_set_volume(ma_engine* pEngine, float volume);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_engine_get_volume(ma_engine* pEngine);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_engine_set_gain_db(ma_engine* pEngine, float gainDB);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_engine_get_gain_db(ma_engine* pEngine);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_engine_get_listener_count(ma_engine* pEngine);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_engine_find_closest_listener(ma_engine* pEngine, float absolutePosX, float absolutePosY, float absolutePosZ);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_engine_listener_set_position(ma_engine* pEngine, uint listenerIndex, float x, float y, float z);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_vec3f ma_engine_listener_get_position(ma_engine* pEngine, uint listenerIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_engine_listener_set_direction(ma_engine* pEngine, uint listenerIndex, float x, float y, float z);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_vec3f ma_engine_listener_get_direction(ma_engine* pEngine, uint listenerIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_engine_listener_set_velocity(ma_engine* pEngine, uint listenerIndex, float x, float y, float z);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_vec3f ma_engine_listener_get_velocity(ma_engine* pEngine, uint listenerIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_engine_listener_set_cone(ma_engine* pEngine, uint listenerIndex, float innerAngleInRadians, float outerAngleInRadians, float outerGain);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_engine_listener_get_cone(ma_engine* pEngine, uint listenerIndex, float* pInnerAngleInRadians, float* pOuterAngleInRadians, float* pOuterGain);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_engine_listener_set_world_up(ma_engine* pEngine, uint listenerIndex, float x, float y, float z);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_vec3f ma_engine_listener_get_world_up(ma_engine* pEngine, uint listenerIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_engine_listener_set_enabled(ma_engine* pEngine, uint listenerIndex, uint isEnabled);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_engine_listener_is_enabled(ma_engine* pEngine, uint listenerIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_engine_play_sound_ex(ma_engine* pEngine, sbyte* pFilePath, void* pNode, uint nodeInputBusIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_engine_play_sound(ma_engine* pEngine, sbyte* pFilePath, ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_init_from_file(ma_engine* pEngine, sbyte* pFilePath, uint flags, ma_sound* pGroup, ma_fence* pDoneFence, ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_init_from_file_w(ma_engine* pEngine, uint* pFilePath, uint flags, ma_sound* pGroup, ma_fence* pDoneFence, ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_init_copy(ma_engine* pEngine, ma_sound* pExistingSound, uint flags, ma_sound* pGroup, ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_init_from_data_source(ma_engine* pEngine, void* pDataSource, uint flags, ma_sound* pGroup, ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_init_ex(ma_engine* pEngine, ma_sound_config* pConfig, ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_uninit(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_engine* ma_sound_get_engine(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern void* ma_sound_get_data_source(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_start(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_stop(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_stop_with_fade_in_pcm_frames(ma_sound* pSound, ulong fadeLengthInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_stop_with_fade_in_milliseconds(ma_sound* pSound, ulong fadeLengthInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_reset_start_time(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_reset_stop_time(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_reset_fade(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_reset_stop_time_and_fade(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_volume(ma_sound* pSound, float volume);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_get_volume(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_pan(ma_sound* pSound, float pan);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_get_pan(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_pan_mode(ma_sound* pSound, ma_pan_mode panMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_pan_mode ma_sound_get_pan_mode(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_pitch(ma_sound* pSound, float pitch);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_get_pitch(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_spatialization_enabled(ma_sound* pSound, uint enabled);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_sound_is_spatialization_enabled(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_pinned_listener_index(ma_sound* pSound, uint listenerIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_sound_get_pinned_listener_index(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_sound_get_listener_index(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_vec3f ma_sound_get_direction_to_listener(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_position(ma_sound* pSound, float x, float y, float z);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_vec3f ma_sound_get_position(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_direction(ma_sound* pSound, float x, float y, float z);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_vec3f ma_sound_get_direction(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_velocity(ma_sound* pSound, float x, float y, float z);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_vec3f ma_sound_get_velocity(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_attenuation_model(ma_sound* pSound, ma_attenuation_model attenuationModel);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_attenuation_model ma_sound_get_attenuation_model(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_positioning(ma_sound* pSound, ma_positioning positioning);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_positioning ma_sound_get_positioning(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_rolloff(ma_sound* pSound, float rolloff);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_get_rolloff(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_min_gain(ma_sound* pSound, float minGain);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_get_min_gain(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_max_gain(ma_sound* pSound, float maxGain);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_get_max_gain(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_min_distance(ma_sound* pSound, float minDistance);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_get_min_distance(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_max_distance(ma_sound* pSound, float maxDistance);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_get_max_distance(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_cone(ma_sound* pSound, float innerAngleInRadians, float outerAngleInRadians, float outerGain);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_get_cone(ma_sound* pSound, float* pInnerAngleInRadians, float* pOuterAngleInRadians, float* pOuterGain);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_doppler_factor(ma_sound* pSound, float dopplerFactor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_get_doppler_factor(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_directional_attenuation_factor(ma_sound* pSound, float directionalAttenuationFactor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_get_directional_attenuation_factor(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_fade_in_pcm_frames(ma_sound* pSound, float volumeBeg, float volumeEnd, ulong fadeLengthInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_fade_in_milliseconds(ma_sound* pSound, float volumeBeg, float volumeEnd, ulong fadeLengthInMilliseconds);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_fade_start_in_pcm_frames(ma_sound* pSound, float volumeBeg, float volumeEnd, ulong fadeLengthInFrames, ulong absoluteGlobalTimeInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_fade_start_in_milliseconds(ma_sound* pSound, float volumeBeg, float volumeEnd, ulong fadeLengthInMilliseconds, ulong absoluteGlobalTimeInMilliseconds);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_get_current_fade_volume(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_start_time_in_pcm_frames(ma_sound* pSound, ulong absoluteGlobalTimeInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_start_time_in_milliseconds(ma_sound* pSound, ulong absoluteGlobalTimeInMilliseconds);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_stop_time_in_pcm_frames(ma_sound* pSound, ulong absoluteGlobalTimeInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_stop_time_in_milliseconds(ma_sound* pSound, ulong absoluteGlobalTimeInMilliseconds);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_stop_time_with_fade_in_pcm_frames(ma_sound* pSound, ulong stopAbsoluteGlobalTimeInFrames, ulong fadeLengthInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_stop_time_with_fade_in_milliseconds(ma_sound* pSound, ulong stopAbsoluteGlobalTimeInMilliseconds, ulong fadeLengthInMilliseconds);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_sound_is_playing(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ulong ma_sound_get_time_in_pcm_frames(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ulong ma_sound_get_time_in_milliseconds(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_set_looping(ma_sound* pSound, uint isLooping);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_sound_is_looping(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_sound_at_end(ma_sound* pSound);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_seek_to_pcm_frame(ma_sound* pSound, ulong frameIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_seek_to_second(ma_sound* pSound, float seekPointInSeconds);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_get_data_format(ma_sound* pSound, ma_format* pFormat, uint* pChannels, uint* pSampleRate, byte* pChannelMap, nuint channelMapCap);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_get_cursor_in_pcm_frames(ma_sound* pSound, ulong* pCursor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_get_length_in_pcm_frames(ma_sound* pSound, ulong* pLength);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_get_cursor_in_seconds(ma_sound* pSound, float* pCursor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_get_length_in_seconds(ma_sound* pSound, float* pLength);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_set_end_callback(ma_sound* pSound, delegate* unmanaged[Cdecl]<void*, ma_sound*, void> callback, void* pUserData);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_group_init(ma_engine* pEngine, uint flags, ma_sound* pParentGroup, ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_group_init_ex(ma_engine* pEngine, ma_sound_config* pConfig, ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_uninit(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_engine* ma_sound_group_get_engine(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_group_start(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_result ma_sound_group_stop(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_volume(ma_sound* pGroup, float volume);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_group_get_volume(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_pan(ma_sound* pGroup, float pan);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_group_get_pan(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_pan_mode(ma_sound* pGroup, ma_pan_mode panMode);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_pan_mode ma_sound_group_get_pan_mode(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_pitch(ma_sound* pGroup, float pitch);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_group_get_pitch(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_spatialization_enabled(ma_sound* pGroup, uint enabled);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_sound_group_is_spatialization_enabled(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_pinned_listener_index(ma_sound* pGroup, uint listenerIndex);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_sound_group_get_pinned_listener_index(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_sound_group_get_listener_index(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_vec3f ma_sound_group_get_direction_to_listener(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_position(ma_sound* pGroup, float x, float y, float z);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_vec3f ma_sound_group_get_position(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_direction(ma_sound* pGroup, float x, float y, float z);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_vec3f ma_sound_group_get_direction(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_velocity(ma_sound* pGroup, float x, float y, float z);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_vec3f ma_sound_group_get_velocity(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_attenuation_model(ma_sound* pGroup, ma_attenuation_model attenuationModel);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_attenuation_model ma_sound_group_get_attenuation_model(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_positioning(ma_sound* pGroup, ma_positioning positioning);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ma_positioning ma_sound_group_get_positioning(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_rolloff(ma_sound* pGroup, float rolloff);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_group_get_rolloff(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_min_gain(ma_sound* pGroup, float minGain);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_group_get_min_gain(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_max_gain(ma_sound* pGroup, float maxGain);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_group_get_max_gain(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_min_distance(ma_sound* pGroup, float minDistance);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_group_get_min_distance(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_max_distance(ma_sound* pGroup, float maxDistance);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_group_get_max_distance(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_cone(ma_sound* pGroup, float innerAngleInRadians, float outerAngleInRadians, float outerGain);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_get_cone(ma_sound* pGroup, float* pInnerAngleInRadians, float* pOuterAngleInRadians, float* pOuterGain);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_doppler_factor(ma_sound* pGroup, float dopplerFactor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_group_get_doppler_factor(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_directional_attenuation_factor(ma_sound* pGroup, float directionalAttenuationFactor);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_group_get_directional_attenuation_factor(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_fade_in_pcm_frames(ma_sound* pGroup, float volumeBeg, float volumeEnd, ulong fadeLengthInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_fade_in_milliseconds(ma_sound* pGroup, float volumeBeg, float volumeEnd, ulong fadeLengthInMilliseconds);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ma_sound_group_get_current_fade_volume(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_start_time_in_pcm_frames(ma_sound* pGroup, ulong absoluteGlobalTimeInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_start_time_in_milliseconds(ma_sound* pGroup, ulong absoluteGlobalTimeInMilliseconds);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_stop_time_in_pcm_frames(ma_sound* pGroup, ulong absoluteGlobalTimeInFrames);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ma_sound_group_set_stop_time_in_milliseconds(ma_sound* pGroup, ulong absoluteGlobalTimeInMilliseconds);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern uint ma_sound_group_is_playing(ma_sound* pGroup);

        [DllImport("miniaudio", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]

        public static extern ulong ma_sound_group_get_time_in_pcm_frames(ma_sound* pGroup);
    }
}
