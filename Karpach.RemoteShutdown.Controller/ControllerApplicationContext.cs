using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Karpach.RemoteShutdown.Controller.Helpers;
using Karpach.RemoteShutdown.Controller.Interfaces;
using Karpach.RemoteShutdown.Controller.Properties;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Win32;

namespace Karpach.RemoteShutdown.Controller
{
    public class ControllerApplicationContext: ApplicationContext
    {
        private readonly ITrayCommandHelper _trayCommandHelper;
        private readonly SettingsForm _settingsForm;
        private readonly IHostHelper _hostHelper;
        private readonly NotifyIcon _trayIcon;        
        private readonly ToolStripMenuItem _commandButton;
        private readonly GlobalHotkeyHelper _hotkeyHelper;
        private System.Windows.Forms.Timer _autoHideTimer;
        private const int AutoHideDelayMs = 60000; // 60 seconds

        public ControllerApplicationContext(ITrayCommandHelper trayCommandHelper, SettingsForm settingsForm, IHostHelper hostHelper)
        {
            _trayCommandHelper = trayCommandHelper;
            _settingsForm = settingsForm;
            _hostHelper = hostHelper;
            var notifyContextMenu = new ContextMenuStrip();

            _commandButton = new ToolStripMenuItem(_trayCommandHelper.GetText((TrayCommandType)Settings.Default.DefaultCommand))
            {
                Image = Resources.Shutdown.ToBitmap()
            };
            _commandButton.Click += ShutDownClick;
            notifyContextMenu.Items.Add(_commandButton);

            notifyContextMenu.Items.Add("-");

            var settings = new ToolStripMenuItem("Settings")
            {
                Image = Resources.Settings.ToBitmap()
            };
            settings.Click += SettingsClick;
            notifyContextMenu.Items.Add(settings);

            notifyContextMenu.Items.Add("-");

            var exit = new ToolStripMenuItem("Exit")
            {
                Image = Resources.Exit.ToBitmap()
            };
            exit.Click += Exit;
            notifyContextMenu.Items.Add(exit);


            // Initialize Tray Icon            
            _trayIcon = new NotifyIcon
            {
                Icon = Resources.AppIcon,
                ContextMenuStrip = notifyContextMenu,
                Visible = !Settings.Default.HideTrayIcon
            };

            // Initialize global hotkey for revealing tray icon (Ctrl+Shift+Alt+R)
            _hotkeyHelper = new GlobalHotkeyHelper();
            _hotkeyHelper.HotkeyPressed += OnRevealHotkeyPressed;
            _hotkeyHelper.Register();

            // Initialize auto-hide timer
            _autoHideTimer = new System.Windows.Forms.Timer();
            _autoHideTimer.Interval = AutoHideDelayMs;
            _autoHideTimer.Tick += OnAutoHideTimerTick;

            _hostHelper.SecretCode = Settings.Default.SecretCode;
            _hostHelper.DefaultCommand = (TrayCommandType)Settings.Default.DefaultCommand;
            _hostHelper.CreateHostAsync(Settings.Default.RemotePort);
        }

        private void OnRevealHotkeyPressed(object sender, EventArgs e)
        {
            // Only respond if tray icon is hidden
            if (!_trayIcon.Visible)
            {
                RevealTrayIcon();
            }
        }

        private void RevealTrayIcon()
        {
            // Require password if set
            if (!PasswordDialog.ValidatePassword())
            {
                return;
            }

            // Show the tray icon
            _trayIcon.Visible = true;

            // Start auto-hide timer if HideTrayIcon setting is enabled
            if (Settings.Default.HideTrayIcon)
            {
                _autoHideTimer.Stop();
                _autoHideTimer.Start();
            }
        }

        private void OnAutoHideTimerTick(object sender, EventArgs e)
        {
            _autoHideTimer.Stop();
            
            // Only auto-hide if the setting is still enabled
            if (Settings.Default.HideTrayIcon)
            {
                _trayIcon.Visible = false;
            }
        }

        private void ResetAutoHideTimer()
        {
            if (Settings.Default.HideTrayIcon && _trayIcon.Visible)
            {
                _autoHideTimer.Stop();
                _autoHideTimer.Start();
            }
        }

        private void SettingsClick(object sender, EventArgs e)
        {
            // Stop auto-hide timer while settings dialog is open
            _autoHideTimer.Stop();

            // Require password if set
            if (!PasswordDialog.ValidatePassword())
            {
                ResetAutoHideTimer();
                return;
            }

            if (_settingsForm.ShowDialog() == DialogResult.OK)
            {
                if (Settings.Default.RemotePort != _settingsForm.Port)
                {
                    _hostHelper.CreateHostAsync(_settingsForm.Port);
                }
                if (Settings.Default.AutoStart != _settingsForm.AutoStart)
                {
                    SetAutoStart(_settingsForm.AutoStart);
                }
                _commandButton.Text = _trayCommandHelper.GetText(_settingsForm.CommandType);
                Settings.Default.AutoStart = _settingsForm.AutoStart;
                Settings.Default.DefaultCommand = (int)_settingsForm.CommandType;
                Settings.Default.RemotePort = _settingsForm.Port;
                Settings.Default.SecretCode = _settingsForm.SecretCode;
                Settings.Default.HideTrayIcon = _settingsForm.HideTrayIcon;
                Settings.Default.AdminPassword = _settingsForm.AdminPassword;
                Settings.Default.Save();
                // Update host helper
                _hostHelper.SecretCode = Settings.Default.SecretCode;
                _hostHelper.DefaultCommand = (TrayCommandType)Settings.Default.DefaultCommand;

                // Apply hide tray icon setting
                if (Settings.Default.HideTrayIcon)
                {
                    _trayIcon.Visible = false;
                }
            }
            else
            {
                // User cancelled, restart auto-hide timer if needed
                ResetAutoHideTimer();
            }
        }

        private void SetAutoStart(bool autoStart)
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (autoStart)
            {
                // Add the value in the registry so that the application runs at startup
                rkApp?.SetValue("Karpach.RemoteShutdown", Application.ExecutablePath);
            }
            else
            {
                rkApp?.DeleteValue("Karpach.RemoteShutdown", false);
            }
        }

        private void ShutDownClick(object sender, EventArgs e)
        {
            ResetAutoHideTimer();
            _trayCommandHelper.RunCommand((TrayCommandType)Settings.Default.DefaultCommand);
        }

        void Exit(object sender, EventArgs e)
        {
            // Require password if set
            if (!PasswordDialog.ValidatePassword())
            {
                ResetAutoHideTimer();
                return;
            }

            // Cleanup
            _autoHideTimer?.Stop();
            _autoHideTimer?.Dispose();
            _hotkeyHelper?.Dispose();
            
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            _trayIcon.Visible = false;            
            _hostHelper.Cancel();
            Application.Exit();
        }        
    }
}