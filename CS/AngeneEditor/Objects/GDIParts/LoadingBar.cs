using Angene.Essentials;
using Angene;
using AngeneEditor;
using Angene.Main;
using AngeneEditor.Scenes;

namespace AngeneEditor.Objects.GDIParts
{
    class LoadingBar : IScreenPlay
    {
        Window winInstance;
        Instances instances = AngeneEditor.Entry.;


        public void Start()
        {
            instances.TryGetInstance<Window>(out winInstance);
        }
    }
}
