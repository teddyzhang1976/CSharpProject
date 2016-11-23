using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Transform
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            if (rbtn_object.Checked)//如果选择转换为object类型
            {
                using (FileStream P_filestream = //创建文件流对象
                    new FileStream(@"d:\log.txt", System.IO.FileMode.Create))
                {
                    object P_object = //使用as关键字转换类型
                        P_filestream as object;
                    if (P_object != null)//判断转换是否成功
                    {
                        MessageBox.Show("转换为Object成功！", "提示！");
                    }
                    else
                    {
                        MessageBox.Show("转换为Object不成功！", "提示！");
                    }
                }

            }
            if (rbtn_stream.Checked)//如果选择转换为stream类型
            {
                using (FileStream P_filestream =//创建文件流对象
                    new FileStream(@"d:\log.txt", System.IO.FileMode.Create))
                {
                    object P_obj = P_filestream;
                    Stream P_stream = //使用as关键字转换类型
                        P_obj as Stream;
                    if (P_stream != null)//判断转换是否成功
                    {
                        MessageBox.Show("转换为Stream成功！", "提示！");
                    }
                    else
                    {
                        MessageBox.Show("转换为Stream不成功！", "提示！");
                    }
                }
            }
            if (rbtn_string.Checked)//如果选择转换为string类型
            {
                using (FileStream P_filestream = //创建文件流对象
                    new FileStream(@"d:\log.txt", System.IO.FileMode.Create))
                {
                    object P_obj = P_filestream;
                    string P_str = //使用as关键字转换类型
                        P_obj as string;
                    if (P_str != null)//判断转换是否成功
                    {
                        MessageBox.Show("转换为string成功！", "提示！");
                    }
                    else
                    {
                        MessageBox.Show("转换为string不成功！", "提示！");
                    }
                }
            }
        }
    }
}
