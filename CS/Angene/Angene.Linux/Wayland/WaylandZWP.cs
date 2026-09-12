using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static Angene.Linux.Wayland.WaylandClient.Methods;

namespace Angene.Linux.Wayland
{
    public class WaylandZWP
    {
        private static unsafe byte* Utf8(string s) => (byte*)Marshal.StringToCoTaskMemUTF8(s);
        public partial struct zwp_confined_pointer_v1
        {
        }

        public partial struct zwp_locked_pointer_v1
        {
        }

        public partial struct zwp_pointer_constraints_v1
        {
        }

        [NativeTypeName("unsigned int")]
        public enum zwp_pointer_constraints_v1_error : uint
        {
            ZWP_POINTER_CONSTRAINTS_V1_ERROR_ALREADY_CONSTRAINED = 1,
        }
        
        private static readonly WaylandClient.wl_message[] zwp_locked_pointer_v1_requests =
            GC.AllocateArray<WaylandClient.wl_message>(3, pinned: true);

        private static readonly WaylandClient.wl_message[] zwp_locked_pointer_v1_events =
            GC.AllocateArray<WaylandClient.wl_message>(2, pinned: true);

        public static WaylandClient.wl_interface zwp_locked_pointer_v1_interface;

        private static readonly WaylandClient.wl_message[] zwp_confined_pointer_v1_requests =
            GC.AllocateArray<WaylandClient.wl_message>(2, pinned: true);
        private static readonly WaylandClient.wl_message[] zwp_confined_pointer_v1_events =
            GC.AllocateArray<WaylandClient.wl_message>(2, pinned: true);
        public static WaylandClient.wl_interface zwp_confined_pointer_v1_interface;

        private static readonly WaylandClient.wl_message[] zwp_relative_pointer_v1_requests =
            GC.AllocateArray<WaylandClient.wl_message>(1, pinned: true);
        private static readonly WaylandClient.wl_message[] zwp_relative_pointer_v1_events =
            GC.AllocateArray<WaylandClient.wl_message>(1, pinned: true);
        public static WaylandClient.wl_interface zwp_relative_pointer_v1_interface;
        private static readonly IntPtr[] zwp_set_region_types =
            GC.AllocateArray<IntPtr>(1, pinned: true);
        
