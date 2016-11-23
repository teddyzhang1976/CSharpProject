using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lines
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_true_Click(object sender, EventArgs e)
        {
            StringBuilder P_stringbuilder = //创建字符串处理对象
                new StringBuilder(txt_string.Text);
            for (int i = 0; i < P_stringbuilder.Length; i++)//开始循环
                if (P_stringbuilder[i] == ',')//判断是否出现（,）号
                    P_stringbuilder.Insert(++i,//向字符串内添加换行符
                        Environment.NewLine);
            txt_Lines.Text = //得到分行后的字符串
                P_stringbuilder.ToString();
            bool P_bl = "abc" == "abc";
            MessageBox.Show(P_bl.ToString());
        }
    }
}
