using Angene.Common.Settings;
using Angene.Essentials;
using Angene.Main;
using System;
using System.Collections.Generic;

namespace AngeneEditor
{
    public class Instances : IDisposable
    {
        // Single unified registry keyed by type, no need for separate lists
        private readonly Dictionary<Type, object> _registry = new();
        private bool _disposed;

        public static Instances Instance { get; } = new Instances();
        public Engine engine;
        public Settings settings;

        public void MakeInstances()
        {
            engine = Engine.Instance;
            engine.Init();
            settings = engine.SettingHandlerInstanced;
        }

        /// <summary>
        /// Retrieve a registered instance of type T.
        /// </summary>
        public T GetInstance<T>()
        {
            ThrowIfDisposed();

            if (_registry.TryGetValue(typeof(T), out var instance))
                return (T)instance;

            throw new InvalidOperationException(
                $"No instance of type '{typeof(T).Name}' has been registered.");
        }

        /// <summary>
        /// Attempts to retrieve a registered instance of type T.
        /// </summary>
        public bool TryGetInstance<T>(out T result)
        {
            ThrowIfDisposed();

            if (_registry.TryGetValue(typeof(T), out var instance))
            {
                result = (T)instance;
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// Registers an externally created instance of type T.
        /// </summary>
        public void AddInstance<T>(T instance)
        {
            ThrowIfDisposed();
            ArgumentNullException.ThrowIfNull(instance);

            if (!_registry.TryAdd(typeof(T), instance))
                throw new InvalidOperationException(
                    $"An instance of type '{typeof(T).Name}' is already registered.");
        }

        /// <summary>
        /// Registers an instance, replacing any existing one.
        /// </summary>
        public void ReplaceInstance<T>(T instance)
        {
            ThrowIfDisposed();
            ArgumentNullException.ThrowIfNull(instance);
            _registry[typeof(T)] = instance;
        }

        /// <summary>
        /// Removes a registered instance of type T.
        /// </summary>
        public bool RemoveInstance<T>()
        {
            ThrowIfDisposed();
            return _registry.Remove(typeof(T));
        }

        public bool IsRegistered<T>() => _registry.ContainsKey(typeof(T));

        private void ThrowIfDisposed()
        {
            ObjectDisposedException.ThrowIf(_disposed, this);
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;

            foreach (var instance in _registry.Values)
            {
                if (instance is IDisposable disposable)
                    disposable.Dispose();
            }

            _registry.Clear();
        }
    }
}