        static unsafe WaylandZWP()
        {
            zwp_set_region_types[0] = WaylandClient.Methods.GetWlRegionInterface();
            zwp_locked_pointer_v1_requests[0] = new WaylandClient.wl_message { Name = Utf8("destroy"), Signature = Utf8(""), Types = null };
            zwp_locked_pointer_v1_requests[1] = new WaylandClient.wl_message { Name = Utf8("set_cursor_position_hint"), Signature = Utf8("ff"), Types = null };
            zwp_locked_pointer_v1_requests[2] = new WaylandClient.wl_message { Name = Utf8("set_region"), Signature = Utf8("?o"), Types = (WaylandClient.wl_interface**)Unsafe.AsPointer(ref zwp_set_region_types[0]) };

            zwp_locked_pointer_v1_events[0] = new WaylandClient.wl_message { Name = Utf8("locked"), Signature = Utf8(""), Types = null };
            zwp_locked_pointer_v1_events[1] = new WaylandClient.wl_message { Name = Utf8("unlocked"), Signature = Utf8(""), Types = null };

            zwp_locked_pointer_v1_interface = new WaylandClient.wl_interface
            {
                Name = Utf8("zwp_locked_pointer_v1"),
                Version = 1,
                MethodCount = 3,
                Methods = (WaylandClient.wl_message*)Unsafe.AsPointer(ref zwp_locked_pointer_v1_requests[0]),
                EventCount = 2,
                Events = (WaylandClient.wl_message*)Unsafe.AsPointer(ref zwp_locked_pointer_v1_events[0]),
            };
            
            zwp_confined_pointer_v1_requests[0] = new WaylandClient.wl_message { Name = Utf8("destroy"), Signature = Utf8(""), Types = null };
            zwp_confined_pointer_v1_requests[1] = new WaylandClient.wl_message { Name = Utf8("set_region"), Signature = Utf8("?o"), Types = (WaylandClient.wl_interface**)Unsafe.AsPointer(ref zwp_set_region_types[0]) };

            zwp_confined_pointer_v1_events[0] = new WaylandClient.wl_message { Name = Utf8("confined"), Signature = Utf8(""), Types = null };
            zwp_confined_pointer_v1_events[1] = new WaylandClient.wl_message { Name = Utf8("unconfined"), Signature = Utf8(""), Types = null };

            zwp_confined_pointer_v1_interface = new WaylandClient.wl_interface
            {
                Name = Utf8("zwp_confined_pointer_v1"),
                Version = 1,
                MethodCount = 2,
                Methods = (WaylandClient.wl_message*)Unsafe.AsPointer(ref zwp_confined_pointer_v1_requests[0]),
                EventCount = 2,
                Events = (WaylandClient.wl_message*)Unsafe.AsPointer(ref zwp_confined_pointer_v1_events[0]),
            };

            zwp_relative_pointer_v1_requests[0] = new WaylandClient.wl_message { Name = Utf8("destroy"), Signature = Utf8(""), Types = null };
            zwp_relative_pointer_v1_events[0] = new WaylandClient.wl_message { Name = Utf8("relative_motion"), Signature = Utf8("uuffff"), Types = null };

            zwp_relative_pointer_v1_interface = new WaylandClient.wl_interface
            {
                Name = Utf8("zwp_relative_pointer_v1"),
                Version = 1,
                MethodCount = 1,
                Methods = (WaylandClient.wl_message*)Unsafe.AsPointer(ref zwp_relative_pointer_v1_requests[0]),
                EventCount = 1,
                Events = (WaylandClient.wl_message*)Unsafe.AsPointer(ref zwp_relative_pointer_v1_events[0]),
            };
        }

        [NativeTypeName("unsigned int")]
        public enum zwp_pointer_constraints_v1_lifetime : uint
        {
            ZWP_POINTER_CONSTRAINTS_V1_LIFETIME_ONESHOT = 1,
            ZWP_POINTER_CONSTRAINTS_V1_LIFETIME_PERSISTENT = 2,
        }

        public unsafe partial struct zwp_locked_pointer_v1_listener
        {
            [NativeTypeName("void (*)(void *, struct zwp_locked_pointer_v1 *)")]
            public delegate* unmanaged[Cdecl]<void*, zwp_locked_pointer_v1*, void> locked;

            [NativeTypeName("void (*)(void *, struct zwp_locked_pointer_v1 *)")]
            public delegate* unmanaged[Cdecl]<void*, zwp_locked_pointer_v1*, void> unlocked;
        }

        public unsafe partial struct zwp_confined_pointer_v1_listener
        {
            [NativeTypeName("void (*)(void *, struct zwp_confined_pointer_v1 *)")]
            public delegate* unmanaged[Cdecl]<void*, zwp_confined_pointer_v1*, void> confined;

            [NativeTypeName("void (*)(void *, struct zwp_confined_pointer_v1 *)")]
            public delegate* unmanaged[Cdecl]<void*, zwp_confined_pointer_v1*, void> unconfined;
        }

        public partial struct zwp_relative_pointer_manager_v1
        {
        }

        public partial struct zwp_relative_pointer_v1
        {
        }

        public unsafe partial struct zwp_relative_pointer_v1_listener
        {
            [NativeTypeName("void (*)(void *, struct zwp_relative_pointer_v1 *, uint32_t, uint32_t, wl_fixed_t, wl_fixed_t, wl_fixed_t, wl_fixed_t)")]
            public delegate* unmanaged[Cdecl]<void*, zwp_relative_pointer_v1*, uint, uint, int, int, int, int, void> relative_motion;
        }

