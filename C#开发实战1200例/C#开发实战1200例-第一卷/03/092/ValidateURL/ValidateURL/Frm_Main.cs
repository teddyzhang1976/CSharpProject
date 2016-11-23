using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ValidateURL
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Validate_Click(object sender, EventArgs e)
        {
            if (!IsUrl(textBox1.Text))//验证网址格式是否正确
            { MessageBox.Show("网址格式不正确!!!"); }//弹出消息对话框
            else { MessageBox.Show("网址格式正确!!!!!"); }//弹出消息对话框
        }

        /// <summary>
        /// 验证网址格式是否正确
        /// </summary>
        /// <param name="str_url">网址字符串</param>
        /// <returns>方法返回布尔值</returns>
        public bool IsUrl(string str_url)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_url,//使用正则表达式判断是否匹配
@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
        }
    }
}