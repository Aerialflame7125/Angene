# Angene\painter.py
import ctypes

gdi32 = ctypes.WinDLL('gdi32', use_last_error=True)

# Properly define all GDI functions
CreateSolidBrush = gdi32.CreateSolidBrush
CreateSolidBrush.argtypes = [ctypes.c_ulong]
CreateSolidBrush.restype = ctypes.c_void_p

SelectObject = gdi32.SelectObject
SelectObject.argtypes = [ctypes.c_void_p, ctypes.c_void_p]
SelectObject.restype = ctypes.c_void_p

DeleteObject = gdi32.DeleteObject
DeleteObject.argtypes = [ctypes.c_void_p]
DeleteObject.restype = ctypes.c_bool

Rectangle = gdi32.Rectangle
Rectangle.argtypes = [ctypes.c_void_p, ctypes.c_int, ctypes.c_int, ctypes.c_int, ctypes.c_int]
Rectangle.restype = ctypes.c_bool

TextOutW = gdi32.TextOutW
TextOutW.argtypes = [ctypes.c_void_p, ctypes.c_int, ctypes.c_int, ctypes.c_wchar_p, ctypes.c_int]
TextOutW.restype = ctypes.c_bool

SetBkMode = gdi32.SetBkMode
SetBkMode.argtypes = [ctypes.c_void_p, ctypes.c_int]
SetBkMode.restype = ctypes.c_int

SetTextColor = gdi32.SetTextColor
SetTextColor.argtypes = [ctypes.c_void_p, ctypes.c_ulong]
SetTextColor.restype = ctypes.c_ulong

# Get stock objects (NULL_PEN to prevent outline drawing which can leak)
GetStockObject = gdi32.GetStockObject
GetStockObject.argtypes = [ctypes.c_int]
GetStockObject.restype = ctypes.c_void_p

NULL_PEN = 8
NULL_BRUSH = 5

TRANSPARENT = 1

def RGB(r, g, b):
    """Create a COLORREF from RGB values (0-255 each)"""
    return (r & 0xFF) | ((g & 0xFF) << 8) | ((b & 0xFF) << 16)

class Renderer:
    """Rendering class that handles drawing to a device context"""
    _brush_cache = {}  # class-level cache to reuse brushes
    _null_pen = None    # Cached NULL pen to prevent outline drawing
    
    def __init__(self, hdc):
        # Don't wrap if already a void pointer
        if isinstance(hdc, ctypes.c_void_p):
            self.hdc = hdc
        else:
            self.hdc = ctypes.c_void_p(hdc)
        
        # Get NULL_PEN once and cache it
        if Renderer._null_pen is None:
            Renderer._null_pen = GetStockObject(NULL_PEN)
    
    def _get_brush(self, color):
        """Return a cached brush for color, creating it if necessary"""
        if color not in Renderer._brush_cache:
            brush = CreateSolidBrush(color)
            if not brush:
                print(f"Warning: Failed to create brush for color {color}")
                return None
            Renderer._brush_cache[color] = brush
        return Renderer._brush_cache[color]
    
    def clear(self, color):
        """Clear the entire drawing surface with a solid color"""
        brush = self._get_brush(color)
        if not brush:
            return
        
        # Select NULL pen to prevent outline
        old_pen = SelectObject(self.hdc, Renderer._null_pen)
        old_brush = SelectObject(self.hdc, brush)
        
        # Use large coordinates to fill entire surface
        Rectangle(self.hdc, -1, -1, 10000, 10000)
        
        # Restore old objects
        if old_brush:
            SelectObject(self.hdc, old_brush)
        if old_pen:
            SelectObject(self.hdc, old_pen)
    
    def draw_rect(self, x, y, w, h, color):
        """Draw a filled rectangle"""
        brush = self._get_brush(color)
        if not brush:
            return
        
        # Select NULL pen to prevent outline
        old_pen = SelectObject(self.hdc, Renderer._null_pen)
        old_brush = SelectObject(self.hdc, brush)
        
        Rectangle(self.hdc, int(x), int(y), int(x + w), int(y + h))
        
        # Restore old objects
        if old_brush:
            SelectObject(self.hdc, old_brush)
        if old_pen:
            SelectObject(self.hdc, old_pen)
    
    def draw_text(self, x, y, text, color):
        """Draw text at the specified position"""
        try:
            SetBkMode(self.hdc, TRANSPARENT)
            SetTextColor(self.hdc, color)
            # Ensure text is a string and has reasonable length
            text_str = str(text)[:256]  # Limit length to prevent issues
            TextOutW(self.hdc, int(x), int(y), text_str, len(text_str))
        except Exception as e:
            print(f"Error drawing text: {e}")
    
    @classmethod
    def cleanup(cls):
        """Delete all cached brushes. Call on engine exit."""
        for brush in cls._brush_cache.values():
            DeleteObject(brush)
        cls._brush_cache.clear()
        # Note: Don't delete stock objects like NULL_PEN