        public static unsafe partial class Methods
        {
            public static void zwp_pointer_constraints_v1_set_user_data([NativeTypeName("struct zwp_pointer_constraints_v1 *")] zwp_pointer_constraints_v1* zwp_pointer_constraints_v1, void* user_data)
            {
                wl_proxy_set_user_data((IntPtr*)unchecked(zwp_pointer_constraints_v1), user_data);
            }

            public static void* zwp_pointer_constraints_v1_get_user_data([NativeTypeName("struct zwp_pointer_constraints_v1 *")] zwp_pointer_constraints_v1* zwp_pointer_constraints_v1)
            {
                return wl_proxy_get_user_data((IntPtr*)zwp_pointer_constraints_v1);
            }

            [return: NativeTypeName("uint32_t")]
            public static uint zwp_pointer_constraints_v1_get_version([NativeTypeName("struct zwp_pointer_constraints_v1 *")] zwp_pointer_constraints_v1* zwp_pointer_constraints_v1)
            {
                return wl_proxy_get_version((IntPtr*)zwp_pointer_constraints_v1);
            }

            public static void zwp_pointer_constraints_v1_destroy([NativeTypeName("struct zwp_pointer_constraints_v1 *")] zwp_pointer_constraints_v1* zwp_pointer_constraints_v1)
            {
                _ = wl_proxy_marshal_flags((IntPtr*)zwp_pointer_constraints_v1, 0, null, wl_proxy_get_version((IntPtr*)zwp_pointer_constraints_v1), (1 << 0));
            }

            [return: NativeTypeName("struct zwp_locked_pointer_v1 *")]
            public static zwp_locked_pointer_v1* zwp_pointer_constraints_v1_lock_pointer([NativeTypeName("struct zwp_pointer_constraints_v1 *")] zwp_pointer_constraints_v1* zwp_pointer_constraints_v1, [NativeTypeName("struct wl_surface *")] WaylandClient.wl_surface* surface, [NativeTypeName("struct wl_pointer *")] WaylandClient.wl_pointer* pointer, [NativeTypeName("struct wl_region *")] WaylandClient.wl_region* region, [NativeTypeName("uint32_t")] uint lifetime)
            {
                WaylandClient.wl_argument* args = stackalloc WaylandClient.wl_argument[5];
                args[0].o = IntPtr.Zero;       // new_id placeholder
                args[1].o = (IntPtr)surface;
                args[2].o = (IntPtr)pointer;
                args[3].o = (IntPtr)region;
                args[4].u = lifetime;

                WaylandClient.wl_proxy* id = (WaylandClient.wl_proxy*)wl_proxy_marshal_array_flags(
                    (IntPtr*)zwp_pointer_constraints_v1, 1,
                    (WaylandClient.wl_interface*)Unsafe.AsPointer(ref zwp_locked_pointer_v1_interface),
                    wl_proxy_get_version((IntPtr*)zwp_pointer_constraints_v1), 0, args);
                return (zwp_locked_pointer_v1*)(id);
            }

            [return: NativeTypeName("struct zwp_confined_pointer_v1 *")]
            public static zwp_confined_pointer_v1* zwp_pointer_constraints_v1_confine_pointer([NativeTypeName("struct zwp_pointer_constraints_v1 *")] zwp_pointer_constraints_v1* zwp_pointer_constraints_v1, [NativeTypeName("struct wl_surface *")] WaylandClient.wl_surface* surface, [NativeTypeName("struct wl_pointer *")] WaylandClient.wl_pointer* pointer, [NativeTypeName("struct wl_region *")] WaylandClient.wl_region* region, [NativeTypeName("uint32_t")] uint lifetime)
            {
                WaylandClient.wl_argument* args = stackalloc WaylandClient.wl_argument[5];
                args[0].o = IntPtr.Zero;       // new_id placeholder
                args[1].o = (IntPtr)surface;
                args[2].o = (IntPtr)pointer;
                args[3].o = (IntPtr)region;
                args[4].u = lifetime;

                WaylandClient.wl_proxy* id = (WaylandClient.wl_proxy*)wl_proxy_marshal_array_flags(
                    (IntPtr*)zwp_pointer_constraints_v1, 2,
                    (WaylandClient.wl_interface*)Unsafe.AsPointer(ref zwp_confined_pointer_v1_interface),
                    wl_proxy_get_version((IntPtr*)zwp_pointer_constraints_v1), 0, args);
                return (zwp_confined_pointer_v1*)(id);
            }

