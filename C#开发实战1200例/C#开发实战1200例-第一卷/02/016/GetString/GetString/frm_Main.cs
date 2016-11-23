using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetString
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Get_Click(object sender, EventArgs e)
        {
            string str = "\"";//定义字符串变量str并赋值为引号
            string P_strOne, P_strTwo, P_strThree;//定义三个字符串变量
            P_strOne = "Hello,\"C#\";";//为第一个字符串变量赋值
            P_strTwo = "Hello," + '\u0022' + "C#" + '\u0022' + ";";//为第二个字符串变量赋值
            P_strThree = "Hello," + str + "C#" + str + ";";//为第三个字符串变量赋值
            MessageBox.Show(//在消息提示框中输出三个字符串
                P_strOne + "     " + P_strTwo + "     " + P_strThree);
        }
    }
}
