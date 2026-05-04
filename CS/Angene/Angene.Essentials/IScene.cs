using Angene.Globals;
using Angene.Essentials;
using System;
using System.Collections.Generic;

namespace Angene.Essentials
{
    /// <summary>
    /// Scene interface.
    /// All lifecycle execution is routed through Angene.Lifecycle.Lifecycle.
    /// </summary>
    public interface IScene
    {
        public IScene Instance => this;
        string Name => "New Scene";
        void Initialize(); //On Scene Init

        List<Entity> GetEntities();

        void OnMessage(IntPtr msgPtr); //On WM Message

        void Render(); // Final render in scene

        void Cleanup(); // Scene cleanup

        IRenderer3D? Renderer3D => null; // 3D renderer
    }
}