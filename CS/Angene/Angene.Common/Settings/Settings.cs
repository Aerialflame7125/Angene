using System;
using System.Collections;
using System.Collections.Generic;

namespace Angene.Common.Settings
{
    public class Settings
    {
        private readonly Dictionary<string, Dictionary<string, object>> _store = new();
        private readonly Dictionary<string, Func<object, bool>> _validators = new();

        public event Action<string, object>? OnSettingsChanged;

        // load defaults when instantiated
        public Settings()
        {
            LoadDefaults();
        }

        public void LoadDefaults()
        {
            Register("Console.LogDebugToConsole", 0,
                v => v is int i && i is 0 or 1);

            Register("Main.Version", "Angene CS v0.1c44 | Brain Implosion");

            Register("Main.getIsGameAllowedForWebsockets", false,
                v => v is bool);
        }

        public void Register(string key, object defaultValue, Func<object, bool>? validator = null)
        {
            var (ns, field) = ParseKey(key);

            if (!_store.ContainsKey(ns))
                _store[ns] = new Dictionary<string, object>();

            // Write default if key somehow missing (i dont know how it could be missing but I guess.)
            if (!_store[ns].ContainsKey(field))
                _store[ns][field] = defaultValue;

            if (validator != null)
                _validators[key] = validator;
        }

        public object? GetSetting(string key)
        {
            var (ns, field) = ParseKey(key);

            if (_store.TryGetValue(ns, out var nsDict) &&
                nsDict.TryGetValue(field, out var value))
                return value;

            return null;
        }

        public T? GetSetting<T>(string key)
        {
            var raw = GetSetting(key);
            if (raw is T typed) return typed;
            return default;
        }

        public bool SetSetting(string key, object value)
        {
            var (ns, field) = ParseKey(key);

            // if unregistered, register then set key.
            if (!_store.TryGetValue(ns, out var nsDict) || !nsDict.ContainsKey(field))
                Register(key, null);

            // Run validator if one exists
            if (_validators.TryGetValue(key, out var validate) && !validate(value))
                return false;

            nsDict[field] = value;
            OnSettingsChanged?.Invoke(key, value);
            return true;
        }

        private static (string ns, string field) ParseKey(string key)
        {
            int dot = key.IndexOf('.');
            if (dot < 0) throw new ArgumentException($"Key must be 'Namespace.Field', got: {key}");
            return (key[..dot], key[(dot + 1)..]);
        }
    }
}