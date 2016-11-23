namespace InputText
{
    partial class Frm_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnConcel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.imgLogin = new System.Windows.Forms.ImageList(this.components);
            this.lbluName = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPasword = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbluPwd = new System.Windows.Forms.Label();
            this.errUser = new System.Windows.Forms.ErrorProvider(this.components);
            this.errPassword = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(368, 44);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(4, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 8);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(16, -80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 12);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(16, -80);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(376, 12);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            // 
            // btnConcel
            // 
            this.btnConcel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConcel.Location = new System.Drawing.Point(258, 139);
            this.btnConcel.Name = "btnConcel";
            this.btnConcel.Size = new System.Drawing.Size(96, 23);
            this.btnConcel.TabIndex = 26;
            this.btnConcel.Text = "退出(&E)";
            this.btnConcel.Click += new System.EventHandler(this.btnConcel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(115, 139);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 23);
            this.btnOK.TabIndex = 25;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // imgLogin
            // 
            this.imgLogin.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLogin.ImageStream")));
            this.imgLogin.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLogin.Images.SetKeyName(0, "");
            this.imgLogin.Images.SetKeyName(1, "");
            // 
            // lbluName
            // 
            this.lbluName.AutoSize = true;
            this.lbluName.Location = new System.Drawing.Point(44, 77);
            this.lbluName.Name = "lbluName";
            this.lbluName.Size = new System.Drawing.Size(53, 12);
            this.lbluName.TabIndex = 20;
            this.lbluName.Text = "登录名：";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(132, 69);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(208, 21);
            this.txtUser.TabIndex = 22;
            this.txtUser.Tag = "登录名：";
            this.txtUser.Validating += new System.ComponentModel.CancelEventHandler(this.txtUser_Validating);
            // 
            // txtPasword
            // 
            this.txtPasword.Location = new System.Drawing.Point(132, 101);
            this.txtPasword.Name = "txtPasword";
            this.txtPasword.PasswordChar = '●';
            this.txtPasword.Size = new System.Drawing.Size(208, 21);
            this.txtPasword.TabIndex = 23;
            this.txtPasword.Tag = "密  码：";
            this.txtPasword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPasword_Validating);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(12, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(360, 8);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            // 
            // lbluPwd
            // 
            this.lbluPwd.AutoSize = true;
            this.lbluPwd.Location = new System.Drawing.Point(44, 101);
            this.lbluPwd.Name = "lbluPwd";
            this.lbluPwd.Size = new System.Drawing.Size(53, 12);
            this.lbluPwd.TabIndex = 21;
            this.lbluPwd.Text = "密  码：";
            // 
            // errUser
            // 
            this.errUser.BlinkRate = 100;
            this.errUser.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errUser.ContainerControl = this;
            // 
            // errPassword
            // 
            this.errPassword.BlinkRate = 100;
            this.errPassword.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errPassword.ContainerControl = this;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 169);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnConcel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbluName);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtPasword);
            this.Controls.Add(this.lbluPwd);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "使用ErrorProvider组件验证文本框输入";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnConcel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ImageList imgLogin;
        private System.Windows.Forms.Label lbluName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPasword;
        private System.Windows.Forms.Label lbluPwd;
        private System.Windows.Forms.ErrorProvider errUser;
        private System.Windows.Forms.ErrorProvider errPassword;


    }
}

