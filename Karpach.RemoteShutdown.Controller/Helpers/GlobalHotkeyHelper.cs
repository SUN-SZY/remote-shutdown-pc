using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Karpach.RemoteShutdown.Controller.Helpers
{
    /// <summary>
    /// A helper class to register and handle global hotkeys.
    /// The hotkey Ctrl+Shift+Alt+R is used to reveal the tray icon.
    /// </summary>
    public class GlobalHotkeyHelper : IDisposable
    {
        private const int WM_HOTKEY = 0x0312;
        private const int HOTKEY_ID = 9000;

        // Modifier keys
        private const uint MOD_ALT = 0x0001;
        private const uint MOD_CONTROL = 0x0002;
        private const uint MOD_SHIFT = 0x0004;
        private const uint MOD_NOREPEAT = 0x4000;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private readonly HotkeyWindow _window;
        private bool _disposed;

        public event EventHandler HotkeyPressed;

        public GlobalHotkeyHelper()
        {
            _window = new HotkeyWindow();
            _window.HotkeyPressed += (s, e) => HotkeyPressed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Registers the global hotkey Ctrl+Shift+Alt+R
        /// </summary>
        public bool Register()
        {
            // Register Ctrl+Shift+Alt+R
            uint modifiers = MOD_CONTROL | MOD_SHIFT | MOD_ALT | MOD_NOREPEAT;
            uint key = (uint)Keys.R;
            return RegisterHotKey(_window.Handle, HOTKEY_ID, modifiers, key);
        }

        /// <summary>
        /// Unregisters the global hotkey
        /// </summary>
        public void Unregister()
        {
            UnregisterHotKey(_window.Handle, HOTKEY_ID);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Unregister();
                _window.Dispose();
                _disposed = true;
            }
        }

        /// <summary>
        /// Hidden window to receive hotkey messages
        /// </summary>
        private class HotkeyWindow : NativeWindow, IDisposable
        {
            public event EventHandler HotkeyPressed;

            public HotkeyWindow()
            {
                CreateHandle(new CreateParams());
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOTKEY_ID)
                {
                    HotkeyPressed?.Invoke(this, EventArgs.Empty);
                }
                base.WndProc(ref m);
            }

            public void Dispose()
            {
                DestroyHandle();
            }
        }
    }
}
