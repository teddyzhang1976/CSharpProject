namespace Chapter_8_CSharp
{
    partial class ConnectionTest
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
            this.ConnectionTimeout = new System.Windows.Forms.ComboBox();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.AuthenticateWindows = new System.Windows.Forms.RadioButton();
            this.AuthenticateSqlServer = new System.Windows.Forms.RadioButton();
            this.UserName = new System.Windows.Forms.TextBox();
            this.LabelUserName = new System.Windows.Forms.Label();
            this.UserPassword = new System.Windows.Forms.TextBox();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.RemoteServer = new System.Windows.Forms.RadioButton();
            this.LocalServer = new System.Windows.Forms.RadioButton();
            this.LabelServerName = new System.Windows.Forms.Label();
            this.IsExpressEdition = new System.Windows.Forms.CheckBox();
            this.ServerName = new System.Windows.Forms.TextBox();
            this.ConnectionPreview = new System.Windows.Forms.TextBox();
            this.LabelPreview = new System.Windows.Forms.Label();
            this.ActClose = new System.Windows.Forms.Button();
            this.EnableMarsSupport = new System.Windows.Forms.CheckBox();
            this.LabelTimeout = new System.Windows.Forms.Label();
            this.LabelInitialCatalog = new System.Windows.Forms.Label();
            this.InitialCatalog = new System.Windows.Forms.TextBox();
            this.ActTest = new System.Windows.Forms.Button();
            this.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectionTimeout
            // 
            this.ConnectionTimeout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConnectionTimeout.FormattingEnabled = true;
            this.ConnectionTimeout.Location = new System.Drawing.Point(88, 232);
            this.ConnectionTimeout.Name = "ConnectionTimeout";
            this.ConnectionTimeout.Size = new System.Drawing.Size(288, 21);
            this.ConnectionTimeout.TabIndex = 5;
            this.ConnectionTimeout.SelectedIndexChanged += new System.EventHandler(this.FieldUpdates);
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.AuthenticateWindows);
            this.Panel2.Controls.Add(this.AuthenticateSqlServer);
            this.Panel2.Controls.Add(this.UserName);
            this.Panel2.Controls.Add(this.LabelUserName);
            this.Panel2.Controls.Add(this.UserPassword);
            this.Panel2.Controls.Add(this.LabelPassword);
            this.Panel2.Location = new System.Drawing.Point(8, 104);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(376, 100);
            this.Panel2.TabIndex = 1;
            // 
            // AuthenticateWindows
            // 
            this.AuthenticateWindows.AutoSize = true;
            this.AuthenticateWindows.Checked = true;
            this.AuthenticateWindows.Location = new System.Drawing.Point(0, 0);
            this.AuthenticateWindows.Name = "AuthenticateWindows";
            this.AuthenticateWindows.Size = new System.Drawing.Size(139, 17);
            this.AuthenticateWindows.TabIndex = 0;
            this.AuthenticateWindows.TabStop = true;
            this.AuthenticateWindows.Text = "Windows authentication";
            this.AuthenticateWindows.UseVisualStyleBackColor = true;
            // 
            // AuthenticateSqlServer
            // 
            this.AuthenticateSqlServer.AutoSize = true;
            this.AuthenticateSqlServer.Location = new System.Drawing.Point(0, 24);
            this.AuthenticateSqlServer.Name = "AuthenticateSqlServer";
            this.AuthenticateSqlServer.Size = new System.Drawing.Size(150, 17);
            this.AuthenticateSqlServer.TabIndex = 1;
            this.AuthenticateSqlServer.Text = "SQL Server authentication";
            this.AuthenticateSqlServer.UseVisualStyleBackColor = true;
            this.AuthenticateSqlServer.CheckedChanged += new System.EventHandler(this.AuthenticateSqlServer_CheckedChanged);
            // 
            // UserName
            // 
            this.UserName.Enabled = false;
            this.UserName.Location = new System.Drawing.Point(112, 49);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(256, 20);
            this.UserName.TabIndex = 3;
            this.UserName.TextChanged += new System.EventHandler(this.FieldUpdates);
            this.UserName.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelUserName
            // 
            this.LabelUserName.AutoSize = true;
            this.LabelUserName.Enabled = false;
            this.LabelUserName.Location = new System.Drawing.Point(32, 51);
            this.LabelUserName.Name = "LabelUserName";
            this.LabelUserName.Size = new System.Drawing.Size(63, 13);
            this.LabelUserName.TabIndex = 2;
            this.LabelUserName.Text = "User Name:";
            // 
            // UserPassword
            // 
            this.UserPassword.Enabled = false;
            this.UserPassword.Location = new System.Drawing.Point(112, 73);
            this.UserPassword.Name = "UserPassword";
            this.UserPassword.PasswordChar = '*';
            this.UserPassword.Size = new System.Drawing.Size(256, 20);
            this.UserPassword.TabIndex = 5;
            this.UserPassword.TextChanged += new System.EventHandler(this.FieldUpdates);
            this.UserPassword.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // LabelPassword
            // 
            this.LabelPassword.AutoSize = true;
            this.LabelPassword.Enabled = false;
            this.LabelPassword.Location = new System.Drawing.Point(32, 75);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(56, 13);
            this.LabelPassword.TabIndex = 4;
            this.LabelPassword.Text = "Password:";
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.RemoteServer);
            this.Panel1.Controls.Add(this.LocalServer);
            this.Panel1.Controls.Add(this.LabelServerName);
            this.Panel1.Controls.Add(this.IsExpressEdition);
            this.Panel1.Controls.Add(this.ServerName);
            this.Panel1.Location = new System.Drawing.Point(8, 8);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(376, 90);
            this.Panel1.TabIndex = 0;
            // 
            // RemoteServer
            // 
            this.RemoteServer.AutoSize = true;
            this.RemoteServer.Location = new System.Drawing.Point(0, 24);
            this.RemoteServer.Name = "RemoteServer";
            this.RemoteServer.Size = new System.Drawing.Size(96, 17);
            this.RemoteServer.TabIndex = 1;
            this.RemoteServer.Text = "Remote Server";
            this.RemoteServer.UseVisualStyleBackColor = true;
            this.RemoteServer.CheckedChanged += new System.EventHandler(this.RemoteServer_CheckedChanged);
            // 
            // LocalServer
            // 
            this.LocalServer.AutoSize = true;
            this.LocalServer.Checked = true;
            this.LocalServer.Location = new System.Drawing.Point(0, 0);
            this.LocalServer.Name = "LocalServer";
            this.LocalServer.Size = new System.Drawing.Size(85, 17);
            this.LocalServer.TabIndex = 0;
            this.LocalServer.TabStop = true;
            this.LocalServer.Text = "Local Server";
            this.LocalServer.UseVisualStyleBackColor = true;
            // 
            // LabelServerName
            // 
            this.LabelServerName.AutoSize = true;
            this.LabelServerName.Enabled = false;
            this.LabelServerName.Location = new System.Drawing.Point(32, 48);
            this.LabelServerName.Name = "LabelServerName";
            this.LabelServerName.Size = new System.Drawing.Size(72, 13);
            this.LabelServerName.TabIndex = 2;
            this.LabelServerName.Text = "Server Name:";
            // 
            // IsExpressEdition
            // 
            this.IsExpressEdition.AutoSize = true;
            this.IsExpressEdition.Location = new System.Drawing.Point(0, 70);
            this.IsExpressEdition.Name = "IsExpressEdition";
            this.IsExpressEdition.Size = new System.Drawing.Size(173, 17);
            this.IsExpressEdition.TabIndex = 4;
            this.IsExpressEdition.Text = "SQL Server Express installation";
            this.IsExpressEdition.UseVisualStyleBackColor = true;
            this.IsExpressEdition.CheckedChanged += new System.EventHandler(this.FieldUpdates);
            // 
            // ServerName
            // 
            this.ServerName.Enabled = false;
            this.ServerName.Location = new System.Drawing.Point(112, 46);
            this.ServerName.Name = "ServerName";
            this.ServerName.Size = new System.Drawing.Size(256, 20);
            this.ServerName.TabIndex = 3;
            this.ServerName.TextChanged += new System.EventHandler(this.FieldUpdates);
            this.ServerName.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // ConnectionPreview
            // 
            this.ConnectionPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionPreview.Location = new System.Drawing.Point(8, 312);
            this.ConnectionPreview.Multiline = true;
            this.ConnectionPreview.Name = "ConnectionPreview";
            this.ConnectionPreview.ReadOnly = true;
            this.ConnectionPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConnectionPreview.Size = new System.Drawing.Size(456, 120);
            this.ConnectionPreview.TabIndex = 8;
            // 
            // LabelPreview
            // 
            this.LabelPreview.AutoSize = true;
            this.LabelPreview.Location = new System.Drawing.Point(8, 292);
            this.LabelPreview.Name = "LabelPreview";
            this.LabelPreview.Size = new System.Drawing.Size(132, 13);
            this.LabelPreview.TabIndex = 7;
            this.LabelPreview.Text = "Connection String Preview";
            // 
            // ActClose
            // 
            this.ActClose.Location = new System.Drawing.Point(392, 48);
            this.ActClose.Name = "ActClose";
            this.ActClose.Size = new System.Drawing.Size(75, 23);
            this.ActClose.TabIndex = 10;
            this.ActClose.Text = "Close";
            this.ActClose.UseVisualStyleBackColor = true;
            this.ActClose.Click += new System.EventHandler(this.ActClose_Click);
            // 
            // EnableMarsSupport
            // 
            this.EnableMarsSupport.AutoSize = true;
            this.EnableMarsSupport.Location = new System.Drawing.Point(8, 258);
            this.EnableMarsSupport.Name = "EnableMarsSupport";
            this.EnableMarsSupport.Size = new System.Drawing.Size(233, 17);
            this.EnableMarsSupport.TabIndex = 6;
            this.EnableMarsSupport.Text = "Enable Multiple Active Record Sets (MARS)";
            this.EnableMarsSupport.UseVisualStyleBackColor = true;
            this.EnableMarsSupport.CheckedChanged += new System.EventHandler(this.FieldUpdates);
            // 
            // LabelTimeout
            // 
            this.LabelTimeout.AutoSize = true;
            this.LabelTimeout.Location = new System.Drawing.Point(8, 234);
            this.LabelTimeout.Name = "LabelTimeout";
            this.LabelTimeout.Size = new System.Drawing.Size(48, 13);
            this.LabelTimeout.TabIndex = 4;
            this.LabelTimeout.Text = "Timeout:";
            // 
            // LabelInitialCatalog
            // 
            this.LabelInitialCatalog.AutoSize = true;
            this.LabelInitialCatalog.Location = new System.Drawing.Point(8, 211);
            this.LabelInitialCatalog.Name = "LabelInitialCatalog";
            this.LabelInitialCatalog.Size = new System.Drawing.Size(73, 13);
            this.LabelInitialCatalog.TabIndex = 2;
            this.LabelInitialCatalog.Text = "Initial Catalog:";
            // 
            // InitialCatalog
            // 
            this.InitialCatalog.Location = new System.Drawing.Point(88, 209);
            this.InitialCatalog.Name = "InitialCatalog";
            this.InitialCatalog.Size = new System.Drawing.Size(288, 20);
            this.InitialCatalog.TabIndex = 3;
            this.InitialCatalog.TextChanged += new System.EventHandler(this.FieldUpdates);
            this.InitialCatalog.Enter += new System.EventHandler(this.TextFields_Enter);
            // 
            // ActTest
            // 
            this.ActTest.Location = new System.Drawing.Point(392, 16);
            this.ActTest.Name = "ActTest";
            this.ActTest.Size = new System.Drawing.Size(75, 23);
            this.ActTest.TabIndex = 9;
            this.ActTest.Text = "Test";
            this.ActTest.UseVisualStyleBackColor = true;
            this.ActTest.Click += new System.EventHandler(this.ActTest_Click);
            // 
            // ConnectionTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 443);
            this.Controls.Add(this.ConnectionTimeout);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.ConnectionPreview);
            this.Controls.Add(this.LabelPreview);
            this.Controls.Add(this.ActClose);
            this.Controls.Add(this.EnableMarsSupport);
            this.Controls.Add(this.LabelTimeout);
            this.Controls.Add(this.LabelInitialCatalog);
            this.Controls.Add(this.InitialCatalog);
            this.Controls.Add(this.ActTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConnectionTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapter 8 - Connection Test";
            this.Load += new System.EventHandler(this.ConnectionTest_Load);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox ConnectionTimeout;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.RadioButton AuthenticateWindows;
        internal System.Windows.Forms.RadioButton AuthenticateSqlServer;
        internal System.Windows.Forms.TextBox UserName;
        internal System.Windows.Forms.Label LabelUserName;
        internal System.Windows.Forms.TextBox UserPassword;
        internal System.Windows.Forms.Label LabelPassword;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.RadioButton RemoteServer;
        internal System.Windows.Forms.RadioButton LocalServer;
        internal System.Windows.Forms.Label LabelServerName;
        internal System.Windows.Forms.CheckBox IsExpressEdition;
        internal System.Windows.Forms.TextBox ServerName;
        internal System.Windows.Forms.TextBox ConnectionPreview;
        internal System.Windows.Forms.Label LabelPreview;
        internal System.Windows.Forms.Button ActClose;
        internal System.Windows.Forms.CheckBox EnableMarsSupport;
        internal System.Windows.Forms.Label LabelTimeout;
        internal System.Windows.Forms.Label LabelInitialCatalog;
        internal System.Windows.Forms.TextBox InitialCatalog;
        internal System.Windows.Forms.Button ActTest;
    }
}

