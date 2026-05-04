using Angene.Common;
using Angene.Essentials;
using Angene.Globals;
using Angene.Input;
using Angene.Input.WinInput;
using Angene.Main;
using Angene.Management;
using Angene.Platform;
using Angene.Windows;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if WINDOWS
using Angene.Graphics;
#endif

namespace Game
{
    public class KeyInputTestScene : IScene
    {
        public IRenderer3D? Renderer3D => null;

        private readonly Window _window;
        private List<Entity> _entities = new();
        private KeyDetection _keyDetection = new();

        public KeyInputTestScene(Window window)
        {
            _window = window ?? throw new ArgumentNullException(nameof(window));
        }

        public void Initialize()
        {
            _entities = new List<Entity>();
            _keyDetection.Register(_window.ManagementScene as ManagementScene);
            Logger.Log("[KeyInputTestScene] Initialized.", LoggingTarget.MainGame, LogLevel.Info);
        }

        public List<Entity> GetEntities() => _entities;

        public void OnMessage(IntPtr msgPtr) { }

        public void Render()
        {
#if WINDOWS
            DrawWindows();
#endif
        }

        public void Cleanup()
        {
            _keyDetection.Deregister();
            _entities.Clear();
            Logger.Log("[KeyInputTestScene] Cleaned up.", LoggingTarget.MainGame, LogLevel.Info);
        }

#if WINDOWS
        private void DrawWindows()
        {
            IntPtr hdc = Win32.GetDC((IntPtr)_window.Hwnd);
            if (hdc == IntPtr.Zero) return;

            try
            {
                using var r = new GdiRenderer(hdc);
                r.BeginFrame(_window.Width, _window.Height);
                r.Clear(0.07f, 0.07f, 0.10f, 1.0f);

                r.DrawText(12, 10, "Angene | KeyDetection Test", 0x00FFFF00);
                r.DrawText(12, 28, "Press keys — lit keys are currently held.", 0x00AAAAAA);
                r.DrawText(12, 44, $"Platform: {PlatformDetection.CurrentPlatform}", 0x00555555);

                float startY = 80;

                // Row 1: Esc + F-keys
                DrawKey(r, 12, startY, "Esc", Keys.IKeyCodeMod.Escape);
                DrawKey(r, 80, startY, "F1", Keys.IKeyCodeFunc.f1);
                DrawKey(r, 120, startY, "F2", Keys.IKeyCodeFunc.f2);
                DrawKey(r, 160, startY, "F3", Keys.IKeyCodeFunc.f3);
                DrawKey(r, 200, startY, "F4", Keys.IKeyCodeFunc.f4);
                DrawKey(r, 260, startY, "F5", Keys.IKeyCodeFunc.f5);
                DrawKey(r, 300, startY, "F6", Keys.IKeyCodeFunc.f6);
                DrawKey(r, 340, startY, "F7", Keys.IKeyCodeFunc.f7);
                DrawKey(r, 380, startY, "F8", Keys.IKeyCodeFunc.f8);

                // Row 2: Number row
                float row2Y = startY + 50;
                DrawKey(r, 12, row2Y, "1", Keys.IKeyCodeNum.d1);
                DrawKey(r, 52, row2Y, "2", Keys.IKeyCodeNum.d2);
                DrawKey(r, 92, row2Y, "3", Keys.IKeyCodeNum.d3);
                DrawKey(r, 132, row2Y, "4", Keys.IKeyCodeNum.d4);
                DrawKey(r, 172, row2Y, "5", Keys.IKeyCodeNum.d5);
                DrawKey(r, 212, row2Y, "6", Keys.IKeyCodeNum.d6);
                DrawKey(r, 252, row2Y, "7", Keys.IKeyCodeNum.d7);
                DrawKey(r, 292, row2Y, "8", Keys.IKeyCodeNum.d8);
                DrawKey(r, 332, row2Y, "9", Keys.IKeyCodeNum.d9);
                DrawKey(r, 372, row2Y, "0", Keys.IKeyCodeNum.d0);

                // Row 3: QWERTY
                float row3Y = row2Y + 50;
                DrawKey(r, 12, row3Y, "Q", Keys.IKeyCodeASCII.q);
                DrawKey(r, 52, row3Y, "W", Keys.IKeyCodeASCII.w);
                DrawKey(r, 92, row3Y, "E", Keys.IKeyCodeASCII.e);
                DrawKey(r, 132, row3Y, "R", Keys.IKeyCodeASCII.r);
                DrawKey(r, 172, row3Y, "T", Keys.IKeyCodeASCII.t);
                DrawKey(r, 212, row3Y, "Y", Keys.IKeyCodeASCII.y);
                DrawKey(r, 252, row3Y, "U", Keys.IKeyCodeASCII.u);
                DrawKey(r, 292, row3Y, "I", Keys.IKeyCodeASCII.i);
                DrawKey(r, 332, row3Y, "O", Keys.IKeyCodeASCII.o);
                DrawKey(r, 372, row3Y, "P", Keys.IKeyCodeASCII.p);

                // Row 4: ASDF
                float row4Y = row3Y + 50;
                DrawKey(r, 32, row4Y, "A", Keys.IKeyCodeASCII.a);
                DrawKey(r, 72, row4Y, "S", Keys.IKeyCodeASCII.s);
                DrawKey(r, 112, row4Y, "D", Keys.IKeyCodeASCII.d);
                DrawKey(r, 152, row4Y, "F", Keys.IKeyCodeASCII.f);
                DrawKey(r, 192, row4Y, "G", Keys.IKeyCodeASCII.g);
                DrawKey(r, 232, row4Y, "H", Keys.IKeyCodeASCII.h);
                DrawKey(r, 272, row4Y, "J", Keys.IKeyCodeASCII.j);
                DrawKey(r, 312, row4Y, "K", Keys.IKeyCodeASCII.k);
                DrawKey(r, 352, row4Y, "L", Keys.IKeyCodeASCII.l);

                // Row 5: ZXCV + shifts
                float row5Y = row4Y + 50;
                DrawKeyWide(r, 12, row5Y, "LShift", 70, Keys.IKeyCodeMod.LShift);
                DrawKey(r, 92, row5Y, "Z", Keys.IKeyCodeASCII.z);
                DrawKey(r, 132, row5Y, "X", Keys.IKeyCodeASCII.x);
                DrawKey(r, 172, row5Y, "C", Keys.IKeyCodeASCII.c);
                DrawKey(r, 212, row5Y, "V", Keys.IKeyCodeASCII.v);
                DrawKey(r, 252, row5Y, "B", Keys.IKeyCodeASCII.b);
                DrawKey(r, 292, row5Y, "N", Keys.IKeyCodeASCII.n);
                DrawKey(r, 332, row5Y, "M", Keys.IKeyCodeASCII.m);
                DrawKeyWide(r, 372, row5Y, "RShift", 70, Keys.IKeyCodeMod.RShift);

                // Row 6: Ctrl / Alt / Space
                float row6Y = row5Y + 50;
                DrawKeyWide(r, 12, row6Y, "LCtrl", 55, Keys.IKeyCodeMod.LCtrl);
                DrawKeyWide(r, 77, row6Y, "LAlt", 55, Keys.IKeyCodeMod.LAlt);
                DrawKeyWide(r, 142, row6Y, "Space", 200, Keys.IKeyCodeMod.Space);
                DrawKeyWide(r, 352, row6Y, "RAlt", 55, Keys.IKeyCodeMod.RAlt);
                DrawKeyWide(r, 417, row6Y, "RCtrl", 55, Keys.IKeyCodeMod.RCtrl);

                // Arrow cluster
                float ax = 530, ay = row5Y;
                DrawKey(r, ax + 40, ay, "Up", Keys.IKeyCodeArrow.Up);
                DrawKey(r, ax, ay + 42, "Left", Keys.IKeyCodeArrow.Left);
                DrawKey(r, ax + 40, ay + 42, "Down", Keys.IKeyCodeArrow.Down);
                DrawKey(r, ax + 80, ay + 42, "Right", Keys.IKeyCodeArrow.Right);

                // Legend
                float ly = _window.Height - 36;
                r.DrawRect(12, ly, 32, 18, 0x00336633u);
                r.DrawText(50, ly + 2, "= held", 0x00AAAAAAu);
                r.DrawRect(110, ly, 32, 18, 0x00222233u);
                r.DrawText(148, ly + 2, "= not held", 0x00AAAAAAu);

                r.EndFrame();
            }
            finally
            {
                Win32.ReleaseDC((IntPtr)_window.Hwnd, hdc);
            }
        }

        private void DrawKey(GdiRenderer r, float x, float y, string label, object key)
            => DrawKeyWide(r, x, y, label, 32, key);

        private void DrawKeyWide(GdiRenderer r, float x, float y, string label, float w, object key)
        {
            bool held = KeyDetection.IsKeyDown(key);

            uint bg = held ? 0x003A6E3Au : 0x00222233u;
            uint fg = held ? 0x0000FF00u : 0x00AAAAAAu;
            uint border = held ? 0x0000CC00u : 0x00444466u;

            r.DrawRect(x, y, w, 32, bg);
            r.DrawRect(x, y, w, 1, border);
            r.DrawRect(x, y + 31, w, 1, border);
            r.DrawRect(x, y, 1, 32, border);
            r.DrawRect(x + w - 1, y, 1, 32, border);

            float tx = x + Math.Max(2, (w - label.Length * 7) / 2);
            r.DrawText(tx, y + 9, label, fg);
        }
#endif
    }
}