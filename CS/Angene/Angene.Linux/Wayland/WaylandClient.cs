using System;
using System.Runtime.InteropServices;

namespace Angene.Linux.Wayland
{
    public unsafe class WaylandClient
    {
        public partial struct timespec
        {
        }

        public partial struct wl_buffer
        {
        }

        public partial struct wl_proxy
        {
        }

        public partial struct wl_callback
        {
        }

        public partial struct wl_compositor
        {
        }

        public partial struct wl_data_device
        {
        }

        public partial struct wl_data_device_manager
        {
        }

        public partial struct wl_data_offer
        {
        }

        public partial struct wl_data_source
        {
        }

        public partial struct wl_display
        {
        }

        public partial struct wl_fixes
        {
        }

        public partial struct wl_keyboard
        {
        }

        public partial struct wl_output
        {
        }

        public partial struct wl_pointer
        {
        }

        public partial struct wl_region
        {
        }

        public partial struct wl_registry
        {
        }

        public partial struct wl_seat
        {
        }

        public partial struct wl_shell
        {
        }

        public partial struct wl_shell_surface
        {
        }

        public partial struct wl_shm
        {
        }

        public partial struct wl_shm_pool
        {
        }

        public partial struct wl_subcompositor
        {
        }

        public partial struct wl_subsurface
        {
        }

        public partial struct wl_surface
        {
        }

        public partial struct wl_touch
        {
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct wl_argument
        {
            [FieldOffset(0)] public int i;
            [FieldOffset(0)] public uint u;
            [FieldOffset(0)] public int f;
            [FieldOffset(0)] public IntPtr s;
            [FieldOffset(0)] public IntPtr o;
            [FieldOffset(0)] public uint n;
            [FieldOffset(0)] public IntPtr a;
            [FieldOffset(0)] public int h;
        }

