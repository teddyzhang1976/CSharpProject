namespace EstablishAndExpunctionM3U
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
            if(disposing && (components != null))
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
            this.found = new System.Windows.Forms.Button();
            this.unfold = new System.Windows.Forms.Button();
            this.Expunction = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fileName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.M3UName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OpenM3U = new System.Windows.Forms.Button();
            this.writeIn = new System.Windows.Forms.Button();
            this.openMusic = new System.Windows.Forms.Button();
            this.M3UPath = new System.Windows.Forms.TextBox();
            this.musicPath = new System.Windows.Forms.TextBox();
            this.musicName = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // found
            // 
            this.found.Location = new System.Drawing.Point(273, 14);
            this.found.Name = "found";
            this.found.Size = new System.Drawing.Size(52, 23);
            this.found.TabIndex = 0;
            this.found.Text = "创建";
            this.found.UseVisualStyleBackColor = true;
            this.found.Click += new System.EventHandler(this.found_Click);
            // 
            // unfold
            // 
            this.unfold.Location = new System.Drawing.Point(273, 20);
            this.unfold.Name = "unfold";
            this.unfold.Size = new System.Drawing.Size(52, 23);
            this.unfold.TabIndex = 1;
            this.unfold.Text = "打开";
            this.unfold.UseVisualStyleBackColor = true;
            this.unfold.Click += new System.EventHandler(this.unfold_Click);
            // 
            // Expunction
            // 
            this.Expunction.Location = new System.Drawing.Point(273, 52);
            this.Expunction.Name = "Expunction";
            this.Expunction.Size = new System.Drawing.Size(52, 23);
            this.Expunction.TabIndex = 2;
            this.Expunction.Text = "删除";
            this.Expunction.UseVisualStyleBackColor = true;
            this.Expunction.Click += new System.EventHandler(this.Expunction_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.unfold);
            this.groupBox3.Controls.Add(this.Expunction);
            this.groupBox3.Controls.Add(this.fileName);
            this.groupBox3.Location = new System.Drawing.Point(3, 209);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(333, 83);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "删除";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "文件路径：";
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(78, 22);
            this.fileName.Name = "fileName";
            this.fileName.ReadOnly = true;
            this.fileName.Size = new System.Drawing.Size(189, 21);
            this.fileName.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.M3UName);
            this.groupBox1.Controls.Add(this.found);
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 44);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新建";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "创建提示：";
            // 
            // M3UName
            // 
            this.M3UName.Location = new System.Drawing.Point(78, 14);
            this.M3UName.Name = "M3UName";
            this.M3UName.ReadOnly = true;
            this.M3UName.Size = new System.Drawing.Size(189, 21);
            this.M3UName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "文 件 名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "文件路径：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "M3U 路径：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.OpenM3U);
            this.groupBox2.Controls.Add(this.writeIn);
            this.groupBox2.Controls.Add(this.openMusic);
            this.groupBox2.Controls.Add(this.M3UPath);
            this.groupBox2.Controls.Add(this.musicPath);
            this.groupBox2.Controls.Add(this.musicName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(3, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 152);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "写入";
            // 
            // OpenM3U
            // 
            this.OpenM3U.Location = new System.Drawing.Point(273, 86);
            this.OpenM3U.Name = "OpenM3U";
            this.OpenM3U.Size = new System.Drawing.Size(52, 23);
            this.OpenM3U.TabIndex = 9;
            this.OpenM3U.Text = "打开";
            this.OpenM3U.UseVisualStyleBackColor = true;
            this.OpenM3U.Click += new System.EventHandler(this.openM3U_Click);
            // 
            // writeIn
            // 
            this.writeIn.Location = new System.Drawing.Point(273, 123);
            this.writeIn.Name = "writeIn";
            this.writeIn.Size = new System.Drawing.Size(52, 23);
            this.writeIn.TabIndex = 8;
            this.writeIn.Text = "写入";
            this.writeIn.UseVisualStyleBackColor = true;
            this.writeIn.Click += new System.EventHandler(this.writeIn_Click);
            // 
            // openMusic
            // 
            this.openMusic.Location = new System.Drawing.Point(273, 51);
            this.openMusic.Name = "openMusic";
            this.openMusic.Size = new System.Drawing.Size(52, 23);
            this.openMusic.TabIndex = 7;
            this.openMusic.Text = "打开";
            this.openMusic.UseVisualStyleBackColor = true;
            this.openMusic.Click += new System.EventHandler(this.openMusic_Click);
            // 
            // M3UPath
            // 
            this.M3UPath.Location = new System.Drawing.Point(78, 88);
            this.M3UPath.Name = "M3UPath";
            this.M3UPath.ReadOnly = true;
            this.M3UPath.Size = new System.Drawing.Size(189, 21);
            this.M3UPath.TabIndex = 6;
            // 
            // musicPath
            // 
            this.musicPath.Location = new System.Drawing.Point(78, 53);
            this.musicPath.Name = "musicPath";
            this.musicPath.ReadOnly = true;
            this.musicPath.Size = new System.Drawing.Size(189, 21);
            this.musicPath.TabIndex = 5;
            // 
            // musicName
            // 
            this.musicName.Location = new System.Drawing.Point(78, 19);
            this.musicName.Name = "musicName";
            this.musicName.ReadOnly = true;
            this.musicName.Size = new System.Drawing.Size(189, 21);
            this.musicName.TabIndex = 4;
            // 
            // EstablishAndExpunctionM3U
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 296);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "EstablishAndExpunctionM3U";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "M3U歌词文件的创建及删除";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button found;
        private System.Windows.Forms.Button unfold;
        private System.Windows.Forms.Button Expunction;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox M3UName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button writeIn;
        private System.Windows.Forms.Button openMusic;
        private System.Windows.Forms.TextBox M3UPath;
        private System.Windows.Forms.TextBox musicPath;
        private System.Windows.Forms.TextBox musicName;
        private System.Windows.Forms.Button OpenM3U;
    }
}

