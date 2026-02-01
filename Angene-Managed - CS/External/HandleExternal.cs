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

        // Discord
        public void SetDiscordRichPresence(
            DiscordGameSDK.ActivityType activityType, string details, string state,
            int activityStart, int activityEnd,
            string largeImageKey, string largeImageText, string smallImageKey, string smallImageText,
            string inviteCoverImageKey, string inviteCoverText,
            string partyId, int partySize, int partyMax, string joinSecret, string spectateSecret,
            uint supportedPlatforms,
            bool useDirectRPC = false, bool useTimestamps = false, bool useParty = false, bool useSecrets = false, bool usePlatforms = false,
            bool verbose = false
            )
        {
            // Define activity
            DiscordGameSDK.Activity activity = new DiscordGameSDK.Activity();
            if ( discord == null )
            {
                Console.WriteLine("Discord Rich Presence Change called before initialization!");
            }
            if (verbose)
            {
                Console.WriteLine("Setting Discord Rich Presence: Type={0}, Details={1}, State={2}", activityType, details, state);
            }
            activity.Type = activityType;
            activity.Details = details;
            activity.State = state;
            if (verbose)
            {
                Console.WriteLine("Using Discord Invite Cover: Image={0}, Text={1}", inviteCoverImageKey, inviteCoverText);
            }
            // Assets
            ActivityAssets assets = new ActivityAssets();
            assets.LargeImage = largeImageKey;
            assets.LargeText = largeImageText;
            assets.SmallImage = smallImageKey;
            assets.SmallText = smallImageText;
            activity.Assets = assets;
            if (verbose)
            {
                 Console.WriteLine("Using Discord Assets: LargeImage={0}, LargeText={1}, SmallImage={2}, SmallText={3}", largeImageKey, largeImageText, smallImageKey, smallImageText);
            }
            /*
            // show supported platforms if enabled
            // Desktop = 1, Mobile = 2, Web = 4
            // ---------------------------------------
            if ( usePlatforms ) 
            { 
                activity.SupportedPlatforms = supportedPlatforms;
                if (verbose)
                {
                    Console.WriteLine("Using Discord Supported Platforms: {0}", supportedPlatforms);
                }
            }
            */
            // If timestamps
            if (useTimestamps)
            {
                DiscordGameSDK.ActivityTimestamps timestamps = new DiscordGameSDK.ActivityTimestamps();
                timestamps.Start = activityStart;
                timestamps.End = activityEnd;
                activity.Timestamps = timestamps;
                if (verbose)
                {
                    Console.WriteLine("Using Discord Timestamps: Start={0}, End={1}", activityStart, activityEnd);
                }
            }
            // If using party
            if (useParty)
            {
                DiscordGameSDK.ActivityParty party = new DiscordGameSDK.ActivityParty();
                DiscordGameSDK.PartySize size = new DiscordGameSDK.PartySize();
                party.Id = partyId;
                size.CurrentSize = partySize;
                size.MaxSize = partyMax;
                party.Size = size;
                if (useSecrets)
                {
                    DiscordGameSDK.ActivitySecrets secrets = new DiscordGameSDK.ActivitySecrets();
                    secrets.Spectate = spectateSecret;
                    secrets.Join = joinSecret;
                    activity.Secrets = secrets;
                    if (verbose)
                    {
                        Console.WriteLine("Using Discord Secrets: Join={0}, Spectate={1}", joinSecret, spectateSecret);
                    }
                }
                activity.Party = party;
                if (verbose)
                {
                    Console.WriteLine("Using Discord Party: Id={0}, Size={1}/{2}", partyId, partySize, partyMax);
                }
            }
            // Set activity
            discord?.GetActivityManager().UpdateActivity(activity, result =>
            {
                if (verbose)
                {
                    Console.WriteLine("Discord Rich Presence Update Result: {0}", result);
                }
            });
        }



        private void DiscordGameSDKLogIssueFunction(LogLevel level, string message)
        {
            Console.WriteLine("DiscordGameSDK:{0} - {1}", level, message);
        }

        public void Initialize()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Console.WriteLine("Initialize Called for HandleExternal, Initialize external SDKs...");
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
