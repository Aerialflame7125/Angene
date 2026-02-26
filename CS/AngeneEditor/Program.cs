using System;
using System.Windows.Forms;
using AngeneEditor.Theme;

namespace AngeneEditor
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            // Apply dark title bars on Windows 11 where possible
            TryEnableDarkTitleBar();

            try
            {
                Application.Run(new EditorWindow());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Startup Crash",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private static void TryEnableDarkTitleBar()
        {
            // Windows 11 dark mode for title bars via DwmSetWindowAttribute
            // Applied to all future forms via Application.OpenForms is not possible pre-show,
            // so EditorWindow applies it in its constructor via P/Invoke if needed.
            // This is a no-op stub for cross-version safety.
        }
    }
}