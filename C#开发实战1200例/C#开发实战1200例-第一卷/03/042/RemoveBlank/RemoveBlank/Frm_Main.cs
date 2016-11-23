using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace RemoveBlank
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_RemoveBlank_Click(object sender, EventArgs e)
        {
            char[] P_chr = txt_str.Text.ToCharArray();//得到字符数组
            IEnumerator P_ienumerator_chr = //得到枚举器
                P_chr.GetEnumerator();
            StringBuilder P_stringbuilder = //创建stringbuilder对象
                new StringBuilder();
            while (P_ienumerator_chr.MoveNext())//开始枚举
            {
                P_stringbuilder.Append(//向stringbuilder对象中添加非空格字符
                    (char)P_ienumerator_chr.Current != ' ' ?
                    P_ienumerator_chr.Current.ToString() : string.Empty);
            }
            txt_removeblank.Text = //得到没有空格的字符串
                P_stringbuilder.ToString();
        }
    }
}
