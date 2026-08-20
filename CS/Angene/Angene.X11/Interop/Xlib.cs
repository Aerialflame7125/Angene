using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Angene.X11.Interop;

public class XLib
{
    public const long SubstructureNotifyMask = 0x00080000;
    public const long SubstructureRedirectMask = 0x00100000;
    public enum XEventMask : long
    {
        NoEventMask = 0,
        KeyPressMask = 1L << 0,
        KeyReleaseMask = 1L << 1,
        ButtonPressMask = 1L << 2,
        ButtonReleaseMask = 1L << 3,
        EnterWindowMask = 1L << 4,
        LeaveWindowMask = 1L << 5,
        PointerMotionMask = 1L << 6,
        PointerMotionHintMask = 1L << 7,
        Button1MotionMask = 1L << 8,
        Button2MotionMask = 1L << 9,
        Button3MotionMask = 1L << 10,
        Button4MotionMask = 1L << 11,
        Button5MotionMask = 1L << 12,
        ButtonMotionMask = 1L << 13,
        KeymapStateMask = 1L << 14,
        ExposureMask = 1L << 15,
        VisibilityChangeMask = 1L << 16,
        StructureNotifyMask = 1L << 17,
        ResizeRedirectMask = 1L << 18,
        SubstructureNotifyMask = 1L << 19,
        SubstructureRedirectMask = 1L << 20,
        FocusChangeMask = 1L << 21,
        PropertyChangeMask = 1L << 22,
        ColormapChangeMask = 1L << 23,
        OwnerGrabButtonMask = (long)0x02000000
    }
    public unsafe partial struct _XExtData
    {
        public int number;

            public _XExtData* next;

            public delegate* unmanaged[Cdecl]<_XExtData*, int> free_private;

            public sbyte* private_data;
    }

    public partial struct XExtCodes
    {
        public int extension;

        public int major_opcode;

        public int first_event;

        public int first_error;
    }

    public partial struct XPixmapFormatValues
    {
        public int depth;

        public int bits_per_pixel;

        public int scanline_pad;
    }

    public partial struct XGCValues
    {
        public int function;

            public nuint plane_mask;

            public nuint foreground;

            public nuint background;

        public int line_width;

        public int line_style;

        public int cap_style;

        public int join_style;

        public int fill_style;

        public int fill_rule;

        public int arc_mode;

            public nuint tile;

            public nuint stipple;

        public int ts_x_origin;

        public int ts_y_origin;

            public nuint font;

        public int subwindow_mode;

        public int graphics_exposures;

        public int clip_x_origin;

        public int clip_y_origin;

            public nuint clip_mask;

        public int dash_offset;

            public sbyte dashes;
    }

    public partial struct _XGC
    {
    }

    public unsafe partial struct Visual
    {
            public _XExtData* ext_data;

            public nuint visualid;

        public int c_class;

            public nuint red_mask;

            public nuint green_mask;

            public nuint blue_mask;

        public int bits_per_rgb;

        public int map_entries;
    }

    public unsafe partial struct Depth
    {
        public int depth;

        public int nvisuals;

        public Visual* visuals;
    }

    public partial struct _XDisplay
    {
    }

    public unsafe partial struct Screen
    {
            public _XExtData* ext_data;

            public _XDisplay* display;

            public nuint root;

        public int width;

        public int height;

        public int mwidth;

        public int mheight;

        public int ndepths;

        public Depth* depths;

        public int root_depth;

        public Visual* root_visual;

            public _XGC* default_gc;

            public nuint cmap;

            public nuint white_pixel;

            public nuint black_pixel;

        public int max_maps;

        public int min_maps;

        public int backing_store;

        public int save_unders;

            public nint root_input_mask;
    }

    public unsafe partial struct ScreenFormat
    {
            public _XExtData* ext_data;

        public int depth;

        public int bits_per_pixel;

        public int scanline_pad;
    }

    public partial struct XSetWindowAttributes
    {
            public nuint background_pixmap;

            public nuint background_pixel;

            public nuint border_pixmap;

            public nuint border_pixel;

        public int bit_gravity;

        public int win_gravity;

        public int backing_store;

            public nuint backing_planes;

            public nuint backing_pixel;

        public int save_under;

            public nint event_mask;

            public nint do_not_propagate_mask;

        public int override_redirect;

            public nuint colormap;

            public nuint cursor;
    }

    public unsafe partial struct XWindowAttributes
    {
        public int x;

        public int y;

        public int width;

        public int height;

        public int border_width;

        public int depth;

        public Visual* visual;

            public nuint root;

        public int c_class;

        public int bit_gravity;

        public int win_gravity;

        public int backing_store;

            public nuint backing_planes;

            public nuint backing_pixel;

        public int save_under;

            public nuint colormap;

        public int map_installed;

        public int map_state;

            public nint all_event_masks;

            public nint your_event_mask;

            public nint do_not_propagate_mask;

        public int override_redirect;

        public Screen* screen;
    }

    public unsafe partial struct XHostAddress
    {
        public int family;

        public int length;

            public sbyte* address;
    }

    public unsafe partial struct XServerInterpretedAddress
    {
        public int typelength;

        public int valuelength;

            public sbyte* type;

            public sbyte* value;
    }

    public unsafe partial struct _XImage
    {
        public int width;

        public int height;

        public int xoffset;

        public int format;

            public sbyte* data;

        public int byte_order;

        public int bitmap_unit;

        public int bitmap_bit_order;

        public int bitmap_pad;

        public int depth;

        public int bytes_per_line;

        public int bits_per_pixel;

            public nuint red_mask;

            public nuint green_mask;

            public nuint blue_mask;

            public sbyte* obdata;

            public _XImage.funcs f;

        public unsafe partial struct funcs
        {
                    public delegate* unmanaged[Cdecl]<_XDisplay*, Visual*, uint, int, int, sbyte*, uint, uint, int, int, _XImage*> create_image;

                    public delegate* unmanaged[Cdecl]<_XImage*, int> destroy_image;

                    public delegate* unmanaged[Cdecl]<_XImage*, int, int, nuint> get_pixel;

                    public delegate* unmanaged[Cdecl]<_XImage*, int, int, nuint, int> put_pixel;

                    public delegate* unmanaged[Cdecl]<_XImage*, int, int, uint, uint, _XImage*> sub_image;

                    public delegate* unmanaged[Cdecl]<_XImage*, nint, int> add_pixel;
        }
    }

    public partial struct XWindowChanges
    {
        public int x;

        public int y;

        public int width;

        public int height;

        public int border_width;

            public nuint sibling;

        public int stack_mode;
    }

    public partial struct XColor
    {
            public nuint pixel;

            public ushort red;

            public ushort green;

            public ushort blue;

            public sbyte flags;

            public sbyte pad;
    }

    public partial struct XSegment
    {
        public short x1;

        public short y1;

        public short x2;

        public short y2;
    }

    public partial struct XPoint
    {
        public short x;

        public short y;
    }

    public partial struct XRectangle
    {
        public short x;

