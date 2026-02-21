using Angene.Main;
using Angene.Essentials;
using Angene.Globals;

namespace AngeneEditor.Scenes
{
    public class Init : IScene
    {
        private Window win;
        private Instances instances;
        public IRenderer3D? Renderer3D => throw new NotImplementedException();

        public void Initialize()
        {
            Init self = this;
            instances = Entry.instances;
            instances.AddInstance<Init>(self);
        }

        public List<Entity> GetEntities()
        {
            throw new NotImplementedException();
        }

        public void OnMessage(nint msgPtr)
        {
            throw new NotImplementedException();
        }

        public void Render()
        {
            throw new NotImplementedException();
        }

        public void Cleanup()
        {
            throw new NotImplementedException();
        }

        public Init(Window window)
        {
            win = window;
        }
    }
}
