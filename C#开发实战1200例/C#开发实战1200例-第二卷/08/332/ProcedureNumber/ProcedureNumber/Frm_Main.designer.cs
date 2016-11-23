namespace ProcedureNumber
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
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Clsoe = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_Age = new System.Windows.Forms.TextBox();
            this.txt_Num = new System.Windows.Forms.TextBox();
            this.txt_Money = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.errorage = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorage)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(213, 113);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "确定(&O)";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Clsoe
            // 
            this.btn_Clsoe.Location = new System.Drawing.Point(313, 113);
            this.btn_Clsoe.Name = "btn_Clsoe";
            this.btn_Clsoe.Size = new System.Drawing.Size(75, 23);
            this.btn_Clsoe.TabIndex = 1;
            this.btn_Clsoe.Text = "退出(&Q)";
            this.btn_Clsoe.UseVisualStyleBackColor = true;
            this.btn_Clsoe.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "员工编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "员工年龄：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "身份证号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "员工姓名：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "基本工资：";
            // 
            // txt_id
            // 
            this.txt_id.Enabled = false;
            this.txt_id.Location = new System.Drawing.Point(66, 32);
            this.txt_id.MaxLength = 6;
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(115, 21);
            this.txt_id.TabIndex = 8;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(273, 32);
            this.txt_Name.MaxLength = 30;
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(115, 21);
            this.txt_Name.TabIndex = 9;
            // 
            // txt_Age
            // 
            this.errorage.SetIconPadding(this.txt_Age, 4);
            this.txt_Age.Location = new System.Drawing.Point(65, 59);
            this.txt_Age.MaxLength = 3;
            this.txt_Age.Name = "txt_Age";
            this.txt_Age.Size = new System.Drawing.Size(115, 21);
            this.txt_Age.TabIndex = 10;
            this.txt_Age.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            // 
            // txt_Num
            // 
            this.txt_Num.Location = new System.Drawing.Point(66, 86);
            this.txt_Num.MaxLength = 18;
            this.txt_Num.Name = "txt_Num";
            this.txt_Num.Size = new System.Drawing.Size(323, 21);
            this.txt_Num.TabIndex = 11;
            // 
            // txt_Money
            // 
            this.txt_Money.Location = new System.Drawing.Point(273, 59);
            this.txt_Money.MaxLength = 8;
            this.txt_Money.Name = "txt_Money";
            this.txt_Money.Size = new System.Drawing.Size(115, 21);
            this.txt_Money.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(172, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "员工个人信息";
            // 
            // errorage
            // 
            this.errorage.ContainerControl = this;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 146);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_Money);
            this.Controls.Add(this.txt_Num);
            this.Controls.Add(this.txt_Age);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Clsoe);
            this.Controls.Add(this.btn_OK);
            this.Name = "Frm_Main";
            this.Text = "判断输入数据是否符合要求";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Clsoe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_Age;
        private System.Windows.Forms.ErrorProvider errorage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Money;
        private System.Windows.Forms.TextBox txt_Num;
    }
}

