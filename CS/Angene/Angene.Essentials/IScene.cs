using Angene.Globals;
using Angene.Essentials;
using System;
using System.Collections.Generic;
using Angene.Graphics.DX11;
using Angene.Graphics;

namespace Angene.Essentials
{
    /// <summary>
    /// Scene interface.
    /// All lifecycle execution is routed through Angene.Lifecycle.
    /// </summary>
    public interface IScene
    {
        object Instance { get; }
        List<Entity> Entities { get; }
        string Name { get; }

        public List<Entity> GetEntities() => Entities;
        public void AddEntity(Entity e) => Entities.Add(e);
        public void RemoveEntity(Entity e) => Entities.Remove(e);

        void Initialize(); //On Scene Init

        void OnMessage(IntPtr msgPtr); //On WM Message

        void Render(); // Final render in scene

        void Cleanup(); // Scene cleanup
    }

    /// <summary>
    /// IDX11Scene definition for a DX11 specific scene with render calls.
    /// All definitions and execution still gets routed through Angene.Lifecycle
    /// </summary>
    public interface IDX11Scene : IScene
    {
        void Render(IDX11GraphicsContext graphics);
    }
}