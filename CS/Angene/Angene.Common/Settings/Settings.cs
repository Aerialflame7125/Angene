using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public string saveKeys(string path)
        {
            try
            {
                JObject jo = new();
                foreach (var key in _store.Keys)
                {
                    var (ns, field) = ParseKey(key);
                    _store.TryGetValue(ns, out var nsDict);
                    nsDict.TryGetValue(field, out var value);

                    if (!File.Exists(path))
                        File.Create(path).Close();

                    jo[ns] = (JToken)value;
                }
                string o = jo.ToString();
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(o);
                File.WriteAllBytes(path, bytes);
                return path;
            }
            catch (Exception e)
            {
                throw new AngeneException("An exception was caught when attempting to save keys.", e);
            }
        }

        public Dictionary<string, Dictionary<string, object>> readKeysFromFile(string path)
        {
            try
            {
                string js = File.ReadAllText(path);
                JObject root = JObject.Parse(js);

                foreach (var ns in root.Properties())
                {
                    if (ns.Value is JObject fields)
                    {
                        foreach (var field in fields.Properties())
                        {
                            string key = $"{ns.Name}.{field.Name}";
                            SetSetting(key, field.Value.ToObject<object>());
                        }
                    }
                }

                return _store;
            }
            catch (Exception e)
            {
                throw new AngeneException("An exception was caught when attempting to read keys.", e);
            }
        }
    }
}