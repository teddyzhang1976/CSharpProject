namespace CheckedListBoxForSelect
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
            this.bntEsce = new System.Windows.Forms.Button();
            this.bntSearch = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.rdbWoMan = new System.Windows.Forms.RadioButton();
            this.rdbMan = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.ckClass = new System.Windows.Forms.CheckBox();
            this.ckName = new System.Windows.Forms.CheckBox();
            this.txtstuId = new System.Windows.Forms.TextBox();
            this.ckId = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bntEsce);
            this.groupBox1.Controls.Add(this.bntSearch);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtClass);
            this.groupBox1.Controls.Add(this.rdbWoMan);
            this.groupBox1.Controls.Add(this.rdbMan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ckClass);
            this.groupBox1.Controls.Add(this.ckName);
            this.groupBox1.Controls.Add(this.txtstuId);
            this.groupBox1.Controls.Add(this.ckId);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // bntEsce
            // 
            this.bntEsce.Location = new System.Drawing.Point(185, 77);
            this.bntEsce.Name = "bntEsce";
            this.bntEsce.Size = new System.Drawing.Size(75, 23);
            this.bntEsce.TabIndex = 10;
            this.bntEsce.Text = "取消(&F)";
            this.bntEsce.UseVisualStyleBackColor = true;
            this.bntEsce.Click += new System.EventHandler(this.bntEsce_Click);
            // 
            // bntSearch
            // 
            this.bntSearch.Location = new System.Drawing.Point(94, 77);
            this.bntSearch.Name = "bntSearch";
            this.bntSearch.Size = new System.Drawing.Size(75, 23);
            this.bntSearch.TabIndex = 9;
            this.bntSearch.Text = "搜索(&D)";
            this.bntSearch.UseVisualStyleBackColor = true;
            this.bntSearch.Click += new System.EventHandler(this.bntSearch_Click);
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(69, 52);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 8;
            // 
            // txtClass
            // 
            this.txtClass.Enabled = false;
            this.txtClass.Location = new System.Drawing.Point(239, 16);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(94, 21);
            this.txtClass.TabIndex = 7;
            // 
            // rdbWoMan
            // 
            this.rdbWoMan.AutoSize = true;
            this.rdbWoMan.Location = new System.Drawing.Point(298, 58);
            this.rdbWoMan.Name = "rdbWoMan";
            this.rdbWoMan.Size = new System.Drawing.Size(35, 16);
            this.rdbWoMan.TabIndex = 6;
            this.rdbWoMan.TabStop = true;
            this.rdbWoMan.Text = "女";
            this.rdbWoMan.UseVisualStyleBackColor = true;
            // 
            // rdbMan
            // 
            this.rdbMan.AutoSize = true;
            this.rdbMan.Location = new System.Drawing.Point(239, 57);
            this.rdbMan.Name = "rdbMan";
            this.rdbMan.Size = new System.Drawing.Size(35, 16);
            this.rdbMan.TabIndex = 5;
            this.rdbMan.TabStop = true;
            this.rdbMan.Text = "男";
            this.rdbMan.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "性别：";
            // 
            // ckClass
            // 
            this.ckClass.AutoSize = true;
            this.ckClass.Location = new System.Drawing.Point(185, 21);
            this.ckClass.Name = "ckClass";
            this.ckClass.Size = new System.Drawing.Size(60, 16);
            this.ckClass.TabIndex = 3;
            this.ckClass.Text = "年级：";
            this.ckClass.UseVisualStyleBackColor = true;
            this.ckClass.CheckedChanged += new System.EventHandler(this.ckClass_CheckedChanged);
            // 
            // ckName
            // 
            this.ckName.AutoSize = true;
            this.ckName.Location = new System.Drawing.Point(17, 58);
            this.ckName.Name = "ckName";
            this.ckName.Size = new System.Drawing.Size(60, 16);
            this.ckName.TabIndex = 2;
            this.ckName.Text = "姓名：";
            this.ckName.UseVisualStyleBackColor = true;
            this.ckName.CheckedChanged += new System.EventHandler(this.ckName_CheckedChanged);
            // 
            // txtstuId
            // 
            this.txtstuId.Enabled = false;
            this.txtstuId.Location = new System.Drawing.Point(69, 16);
            this.txtstuId.Name = "txtstuId";
            this.txtstuId.Size = new System.Drawing.Size(100, 21);
            this.txtstuId.TabIndex = 1;
            // 
            // ckId
            // 
            this.ckId.AutoSize = true;
            this.ckId.Location = new System.Drawing.Point(17, 21);
            this.ckId.Name = "ckId";
            this.ckId.Size = new System.Drawing.Size(60, 16);
            this.ckId.TabIndex = 0;
            this.ckId.Text = "学号：";
            this.ckId.UseVisualStyleBackColor = true;
            this.ckId.CheckedChanged += new System.EventHandler(this.ckId_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView1.Location = new System.Drawing.Point(39, 136);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(339, 96);
            this.dataGridView1.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "学生编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "学生姓名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "学生性别";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "学生年龄";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "学生年级";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "家庭住址";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 216);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.Text = "利用选择控件实现复杂查询";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbWoMan;
        private System.Windows.Forms.RadioButton rdbMan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckClass;
        private System.Windows.Forms.CheckBox ckName;
        private System.Windows.Forms.TextBox txtstuId;
        private System.Windows.Forms.CheckBox ckId;
        private System.Windows.Forms.Button bntEsce;
        private System.Windows.Forms.Button bntSearch;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}

