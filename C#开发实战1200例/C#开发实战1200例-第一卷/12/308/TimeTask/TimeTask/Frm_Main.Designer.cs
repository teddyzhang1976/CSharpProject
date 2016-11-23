namespace TimeTask
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
            this.Moth_Display = new System.Windows.Forms.MonthCalendar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Task = new System.Windows.Forms.TextBox();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.lv_Task = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Moth_Display
            // 
            this.Moth_Display.Location = new System.Drawing.Point(229, 2);
            this.Moth_Display.Name = "Moth_Display";
            this.Moth_Display.TabIndex = 0;
            this.Moth_Display.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Moth_Display_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lv_Task);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 176);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "任务列表";
            // 
            // txt_Task
            // 
            this.txt_Task.Location = new System.Drawing.Point(6, 20);
            this.txt_Task.Multiline = true;
            this.txt_Task.Name = "txt_Task";
            this.txt_Task.Size = new System.Drawing.Size(430, 51);
            this.txt_Task.TabIndex = 4;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(62, 184);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(86, 23);
            this.btn_Delete.TabIndex = 5;
            this.btn_Delete.Text = "删除任务";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // lv_Task
            // 
            this.lv_Task.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv_Task.GridLines = true;
            this.lv_Task.Location = new System.Drawing.Point(6, 20);
            this.lv_Task.Name = "lv_Task";
            this.lv_Task.Size = new System.Drawing.Size(208, 150);
            this.lv_Task.TabIndex = 0;
            this.lv_Task.UseCompatibleStateImageBehavior = false;
            this.lv_Task.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "任务时间";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "任务内容";
            this.columnHeader2.Width = 260;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_Task);
            this.groupBox2.Location = new System.Drawing.Point(8, 213);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(441, 78);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "任务内容";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 296);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Moth_Display);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "日历计划任务";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar Moth_Display;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_Task;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.ListView lv_Task;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

