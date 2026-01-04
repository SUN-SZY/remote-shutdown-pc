namespace Karpach.RemoteShutdown.Controller
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
			chkAutoLoad = new System.Windows.Forms.CheckBox();
			lbDefaultCommand = new System.Windows.Forms.Label();
			cbxTrayCommand = new System.Windows.Forms.ComboBox();
			btnOk = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			lbSecretCode = new System.Windows.Forms.Label();
			txtSecretCode = new System.Windows.Forms.TextBox();
			lbPort = new System.Windows.Forms.Label();
			txtPort = new System.Windows.Forms.TextBox();
			chkHideTrayIcon = new System.Windows.Forms.CheckBox();
			lbAdminPassword = new System.Windows.Forms.Label();
			txtAdminPassword = new System.Windows.Forms.TextBox();
			lblHotkeyInfo = new System.Windows.Forms.Label();
			grpParentalControl = new System.Windows.Forms.GroupBox();
			chkDisableWakeEvent = new System.Windows.Forms.CheckBox();
			grpParentalControl.SuspendLayout();
			SuspendLayout();
			// 
			// chkAutoLoad
			// 
			chkAutoLoad.AutoSize = true;
			chkAutoLoad.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chkAutoLoad.Location = new System.Drawing.Point(21, 14);
			chkAutoLoad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			chkAutoLoad.Name = "chkAutoLoad";
			chkAutoLoad.Size = new System.Drawing.Size(186, 19);
			chkAutoLoad.TabIndex = 1;
			chkAutoLoad.Text = "Auto load at Windows startup:";
			chkAutoLoad.UseVisualStyleBackColor = true;
			// 
			// lbDefaultCommand
			// 
			lbDefaultCommand.AutoSize = true;
			lbDefaultCommand.Location = new System.Drawing.Point(54, 46);
			lbDefaultCommand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			lbDefaultCommand.Name = "lbDefaultCommand";
			lbDefaultCommand.Size = new System.Drawing.Size(132, 15);
			lbDefaultCommand.TabIndex = 2;
			lbDefaultCommand.Text = "System Tray Command:";
			// 
			// cbxTrayCommand
			// 
			cbxTrayCommand.FormattingEnabled = true;
			cbxTrayCommand.Location = new System.Drawing.Point(194, 43);
			cbxTrayCommand.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			cbxTrayCommand.Name = "cbxTrayCommand";
			cbxTrayCommand.Size = new System.Drawing.Size(140, 23);
			cbxTrayCommand.TabIndex = 3;
			// 
			// btnOk
			// 
			btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			btnOk.Location = new System.Drawing.Point(97, 340);
			btnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			btnOk.Name = "btnOk";
			btnOk.Size = new System.Drawing.Size(88, 27);
			btnOk.TabIndex = 11;
			btnOk.Text = "Ok";
			btnOk.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(194, 340);
			btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(88, 27);
			btnCancel.TabIndex = 12;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// lbSecretCode
			// 
			lbSecretCode.AutoSize = true;
			lbSecretCode.Location = new System.Drawing.Point(112, 84);
			lbSecretCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			lbSecretCode.Name = "lbSecretCode";
			lbSecretCode.Size = new System.Drawing.Size(73, 15);
			lbSecretCode.TabIndex = 2;
			lbSecretCode.Text = "Secret Code:";
			// 
			// txtSecretCode
			// 
			txtSecretCode.Location = new System.Drawing.Point(194, 81);
			txtSecretCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			txtSecretCode.Name = "txtSecretCode";
			txtSecretCode.Size = new System.Drawing.Size(140, 23);
			txtSecretCode.TabIndex = 5;
			// 
			// lbPort
			// 
			lbPort.AutoSize = true;
			lbPort.Location = new System.Drawing.Point(153, 121);
			lbPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			lbPort.Name = "lbPort";
			lbPort.Size = new System.Drawing.Size(32, 15);
			lbPort.TabIndex = 2;
			lbPort.Text = "Port:";
			// 
			// txtPort
			// 
			txtPort.Location = new System.Drawing.Point(194, 118);
			txtPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			txtPort.Name = "txtPort";
			txtPort.Size = new System.Drawing.Size(140, 23);
			txtPort.TabIndex = 6;
			txtPort.Validating += txtPort_Validating;
			// 
			// chkHideTrayIcon
			// 
			chkHideTrayIcon.AutoSize = true;
			chkHideTrayIcon.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chkHideTrayIcon.Location = new System.Drawing.Point(89, 22);
			chkHideTrayIcon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			chkHideTrayIcon.Name = "chkHideTrayIcon";
			chkHideTrayIcon.Size = new System.Drawing.Size(104, 19);
			chkHideTrayIcon.TabIndex = 8;
			chkHideTrayIcon.Text = "Hide Tray Icon:";
			chkHideTrayIcon.UseVisualStyleBackColor = true;
			// 
			// lbAdminPassword
			// 
			lbAdminPassword.AutoSize = true;
			lbAdminPassword.Location = new System.Drawing.Point(73, 57);
			lbAdminPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			lbAdminPassword.Name = "lbAdminPassword";
			lbAdminPassword.Size = new System.Drawing.Size(99, 15);
			lbAdminPassword.TabIndex = 2;
			lbAdminPassword.Text = "Admin Password:";
			// 
			// txtAdminPassword
			// 
			txtAdminPassword.Location = new System.Drawing.Point(194, 239);
			txtAdminPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			txtAdminPassword.Name = "txtAdminPassword";
			txtAdminPassword.PasswordChar = '*';
			txtAdminPassword.Size = new System.Drawing.Size(140, 23);
			txtAdminPassword.TabIndex = 9;
			// 
			// lblHotkeyInfo
			// 
			lblHotkeyInfo.AutoSize = true;
			lblHotkeyInfo.ForeColor = System.Drawing.SystemColors.GrayText;
			lblHotkeyInfo.Location = new System.Drawing.Point(28, 275);
			lblHotkeyInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			lblHotkeyInfo.Name = "lblHotkeyInfo";
			lblHotkeyInfo.Size = new System.Drawing.Size(338, 30);
			lblHotkeyInfo.TabIndex = 14;
			lblHotkeyInfo.Text = "When tray icon is hidden, press Ctrl+Shift+Alt+R to reveal it.\nPassword is required to access settings, exit, or reveal tray icon.";
			// 
			// grpParentalControl
			// 
			grpParentalControl.Controls.Add(chkHideTrayIcon);
			grpParentalControl.Controls.Add(lbAdminPassword);
			grpParentalControl.Location = new System.Drawing.Point(14, 185);
			grpParentalControl.Name = "grpParentalControl";
			grpParentalControl.Size = new System.Drawing.Size(386, 140);
			grpParentalControl.TabIndex = 13;
			grpParentalControl.TabStop = false;
			grpParentalControl.Text = "Parental Control";
			// 
			// chkDisableWakeEvent
			// 
			chkDisableWakeEvent.AutoSize = true;
			chkDisableWakeEvent.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chkDisableWakeEvent.Location = new System.Drawing.Point(73, 160);
			chkDisableWakeEvent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			chkDisableWakeEvent.Name = "chkDisableWakeEvent";
			chkDisableWakeEvent.Size = new System.Drawing.Size(134, 19);
			chkDisableWakeEvent.TabIndex = 7;
			chkDisableWakeEvent.Text = "Disable wake events:";
			chkDisableWakeEvent.UseVisualStyleBackColor = true;
			// 
			// SettingsForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(414, 382);
			Controls.Add(lblHotkeyInfo);
			Controls.Add(txtAdminPassword);
			Controls.Add(chkDisableWakeEvent);
			Controls.Add(txtPort);
			Controls.Add(txtSecretCode);
			Controls.Add(btnCancel);
			Controls.Add(btnOk);
			Controls.Add(cbxTrayCommand);
			Controls.Add(lbPort);
			Controls.Add(lbSecretCode);
			Controls.Add(lbDefaultCommand);
			Controls.Add(chkAutoLoad);
			Controls.Add(grpParentalControl);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			MaximizeBox = false;
			Name = "SettingsForm";
			Text = "Settings";
			grpParentalControl.ResumeLayout(false);
			grpParentalControl.PerformLayout();
			ResumeLayout(false);
			PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox chkAutoLoad;
        private System.Windows.Forms.Label lbDefaultCommand;
        private System.Windows.Forms.ComboBox cbxTrayCommand;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbSecretCode;
        private System.Windows.Forms.TextBox txtSecretCode;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.CheckBox chkHideTrayIcon;
        private System.Windows.Forms.Label lbAdminPassword;
        private System.Windows.Forms.TextBox txtAdminPassword;
        private System.Windows.Forms.Label lblHotkeyInfo;
        private System.Windows.Forms.GroupBox grpParentalControl;
        private System.Windows.Forms.CheckBox chkDisableWakeEvent;
    }
}