using Angene.Globals;
using Angene.Essentials;
using System;
using System.Collections.Generic;
using Angene.Essentials.GraphicsContexts;
using Angene.Math.Vectors;
#if Windows
using Angene.Graphics.DX11;
#endif

namespace Angene.Essentials
{
    /// <summary>
    /// Scene interface.
    /// All lifecycle execution is routed through Angene.Lifecycle.
    /// </summary>
    public interface IScene
    {
        static object Instance { get; }
        List<Entity> Entities { get; }
        Entity MainCamera { get; }
        string Name { get; }

        public Entity GetCameraEntity() => MainCamera;
        public List<Entity> GetEntities() => Entities;
        public void AddEntity(Entity e) => Entities.Add(e);
        public void RemoveEntity(Entity e) => Entities.Remove(e);

        void Initialize(); //On Scene Init

        void OnMessage(object msgPtr); //On WM Message.

        void Render() { } // Final render in scene

        void Cleanup(); // Scene cleanup
    }

    public static class SceneExtensions // Implicit inheritance
    {
        public static Matrix4x4 GetWorldMatrix(this IScene scene, Entity e)
        {
            Matrix4x4 local = e.Transform.GetMatrix();
            Entity? parent = e.GetParent();
            
            return parent == null ? local : GetWorldMatrix(scene, parent) * local;
        }
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