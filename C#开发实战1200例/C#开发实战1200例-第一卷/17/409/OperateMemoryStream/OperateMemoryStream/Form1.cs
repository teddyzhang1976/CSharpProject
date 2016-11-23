using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OperateMemoryStream
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] BContent = Encoding.Default.GetBytes(textBox1.Text);
            MemoryStream MStream = new MemoryStream(100);
            MStream.Write(BContent, 0, BContent.Length);
            richTextBox1.Text = "分配给该流的字节数：" + MStream.Capacity.ToString() + "\n流长度："
                + MStream.Length.ToString() + "\n流的当前位置：" + MStream.Position.ToString();
            MStream.Seek(0, SeekOrigin.Begin);
            byte[] byteArray = new byte[MStream.Length];
            int count = MStream.Read(byteArray, 0, (int)MStream.Length - 1);
            while (count < MStream.Length)
            {
                byteArray[count++] = Convert.ToByte(MStream.ReadByte());
            }
            char[] charArray = new char[Encoding.Default.GetCharCount(byteArray, 0, count)];
            Encoding.Default.GetChars(byteArray, 0, count, charArray, 0);
            for (int i = 0; i < charArray.Length; i++)
            {
                richTextBox2.Text += charArray[i].ToString();
            }
        }
    }
}
