using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConvertToString
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Convert_Click(object sender, EventArgs e)
        {
            #region 针对Windows 7系统
            string s = string.Format("{0}/{1}/{2}",//得到日期字符串
                txt_Year.Text, txt_Month.Text, txt_Day.Text);
            DateTime P_dt = DateTime.ParseExact(//将字符串转换为日期格式
                s, "yyyy/MM/dd", null);
            #endregion
            //#region 针对Windows XP或者2003系统
            //string s = string.Format("{0}{1}{2}",//得到日期字符串
            //    txt_Year.Text, txt_Month.Text, txt_Day.Text);
            //DateTime P_dt = DateTime.ParseExact(//将字符串转换为日期格式
            //    s, "yyyyMMdd", null);
            //#endregion
            MessageBox.Show("输入的日期为： "//弹出消息对话框
                + P_dt.ToLongDateString(), "提示！");
        }
    }
}
