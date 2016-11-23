namespace PortFolio
{
    partial class PositionMonitorDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PositionMonitorDlg));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewPositionTrading = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.多开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.多平ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空平ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.头寸回撤ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.调整ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionDirection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balancePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.floatingGainLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.liquidationGainLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.floatingGainLossRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.netGainLossRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.liquidationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPositionTrading)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton6,
            this.toolStripButton5,
            this.toolStripButton4,
            this.toolStripButton3,
            this.toolStripButton2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1276, 40);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(60, 37);
            this.toolStripButton6.Text = "多开股票";
            this.toolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(60, 37);
            this.toolStripButton5.Text = "空开股票";
            this.toolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(60, 37);
            this.toolStripButton4.Text = "多平股票";
            this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(60, 37);
            this.toolStripButton3.Text = "空平股票";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(60, 37);
            this.toolStripButton2.Text = "头寸回撤";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 37);
            this.toolStripButton1.Text = "头寸调整";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // dataGridViewPositionTrading
            // 
            this.dataGridViewPositionTrading.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPositionTrading.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPositionTrading.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPositionTrading.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.name,
            this.positionCount,
            this.positionDirection,
            this.currentValue,
            this.purchasePrice,
            this.currentPrice,
            this.balancePrice,
            this.floatingGainLoss,
            this.liquidationGainLoss,
            this.floatingGainLossRate,
            this.netGainLossRate,
            this.purchaseDate,
            this.liquidationDate,
            this.memo});
            this.dataGridViewPositionTrading.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPositionTrading.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewPositionTrading.Location = new System.Drawing.Point(152, 44);
            this.dataGridViewPositionTrading.Name = "dataGridViewPositionTrading";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPositionTrading.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewPositionTrading.RowTemplate.Height = 23;
            this.dataGridViewPositionTrading.Size = new System.Drawing.Size(1101, 501);
            this.dataGridViewPositionTrading.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.多开ToolStripMenuItem,
            this.多平ToolStripMenuItem,
            this.空开ToolStripMenuItem,
            this.空平ToolStripMenuItem,
            this.头寸回撤ToolStripMenuItem,
            this.调整ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 136);
            // 
            // 多开ToolStripMenuItem
            // 
            this.多开ToolStripMenuItem.Name = "多开ToolStripMenuItem";
            this.多开ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.多开ToolStripMenuItem.Text = "多开";
            // 
            // 多平ToolStripMenuItem
            // 
            this.多平ToolStripMenuItem.Name = "多平ToolStripMenuItem";
            this.多平ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.多平ToolStripMenuItem.Text = "多平";
            // 
            // 空开ToolStripMenuItem
            // 
            this.空开ToolStripMenuItem.Name = "空开ToolStripMenuItem";
            this.空开ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.空开ToolStripMenuItem.Text = "空开";
            // 
            // 空平ToolStripMenuItem
            // 
            this.空平ToolStripMenuItem.Name = "空平ToolStripMenuItem";
            this.空平ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.空平ToolStripMenuItem.Text = "空平";
            // 
            // 头寸回撤ToolStripMenuItem
            // 
            this.头寸回撤ToolStripMenuItem.Name = "头寸回撤ToolStripMenuItem";
            this.头寸回撤ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.头寸回撤ToolStripMenuItem.Text = "回撤";
            // 
            // 调整ToolStripMenuItem
            // 
            this.调整ToolStripMenuItem.Name = "调整ToolStripMenuItem";
            this.调整ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.调整ToolStripMenuItem.Text = "调整";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 44);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(134, 501);
            this.treeView1.TabIndex = 3;
            // 
            // code
            // 
            this.code.HeaderText = "代码";
            this.code.Name = "code";
            this.code.Width = 54;
            // 
            // name
            // 
            this.name.HeaderText = "名称";
            this.name.Name = "name";
            this.name.Width = 54;
            // 
            // positionCount
            // 
            this.positionCount.HeaderText = "头寸数量";
            this.positionCount.Name = "positionCount";
            this.positionCount.Width = 78;
            // 
            // positionDirection
            // 
            this.positionDirection.HeaderText = "头寸方向";
            this.positionDirection.Name = "positionDirection";
            this.positionDirection.Width = 78;
            // 
            // currentValue
            // 
            this.currentValue.HeaderText = "市值";
            this.currentValue.Name = "currentValue";
            this.currentValue.Width = 54;
            // 
            // purchasePrice
            // 
            this.purchasePrice.HeaderText = "成本价";
            this.purchasePrice.Name = "purchasePrice";
            this.purchasePrice.Width = 66;
            // 
            // currentPrice
            // 
            this.currentPrice.HeaderText = "最新价";
            this.currentPrice.Name = "currentPrice";
            this.currentPrice.Width = 66;
            // 
            // balancePrice
            // 
            this.balancePrice.HeaderText = "保本价";
            this.balancePrice.Name = "balancePrice";
            this.balancePrice.Width = 66;
            // 
            // floatingGainLoss
            // 
            this.floatingGainLoss.HeaderText = "浮动盈亏";
            this.floatingGainLoss.Name = "floatingGainLoss";
            this.floatingGainLoss.Width = 78;
            // 
            // liquidationGainLoss
            // 
            this.liquidationGainLoss.HeaderText = "成交盈亏";
            this.liquidationGainLoss.Name = "liquidationGainLoss";
            this.liquidationGainLoss.Width = 78;
            // 
            // floatingGainLossRate
            // 
            this.floatingGainLossRate.HeaderText = "浮盈率";
            this.floatingGainLossRate.Name = "floatingGainLossRate";
            this.floatingGainLossRate.Width = 66;
            // 
            // netGainLossRate
            // 
            this.netGainLossRate.HeaderText = "盈利率";
            this.netGainLossRate.Name = "netGainLossRate";
            this.netGainLossRate.Width = 66;
            // 
            // purchaseDate
            // 
            this.purchaseDate.HeaderText = "开仓日期";
            this.purchaseDate.Name = "purchaseDate";
            this.purchaseDate.Width = 78;
            // 
            // liquidationDate
            // 
            this.liquidationDate.HeaderText = "平仓日期";
            this.liquidationDate.Name = "liquidationDate";
            this.liquidationDate.Width = 78;
            // 
            // memo
            // 
            this.memo.HeaderText = "操作笔记";
            this.memo.Name = "memo";
            this.memo.Width = 78;
            // 
            // PositionTradingDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 568);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.dataGridViewPositionTrading);
            this.Controls.Add(this.toolStrip1);
            this.Name = "PositionTradingDlg";
            this.Text = "PositionTrading";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPositionTrading)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.DataGridView dataGridViewPositionTrading;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 多开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 多平ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空平ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 头寸回撤ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 调整ToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDirection;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn balancePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn floatingGainLoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn liquidationGainLoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn floatingGainLossRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn netGainLossRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn liquidationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn memo;
    }
}