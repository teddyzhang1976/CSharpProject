using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using ImageOfStock;
using System.Drawing.Drawing2D;
using System.Net;
namespace StockMonitor.Forms
{
    public partial class TestTimeLineStockForm : Form
    {
        public TestTimeLineStockForm()
        {
            InitializeComponent();
            CandleGraph();
        }


        public string stockcode = "sn000012";
        public string GetValueURL = "http://www.iwind.com.cn/iwind/RealTimeList/GetPriceList.ashx?stockcode=";
        public DataTable DTimeLine = new DataTable();
        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockCodeIn(string StockCode)
        {
           
                List<string[]> list = new List<string[]>();
  
                CandleGraph();
                this.chartGraph1.ProcessBarValue = 0;     
                Thread refreshData = new Thread(new ParameterizedThreadStart(UpdateDataToGraph));
                refreshData.IsBackground = true;
                refreshData.Start(list);
        
        }

        public void CandleGraph()
        {
            this.chartGraph1.ResetNullGraph();
            this.chartGraph1.UseScrollAddSpeed = true;
            this.chartGraph1.SetXScaleField("日期");
            this.chartGraph1.CanDragSeries = true;
            this.chartGraph1.SetSrollStep(10, 10);
            this.chartGraph1.ShowLeftScale = true;
            this.chartGraph1.ShowRightScale = true;
            this.chartGraph1.LeftPixSpace = 85;
            this.chartGraph1.RightPixSpace = 85;

            ////K线图+BS点
            string candleName = "分时走势";
            mainPanelID = this.chartGraph1.AddChartPanel(70);
            this.chartGraph1.AddTrendLine("均价", "均价", mainPanelID);
            this.chartGraph1.SetTrendLineStyle("均价", Color.Yellow, Color.Yellow, 1, DashStyle.Solid);
            this.chartGraph1.AddTrendLine("最新价格", "最新价格", mainPanelID);
            this.chartGraph1.SetTrendLineStyle("最新价格", Color.White, Color.White, 1, DashStyle.Solid);  
            
            //成交量
            volumePanelID = this.chartGraph1.AddChartPanel(30);
            this.chartGraph1.AddHistogram("成交量", "成交量", candleName, volumePanelID);
            this.chartGraph1.SetHistogramStyle("成交量", Color.Red, Color.SkyBlue, 1, false);
            this.chartGraph1.AddVolCandle(candleName, "最新价格", "成交额", "涨跌", "均价", volumePanelID, true);
            this.chartGraph1.SetTick(volumePanelID, 1);
            this.chartGraph1.SetDigit(volumePanelID, 0);

            //open 最新价格
            //high 成交额
            //low 涨跌
            //close 均价
     
        }

        //定义四个Panel作为例子
        int mainPanelID = -1;
        int volumePanelID = -1;
        int kdjPanelID = -1;
        int macdPanelID = -1;
        

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomForm_Load(object sender, EventArgs e)
        {
            this.Text = "我赢财富终端";
            this.Location = new Point(0, 0);
            this.Size = new Size(Screen.GetWorkingArea(this).Width, Screen.GetWorkingArea(this).Height);
            CandleGraph();
        }

        /// <summary>
        /// 更新进度条
        /// </summary>
        /// <param name="obj"></param>
        public void UpdateProcessBar(object obj)
        {
            int[] values = obj as int[];
            int total = values[0];
            int current = values[1];
            int processValue = Convert.ToInt32((double)current / (double)total * 100);
            if (processValue > this.chartGraph1.ProcessBarValue)
            {
                this.chartGraph1.ProcessBarValue = processValue;
            }
            if (current == total - 2)
            {
                this.chartGraph1.ProcessBarValue = 100;
   
                this.chartGraph1.RefreshGraph();
            }
        }

        private delegate void UpdateProcessBarDelegate(object obj);

