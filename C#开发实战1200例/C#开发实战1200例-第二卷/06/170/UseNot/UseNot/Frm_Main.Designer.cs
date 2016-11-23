namespace UseNot
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtn_Three = new System.Windows.Forms.RadioButton();
            this.rbtn_Two = new System.Windows.Forms.RadioButton();
            this.rbtn_One = new System.Windows.Forms.RadioButton();
            this.dgv_Message = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Message)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtn_Three);
            this.groupBox1.Controls.Add(this.rbtn_Two);
            this.groupBox1.Controls.Add(this.rbtn_One);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // rbtn_Three
            // 
            this.rbtn_Three.AutoSize = true;
            this.rbtn_Three.Location = new System.Drawing.Point(12, 64);
            this.rbtn_Three.Name = "rbtn_Three";
            this.rbtn_Three.Size = new System.Drawing.Size(365, 16);
            this.rbtn_Three.TabIndex = 3;
            this.rbtn_Three.Text = "查询软件工程成绩大于90而且外语成绩不在70-85之间的学生信息";
            this.rbtn_Three.UseVisualStyleBackColor = true;
            // 
            // rbtn_Two
            // 
            this.rbtn_Two.AutoSize = true;
            this.rbtn_Two.Location = new System.Drawing.Point(12, 42);
            this.rbtn_Two.Name = "rbtn_Two";
            this.rbtn_Two.Size = new System.Drawing.Size(215, 16);
            this.rbtn_Two.TabIndex = 2;
            this.rbtn_Two.Text = "查询数据结构成绩小于60的学生信息";
            this.rbtn_Two.UseVisualStyleBackColor = true;
            // 
            // rbtn_One
            // 
            this.rbtn_One.AutoSize = true;
            this.rbtn_One.Location = new System.Drawing.Point(12, 20);
            this.rbtn_One.Name = "rbtn_One";
            this.rbtn_One.Size = new System.Drawing.Size(191, 16);
            this.rbtn_One.TabIndex = 1;
            this.rbtn_One.Text = "查询高数成绩大于80的学生信息";
            this.rbtn_One.UseVisualStyleBackColor = true;
            // 
            // dgv_Message
            // 
            this.dgv_Message.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Message.Location = new System.Drawing.Point(0, 97);
            this.dgv_Message.Name = "dgv_Message";
            this.dgv_Message.RowTemplate.Height = 23;
            this.dgv_Message.Size = new System.Drawing.Size(422, 182);
            this.dgv_Message.TabIndex = 1;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 282);
            this.Controls.Add(this.dgv_Message);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NOT与谓词进行组合条件的查询";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Message)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtn_Three;
        private System.Windows.Forms.RadioButton rbtn_Two;
        private System.Windows.Forms.RadioButton rbtn_One;
        private System.Windows.Forms.DataGridView dgv_Message;
    }
}

