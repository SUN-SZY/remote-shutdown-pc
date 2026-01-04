using System;
using System.Windows.Forms;
using Karpach.RemoteShutdown.Controller.Properties;

namespace Karpach.RemoteShutdown.Controller
{
    public partial class PasswordDialog : Form
    {
        public bool IsPasswordValid { get; private set; }

        public PasswordDialog()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == Settings.Default.AdminPassword)
            {
                IsPasswordValid = true;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                lblError.Visible = true;
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsPasswordValid = false;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Shows the password dialog and returns true if the correct password was entered.
        /// Returns true immediately if no admin password is configured.
        /// </summary>
        public static bool ValidatePassword()
        {
            // If no password is set, allow access
            if (string.IsNullOrEmpty(Settings.Default.AdminPassword))
            {
                return true;
            }

            using (var dialog = new PasswordDialog())
            {
                dialog.ShowDialog();
                return dialog.IsPasswordValid;
            }
        }
    }
}
