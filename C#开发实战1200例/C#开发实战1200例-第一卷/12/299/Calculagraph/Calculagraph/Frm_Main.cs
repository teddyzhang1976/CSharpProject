using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace Calculagraph
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public int intHour, intMouit, intSecon;//定义整型字段
        private void Form1_Load(object sender, EventArgs e)
        {
            string strHour = DateTime.Now.TimeOfDay.Hours.ToString();//得到小时数
            string strMouit = DateTime.Now.TimeOfDay.Minutes.ToString();//得到分钟数
            string strSecon = DateTime.Now.TimeOfDay.Seconds.ToString();//得到秒数
            if (Convert.ToInt32(strHour) < 10)
            {
                strHour = "0" + strHour;//如果小于10则补0
            }
            if (Convert.ToInt32(strMouit) < 10)
            {
                strMouit = "0" + strMouit;//如果小于10则补0
            }
            if (Convert.ToInt32(strSecon) < 10)
            {
                strSecon = "0" + strSecon;//如果小于10则补0
            }
            textBox2.Text = strHour + ":" + strMouit + ":" + strSecon;//显时间信息
            intHour = Convert.ToInt32(strHour);//将小时数转换为整型
            intMouit = Convert.ToInt32(strMouit);//将分钟数转换为整型
            intSecon = Convert.ToInt32(strSecon);//将秒数转换为整型
            numericUpDown3.Value = Convert.ToInt32(strHour);//显示小时数
            numericUpDown2.Value = Convert.ToInt32(strMouit);//显示分钟数
            numericUpDown1.Value = Convert.ToInt32(strSecon);//显示秒数
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string strHour = DateTime.Now.TimeOfDay.Hours.ToString();//得到系统时间小时数
            string strMouit = DateTime.Now.TimeOfDay.Minutes.ToString();//得到系统时间分种数
            string strSecon = DateTime.Now.TimeOfDay.Seconds.ToString();//得到系统时间秒数
            if (Convert.ToInt32(strHour) < 10)
            {
                strHour = "0" + strHour;//如果小于10则补0
            }
            if (Convert.ToInt32(strMouit) < 10)
            {
                strMouit = "0" + strMouit;//如果小于10则补0
            }
            if (Convert.ToInt32(strSecon) < 10)
            {
                strSecon = "0" + strSecon;//如果小于10则补0
            }
            textBox1.Text = //显示系统当前时间
                strHour + ":" + strMouit + ":" + strSecon;
        }

        //设置小时
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            string Hour, Minute, second;//字符串变量
            if (numericUpDown1.Value == 60)
            {
                numericUpDown1.Value = 0;
                numericUpDown2.Value = Convert.ToInt32(numericUpDown2.Value) + 1;
                intMouit = Convert.ToInt32(numericUpDown2.Value);
                intSecon = Convert.ToInt32(numericUpDown1.Value);
                if (Convert.ToInt32(intHour) < 10)
                {
                    Hour = "0" + intHour.ToString() + ":";
                }
                else
                {
                    Hour = intHour.ToString() + ":";
                }
                if (Convert.ToInt32(intMouit) < 10)
                {
                    Minute = "0" + intMouit.ToString() + ":";
                }
                else
                {
                    Minute = intMouit.ToString() + ":";
                }
                if (Convert.ToInt32(intSecon) < 10)
                {
                    second = "0" + intSecon.ToString();
                }
                else
                {
                    second = intSecon.ToString();
                }
                textBox2.Text = Hour + Minute + second;
            }
            else
            {

                intSecon = Convert.ToInt32(numericUpDown1.Value);
                if (Convert.ToInt32(intHour) < 10)
                {
                    Hour = "0" + intHour.ToString() + ":";
                }
                else
                {
                    Hour = intHour.ToString() + ":";
                }
                if (Convert.ToInt32(intMouit) < 10)
                {
                    Minute = "0" + intMouit.ToString() + ":";
                }
                else
                {
                    Minute = intMouit.ToString() + ":";
                }
                if (Convert.ToInt32(intSecon) < 10)
                {
                    second = "0" + intSecon.ToString();
                }
                else
                {
                    second = intSecon.ToString();
                }
                textBox2.Text = Hour + Minute + second;


            }
        }/////////
        //设置分
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            string Hour, Minute, second;
            if (numericUpDown2.Value == 60)
            {
                numericUpDown2.Value = 0;
                numericUpDown3.Value = Convert.ToInt32(numericUpDown2.Value) + 1;
                intMouit = Convert.ToInt32(numericUpDown2.Value);
                intHour = Convert.ToInt32(numericUpDown3.Value);
                if (Convert.ToInt32(intHour) < 10)
                {
                    Hour = "0" + intHour.ToString() + ":";
                }
                else
                {
                    Hour = intHour.ToString() + ":";
                }
                if (Convert.ToInt32(intMouit) < 10)
                {
                    Minute = "0" + intMouit.ToString() + ":";
                }
                else
                {
                    Minute = intMouit.ToString() + ":";
                }
                if (Convert.ToInt32(intSecon) < 10)
                {
                    second = "0" + intSecon.ToString();
                }
                else
                {
                    second = intSecon.ToString();
                }
                textBox2.Text = Hour + Minute + second;
            }
            else
            {
                intMouit = Convert.ToInt32(numericUpDown2.Value);
                if (Convert.ToInt32(intHour) < 10)
                {
                    Hour = "0" + intHour.ToString() + ":";
                }
                else
                {
                    Hour = intHour.ToString() + ":";
                }
                if (Convert.ToInt32(intMouit) < 10)
                {
                    Minute = "0" + intMouit.ToString() + ":";
                }
                else
                {
                    Minute = intMouit.ToString() + ":";
                }
                if (Convert.ToInt32(intSecon) < 10)
                {
                    second = "0" + intSecon.ToString();
                }
                else
                {
                    second = intSecon.ToString();
                }
                textBox2.Text = Hour + Minute + second;

            }
        }///
        //设置秒
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            string Hour, Minute, second;
            if (numericUpDown3.Value == 24)
            {
                numericUpDown3.Value = 0;
                intHour = Convert.ToInt32(numericUpDown3.Value);
                if (Convert.ToInt32(intHour) < 10)
                {
                    Hour = "0" + intHour.ToString() + ":";
                }
                else
                {
                    Hour = intHour.ToString() + ":";
                }
                if (Convert.ToInt32(intMouit) < 10)
                {
                    Minute = "0" + intMouit.ToString() + ":";
                }
                else
                {
                    Minute = intMouit.ToString() + ":";
                }
                if (Convert.ToInt32(intSecon) < 10)
                {
                    second = "0" + intSecon.ToString();
                }
                else
                {
                    second = intSecon.ToString();
                }
                textBox2.Text = Hour + Minute + second;
            }
            else
            {
                intHour = Convert.ToInt32(numericUpDown3.Value);
                if (Convert.ToInt32(intHour) < 10)
                {
                    Hour = "0" + intHour.ToString() + ":";
                }
                else
                {
                    Hour = intHour.ToString() + ":";
                }
                if (Convert.ToInt32(intMouit) < 10)
                {
                    Minute = "0" + intMouit.ToString() + ":";
                }
                else
                {
                    Minute = intMouit.ToString() + ":";
                }
                if (Convert.ToInt32(intSecon) < 10)
                {
                    second = "0" + intSecon.ToString();
                }
                else
                {
                    second = intSecon.ToString();
                }
                textBox2.Text = Hour + Minute + second;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime get_time1 = DateTime.Now;//得到系统当前时间
            DateTime sta_ontime1 = Convert.ToDateTime(//获取定时信息
                Convert.ToDateTime(textBox2.Text.Trim().ToString()));
            long dat = DateAndTime.DateDiff(//计算两个时间间隔的秒数
                "s", get_time1, sta_ontime1,
                FirstDayOfWeek.Sunday,
                FirstWeekOfYear.FirstFourDays);
            if (dat > 0)//如果时间间隔大于0秒
            {
                if (timer2.Enabled != true)
                {
                    timer2.Enabled = true;//开始计时
                    label4.Text = "闹钟已启动";//显示操作信息
                    label1.Text = "剩余" + dat.ToString() + "秒";//显示剩余时间
                }
                else
                {
                    MessageBox.Show(//弹出消息对话框
                        "时钟已经启动，请取消后，在启动");
                }
            }
            else
            {
                long hour = 24 * 3600 + dat;//计算到下一天的这个时间的秒数
                timer2.Enabled = true;//开始计时
                label4.Text = "闹钟已启动";//显示操作信息
                label1.Text = "乘余" + hour.ToString() + "秒";//显示剩余时间
            }
        }
        //计时
        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime get_time1 = Convert.ToDateTime(//获取系统时间
                DateTime.Now.ToString());
            DateTime sta_ontime1 = Convert.ToDateTime(//获取定时信息
                Convert.ToDateTime(textBox2.Text.Trim().
                ToString()));
            long dat = DateAndTime.DateDiff("s", //得到时间间隔
                get_time1, sta_ontime1, FirstDayOfWeek.Sunday,
                FirstWeekOfYear.FirstFourDays);
            if (dat == 0)//如果时间间隔为0
            {
                Console.Beep(200, 500);//扬声器发声
                label4.Text = "时间已到";//显示提示信息
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;//取消计时器
            label4.Text = "闹钟已取消";//显示提示信息
            label1.Text = "";//取消显示剩余时间
        }
    }
}