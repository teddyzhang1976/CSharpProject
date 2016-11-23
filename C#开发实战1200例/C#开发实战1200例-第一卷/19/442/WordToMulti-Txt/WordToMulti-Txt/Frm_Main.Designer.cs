namespace WordToMulti_Txt
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
            this.cbox_Select = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_SavePath = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.txt_select = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_split = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbox_Select);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_SavePath);
            this.groupBox1.Controls.Add(this.btn_Save);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_path);
            this.groupBox1.Controls.Add(this.txt_select);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_split);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 147);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "分割Word文档";
            // 
            // cbox_Select
            // 
            this.cbox_Select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Select.FormattingEnabled = true;
            this.cbox_Select.Items.AddRange(new object[] {
            "以段落方式分割文档",
            "以100个字符为单位分割文档"});
            this.cbox_Select.Location = new System.Drawing.Point(137, 110);
            this.cbox_Select.Name = "cbox_Select";
            this.cbox_Select.Size = new System.Drawing.Size(176, 20);
            this.cbox_Select.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "分割Word文档方式：";
            // 
            // txt_SavePath
            // 
            this.txt_SavePath.Location = new System.Drawing.Point(137, 71);
            this.txt_SavePath.Name = "txt_SavePath";
            this.txt_SavePath.ReadOnly = true;
            this.txt_SavePath.Size = new System.Drawing.Size(176, 21);
            this.txt_SavePath.TabIndex = 8;
            // 
            // btn_Save
            // 
            this.btn_Save.Enabled = false;
            this.btn_Save.Location = new System.Drawing.Point(319, 71);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 10;
            this.btn_Save.Text = "选择";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "保存分割文本文件：";
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(137, 31);
            this.txt_path.Name = "txt_path";
            this.txt_path.ReadOnly = true;
            this.txt_path.Size = new System.Drawing.Size(176, 21);
            this.txt_path.TabIndex = 2;
            // 
            // txt_select
            // 
            this.txt_select.Location = new System.Drawing.Point(319, 31);
            this.txt_select.Name = "txt_select";
            this.txt_select.Size = new System.Drawing.Size(75, 23);
            this.txt_select.TabIndex = 4;
            this.txt_select.Text = "选择";
            this.txt_select.UseVisualStyleBackColor = true;
            this.txt_select.Click += new System.EventHandler(this.txt_select_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "打开Word文档位置：";
            // 
            // btn_split
            // 
            this.btn_split.Enabled = false;
            this.btn_split.Location = new System.Drawing.Point(319, 107);
            this.btn_split.Name = "btn_split";
            this.btn_split.Size = new System.Drawing.Size(75, 23);
            this.btn_split.TabIndex = 0;
            this.btn_split.Text = "开始分解";
            this.btn_split.UseVisualStyleBackColor = true;
            this.btn_split.Click += new System.EventHandler(this.btn_split_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 166);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.Text = "将Word中数据分解到多个文本文件中";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbox_Select;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_SavePath;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button txt_select;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_split;
    }
}

