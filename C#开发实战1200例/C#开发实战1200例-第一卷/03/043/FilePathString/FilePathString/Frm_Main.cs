using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FilePathString
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Openfile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                string P_str_all = openFileDialog1.FileName;//记录选择的文件全路径
                string P_str_path = //获取文件路径
                    P_str_all.Substring(0, P_str_all.LastIndexOf("\\") + 1);
                string P_str_filename = //获取文件名
                    P_str_all.Substring(P_str_all.LastIndexOf("\\") + 1, 
                    P_str_all.LastIndexOf(".") - 
                    (P_str_all.LastIndexOf("\\")+1));
                string P_str_fileexc = //获取文件扩展名
                    P_str_all.Substring(P_str_all.LastIndexOf(".")+1,
                    P_str_all.Length - P_str_all.LastIndexOf(".")-1);
                lb_filepath.Text = "文件路径： " + P_str_path;//显示文件路径
                lb_filename.Text = "文件名称： " + P_str_filename;//显示文件名
                lb_fileexc.Text = "文件扩展名： " + P_str_fileexc;//显示扩展名
            }
        }

    }
}
