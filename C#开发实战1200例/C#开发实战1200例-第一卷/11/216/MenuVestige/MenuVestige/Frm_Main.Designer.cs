namespace MenuVestige
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
            this.btn_One = new System.Windows.Forms.Button();
            this.btn_Tow = new System.Windows.Forms.Button();
            this.btn_Three = new System.Windows.Forms.Button();
            this.btn_Four = new System.Windows.Forms.Button();
            this.btn_Five = new System.Windows.Forms.Button();
            this.btn_six = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_One
            // 
            this.btn_One.Location = new System.Drawing.Point(29, 23);
            this.btn_One.Name = "btn_One";
            this.btn_One.Size = new System.Drawing.Size(119, 38);
            this.btn_One.TabIndex = 0;
            this.btn_One.Text = "按钮1";
            this.btn_One.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_One.UseVisualStyleBackColor = true;
            // 
            // btn_Tow
            // 
            this.btn_Tow.Location = new System.Drawing.Point(29, 92);
            this.btn_Tow.Name = "btn_Tow";
            this.btn_Tow.Size = new System.Drawing.Size(119, 38);
            this.btn_Tow.TabIndex = 1;
            this.btn_Tow.Text = "按钮2";
            this.btn_Tow.UseVisualStyleBackColor = true;
            // 
            // btn_Three
            // 
            this.btn_Three.Location = new System.Drawing.Point(29, 167);
            this.btn_Three.Name = "btn_Three";
            this.btn_Three.Size = new System.Drawing.Size(119, 38);
            this.btn_Three.TabIndex = 2;
            this.btn_Three.Text = "按钮3";
            this.btn_Three.UseVisualStyleBackColor = true;
            // 
            // btn_Four
            // 
            this.btn_Four.Location = new System.Drawing.Point(236, 23);
            this.btn_Four.Name = "btn_Four";
            this.btn_Four.Size = new System.Drawing.Size(119, 38);
            this.btn_Four.TabIndex = 3;
            this.btn_Four.Text = "按钮4";
            this.btn_Four.UseVisualStyleBackColor = true;
            // 
            // btn_Five
            // 
            this.btn_Five.Location = new System.Drawing.Point(236, 92);
            this.btn_Five.Name = "btn_Five";
            this.btn_Five.Size = new System.Drawing.Size(119, 38);
            this.btn_Five.TabIndex = 4;
            this.btn_Five.Text = "按钮5";
            this.btn_Five.UseVisualStyleBackColor = true;
            // 
            // btn_six
            // 
            this.btn_six.Location = new System.Drawing.Point(236, 167);
            this.btn_six.Name = "btn_six";
            this.btn_six.Size = new System.Drawing.Size(119, 38);
            this.btn_six.TabIndex = 5;
            this.btn_six.Text = "按钮6";
            this.btn_six.UseVisualStyleBackColor = true;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 223);
            this.Controls.Add(this.btn_six);
            this.Controls.Add(this.btn_Five);
            this.Controls.Add(this.btn_Four);
            this.Controls.Add(this.btn_Three);
            this.Controls.Add(this.btn_Tow);
            this.Controls.Add(this.btn_One);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "轻松打造绚丽按钮";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_One;
        private System.Windows.Forms.Button btn_Tow;
        private System.Windows.Forms.Button btn_Three;
        private System.Windows.Forms.Button btn_Four;
        private System.Windows.Forms.Button btn_Five;
        private System.Windows.Forms.Button btn_six;
    }
}

