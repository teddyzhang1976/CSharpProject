namespace BatchOperByTrans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.dgvPRProduceInfo = new System.Windows.Forms.DataGridView();
            this.PRProduceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRProduceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperatorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRPlanCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartmentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvenCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsComplete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRProduceInfo)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPRProduceInfo
            // 
            this.dgvPRProduceInfo.AllowUserToAddRows = false;
            this.dgvPRProduceInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPRProduceInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PRProduceCode,
            this.PRProduceDate,
            this.OperatorCode,
            this.PRPlanCode,
            this.DepartmentCode,
            this.InvenCode,
            this.Quantity,
            this.StartDate,
            this.EndDate,
            this.IsComplete});
            this.dgvPRProduceInfo.Location = new System.Drawing.Point(5, 28);
            this.dgvPRProduceInfo.Name = "dgvPRProduceInfo";
            this.dgvPRProduceInfo.RowTemplate.Height = 23;
            this.dgvPRProduceInfo.Size = new System.Drawing.Size(587, 194);
            this.dgvPRProduceInfo.TabIndex = 0;
            // 
            // PRProduceCode
            // 
            this.PRProduceCode.DataPropertyName = "PRProduceCode";
            this.PRProduceCode.HeaderText = "单据编号";
            this.PRProduceCode.Name = "PRProduceCode";
            this.PRProduceCode.ReadOnly = true;
            // 
            // PRProduceDate
            // 
            this.PRProduceDate.DataPropertyName = "PRProduceDate";
            this.PRProduceDate.HeaderText = "单据日期";
            this.PRProduceDate.Name = "PRProduceDate";
            this.PRProduceDate.ReadOnly = true;
            // 
            // OperatorCode
            // 
            this.OperatorCode.DataPropertyName = "OperatorCode";
            this.OperatorCode.HeaderText = "操作员";
            this.OperatorCode.Name = "OperatorCode";
            this.OperatorCode.ReadOnly = true;
            this.OperatorCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OperatorCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PRPlanCode
            // 
            this.PRPlanCode.DataPropertyName = "PRPlanCode";
            this.PRPlanCode.HeaderText = "主计划号";
            this.PRPlanCode.Name = "PRPlanCode";
            this.PRPlanCode.ReadOnly = true;
            this.PRPlanCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PRPlanCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DepartmentCode
            // 
            this.DepartmentCode.DataPropertyName = "DepartmentCode";
            this.DepartmentCode.HeaderText = "生产车间";
            this.DepartmentCode.Name = "DepartmentCode";
            this.DepartmentCode.ReadOnly = true;
            this.DepartmentCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DepartmentCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // InvenCode
            // 
            this.InvenCode.DataPropertyName = "InvenCode";
            this.InvenCode.HeaderText = "产品名称";
            this.InvenCode.Name = "InvenCode";
            this.InvenCode.ReadOnly = true;
            this.InvenCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InvenCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "生产数量";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // StartDate
            // 
            this.StartDate.DataPropertyName = "StartDate";
            this.StartDate.HeaderText = "开始日期";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            this.StartDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // EndDate
            // 
            this.EndDate.DataPropertyName = "EndDate";
            this.EndDate.HeaderText = "结束日期";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            this.EndDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // IsComplete
            // 
            this.IsComplete.DataPropertyName = "IsComplete";
            this.IsComplete.HeaderText = "是否完工";
            this.IsComplete.Name = "IsComplete";
            this.IsComplete.ReadOnly = true;
            this.IsComplete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsComplete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolDelete
            // 
            this.toolDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolDelete.Image")));
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(52, 22);
            this.toolDelete.Tag = "5";
            this.toolDelete.Text = "删除";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolDelete,
            this.toolStripSeparator1,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(596, 25);
            this.toolStrip1.TabIndex = 72;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolExit
            // 
            this.toolExit.Image = ((System.Drawing.Image)(resources.GetObject("toolExit.Image")));
            this.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(52, 22);
            this.toolExit.Tag = "7";
            this.toolExit.Text = "退出";
            this.toolExit.Click += new System.EventHandler(this.toolExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 224);
            this.Controls.Add(this.dgvPRProduceInfo);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "使用事务批量删除生产单信息";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPRProduceInfo)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvPRProduceInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRProduceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRProduceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperatorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRPlanCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvenCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsComplete;
    }
}

