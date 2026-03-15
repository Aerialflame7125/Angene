public class FrameBuffer
{
    public int Width { get; }
    public int Height { get; }
    public int Stride { get; } // bytes per row = Width * 4
    public byte[] Pixels { get; } // BGRA, 32-bit per pixel

    public FrameBuffer(int width, int height)
    {
        Width = width;
        Height = height;
        Stride = width * 4;
        Pixels = new byte[Stride * height];
    }

    public void Clear(uint color)
    {
        byte b = (byte)(color & 0xFF);
        byte g = (byte)((color >> 8) & 0xFF);
        byte r = (byte)((color >> 16) & 0xFF);
        byte a = (byte)((color >> 24) & 0xFF);

        for (int i = 0; i < Pixels.Length; i += 4)
        {
            Pixels[i] = b;
            Pixels[i + 1] = g;
            Pixels[i + 2] = r;
            Pixels[i + 3] = a;
        }
    }

    public void FillRect(int x, int y, int w, int h, uint color)
    {
        byte b = (byte)(color & 0xFF);
        byte g = (byte)((color >> 8) & 0xFF);
        byte r = (byte)((color >> 16) & 0xFF);
        byte a = (byte)((color >> 24) & 0xFF);

        for (int row = y; row < y + h; row++)
        {
            if (row < 0 || row >= Height) continue;
            int rowOffset = row * Stride;
            for (int col = x; col < x + w; col++)
            {
                if (col < 0 || col >= Width) continue;
                int idx = rowOffset + col * 4;
                Pixels[idx] = b;
                Pixels[idx + 1] = g;
                Pixels[idx + 2] = r;
                Pixels[idx + 3] = a;
            }
        }
    }
}