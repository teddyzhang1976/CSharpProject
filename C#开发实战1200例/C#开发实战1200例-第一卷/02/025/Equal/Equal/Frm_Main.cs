using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Equal
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            object P_obj = rbtn_target1.Checked ? //正确的为变量添加引用
                (object)"C# 编程词典" : new System.IO.FileInfo(@"d:\");
            if (rbtn_class1.Checked)//判断选择了哪一个类型
            {
                if (P_obj is System.String)//判断对象是否为字符串类型
                    MessageBox.Show(//提示兼容信息
                        "对象与指定类型兼容", "提示！");
                else
                    MessageBox.Show(//提示不兼容信息
                        "对象与指定类型不兼容","提示！");
            }
            else
            {
                if (P_obj is System.IO.FileInfo)//判断对象是否为文件类型
                    MessageBox.Show(//提示兼容信息
                        "对象与指定类型兼容", "提示！");
                else
                    MessageBox.Show(//提示不兼容信息
                        "对象与指定类型不兼容", "提示！");
            }
        }
    }
}