        public short y;

            public ushort width;

            public ushort height;
    }

    public partial struct XArc
    {
        public short x;

        public short y;

            public ushort width;

            public ushort height;

        public short angle1;

        public short angle2;
    }

    public partial struct XKeyboardControl
    {
        public int key_click_percent;

        public int bell_percent;

        public int bell_pitch;

        public int bell_duration;

        public int led;

        public int led_mode;

        public int key;

        public int auto_repeat_mode;
    }

    public partial struct XKeyboardState
    {
        public int key_click_percent;

        public int bell_percent;

            public uint bell_pitch;

            public uint bell_duration;

            public nuint led_mask;

        public int global_auto_repeat;

            public _auto_repeats_e__FixedBuffer auto_repeats;

        [InlineArray(32)]
        public partial struct _auto_repeats_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public partial struct XTimeCoord
    {
            public nuint time;

        public short x;

        public short y;
    }

    public unsafe partial struct XModifierKeymap
    {
        public int max_keypermod;

            public byte* modifiermap;
    }

    public partial struct _XPrivate
    {
    }

    public partial struct _XrmHashBucketRec
    {
    }

    public unsafe partial struct _Anonymous_e__Struct
    {
            public _XExtData* ext_data;

            public _XPrivate* private1;

        public int fd;

        public int private2;

        public int proto_major_version;

        public int proto_minor_version;

            public sbyte* vendor;

            public nuint private3;

            public nuint private4;

            public nuint private5;

        public int private6;

            public delegate* unmanaged[Cdecl]<_XDisplay*, nuint> resource_alloc;

        public int byte_order;

        public int bitmap_unit;

        public int bitmap_pad;

        public int bitmap_bit_order;

        public int nformats;

        public ScreenFormat* pixmap_format;

        public int private8;

        public int release;

            public _XPrivate* private9;

            public _XPrivate* private10;

        public int qlen;

            public nuint last_request_read;

            public nuint request;

            public sbyte* private11;

            public sbyte* private12;

            public sbyte* private13;

            public sbyte* private14;

            public uint max_request_size;

            public _XrmHashBucketRec* db;

            public delegate* unmanaged[Cdecl]<_XDisplay*, int> private15;

            public sbyte* display_name;

        public int default_screen;

        public int nscreens;

        public Screen* screens;

            public nuint motion_buffer;

            public nuint private16;

        public int min_keycode;

        public int max_keycode;

            public sbyte* private17;

            public sbyte* private18;

        public int private19;

            public sbyte* xdefaults;
    }

    public unsafe partial struct XKeyEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint window;

            public nuint root;

            public nuint subwindow;

            public nuint time;

        public int x;

        public int y;

        public int x_root;

        public int y_root;

            public uint state;

            public uint keycode;

        public int same_screen;
    }

    public unsafe partial struct XButtonEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint window;

            public nuint root;

            public nuint subwindow;

            public nuint time;

        public int x;

        public int y;

        public int x_root;

        public int y_root;

            public uint state;

            public uint button;

