using System;
using System.Runtime.InteropServices;
using Angene.External.DiscordGameSDK;
using System.Collections.Generic;

namespace Angene.External
{
    public class HandleExternal
    {
        internal Discord? discord { get; private set; }

        // Initialize external implementations such as DiscordGameSDK Game SDK
        private void InitializeDiscordGameSDK()
        {
            discord = new Discord(1467308284322254862, (UInt64)CreateFlags.Default);
        }

        private void DiscordGameSDKLogIssueFunction(LogLevel level, string message)
        {
            Console.WriteLine("DiscordGameSDK:{0} - {1}", level, message);
        }

        public void Initialize()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                InitializeDiscordGameSDK();
                discord?.SetLogHook(LogLevel.Debug, DiscordGameSDKLogIssueFunction);
            }
        }

        internal void Dispose()
        {
            if (discord != null)
            {
                discord.Dispose();
                discord = null;
            }
        }
    }
}
