using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace TypeOf
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            Type type = typeof(System.Int32);//获得int类型的Type对象
            foreach (MethodInfo method in type.GetMethods())//遍历string类中定义的所有公共方法
            {
                rtbox_text.AppendText(
                    "方法名称：" + method.Name + Environment.NewLine);//输出方法名称
                foreach (ParameterInfo parameter in method.GetParameters())//遍历公共方法中所有参数
                {
                    rtbox_text.AppendText(
                        "  参数：" + parameter.Name + Environment.NewLine);//输出参数名称
                }
            }
        }
    }
}
