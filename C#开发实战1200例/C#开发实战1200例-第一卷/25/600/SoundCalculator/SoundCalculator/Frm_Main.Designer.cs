namespace SoundCalculator
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolS_Vox = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pict_Amount = new System.Windows.Forms.PictureBox();
            this.pict_Add = new System.Windows.Forms.PictureBox();
            this.pict_Dot = new System.Windows.Forms.PictureBox();
            this.pict_Bear = new System.Windows.Forms.PictureBox();
            this.pict_0 = new System.Windows.Forms.PictureBox();
            this.pict_Deno = new System.Windows.Forms.PictureBox();
            this.pict_Decr = new System.Windows.Forms.PictureBox();
            this.pict_3 = new System.Windows.Forms.PictureBox();
            this.pict_2 = new System.Windows.Forms.PictureBox();
            this.pict_1 = new System.Windows.Forms.PictureBox();
            this.pict_Hund = new System.Windows.Forms.PictureBox();
            this.pict_Ride = new System.Windows.Forms.PictureBox();
            this.pict_6 = new System.Windows.Forms.PictureBox();
            this.pict_5 = new System.Windows.Forms.PictureBox();
            this.pict_4 = new System.Windows.Forms.PictureBox();
            this.pict_Sqrt = new System.Windows.Forms.PictureBox();
            this.pict_Remove = new System.Windows.Forms.PictureBox();
            this.pict_9 = new System.Windows.Forms.PictureBox();
            this.pict_8 = new System.Windows.Forms.PictureBox();
            this.pict_7 = new System.Windows.Forms.PictureBox();
            this.pict_C = new System.Windows.Forms.PictureBox();
            this.pict_CE = new System.Windows.Forms.PictureBox();
            this.pict_Back = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Dot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Bear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Deno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Decr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Hund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Ride)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Sqrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Remove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_C)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_CE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Back)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolS_Vox,
            this.ToolS_Close});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 48);
            // 
            // ToolS_Vox
            // 
            this.ToolS_Vox.Name = "ToolS_Vox";
            this.ToolS_Vox.Size = new System.Drawing.Size(118, 22);
            this.ToolS_Vox.Tag = "0";
            this.ToolS_Vox.Text = "设置声音";
            this.ToolS_Vox.Click += new System.EventHandler(this.ToolS_Vox_Click);
            // 
            // ToolS_Close
            // 
            this.ToolS_Close.Name = "ToolS_Close";
            this.ToolS_Close.Size = new System.Drawing.Size(118, 22);
            this.ToolS_Close.Tag = "1";
            this.ToolS_Close.Text = "退出";
            this.ToolS_Close.Click += new System.EventHandler(this.ToolS_Vox_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SoundCalculator.Properties.Resources.bg;
            this.panel1.ContextMenuStrip = this.contextMenuStrip1;
            this.panel1.Controls.Add(this.pict_Amount);
            this.panel1.Controls.Add(this.pict_Add);
            this.panel1.Controls.Add(this.pict_Dot);
            this.panel1.Controls.Add(this.pict_Bear);
            this.panel1.Controls.Add(this.pict_0);
            this.panel1.Controls.Add(this.pict_Deno);
            this.panel1.Controls.Add(this.pict_Decr);
            this.panel1.Controls.Add(this.pict_3);
            this.panel1.Controls.Add(this.pict_2);
            this.panel1.Controls.Add(this.pict_1);
            this.panel1.Controls.Add(this.pict_Hund);
            this.panel1.Controls.Add(this.pict_Ride);
            this.panel1.Controls.Add(this.pict_6);
            this.panel1.Controls.Add(this.pict_5);
            this.panel1.Controls.Add(this.pict_4);
            this.panel1.Controls.Add(this.pict_Sqrt);
            this.panel1.Controls.Add(this.pict_Remove);
            this.panel1.Controls.Add(this.pict_9);
            this.panel1.Controls.Add(this.pict_8);
            this.panel1.Controls.Add(this.pict_7);
            this.panel1.Controls.Add(this.pict_C);
            this.panel1.Controls.Add(this.pict_CE);
            this.panel1.Controls.Add(this.pict_Back);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 231);
            this.panel1.TabIndex = 0;
            // 
            // pict_Amount
            // 
            this.pict_Amount.AccessibleName = "=";
            this.pict_Amount.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_Amount.Image = global::SoundCalculator.Properties.Resources.Amound;
            this.pict_Amount.Location = new System.Drawing.Point(188, 195);
            this.pict_Amount.Name = "pict_Amount";
            this.pict_Amount.Size = new System.Drawing.Size(41, 24);
            this.pict_Amount.TabIndex = 23;
            this.pict_Amount.TabStop = false;
            this.pict_Amount.Tag = "=";
            this.pict_Amount.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_Amount.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_Amount.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_Add
            // 
            this.pict_Add.AccessibleName = "+";
            this.pict_Add.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_Add.Image = global::SoundCalculator.Properties.Resources.Add;
            this.pict_Add.Location = new System.Drawing.Point(143, 195);
            this.pict_Add.Name = "pict_Add";
            this.pict_Add.Size = new System.Drawing.Size(41, 24);
            this.pict_Add.TabIndex = 22;
            this.pict_Add.TabStop = false;
            this.pict_Add.Tag = "+";
            this.pict_Add.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_Add.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_Add.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_Dot
            // 
            this.pict_Dot.AccessibleName = ".";
            this.pict_Dot.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_Dot.Image = global::SoundCalculator.Properties.Resources.Dot;
            this.pict_Dot.Location = new System.Drawing.Point(99, 195);
            this.pict_Dot.Name = "pict_Dot";
            this.pict_Dot.Size = new System.Drawing.Size(41, 24);
            this.pict_Dot.TabIndex = 21;
            this.pict_Dot.TabStop = false;
            this.pict_Dot.Tag = ".";
            this.pict_Dot.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_Dot.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_Dot.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_Bear
            // 
            this.pict_Bear.AccessibleName = "+-";
            this.pict_Bear.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_Bear.Image = global::SoundCalculator.Properties.Resources.Bear;
            this.pict_Bear.Location = new System.Drawing.Point(55, 195);
            this.pict_Bear.Name = "pict_Bear";
            this.pict_Bear.Size = new System.Drawing.Size(41, 24);
            this.pict_Bear.TabIndex = 20;
            this.pict_Bear.TabStop = false;
            this.pict_Bear.Tag = "+-";
            this.pict_Bear.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_Bear.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_Bear.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_0
            // 
            this.pict_0.AccessibleName = "0";
            this.pict_0.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_0.Image = global::SoundCalculator.Properties.Resources._0;
            this.pict_0.Location = new System.Drawing.Point(8, 195);
            this.pict_0.Name = "pict_0";
            this.pict_0.Size = new System.Drawing.Size(41, 24);
            this.pict_0.TabIndex = 19;
            this.pict_0.TabStop = false;
            this.pict_0.Tag = "0";
            this.pict_0.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_0.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_0.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_Deno
            // 
            this.pict_Deno.AccessibleName = "X";
            this.pict_Deno.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_Deno.Image = global::SoundCalculator.Properties.Resources.Deno;
            this.pict_Deno.Location = new System.Drawing.Point(188, 164);
            this.pict_Deno.Name = "pict_Deno";
            this.pict_Deno.Size = new System.Drawing.Size(41, 24);
            this.pict_Deno.TabIndex = 18;
            this.pict_Deno.TabStop = false;
            this.pict_Deno.Tag = "X";
            this.pict_Deno.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_Deno.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_Deno.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_Decr
            // 
            this.pict_Decr.AccessibleName = "-";
            this.pict_Decr.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_Decr.Image = global::SoundCalculator.Properties.Resources.Decr;
            this.pict_Decr.Location = new System.Drawing.Point(143, 164);
            this.pict_Decr.Name = "pict_Decr";
            this.pict_Decr.Size = new System.Drawing.Size(41, 24);
            this.pict_Decr.TabIndex = 17;
            this.pict_Decr.TabStop = false;
            this.pict_Decr.Tag = "-";
            this.pict_Decr.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_Decr.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_Decr.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_3
            // 
            this.pict_3.AccessibleName = "3";
            this.pict_3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_3.Image = global::SoundCalculator.Properties.Resources._3;
            this.pict_3.Location = new System.Drawing.Point(99, 164);
            this.pict_3.Name = "pict_3";
            this.pict_3.Size = new System.Drawing.Size(41, 24);
            this.pict_3.TabIndex = 16;
            this.pict_3.TabStop = false;
            this.pict_3.Tag = "3";
            this.pict_3.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_3.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_3.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_2
            // 
            this.pict_2.AccessibleName = "2";
            this.pict_2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_2.Image = global::SoundCalculator.Properties.Resources._2;
            this.pict_2.Location = new System.Drawing.Point(54, 164);
            this.pict_2.Name = "pict_2";
            this.pict_2.Size = new System.Drawing.Size(41, 24);
            this.pict_2.TabIndex = 15;
            this.pict_2.TabStop = false;
            this.pict_2.Tag = "2";
            this.pict_2.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_2.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_2.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_1
            // 
            this.pict_1.AccessibleName = "1";
            this.pict_1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_1.Image = global::SoundCalculator.Properties.Resources._1;
            this.pict_1.Location = new System.Drawing.Point(8, 164);
            this.pict_1.Name = "pict_1";
            this.pict_1.Size = new System.Drawing.Size(41, 24);
            this.pict_1.TabIndex = 14;
            this.pict_1.TabStop = false;
            this.pict_1.Tag = "1";
            this.pict_1.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_1.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_1.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_Hund
            // 
            this.pict_Hund.AccessibleName = "%";
            this.pict_Hund.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_Hund.Image = global::SoundCalculator.Properties.Resources.Hund;
            this.pict_Hund.Location = new System.Drawing.Point(188, 133);
            this.pict_Hund.Name = "pict_Hund";
            this.pict_Hund.Size = new System.Drawing.Size(41, 24);
            this.pict_Hund.TabIndex = 13;
            this.pict_Hund.TabStop = false;
            this.pict_Hund.Tag = "%";
            this.pict_Hund.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_Hund.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_Hund.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_Ride
            // 
            this.pict_Ride.AccessibleName = "*";
            this.pict_Ride.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_Ride.Image = global::SoundCalculator.Properties.Resources.Ride;
            this.pict_Ride.Location = new System.Drawing.Point(143, 133);
            this.pict_Ride.Name = "pict_Ride";
            this.pict_Ride.Size = new System.Drawing.Size(41, 24);
            this.pict_Ride.TabIndex = 12;
            this.pict_Ride.TabStop = false;
            this.pict_Ride.Tag = "*";
            this.pict_Ride.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_Ride.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_Ride.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_6
            // 
            this.pict_6.AccessibleName = "6";
            this.pict_6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_6.Image = global::SoundCalculator.Properties.Resources._6;
            this.pict_6.Location = new System.Drawing.Point(99, 133);
            this.pict_6.Name = "pict_6";
            this.pict_6.Size = new System.Drawing.Size(41, 24);
            this.pict_6.TabIndex = 11;
            this.pict_6.TabStop = false;
            this.pict_6.Tag = "6";
            this.pict_6.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_6.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_6.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_5
            // 
            this.pict_5.AccessibleName = "5";
            this.pict_5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_5.Image = global::SoundCalculator.Properties.Resources._5;
            this.pict_5.Location = new System.Drawing.Point(54, 133);
            this.pict_5.Name = "pict_5";
            this.pict_5.Size = new System.Drawing.Size(41, 24);
            this.pict_5.TabIndex = 10;
            this.pict_5.TabStop = false;
            this.pict_5.Tag = "5";
            this.pict_5.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_5.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_5.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_4
            // 
            this.pict_4.AccessibleName = "4";
            this.pict_4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_4.Image = global::SoundCalculator.Properties.Resources._4;
            this.pict_4.Location = new System.Drawing.Point(8, 133);
            this.pict_4.Name = "pict_4";
            this.pict_4.Size = new System.Drawing.Size(41, 24);
            this.pict_4.TabIndex = 9;
            this.pict_4.TabStop = false;
            this.pict_4.Tag = "4";
            this.pict_4.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_4.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_4.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_Sqrt
            // 
            this.pict_Sqrt.AccessibleName = "Sqrt";
            this.pict_Sqrt.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_Sqrt.Image = global::SoundCalculator.Properties.Resources.sqrt;
            this.pict_Sqrt.Location = new System.Drawing.Point(188, 102);
            this.pict_Sqrt.Name = "pict_Sqrt";
            this.pict_Sqrt.Size = new System.Drawing.Size(41, 24);
            this.pict_Sqrt.TabIndex = 8;
            this.pict_Sqrt.TabStop = false;
            this.pict_Sqrt.Tag = "Sqrt";
            this.pict_Sqrt.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_Sqrt.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_Sqrt.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_Remove
            // 
            this.pict_Remove.AccessibleName = "/";
            this.pict_Remove.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_Remove.Image = global::SoundCalculator.Properties.Resources.Remove;
            this.pict_Remove.Location = new System.Drawing.Point(143, 102);
            this.pict_Remove.Name = "pict_Remove";
            this.pict_Remove.Size = new System.Drawing.Size(41, 24);
            this.pict_Remove.TabIndex = 7;
            this.pict_Remove.TabStop = false;
            this.pict_Remove.Tag = "/";
            this.pict_Remove.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_Remove.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_Remove.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_9
            // 
            this.pict_9.AccessibleName = "9";
            this.pict_9.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_9.Image = global::SoundCalculator.Properties.Resources._9;
            this.pict_9.Location = new System.Drawing.Point(99, 102);
            this.pict_9.Name = "pict_9";
            this.pict_9.Size = new System.Drawing.Size(41, 24);
            this.pict_9.TabIndex = 6;
            this.pict_9.TabStop = false;
            this.pict_9.Tag = "9";
            this.pict_9.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_9.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_9.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_8
            // 
            this.pict_8.AccessibleName = "8";
            this.pict_8.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_8.Image = global::SoundCalculator.Properties.Resources._8;
            this.pict_8.Location = new System.Drawing.Point(54, 102);
            this.pict_8.Name = "pict_8";
            this.pict_8.Size = new System.Drawing.Size(41, 24);
            this.pict_8.TabIndex = 5;
            this.pict_8.TabStop = false;
            this.pict_8.Tag = "8";
            this.pict_8.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_8.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_8.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_7
            // 
            this.pict_7.AccessibleName = "7";
            this.pict_7.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_7.Image = global::SoundCalculator.Properties.Resources._7;
            this.pict_7.Location = new System.Drawing.Point(9, 102);
            this.pict_7.Name = "pict_7";
            this.pict_7.Size = new System.Drawing.Size(41, 24);
            this.pict_7.TabIndex = 4;
            this.pict_7.TabStop = false;
            this.pict_7.Tag = "7";
            this.pict_7.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_7.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_7.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_C
            // 
            this.pict_C.AccessibleName = "C";
            this.pict_C.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_C.Image = global::SoundCalculator.Properties.Resources.c;
            this.pict_C.Location = new System.Drawing.Point(163, 72);
            this.pict_C.Name = "pict_C";
            this.pict_C.Size = new System.Drawing.Size(66, 24);
            this.pict_C.TabIndex = 3;
            this.pict_C.TabStop = false;
            this.pict_C.Tag = "C";
            this.pict_C.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_C.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_C.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_CE
            // 
            this.pict_CE.AccessibleName = "CE";
            this.pict_CE.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_CE.Image = global::SoundCalculator.Properties.Resources.ce;
            this.pict_CE.Location = new System.Drawing.Point(91, 72);
            this.pict_CE.Name = "pict_CE";
            this.pict_CE.Size = new System.Drawing.Size(66, 24);
            this.pict_CE.TabIndex = 2;
            this.pict_CE.TabStop = false;
            this.pict_CE.Tag = "CE";
            this.pict_CE.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_CE.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_CE.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // pict_Back
            // 
            this.pict_Back.AccessibleName = "Back";
            this.pict_Back.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pict_Back.Image = global::SoundCalculator.Properties.Resources.back;
            this.pict_Back.Location = new System.Drawing.Point(9, 72);
            this.pict_Back.Name = "pict_Back";
            this.pict_Back.Size = new System.Drawing.Size(75, 24);
            this.pict_Back.TabIndex = 1;
            this.pict_Back.TabStop = false;
            this.pict_Back.Tag = "Back";
            this.pict_Back.MouseLeave += new System.EventHandler(this.pict_Back_MouseLeave);
            this.pict_Back.Click += new System.EventHandler(this.pict_Back_Click);
            this.pict_Back.MouseEnter += new System.EventHandler(this.pict_Back_MouseEnter);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(18, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 231);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Dot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Bear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Deno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Decr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Hund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Ride)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Sqrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Remove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_C)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_CE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Back)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pict_Sqrt;
        private System.Windows.Forms.PictureBox pict_Remove;
        private System.Windows.Forms.PictureBox pict_9;
        private System.Windows.Forms.PictureBox pict_8;
        private System.Windows.Forms.PictureBox pict_7;
        private System.Windows.Forms.PictureBox pict_C;
        private System.Windows.Forms.PictureBox pict_CE;
        private System.Windows.Forms.PictureBox pict_Back;
        private System.Windows.Forms.PictureBox pict_Amount;
        private System.Windows.Forms.PictureBox pict_Add;
        private System.Windows.Forms.PictureBox pict_Dot;
        private System.Windows.Forms.PictureBox pict_Bear;
        private System.Windows.Forms.PictureBox pict_0;
        private System.Windows.Forms.PictureBox pict_Deno;
        private System.Windows.Forms.PictureBox pict_Decr;
        private System.Windows.Forms.PictureBox pict_3;
        private System.Windows.Forms.PictureBox pict_2;
        private System.Windows.Forms.PictureBox pict_1;
        private System.Windows.Forms.PictureBox pict_Hund;
        private System.Windows.Forms.PictureBox pict_Ride;
        private System.Windows.Forms.PictureBox pict_6;
        private System.Windows.Forms.PictureBox pict_5;
        private System.Windows.Forms.PictureBox pict_4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolS_Vox;
        private System.Windows.Forms.ToolStripMenuItem ToolS_Close;

    }
}

