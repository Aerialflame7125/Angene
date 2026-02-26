using System;
using System.Collections;
using System.Collections.Generic;

namespace Angene.Common.Settings
{
    public class Settings
    {
        public List<string> namespaces = new List<string>(["Console", "Main"]);
        public Dictionary<string, object> consoleSettings = new Dictionary<string, object>();

        public Action<string, object>[] OnSettingsChanged = Array.Empty<Action<string, object>>();

        // load defaults when instantiated
        public Settings()
        {
            LoadDefaults();
        }

        public void LoadDefaults()
        {
            // assign value
            consoleSettings["LogDebugToConsole"] = 0;
        }

        public object GetSetting(string key)
        {
            string[] keyParts = key.Split('.');
            if (keyParts.Length < 2)
                return "-1";

            string ns = keyParts[0];
            if (namespaces.Contains(ns))
            {
                if (ns == "Console")
                {
                    if (keyParts[1] == "LogDebugToConsole")
                    {
                        // check if setting exists
                        if (!consoleSettings.ContainsKey("LogDebugToConsole"))
                        {
                            consoleSettings["LogDebugToConsole"] = 0;
                        }
                        return consoleSettings["LogDebugToConsole"].ToString();
                    }
                }
                if (ns == "Main")
                {
                    if (keyParts[1] == "Version")
                    {
                        return "v0.1c35";
                    }
                    if (keyParts[1] == "getIsGameAllowedForWebsockets")
                    {
                        return consoleSettings["getIsGameAllowedForWebsockets"];
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
                if (ns == "Main")
                {
                    if (keyParts[1] == "getIsGameAllowedForWebsockets" && value is bool boolValue)
                    {
                        consoleSettings["getIsGameAllowedForWebsockets"] = boolValue;
                    }
                }
            }
        }
    }
}