            public static int zwp_locked_pointer_v1_add_listener([NativeTypeName("struct zwp_locked_pointer_v1 *")] zwp_locked_pointer_v1* zwp_locked_pointer_v1, [NativeTypeName("const struct zwp_locked_pointer_v1_listener *")] zwp_locked_pointer_v1_listener* listener, void* data)
            {
                return wl_proxy_add_listener((IntPtr)unchecked(zwp_locked_pointer_v1), (IntPtr)unchecked(listener), data);
            }

            public static void zwp_locked_pointer_v1_set_user_data([NativeTypeName("struct zwp_locked_pointer_v1 *")] zwp_locked_pointer_v1* zwp_locked_pointer_v1, void* user_data)
            {
                wl_proxy_set_user_data((IntPtr*)unchecked(zwp_locked_pointer_v1), user_data);
            }

            public static void* zwp_locked_pointer_v1_get_user_data([NativeTypeName("struct zwp_locked_pointer_v1 *")] zwp_locked_pointer_v1* zwp_locked_pointer_v1)
            {
                return wl_proxy_get_user_data((IntPtr*)zwp_locked_pointer_v1);
            }

            [return: NativeTypeName("uint32_t")]
            public static uint zwp_locked_pointer_v1_get_version([NativeTypeName("struct zwp_locked_pointer_v1 *")] zwp_locked_pointer_v1* zwp_locked_pointer_v1)
            {
                return wl_proxy_get_version((IntPtr*)zwp_locked_pointer_v1);
            }

            public static void zwp_locked_pointer_v1_destroy([NativeTypeName("struct zwp_locked_pointer_v1 *")] zwp_locked_pointer_v1* zwp_locked_pointer_v1)
            {
                _ = wl_proxy_marshal_flags((IntPtr*)zwp_locked_pointer_v1, 0, null, wl_proxy_get_version((IntPtr*)zwp_locked_pointer_v1), (1 << 0));
            }

            public static void zwp_locked_pointer_v1_set_cursor_position_hint([NativeTypeName("struct zwp_locked_pointer_v1 *")] zwp_locked_pointer_v1* zwp_locked_pointer_v1, [NativeTypeName("wl_fixed_t")] int surface_x, [NativeTypeName("wl_fixed_t")] int surface_y)
            {
                WaylandClient.wl_argument* args = stackalloc WaylandClient.wl_argument[2];
                args[0].f = surface_x;
                args[1].f = surface_y;
                _ = wl_proxy_marshal_array_flags((IntPtr*)zwp_locked_pointer_v1, 1, null,
                    wl_proxy_get_version((IntPtr*)zwp_locked_pointer_v1), 0, args);
            }

            public static void zwp_locked_pointer_v1_set_region([NativeTypeName("struct zwp_locked_pointer_v1 *")] zwp_locked_pointer_v1* zwp_locked_pointer_v1, [NativeTypeName("struct wl_region *")] WaylandClient.wl_region* region)
            {
                WaylandClient.wl_argument* args = stackalloc WaylandClient.wl_argument[1];
                args[0].o = (IntPtr)region;
                _ = wl_proxy_marshal_array_flags((IntPtr*)zwp_locked_pointer_v1, 2, null,
                    wl_proxy_get_version((IntPtr*)zwp_locked_pointer_v1), 0, args);
            }

