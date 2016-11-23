namespace UseTransForm
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
            this.dgv_Message = new System.Windows.Forms.DataGridView();
            this.cb_NetWork = new System.Windows.Forms.CheckBox();
            this.cb_HardWare = new System.Windows.Forms.CheckBox();
            this.cb_SoftWare = new System.Windows.Forms.CheckBox();
            this.cbox_RowField = new System.Windows.Forms.ComboBox();
            this.cbox_ColumnField = new System.Windows.Forms.ComboBox();
            this.cbox_GatherField = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Select = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Message)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Message
            // 
            this.dgv_Message.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Message.Location = new System.Drawing.Point(0, 89);
            this.dgv_Message.Name = "dgv_Message";
            this.dgv_Message.RowTemplate.Height = 23;
            this.dgv_Message.Size = new System.Drawing.Size(440, 127);
            this.dgv_Message.TabIndex = 18;
            // 
            // cb_NetWork
            // 
            this.cb_NetWork.AutoSize = true;
            this.cb_NetWork.Location = new System.Drawing.Point(243, 69);
            this.cb_NetWork.Name = "cb_NetWork";
            this.cb_NetWork.Size = new System.Drawing.Size(60, 16);
            this.cb_NetWork.TabIndex = 15;
            this.cb_NetWork.Text = "网络部";
            this.cb_NetWork.UseVisualStyleBackColor = true;
            // 
            // cb_HardWare
            // 
            this.cb_HardWare.AutoSize = true;
            this.cb_HardWare.Location = new System.Drawing.Point(159, 69);
            this.cb_HardWare.Name = "cb_HardWare";
            this.cb_HardWare.Size = new System.Drawing.Size(60, 16);
            this.cb_HardWare.TabIndex = 16;
            this.cb_HardWare.Text = "硬件部";
            this.cb_HardWare.UseVisualStyleBackColor = true;
            // 
            // cb_SoftWare
            // 
            this.cb_SoftWare.AutoSize = true;
            this.cb_SoftWare.Location = new System.Drawing.Point(75, 69);
            this.cb_SoftWare.Name = "cb_SoftWare";
            this.cb_SoftWare.Size = new System.Drawing.Size(60, 16);
            this.cb_SoftWare.TabIndex = 17;
            this.cb_SoftWare.Text = "软件部";
            this.cb_SoftWare.UseVisualStyleBackColor = true;
            // 
            // cbox_RowField
            // 
            this.cbox_RowField.FormattingEnabled = true;
            this.cbox_RowField.Location = new System.Drawing.Point(354, 42);
            this.cbox_RowField.Name = "cbox_RowField";
            this.cbox_RowField.Size = new System.Drawing.Size(79, 20);
            this.cbox_RowField.TabIndex = 13;
            this.cbox_RowField.Text = "部门名称";
            // 
            // cbox_ColumnField
            // 
            this.cbox_ColumnField.FormattingEnabled = true;
            this.cbox_ColumnField.Location = new System.Drawing.Point(214, 42);
            this.cbox_ColumnField.Name = "cbox_ColumnField";
            this.cbox_ColumnField.Size = new System.Drawing.Size(75, 20);
            this.cbox_ColumnField.TabIndex = 14;
            this.cbox_ColumnField.Text = "季度";
            // 
            // cbox_GatherField
            // 
            this.cbox_GatherField.FormattingEnabled = true;
            this.cbox_GatherField.Location = new System.Drawing.Point(68, 42);
            this.cbox_GatherField.Name = "cbox_GatherField";
            this.cbox_GatherField.Size = new System.Drawing.Size(79, 20);
            this.cbox_GatherField.TabIndex = 12;
            this.cbox_GatherField.Text = "销售金额";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "区间范围：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "行字段：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "列表字段：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "汇总字段：";
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(356, 64);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(75, 23);
            this.btn_Select.TabIndex = 7;
            this.btn_Select.Text = "交叉表统计";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(76, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "吉林省明日科技营业数据分析";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 216);
            this.Controls.Add(this.dgv_Message);
            this.Controls.Add(this.cb_NetWork);
            this.Controls.Add(this.cb_HardWare);
            this.Controls.Add(this.cb_SoftWare);
            this.Controls.Add(this.cbox_RowField);
            this.Controls.Add(this.cbox_ColumnField);
            this.Controls.Add(this.cbox_GatherField);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Select);
            this.Controls.Add(this.label1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "利用Transform动态分析数据";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Message)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Message;
        private System.Windows.Forms.CheckBox cb_NetWork;
        private System.Windows.Forms.CheckBox cb_HardWare;
        private System.Windows.Forms.CheckBox cb_SoftWare;
        private System.Windows.Forms.ComboBox cbox_RowField;
        private System.Windows.Forms.ComboBox cbox_ColumnField;
        private System.Windows.Forms.ComboBox cbox_GatherField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Label label1;

    }
}

