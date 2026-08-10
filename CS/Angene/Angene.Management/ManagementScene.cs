using Angene.Essentials;
using Angene.Globals;
using System.ComponentModel;

namespace Angene.Management
{
    public class ManagementScene : IScene
    {
        public object Instance { get; internal set; }
        public string Name => "ManagementScene";

        public List<Entity> Entities { get; internal set; } = new List<Entity>();

        Entity defaultEnt;

        public ManagementScene(string Token) => Entities.Add(new Entity(Token));

        public Entity AddEntity(Entity entity)
        {
            Entities.Add(entity);
            return entity;
        }
        
        public T AddScript<T>(Entity entity, T script) where T : IScreenPlay
        {
            if (!Entities.Contains(entity))
            {
                throw new Exception($"Attempted to add script to entity '{entity.name}' which does not exist in '{Name}' Scene.");
            }
            entity.AddScript(script);
            return script;
        }

        public Entity RemoveScript(Entity entity, IScreenPlay script)
        {
            if (entity != null && Entities.Contains(entity))
            {
                entity.RemoveScript(script);
                return entity;
            } else
            {
                throw new Exception($"Attempted to remove script from entity '{entity.name}' which does not exist in '{Name}' Scene.");
            }
        }

        public Entity GetDefaultEntity()
        {
            return defaultEnt;
        }

        public void Cleanup()
        {
            foreach (var entity in Entities)
            {
                foreach (var script in entity.GetScripts())
                {
                    if (script is IScreenPlay sp)
                        sp.Cleanup();
                }
            }
            Entities.Clear();
        }

        public List<Entity> GetEntities()
        {
            return Entities;
        }

        public void Initialize() 
        {
            List<Entity> es = GetEntities();
            foreach (Entity entity in es)
            {
                if (entity.name == "Ent1")
                {
                    defaultEnt = entity;
                    return;
                }
            }
        }

        public void OnMessage(nint msgPtr)
        {
            foreach (var entity in Entities)
            {
                foreach (var script in entity.GetScripts())
                {
                    if (script is IScreenPlay sp)
                        sp.OnMessage(msgPtr);
                }
            }
        }

        public void Render() { }
    }
}