            public static int zwp_confined_pointer_v1_add_listener([NativeTypeName("struct zwp_confined_pointer_v1 *")] zwp_confined_pointer_v1* zwp_confined_pointer_v1, [NativeTypeName("const struct zwp_confined_pointer_v1_listener *")] zwp_confined_pointer_v1_listener* listener, void* data)
            {
                return wl_proxy_add_listener((IntPtr)unchecked(zwp_confined_pointer_v1), (IntPtr)unchecked(listener), data);
            }

            public static void zwp_confined_pointer_v1_set_user_data([NativeTypeName("struct zwp_confined_pointer_v1 *")] zwp_confined_pointer_v1* zwp_confined_pointer_v1, void* user_data)
            {
                wl_proxy_set_user_data((IntPtr*)unchecked(zwp_confined_pointer_v1), user_data);
            }

            public static void* zwp_confined_pointer_v1_get_user_data([NativeTypeName("struct zwp_confined_pointer_v1 *")] zwp_confined_pointer_v1* zwp_confined_pointer_v1)
            {
                return wl_proxy_get_user_data((IntPtr*)zwp_confined_pointer_v1);
            }

            [return: NativeTypeName("uint32_t")]
            public static uint zwp_confined_pointer_v1_get_version([NativeTypeName("struct zwp_confined_pointer_v1 *")] zwp_confined_pointer_v1* zwp_confined_pointer_v1)
            {
                return wl_proxy_get_version((IntPtr*)zwp_confined_pointer_v1);
            }

            public static void zwp_confined_pointer_v1_destroy([NativeTypeName("struct zwp_confined_pointer_v1 *")] zwp_confined_pointer_v1* zwp_confined_pointer_v1)
            {
                _ = wl_proxy_marshal_flags((IntPtr*)zwp_confined_pointer_v1, 0, null, wl_proxy_get_version((IntPtr*)zwp_confined_pointer_v1), (1 << 0));
            }

            public static void zwp_confined_pointer_v1_set_region([NativeTypeName("struct zwp_confined_pointer_v1 *")] zwp_confined_pointer_v1* zwp_confined_pointer_v1, [NativeTypeName("struct wl_region *")] WaylandClient.wl_region* region)
            {
                WaylandClient.wl_argument* args = stackalloc WaylandClient.wl_argument[1];
                args[0].o = (IntPtr)region;
                _ = wl_proxy_marshal_array_flags((IntPtr*)zwp_confined_pointer_v1, 1, null,
                    wl_proxy_get_version((IntPtr*)zwp_confined_pointer_v1), 0, args);
            }

            [NativeTypeName("#define ZWP_POINTER_CONSTRAINTS_V1_DESTROY 0")]
            public const int ZWP_POINTER_CONSTRAINTS_V1_DESTROY = 0;

            [NativeTypeName("#define ZWP_POINTER_CONSTRAINTS_V1_LOCK_POINTER 1")]
            public const int ZWP_POINTER_CONSTRAINTS_V1_LOCK_POINTER = 1;

            [NativeTypeName("#define ZWP_POINTER_CONSTRAINTS_V1_CONFINE_POINTER 2")]
            public const int ZWP_POINTER_CONSTRAINTS_V1_CONFINE_POINTER = 2;

            [NativeTypeName("#define ZWP_POINTER_CONSTRAINTS_V1_DESTROY_SINCE_VERSION 1")]
            public const int ZWP_POINTER_CONSTRAINTS_V1_DESTROY_SINCE_VERSION = 1;

            [NativeTypeName("#define ZWP_POINTER_CONSTRAINTS_V1_LOCK_POINTER_SINCE_VERSION 1")]
            public const int ZWP_POINTER_CONSTRAINTS_V1_LOCK_POINTER_SINCE_VERSION = 1;

