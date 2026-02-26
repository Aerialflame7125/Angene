using Angene.Common;
using Angene.Essentials;
using Angene.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing; // Requires System.Drawing.Common NuGet
using System.Drawing.Imaging;
using System.IO;

namespace Angene.Main
{
    public class Framebuffer : IDisposable
    {
        public int Width { get; }
        public int Height { get; }
        public IntPtr BufferPtr { get; private set; }
        private byte[] _pixels;

        public Framebuffer(int width, int height)
        {
            Width = width;
            Height = height;
            int size = width * height * 4;
            BufferPtr = Marshal.AllocHGlobal(size);
            // Zero out memory
            unsafe
            {
                byte* p = (byte*)BufferPtr.ToPointer();
                for (int i = 0; i<size; i++) p[i] = 0;
            }
        }

        public void Clear(byte r, byte g, byte b) { /* Fast memory fill */ }
        public void Dispose()
        {
            if (BufferPtr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(BufferPtr);
                BufferPtr = IntPtr.Zero;
            }
        }
    }

    internal static class WebSocketManager
    {
        public static readonly List<WebSocket> ActiveClients = new();
        private static readonly SemaphoreSlim _lock = new(1, 1);

        public static async Task AddClient(WebSocket ws)
        {
            await _lock.WaitAsync();
            ActiveClients.Add(ws);
            _lock.Release();
        }

        public static async Task RemoveClient(WebSocket ws)
        {
            await _lock.WaitAsync();
            ActiveClients.Remove(ws);
            _lock.Release();
        }
    }

    internal class Websocket
    {
        public class WebStreamer : IScreenPlay
        {
            private Window _parentWindow;

            public WebStreamer(Window window)
            {
                _parentWindow = window;
            }

            public void Start() { /* Init if needed */ }

            public void LateUpdate(double dt)
            {
                // Don't waste CPU cycles if no one is watching the show
                if (WebSocketManager.ActiveClients.Count == 0) return;

                // Pull pixels from our "faked" framebuffer (the GDI Bitmap)
                if (_parentWindow.Graphics is WSGraphicsContext wsContext)
                {
                    byte[] rawPixels = wsContext.GetRawPixels();
                    byte[] compressedFrame = CompressToJpeg(rawPixels, _parentWindow.Width, _parentWindow.Height);

                    // Fire and forget the broadcast so we don't lag the main engine thread
                    _ = Broadcast(compressedFrame);
                }
            }

            private byte[] CompressToJpeg(byte[] rawPixels, int width, int height)
            {
                using (var bitmap = new System.Drawing.Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
                {
                    var data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, width, height),
                        System.Drawing.Imaging.ImageLockMode.WriteOnly, bitmap.PixelFormat);

                    // Copy raw pixels into the System.Drawing bitmap
                    Marshal.Copy(rawPixels, 0, data.Scan0, rawPixels.Length);
                    bitmap.UnlockBits(data);

                    using (var ms = new System.IO.MemoryStream())
                    {
                        // Use JPEG to keep the payload small
                        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        return ms.ToArray();
                    }
                }
            }
        }

        public static async Task Broadcast(byte[] data)
        {
            var buffer = new ArraySegment<byte>(data);
            List<Task> sendTasks = new();

            // Broadcast to every degenerate currently connected
            foreach (var client in WebSocketManager.ActiveClients)
            {
                if (client.State == WebSocketState.Open)
                {
                    sendTasks.Add(client.SendAsync(buffer, WebSocketMessageType.Binary, true, CancellationToken.None));
                }
            }

            await Task.WhenAll(sendTasks);
        }

        internal static Action<string>? OnInputReceived;

        internal static async Task ProcessWebSocketAsync(HttpListenerContext context)
        {
            WebSocketContext wsContext = await context.AcceptWebSocketAsync(null);
            WebSocket webSocket = wsContext.WebSocket;

            await WebSocketManager.AddClient(webSocket);
            Logger.Log("Client connected to streamer.", LoggingTarget.Engine, LogLevel.Info);

            try
            {
                var buffer = new byte[4096]; // larger buffer for JSON packets
                while (webSocket.State == WebSocketState.Open)
                {
                    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close) break;

                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        string json = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        OnInputReceived?.Invoke(json); // fire the callback
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"WS Error: {ex.Message}", LoggingTarget.Engine, LogLevel.Error);
            }
            finally
            {
                await WebSocketManager.RemoveClient(webSocket);
                webSocket.Dispose();
            }
        }

        internal static async Task StartWebsocket(HttpListener listener)
        {
            while (true)
            {
                // Wait for an incoming request
                HttpListenerContext context = await listener.GetContextAsync();

                // Check if it's a WebSocket request
                if (context.Request.IsWebSocketRequest)
                {
                    _ = ProcessWebSocketAsync(context);
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.Close();
                }
            }
        }
    }
}
