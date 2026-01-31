using System;

namespace Angene.Globals
{
    // Minimal IRenderer contract matching existing renderer implementations.
    public interface IRenderer : IDisposable
    {
        void BeginFrame(int width, int height);
        void Clear(float r, float g, float b, float a);
        void DrawRect(float x, float y, float w, float h, uint color);
        void DrawText(float x, float y, string text, uint color);
        void EndFrame();
    }
}