            [NativeTypeName("#define ZWP_POINTER_CONSTRAINTS_V1_CONFINE_POINTER_SINCE_VERSION 1")]
            public const int ZWP_POINTER_CONSTRAINTS_V1_CONFINE_POINTER_SINCE_VERSION = 1;

            [NativeTypeName("#define ZWP_LOCKED_POINTER_V1_DESTROY 0")]
            public const int ZWP_LOCKED_POINTER_V1_DESTROY = 0;

            [NativeTypeName("#define ZWP_LOCKED_POINTER_V1_SET_CURSOR_POSITION_HINT 1")]
            public const int ZWP_LOCKED_POINTER_V1_SET_CURSOR_POSITION_HINT = 1;

            [NativeTypeName("#define ZWP_LOCKED_POINTER_V1_SET_REGION 2")]
            public const int ZWP_LOCKED_POINTER_V1_SET_REGION = 2;

            [NativeTypeName("#define ZWP_LOCKED_POINTER_V1_LOCKED_SINCE_VERSION 1")]
            public const int ZWP_LOCKED_POINTER_V1_LOCKED_SINCE_VERSION = 1;

            [NativeTypeName("#define ZWP_LOCKED_POINTER_V1_UNLOCKED_SINCE_VERSION 1")]
            public const int ZWP_LOCKED_POINTER_V1_UNLOCKED_SINCE_VERSION = 1;

            [NativeTypeName("#define ZWP_LOCKED_POINTER_V1_DESTROY_SINCE_VERSION 1")]
            public const int ZWP_LOCKED_POINTER_V1_DESTROY_SINCE_VERSION = 1;

            [NativeTypeName("#define ZWP_LOCKED_POINTER_V1_SET_CURSOR_POSITION_HINT_SINCE_VERSION 1")]
            public const int ZWP_LOCKED_POINTER_V1_SET_CURSOR_POSITION_HINT_SINCE_VERSION = 1;

            [NativeTypeName("#define ZWP_LOCKED_POINTER_V1_SET_REGION_SINCE_VERSION 1")]
            public const int ZWP_LOCKED_POINTER_V1_SET_REGION_SINCE_VERSION = 1;

            [NativeTypeName("#define ZWP_CONFINED_POINTER_V1_DESTROY 0")]
            public const int ZWP_CONFINED_POINTER_V1_DESTROY = 0;

            [NativeTypeName("#define ZWP_CONFINED_POINTER_V1_SET_REGION 1")]
            public const int ZWP_CONFINED_POINTER_V1_SET_REGION = 1;

            [NativeTypeName("#define ZWP_CONFINED_POINTER_V1_CONFINED_SINCE_VERSION 1")]
            public const int ZWP_CONFINED_POINTER_V1_CONFINED_SINCE_VERSION = 1;

            [NativeTypeName("#define ZWP_CONFINED_POINTER_V1_UNCONFINED_SINCE_VERSION 1")]
            public const int ZWP_CONFINED_POINTER_V1_UNCONFINED_SINCE_VERSION = 1;

            [NativeTypeName("#define ZWP_CONFINED_POINTER_V1_DESTROY_SINCE_VERSION 1")]
            public const int ZWP_CONFINED_POINTER_V1_DESTROY_SINCE_VERSION = 1;

            [NativeTypeName("#define ZWP_CONFINED_POINTER_V1_SET_REGION_SINCE_VERSION 1")]
            public const int ZWP_CONFINED_POINTER_V1_SET_REGION_SINCE_VERSION = 1;

            public static void zwp_relative_pointer_manager_v1_set_user_data([NativeTypeName("struct zwp_relative_pointer_manager_v1 *")] zwp_relative_pointer_manager_v1* zwp_relative_pointer_manager_v1, void* user_data)
            {
                wl_proxy_set_user_data((IntPtr*)unchecked(zwp_relative_pointer_manager_v1), user_data);
            }

