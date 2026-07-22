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
}