        public int same_screen;
    }

    public unsafe partial struct XMotionEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint window;

            public nuint root;

            public nuint subwindow;

            public nuint time;

        public int x;

        public int y;

        public int x_root;

        public int y_root;

            public uint state;

            public sbyte is_hint;

        public int same_screen;
    }

    public unsafe partial struct XCrossingEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint window;

            public nuint root;

            public nuint subwindow;

            public nuint time;

        public int x;

        public int y;

        public int x_root;

        public int y_root;

        public int mode;

        public int detail;

        public int same_screen;

        public int focus;

            public uint state;
    }

    public unsafe partial struct XFocusChangeEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint window;

        public int mode;

        public int detail;
    }

    public unsafe partial struct XKeymapEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint window;

            public _key_vector_e__FixedBuffer key_vector;

        [InlineArray(32)]
        public partial struct _key_vector_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct XExposeEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint window;

        public int x;

        public int y;

        public int width;

        public int height;

        public int count;
    }

    public unsafe partial struct XGraphicsExposeEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint drawable;

        public int x;

        public int y;

        public int width;

        public int height;

        public int count;

        public int major_code;

        public int minor_code;
    }

    public unsafe partial struct XNoExposeEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint drawable;

        public int major_code;

        public int minor_code;
    }

    public unsafe partial struct XVisibilityEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint window;

        public int state;
    }

    public unsafe partial struct XCreateWindowEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint parent;

            public nuint window;

        public int x;

        public int y;

        public int width;

        public int height;

        public int border_width;

        public int override_redirect;
    }

    public unsafe partial struct XDestroyWindowEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint @event;

            public nuint window;
    }

    public unsafe partial struct XUnmapEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint @event;

            public nuint window;

        public int from_configure;
    }

    public unsafe partial struct XMapEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint @event;

            public nuint window;

        public int override_redirect;
    }

    public unsafe partial struct XMapRequestEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint parent;

            public nuint window;
    }

    public unsafe partial struct XReparentEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint @event;

            public nuint window;

            public nuint parent;

        public int x;

        public int y;

        public int override_redirect;
    }

    public unsafe partial struct XConfigureEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint @event;

            public nuint window;

        public int x;

        public int y;

        public int width;

        public int height;

        public int border_width;

            public nuint above;

        public int override_redirect;
    }

    public unsafe partial struct XGravityEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint @event;

            public nuint window;

        public int x;

        public int y;
    }

    public unsafe partial struct XResizeRequestEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint window;

        public int width;

        public int height;
    }

    public unsafe partial struct XConfigureRequestEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint parent;

            public nuint window;

        public int x;

        public int y;

        public int width;

        public int height;

        public int border_width;

            public nuint above;

        public int detail;

            public nuint value_mask;
    }

    public unsafe partial struct XCirculateEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint @event;

            public nuint window;

        public int place;
    }

    public unsafe partial struct XCirculateRequestEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint parent;

            public nuint window;

        public int place;
    }

    public unsafe partial struct XPropertyEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint window;

            public nuint atom;

            public nuint time;

        public int state;
    }

    public unsafe partial struct XSelectionClearEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint window;

            public nuint selection;

            public nuint time;
    }

    public unsafe partial struct XSelectionRequestEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint owner;

            public nuint requestor;

            public nuint selection;

            public nuint target;

            public nuint property;

            public nuint time;
    }

    public unsafe partial struct XSelectionEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint requestor;

            public nuint selection;

            public nuint target;

            public nuint property;

            public nuint time;
    }

    public unsafe partial struct XColormapEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint window;

            public nuint colormap;

        public int c_new;

        public int state;
    }

    public unsafe partial struct XClientMessageEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint window;

            public nuint message_type;

        public int format;

            public _data_e__Union data;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _data_e__Union
        {
            [FieldOffset(0)]
                    public _b_e__FixedBuffer b;

            [FieldOffset(0)]
                    public _s_e__FixedBuffer s;

            [FieldOffset(0)]
                    public _l_e__FixedBuffer l;

            [InlineArray(20)]
            public partial struct _b_e__FixedBuffer
            {
                public sbyte e0;
            }

            [InlineArray(10)]
            public partial struct _s_e__FixedBuffer
            {
                public short e0;
            }

            [InlineArray(5)]
            public partial struct _l_e__FixedBuffer
            {
                public nint e0;
            }
        }
    }

    public unsafe partial struct XMappingEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint window;

        public int request;

        public int first_keycode;

        public int count;
    }

    public unsafe partial struct XErrorEvent
    {
        public int type;

            public _XDisplay* display;

            public nuint resourceid;

            public nuint serial;

            public byte error_code;

            public byte request_code;

            public byte minor_code;
    }

    public unsafe partial struct XAnyEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

            public nuint window;
    }

    public unsafe partial struct XGenericEvent
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

        public int extension;

        public int evtype;
    }

    public unsafe partial struct XGenericEventCookie
    {
        public int type;

            public nuint serial;

        public int send_event;

            public _XDisplay* display;

        public int extension;

        public int evtype;

            public uint cookie;

        public void* data;
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct _XEvent
    {
        [FieldOffset(0)]
        public int type;

        [FieldOffset(0)]
        public XAnyEvent xany;

        [FieldOffset(0)]
        public XKeyEvent xkey;

        [FieldOffset(0)]
        public XButtonEvent xbutton;

        [FieldOffset(0)]
        public XMotionEvent xmotion;

        [FieldOffset(0)]
        public XCrossingEvent xcrossing;

        [FieldOffset(0)]
        public XFocusChangeEvent xfocus;

        [FieldOffset(0)]
        public XExposeEvent xexpose;

        [FieldOffset(0)]
        public XGraphicsExposeEvent xgraphicsexpose;

        [FieldOffset(0)]
        public XNoExposeEvent xnoexpose;

        [FieldOffset(0)]
        public XVisibilityEvent xvisibility;

        [FieldOffset(0)]
        public XCreateWindowEvent xcreatewindow;

        [FieldOffset(0)]
        public XDestroyWindowEvent xdestroywindow;

        [FieldOffset(0)]
        public XUnmapEvent xunmap;

        [FieldOffset(0)]
        public XMapEvent xmap;

        [FieldOffset(0)]
        public XMapRequestEvent xmaprequest;

        [FieldOffset(0)]
        public XReparentEvent xreparent;

        [FieldOffset(0)]
        public XConfigureEvent xconfigure;

        [FieldOffset(0)]
        public XGravityEvent xgravity;

        [FieldOffset(0)]
        public XResizeRequestEvent xresizerequest;

        [FieldOffset(0)]
        public XConfigureRequestEvent xconfigurerequest;

        [FieldOffset(0)]
        public XCirculateEvent xcirculate;

        [FieldOffset(0)]
        public XCirculateRequestEvent xcirculaterequest;

        [FieldOffset(0)]
        public XPropertyEvent xproperty;

        [FieldOffset(0)]
        public XSelectionClearEvent xselectionclear;

        [FieldOffset(0)]
        public XSelectionRequestEvent xselectionrequest;

        [FieldOffset(0)]
        public XSelectionEvent xselection;

        [FieldOffset(0)]
        public XColormapEvent xcolormap;

        [FieldOffset(0)]
        public XClientMessageEvent xclient;

        [FieldOffset(0)]
        public XMappingEvent xmapping;

        [FieldOffset(0)]
        public XErrorEvent xerror;

        [FieldOffset(0)]
        public XKeymapEvent xkeymap;

        [FieldOffset(0)]
        public XGenericEvent xgeneric;

        [FieldOffset(0)]
        public XGenericEventCookie xcookie;

        [FieldOffset(0)]
            public _pad_e__FixedBuffer pad;

        [InlineArray(24)]
        public partial struct _pad_e__FixedBuffer
        {
            public nint e0;
        }
    }

    public partial struct XCharStruct
    {
        public short lbearing;

        public short rbearing;

        public short width;

        public short ascent;

        public short descent;

            public ushort attributes;
    }

    public partial struct XFontProp
    {
            public nuint name;

            public nuint card32;
    }

    public unsafe partial struct XFontStruct
    {
            public _XExtData* ext_data;

            public nuint fid;

            public uint direction;

            public uint min_char_or_byte2;

            public uint max_char_or_byte2;

            public uint min_byte1;

            public uint max_byte1;

        public int all_chars_exist;

            public uint default_char;

        public int n_properties;

        public XFontProp* properties;

        public XCharStruct min_bounds;

        public XCharStruct max_bounds;

        public XCharStruct* per_char;

        public int ascent;

        public int descent;
    }

    public unsafe partial struct XTextItem
    {
            public sbyte* chars;

        public int nchars;

        public int delta;

            public nuint font;
    }

    public partial struct XChar2b
    {
            public byte byte1;

            public byte byte2;
    }

    public unsafe partial struct XTextItem16
    {
        public XChar2b* chars;

        public int nchars;

        public int delta;

            public nuint font;
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct XEDataObject
    {
        [FieldOffset(0)]
            public _XDisplay* display;

        [FieldOffset(0)]
            public _XGC* gc;

        [FieldOffset(0)]
        public Visual* visual;

        [FieldOffset(0)]
        public Screen* screen;

        [FieldOffset(0)]
        public ScreenFormat* pixmap_format;

        [FieldOffset(0)]
        public XFontStruct* font;
    }

    public partial struct XFontSetExtents
    {
        public XRectangle max_ink_extent;

        public XRectangle max_logical_extent;
    }

    public partial struct _XOM
    {
    }

    public partial struct _XOC
    {
    }

    public unsafe partial struct XmbTextItem
    {
            public sbyte* chars;

        public int nchars;

        public int delta;

            public _XOC* font_set;
    }

    public unsafe partial struct XwcTextItem
    {
            public uint* chars;

        public int nchars;

        public int delta;

            public _XOC* font_set;
    }

    public unsafe partial struct XOMCharSetList
    {
        public int charset_count;

            public sbyte** charset_list;
    }

    public enum XOrientation : uint
    {
        XOMOrientation_LTR_TTB,
        XOMOrientation_RTL_TTB,
        XOMOrientation_TTB_LTR,
        XOMOrientation_TTB_RTL,
        XOMOrientation_Context,
    }

    public unsafe partial struct XOMOrientation
    {
        public int num_orientation;

        public XOrientation* orientation;
    }

    public unsafe partial struct XOMFontInfo
    {
        public int num_font;

        public XFontStruct** font_struct_list;

            public sbyte** font_name_list;
    }

    public partial struct _XIM
    {
    }

    public partial struct _XIC
    {
    }

    public unsafe partial struct XIMStyles
    {
            public ushort count_styles;

            public nuint* supported_styles;
    }

    public unsafe partial struct XIMCallback
    {
            public sbyte* client_data;

            public delegate* unmanaged[Cdecl]<_XIM*, sbyte*, sbyte*, void> callback;
    }

    public unsafe partial struct XICCallback
    {
            public sbyte* client_data;

            public delegate* unmanaged[Cdecl]<_XIC*, sbyte*, sbyte*, int> callback;
    }

    public unsafe partial struct _XIMText
    {
            public ushort length;

            public nuint* feedback;

        public int encoding_is_wchar;

            public _string_e__Union @string;

        [StructLayout(LayoutKind.Explicit)]
        public unsafe partial struct _string_e__Union
        {
            [FieldOffset(0)]
                    public sbyte* multi_byte;

            [FieldOffset(0)]
                    public uint* wide_char;
        }
    }

    public partial struct _XIMPreeditStateNotifyCallbackStruct
    {
            public nuint state;
    }

    public unsafe partial struct _XIMStringConversionText
    {
            public ushort length;

            public nuint* feedback;

        public int encoding_is_wchar;

            public _string_e__Union @string;

        [StructLayout(LayoutKind.Explicit)]
        public unsafe partial struct _string_e__Union
        {
            [FieldOffset(0)]
                    public sbyte* mbs;

            [FieldOffset(0)]
                    public uint* wcs;
        }
    }

    public enum XIMCaretDirection : uint
    {
        XIMForwardChar,
        XIMBackwardChar,
        XIMForwardWord,
        XIMBackwardWord,
        XIMCaretUp,
        XIMCaretDown,
        XIMNextLine,
        XIMPreviousLine,
        XIMLineStart,
        XIMLineEnd,
        XIMAbsolutePosition,
        XIMDontChange,
    }

    public unsafe partial struct _XIMStringConversionCallbackStruct
    {
            public ushort position;

        public XIMCaretDirection direction;

            public ushort operation;

            public ushort factor;

            public _XIMStringConversionText* text;
    }

    public unsafe partial struct _XIMPreeditDrawCallbackStruct
    {
        public int caret;

        public int chg_first;

        public int chg_length;

            public _XIMText* text;
    }

    public enum XIMCaretStyle : uint
    {
        XIMIsInvisible,
        XIMIsPrimary,
        XIMIsSecondary,
    }

    public partial struct _XIMPreeditCaretCallbackStruct
    {
        public int position;

        public XIMCaretDirection direction;

        public XIMCaretStyle style;
    }

    public enum XIMStatusDataType : uint
    {
        XIMTextType,
        XIMBitmapType,
    }

    public partial struct _XIMStatusDrawCallbackStruct
    {
        public XIMStatusDataType type;

            public _data_e__Union data;

        [StructLayout(LayoutKind.Explicit)]
        public unsafe partial struct _data_e__Union
        {
            [FieldOffset(0)]
                    public _XIMText* text;

            [FieldOffset(0)]
                    public nuint bitmap;
        }
    }

    public partial struct _XIMHotKeyTrigger
    {
            public nuint keysym;

        public int modifier;

        public int modifier_mask;
    }

    public unsafe partial struct _XIMHotKeyTriggers
    {
        public int num_hot_key;

            public _XIMHotKeyTrigger* key;
    }

    public unsafe partial struct XIMValuesList
    {
            public ushort count_values;

            public sbyte** supported_values;
    }

    public static unsafe partial class Methods
    {
        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, EntryPoint = "_Z7_XmblenPci", ExactSpelling = true)]
        public static extern int _Xmblen(sbyte* str, int len);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern XFontStruct* XLoadQueryFont(_XDisplay* param0, sbyte* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern XFontStruct* XQueryFont(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern XTimeCoord* XGetMotionEvents(_XDisplay* param0, nuint param1, nuint param2, nuint param3, int* param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern XModifierKeymap* XDeleteModifiermapEntry(XModifierKeymap* param0, byte param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern XModifierKeymap* XGetModifierMapping(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern XModifierKeymap* XInsertModifiermapEntry(XModifierKeymap* param0, byte param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern XModifierKeymap* XNewModifiermap(int param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern _XImage* XCreateImage(_XDisplay* param0, Visual* param1, uint param2, int param3, int param4, sbyte* param5, uint param6, uint param7, int param8, int param9);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XInitImage(_XImage* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern _XImage* XGetImage(_XDisplay* param0, nuint param1, int param2, int param3, uint param4, uint param5, nuint param6, int param7);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern _XImage* XGetSubImage(_XDisplay* param0, nuint param1, int param2, int param3, uint param4, uint param5, nuint param6, int param7, _XImage* param8, int param9, int param10);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern _XDisplay* XOpenDisplay(sbyte* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XrmInitialize();

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XFetchBytes(_XDisplay* param0, int* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XFetchBuffer(_XDisplay* param0, int* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XGetAtomName(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGetAtomNames(_XDisplay* param0, nuint* param1, int param2, sbyte** param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XGetDefault(_XDisplay* param0, sbyte* param1, sbyte* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XDisplayName(sbyte* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XKeysymToString(nuint param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern delegate* unmanaged[Cdecl]<_XDisplay*, int> XSynchronize(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern delegate* unmanaged[Cdecl]<_XDisplay*, int> XSetAfterFunction(_XDisplay* param0, delegate* unmanaged[Cdecl]<_XDisplay*, int> param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XInternAtom(_XDisplay* param0, sbyte* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XInternAtoms(_XDisplay* param0, sbyte** param1, int param2, int param3, nuint* param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XCopyColormapAndFree(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XCreateColormap(_XDisplay* param0, nuint param1, Visual* param2, int param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XCreatePixmapCursor(_XDisplay* param0, nuint param1, nuint param2, XColor* param3, XColor* param4, uint param5, uint param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XCreateGlyphCursor(_XDisplay* param0, nuint param1, nuint param2, uint param3, uint param4, XColor* param5, XColor* param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XCreateFontCursor(_XDisplay* param0, uint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XLoadFont(_XDisplay* param0, sbyte* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern _XGC* XCreateGC(_XDisplay* param0, nuint param1, nuint param2, XGCValues* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XGContextFromGC(_XGC* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XFlushGC(_XDisplay* param0, _XGC* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XCreatePixmap(_XDisplay* param0, nuint param1, uint param2, uint param3, uint param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XCreateBitmapFromData(_XDisplay* param0, nuint param1, sbyte* param2, uint param3, uint param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XCreatePixmapFromBitmapData(_XDisplay* param0, nuint param1, sbyte* param2, uint param3, uint param4, nuint param5, nuint param6, uint param7);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XCreateSimpleWindow(_XDisplay* param0, nuint param1, int param2, int param3, uint param4, uint param5, uint param6, nuint param7, nuint param8);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XGetSelectionOwner(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XCreateWindow(_XDisplay* param0, nuint param1, int param2, int param3, uint param4, uint param5, uint param6, int param7, uint param8, Visual* param9, nuint param10, XSetWindowAttributes* param11);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint* XListInstalledColormaps(_XDisplay* param0, nuint param1, int* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte** XListFonts(_XDisplay* param0, sbyte* param1, int param2, int* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte** XListFontsWithInfo(_XDisplay* param0, sbyte* param1, int param2, int* param3, XFontStruct** param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte** XGetFontPath(_XDisplay* param0, int* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte** XListExtensions(_XDisplay* param0, int* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint* XListProperties(_XDisplay* param0, nuint param1, int* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern XHostAddress* XListHosts(_XDisplay* param0, int* param1, int* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            [Obsolete]
        public static extern nuint XKeycodeToKeysym(_XDisplay* param0, byte param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XLookupKeysym(XKeyEvent* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint* XGetKeyboardMapping(_XDisplay* param0, byte param1, int param2, int* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XStringToKeysym(sbyte* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nint XMaxRequestSize(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nint XExtendedMaxRequestSize(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XResourceManagerString(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XScreenResourceString(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XDisplayMotionBufferSize(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XVisualIDFromVisual(Visual* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XInitThreads();

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFreeThreads();

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XLockDisplay(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XUnlockDisplay(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern XExtCodes* XInitExtension(_XDisplay* param0, sbyte* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern XExtCodes* XAddExtension(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern _XExtData* XFindOnExtensionList(_XExtData** param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern _XExtData** XEHeadOfExtensionList(XEDataObject param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XRootWindow(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XDefaultRootWindow(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XRootWindowOfScreen(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Visual* XDefaultVisual(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Visual* XDefaultVisualOfScreen(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern _XGC* XDefaultGC(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern _XGC* XDefaultGCOfScreen(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XBlackPixel(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XWhitePixel(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XAllPlanes();

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XBlackPixelOfScreen(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XWhitePixelOfScreen(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XNextRequest(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XLastKnownRequestProcessed(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XServerVendor(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XDisplayString(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XDefaultColormap(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nuint XDefaultColormapOfScreen(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern _XDisplay* XDisplayOfScreen(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Screen* XScreenOfDisplay(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Screen* XDefaultScreenOfDisplay(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern nint XEventMaskOfScreen(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XScreenNumberOfScreen(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern delegate* unmanaged[Cdecl]<_XDisplay*, XErrorEvent*, int> XSetErrorHandler(delegate* unmanaged[Cdecl]<_XDisplay*, XErrorEvent*, int> param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern delegate* unmanaged[Cdecl]<_XDisplay*, int> XSetIOErrorHandler(delegate* unmanaged[Cdecl]<_XDisplay*, int> param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XSetIOErrorExitHandler(_XDisplay* param0, delegate* unmanaged[Cdecl]<_XDisplay*, void*, void> param1, void* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern XPixmapFormatValues* XListPixmapFormats(_XDisplay* param0, int* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int* XListDepths(_XDisplay* param0, int param1, int* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XReconfigureWMWindow(_XDisplay* param0, nuint param1, int param2, uint param3, XWindowChanges* param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGetWMProtocols(_XDisplay* param0, nuint param1, nuint** param2, int* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetWMProtocols(_XDisplay* param0, nuint param1, nuint* param2, int param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XIconifyWindow(_XDisplay* param0, nuint param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XWithdrawWindow(_XDisplay* param0, nuint param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGetCommand(_XDisplay* param0, nuint param1, sbyte*** param2, int* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGetWMColormapWindows(_XDisplay* param0, nuint param1, nuint** param2, int* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetWMColormapWindows(_XDisplay* param0, nuint param1, nuint* param2, int param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XFreeStringList(sbyte** param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetTransientForHint(_XDisplay* param0, nuint param1, nuint param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XActivateScreenSaver(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XAddHost(_XDisplay* param0, XHostAddress* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XAddHosts(_XDisplay* param0, XHostAddress* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XAddToExtensionList(_XExtData** param0, _XExtData* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XAddToSaveSet(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XAllocColor(_XDisplay* param0, nuint param1, XColor* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XAllocColorCells(_XDisplay* param0, nuint param1, int param2, nuint* param3, uint param4, nuint* param5, uint param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XAllocColorPlanes(_XDisplay* param0, nuint param1, int param2, nuint* param3, int param4, int param5, int param6, int param7, nuint* param8, nuint* param9, nuint* param10);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XAllocNamedColor(_XDisplay* param0, nuint param1, sbyte* param2, XColor* param3, XColor* param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XAllowEvents(_XDisplay* param0, int param1, nuint param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XAutoRepeatOff(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XAutoRepeatOn(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XBell(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XBitmapBitOrder(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XBitmapPad(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XBitmapUnit(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XCellsOfScreen(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XChangeActivePointerGrab(_XDisplay* param0, uint param1, nuint param2, nuint param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XChangeGC(_XDisplay* param0, _XGC* param1, nuint param2, XGCValues* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XChangeKeyboardControl(_XDisplay* param0, nuint param1, XKeyboardControl* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XChangeKeyboardMapping(_XDisplay* param0, int param1, int param2, nuint* param3, int param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XChangePointerControl(_XDisplay* param0, int param1, int param2, int param3, int param4, int param5);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XChangeProperty(_XDisplay* param0, nuint param1, nuint param2, nuint param3, int param4, int param5, byte* param6, int param7);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XChangeSaveSet(_XDisplay* param0, nuint param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XChangeWindowAttributes(_XDisplay* param0, nuint param1, nuint param2, XSetWindowAttributes* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XCheckIfEvent(_XDisplay* param0, _XEvent* param1, delegate* unmanaged[Cdecl]<_XDisplay*, _XEvent*, sbyte*, int> param2, sbyte* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XCheckMaskEvent(_XDisplay* param0, nint param1, _XEvent* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XCheckTypedEvent(_XDisplay* param0, int param1, _XEvent* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XCheckTypedWindowEvent(_XDisplay* param0, nuint param1, int param2, _XEvent* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XCheckWindowEvent(_XDisplay* param0, nuint param1, nint param2, _XEvent* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XCirculateSubwindows(_XDisplay* param0, nuint param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XCirculateSubwindowsDown(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XCirculateSubwindowsUp(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XClearArea(_XDisplay* param0, nuint param1, int param2, int param3, uint param4, uint param5, int param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XClearWindow(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XCloseDisplay(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XConfigureWindow(_XDisplay* param0, nuint param1, uint param2, XWindowChanges* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XConnectionNumber(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XConvertSelection(_XDisplay* param0, nuint param1, nuint param2, nuint param3, nuint param4, nuint param5);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XCopyArea(_XDisplay* param0, nuint param1, nuint param2, _XGC* param3, int param4, int param5, uint param6, uint param7, int param8, int param9);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XCopyGC(_XDisplay* param0, _XGC* param1, nuint param2, _XGC* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XCopyPlane(_XDisplay* param0, nuint param1, nuint param2, _XGC* param3, int param4, int param5, uint param6, uint param7, int param8, int param9, nuint param10);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDefaultDepth(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDefaultDepthOfScreen(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDefaultScreen(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDefineCursor(_XDisplay* param0, nuint param1, nuint param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDeleteProperty(_XDisplay* param0, nuint param1, nuint param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDestroyWindow(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDestroySubwindows(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDoesBackingStore(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDoesSaveUnders(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDisableAccessControl(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDisplayCells(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDisplayHeight(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDisplayHeightMM(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDisplayKeycodes(_XDisplay* param0, int* param1, int* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDisplayPlanes(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDisplayWidth(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDisplayWidthMM(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDrawArc(_XDisplay* param0, nuint param1, _XGC* param2, int param3, int param4, uint param5, uint param6, int param7, int param8);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDrawArcs(_XDisplay* param0, nuint param1, _XGC* param2, XArc* param3, int param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDrawImageString(_XDisplay* param0, nuint param1, _XGC* param2, int param3, int param4, sbyte* param5, int param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDrawImageString16(_XDisplay* param0, nuint param1, _XGC* param2, int param3, int param4, XChar2b* param5, int param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDrawLine(_XDisplay* param0, nuint param1, _XGC* param2, int param3, int param4, int param5, int param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDrawLines(_XDisplay* param0, nuint param1, _XGC* param2, XPoint* param3, int param4, int param5);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDrawPoint(_XDisplay* param0, nuint param1, _XGC* param2, int param3, int param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDrawPoints(_XDisplay* param0, nuint param1, _XGC* param2, XPoint* param3, int param4, int param5);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDrawRectangle(_XDisplay* param0, nuint param1, _XGC* param2, int param3, int param4, uint param5, uint param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDrawRectangles(_XDisplay* param0, nuint param1, _XGC* param2, XRectangle* param3, int param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDrawSegments(_XDisplay* param0, nuint param1, _XGC* param2, XSegment* param3, int param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDrawString(_XDisplay* param0, nuint param1, _XGC* param2, int param3, int param4, sbyte* param5, int param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDrawString16(_XDisplay* param0, nuint param1, _XGC* param2, int param3, int param4, XChar2b* param5, int param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDrawText(_XDisplay* param0, nuint param1, _XGC* param2, int param3, int param4, XTextItem* param5, int param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDrawText16(_XDisplay* param0, nuint param1, _XGC* param2, int param3, int param4, XTextItem16* param5, int param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XEnableAccessControl(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XEventsQueued(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFetchName(_XDisplay* param0, nuint param1, sbyte** param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFillArc(_XDisplay* param0, nuint param1, _XGC* param2, int param3, int param4, uint param5, uint param6, int param7, int param8);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFillArcs(_XDisplay* param0, nuint param1, _XGC* param2, XArc* param3, int param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFillPolygon(_XDisplay* param0, nuint param1, _XGC* param2, XPoint* param3, int param4, int param5, int param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFillRectangle(_XDisplay* param0, nuint param1, _XGC* param2, int param3, int param4, uint param5, uint param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFillRectangles(_XDisplay* param0, nuint param1, _XGC* param2, XRectangle* param3, int param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFlush(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XForceScreenSaver(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFree(void* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFreeColormap(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFreeColors(_XDisplay* param0, nuint param1, nuint* param2, int param3, nuint param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFreeCursor(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFreeExtensionList(sbyte** param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFreeFont(_XDisplay* param0, XFontStruct* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFreeFontInfo(sbyte** param0, XFontStruct* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFreeFontNames(sbyte** param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFreeFontPath(sbyte** param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFreeGC(_XDisplay* param0, _XGC* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFreeModifiermap(XModifierKeymap* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFreePixmap(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGeometry(_XDisplay* param0, int param1, sbyte* param2, sbyte* param3, uint param4, uint param5, uint param6, int param7, int param8, int* param9, int* param10, int* param11, int* param12);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGetErrorDatabaseText(_XDisplay* param0, sbyte* param1, sbyte* param2, sbyte* param3, sbyte* param4, int param5);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGetErrorText(_XDisplay* param0, int param1, sbyte* param2, int param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGetFontProperty(XFontStruct* param0, nuint param1, nuint* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGetGCValues(_XDisplay* param0, _XGC* param1, nuint param2, XGCValues* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGetGeometry(_XDisplay* param0, nuint param1, nuint* param2, int* param3, int* param4, uint* param5, uint* param6, uint* param7, uint* param8);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGetIconName(_XDisplay* param0, nuint param1, sbyte** param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGetInputFocus(_XDisplay* param0, nuint* param1, int* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGetKeyboardControl(_XDisplay* param0, XKeyboardState* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGetPointerControl(_XDisplay* param0, int* param1, int* param2, int* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGetPointerMapping(_XDisplay* param0, byte* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGetScreenSaver(_XDisplay* param0, int* param1, int* param2, int* param3, int* param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGetTransientForHint(_XDisplay* param0, nuint param1, nuint* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGetWindowProperty(_XDisplay* param0, nuint param1, nuint param2, nint param3, nint param4, int param5, nuint param6, nuint* param7, int* param8, nuint* param9, nuint* param10, byte** param11);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGetWindowAttributes(_XDisplay* param0, nuint param1, XWindowAttributes* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGrabButton(_XDisplay* param0, uint param1, uint param2, nuint param3, int param4, uint param5, int param6, int param7, nuint param8, nuint param9);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGrabKey(_XDisplay* param0, int param1, uint param2, nuint param3, int param4, int param5, int param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGrabKeyboard(_XDisplay* param0, nuint param1, int param2, int param3, int param4, nuint param5);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGrabPointer(_XDisplay* param0, nuint param1, int param2, uint param3, int param4, int param5, nuint param6, nuint param7, nuint param8);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGrabServer(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XHeightMMOfScreen(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XHeightOfScreen(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XIfEvent(_XDisplay* param0, _XEvent* param1, delegate* unmanaged[Cdecl]<_XDisplay*, _XEvent*, sbyte*, int> param2, sbyte* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XImageByteOrder(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XInstallColormap(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern byte XKeysymToKeycode(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XKillClient(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XLookupColor(_XDisplay* param0, nuint param1, sbyte* param2, XColor* param3, XColor* param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XLowerWindow(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XMapRaised(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XMapSubwindows(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XMapWindow(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XMaskEvent(_XDisplay* param0, nint param1, _XEvent* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XMaxCmapsOfScreen(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XMinCmapsOfScreen(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XMoveResizeWindow(_XDisplay* param0, nuint param1, int param2, int param3, uint param4, uint param5);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XMoveWindow(_XDisplay* param0, nuint param1, int param2, int param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XNextEvent(_XDisplay* param0, _XEvent* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XNoOp(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XParseColor(_XDisplay* param0, nuint param1, sbyte* param2, XColor* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XParseGeometry(sbyte* param0, int* param1, int* param2, uint* param3, uint* param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XPeekEvent(_XDisplay* param0, _XEvent* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XPeekIfEvent(_XDisplay* param0, _XEvent* param1, delegate* unmanaged[Cdecl]<_XDisplay*, _XEvent*, sbyte*, int> param2, sbyte* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XPending(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XPlanesOfScreen(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XProtocolRevision(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XProtocolVersion(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XPutBackEvent(_XDisplay* param0, _XEvent* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XPutImage(_XDisplay* param0, nuint param1, _XGC* param2, _XImage* param3, int param4, int param5, int param6, int param7, uint param8, uint param9);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XQLength(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XQueryBestCursor(_XDisplay* param0, nuint param1, uint param2, uint param3, uint* param4, uint* param5);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XQueryBestSize(_XDisplay* param0, int param1, nuint param2, uint param3, uint param4, uint* param5, uint* param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XQueryBestStipple(_XDisplay* param0, nuint param1, uint param2, uint param3, uint* param4, uint* param5);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XQueryBestTile(_XDisplay* param0, nuint param1, uint param2, uint param3, uint* param4, uint* param5);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XQueryColor(_XDisplay* param0, nuint param1, XColor* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XQueryColors(_XDisplay* param0, nuint param1, XColor* param2, int param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XQueryExtension(_XDisplay* param0, sbyte* param1, int* param2, int* param3, int* param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XQueryKeymap(_XDisplay* param0, sbyte* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XQueryPointer(_XDisplay* param0, nuint param1, nuint* param2, nuint* param3, int* param4, int* param5, int* param6, int* param7, uint* param8);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XQueryTextExtents(_XDisplay* param0, nuint param1, sbyte* param2, int param3, int* param4, int* param5, int* param6, XCharStruct* param7);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XQueryTextExtents16(_XDisplay* param0, nuint param1, XChar2b* param2, int param3, int* param4, int* param5, int* param6, XCharStruct* param7);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XQueryTree(_XDisplay* param0, nuint param1, nuint* param2, nuint* param3, nuint** param4, uint* param5);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XRaiseWindow(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XReadBitmapFile(_XDisplay* param0, nuint param1, sbyte* param2, uint* param3, uint* param4, nuint* param5, int* param6, int* param7);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XReadBitmapFileData(sbyte* param0, uint* param1, uint* param2, byte** param3, int* param4, int* param5);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XRebindKeysym(_XDisplay* param0, nuint param1, nuint* param2, int param3, byte* param4, int param5);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XRecolorCursor(_XDisplay* param0, nuint param1, XColor* param2, XColor* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XRefreshKeyboardMapping(XMappingEvent* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XRemoveFromSaveSet(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XRemoveHost(_XDisplay* param0, XHostAddress* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XRemoveHosts(_XDisplay* param0, XHostAddress* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XReparentWindow(_XDisplay* param0, nuint param1, nuint param2, int param3, int param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XResetScreenSaver(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XResizeWindow(_XDisplay* param0, nuint param1, uint param2, uint param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XRestackWindows(_XDisplay* param0, nuint* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XRotateBuffers(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XRotateWindowProperties(_XDisplay* param0, nuint param1, nuint* param2, int param3, int param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XScreenCount(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSelectInput(_XDisplay* param0, nuint param1, nint param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSendEvent(_XDisplay* param0, nuint param1, int param2, nint param3, _XEvent* param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetAccessControl(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetArcMode(_XDisplay* param0, _XGC* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetBackground(_XDisplay* param0, _XGC* param1, nuint param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetClipMask(_XDisplay* param0, _XGC* param1, nuint param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetClipOrigin(_XDisplay* param0, _XGC* param1, int param2, int param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetClipRectangles(_XDisplay* param0, _XGC* param1, int param2, int param3, XRectangle* param4, int param5, int param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetCloseDownMode(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetCommand(_XDisplay* param0, nuint param1, sbyte** param2, int param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetDashes(_XDisplay* param0, _XGC* param1, int param2, sbyte* param3, int param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetFillRule(_XDisplay* param0, _XGC* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetFillStyle(_XDisplay* param0, _XGC* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetFont(_XDisplay* param0, _XGC* param1, nuint param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetFontPath(_XDisplay* param0, sbyte** param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetForeground(_XDisplay* param0, _XGC* param1, nuint param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetFunction(_XDisplay* param0, _XGC* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetGraphicsExposures(_XDisplay* param0, _XGC* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetIconName(_XDisplay* param0, nuint param1, sbyte* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetInputFocus(_XDisplay* param0, nuint param1, int param2, nuint param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetLineAttributes(_XDisplay* param0, _XGC* param1, uint param2, int param3, int param4, int param5);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetModifierMapping(_XDisplay* param0, XModifierKeymap* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetPlaneMask(_XDisplay* param0, _XGC* param1, nuint param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetPointerMapping(_XDisplay* param0, byte* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetScreenSaver(_XDisplay* param0, int param1, int param2, int param3, int param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetSelectionOwner(_XDisplay* param0, nuint param1, nuint param2, nuint param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetState(_XDisplay* param0, _XGC* param1, nuint param2, nuint param3, int param4, nuint param5);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetStipple(_XDisplay* param0, _XGC* param1, nuint param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetSubwindowMode(_XDisplay* param0, _XGC* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetTSOrigin(_XDisplay* param0, _XGC* param1, int param2, int param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetTile(_XDisplay* param0, _XGC* param1, nuint param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetWindowBackground(_XDisplay* param0, nuint param1, nuint param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetWindowBackgroundPixmap(_XDisplay* param0, nuint param1, nuint param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetWindowBorder(_XDisplay* param0, nuint param1, nuint param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetWindowBorderPixmap(_XDisplay* param0, nuint param1, nuint param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetWindowBorderWidth(_XDisplay* param0, nuint param1, uint param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSetWindowColormap(_XDisplay* param0, nuint param1, nuint param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XStoreBuffer(_XDisplay* param0, sbyte* param1, int param2, int param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XStoreBytes(_XDisplay* param0, sbyte* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XStoreColor(_XDisplay* param0, nuint param1, XColor* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XStoreColors(_XDisplay* param0, nuint param1, XColor* param2, int param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XStoreName(_XDisplay* param0, nuint param1, sbyte* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XStoreNamedColor(_XDisplay* param0, nuint param1, sbyte* param2, nuint param3, int param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSync(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XTextExtents(XFontStruct* param0, sbyte* param1, int param2, int* param3, int* param4, int* param5, XCharStruct* param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XTextExtents16(XFontStruct* param0, XChar2b* param1, int param2, int* param3, int* param4, int* param5, XCharStruct* param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XTextWidth(XFontStruct* param0, sbyte* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XTextWidth16(XFontStruct* param0, XChar2b* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XTranslateCoordinates(_XDisplay* param0, nuint param1, nuint param2, int param3, int param4, int* param5, int* param6, nuint* param7);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XUndefineCursor(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XUngrabButton(_XDisplay* param0, uint param1, uint param2, nuint param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XUngrabKey(_XDisplay* param0, int param1, uint param2, nuint param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XUngrabKeyboard(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XUngrabPointer(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XUngrabServer(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XUninstallColormap(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XUnloadFont(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XUnmapSubwindows(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XUnmapWindow(_XDisplay* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XVendorRelease(_XDisplay* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XWarpPointer(_XDisplay* param0, nuint param1, nuint param2, int param3, int param4, uint param5, uint param6, int param7, int param8);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XWidthMMOfScreen(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XWidthOfScreen(Screen* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XWindowEvent(_XDisplay* param0, nuint param1, nint param2, _XEvent* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XWriteBitmapFile(_XDisplay* param0, sbyte* param1, nuint param2, uint param3, uint param4, int param5, int param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XSupportsLocale();

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XSetLocaleModifiers(sbyte* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern _XOM* XOpenOM(_XDisplay* param0, _XrmHashBucketRec* param1, sbyte* param2, sbyte* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XCloseOM(_XOM* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XSetOMValues(_XOM* param0, __arglist);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XGetOMValues(_XOM* param0, __arglist);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern _XDisplay* XDisplayOfOM(_XOM* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XLocaleOfOM(_XOM* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern _XOC* XCreateOC(_XOM* param0, __arglist);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XDestroyOC(_XOC* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern _XOM* XOMOfOC(_XOC* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XSetOCValues(_XOC* param0, __arglist);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XGetOCValues(_XOC* param0, __arglist);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern _XOC* XCreateFontSet(_XDisplay* param0, sbyte* param1, sbyte*** param2, int* param3, sbyte** param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XFreeFontSet(_XDisplay* param0, _XOC* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFontsOfFontSet(_XOC* param0, XFontStruct*** param1, sbyte*** param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XBaseFontNameListOfFontSet(_XOC* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XLocaleOfFontSet(_XOC* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XContextDependentDrawing(_XOC* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XDirectionalDependentDrawing(_XOC* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XContextualDrawing(_XOC* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern XFontSetExtents* XExtentsOfFontSet(_XOC* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XmbTextEscapement(_XOC* param0, sbyte* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XwcTextEscapement(_XOC* param0, uint* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int Xutf8TextEscapement(_XOC* param0, sbyte* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XmbTextExtents(_XOC* param0, sbyte* param1, int param2, XRectangle* param3, XRectangle* param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XwcTextExtents(_XOC* param0, uint* param1, int param2, XRectangle* param3, XRectangle* param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int Xutf8TextExtents(_XOC* param0, sbyte* param1, int param2, XRectangle* param3, XRectangle* param4);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XmbTextPerCharExtents(_XOC* param0, sbyte* param1, int param2, XRectangle* param3, XRectangle* param4, int param5, int* param6, XRectangle* param7, XRectangle* param8);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XwcTextPerCharExtents(_XOC* param0, uint* param1, int param2, XRectangle* param3, XRectangle* param4, int param5, int* param6, XRectangle* param7, XRectangle* param8);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int Xutf8TextPerCharExtents(_XOC* param0, sbyte* param1, int param2, XRectangle* param3, XRectangle* param4, int param5, int* param6, XRectangle* param7, XRectangle* param8);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XmbDrawText(_XDisplay* param0, nuint param1, _XGC* param2, int param3, int param4, XmbTextItem* param5, int param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XwcDrawText(_XDisplay* param0, nuint param1, _XGC* param2, int param3, int param4, XwcTextItem* param5, int param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Xutf8DrawText(_XDisplay* param0, nuint param1, _XGC* param2, int param3, int param4, XmbTextItem* param5, int param6);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XmbDrawString(_XDisplay* param0, nuint param1, _XOC* param2, _XGC* param3, int param4, int param5, sbyte* param6, int param7);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XwcDrawString(_XDisplay* param0, nuint param1, _XOC* param2, _XGC* param3, int param4, int param5, uint* param6, int param7);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Xutf8DrawString(_XDisplay* param0, nuint param1, _XOC* param2, _XGC* param3, int param4, int param5, sbyte* param6, int param7);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XmbDrawImageString(_XDisplay* param0, nuint param1, _XOC* param2, _XGC* param3, int param4, int param5, sbyte* param6, int param7);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XwcDrawImageString(_XDisplay* param0, nuint param1, _XOC* param2, _XGC* param3, int param4, int param5, uint* param6, int param7);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Xutf8DrawImageString(_XDisplay* param0, nuint param1, _XOC* param2, _XGC* param3, int param4, int param5, sbyte* param6, int param7);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern _XIM* XOpenIM(_XDisplay* param0, _XrmHashBucketRec* param1, sbyte* param2, sbyte* param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XCloseIM(_XIM* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XGetIMValues(_XIM* param0, __arglist);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XSetIMValues(_XIM* param0, __arglist);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern _XDisplay* XDisplayOfIM(_XIM* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XLocaleOfIM(_XIM* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern _XIC* XCreateIC(_XIM* param0, __arglist);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XDestroyIC(_XIC* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XSetICFocus(_XIC* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XUnsetICFocus(_XIC* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern uint* XwcResetIC(_XIC* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XmbResetIC(_XIC* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* Xutf8ResetIC(_XIC* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XSetICValues(_XIC* param0, __arglist);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern sbyte* XGetICValues(_XIC* param0, __arglist);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern _XIM* XIMOfIC(_XIC* param0);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XFilterEvent(_XEvent* param0, nuint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XmbLookupString(_XIC* param0, XKeyEvent* param1, sbyte* param2, int param3, nuint* param4, int* param5);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XwcLookupString(_XIC* param0, XKeyEvent* param1, uint* param2, int param3, nuint* param4, int* param5);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int Xutf8LookupString(_XIC* param0, XKeyEvent* param1, sbyte* param2, int param3, nuint* param4, int* param5);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern void* XVaCreateNestedList(int param0, __arglist);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XRegisterIMInstantiateCallback(_XDisplay* param0, _XrmHashBucketRec* param1, sbyte* param2, sbyte* param3, delegate* unmanaged[Cdecl]<_XDisplay*, sbyte*, sbyte*, void> param4, sbyte* param5);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XUnregisterIMInstantiateCallback(_XDisplay* param0, _XrmHashBucketRec* param1, sbyte* param2, sbyte* param3, delegate* unmanaged[Cdecl]<_XDisplay*, sbyte*, sbyte*, void> param4, sbyte* param5);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XInternalConnectionNumbers(_XDisplay* param0, int** param1, int* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XProcessInternalConnection(_XDisplay* param0, int param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XAddConnectionWatch(_XDisplay* param0, delegate* unmanaged[Cdecl]<_XDisplay*, sbyte*, int, int, sbyte**, void> param1, sbyte* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XRemoveConnectionWatch(_XDisplay* param0, delegate* unmanaged[Cdecl]<_XDisplay*, sbyte*, int, int, sbyte**, void> param1, sbyte* param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XSetAuthorization(sbyte* param0, int param1, sbyte* param2, int param3);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _Xmbtowc(uint* param0, sbyte* param1, int param2);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int _Xwctomb(sbyte* param0, uint param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int XGetEventData(_XDisplay* param0, XGenericEventCookie* param1);

        [DllImport("X11", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void XFreeEventData(_XDisplay* param0, XGenericEventCookie* param1);
    }
}
