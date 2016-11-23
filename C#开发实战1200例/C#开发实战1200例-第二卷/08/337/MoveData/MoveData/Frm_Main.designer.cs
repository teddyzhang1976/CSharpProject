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
            this.txt_money = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Message = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Befor = new System.Windows.Forms.Button();
            this.btn_Last = new System.Windows.Forms.Button();
            this.btn_After = new System.Windows.Forms.Button();
            this.btn_First = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_money
            // 
            this.txt_money.Location = new System.Drawing.Point(62, 55);
            this.txt_money.Name = "txt_money";
            this.txt_money.Size = new System.Drawing.Size(86, 21);
            this.txt_money.TabIndex = 9;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(217, 22);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(86, 21);
            this.txt_Name.TabIndex = 7;
            // 
            // txt_id
            // 
            this.txt_id.Enabled = false;
            this.txt_id.Location = new System.Drawing.Point(62, 22);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(86, 21);
            this.txt_id.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(159, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "工作评价";
            // 
            // txt_Message
            // 
            this.txt_Message.Location = new System.Drawing.Point(217, 55);
            this.txt_Message.Name = "txt_Message";
            this.txt_Message.Size = new System.Drawing.Size(86, 21);
            this.txt_Message.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "员工编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "基本工资";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "员工姓名";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Message);
            this.groupBox1.Controls.Add(this.txt_money);
            this.groupBox1.Controls.Add(this.txt_Name);
            this.groupBox1.Controls.Add(this.txt_id);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 88);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据信息";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Befor);
            this.groupBox2.Controls.Add(this.btn_Last);
            this.groupBox2.Controls.Add(this.btn_After);
            this.groupBox2.Controls.Add(this.btn_First);
            this.groupBox2.Location = new System.Drawing.Point(10, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 58);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查看员工信息";
            // 
            // btn_Befor
            // 
            this.btn_Befor.Location = new System.Drawing.Point(104, 24);
            this.btn_Befor.Name = "btn_Befor";
            this.btn_Befor.Size = new System.Drawing.Size(54, 23);
            this.btn_Befor.TabIndex = 20;
            this.btn_Befor.Text = "上一条";
            this.btn_Befor.UseVisualStyleBackColor = true;
            this.btn_Befor.Click += new System.EventHandler(this.btn_Befor_Click);
            // 
            // btn_Last
            // 
            this.btn_Last.Location = new System.Drawing.Point(224, 24);
            this.btn_Last.Name = "btn_Last";
            this.btn_Last.Size = new System.Drawing.Size(54, 23);
            this.btn_Last.TabIndex = 22;
            this.btn_Last.Text = "末一条";
            this.btn_Last.UseVisualStyleBackColor = true;
            this.btn_Last.Click += new System.EventHandler(this.btn_Last_Click);
            // 
            // btn_After
            // 
            this.btn_After.Location = new System.Drawing.Point(164, 24);
            this.btn_After.Name = "btn_After";
            this.btn_After.Size = new System.Drawing.Size(54, 23);
            this.btn_After.TabIndex = 21;
            this.btn_After.Text = "下一条";
            this.btn_After.UseVisualStyleBackColor = true;
            this.btn_After.Click += new System.EventHandler(this.btn_After_Click);
            // 
            // btn_First
            // 
            this.btn_First.Location = new System.Drawing.Point(44, 24);
            this.btn_First.Name = "btn_First";
            this.btn_First.Size = new System.Drawing.Size(54, 23);
            this.btn_First.TabIndex = 19;
            this.btn_First.Text = "第一条";
            this.btn_First.UseVisualStyleBackColor = true;
            this.btn_First.Click += new System.EventHandler(this.btn_First_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 158);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "移动记录";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_money;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Message;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Befor;
        private System.Windows.Forms.Button btn_Last;
        private System.Windows.Forms.Button btn_After;
        private System.Windows.Forms.Button btn_First;
    }
}