        /// <summary>
        /// 更新数据到图像
        /// </summary>
        /// <param name="obj"></param>
        public void UpdateDataToGraph(object obj)
        {
    
            this.chartGraph1.SetTitle(mainPanelID, "000012 (南 玻A) 分时走势");

                this.chartGraph1.SetTitle(volumePanelID, "成交量");
                    this.chartGraph1.SetIntervalType(mainPanelID, ChartGraph.IntervalType.Minute);
                    this.chartGraph1.SetIntervalType(volumePanelID, ChartGraph.IntervalType.Minute);
                    this.chartGraph1.RefreshGraph();
           // int i = 0;
       
            //foreach (MyValue MV in MyList)
            //{
            //    i++;
            //    DateTime dt = DateTime.Parse(MV.Time);
            //    double one = RadomName();
            //    this.chartGraph1.SetValue("OPEN", one, dt);
            //    this.chartGraph1.SetValue("HIGH", one, dt);
            //    this.chartGraph1.SetValue("LOW", one, dt);
            //    this.chartGraph1.SetValue("CLOSE", one, dt);
            //    this.chartGraph1.SetValue("VOL", RadomName(), dt);
            //    this.BeginInvoke(new UpdateProcessBarDelegate(UpdateProcessBar), new int[] { MyList.Count, MyList.Count - i });
            //}
                    SetLower();
            for (int i = MyList.Count - 1; i >= 2; i--)
            {
                double one = RadomName();
                DateTime dt = DateTime.Parse(MyList[i].Time.ToString());
                this.chartGraph1.SetValue("最新价格", one, dt);// double.Parse(MyList[i].Value)+0.1, dt);
                this.chartGraph1.SetValue("成交额", one, dt);// MyList[i].Value, dt);
                this.chartGraph1.SetValue("涨跌", one, dt);//MyList[i].Value, dt);
                this.chartGraph1.SetValue("均价", RadomName(), dt);//MyList[i].Value, dt);
                this.chartGraph1.SetValue("成交量", RadomName(), dt);
                this.BeginInvoke(new UpdateProcessBarDelegate(UpdateProcessBar), new int[] { MyList.Count, MyList.Count - i });
            }
       
            this.chartGraph1.Enabled = true;
        }
        /// <summary>
        /// 随机起名
        /// </summary>
        /// <returns></returns>
        public static double RadomName()
        {
            Random rdm = new Random();
            string UserIDStr = "13.";
            for (int i = 1; i <= 2; i++)
            {
                UserIDStr += rdm.Next(1, 9).ToString();
            }
            return double.Parse(UserIDStr);
        }
        List<MyValue> MyList = new List<MyValue>();
        /// <summary>
        /// 发送信息
        /// </summary>
        public string WebBack(string stockcode)
        {
            try
            {
                string url = GetValueURL + stockcode;
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Method = "GET";
                req.KeepAlive = true;
                using (WebResponse wr = req.GetResponse())
                {

                    StreamReader reader = new StreamReader(wr.GetResponseStream(), Encoding.UTF8);
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
            catch (Exception expp)
            {
                return expp.Message;
            }
        }
        /// <summary>
        /// 更新列表
        /// </summary>
        /// <param name="Time"></param>
        /// <param name="Value"></param>
        private void UpdateMyList(string Time,string Value,string VOL)
        {
           string BJ=DateTime.Parse(Time).ToString("HHmm");
            foreach (MyValue MV in MyList)
            { 
                 if(BJ==DateTime.Parse(MV.Time).ToString("HHmm"))
                 {
                     MV.Value = Value;
                     MV.VOL = VOL;
                     break;
                 }
            }
        }
        public string GetInfoValueURL = "http://www.iwind.com.cn/iwind/RealTimeList/GetNowPrice.ashx?stockcode=";
        /// <summary>
        /// 发送信息
        /// </summary>
        public string WebInfoBack(string stockcode)
        {
            try
            {
                string url = GetInfoValueURL + stockcode;
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Method = "GET";
                req.KeepAlive = true;
                using (WebResponse wr = req.GetResponse())
                {

                    StreamReader reader = new StreamReader(wr.GetResponseStream(), Encoding.UTF8);
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
            catch (Exception expp)
            {
                return expp.Message;
            }
        }
        /// <summary>
        /// 设置区间最小值
        /// </summary>
        public void SetLower()
        {
            string[] RtStr = WebInfoBack(stockcode).Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            string MinLow = RtStr[9];
            string MxH = RtStr[8];

            foreach (MyValue MV in MyList)
            {
                if (DateTime.Parse(MV.Time).ToString("HHmm") == "1401")
                {
                    MV.Value = MxH; 
                }
                if (MV.Value=="0")
                {
                    MV.Value = MinLow;               
                }
            }
     
        }

        private void Test_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            DateTime time1 = DateTime.Parse("09:28:00");
            DateTime time2 = DateTime.Parse("11:30:00");
            while (time1 <= time2)
            {
                MyValue MV = new MyValue();
                MV.Time = time1.ToString("HH:mm:ss");
                MyList.Add(MV);
                time1 = time1.AddMinutes(1);
            }
            DateTime time3 = DateTime.Parse("13:00:00");
            DateTime time4 = DateTime.Parse("15:00:00");
            while (time3 <= time4)
            {
                MyValue MV = new MyValue();
                MV.Time = time3.ToString("HH:mm:ss");
                MyList.Add(MV);
                time3 = time3.AddMinutes(1);
            }


            DTimeLine = new DataTable();
            DTimeLine.Columns.Add("CJJ");
            DTimeLine.Columns.Add("KPJ");
            DTimeLine.Columns.Add("MRJ");
            DTimeLine.Columns.Add("MCJ");
            DTimeLine.Columns.Add("MRL");
            DTimeLine.Columns.Add("MCL");
            DTimeLine.Columns.Add("GPDM");
            DTimeLine.Columns.Add("BS");
            DTimeLine.Columns.Add("JLSJ");
            string MyCodeStr = WebBack(stockcode);
            string[] SpCode=MyCodeStr.Split(new string[]{","},StringSplitOptions.RemoveEmptyEntries);
            object[] myrow=new object[9];
            int arr = 0;
            for (int i = 0; i < SpCode.Length; i++)
            {
                if ((i + 1) %9 == 0)
                {              
                    myrow[arr] = SpCode[i];
                    arr = 0;

                    #region 赋值
                    string VOL = "";
                    if (SpCode[i - 8] == SpCode[i - 6])//如果为买入价格
                    {
                        VOL = SpCode[i - 4];//反馈为买入量
                    }
                    else
                    {
                        VOL = SpCode[i - 3];//反馈为卖出量   
                    }
                    UpdateMyList(SpCode[i], SpCode[i - 8], VOL);
                    #endregion
                    DTimeLine.Rows.Add(myrow);
                }
                else
                {
                    myrow[arr] = SpCode[i];
                    arr++;
                }
            }
          dataGridView1.DataSource = DTimeLine;
         StockCodeIn("000002");
     

      

        }

        private void Test2_Click(object sender, EventArgs e)
        {
            this.chartGraph1.LastVisibleRecord = 239;
            this.chartGraph1.FirstVisibleRecord = 1;
            this.chartGraph1.DrawGraph();
        }
    }
    /// <summary>
    /// 值
    /// </summary>
    public class MyValue
    {
        /// <summary>
        /// 值
        /// </summary>
        public string Value="0";
        /// <summary>
        /// 平均值
        /// </summary>
        public string Average="0";
        /// <summary>
        /// 量
        /// </summary>
        public string VOL="0";
        /// <summary>
        /// 时间
        /// </summary>
        public string Time;

        

    }
}