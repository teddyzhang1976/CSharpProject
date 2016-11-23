using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace ValidateIP
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            if (IPCheck(textBox1.Text))//验证IP是否正确
            {
                MessageBox.Show("输入ＩＰ正确");//弹出消息对话框
            }
            else { MessageBox.Show("输入ＩＰ不正确"); }//弹出消息对话框
        }

        /// <summary>
        /// 验证IP是否正确
        /// </summary>
        /// <param name="IP">IP地址字符串</param>
        /// <returns>方法返回布尔值</returns>
        public bool IPCheck(string IP)
        {
            string num = "(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)";//创建正则表达式字符串
            return Regex.IsMatch(IP,//使用正则表达式判断是否匹配
                ("^" + num + "\\." + num + "\\." + num + "\\." + num + "$"));
        }
    }
}