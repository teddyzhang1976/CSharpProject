using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SaveToFile
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "*.txt|*.txt";//保存文件类型
            if (saveFileDialog1.ShowDialog()==DialogResult.OK)//判断是否选定文件
            {
                StreamWriter sw = new StreamWriter(//创建文件写入器
                    saveFileDialog1.FileName);
                sw.Write(txt_Message.Text);//向文件中写入文本信息
                sw.Close();//关闭文件流
            }
        }
    }
}