            public static void* zwp_relative_pointer_manager_v1_get_user_data([NativeTypeName("struct zwp_relative_pointer_manager_v1 *")] zwp_relative_pointer_manager_v1* zwp_relative_pointer_manager_v1)
            {
                return wl_proxy_get_user_data((IntPtr*)zwp_relative_pointer_manager_v1);
            }

            [return: NativeTypeName("uint32_t")]
            public static uint zwp_relative_pointer_manager_v1_get_version([NativeTypeName("struct zwp_relative_pointer_manager_v1 *")] zwp_relative_pointer_manager_v1* zwp_relative_pointer_manager_v1)
            {
                return wl_proxy_get_version((IntPtr*)zwp_relative_pointer_manager_v1);
            }

            public static void zwp_relative_pointer_manager_v1_destroy([NativeTypeName("struct zwp_relative_pointer_manager_v1 *")] zwp_relative_pointer_manager_v1* zwp_relative_pointer_manager_v1)
            {
                _ = wl_proxy_marshal_flags((IntPtr*)zwp_relative_pointer_manager_v1, 0, null, wl_proxy_get_version((IntPtr*)zwp_relative_pointer_manager_v1), (1 << 0));
            }

            [return: NativeTypeName("struct zwp_relative_pointer_v1 *")]
            public static zwp_relative_pointer_v1* zwp_relative_pointer_manager_v1_get_relative_pointer([NativeTypeName("struct zwp_relative_pointer_manager_v1 *")] zwp_relative_pointer_manager_v1* zwp_relative_pointer_manager_v1, [NativeTypeName("struct wl_pointer *")] WaylandClient.wl_pointer* pointer)
            {
                WaylandClient.wl_argument* args = stackalloc WaylandClient.wl_argument[2];
                args[0].o = IntPtr.Zero; // new_id placeholder
                args[1].o = (IntPtr)pointer;

                WaylandClient.wl_proxy* id = (WaylandClient.wl_proxy*)wl_proxy_marshal_array_flags(
                    (IntPtr*)zwp_relative_pointer_manager_v1, 1,
                    (WaylandClient.wl_interface*)Unsafe.AsPointer(ref zwp_relative_pointer_v1_interface),
                    wl_proxy_get_version((IntPtr*)zwp_relative_pointer_manager_v1), 0, args);
                return (zwp_relative_pointer_v1*)(id);
            }

            public static int zwp_relative_pointer_v1_add_listener([NativeTypeName("struct zwp_relative_pointer_v1 *")] zwp_relative_pointer_v1* zwp_relative_pointer_v1, [NativeTypeName("const struct zwp_relative_pointer_v1_listener *")] zwp_relative_pointer_v1_listener* listener, void* data)
            {
                return wl_proxy_add_listener((IntPtr)unchecked(zwp_relative_pointer_v1), (IntPtr)unchecked(listener), data);
            }

            public static void zwp_relative_pointer_v1_set_user_data([NativeTypeName("struct zwp_relative_pointer_v1 *")] zwp_relative_pointer_v1* zwp_relative_pointer_v1, void* user_data)
            {
                wl_proxy_set_user_data((IntPtr*)unchecked(zwp_relative_pointer_v1), user_data);
            }

            public static void* zwp_relative_pointer_v1_get_user_data([NativeTypeName("struct zwp_relative_pointer_v1 *")] zwp_relative_pointer_v1* zwp_relative_pointer_v1)
            {
                return wl_proxy_get_user_data((IntPtr*)zwp_relative_pointer_v1);
            }

            [return: NativeTypeName("uint32_t")]
            public static uint zwp_relative_pointer_v1_get_version([NativeTypeName("struct zwp_relative_pointer_v1 *")] zwp_relative_pointer_v1* zwp_relative_pointer_v1)
            {
                return wl_proxy_get_version((IntPtr*)zwp_relative_pointer_v1);
            }

