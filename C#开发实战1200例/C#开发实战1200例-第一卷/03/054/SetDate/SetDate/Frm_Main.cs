using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SetDate
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public class SetSystemDateTime//设置系统日期类
        {
            [DllImportAttribute("Kernel32.dll")]
            public static extern void GetLocalTime(SystemTime st);
            [DllImportAttribute("Kernel32.dll")]
            public static extern void SetLocalTime(SystemTime st);
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public class SystemTime//系统时间类
        {
            public ushort vYear;//年
            public ushort vMonth;//月
            public ushort vDayOfWeek;//星期
            public ushort vDay;//日
            public ushort vHour;//小时
            public ushort vMinute;//分
            public ushort vSecond;//秒
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = DateTime.Now.ToString("F") +//得到系统时间
                "  " + DateTime.Now.ToString("dddd");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您真的确定更改系统当前日期吗？",//设置系统当前日期时间
                "信息提示", MessageBoxButtons.OK) == DialogResult.OK)
            {
                DateTime Year = this.dateTimePicker1.Value;//得到时间信息
                SystemTime MySystemTime = new SystemTime();//创建系统时间类的对象
                SetSystemDateTime.GetLocalTime(MySystemTime);//得到系统时间
                MySystemTime.vYear = (ushort)this.dateTimePicker1.Value.Year;//设置年
                MySystemTime.vMonth = (ushort)this.dateTimePicker1.Value.Month;//设置月
                MySystemTime.vDay = (ushort)this.dateTimePicker1.Value.Day;//设置日
                MySystemTime.vHour = (ushort)this.dateTimePicker2.Value.Hour;//设置小时
                MySystemTime.vMinute = (ushort)this.dateTimePicker2.Value.Minute;//设置分
                MySystemTime.vSecond = (ushort)this.dateTimePicker2.Value.Second;//设置秒
                SetSystemDateTime.SetLocalTime(MySystemTime);//设置系统时间
                button1_Click(null, null);//执行按钮点击事件
            }
        }
    }
}