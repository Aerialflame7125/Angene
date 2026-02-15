// X11Native.cs - Linux X11 windowing support
#if !WINDOWS
using System;
using System.Runtime.InteropServices;

namespace Angene.Platform.Linux
{
    // X11 bindings for Linux windowing
    public static class X11
    {
        private const string libX11 = "libX11.so.6";
        
        // Display and window types
        public struct Display { }
        public struct Window { }
        public struct GC { }
        
        // Event structures
        [StructLayout(LayoutKind.Explicit)]
        public struct XEvent
        {
            [FieldOffset(0)] public int type;
            [FieldOffset(0)] public XAnyEvent xany;
            [FieldOffset(0)] public XKeyEvent xkey;
            [FieldOffset(0)] public XButtonEvent xbutton;
            [FieldOffset(0)] public XMotionEvent xmotion;
            [FieldOffset(0)] public XExposeEvent xexpose;
            [FieldOffset(0)] public XConfigureEvent xconfigure;
            [FieldOffset(0)] public XClientMessageEvent xclient;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct XAnyEvent
        {
            public int type;
            public IntPtr serial;
            public int send_event;
            public IntPtr display;
            public IntPtr window;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct XKeyEvent
        {
            public int type;
            public IntPtr serial;
            public int send_event;
            public IntPtr display;
            public IntPtr window;
            public IntPtr root;
            public IntPtr subwindow;
            public IntPtr time;
            public int x, y;
            public int x_root, y_root;
            public uint state;
            public uint keycode;
            public int same_screen;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct XButtonEvent
        {
            public int type;
            public IntPtr serial;
            public int send_event;
            public IntPtr display;
            public IntPtr window;
            public IntPtr root;
            public IntPtr subwindow;
            public IntPtr time;
            public int x, y;
            public int x_root, y_root;
            public uint state;
            public uint button;
            public int same_screen;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct XMotionEvent
        {
            public int type;
            public IntPtr serial;
            public int send_event;
            public IntPtr display;
            public IntPtr window;
            public IntPtr root;
            public IntPtr subwindow;
            public IntPtr time;
            public int x, y;
            public int x_root, y_root;
            public uint state;
            public byte is_hint;
            public int same_screen;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct XExposeEvent
        {
            public int type;
            public IntPtr serial;
            public int send_event;
            public IntPtr display;
            public IntPtr window;
            public int x, y;
            public int width, height;
            public int count;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct XConfigureEvent
        {
            public int type;
            public IntPtr serial;
            public int send_event;
            public IntPtr display;
            public IntPtr window;
            public int x, y;
            public int width, height;
            public int border_width;
            public IntPtr above;
            public int override_redirect;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct XClientMessageEvent
        {
            public int type;
            public IntPtr serial;
            public int send_event;
            public IntPtr display;
            public IntPtr window;
            public IntPtr message_type;
            public int format;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public IntPtr[] data;
        }
        
        // Event types
        public const int KeyPress = 2;
        public const int KeyRelease = 3;
        public const int ButtonPress = 4;
        public const int ButtonRelease = 5;
        public const int MotionNotify = 6;
        public const int Expose = 12;
        public const int ConfigureNotify = 22;
        public const int ClientMessage = 33;
        
        // Event masks
        public const long NoEventMask = 0L;
        public const long KeyPressMask = (1L << 0);
        public const long KeyReleaseMask = (1L << 1);
        public const long ButtonPressMask = (1L << 2);
        public const long ButtonReleaseMask = (1L << 3);
        public const long PointerMotionMask = (1L << 6);
        public const long ExposureMask = (1L << 15);
        public const long StructureNotifyMask = (1L << 17);
        
        // Window attributes
        public const int CWBackPixel = (1 << 1);
        public const int CWEventMask = (1 << 11);
        
        [StructLayout(LayoutKind.Sequential)]
        public struct XSetWindowAttributes
        {
            public IntPtr background_pixmap;
            public ulong background_pixel;
            public IntPtr border_pixmap;
            public ulong border_pixel;
            public int bit_gravity;
            public int win_gravity;
            public int backing_store;
            public ulong backing_planes;
            public ulong backing_pixel;
            public int save_under;
            public long event_mask;
            public long do_not_propagate_mask;
            public int override_redirect;
            public IntPtr colormap;
            public IntPtr cursor;
        }
        
        // X11 function imports
        [DllImport(libX11)]
        public static extern IntPtr XOpenDisplay(IntPtr display);
        
        [DllImport(libX11)]
        public static extern int XCloseDisplay(IntPtr display);
        
        [DllImport(libX11)]
        public static extern int XDefaultScreen(IntPtr display);
        
        [DllImport(libX11)]
        public static extern IntPtr XRootWindow(IntPtr display, int screen_number);
        
        [DllImport(libX11)]
        public static extern ulong XBlackPixel(IntPtr display, int screen_number);
        
        [DllImport(libX11)]
        public static extern ulong XWhitePixel(IntPtr display, int screen_number);
        
        [DllImport(libX11)]
        public static extern IntPtr XCreateSimpleWindow(
            IntPtr display,
            IntPtr parent,
            int x, int y,
            uint width, uint height,
            uint border_width,
            ulong border,
            ulong background);
        
        [DllImport(libX11)]
        public static extern IntPtr XCreateWindow(
            IntPtr display,
            IntPtr parent,
            int x, int y,
            uint width, uint height,
            uint border_width,
            int depth,
            uint window_class,
            IntPtr visual,
            ulong valuemask,
            ref XSetWindowAttributes attributes);
        
        [DllImport(libX11)]
        public static extern int XSelectInput(IntPtr display, IntPtr window, long event_mask);
        
        [DllImport(libX11)]
        public static extern int XMapWindow(IntPtr display, IntPtr window);
        
        [DllImport(libX11)]
        public static extern int XStoreName(IntPtr display, IntPtr window, string window_name);
        
        [DllImport(libX11)]
        public static extern int XNextEvent(IntPtr display, out XEvent event_return);
        
        [DllImport(libX11)]
        public static extern int XPending(IntPtr display);
        
        [DllImport(libX11)]
        public static extern int XCheckMaskEvent(IntPtr display, long event_mask, out XEvent event_return);
        
        [DllImport(libX11)]
        public static extern int XDestroyWindow(IntPtr display, IntPtr window);
        
        [DllImport(libX11)]
        public static extern int XFlush(IntPtr display);
        
        [DllImport(libX11)]
        public static extern IntPtr XInternAtom(IntPtr display, string atom_name, bool only_if_exists);
        
        [DllImport(libX11)]
        public static extern int XSetWMProtocols(IntPtr display, IntPtr window, IntPtr[] protocols, int count);
        
        [DllImport(libX11)]
        public static extern IntPtr XCreateGC(IntPtr display, IntPtr drawable, ulong valuemask, IntPtr values);
        
        [DllImport(libX11)]
        public static extern int XFreeGC(IntPtr display, IntPtr gc);
        
        [DllImport(libX11)]
        public static extern int XSetForeground(IntPtr display, IntPtr gc, ulong foreground);
        
        [DllImport(libX11)]
        public static extern int XFillRectangle(IntPtr display, IntPtr drawable, IntPtr gc, int x, int y, uint width, uint height);
        
        [DllImport(libX11)]
        public static extern int XDrawString(IntPtr display, IntPtr drawable, IntPtr gc, int x, int y, string text, int length);
        
        [DllImport(libX11)]
        public static extern IntPtr XCreateImage(
            IntPtr display,
            IntPtr visual,
            uint depth,
            int format,
            int offset,
            IntPtr data,
            uint width,
            uint height,
            int bitmap_pad,
            int bytes_per_line);
        
        [DllImport(libX11)]
        public static extern int XPutImage(
            IntPtr display,
            IntPtr drawable,
            IntPtr gc,
            IntPtr image,
            int src_x, int src_y,
            int dest_x, int dest_y,
            uint width, uint height);
        
        [DllImport(libX11)]
        public static extern int XDestroyImage(IntPtr image);
        
        // Image formats
        public const int ZPixmap = 2;
    }
}
#endif