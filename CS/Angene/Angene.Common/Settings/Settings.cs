using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Angene.Common.Settings
{
    public class Settings
    {
        private static readonly Dictionary<string, Dictionary<string, object?>> _store = new();
        private static readonly Dictionary<string, Func<object, bool>> _validators = new();
        
        public static Settings Instance = new Settings();

        public event Action<string, object>? OnSettingsChanged;

        // Load defaults when instantiated
        public Settings()
        {
            Instance = this;
            LoadDefaults();
        }

        private void LoadDefaults()
        {
            Register("Console.LogDebugToConsole", 0,
                v => v is int i && i is 0 or 1);

            Register("Main.VersionFloat", 0.3f, v => v is float);

            Register("Main.Version", "Angene v0.3 | Galvanized Square Steel");

            Register("Main.getIsGameAllowedForWebsockets", false,
                v => v is bool);

            Register("Engine.RunningDirectory", null, v => v is string);
            
#if WINDOWS
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            if (!Path.Exists(Path.Combine(localAppData, "Angene")))
            {
                Directory.CreateDirectory(Path.Combine(localAppData, "Angene"));
                Directory.CreateDirectory(Path.Combine(localAppData, "Angene", "Shaders"));
            }
            Register("Graphics.ShaderDirectory", Path.Combine(localAppData, "Angene", "Shaders"), v => v is string);

#elif LINUX
            string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string targetPath = Path.Combine(homeDirectory, ".var");
            
            if (!Path.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
                Directory.CreateDirectory(Path.Combine(targetPath, "Angene"));
                Directory.CreateDirectory(Path.Combine(targetPath, "Angene", "Shaders"));
            }
            targetPath = Path.Combine(targetPath, "Angene", "Shaders");

            Register("Graphics.ShaderDirectory", targetPath);
#else
            // Logger.LogError("Could not recognize system build. Graphics.ShaderDirectory is invalidated.", LoggingTarget.Graphics);
#endif
        }

        public void Register(string key, object? defaultValue, Func<object, bool>? validator = null)
        {
            var (ns, field) = ParseKey(key);

            if (!_store.ContainsKey(ns))
                _store[ns] = new Dictionary<string, object?>();

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

        public bool SetSetting(string key, object? value)
        {
            var (ns, field) = ParseKey(key);

            switch (key)
            {
                case "Main.Version":
                    return false;
                case "Engine.RunningDirectory":
                    if (GetSetting<string?>("Engine.RunningDirectory") == null)
                    {
                        _store[ns][field] = value;
                        if (value != null) OnSettingsChanged?.Invoke(key, value);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "Graphics.ShaderDirectory":
                    return false;
            }

            // If unregistered, register then set key
            if (!_store.TryGetValue(ns, out var nsDict) || !nsDict.ContainsKey(field))
                Register(key, null);

            // Run validator if one exists
            if (value != null && _validators.TryGetValue(key, out var validate) && !validate(value))
                return false;

            _store[ns][field] = value;
            if (value != null) OnSettingsChanged?.Invoke(key, value);
            return true;
        }

        private static (string ns, string field) ParseKey(string key)
        {
            int dot = key.IndexOf('.');
            if (dot < 0) throw new ArgumentException($"Key must be 'Namespace.Field', got: {key}");
            return (key[..dot], key[(dot + 1)..]);
        }

        public string SaveKeys(string path)
        {
            try
            {
                JObject jo = new();
                foreach (var (ns, fields) in _store)
                {
                    JObject nsObject = new();
                    foreach (var (field, value) in fields)
                    {
                        nsObject[field] = value != null ? JToken.FromObject(value) : null;
                    }
                    jo[ns] = nsObject;
                }

                string directory = Path.GetDirectoryName(path) ?? "";
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.WriteAllText(path, jo.ToString());
                return path;
            }
            catch (Exception e)
            {
                throw new Exception("An exception was caught when attempting to save keys.", e);
            }
        }

        public Dictionary<string, Dictionary<string, object?>> ReadKeysFromFile(string path)
        {
            try
            {
                if (!File.Exists(path)) return _store;

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
                throw new Exception("An exception was caught when attempting to read keys.", e);
            }
        }
    }
}