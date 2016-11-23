using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GetCount
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_GetCount_Click(object sender, EventArgs e)
        {
            int P_scalar = 0;//定义值类型变量并赋值为0
            Regex P_regex = //创建正则表达式对象，用于判断字符是否为汉字
                new Regex("^[\u4E00-\u9FA5]{0,}$");
            for (int i = 0; i < txt_str.Text.Length; i++)//遍历字符串中每一个字符
            {
                P_scalar = //如果检查的字符是汉字则计数器加1
                    P_regex.IsMatch(txt_str.Text[i].
                    ToString()) ? ++P_scalar : P_scalar;
            }
            txt_count.Text = P_scalar.ToString();//显示汉字数量
        }
    }
}
