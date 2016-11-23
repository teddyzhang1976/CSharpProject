using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UTF8File
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = saveFileDialog1.FileName;
            }
            else
            {
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text.Trim()))//若文件路径为空
            {
                MessageBox.Show("请设置文件路径！");
                return;
            }

            if (String.IsNullOrEmpty(textBox2.Text.Trim()))//若文本内容为空
            {
                MessageBox.Show("请输入文件内容！");
                return;
            }

            if (!File.Exists(textBox1.Text))
            {
                using (StreamWriter sw = File.CreateText(textBox1.Text))//创建或打开一个文件用于写入 UTF-8 编码的文本。
                {
                    sw.WriteLine(textBox2.Text);//把字符串写入文本流
                    MessageBox.Show("文件创建成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("该文件已经存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
