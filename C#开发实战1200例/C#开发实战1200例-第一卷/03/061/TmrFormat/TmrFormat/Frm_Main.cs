using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TmrFormat
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_GetTime_Click(object sender, EventArgs e)
        {
            lab_time.Text =
                DateTime.Now.ToString("d") + "\n" +//使用指定格式的字符串变量格式化日期字符串
                DateTime.Now.ToString("D") + "\n" +
                DateTime.Now.ToString("f") + "\n" +
                DateTime.Now.ToString("F") + "\n" +
                DateTime.Now.ToString("g") + "\n" +
                DateTime.Now.ToString("G") + "\n" +
                DateTime.Now.ToString("R") + "\n" +
                DateTime.Now.ToString("y") + "\n" +
                "当前系统时间为："+DateTime.Now.ToString(//使用自定义格式格式化字符串
                "yyyy年MM月dd日 HH时mm分ss秒");
        }
    }
}
