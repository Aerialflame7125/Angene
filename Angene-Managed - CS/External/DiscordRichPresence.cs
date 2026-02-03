using Angene.Main;
using DiscordRPC;
using DiscordRPC.Logging;
using DiscordRPC.Message;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Angene.External
{
    // Honestly its all because of PPY's implementation of RPC that I even know how to use it.
    // Not to mention, this discord implementation made me realize i need a logger
    //
    public partial class DiscordRichPresence
    {
        private static readonly int ellipsisLength = Encoding.UTF8.GetByteCount(new[] { '…' });

        private static string? clampLength(string? str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            string trimmed = str.Trim();
            if (trimmed.Length < 2)
                return trimmed.PadRight(2, '\u200B');

            if (Encoding.UTF8.GetByteCount(str) <= 128)
                return str;

            ReadOnlyMemory<char> strMem = str.AsMemory();

            do
            {
                strMem = strMem[..^1];
            }
            while (Encoding.UTF8.GetByteCount(strMem.Span) + ellipsisLength > 128);

            return string.Create(strMem.Length + 1, strMem, (span, mem) =>
            {
                mem.Span.CopyTo(span);
                span[^1] = '…';
            });
        }

        public sealed class DiscordPresenceState
        {
            public string? State { get; set; }
            public string? Details { get; set; }
            public string? LargeImageKey { get; set; }
            public string? LargeImageText { get; set; }
            public string? SmallImageKey { get; set; }
            public string? SmallImageText { get; set; }
            public Button[]? Buttons { get; set; }
        }

        private readonly DiscordRpcClient client;
        private CancellationTokenSource? debounceCts;
        private DiscordPresenceState? pending;

        public DiscordRichPresence(string clientId)
        {
            client = new DiscordRpcClient(clientId)
            {
                SkipIdenticalPresence = true
            };

            client.OnReady += (_, __) =>
                Logger.Log("Discord RPC ready.", LoggingTarget.Network, Angene.Main.LogLevel.Info);

            client.OnError += (_, e) =>
                Logger.Log($"Discord RPC error: {e.Message}", LoggingTarget.Network, Angene.Main.LogLevel.Error);

            client.Initialize();
        }

        public void SetPresence(DiscordPresenceState state)
        {
            pending = state;
            schedule();
        }

        public void Clear()
        {
            pending = null;
            client.ClearPresence();
        }

        private void schedule()
        {
            debounceCts?.Cancel();
            debounceCts = new CancellationTokenSource();

            _ = Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(200, debounceCts.Token);

                    if (pending == null)
                    {
                        client.ClearPresence();
                        return;
                    }

                    client.SetPresence(new RichPresence
                    {
                        State = clampLength(pending.State),
                        Details = clampLength(pending.Details),
                        Assets = new Assets
                        {
                            LargeImageKey = pending.LargeImageKey,
                            LargeImageText = pending.LargeImageText,
                            SmallImageKey = pending.SmallImageKey,
                            SmallImageText = pending.SmallImageText
                        },
                        Buttons = pending.Buttons
                    });
                }
                catch (TaskCanceledException) { }
            });
        }

        public void Dispose()
        {
            debounceCts?.Cancel();
            client.Dispose();
        }
    }
}
