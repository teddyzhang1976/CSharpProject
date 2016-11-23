using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ReadUTF8File
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "文本文件(*.txt)|*.txt";
                openFileDialog1.ShowDialog();
                textBox1.Text = openFileDialog1.FileName;
                StreamReader SReader = File.OpenText(textBox1.Text);
                textBox2.Text = SReader.ReadToEnd();
            }
            catch { }
        }
    }
}