            public static void zwp_relative_pointer_v1_destroy([NativeTypeName("struct zwp_relative_pointer_v1 *")] zwp_relative_pointer_v1* zwp_relative_pointer_v1)
            {
                _ = wl_proxy_marshal_flags((IntPtr*)zwp_relative_pointer_v1, 0, null, wl_proxy_get_version((IntPtr*)zwp_relative_pointer_v1), (1 << 0));
            }

            [NativeTypeName("#define ZWP_RELATIVE_POINTER_MANAGER_V1_DESTROY 0")]
            public const int ZWP_RELATIVE_POINTER_MANAGER_V1_DESTROY = 0;

            [NativeTypeName("#define ZWP_RELATIVE_POINTER_MANAGER_V1_GET_RELATIVE_POINTER 1")]
            public const int ZWP_RELATIVE_POINTER_MANAGER_V1_GET_RELATIVE_POINTER = 1;

            [NativeTypeName("#define ZWP_RELATIVE_POINTER_MANAGER_V1_DESTROY_SINCE_VERSION 1")]
            public const int ZWP_RELATIVE_POINTER_MANAGER_V1_DESTROY_SINCE_VERSION = 1;

            [NativeTypeName("#define ZWP_RELATIVE_POINTER_MANAGER_V1_GET_RELATIVE_POINTER_SINCE_VERSION 1")]
            public const int ZWP_RELATIVE_POINTER_MANAGER_V1_GET_RELATIVE_POINTER_SINCE_VERSION = 1;

            [NativeTypeName("#define ZWP_RELATIVE_POINTER_V1_DESTROY 0")]
            public const int ZWP_RELATIVE_POINTER_V1_DESTROY = 0;

            [NativeTypeName("#define ZWP_RELATIVE_POINTER_V1_RELATIVE_MOTION_SINCE_VERSION 1")]
            public const int ZWP_RELATIVE_POINTER_V1_RELATIVE_MOTION_SINCE_VERSION = 1;

            [NativeTypeName("#define ZWP_RELATIVE_POINTER_V1_DESTROY_SINCE_VERSION 1")]
            public const int ZWP_RELATIVE_POINTER_V1_DESTROY_SINCE_VERSION = 1;
            
            public static IntPtr GetInterface(string interfaceName)
            {
                if (NativeLibrary.TryLoad("libwayland-client.so.0", out IntPtr handle))
                {
                    if (NativeLibrary.TryGetExport(handle, interfaceName, out IntPtr interfacePtr))
                    {
                        return interfacePtr;
                    }
                }
                throw new EntryPointNotFoundException($"Could not resolve {interfaceName} symbol.");
            }
        }

        /// <summary>Defines the type of a member as it was used in the native signature.</summary>
        [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = false, Inherited = true)]
        [Conditional("DEBUG")]
        internal sealed partial class NativeTypeNameAttribute : Attribute
        {
            private readonly string _name;

            /// <summary>Initializes a new instance of the <see cref="NativeTypeNameAttribute" /> class.</summary>
            /// <param name="name">The name of the type that was used in the native signature.</param>
            public NativeTypeNameAttribute(string name)
            {
                _name = name;
            }

            /// <summary>Gets the name of the type that was used in the native signature.</summary>
            public string Name => _name;
        }

        /// <summary>Defines the annotation found in a native declaration.</summary>
        [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = true, Inherited = false)]
        [Conditional("DEBUG")]
        internal sealed partial class NativeAnnotationAttribute : Attribute
        {
            private readonly string _annotation;

            /// <summary>Initializes a new instance of the <see cref="NativeAnnotationAttribute" /> class.</summary>
            /// <param name="annotation">The annotation that was used in the native declaration.</param>
            public NativeAnnotationAttribute(string annotation)
            {
                _annotation = annotation;
            }

            /// <summary>Gets the annotation that was used in the native declaration.</summary>
            public string Annotation => _annotation;
        }
    }
}
