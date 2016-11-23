using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ReadBinaryFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.bin|*.bin";
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("请选择文件");
                return;
            }

            textBox2.Text = string.Empty;
            try
            {
                FileStream myStream = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read);
                BinaryReader myReader = new BinaryReader(myStream);
                for (int i = 0; i < myStream.Length; i++)
                {
                    textBox2.Text += myReader.ReadInt32();
                }
                myReader.Close();
                myStream.Close();
            }
            catch { }
        }
    }
}
