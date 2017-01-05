using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
namespace WoYingFinaceService
{
    public delegate void OnProgressEventHandler(ProgressBar sender, long mini, long max, long value);
    public delegate void SetTextCallback(TextBox label, string text);
    public partial class ServiceForm : Form
    {

        public void SetDataToPM()
        {
            while (true)
            {
                try
                {

                    DateTime DT = DateTime.Now;
                    string xqj = DT.DayOfWeek.ToString();

                    if (xqj == "Saturday")
                    {
                        SetThreadText(Logtxt, "\r\n今日星期六，不进行制作分时走势 " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        Thread.Sleep(30000);
                    }
                    if (xqj == "Sunday")
                    {
                        SetThreadText(Logtxt, "\r\n今日星期日，不进行制作分时走势 " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        Thread.Sleep(30000);
                    }
                    if ((xqj != "Sunday") && (xqj != "Saturday"))
                    {
                        DateTime NowTime = DateTime.Parse(DateTime.Now.TimeOfDay.ToString());
                         DateTime ErTopTime = DateTime.Parse("09:05:00");
                        DateTime TopTime = DateTime.Parse("09:25:00");
                        DateTime BottomTime = DateTime.Parse("15:05:00");
                        if (ErTopTime < NowTime && NowTime < TopTime)
                        {
                            GetReatNowPrice.InitDataBase();//初始化分时走势
                            string Title = "初始化分时走势成功" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
                            if (Logtxt.Text.Length > 32767)
                            {
                                Logtxt.Text = "";
                            }
                            SetThreadText(Logtxt, Title + Logtxt.Text);
                        }
                        if (TopTime < NowTime && NowTime < BottomTime)
                        {

                            GetReatNowPrice.GetStockInfo();
                            string Title = "制作分时走势成功" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
                            if (Logtxt.Text.Length > 32767)
                            {
                                Logtxt.Text = "";
                            }
                            SetThreadText(Logtxt, Title + Logtxt.Text);
                            Thread.Sleep(int.Parse(textBox2.Text));
                        }
                        else
                        {
                            Thread.Sleep(30000);
                            SetThreadText(Logtxt, "收盘时间，不制作分时走势!" + Logtxt.Text);
                        }
                    }

                }
                catch (Exception exp)
                {

                }
            
            }
        }
        /// <summary>
        /// 跨线程调用控件
        /// </summary>
        /// <param name="label">Label控件</param>
        /// <param name="text">准备赋的值</param>
        private void SetThreadText(TextBox label, string text)
        {
            if (label.InvokeRequired)
            {
                SetTextCallback method = new SetTextCallback(this.SetThreadText);
                base.Invoke(method, new object[] { label, text });
            }
            else
            {
                label.Text = text;
            }
        }
        public ServiceForm()
        {
            InitializeComponent();
        }
  
        private void button1_Click(object sender, EventArgs e)
        {
            textBoxfilepath.Text = @"F:\公司项目\我赢网v2_1\软件客户端\看盘软件\WYStockRealView\WoYingRealTimeInterFace\App_Data\RealTimeLine\";
        }
        private void MakeTest_Click(object sender, EventArgs e)
        {
            long sl = DateTime.Now.Ticks;
            GetReatNowPrice.GetStockInfo();
            MessageBox.Show("已经完成"+TimeSpan.FromTicks(DateTime.Now.Ticks-sl).ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetReatNowPrice.InitDataBase();
            MessageBox.Show("已经完成");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlHelper.SqlConnStringZX = textBox1.Text;
            CommonSetting.RemotePath = textBoxfilepath.Text;
            AddtoSet();
            MessageBox.Show("保存成功!");
        }
        Thread th = null;
        private void button1_Click_1(object sender, EventArgs e)
        {
            th = new Thread(new ThreadStart(SetDataToPM));
            th.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            th.Abort();
            MessageBox.Show("已经停止");
        }

        private void ServiceForm_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            try
            {
                ReadtoSet();
            }
            catch { }
        }
        public void AddtoSet()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Setting.ini";
            if (!File.Exists(filePath))
            {
                FileStream fs = File.Create(filePath);
                fs.Close();
            }
            StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8);
            sw.WriteLine(textBox1.Text);
            sw.WriteLine(textBoxfilepath.Text);
            sw.WriteLine(textBox2.Text);
            sw.Close();

        }
        public void ReadtoSet()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Setting.ini";
            if (!File.Exists(filePath))
            {
                FileStream fs = File.Create(filePath);
                fs.Close();
            }
            StreamReader sw = new StreamReader(filePath,  Encoding.UTF8);
            textBox1.Text = sw.ReadLine();
            textBoxfilepath.Text = sw.ReadLine();
            textBox2.Text = sw.ReadLine();
            sw.Close();

        }
    }
}