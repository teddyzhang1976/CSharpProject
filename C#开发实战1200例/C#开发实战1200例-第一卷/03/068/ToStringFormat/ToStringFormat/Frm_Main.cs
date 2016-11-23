using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToStringFormat
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            lb_Format.Text += Environment.NewLine;
            lb_Format.Text += Environment.NewLine;
            lb_Format.Text += Environment.NewLine;
            lb_Format.Text += string.Format("{0}",//使用指定日期格式化方式格式化字符串
                DateTime.Now.ToString("F"));
            lb_Format.Text += Environment.NewLine;
            lb_Format.Text += string.Format("{0}",//使用指定日期格式化方式格式化字符串
                DateTime.Now.ToString("f"));
            lb_Format.Text += Environment.NewLine;
            lb_Format.Text += string.Format("{0}",//使用指定日期格式化方式格式化字符串
                DateTime.Now.ToString("D"));
            lb_Format.Text += Environment.NewLine;
            lb_Format.Text += string.Format("{0}",//使用指定日期格式化方式格式化字符串
                DateTime.Now.ToString("d"));
            lb_Format.Text += Environment.NewLine;
            lb_Format.Text += string.Format("{0}",//使用指定日期格式化方式格式化字符串
                DateTime.Now.ToString("G"));
            lb_Format.Text += Environment.NewLine;
            lb_Format.Text += string.Format("{0}",//使用指定日期格式化方式格式化字符串
                DateTime.Now.ToString("g"));
            lb_Format.Text += Environment.NewLine;
            lb_Format.Text += string.Format("{0}",//使用指定日期格式化方式格式化字符串
                DateTime.Now.ToString("yyyy-MM-dd hh:ss:ff"));
        }
    }
}
