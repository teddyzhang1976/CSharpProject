namespace MultiFormatTxt
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
            this.DataGridView3 = new System.Windows.Forms.DataGridView();
            this.DataGridView2 = new System.Windows.Forms.DataGridView();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnParseTextFiles = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView3
            // 
            this.DataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DataGridView3.ColumnHeadersHeight = 32;
            this.DataGridView3.Location = new System.Drawing.Point(227, 214);
            this.DataGridView3.Margin = new System.Windows.Forms.Padding(2);
            this.DataGridView3.Name = "DataGridView3";
            this.DataGridView3.RowTemplate.Height = 27;
            this.DataGridView3.Size = new System.Drawing.Size(324, 111);
            this.DataGridView3.TabIndex = 21;
            this.DataGridView3.Text = "DataGridView3";
            // 
            // DataGridView2
            // 
            this.DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DataGridView2.ColumnHeadersHeight = 32;
            this.DataGridView2.Location = new System.Drawing.Point(227, 107);
            this.DataGridView2.Margin = new System.Windows.Forms.Padding(2);
            this.DataGridView2.Name = "DataGridView2";
            this.DataGridView2.RowTemplate.Height = 27;
            this.DataGridView2.Size = new System.Drawing.Size(324, 103);
            this.DataGridView2.TabIndex = 20;
            this.DataGridView2.Text = "DataGridView2";
            // 
            // DataGridView1
            // 
            this.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DataGridView1.ColumnHeadersHeight = 32;
            this.DataGridView1.Location = new System.Drawing.Point(227, 6);
            this.DataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowTemplate.Height = 27;
            this.DataGridView1.Size = new System.Drawing.Size(324, 96);
            this.DataGridView1.TabIndex = 19;
            this.DataGridView1.Text = "DataGridView1";
            // 
            // btnParseTextFiles
            // 
            this.btnParseTextFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnParseTextFiles.Location = new System.Drawing.Point(22, 266);
            this.btnParseTextFiles.Margin = new System.Windows.Forms.Padding(2);
            this.btnParseTextFiles.Name = "btnParseTextFiles";
            this.btnParseTextFiles.Size = new System.Drawing.Size(174, 59);
            this.btnParseTextFiles.TabIndex = 18;
            this.btnParseTextFiles.Text = "将内含多重格式的文本文件显示在 DataGridView 控件中";
            this.btnParseTextFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParseTextFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnParseTextFiles.Click += new System.EventHandler(this.btnParseTextFiles_Click);
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtResult.Location = new System.Drawing.Point(5, 21);
            this.txtResult.Margin = new System.Windows.Forms.Padding(2);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(208, 228);
            this.txtResult.TabIndex = 17;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 6);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(77, 12);
            this.Label1.TabIndex = 16;
            this.Label1.Text = "文本文件内容";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 330);
            this.Controls.Add(this.DataGridView3);
            this.Controls.Add(this.DataGridView2);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.btnParseTextFiles);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.Label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "解析含有多种格式的文本文件";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView DataGridView3;
        internal System.Windows.Forms.DataGridView DataGridView2;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.Button btnParseTextFiles;
        internal System.Windows.Forms.TextBox txtResult;
        internal System.Windows.Forms.Label Label1;
    }
}

