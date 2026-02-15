using System;
using System.Collections.Generic;
using System.Linq;
using Angene.Common;

namespace Angene.Essentials
{
    /// <summary>
    /// Entity represents a game object in the scene.
    /// Entities do NOT execute lifecycle logic directly.
    /// All lifecycle is managed by Angene.ScriptBinding.Lifecycle.
    /// </summary>
    public class Entity : IEquatable<Entity>
    {
        // Unique identifier for this entity
        private static int _nextId = 0;
        public int Id { get; private set; }

        // Transform
        public int x;
        public int y;
        public int z;

        // Identity
        public string name;

        // Script instances attached to this entity
        private List<object> _scripts;
        
        // Entity hierarchy (now safe because Entity is a class)
        public List<Entity> childEntities { get; private set; }
        private Entity? _parent;

        // Internal enabled state (use Lifecycle.SetEntityEnabled to change)
        internal bool _enabled;

        public Entity(int _x, int _y, string _name = "New Object")
        {
            Id = _nextId++;
            x = _x;
            y = _y;
            z = 0;
            name = _name;
            _scripts = new List<object>();
            childEntities = new List<Entity>();
            _parent = null;
            _enabled = true;

            // Register with lifecycle system
            ScriptBinding.Lifecycle.HandleEntityCreated(this);
        }

        /// <summary>
        /// Add a script component to this entity.
        /// The script will be automatically registered with the lifecycle system.
        /// </summary>
        public T AddScript<T>() where T : new()
        {
            var scriptInstance = new T();
            AddScript(scriptInstance);
            return scriptInstance;
        }

        /// <summary>
        /// Add a script instance to this entity.
        /// The script will be automatically registered with the lifecycle system.
        /// </summary>
        public void AddScript(object scriptInstance)
        {
            if (scriptInstance == null)
            {
                Logger.Log(
                    $"Attempted to add null script to entity '{name}'",
                    LoggingTarget.Engine,
                    LogLevel.Error
                );
                return;
            }

            _scripts.Add(scriptInstance);
            ScriptBinding.Lifecycle.RegisterScript(this, scriptInstance);

            Logger.Log(
                $"Script '{scriptInstance.GetType().Name}' added to entity '{name}'",
                LoggingTarget.Engine,
                LogLevel.Info
            );
        }

        /// <summary>
        /// Remove a script from this entity.
        /// Note: This does not trigger lifecycle callbacks - the script is simply detached.
        /// </summary>
        public void RemoveScript(object scriptInstance)
        {
            if (_scripts.Remove(scriptInstance))
            {
                Logger.Log(
                    $"Script '{scriptInstance.GetType().Name}' removed from entity '{name}'",
                    LoggingTarget.Engine,
                    LogLevel.Info
                );
            }
        }

        /// <summary>
        /// Get all scripts attached to this entity.
        /// </summary>
        public IReadOnlyList<object> GetScripts()
        {
            return _scripts.AsReadOnly();
        }

        /// <summary>
        /// Returns a script object by type searched.
        /// If script not found, returns null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public T GetScriptByType<T>()
        {
            foreach (var script in _scripts )
            {
                if ( script.GetType() == typeof( T ))
                {
                    return (T)script;
                }
            }
            return default(T);
        }

        /// <summary>
        /// Get a script of a specific type from this entity.
        /// </summary>
        public T? GetScript<T>() where T : class
        {
            foreach (var script in _scripts)
            {
                if (script is T typedScript)
                    return typedScript;
            }
            return null;
        }

        /// <summary>
        /// Set the enabled state of this entity.
        /// This will trigger OnEnable/OnDisable lifecycle callbacks.
        /// </summary>
        public void SetEnabled(bool enabled)
        {
            ScriptBinding.Lifecycle.SetEntityEnabled(this, enabled);
        }

        /// <summary>
        /// Check if this entity is enabled.
        /// </summary>
        public bool IsEnabled()
        {
            return _enabled;
        }

        /// <summary>
        /// Add a child entity to this entity.
        /// </summary>
        public void AddChild(Entity child)
        {
            if (child == null)
                return;

            if (!childEntities.Contains(child))
            {
                childEntities.Add(child);
                child._parent = this;
                Logger.Log(
                    $"Entity '{child.name}' added as child of '{name}'",
                    LoggingTarget.Engine,
                    LogLevel.Info
                );
            }
        }

        /// <summary>
        /// Remove a child entity from this entity.
        /// </summary>
        public void RemoveChild(Entity child)
        {
            if (child == null)
                return;

            if (childEntities.Remove(child))
            {
                child._parent = null;
                Logger.Log(
                    $"Entity '{child.name}' removed from parent '{name}'",
                    LoggingTarget.Engine,
                    LogLevel.Info
                );
            }
        }

        /// <summary>
        /// Check if this entity is a parent of another entity.
        /// </summary>
        public bool IsParent(Entity entity)
        {
            return childEntities.Contains(entity);
        }

        /// <summary>
        /// Get the parent of this entity, if any.
        /// </summary>
        public Entity? GetParent()
        {
            return _parent;
        }

        /// <summary>
        /// Destroy this entity and all its children.
        /// This will trigger OnDisable and OnDestroy lifecycle callbacks.
        /// DO NOT call lifecycle methods directly - they are managed by the lifecycle system.
        /// </summary>
        public void Destroy()
        {
            // Destroy all children first
            foreach (var child in childEntities.ToArray()) // ToArray to avoid modification during iteration
            {
                child.Destroy();
            }

            // Notify lifecycle system
            ScriptBinding.Lifecycle.HandleEntityDestroyed(this);

            // Clear scripts
            _scripts.Clear();

            Logger.Log(
                $"Entity '{name}' destroyed",
                LoggingTarget.Engine,
                LogLevel.Info
            );
        }

        // Equality members for use as dictionary keys
        public bool Equals(Entity? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Entity);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(Entity? left, Entity? right)
        {
            if (left is null) return right is null;
            return left.Equals(right);
        }

        public static bool operator !=(Entity? left, Entity? right)
        {
            return !(left == right);
        }
    }
}