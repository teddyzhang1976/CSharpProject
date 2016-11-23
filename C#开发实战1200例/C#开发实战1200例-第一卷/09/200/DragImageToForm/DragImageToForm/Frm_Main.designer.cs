namespace DragImageToForm
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
            this.panel_face = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Tool_Ima = new System.Windows.Forms.ToolStripMenuItem();
            this.Tool_File = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_face
            // 
            this.panel_face.ContextMenuStrip = this.contextMenuStrip1;
            this.panel_face.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_face.Location = new System.Drawing.Point(0, 0);
            this.panel_face.Name = "panel_face";
            this.panel_face.Size = new System.Drawing.Size(391, 238);
            this.panel_face.TabIndex = 0;
            this.panel_face.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tool_Ima,
            this.Tool_File});
            this.contextMenuStrip1.Name = "contextMenuStrip2";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 48);
            // 
            // Tool_Ima
            // 
            this.Tool_Ima.Name = "Tool_Ima";
            this.Tool_Ima.Size = new System.Drawing.Size(136, 22);
            this.Tool_Ima.Tag = "1";
            this.Tool_Ima.Text = "拖放图片";
            // 
            // Tool_File
            // 
            this.Tool_File.Name = "Tool_File";
            this.Tool_File.Size = new System.Drawing.Size(136, 22);
            this.Tool_File.Tag = "2";
            this.Tool_File.Text = "拖放文件夹";
            // 
            // Frm_Main
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 238);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.panel_face);
            this.Name = "Frm_Main";
            this.Text = "向窗体中拖放图片并显示";
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Frm_Main_DragEnter);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_face;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Tool_Ima;
        private System.Windows.Forms.ToolStripMenuItem Tool_File;

    }
}

