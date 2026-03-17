// Runtime/HeadlessWindow.cs
using Angene.Graphics;
using Angene.Main;
using Angene.Platform;

namespace AngeneEditor.Runtime
{
    /// <summary>
    /// A Window substitute with no real HWND.
    /// Passes only a graphics context backed by the editor panel.
    /// </summary>
    public sealed class HeadlessWindow
    {
        public int Width { get; }
        public int Height { get; }
        public IGraphicsContext? Graphics { get; set; } // set by EditorSceneHost

        public HeadlessWindow(int w, int h)
        {
            Width = w;
            Height = h;
        }

        // Scenes that call window.Scenes or window.SetScene
        // should check for null gracefully — flag this in your IScene contract.
    }
}