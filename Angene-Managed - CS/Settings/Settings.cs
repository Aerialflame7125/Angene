
using System;
using System.Collections;
using System.Collections.Generic;

namespace Angene.Settings
{
    public class Settings
    {
        public List<string> namespaces = new List<string>(["Console", "Main"]);
        public Dictionary<string, int> consoleSettings = new Dictionary<string, int>();

        public Action<string, int>[] OnSettingsChanged = Array.Empty<Action<string, int>>();

        public void LoadDefaults()
        {
            consoleSettings.Add("LogDebugToConsole", 0);
        }
        
        public string GetSetting(string key)
        {
            string[] keyParts = key.Split('.');
            string ns = keyParts[0];
            if (namespaces.Contains(ns))
            {
                if (ns == "Console")
                {
                    if (keyParts[1] == "LogDebugToConsole")
                    {
                        return consoleSettings["LogDebugToConsole"].ToString();
                    }
                }
                if (ns == "Main")
                {
                    if (keyParts[1] == "Version")
                    {
                        return "v0.1c26";
                    }
                }
            }
            return "-1"; // Setting not found
        }

        public void SetSetting(string key, object value)
        {
            string[] keyParts = key.Split('.');
            string ns = keyParts[0];

            if (namespaces.Contains(ns))
            {
                if (ns == "Console")
                {
                    if (keyParts[1] == "LogDebugToConsole" && value is int intValue)
                    {
                        consoleSettings["LogDebugToConsole"] = intValue;
                    }
                }
            }
        }
    }
}
