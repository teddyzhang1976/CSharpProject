using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace SetTime
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        //api函数声明   
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        public extern static bool SetSystemTime(ref SYSTEMTIME time); 
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public short Year;
            public short Month;
            public short DayOfWeek;
            public short Day;
            public short Hour;
            public short Minute;
            public short Second;
            public short Miliseconds;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblNowTime.Text = DateTime.Now.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblNowTime.Text = DateTime.Now.ToString();
            Microsoft.Win32.SystemEvents.TimeChanged+=new EventHandler(SystemEvents_TimeChanged);
        }

        private void SystemEvents_TimeChanged(object sender, EventArgs e)
        {
            MessageBox.Show("系统日期修改成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mYear = monthCalendar1.SelectionRange.Start.Year;
            mMonth = monthCalendar1.SelectionRange.Start.Month;
            mDay = monthCalendar1.SelectionRange.Start.Day;
            //调用代码   
            SYSTEMTIME t = new SYSTEMTIME();
            t.Year = (short)mYear;
            t.Month = (short)mMonth;
            t.Day = (short)mDay;
            t.Hour = (short)(dateTimePicker1.Value.Hour - 8);//这个函数使用的是0时区的时间,例如，要设12点，则为12-8   
            t.Minute = (short)dateTimePicker1.Value.Minute;
            t.Second = (short)dateTimePicker1.Value.Second;
            bool v = SetSystemTime(ref t);   
        }
        int mYear;
        int mDay;
        int mMonth;
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            mYear = e.Start.Year;
            mMonth = e.Start.Month;
            mDay =e.Start.Day;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