        public struct wl_array {
            nuint size;
            nuint alloc;
            void *data;
        };

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct wl_interface
        {
            public byte* Name;
            public int Version;
            public int MethodCount;
            public wl_message* Methods;
            public int EventCount;
            public wl_message* Events;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct wl_message
        {
            public byte* Name;
            public byte* Signature;
            public wl_interface** Types;
        }

        public enum wl_display_error : uint
        {
            WL_DISPLAY_ERROR_INVALID_OBJECT = 0,
            WL_DISPLAY_ERROR_INVALID_METHOD = 1,
            WL_DISPLAY_ERROR_NO_MEMORY = 2,
            WL_DISPLAY_ERROR_IMPLEMENTATION = 3,
        }

        public unsafe partial struct wl_display_listener
        {
            public delegate* unmanaged[Cdecl]<void*, wl_display*, void*, uint, sbyte*, void> error;
            public delegate* unmanaged[Cdecl]<void*, wl_display*, uint, void> delete_id;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void WaylandGlobalDelegate(
            IntPtr data, 
            IntPtr registry, 
            uint name, 
            [MarshalAs(UnmanagedType.LPStr)] string @interface, 
            uint version
        );

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void WaylandGlobalRemoveDelegate(
            IntPtr data, 
            IntPtr registry, 
            uint name
        );

        public unsafe partial struct wl_registry_listener
        {
            public delegate* unmanaged[Cdecl]<void*, wl_registry*, uint, sbyte*, uint, void> global;
            public delegate* unmanaged[Cdecl]<void*, wl_registry*, uint, void> global_remove;
        }

        public unsafe partial struct wl_callback_listener
        {
            public delegate* unmanaged[Cdecl]<void*, wl_callback*, uint, void> done;
        }

        public enum wl_shm_pool_error : uint
        {
            WL_SHM_POOL_ERROR_INVALID_FORMAT = 0,
            WL_SHM_POOL_ERROR_INVALID_STRIDE = 1,
        }

        public enum wl_shm_error : uint
        {
            WL_SHM_ERROR_INVALID_FORMAT = 0,
            WL_SHM_ERROR_INVALID_STRIDE = 1,
            WL_SHM_ERROR_INVALID_FD = 2,
        }

        public enum wl_shm_format : uint
        {
            WL_SHM_FORMAT_ARGB8888 = 0,
            WL_SHM_FORMAT_XRGB8888 = 1,
            WL_SHM_FORMAT_C8 = 0x20203843,
            WL_SHM_FORMAT_RGB332 = 0x38424752,
            WL_SHM_FORMAT_BGR233 = 0x38524742,
            WL_SHM_FORMAT_XRGB4444 = 0x32315258,
            WL_SHM_FORMAT_XBGR4444 = 0x32314258,
            WL_SHM_FORMAT_RGBX4444 = 0x32315852,
            WL_SHM_FORMAT_BGRX4444 = 0x32315842,
            WL_SHM_FORMAT_ARGB4444 = 0x32315241,
            WL_SHM_FORMAT_ABGR4444 = 0x32314241,
            WL_SHM_FORMAT_RGBA4444 = 0x32314152,
            WL_SHM_FORMAT_BGRA4444 = 0x32314142,
            WL_SHM_FORMAT_XRGB1555 = 0x35315258,
            WL_SHM_FORMAT_XBGR1555 = 0x35314258,
            WL_SHM_FORMAT_RGBX5551 = 0x35315852,
            WL_SHM_FORMAT_BGRX5551 = 0x35315842,
            WL_SHM_FORMAT_ARGB1555 = 0x35315241,
            WL_SHM_FORMAT_ABGR1555 = 0x35314241,
            WL_SHM_FORMAT_RGBA5551 = 0x35314152,
            WL_SHM_FORMAT_BGRA5551 = 0x35314142,
            WL_SHM_FORMAT_RGB565 = 0x36314752,
            WL_SHM_FORMAT_BGR565 = 0x36314742,
            WL_SHM_FORMAT_RGB888 = 0x34324752,
            WL_SHM_FORMAT_BGR888 = 0x34324742,
            WL_SHM_FORMAT_XBGR8888 = 0x34324258,
            WL_SHM_FORMAT_RGBX8888 = 0x34325852,
            WL_SHM_FORMAT_BGRX8888 = 0x34325842,
            WL_SHM_FORMAT_ABGR8888 = 0x34324241,
            WL_SHM_FORMAT_RGBA8888 = 0x34324152,
            WL_SHM_FORMAT_BGRA8888 = 0x34324142,
            WL_SHM_FORMAT_XRGB2101010 = 0x30335258,
            WL_SHM_FORMAT_XBGR2101010 = 0x30334258,
            WL_SHM_FORMAT_RGBX1010102 = 0x30335852,
            WL_SHM_FORMAT_BGRX1010102 = 0x30335842,
            WL_SHM_FORMAT_ARGB2101010 = 0x30335241,
            WL_SHM_FORMAT_ABGR2101010 = 0x30334241,
            WL_SHM_FORMAT_RGBA1010102 = 0x30334152,
            WL_SHM_FORMAT_BGRA1010102 = 0x30334142,
            WL_SHM_FORMAT_YUYV = 0x56595559,
            WL_SHM_FORMAT_YVYU = 0x55595659,
            WL_SHM_FORMAT_UYVY = 0x59565955,
            WL_SHM_FORMAT_VYUY = 0x59555956,
            WL_SHM_FORMAT_AYUV = 0x56555941,
            WL_SHM_FORMAT_NV12 = 0x3231564e,
            WL_SHM_FORMAT_NV21 = 0x3132564e,
            WL_SHM_FORMAT_NV16 = 0x3631564e,
            WL_SHM_FORMAT_NV61 = 0x3136564e,
            WL_SHM_FORMAT_YUV410 = 0x39565559,
            WL_SHM_FORMAT_YVU410 = 0x39555659,
            WL_SHM_FORMAT_YUV411 = 0x31315559,
            WL_SHM_FORMAT_YVU411 = 0x31315659,
            WL_SHM_FORMAT_YUV420 = 0x32315559,
            WL_SHM_FORMAT_YVU420 = 0x32315659,
            WL_SHM_FORMAT_YUV422 = 0x36315559,
            WL_SHM_FORMAT_YVU422 = 0x36315659,
            WL_SHM_FORMAT_YUV444 = 0x34325559,
            WL_SHM_FORMAT_YVU444 = 0x34325659,
            WL_SHM_FORMAT_R8 = 0x20203852,
            WL_SHM_FORMAT_R16 = 0x20363152,
            WL_SHM_FORMAT_RG88 = 0x38384752,
            WL_SHM_FORMAT_GR88 = 0x38385247,
            WL_SHM_FORMAT_RG1616 = 0x32334752,
            WL_SHM_FORMAT_GR1616 = 0x32335247,
            WL_SHM_FORMAT_XRGB16161616F = 0x48345258,
            WL_SHM_FORMAT_XBGR16161616F = 0x48344258,
            WL_SHM_FORMAT_ARGB16161616F = 0x48345241,
            WL_SHM_FORMAT_ABGR16161616F = 0x48344241,
            WL_SHM_FORMAT_XYUV8888 = 0x56555958,
            WL_SHM_FORMAT_VUY888 = 0x34325556,
            WL_SHM_FORMAT_VUY101010 = 0x30335556,
            WL_SHM_FORMAT_Y210 = 0x30313259,
            WL_SHM_FORMAT_Y212 = 0x32313259,
            WL_SHM_FORMAT_Y216 = 0x36313259,
            WL_SHM_FORMAT_Y410 = 0x30313459,
            WL_SHM_FORMAT_Y412 = 0x32313459,
            WL_SHM_FORMAT_Y416 = 0x36313459,
            WL_SHM_FORMAT_XVYU2101010 = 0x30335658,
            WL_SHM_FORMAT_XVYU12_16161616 = 0x36335658,
            WL_SHM_FORMAT_XVYU16161616 = 0x38345658,
            WL_SHM_FORMAT_Y0L0 = 0x304c3059,
            WL_SHM_FORMAT_X0L0 = 0x304c3058,
            WL_SHM_FORMAT_Y0L2 = 0x324c3059,
            WL_SHM_FORMAT_X0L2 = 0x324c3058,
            WL_SHM_FORMAT_YUV420_8BIT = 0x38305559,
            WL_SHM_FORMAT_YUV420_10BIT = 0x30315559,
            WL_SHM_FORMAT_XRGB8888_A8 = 0x38415258,
            WL_SHM_FORMAT_XBGR8888_A8 = 0x38414258,
            WL_SHM_FORMAT_RGBX8888_A8 = 0x38415852,
            WL_SHM_FORMAT_BGRX8888_A8 = 0x38415842,
            WL_SHM_FORMAT_RGB888_A8 = 0x38413852,
            WL_SHM_FORMAT_BGR888_A8 = 0x38413842,
            WL_SHM_FORMAT_RGB565_A8 = 0x38413552,
            WL_SHM_FORMAT_BGR565_A8 = 0x38413542,
            WL_SHM_FORMAT_NV24 = 0x3432564e,
            WL_SHM_FORMAT_NV42 = 0x3234564e,
            WL_SHM_FORMAT_P210 = 0x30313250,
            WL_SHM_FORMAT_P010 = 0x30313050,
            WL_SHM_FORMAT_P012 = 0x32313050,
            WL_SHM_FORMAT_P016 = 0x36313050,
            WL_SHM_FORMAT_AXBXGXRX106106106106 = 0x30314241,
            WL_SHM_FORMAT_NV15 = 0x3531564e,
            WL_SHM_FORMAT_Q410 = 0x30313451,
            WL_SHM_FORMAT_Q401 = 0x31303451,
            WL_SHM_FORMAT_XRGB16161616 = 0x38345258,
            WL_SHM_FORMAT_XBGR16161616 = 0x38344258,
            WL_SHM_FORMAT_ARGB16161616 = 0x38345241,
            WL_SHM_FORMAT_ABGR16161616 = 0x38344241,
            WL_SHM_FORMAT_C1 = 0x20203143,
            WL_SHM_FORMAT_C2 = 0x20203243,
            WL_SHM_FORMAT_C4 = 0x20203443,
            WL_SHM_FORMAT_D1 = 0x20203144,
            WL_SHM_FORMAT_D2 = 0x20203244,
            WL_SHM_FORMAT_D4 = 0x20203444,
            WL_SHM_FORMAT_D8 = 0x20203844,
            WL_SHM_FORMAT_R1 = 0x20203152,
            WL_SHM_FORMAT_R2 = 0x20203252,
            WL_SHM_FORMAT_R4 = 0x20203452,
            WL_SHM_FORMAT_R10 = 0x20303152,
            WL_SHM_FORMAT_R12 = 0x20323152,
            WL_SHM_FORMAT_AVUY8888 = 0x59555641,
            WL_SHM_FORMAT_XVUY8888 = 0x59555658,
            WL_SHM_FORMAT_P030 = 0x30333050,
            WL_SHM_FORMAT_RGB161616 = 0x38344752,
            WL_SHM_FORMAT_BGR161616 = 0x38344742,
            WL_SHM_FORMAT_R16F = 0x48202052,
            WL_SHM_FORMAT_GR1616F = 0x48205247,
            WL_SHM_FORMAT_BGR161616F = 0x48524742,
            WL_SHM_FORMAT_R32F = 0x46202052,
            WL_SHM_FORMAT_GR3232F = 0x46205247,
            WL_SHM_FORMAT_BGR323232F = 0x46524742,
            WL_SHM_FORMAT_ABGR32323232F = 0x46384241,
            WL_SHM_FORMAT_NV20 = 0x3032564e,
            WL_SHM_FORMAT_NV30 = 0x3033564e,
            WL_SHM_FORMAT_S010 = 0x30313053,
            WL_SHM_FORMAT_S210 = 0x30313253,
            WL_SHM_FORMAT_S410 = 0x30313453,
            WL_SHM_FORMAT_S012 = 0x32313053,
            WL_SHM_FORMAT_S212 = 0x32313253,
            WL_SHM_FORMAT_S412 = 0x32313453,
            WL_SHM_FORMAT_S016 = 0x36313053,
            WL_SHM_FORMAT_S216 = 0x36313253,
            WL_SHM_FORMAT_S416 = 0x36313453,
            WL_SHM_FORMAT_XVUY2101010 = 0x30335958,
            WL_SHM_FORMAT_P230 = 0x30333250,
            WL_SHM_FORMAT_T430 = 0x30333454,
            WL_SHM_FORMAT_Y8 = 0x59455247,
            WL_SHM_FORMAT_XYYY2101010 = 0x34415059,
        }

        public unsafe partial struct wl_shm_listener
        {
            public delegate* unmanaged[Cdecl]<void*, wl_shm*, uint, void> format;
        }

        public unsafe partial struct wl_buffer_listener
        {
            public delegate* unmanaged[Cdecl]<void*, wl_buffer*, void> release;
        }

        public enum wl_data_offer_error : uint
        {
            WL_DATA_OFFER_ERROR_INVALID_FINISH = 0,
            WL_DATA_OFFER_ERROR_INVALID_ACTION_MASK = 1,
            WL_DATA_OFFER_ERROR_INVALID_ACTION = 2,
            WL_DATA_OFFER_ERROR_INVALID_OFFER = 3,
        }

        public unsafe partial struct wl_data_offer_listener
        {
            public delegate* unmanaged[Cdecl]<void*, wl_data_offer*, sbyte*, void> offer;
            public delegate* unmanaged[Cdecl]<void*, wl_data_offer*, uint, void> source_actions;
            public delegate* unmanaged[Cdecl]<void*, wl_data_offer*, uint, void> action;
        }

        public enum wl_data_source_error : uint
        {
            WL_DATA_SOURCE_ERROR_INVALID_ACTION_MASK = 0,
            WL_DATA_SOURCE_ERROR_INVALID_SOURCE = 1,
        }

        public unsafe partial struct wl_data_source_listener
        {
            public delegate* unmanaged[Cdecl]<void*, wl_data_source*, sbyte*, void> target;
            public delegate* unmanaged[Cdecl]<void*, wl_data_source*, sbyte*, int, void> send;
            public delegate* unmanaged[Cdecl]<void*, wl_data_source*, void> cancelled;
            public delegate* unmanaged[Cdecl]<void*, wl_data_source*, void> dnd_drop_performed;
            public delegate* unmanaged[Cdecl]<void*, wl_data_source*, void> dnd_finished;
            public delegate* unmanaged[Cdecl]<void*, wl_data_source*, uint, void> action;
        }

        public enum wl_data_device_error : uint
        {
            WL_DATA_DEVICE_ERROR_ROLE = 0,
            WL_DATA_DEVICE_ERROR_USED_SOURCE = 1,
        }

        public unsafe partial struct wl_data_device_listener
        {
            public delegate* unmanaged[Cdecl]<void*, wl_data_device*, wl_data_offer*, void> data_offer;
            public delegate* unmanaged[Cdecl]<void*, wl_data_device*, uint, wl_surface*, int, int, wl_data_offer*, void> enter;
            public delegate* unmanaged[Cdecl]<void*, wl_data_device*, void> leave;
            public delegate* unmanaged[Cdecl]<void*, wl_data_device*, uint, int, int, void> motion;
            public delegate* unmanaged[Cdecl]<void*, wl_data_device*, void> drop;
            public delegate* unmanaged[Cdecl]<void*, wl_data_device*, wl_data_offer*, void> selection;
        }

        public enum wl_data_device_manager_dnd_action : uint
        {
            WL_DATA_DEVICE_MANAGER_DND_ACTION_NONE = 0,
            WL_DATA_DEVICE_MANAGER_DND_ACTION_COPY = 1,
            WL_DATA_DEVICE_MANAGER_DND_ACTION_MOVE = 2,
            WL_DATA_DEVICE_MANAGER_DND_ACTION_ASK = 4,
        }

        public enum wl_shell_error : uint
        {
            WL_SHELL_ERROR_ROLE = 0,
        }

        public enum wl_shell_surface_resize : uint
        {
            WL_SHELL_SURFACE_RESIZE_NONE = 0,
            WL_SHELL_SURFACE_RESIZE_TOP = 1,
            WL_SHELL_SURFACE_RESIZE_BOTTOM = 2,
            WL_SHELL_SURFACE_RESIZE_LEFT = 4,
            WL_SHELL_SURFACE_RESIZE_TOP_LEFT = 5,
            WL_SHELL_SURFACE_RESIZE_BOTTOM_LEFT = 6,
            WL_SHELL_SURFACE_RESIZE_RIGHT = 8,
            WL_SHELL_SURFACE_RESIZE_TOP_RIGHT = 9,
            WL_SHELL_SURFACE_RESIZE_BOTTOM_RIGHT = 10,
        }

        public enum wl_shell_surface_transient : uint
        {
            WL_SHELL_SURFACE_TRANSIENT_INACTIVE = 0x1,
        }

        public enum wl_shell_surface_fullscreen_method : uint
        {
            WL_SHELL_SURFACE_FULLSCREEN_METHOD_DEFAULT = 0,
            WL_SHELL_SURFACE_FULLSCREEN_METHOD_SCALE = 1,
            WL_SHELL_SURFACE_FULLSCREEN_METHOD_DRIVER = 2,
            WL_SHELL_SURFACE_FULLSCREEN_METHOD_FILL = 3,
        }

        public unsafe partial struct wl_shell_surface_listener
        {
            public delegate* unmanaged[Cdecl]<void*, wl_shell_surface*, uint, void> ping;
            public delegate* unmanaged[Cdecl]<void*, wl_shell_surface*, uint, int, int, void> configure;
            public delegate* unmanaged[Cdecl]<void*, wl_shell_surface*, void> popup_done;
        }

        public enum wl_surface_error : uint
        {
            WL_SURFACE_ERROR_INVALID_SCALE = 0,
            WL_SURFACE_ERROR_INVALID_TRANSFORM = 1,
            WL_SURFACE_ERROR_INVALID_SIZE = 2,
            WL_SURFACE_ERROR_INVALID_OFFSET = 3,
            WL_SURFACE_ERROR_DEFUNCT_ROLE_OBJECT = 4,
            WL_SURFACE_ERROR_NO_BUFFER = 5,
        }

        public unsafe partial struct wl_surface_listener
        {
            public delegate* unmanaged[Cdecl]<void*, wl_surface*, wl_output*, void> enter;
            public delegate* unmanaged[Cdecl]<void*, wl_surface*, wl_output*, void> leave;
            public delegate* unmanaged[Cdecl]<void*, wl_surface*, int, void> preferred_buffer_scale;
            public delegate* unmanaged[Cdecl]<void*, wl_surface*, uint, void> preferred_buffer_transform;
        }

        public enum wl_seat_capability : uint
        {
            WL_SEAT_CAPABILITY_POINTER = 1,
            WL_SEAT_CAPABILITY_KEYBOARD = 2,
            WL_SEAT_CAPABILITY_TOUCH = 4,
        }

        public enum wl_seat_error : uint
        {
            WL_SEAT_ERROR_MISSING_CAPABILITY = 0,
        }

        public unsafe partial struct wl_seat_listener
        {
            public delegate* unmanaged[Cdecl]<void*, wl_seat*, uint, void> capabilities;
            public delegate* unmanaged[Cdecl]<void*, wl_seat*, sbyte*, void> name;
        }

        public enum wl_pointer_error : uint
        {
            WL_POINTER_ERROR_ROLE = 0,
        }

        public enum wl_pointer_button_state : uint
        {
            WL_POINTER_BUTTON_STATE_RELEASED = 0,
            WL_POINTER_BUTTON_STATE_PRESSED = 1,
        }

        public enum wl_pointer_axis : uint
        {
            WL_POINTER_AXIS_VERTICAL_SCROLL = 0,
            WL_POINTER_AXIS_HORIZONTAL_SCROLL = 1,
        }

        public enum wl_pointer_axis_source : uint
        {
            WL_POINTER_AXIS_SOURCE_WHEEL = 0,
            WL_POINTER_AXIS_SOURCE_FINGER = 1,
            WL_POINTER_AXIS_SOURCE_CONTINUOUS = 2,
            WL_POINTER_AXIS_SOURCE_WHEEL_TILT = 3,
        }

        public enum wl_pointer_axis_relative_direction : uint
        {
            WL_POINTER_AXIS_RELATIVE_DIRECTION_IDENTICAL = 0,
            WL_POINTER_AXIS_RELATIVE_DIRECTION_INVERTED = 1,
        }

        public unsafe partial struct wl_pointer_listener
        {
            public delegate* unmanaged[Cdecl]<void*, wl_pointer*, uint, wl_surface*, int, int, void> enter;
            public delegate* unmanaged[Cdecl]<void*, wl_pointer*, uint, wl_surface*, void> leave;
            public delegate* unmanaged[Cdecl]<void*, wl_pointer*, uint, int, int, void> motion;
            public delegate* unmanaged[Cdecl]<void*, wl_pointer*, uint, uint, uint, uint, void> button;
            public delegate* unmanaged[Cdecl]<void*, wl_pointer*, uint, uint, int, void> axis;
            public delegate* unmanaged[Cdecl]<void*, wl_pointer*, void> frame;
            public delegate* unmanaged[Cdecl]<void*, wl_pointer*, uint, void> axis_source;
            public delegate* unmanaged[Cdecl]<void*, wl_pointer*, uint, uint, void> axis_stop;
            public delegate* unmanaged[Cdecl]<void*, wl_pointer*, uint, int, void> axis_discrete;
            public delegate* unmanaged[Cdecl]<void*, wl_pointer*, uint, int, void> axis_value120;
            public delegate* unmanaged[Cdecl]<void*, wl_pointer*, uint, uint, void> axis_relative_direction;
            public delegate* unmanaged[Cdecl]<void*, wl_pointer*, int, int, void> warp;
        }

        public enum wl_keyboard_keymap_format : uint
        {
            WL_KEYBOARD_KEYMAP_FORMAT_NO_KEYMAP = 0,
            WL_KEYBOARD_KEYMAP_FORMAT_XKB_V1 = 1,
        }

        public enum wl_keyboard_key_state : uint
        {
            WL_KEYBOARD_KEY_STATE_RELEASED = 0,
            WL_KEYBOARD_KEY_STATE_PRESSED = 1,
            WL_KEYBOARD_KEY_STATE_REPEATED = 2,
        }

        public unsafe partial struct wl_keyboard_listener
        {
            public delegate* unmanaged[Cdecl]<void*, wl_keyboard*, uint, int, uint, void> keymap;
            public delegate* unmanaged[Cdecl]<void*, wl_keyboard*, uint, wl_surface*, wl_array*, void> enter;
            public delegate* unmanaged[Cdecl]<void*, wl_keyboard*, uint, wl_surface*, void> leave;
            public delegate* unmanaged[Cdecl]<void*, wl_keyboard*, uint, uint, uint, uint, void> key;
            public delegate* unmanaged[Cdecl]<void*, wl_keyboard*, uint, uint, uint, uint, uint, void> modifiers;
            public delegate* unmanaged[Cdecl]<void*, wl_keyboard*, int, int, void> repeat_info;
        }

        public unsafe partial struct wl_touch_listener
        {
            public delegate* unmanaged[Cdecl]<void*, wl_touch*, uint, uint, wl_surface*, int, int, int, void> down;
            public delegate* unmanaged[Cdecl]<void*, wl_touch*, uint, uint, int, void> up;
            public delegate* unmanaged[Cdecl]<void*, wl_touch*, uint, int, int, int, void> motion;
            public delegate* unmanaged[Cdecl]<void*, wl_touch*, void> frame;
            public delegate* unmanaged[Cdecl]<void*, wl_touch*, void> cancel;
            public delegate* unmanaged[Cdecl]<void*, wl_touch*, int, int, int, void> shape;
            public delegate* unmanaged[Cdecl]<void*, wl_touch*, int, int, void> orientation;
        }

        public enum wl_output_subpixel : uint
        {
            WL_OUTPUT_SUBPIXEL_UNKNOWN = 0,
            WL_OUTPUT_SUBPIXEL_NONE = 1,
            WL_OUTPUT_SUBPIXEL_HORIZONTAL_RGB = 2,
            WL_OUTPUT_SUBPIXEL_HORIZONTAL_BGR = 3,
            WL_OUTPUT_SUBPIXEL_VERTICAL_RGB = 4,
            WL_OUTPUT_SUBPIXEL_VERTICAL_BGR = 5,
        }

        public enum wl_output_transform : uint
        {
            WL_OUTPUT_TRANSFORM_NORMAL = 0,
            WL_OUTPUT_TRANSFORM_90 = 1,
            WL_OUTPUT_TRANSFORM_180 = 2,
            WL_OUTPUT_TRANSFORM_270 = 3,
            WL_OUTPUT_TRANSFORM_FLIPPED = 4,
            WL_OUTPUT_TRANSFORM_FLIPPED_90 = 5,
            WL_OUTPUT_TRANSFORM_FLIPPED_180 = 6,
            WL_OUTPUT_TRANSFORM_FLIPPED_270 = 7,
        }

        public enum wl_output_mode : uint
        {
            WL_OUTPUT_MODE_CURRENT = 0x1,
            WL_OUTPUT_MODE_PREFERRED = 0x2,
        }

        public unsafe partial struct wl_output_listener
        {
            public delegate* unmanaged[Cdecl]<void*, wl_output*, int, int, int, int, int, sbyte*, sbyte*, int, void> geometry;
            public delegate* unmanaged[Cdecl]<void*, wl_output*, uint, int, int, int, void> mode;
            public delegate* unmanaged[Cdecl]<void*, wl_output*, void> done;
            public delegate* unmanaged[Cdecl]<void*, wl_output*, int, void> scale;
            public delegate* unmanaged[Cdecl]<void*, wl_output*, sbyte*, void> name;
            public delegate* unmanaged[Cdecl]<void*, wl_output*, sbyte*, void> description;
        }

        public enum wl_subcompositor_error : uint
        {
            WL_SUBCOMPOSITOR_ERROR_BAD_SURFACE = 0,
            WL_SUBCOMPOSITOR_ERROR_BAD_PARENT = 1,
        }

        public enum wl_subsurface_error : uint
        {
            WL_SUBSURFACE_ERROR_BAD_SURFACE = 0,
        }

        public enum wl_fixes_error : uint
        {
            WL_FIXES_ERROR_INVALID_ACK_REMOVE = 0,
        }

        // TODO: placeholder interfaces
        public static wl_interface* wl_registry_interface = CreateInterfaceStub("wl_registry", 1);

        internal static wl_interface* CreateInterfaceStub(string name, int version)
        {
            var ptr = (wl_interface*)System.Runtime.InteropServices.Marshal.AllocHGlobal(sizeof(wl_interface));
            ptr->Name = (byte*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(name);
            ptr->Version = version;
            ptr->MethodCount = 0;
            ptr->Methods = null;
            ptr->EventCount = 0;
            ptr->Events = null;
            return ptr;
        }

        public static unsafe partial class Methods
        {
            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void wl_event_queue_destroy(IntPtr* queue);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr* wl_proxy_marshal_flags(IntPtr* proxy, uint opcode, wl_interface* @interface, uint version, uint flags, __arglist);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr* wl_proxy_marshal_array_flags(IntPtr* proxy, uint opcode, wl_interface* @interface, uint version, uint flags, wl_argument* args);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void wl_proxy_marshal(IntPtr* p, uint opcode);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void wl_proxy_marshal_array(IntPtr* p, uint opcode, wl_argument* args);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr* wl_proxy_create(IntPtr* factory, wl_interface* @interface);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void* wl_proxy_create_wrapper(void* proxy);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void wl_proxy_wrapper_destroy(void* proxy_wrapper);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr* wl_proxy_marshal_constructor(IntPtr* proxy, uint opcode, wl_interface* @interface, __arglist);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr* wl_proxy_marshal_constructor_versioned(IntPtr* proxy, uint opcode, wl_interface* @interface, uint version, __arglist);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr* wl_proxy_marshal_array_constructor(IntPtr* proxy, uint opcode, wl_argument* args, wl_interface* @interface);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr* wl_proxy_marshal_array_constructor_versioned(IntPtr* proxy, uint opcode, wl_argument* args, wl_interface* @interface, uint version);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void wl_proxy_destroy(IntPtr* proxy);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int wl_proxy_add_listener(IntPtr* proxy, delegate* unmanaged[Cdecl]<void>* implementation, void* data);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void* wl_proxy_get_listener(IntPtr* proxy);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int wl_proxy_add_dispatcher(IntPtr* proxy, delegate* unmanaged[Cdecl]<void*, void*, uint, wl_message*, wl_argument*, int> dispatcher_func, void* dispatcher_data, void* data);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void wl_proxy_set_user_data(IntPtr* proxy, void* user_data);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void* wl_proxy_get_user_data(IntPtr* proxy);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint wl_proxy_get_version(IntPtr* proxy);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint wl_proxy_get_id(IntPtr* proxy);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void wl_proxy_set_tag(IntPtr* proxy, sbyte** tag);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte** wl_proxy_get_tag(IntPtr* proxy);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* wl_proxy_get_class(IntPtr* proxy);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern wl_interface* wl_proxy_get_interface(IntPtr* proxy);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr* wl_proxy_get_display(IntPtr* proxy);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void wl_proxy_set_queue(IntPtr* proxy, IntPtr* queue);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr* wl_proxy_get_queue(IntPtr* proxy);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* wl_event_queue_get_name(IntPtr* queue);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr* wl_display_connect(sbyte* name);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr* wl_display_connect_to_fd(int fd);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void wl_display_disconnect(IntPtr* display);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int wl_display_get_fd(IntPtr* display);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int wl_display_dispatch(IntPtr* display);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int wl_display_dispatch_queue(IntPtr* display, IntPtr* queue);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int wl_display_dispatch_timeout(IntPtr* display, timespec* timeout);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int wl_display_dispatch_queue_timeout(IntPtr* display, IntPtr* queue, timespec* timeout);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int wl_display_dispatch_queue_pending(IntPtr* display, IntPtr* queue);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int wl_display_dispatch_queue_pending_single(IntPtr* display, IntPtr* queue);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int wl_display_dispatch_pending(IntPtr* display);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int wl_display_dispatch_pending_single(IntPtr* display);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int wl_display_get_error(IntPtr* display);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint wl_display_get_protocol_error(IntPtr* display, wl_interface** @interface, uint* id);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int wl_display_flush(IntPtr* display);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int wl_display_roundtrip_queue(IntPtr* display, IntPtr* queue);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int wl_display_roundtrip(IntPtr* display);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr* wl_display_create_queue(IntPtr* display);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern IntPtr* wl_display_create_queue_with_name(IntPtr* display, sbyte* name);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int wl_display_prepare_read_queue(IntPtr* display, IntPtr* queue);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int wl_display_prepare_read(IntPtr* display);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void wl_display_cancel_read(IntPtr* display);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern int wl_display_read_events(IntPtr* display);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void wl_log_set_handler_client(delegate* unmanaged[Cdecl]<sbyte*, IntPtr, void> handler);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void wl_display_set_max_buffer_size(IntPtr* display, nuint max_buffer_size);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl)]
            public static extern int wl_registry_add_listener(IntPtr registry, ref wl_registry_listener listener, IntPtr data);
            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl)]
            public static extern int wl_display_roundtrip(IntPtr display);

