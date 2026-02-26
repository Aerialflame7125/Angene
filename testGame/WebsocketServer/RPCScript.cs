using Angene.Common;
using Angene.Essentials;
using Angene.External;
using DiscordRPC;
using Org.BouncyCastle.Asn1.Cmp;

namespace Game
{
    internal class RPCScript : IScreenPlay
    {
        private RichPresence presence = new RichPresence
        {
            Assets = new Assets { SmallImageKey = "angene_logo", SmallImageText = $"Running on Angene" }
        };

        private DiscordRichPresence? _rpc = new ("1467308284322254862");
        private PackageTest pt;
        public void Start()
        {
            Logger.LogWarning("Awake() called for RPCScript()", LoggingTarget.MainGame);
            presence.State = "im jeorking it";
            
            presence.Assets.LargeImageKey = "g_khlbfbmaec9sq";
            presence.Assets.LargeImageText = "beer";
            presence.Buttons = new[]
                {
                new Button
                {
                    Label = "join me twin",
                    Url = "https://amretar.com"
                }
            };
            _rpc.SetPresence(presence);
        }

        public void SetText(string text)
        {
            presence.Details = $"Read {text} from package 'game.angpkg'";
            _rpc.SetPresence(presence);
        }

        void Cleanup()
        {
            // Dispose RPC when scene is destroyed
            _rpc?.Dispose();
            _rpc = null;
        }
    }
}
