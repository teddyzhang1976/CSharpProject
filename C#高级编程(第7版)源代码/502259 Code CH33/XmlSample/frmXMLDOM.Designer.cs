namespace XmlSample
{
  partial class frmXMLDOM
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
        this.button1 = new System.Windows.Forms.Button();
        this.button2 = new System.Windows.Forms.Button();
        this.button4 = new System.Windows.Forms.Button();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(298, 35);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(134, 23);
        this.button1.TabIndex = 0;
        this.button1.Text = "GetElementsByTagName";
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // button2
        // 
        this.button2.Location = new System.Drawing.Point(298, 73);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(134, 23);
        this.button2.TabIndex = 2;
        this.button2.Text = "SelectNodes";
        this.button2.Click += new System.EventHandler(this.button2_Click);
        // 
        // button4
        // 
        this.button4.Location = new System.Drawing.Point(298, 116);
        this.button4.Name = "button4";
        this.button4.Size = new System.Drawing.Size(134, 23);
        this.button4.TabIndex = 4;
        this.button4.Text = "Add New Element";
        this.button4.Click += new System.EventHandler(this.button4_Click);
        // 
        // textBox1
        // 
        this.textBox1.Location = new System.Drawing.Point(12, 34);
        this.textBox1.Multiline = true;
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(257, 179);
        this.textBox1.TabIndex = 5;
        // 
        // frmXMLDOM
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(451, 234);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.button4);
        this.Controls.Add(this.button2);
        this.Controls.Add(this.button1);
        this.Name = "frmXMLDOM";
        this.Text = "frmXMLDOM";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.TextBox textBox1;
  }
}