namespace StoreIDAndName
{
    partial class Form1
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
            this.lab_ID = new System.Windows.Forms.Label();
            this.lab_Name = new System.Windows.Forms.Label();
            this.lab_First = new System.Windows.Forms.Label();
            this.lab_Second = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lab_ID
            // 
            this.lab_ID.AutoSize = true;
            this.lab_ID.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_ID.Location = new System.Drawing.Point(25, 19);
            this.lab_ID.Name = "lab_ID";
            this.lab_ID.Size = new System.Drawing.Size(63, 14);
            this.lab_ID.TabIndex = 0;
            this.lab_ID.Text = "用户编号";
            // 
            // lab_Name
            // 
            this.lab_Name.AutoSize = true;
            this.lab_Name.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Name.Location = new System.Drawing.Point(125, 19);
            this.lab_Name.Name = "lab_Name";
            this.lab_Name.Size = new System.Drawing.Size(63, 14);
            this.lab_Name.TabIndex = 0;
            this.lab_Name.Text = "用户姓名";
            // 
            // lab_First
            // 
            this.lab_First.AutoSize = true;
            this.lab_First.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_First.Location = new System.Drawing.Point(25, 42);
            this.lab_First.Name = "lab_First";
            this.lab_First.Size = new System.Drawing.Size(0, 14);
            this.lab_First.TabIndex = 1;
            // 
            // lab_Second
            // 
            this.lab_Second.AutoSize = true;
            this.lab_Second.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Second.Location = new System.Drawing.Point(25, 65);
            this.lab_Second.Name = "lab_Second";
            this.lab_Second.Size = new System.Drawing.Size(0, 14);
            this.lab_Second.TabIndex = 2;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 113);
            this.Controls.Add(this.lab_Second);
            this.Controls.Add(this.lab_First);
            this.Controls.Add(this.lab_Name);
            this.Controls.Add(this.lab_ID);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "使用属性存储用户编号和姓名";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_ID;
        private System.Windows.Forms.Label lab_Name;
        private System.Windows.Forms.Label lab_First;
        private System.Windows.Forms.Label lab_Second;
    }
}

