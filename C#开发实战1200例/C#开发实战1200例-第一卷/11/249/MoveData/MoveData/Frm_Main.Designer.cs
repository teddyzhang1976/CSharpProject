namespace MoveData
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
            if(disposing && (components != null))
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.allLeft = new System.Windows.Forms.Button();
            this.allRight = new System.Windows.Forms.Button();
            this.left = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(5, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(100, 257);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "水果";
            // 
            // listView1
            // 
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(4, 13);
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(92, 240);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView2);
            this.groupBox2.Location = new System.Drawing.Point(187, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(100, 257);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "购物车";
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(4, 13);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(92, 240);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.List;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.allLeft);
            this.groupBox3.Controls.Add(this.allRight);
            this.groupBox3.Controls.Add(this.left);
            this.groupBox3.Controls.Add(this.right);
            this.groupBox3.Location = new System.Drawing.Point(113, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(61, 257);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作";
            // 
            // allLeft
            // 
            this.allLeft.Location = new System.Drawing.Point(6, 206);
            this.allLeft.Name = "allLeft";
            this.allLeft.Size = new System.Drawing.Size(49, 23);
            this.allLeft.TabIndex = 0;
            this.allLeft.Text = "<<";
            this.allLeft.UseVisualStyleBackColor = true;
            this.allLeft.Click += new System.EventHandler(this.allLeft_Click);
            // 
            // allRight
            // 
            this.allRight.Location = new System.Drawing.Point(6, 142);
            this.allRight.Name = "allRight";
            this.allRight.Size = new System.Drawing.Size(49, 23);
            this.allRight.TabIndex = 0;
            this.allRight.Text = ">>";
            this.allRight.UseVisualStyleBackColor = true;
            this.allRight.Click += new System.EventHandler(this.allRight_Click);
            // 
            // left
            // 
            this.left.Location = new System.Drawing.Point(6, 83);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(49, 23);
            this.left.TabIndex = 0;
            this.left.Text = "<<";
            this.left.UseVisualStyleBackColor = true;
            this.left.Click += new System.EventHandler(this.left_Click);
            // 
            // right
            // 
            this.right.Location = new System.Drawing.Point(6, 30);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(49, 23);
            this.right.TabIndex = 0;
            this.right.Text = ">>";
            this.right.UseVisualStyleBackColor = true;
            this.right.Click += new System.EventHandler(this.right_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 263);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListView间的数据移动";
            this.Load += new System.EventHandler(this.MoveData_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Button allLeft;
        private System.Windows.Forms.Button allRight;
        private System.Windows.Forms.Button left;
    }
}

