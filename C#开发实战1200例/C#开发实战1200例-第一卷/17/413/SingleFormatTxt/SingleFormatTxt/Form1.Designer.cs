namespace SingleFormatTxt
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
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnParseTextFiles = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView1
            // 
            this.DataGridView1.Location = new System.Drawing.Point(1, 161);
            this.DataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowTemplate.Height = 27;
            this.DataGridView1.Size = new System.Drawing.Size(448, 174);
            this.DataGridView1.TabIndex = 11;
            this.DataGridView1.Text = "DataGridView1";
            // 
            // btnParseTextFiles
            // 
            this.btnParseTextFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnParseTextFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnParseTextFiles.Location = new System.Drawing.Point(43, 130);
            this.btnParseTextFiles.Margin = new System.Windows.Forms.Padding(2);
            this.btnParseTextFiles.Name = "btnParseTextFiles";
            this.btnParseTextFiles.Size = new System.Drawing.Size(362, 27);
            this.btnParseTextFiles.TabIndex = 10;
            this.btnParseTextFiles.Text = "将字符分隔字段的文本文件显示在 DataGridView 控件中";
            this.btnParseTextFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParseTextFiles.Click += new System.EventHandler(this.btnParseTextFiles_Click);
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtResult.Location = new System.Drawing.Point(1, 21);
            this.txtResult.Margin = new System.Windows.Forms.Padding(2);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(448, 105);
            this.txtResult.TabIndex = 9;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label1.Location = new System.Drawing.Point(4, 3);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(111, 20);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "文本文件内容";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 339);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.btnParseTextFiles);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.Label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "解析只有一种格式的文本文件";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.Button btnParseTextFiles;
        internal System.Windows.Forms.TextBox txtResult;
        internal System.Windows.Forms.Label Label1;
    }
}

