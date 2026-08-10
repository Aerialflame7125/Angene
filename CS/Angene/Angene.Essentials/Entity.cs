using System;
using System.Collections.Generic;
using System.Linq;
using Angene.Common;
using Angene.Essentials.Components;
using Angene.Math.Vectors;

namespace Angene.Essentials
{
    /// <summary>
    /// Entity represents a game object in the scene.
    /// Entities do NOT execute lifecycle logic directly.
    /// All lifecycle is managed by Angene.Lifecycle.ScriptBinding.
    /// </summary>
    public class Entity : IEquatable<Entity>
    {
        // Unique identifier for this entity
        private static int _nextId = 0;
        public int Id { get; private set; }
        public static Entity Instance = new Entity();

        // Identity
        public string name;

        // Transform
        public ComponentStructs.Transform3D Transform
        {
            get => GetComponent<ComponentStructs.Transform3D>() ?? AddComponent<ComponentStructs.Transform3D>();
            set => AddComponent(value);
        }


        // Script instances and components attached to this entity
        private List<object> _scripts;
        private Dictionary<Type, object> _components;
        
        // Entity hierarchy (now safe because Entity is a class)
        public List<Entity> childEntities { get; private set; }
        private Entity? _parent;

        // Internal enabled state (use Lifecycle.SetEntityEnabled to change)
        internal bool _enabled;

        public Entity(string _name = "New Object")
        {
            Id = _nextId++;
            name = _name;
            _scripts = new List<object>();
            childEntities = new List<Entity>();
            _parent = null;
            _enabled = true;

            // Register with lifecycle system
            Lifecycle.ScriptBinding.HandleEntityCreated(this);
        }

/*
        public Entity(Vec2 Pos, string _name = "New Object")
        {
            Id = _nextId++;
            name = _name;
            _scripts = new List<object>();
            childEntities = new List<Entity>();
            _parent = null;
            transformType = TransformType.Transform2D;

            _enabled = true;

            // Register with lifecycle system
            Lifecycle.ScriptBinding.HandleEntityCreated(this);
        }
*/
        public Entity(Vec3 Pos, Vec3 Rot, Vec3 Scale, string _name = "New Object")
        {
            Id = _nextId++;
            name = _name;
            _scripts = new List<object>();
            childEntities = new List<Entity>();
            _parent = null;
            AddComponent(new ComponentStructs.Transform3D(Pos, Rot, Scale));
            _enabled = true;

            // Register with lifecycle system
            Lifecycle.ScriptBinding.HandleEntityCreated(this);
        }

        /* COMPONENTS */

        /// <summary>
        /// Construct and add a new component of type T using its parameterless constructor.
        /// </summary>
        public T AddComponent<T>() where T : class, new()
        {
            return AddComponent(new T());
        }

        /// <summary>
        /// Add an already-constructed component instance (use this when the component
        /// needs constructor args, e.g. new Mesh(vertexBuffer, indexBuffer)).
        /// If a component of this exact type already exists, it is replaced.
        /// </summary>
        public T AddComponent<T>(T instance) where T : class
        {
            if (instance == null)
            {
                Logger.LogError(
                    $"Attempted to add null component to entity '{name}'",
                    LoggingTarget.Engine
                );
                return instance!;
            }
 
            var type = typeof(T);
 
            if (_components.ContainsKey(type))
            {
                Logger.LogWarning(
                    $"Entity '{name}' already has a component of type '{type.Name}'; overwriting.",
                    LoggingTarget.Engine
                );
            }
 
            _components[type] = instance;
 
            Logger.LogDebug(
                $"Component '{type.Name}' added to entity '{name}'",
                LoggingTarget.Engine
            );
 
            return instance;
        }
        
        /// <summary>
        /// Get the component of type T attached to this entity, or null if it has none.
        /// </summary>
        public T? GetComponent<T>() where T : class
        {
            return _components.TryGetValue(typeof(T), out var component) ? component as T : null;
        }
 
        /// <summary>
        /// Try-pattern version of GetComponent, avoids a separate null check at the call site.
        /// </summary>
        public bool TryGetComponent<T>(out T? component) where T : class
        {
            component = GetComponent<T>();
            return component != null;
        }
 
        /// <summary>
        /// Check whether this entity has a component of type T.
        /// </summary>
        public bool HasComponent<T>() where T : class
        {
            return _components.ContainsKey(typeof(T));
        }
 
        /// <summary>
        /// Remove the component of type T from this entity, if present.
        /// </summary>
        public bool RemoveComponent<T>() where T : class
        {
            var removed = _components.Remove(typeof(T));
 
            if (removed)
            {
                Logger.LogDebug(
                    $"Component '{typeof(T).Name}' removed from entity '{name}'",
                    LoggingTarget.Engine
                );
            }
 
            return removed;
        }
 
        /// <summary>
        /// Get all components attached to this entity (e.g. for a render system that
        /// needs to know "does this entity have a Mesh + Transform3D?").
        /// </summary>
        public IReadOnlyCollection<object> GetComponents()
        {
            return _components.Values;
        }

        /* SCRIPTS */

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
                Logger.LogError(
                    $"Attempted to add null script to entity '{name}'",
                    LoggingTarget.Engine
                );
                return;
            }

            _scripts.Add(scriptInstance);
            Lifecycle.ScriptBinding.RegisterScript(this, scriptInstance);

            Logger.LogDebug(
                $"Script '{scriptInstance.GetType().Name}' added to entity '{name}'",
                LoggingTarget.Engine
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
                Logger.LogDebug(
                    $"Script '{scriptInstance.GetType().Name}' removed from entity '{name}'",
                    LoggingTarget.Engine
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
        public T? GetScriptByType<T>()
        {
            foreach (var script in _scripts )
            {
                if ( script.GetType() == typeof( T ))
                {
                    return (T)script;
                }
            }
            return default;
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

        /* Properties */

        /// <summary>
        /// Set the enabled state of this entity.
        /// This will trigger OnEnable/OnDisable lifecycle callbacks.
        /// </summary>
        public void SetEnabled(bool enabled)
        {
            Lifecycle.ScriptBinding.SetEntityEnabled(this, enabled);
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
                Logger.LogDebug(
                    $"Entity '{child.name}' added as child of '{name}'",
                    LoggingTarget.Engine
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
                Logger.LogDebug(
                    $"Entity '{child.name}' removed from parent '{name}'",
                    LoggingTarget.Engine
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

        public void Remove() => Destroy();

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
            Lifecycle.ScriptBinding.DestroyEntity(this);

            // Clear scripts
            _scripts.Clear();
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