            [DllImport("libwayland-client.so.0", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr wl_compositor_create_surface(IntPtr compositor);

            public const int WL_MARSHAL_FLAG_DESTROY = 1 << 0;

            public static IntPtr* wl_display_get_registry(IntPtr* wl_display)
            {
                if (wl_display == null)
                    throw new ArgumentNullException(nameof(wl_display));

                // Opcode 1 corresponds to WL_DISPLAY_GET_REGISTRY in the protocol specification
                const uint WL_DISPLAY_GET_REGISTRY = 1;

                // Version to advertise for the new registry proxy; matches the display proxy's own version.
                uint version = wl_proxy_get_version(wl_display);

                // Single new-id argument slot; libwayland fills in the actual object, so this is a placeholder.
                wl_argument* args = stackalloc wl_argument[1];
                args[0].o = IntPtr.Zero;

                return wl_proxy_marshal_array_flags(
                    wl_display,
                    WL_DISPLAY_GET_REGISTRY,
                    wl_registry_interface,
                    version,
                    0,
                    args
                );
            }

            public static void wl_surface_commit(IntPtr wl_surface)
            {
                if (wl_surface == IntPtr.Zero)
                    throw new ArgumentNullException(nameof(wl_surface));

                wl_proxy_marshal(&wl_surface, 6);
            }
        }
    }
}