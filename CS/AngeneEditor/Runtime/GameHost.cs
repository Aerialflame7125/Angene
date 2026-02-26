using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace AngeneEditor.Runtime
{
    /// <summary>
    /// Manages launching the game process and embedding its window
    /// into the editor preview panel via Win32 SetParent.
    ///
    /// Window count tracking:
    ///   If the game creates > 1 window, the editor detects it
    ///   and fires the MultiWindowWarning event so the shell
    ///   can prompt the user.
    /// </summary>
    public sealed class GameHost : IDisposable
    {
        [DllImport("user32.dll")] private static extern IntPtr SetParent(IntPtr hWnd, IntPtr hParent);
        [DllImport("user32.dll")] private static extern bool SetWindowPos(IntPtr hWnd, IntPtr after, int x, int y, int w, int h, uint flags);
        [DllImport("user32.dll")] private static extern int SetWindowLong(IntPtr hWnd, int idx, int newVal);
        [DllImport("user32.dll")] private static extern int GetWindowLong(IntPtr hWnd, int idx);
        [DllImport("user32.dll")] private static extern bool ShowWindow(IntPtr hWnd, int cmd);
        [DllImport("user32.dll")] private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);
        [DllImport("user32.dll")] private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint pid);
        [DllImport("user32.dll")] private static extern bool IsWindowVisible(IntPtr hWnd);

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        private const int GWL_STYLE = -16;
        private const int WS_CAPTION = 0x00C00000;
        private const int WS_THICKFRAME = 0x00040000;
        private const int WS_BORDER = 0x00800000;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOZORDER = 0x0004;
        private const uint SWP_FRAMECHANGED = 0x0020;

        private Process? _process;
        private IntPtr _gameHwnd = IntPtr.Zero;
        private Panel? _host;
        private System.Windows.Forms.Timer? _embedTimer;
        private System.Windows.Forms.Timer? _windowCountTimer;

        private readonly List<IntPtr> _knownWindows = new();

        public bool IsRunning => _process != null && !_process.HasExited;
        public bool IsEmbedded { get; private set; }
        public int WindowCount { get; private set; }

        public event Action? GameStarted;
        public event Action? GameStopped;
        public event Action<int>? MultiWindowWarning; // fires with window count when > 1
        public event Action<string>? LogLine;

        // ── Launch ───────────────────────────────────────────────────────────────

        /// <summary>
        /// Builds the project and launches it, embedding into the host panel.
        /// </summary>
        public void Launch(string projectDir, Panel hostPanel, bool verbose = false)
        {
            if (IsRunning) Stop();

            _host = hostPanel;
            _gameHwnd = IntPtr.Zero;
            IsEmbedded = false;
            WindowCount = 0;
            _knownWindows.Clear();

            // Build first
            if (!Build(projectDir)) return;

            // Find the native host executable
            string hostExe = Path.Combine(projectDir, "bin", "Debug", "net8.0", "AngenHost.exe");
            if (!File.Exists(hostExe))
            {
                // Fallback: look for any .exe in output dir
                var exes = Directory.GetFiles(
                    Path.Combine(projectDir, "bin", "Debug", "net8.0"), "*.exe");
                if (exes.Length == 0)
                {
                    LogLine?.Invoke("[Editor] No host executable found after build.");
                    return;
                }
                hostExe = exes[0];
            }

            string args = verbose ? "--verbose" : "";

            _process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = hostExe,
                    Arguments = args,
                    WorkingDirectory = projectDir,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = false,
                },
                EnableRaisingEvents = true
            };

            _process.OutputDataReceived += (_, e) => { if (e.Data != null) LogLine?.Invoke(e.Data); };
            _process.ErrorDataReceived += (_, e) => { if (e.Data != null) LogLine?.Invoke($"[ERR] {e.Data}"); };
            _process.Exited += (_, _) => { GameStopped?.Invoke(); CleanupProcess(); };

            _process.Start();
            _process.BeginOutputReadLine();
            _process.BeginErrorReadLine();

            GameStarted?.Invoke();
            LogLine?.Invoke($"[Editor] Game process started (PID {_process.Id})");

            // Poll for the game window to appear, then embed it
            StartEmbedPolling();

            // Poll for extra windows
            StartWindowCountPolling();
        }

        // ── Stop ─────────────────────────────────────────────────────────────────

        public void Stop()
        {
            _embedTimer?.Stop();
            _windowCountTimer?.Stop();

            if (_gameHwnd != IntPtr.Zero && _host != null)
            {
                // Restore window to standalone before killing
                SetWindowLong(_gameHwnd, GWL_STYLE,
                    GetWindowLong(_gameHwnd, GWL_STYLE) | WS_CAPTION | WS_THICKFRAME);
                SetParent(_gameHwnd, IntPtr.Zero);
                ShowWindow(_gameHwnd, 0); // hide
            }

            try { _process?.Kill(); } catch { }
            CleanupProcess();
            IsEmbedded = false;
            LogLine?.Invoke("[Editor] Game stopped.");
        }

        // ── Build ─────────────────────────────────────────────────────────────────

        private bool Build(string projectDir)
        {
            LogLine?.Invoke("[Editor] Building project...");

            var build = Process.Start(new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = "build --configuration Debug",
                WorkingDirectory = projectDir,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
            });

            if (build == null) { LogLine?.Invoke("[Editor] Build failed to start."); return false; }

            build.OutputDataReceived += (_, e) => { if (e.Data != null) LogLine?.Invoke(e.Data); };
            build.ErrorDataReceived += (_, e) => { if (e.Data != null) LogLine?.Invoke($"[Build ERR] {e.Data}"); };
            build.BeginOutputReadLine();
            build.BeginErrorReadLine();
            build.WaitForExit();

            bool ok = build.ExitCode == 0;
            LogLine?.Invoke(ok ? "[Editor] Build succeeded." : $"[Editor] Build failed (exit {build.ExitCode}).");
            return ok;
        }

        // ── Embed polling ─────────────────────────────────────────────────────────

        private void StartEmbedPolling()
        {
            _embedTimer = new System.Windows.Forms.Timer { Interval = 200 };
            _embedTimer.Tick += TryEmbed;
            _embedTimer.Start();
        }

        private void TryEmbed(object? s, EventArgs e)
        {
            if (_process == null || _process.HasExited || _host == null)
            {
                _embedTimer?.Stop();
                return;
            }

            IntPtr found = FindProcessWindow(_process.Id);
            if (found == IntPtr.Zero) return;

            _embedTimer?.Stop();
            _gameHwnd = found;
            EmbedWindow(_gameHwnd, _host);
            IsEmbedded = true;
            LogLine?.Invoke("[Editor] Game window embedded.");
        }

        private void EmbedWindow(IntPtr hwnd, Panel host)
        {
            // Strip window chrome
            int style = GetWindowLong(hwnd, GWL_STYLE);
            style &= ~(WS_CAPTION | WS_THICKFRAME | WS_BORDER);
            SetWindowLong(hwnd, GWL_STYLE, style);
            SetWindowPos(hwnd, IntPtr.Zero, 0, 0, 0, 0,
                SWP_NOMOVE | SWP_NOZORDER | SWP_FRAMECHANGED);

            SetParent(hwnd, host.Handle);

            // Resize to fill host panel
            ResizeEmbedded(host.Width, host.Height);

            host.Resize += (_, _) => ResizeEmbedded(host.Width, host.Height);
        }

        public void ResizeEmbedded(int w, int h)
        {
            if (_gameHwnd == IntPtr.Zero) return;
            SetWindowPos(_gameHwnd, IntPtr.Zero, 0, 0, w, h,
                SWP_NOZORDER);
        }

        // ── Multi-window polling ──────────────────────────────────────────────────

        private void StartWindowCountPolling()
        {
            _windowCountTimer = new System.Windows.Forms.Timer { Interval = 500 };
            _windowCountTimer.Tick += CheckWindowCount;
            _windowCountTimer.Start();
        }

        private void CheckWindowCount(object? s, EventArgs e)
        {
            if (_process == null || _process.HasExited) return;

            var windows = GetProcessWindows(_process.Id);
            int count = windows.Count;

            if (count > WindowCount && count > 1)
            {
                WindowCount = count;
                MultiWindowWarning?.Invoke(count);

                // Track new windows for external display
                foreach (var w in windows)
                    if (!_knownWindows.Contains(w))
                        _knownWindows.Add(w);
            }
            else
            {
                WindowCount = count;
            }
        }

        // ── Win32 helpers ─────────────────────────────────────────────────────────

        private static IntPtr FindProcessWindow(int pid)
        {
            IntPtr result = IntPtr.Zero;
            EnumWindows((hwnd, _) =>
            {
                GetWindowThreadProcessId(hwnd, out uint wpid);
                if ((int)wpid == pid && IsWindowVisible(hwnd))
                {
                    result = hwnd;
                    return false; // stop
                }
                return true;
            }, IntPtr.Zero);
            return result;
        }

        private static List<IntPtr> GetProcessWindows(int pid)
        {
            var list = new List<IntPtr>();
            EnumWindows((hwnd, _) =>
            {
                GetWindowThreadProcessId(hwnd, out uint wpid);
                if ((int)wpid == pid && IsWindowVisible(hwnd))
                    list.Add(hwnd);
                return true;
            }, IntPtr.Zero);
            return list;
        }

        private void CleanupProcess()
        {
            _process?.Dispose();
            _process = null;
        }

        public void Dispose()
        {
            Stop();
            _embedTimer?.Dispose();
            _windowCountTimer?.Dispose();
        }
    }
}