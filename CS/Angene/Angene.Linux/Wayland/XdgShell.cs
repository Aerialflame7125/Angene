using System.Runtime.InteropServices;
using static Angene.Linux.Wayland.WaylandClient;
using static Angene.Linux.Wayland.WaylandClient.Methods;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Angene.Linux.Wayland
{
    public unsafe class XdgShell
    {
        public partial struct xdg_popup
        {
        }

        public partial struct xdg_positioner
        {
        }

        public partial struct xdg_surface
        {
        }

        public partial struct xdg_toplevel
        {
        }

        public partial struct xdg_wm_base
        {
        }

        public enum xdg_wm_base_error : uint
        {
            XDG_WM_BASE_ERROR_ROLE = 0,
            XDG_WM_BASE_ERROR_DEFUNCT_SURFACES = 1,
            XDG_WM_BASE_ERROR_NOT_THE_TOPMOST_POPUP = 2,
            XDG_WM_BASE_ERROR_INVALID_POPUP_PARENT = 3,
            XDG_WM_BASE_ERROR_INVALID_SURFACE_STATE = 4,
            XDG_WM_BASE_ERROR_INVALID_POSITIONER = 5,
            XDG_WM_BASE_ERROR_UNRESPONSIVE = 6,
        }

        public unsafe partial struct xdg_wm_base_listener
        {
                public delegate* unmanaged[Cdecl]<void*, xdg_wm_base*, uint, void> ping;
        }

        public enum xdg_positioner_error : uint
        {
            XDG_POSITIONER_ERROR_INVALID_INPUT = 0,
        }

        public enum xdg_positioner_anchor : uint
        {
            XDG_POSITIONER_ANCHOR_NONE = 0,
            XDG_POSITIONER_ANCHOR_TOP = 1,
            XDG_POSITIONER_ANCHOR_BOTTOM = 2,
            XDG_POSITIONER_ANCHOR_LEFT = 3,
            XDG_POSITIONER_ANCHOR_RIGHT = 4,
            XDG_POSITIONER_ANCHOR_TOP_LEFT = 5,
            XDG_POSITIONER_ANCHOR_BOTTOM_LEFT = 6,
            XDG_POSITIONER_ANCHOR_TOP_RIGHT = 7,
            XDG_POSITIONER_ANCHOR_BOTTOM_RIGHT = 8,
        }

        public enum xdg_positioner_gravity : uint
        {
            XDG_POSITIONER_GRAVITY_NONE = 0,
            XDG_POSITIONER_GRAVITY_TOP = 1,
            XDG_POSITIONER_GRAVITY_BOTTOM = 2,
            XDG_POSITIONER_GRAVITY_LEFT = 3,
            XDG_POSITIONER_GRAVITY_RIGHT = 4,
            XDG_POSITIONER_GRAVITY_TOP_LEFT = 5,
            XDG_POSITIONER_GRAVITY_BOTTOM_LEFT = 6,
            XDG_POSITIONER_GRAVITY_TOP_RIGHT = 7,
            XDG_POSITIONER_GRAVITY_BOTTOM_RIGHT = 8,
        }

        public enum xdg_positioner_constraint_adjustment : uint
        {
            XDG_POSITIONER_CONSTRAINT_ADJUSTMENT_NONE = 0,
            XDG_POSITIONER_CONSTRAINT_ADJUSTMENT_SLIDE_X = 1,
            XDG_POSITIONER_CONSTRAINT_ADJUSTMENT_SLIDE_Y = 2,
            XDG_POSITIONER_CONSTRAINT_ADJUSTMENT_FLIP_X = 4,
            XDG_POSITIONER_CONSTRAINT_ADJUSTMENT_FLIP_Y = 8,
            XDG_POSITIONER_CONSTRAINT_ADJUSTMENT_RESIZE_X = 16,
            XDG_POSITIONER_CONSTRAINT_ADJUSTMENT_RESIZE_Y = 32,
        }

        public enum xdg_surface_error : uint
        {
            XDG_SURFACE_ERROR_NOT_CONSTRUCTED = 1,
            XDG_SURFACE_ERROR_ALREADY_CONSTRUCTED = 2,
            XDG_SURFACE_ERROR_UNCONFIGURED_BUFFER = 3,
            XDG_SURFACE_ERROR_INVALID_SERIAL = 4,
            XDG_SURFACE_ERROR_INVALID_SIZE = 5,
            XDG_SURFACE_ERROR_DEFUNCT_ROLE_OBJECT = 6,
        }

        public unsafe partial struct xdg_surface_listener
        {
                public delegate* unmanaged[Cdecl]<void*, xdg_surface*, uint, void> configure;
        }

        public enum xdg_toplevel_error : uint
        {
            XDG_TOPLEVEL_ERROR_INVALID_RESIZE_EDGE = 0,
            XDG_TOPLEVEL_ERROR_INVALID_PARENT = 1,
            XDG_TOPLEVEL_ERROR_INVALID_SIZE = 2,
        }

        public enum xdg_toplevel_resize_edge : uint
        {
            XDG_TOPLEVEL_RESIZE_EDGE_NONE = 0,
            XDG_TOPLEVEL_RESIZE_EDGE_TOP = 1,
            XDG_TOPLEVEL_RESIZE_EDGE_BOTTOM = 2,
            XDG_TOPLEVEL_RESIZE_EDGE_LEFT = 4,
            XDG_TOPLEVEL_RESIZE_EDGE_TOP_LEFT = 5,
            XDG_TOPLEVEL_RESIZE_EDGE_BOTTOM_LEFT = 6,
            XDG_TOPLEVEL_RESIZE_EDGE_RIGHT = 8,
            XDG_TOPLEVEL_RESIZE_EDGE_TOP_RIGHT = 9,
            XDG_TOPLEVEL_RESIZE_EDGE_BOTTOM_RIGHT = 10,
        }

        public enum xdg_toplevel_state : uint
        {
            XDG_TOPLEVEL_STATE_MAXIMIZED = 1,
            XDG_TOPLEVEL_STATE_FULLSCREEN = 2,
            XDG_TOPLEVEL_STATE_RESIZING = 3,
            XDG_TOPLEVEL_STATE_ACTIVATED = 4,
            XDG_TOPLEVEL_STATE_TILED_LEFT = 5,
            XDG_TOPLEVEL_STATE_TILED_RIGHT = 6,
            XDG_TOPLEVEL_STATE_TILED_TOP = 7,
            XDG_TOPLEVEL_STATE_TILED_BOTTOM = 8,
            XDG_TOPLEVEL_STATE_SUSPENDED = 9,
            XDG_TOPLEVEL_STATE_CONSTRAINED_LEFT = 10,
            XDG_TOPLEVEL_STATE_CONSTRAINED_RIGHT = 11,
            XDG_TOPLEVEL_STATE_CONSTRAINED_TOP = 12,
            XDG_TOPLEVEL_STATE_CONSTRAINED_BOTTOM = 13,
        }

        public enum xdg_toplevel_wm_capabilities : uint
        {
            XDG_TOPLEVEL_WM_CAPABILITIES_WINDOW_MENU = 1,
            XDG_TOPLEVEL_WM_CAPABILITIES_MAXIMIZE = 2,
            XDG_TOPLEVEL_WM_CAPABILITIES_FULLSCREEN = 3,
            XDG_TOPLEVEL_WM_CAPABILITIES_MINIMIZE = 4,
        }

        public unsafe partial struct xdg_toplevel_listener
        {
                public delegate* unmanaged[Cdecl]<void*, xdg_toplevel*, int, int, wl_array*, void> configure;

                public delegate* unmanaged[Cdecl]<void*, xdg_toplevel*, void> close;

                public delegate* unmanaged[Cdecl]<void*, xdg_toplevel*, int, int, void> configure_bounds;

                public delegate* unmanaged[Cdecl]<void*, xdg_toplevel*, wl_array*, void> wm_capabilities;
        }

        public enum xdg_popup_error : uint
        {
            XDG_POPUP_ERROR_INVALID_GRAB = 0,
        }

        public unsafe partial struct xdg_popup_listener
        {
                public delegate* unmanaged[Cdecl]<void*, xdg_popup*, int, int, int, int, void> configure;

                public delegate* unmanaged[Cdecl]<void*, xdg_popup*, void> popup_done;

                public delegate* unmanaged[Cdecl]<void*, xdg_popup*, uint, void> repositioned;
        }

        public static wl_interface* xdg_positioner_interface = (wl_interface*)Methods.XdgPositionerInterface;
        public static wl_interface* xdg_surface_interface = (wl_interface*)Methods.XdgSurfaceInterface;
        public static wl_interface* xdg_toplevel_interface = (wl_interface*)Methods.XdgToplevelInterface;
        public static wl_interface* xdg_popup_interface = (wl_interface*)Methods.XdgPopupInterface;

        public static unsafe partial class Methods
        {
            public static int xdg_wm_base_add_listener(xdg_wm_base* xdg_wm_base, xdg_wm_base_listener* listener, void* data)
            {
                return wl_proxy_add_listener(unchecked((IntPtr)xdg_wm_base), unchecked((IntPtr)listener), data);
            }

            public static void xdg_wm_base_set_user_data(xdg_wm_base* xdg_wm_base, void* user_data)
            {
                wl_proxy_set_user_data(unchecked((IntPtr*)(xdg_wm_base)), user_data);
            }

            public static void* xdg_wm_base_get_user_data(xdg_wm_base* xdg_wm_base)
            {
                return wl_proxy_get_user_data((IntPtr*)(xdg_wm_base));
            }

            public static uint xdg_wm_base_get_version(xdg_wm_base* xdg_wm_base)
            {
                return wl_proxy_get_version((IntPtr*)(xdg_wm_base));
            }

            public static void xdg_wm_base_destroy(xdg_wm_base* xdg_wm_base)
            {
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_wm_base), 0, null, wl_proxy_get_version((IntPtr*)(xdg_wm_base)), (1 << 0), null);
            }

            public static xdg_positioner* xdg_wm_base_create_positioner(xdg_wm_base* xdg_wm_base)
            {
                IntPtr* id;

                wl_argument* __args = stackalloc wl_argument[1];
                __args[0].o = IntPtr.Zero;
                id = wl_proxy_marshal_array_flags((IntPtr*)(xdg_wm_base), 1, xdg_positioner_interface, wl_proxy_get_version((IntPtr*)(xdg_wm_base)), 0, __args);
                return (xdg_positioner*)(id);
            }

            public static xdg_surface* xdg_wm_base_get_xdg_surface(xdg_wm_base* xdg_wm_base, wl_surface* surface)
            {
                IntPtr* id;

                wl_argument* __args = stackalloc wl_argument[2];
                __args[0].o = IntPtr.Zero;
                __args[1].o = (IntPtr)(surface);
                id = wl_proxy_marshal_array_flags((IntPtr*)(xdg_wm_base), 2, xdg_surface_interface, wl_proxy_get_version((IntPtr*)(xdg_wm_base)), 0, __args);
                return (xdg_surface*)(id);
            }

            public static void xdg_wm_base_pong(xdg_wm_base* xdg_wm_base, uint serial)
            {
                wl_argument* __args = stackalloc wl_argument[1];
                __args[0].u = serial;
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_wm_base), 3, null, wl_proxy_get_version((IntPtr*)(xdg_wm_base)), 0, __args);
            }

            public static void xdg_positioner_set_user_data(xdg_positioner* xdg_positioner, void* user_data)
            {
                wl_proxy_set_user_data(unchecked((IntPtr*)(xdg_positioner)), user_data);
            }

            public static void* xdg_positioner_get_user_data(xdg_positioner* xdg_positioner)
            {
                return wl_proxy_get_user_data((IntPtr*)(xdg_positioner));
            }

            public static uint xdg_positioner_get_version(xdg_positioner* xdg_positioner)
            {
                return wl_proxy_get_version((IntPtr*)(xdg_positioner));
            }

            public static void xdg_positioner_destroy(xdg_positioner* xdg_positioner)
            {
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_positioner), 0, null, wl_proxy_get_version((IntPtr*)(xdg_positioner)), (1 << 0), null);
            }

            public static void xdg_positioner_set_size(xdg_positioner* xdg_positioner, int width, int height)
            {
                wl_argument* __args = stackalloc wl_argument[2];
                __args[0].i = width;
                __args[1].i = height;
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_positioner), 1, null, wl_proxy_get_version((IntPtr*)(xdg_positioner)), 0, __args);
            }

            public static void xdg_positioner_set_anchor_rect(xdg_positioner* xdg_positioner, int x, int y, int width, int height)
            {
                wl_argument* __args = stackalloc wl_argument[4];
                __args[0].i = x;
                __args[1].i = y;
                __args[2].i = width;
                __args[3].i = height;
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_positioner), 2, null, wl_proxy_get_version((IntPtr*)(xdg_positioner)), 0, __args);
            }

            public static void xdg_positioner_set_anchor(xdg_positioner* xdg_positioner, uint anchor)
            {
                wl_argument* __args = stackalloc wl_argument[1];
                __args[0].u = anchor;
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_positioner), 3, null, wl_proxy_get_version((IntPtr*)(xdg_positioner)), 0, __args);
            }

            public static void xdg_positioner_set_gravity(xdg_positioner* xdg_positioner, uint gravity)
            {
                wl_argument* __args = stackalloc wl_argument[1];
                __args[0].u = gravity;
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_positioner), 4, null, wl_proxy_get_version((IntPtr*)(xdg_positioner)), 0, __args);
            }

            public static void xdg_positioner_set_constraint_adjustment(xdg_positioner* xdg_positioner, uint constraint_adjustment)
            {
                wl_argument* __args = stackalloc wl_argument[1];
                __args[0].u = constraint_adjustment;
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_positioner), 5, null, wl_proxy_get_version((IntPtr*)(xdg_positioner)), 0, __args);
            }

            public static void xdg_positioner_set_offset(xdg_positioner* xdg_positioner, int x, int y)
            {
                wl_argument* __args = stackalloc wl_argument[2];
                __args[0].i = x;
                __args[1].i = y;
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_positioner), 6, null, wl_proxy_get_version((IntPtr*)(xdg_positioner)), 0, __args);
            }

            public static void xdg_positioner_set_reactive(xdg_positioner* xdg_positioner)
            {
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_positioner), 7, null, wl_proxy_get_version((IntPtr*)(xdg_positioner)), 0, null);
            }

            public static void xdg_positioner_set_parent_size(xdg_positioner* xdg_positioner, int parent_width, int parent_height)
            {
                wl_argument* __args = stackalloc wl_argument[2];
                __args[0].i = parent_width;
                __args[1].i = parent_height;
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_positioner), 8, null, wl_proxy_get_version((IntPtr*)(xdg_positioner)), 0, __args);
            }

            public static void xdg_positioner_set_parent_configure(xdg_positioner* xdg_positioner, uint serial)
            {
                wl_argument* __args = stackalloc wl_argument[1];
                __args[0].u = serial;
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_positioner), 9, null, wl_proxy_get_version((IntPtr*)(xdg_positioner)), 0, __args);
            }

            public static int xdg_surface_add_listener(xdg_surface* xdg_surface, xdg_surface_listener* listener, void* data)
            {
                return wl_proxy_add_listener(unchecked((IntPtr)(xdg_surface)), unchecked((IntPtr)(listener)), data);
            }

            public static void xdg_surface_set_user_data(xdg_surface* xdg_surface, void* user_data)
            {
                wl_proxy_set_user_data(unchecked((IntPtr*)(xdg_surface)), user_data);
            }

            public static void* xdg_surface_get_user_data(xdg_surface* xdg_surface)
            {
                return wl_proxy_get_user_data((IntPtr*)(xdg_surface));
            }

            public static uint xdg_surface_get_version(xdg_surface* xdg_surface)
            {
                return wl_proxy_get_version((IntPtr*)(xdg_surface));
            }

            public static void xdg_surface_destroy(xdg_surface* xdg_surface)
            {
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_surface), 0, null, wl_proxy_get_version((IntPtr*)(xdg_surface)), (1 << 0), null);
            }

            public static xdg_toplevel* xdg_surface_get_toplevel(xdg_surface* xdg_surface)
            {
                IntPtr* id;

                wl_argument* __args = stackalloc wl_argument[1];
                __args[0].o = IntPtr.Zero;
                id = wl_proxy_marshal_array_flags((IntPtr*)(xdg_surface), 1, xdg_toplevel_interface, wl_proxy_get_version((IntPtr*)(xdg_surface)), 0, __args);
                return (xdg_toplevel*)(id);
            }

            public static xdg_popup* xdg_surface_get_popup(xdg_surface* xdg_surface, xdg_surface* parent, xdg_positioner* positioner)
            {
                IntPtr* id;

                wl_argument* __args = stackalloc wl_argument[3];
                __args[0].o = IntPtr.Zero;
                __args[1].o = (IntPtr)(parent);
                __args[2].o = (IntPtr)(positioner);
                id = wl_proxy_marshal_array_flags((IntPtr*)(xdg_surface), 2, xdg_popup_interface, wl_proxy_get_version((IntPtr*)(xdg_surface)), 0, __args);
                return (xdg_popup*)(id);
            }

            public static void xdg_surface_set_window_geometry(xdg_surface* xdg_surface, int x, int y, int width, int height)
            {
                wl_argument* __args = stackalloc wl_argument[4];
                __args[0].i = x;
                __args[1].i = y;
                __args[2].i = width;
                __args[3].i = height;
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_surface), 3, null, wl_proxy_get_version((IntPtr*)(xdg_surface)), 0, __args);
            }

            public static void xdg_surface_ack_configure(xdg_surface* xdg_surface, uint serial)
            {
                wl_argument* __args = stackalloc wl_argument[1];
                __args[0].u = serial;
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_surface), 4, null, wl_proxy_get_version((IntPtr*)(xdg_surface)), 0, __args);
            }

            public static int xdg_toplevel_add_listener(xdg_toplevel* xdg_toplevel, xdg_toplevel_listener* listener, void* data)
            {
                return wl_proxy_add_listener(unchecked((IntPtr)(xdg_toplevel)), unchecked((IntPtr)(listener)), data);
            }

            public static void xdg_toplevel_set_user_data(xdg_toplevel* xdg_toplevel, void* user_data)
            {
                wl_proxy_set_user_data(unchecked((IntPtr*)(xdg_toplevel)), user_data);
            }

            public static void* xdg_toplevel_get_user_data(xdg_toplevel* xdg_toplevel)
            {
                return wl_proxy_get_user_data((IntPtr*)(xdg_toplevel));
            }

            public static uint xdg_toplevel_get_version(xdg_toplevel* xdg_toplevel)
            {
                return wl_proxy_get_version((IntPtr*)(xdg_toplevel));
            }

            public static void xdg_toplevel_destroy(xdg_toplevel* xdg_toplevel)
            {
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_toplevel), 0, null, wl_proxy_get_version((IntPtr*)(xdg_toplevel)), (1 << 0), null);
            }

            public static void xdg_toplevel_set_parent(xdg_toplevel* xdg_toplevel, xdg_toplevel* parent)
            {
                wl_argument* __args = stackalloc wl_argument[1];
                __args[0].o = (IntPtr)(parent);
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_toplevel), 1, null, wl_proxy_get_version((IntPtr*)(xdg_toplevel)), 0, __args);
            }

            public static void xdg_toplevel_set_title(xdg_toplevel* xdg_toplevel, sbyte* title)
            {
                wl_argument* __args = stackalloc wl_argument[1];
                __args[0].s = (IntPtr)(title);
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_toplevel), 2, null, wl_proxy_get_version((IntPtr*)(xdg_toplevel)), 0, __args);
            }

            public static void xdg_toplevel_set_app_id(xdg_toplevel* xdg_toplevel, sbyte* app_id)
            {
                wl_argument* __args = stackalloc wl_argument[1];
                __args[0].s = (IntPtr)(app_id);
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_toplevel), 3, null, wl_proxy_get_version((IntPtr*)(xdg_toplevel)), 0, __args);
            }

            public static void xdg_toplevel_show_window_menu(xdg_toplevel* xdg_toplevel, wl_seat* seat, uint serial, int x, int y)
            {
                wl_argument* __args = stackalloc wl_argument[4];
                __args[0].o = (IntPtr)(seat);
                __args[1].u = serial;
                __args[2].i = x;
                __args[3].i = y;
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_toplevel), 4, null, wl_proxy_get_version((IntPtr*)(xdg_toplevel)), 0, __args);
            }

            public static void xdg_toplevel_move(xdg_toplevel* xdg_toplevel, wl_seat* seat, uint serial)
            {
                wl_argument* __args = stackalloc wl_argument[2];
                __args[0].o = (IntPtr)(seat);
                __args[1].u = serial;
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_toplevel), 5, null, wl_proxy_get_version((IntPtr*)(xdg_toplevel)), 0, __args);
            }

            public static void xdg_toplevel_resize(xdg_toplevel* xdg_toplevel, wl_seat* seat, uint serial, uint edges)
            {
                wl_argument* __args = stackalloc wl_argument[3];
                __args[0].o = (IntPtr)(seat);
                __args[1].u = serial;
                __args[2].u = edges;
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_toplevel), 6, null, wl_proxy_get_version((IntPtr*)(xdg_toplevel)), 0, __args);
            }

            public static void xdg_toplevel_set_max_size(xdg_toplevel* xdg_toplevel, int width, int height)
            {
                wl_argument* __args = stackalloc wl_argument[2];
                __args[0].i = width;
                __args[1].i = height;
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_toplevel), 7, null, wl_proxy_get_version((IntPtr*)(xdg_toplevel)), 0, __args);
            }

            public static void xdg_toplevel_set_min_size(xdg_toplevel* xdg_toplevel, int width, int height)
            {
                wl_argument* __args = stackalloc wl_argument[2];
                __args[0].i = width;
                __args[1].i = height;
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_toplevel), 8, null, wl_proxy_get_version((IntPtr*)(xdg_toplevel)), 0, __args);
            }

            public static void xdg_toplevel_set_maximized(xdg_toplevel* xdg_toplevel)
            {
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_toplevel), 9, null, wl_proxy_get_version((IntPtr*)(xdg_toplevel)), 0, null);
            }

            public static void xdg_toplevel_unset_maximized(xdg_toplevel* xdg_toplevel)
            {
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_toplevel), 10, null, wl_proxy_get_version((IntPtr*)(xdg_toplevel)), 0, null);
            }

            public static void xdg_toplevel_set_fullscreen(xdg_toplevel* xdg_toplevel, wl_output* output)
            {
                wl_argument* __args = stackalloc wl_argument[1];
                __args[0].o = (IntPtr)(output);
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_toplevel), 11, null, wl_proxy_get_version((IntPtr*)(xdg_toplevel)), 0, __args);
            }

            public static void xdg_toplevel_unset_fullscreen(xdg_toplevel* xdg_toplevel)
            {
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_toplevel), 12, null, wl_proxy_get_version((IntPtr*)(xdg_toplevel)), 0, null);
            }

            public static void xdg_toplevel_set_minimized(xdg_toplevel* xdg_toplevel)
            {
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_toplevel), 13, null, wl_proxy_get_version((IntPtr*)(xdg_toplevel)), 0, null);
            }

            public static int xdg_popup_add_listener(xdg_popup* xdg_popup, xdg_popup_listener* listener, void* data)
            {
                return wl_proxy_add_listener(unchecked((IntPtr)(xdg_popup)), unchecked((IntPtr)(listener)), data);
            }

            public static void xdg_popup_set_user_data(xdg_popup* xdg_popup, void* user_data)
            {
                wl_proxy_set_user_data(unchecked((IntPtr*)(xdg_popup)), user_data);
            }

            public static void* xdg_popup_get_user_data(xdg_popup* xdg_popup)
            {
                return wl_proxy_get_user_data((IntPtr*)(xdg_popup));
            }

            public static uint xdg_popup_get_version(xdg_popup* xdg_popup)
            {
                return wl_proxy_get_version((IntPtr*)(xdg_popup));
            }

            public static void xdg_popup_destroy(xdg_popup* xdg_popup)
            {
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_popup), 0, null, wl_proxy_get_version((IntPtr*)(xdg_popup)), (1 << 0), null);
            }

            public static void xdg_popup_grab(xdg_popup* xdg_popup, wl_seat* seat, uint serial)
            {
                wl_argument* __args = stackalloc wl_argument[2];
                __args[0].o = (IntPtr)(seat);
                __args[1].u = serial;
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_popup), 1, null, wl_proxy_get_version((IntPtr*)(xdg_popup)), 0, __args);
            }

            public static void xdg_popup_reposition(xdg_popup* xdg_popup, xdg_positioner* positioner, uint token)
            {
                wl_argument* __args = stackalloc wl_argument[2];
                __args[0].o = (IntPtr)(positioner);
                __args[1].u = token;
                _ = wl_proxy_marshal_array_flags((IntPtr*)(xdg_popup), 2, null, wl_proxy_get_version((IntPtr*)(xdg_popup)), 0, __args);
            }
            
            private static readonly string LibPath = Path.Combine(Path.GetTempPath(), "Angene", "libxdg", "Native", "linux-x64", "libxdg-shell-client.so");
            private static IntPtr _libHandle = IntPtr.Zero;
            private static readonly object _lock = new();

            private static IntPtr _positionerPtr;
            private static IntPtr _surfacePtr;
            private static IntPtr _toplevelPtr;
            private static IntPtr _popupPtr;
            private static IntPtr _wmBasePtr;
            
            public static IntPtr XdgPositionerInterface => GetExport(ref _positionerPtr, "xdg_positioner_interface");
            public static IntPtr XdgSurfaceInterface    => GetExport(ref _surfacePtr, "xdg_surface_interface");
            public static IntPtr XdgToplevelInterface   => GetExport(ref _toplevelPtr, "xdg_toplevel_interface");
            public static IntPtr XdgPopupInterface      => GetExport(ref _popupPtr, "xdg_popup_interface");
            public static IntPtr XdgWmBaseInterface     => GetExport(ref _wmBasePtr, "xdg_wm_base_interface");

            private static IntPtr GetExport(ref IntPtr cacheField, string symbolName)
            {
                if (cacheField == IntPtr.Zero)
                {
                    lock (_lock)
                    {
                        if (cacheField == IntPtr.Zero)
                        {
                            IntPtr handle = EnsureLibraryLoaded();
                            if (!NativeLibrary.TryGetExport(handle, symbolName, out cacheField))
                            {
                                throw new EntryPointNotFoundException($"Could not resolve native symbol: '{symbolName}'.");
                            }
                        }
                    }
                }
                return cacheField;
            }

            private static IntPtr EnsureLibraryLoaded()
            {
                if (_libHandle != IntPtr.Zero) return _libHandle;

                ExtractNativeDll();

                if (!NativeLibrary.TryLoad(LibPath, out _libHandle))
                {
                    throw new DllNotFoundException($"Failed to load native library from path: '{LibPath}'.");
                }

                return _libHandle;
            }

            private static void ExtractNativeDll()
            {
                if (File.Exists(LibPath)) return;

                string targetDir = Path.GetDirectoryName(LibPath);
                Directory.CreateDirectory(targetDir);

                var assembly = Assembly.GetExecutingAssembly();
                string resourceName = $"{assembly.GetName().Name}.Native.linux-x64.libxdg-shell-client.so";

                using Stream stream = assembly.GetManifestResourceStream(resourceName);
                if (stream == null)
                {
                    throw new FileNotFoundException($"Could not find embedded resource: '{resourceName}'");
                }

                using FileStream fileStream = new FileStream(LibPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, FileOptions.SequentialScan);
                stream.CopyTo(fileStream);
            }
        }
    }
}