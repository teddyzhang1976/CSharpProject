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

namespace StockMonitor.Forms
{
    public partial class TestDayLineStockForm : UserControl
    {
        #region 字段

        //定义四个Panel作为例子
        /// <summary>
        /// 主
        /// </summary>
        int mainPanelID = -1;
        /// <summary>
        /// 量
        /// </summary>
        int volumePanelID = -1;
        /// <summary>
        /// KDJ
        /// </summary>
        int kdjPanelID = -1;
        /// <summary>
        /// MACD
        /// </summary>
        int macdPanelID = -1;
        /// <summary>
        /// Boll
        /// </summary>
        int bollPanelID = -1;
        /// <summary>
        /// 进程
        /// </summary>
        /// <param name="obj"></param>
        private delegate void UpdateProcessBarDelegate(object obj);
        /// <summary>
        /// 模拟
        /// </summary>
        public ChartGraph ChartGraphTemp = new ChartGraph();
        //public string codepath = AppDomain.CurrentDomain.BaseDirectory + @"history\SZNSE\day\000423.day";

        /// <summary>
        ///股票日线存放地址
        /// </summary>
       public  string codepath = AppDomain.CurrentDomain.BaseDirectory + @"history\SHASE\day\000001.day";
        /// <summary>
        /// 权息资料存放
        /// </summary>
       public  string wgtpath = AppDomain.CurrentDomain.BaseDirectory + @"history\SZNSE\weight\000012.wgt";
       
        /// <summary>
        /// 后台加载使用的线程
        /// </summary>
        public Thread MyLoopThread = null;
        /// <summary>
        /// 距离差
        /// </summary>
        public int CurLengthCount = 0;
        #endregion
     
        #region 测试
         /// <summary>
         /// 更新数据到图像
         /// </summary>
         /// <param name="obj"></param>
         public void UpdateDataToGraph(object obj)
         {
             List<string[]> list = obj as List<string[]>;
             string[] str = list[0];
             this.chartGraph1.SetTitle(mainPanelID, str[2] + "(" + str[1] + ") " + str[0]);
             this.chartGraph1.SetTitle(kdjPanelID, "KDJ(9,3,3)");
             this.chartGraph1.SetTitle(volumePanelID, "VOL(5,10,20)");
             this.chartGraph1.SetTitle(macdPanelID, "MACD(12,26,9)");
             string lineType = str[0];
             switch (lineType)
             {
                 case "5分钟":
                 case "15分钟":
                 case "30分钟":
                 case "60分钟":
                     this.chartGraph1.SetIntervalType(mainPanelID, ChartGraph.IntervalType.Minute);
                     this.chartGraph1.SetIntervalType(volumePanelID, ChartGraph.IntervalType.Minute);
                     this.chartGraph1.SetIntervalType(kdjPanelID, ChartGraph.IntervalType.Minute);
                     break;
                 case "日线":
                     this.chartGraph1.SetIntervalType(mainPanelID, ChartGraph.IntervalType.Day);
                     this.chartGraph1.SetIntervalType(volumePanelID, ChartGraph.IntervalType.Day);
                     this.chartGraph1.SetIntervalType(kdjPanelID, ChartGraph.IntervalType.Day);
                     break;
                 case "周线":
                     this.chartGraph1.SetIntervalType(mainPanelID, ChartGraph.IntervalType.Week);
                     this.chartGraph1.SetIntervalType(volumePanelID, ChartGraph.IntervalType.Week);
                     this.chartGraph1.SetIntervalType(kdjPanelID, ChartGraph.IntervalType.Week);
                     break;
                 case "月线":
                     this.chartGraph1.SetIntervalType(mainPanelID, ChartGraph.IntervalType.Month);
                     this.chartGraph1.SetIntervalType(volumePanelID, ChartGraph.IntervalType.Month);
                     this.chartGraph1.SetIntervalType(kdjPanelID, ChartGraph.IntervalType.Month);
                     break;
             }
             this.chartGraph1.RefreshGraph();
             for (int i = list.Count - 1; i >= 2; i--)
             {
                 string[] records = list[i];
                 string timeKey = records[0];
                 int year = 1970;
                 int month = 1;
                 int day = 1;
                 int hour = 0;
                 int minute = 0;
                 switch (lineType)
                 {
                     case "5分钟":
                     case "15分钟":
                     case "30分钟":
                     case "60分钟":
                         month = Convert.ToInt32(timeKey.Substring(0, 1));
                         day = Convert.ToInt32(timeKey.Substring(1, 2));
                         hour = Convert.ToInt32(timeKey.Substring(3, 2));
                         minute = Convert.ToInt32(timeKey.Substring(5, 2));
                         break;
                     case "日线":
                     case "周线":
                         year = Convert.ToInt32(timeKey.Substring(0, 4));
                         month = Convert.ToInt32(timeKey.Substring(4, 2));
                         day = Convert.ToInt32(timeKey.Substring(6, 2));
                         break;
                     case "月线":
                         year = Convert.ToInt32(timeKey.Substring(0, 4));
                         month = Convert.ToInt32(timeKey.Substring(4, 2));
                         break;
                 }
                 DateTime dt = new DateTime(year, month, day, hour, minute, 0);

                 string OPENStr = records[1];
                 string HIGHStr = records[2];
                 string LOWStr = records[3];
                 string CLOSEStr = records[4];
                 string VOLStr = records[6];
                 this.chartGraph1.SetValue("OPEN", OPENStr, dt);
                 this.chartGraph1.SetValue("HIGH", HIGHStr, dt);
                 this.chartGraph1.SetValue("LOW", LOWStr, dt);
                 this.chartGraph1.SetValue("CLOSE", CLOSEStr, dt);
                 this.chartGraph1.SetValue("VOL", VOLStr, dt);
                 double ymValue = (Convert.ToDouble(CLOSEStr) + Convert.ToDouble(HIGHStr) + Convert.ToDouble(LOWStr)) / 3;
                 this.chartGraph1.SetValue("(CLOSE+HIGH+LOW)/3", ymValue, dt);
                 this.BeginInvoke(new UpdateProcessBarDelegate(UpdateProcessBar), new int[] { list.Count, list.Count - i });
             }
             this.chartGraph1.Enabled = true;
         }

         /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockCodeIn(string StockCode)
        {
                  string Path=AppDomain.CurrentDomain.BaseDirectory+StockCode+".day";
                List<string[]> list = new List<string[]>();
                using (FileStream fs = new FileStream(Path, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                    {
                        sr.BaseStream.Seek(0, SeekOrigin.Begin);
                        while (sr.Peek() > -1)
                        {
                            string value = sr.ReadLine();
                            string[] records = value.ToString().Split('\t');
                            list.Add(records);
                        }
                    }
                }
                CandleGraph();
                this.chartGraph1.ProcessBarValue = 0;
     
                Thread refreshData = new Thread(new ParameterizedThreadStart(UpdateDataToGraph));
                refreshData.IsBackground = true;
                refreshData.Start(list);

            }
         #endregion

        #region 初始化
        public TestDayLineStockForm()
        {
            InitializeComponent();
            PanelInit();
        }
        public TestDayLineStockForm(string MyCode,string Weight)
        {
            codepath = MyCode;
            wgtpath = Weight;
            InitializeComponent();
            PanelInit();
            CountInitValue();
        }
        public TestDayLineStockForm(string MyCode)
        {
            codepath = MyCode;
            InitializeComponent();
            PanelInit();
            CountInitValue();
        
            stockPriceList1.lsdalrswi = StockMonitor.DayLineReader.WGTReader.ReadStockWeights(wgtpath);
        
        }
        public void ChartGraphInit()
        {
            // 
            // chartGraph1
            // 
            this.chartGraph1.AxisSpace = 0;
            this.chartGraph1.CanDragSeries = false;
            this.chartGraph1.CrossOverIndex = 0;
            this.chartGraph1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartGraph1.FirstVisibleRecord = 0;
            this.chartGraph1.LastVisibleRecord = 0;
            this.chartGraph1.LeftPixSpace = 0;
            this.chartGraph1.Location = new System.Drawing.Point(0, 0);
            this.chartGraph1.Name = "chartGraph1";
            this.chartGraph1.ProcessBarValue = 0;
            this.chartGraph1.RightPixSpace = 0;
            this.chartGraph1.ScrollLeftStep = 1;
            this.chartGraph1.ScrollRightStep = 1;
            this.chartGraph1.ShowCrossHair = false;
            this.chartGraph1.ShowLeftScale = false;
            this.chartGraph1.ShowRightScale = false;
            this.chartGraph1.Size = new System.Drawing.Size(788, 570);
            this.chartGraph1.StockCode = "";
            this.chartGraph1.TabIndex = 7;
            this.chartGraph1.Text = "chartGraph2";
            this.chartGraph1.TimekeyField = null;
            this.chartGraph1.UseScrollAddSpeed = false;
        }
        public void StockLoad(string MyCode)
        {
            InitializeComponent();
            PanelInit();
            CountInitValue();
        }
        /// <summary>
        /// 获取初始化值 600个足够显示第一屏幕了
        /// </summary>
        public void CountInitValue()
        {

            this.chartGraph1.DtAllMsg = new DataTable();
            CandleGraph();

            this.chartGraph1.SetTitle(mainPanelID, "南玻A (000012) 日线");
            this.chartGraph1.SetTitle(kdjPanelID, "KDJ(9,3,3)");
            this.chartGraph1.SetTitle(volumePanelID, "VOL(5,10,20)");
            this.chartGraph1.SetTitle(macdPanelID, "MACD(12,26,9)");
            this.chartGraph1.SetTitle(bollPanelID, "布林通道(BOLL,BOLL,BOLL)");
            this.chartGraph1.RefreshGraph();

            int Count = (int)this.chartGraph1.GetAllLineCount();
            if (Count < 600)
            {
                this.chartGraph1.LoadCursorValue(0, Count);
            }
            else
            {
                CurLengthCount = Count - 600;
                this.chartGraph1.LoadCursorValue(CurLengthCount, Count);
            }

        }
        /// <summary>
        /// 布局初始化
        /// </summary>
        public void PanelInit()
        {
            CandleGraph();
            //表面
            this.chartGraph1.PicLineDrawValue += new StockInfoLayOut(SDSDLR_PicLineDrawValue);
            this.chartGraph1.PicLineDrawValueOver += new StockInfoLayOutOver(SDSDLR_PicLineDrawValueOver);
            //临时
            ChartGraphTemp = new ChartGraph();
            this.ChartGraphTemp.StockCode = codepath;
            this.chartGraph1.StockCode = codepath;
            this.ChartGraphTemp.PicLineDrawValue += new StockInfoLayOut(Temp_PicLineDrawValue);
            this.ChartGraphTemp.PicLineDrawValueOver += new StockInfoLayOutOver(Temp_PicLineDrawValueOver);
        }
        /// <summary>
        /// 表面
        /// </summary>
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
            //K线图+BS点
            mainPanelID = this.chartGraph1.AddChartPanel(40);//(百分比)整体为100
            string candleName = "K线图-1";
            this.chartGraph1.AddSimpleMovingAverage("Jesse-Livermore", "杰西利弗莫尔线", "CLOSE", 50, mainPanelID);
            this.chartGraph1.SetTrendLineStyle("Jesse-Livermore", Color.FromArgb(255, 0, 255), Color.FromArgb(255, 0, 255), 2, DashStyle.Solid);
            this.chartGraph1.AddCandle(candleName, "OPEN", "HIGH", "LOW", "CLOSE", mainPanelID, true);
            this.chartGraph1.YMBuySellSignal(mainPanelID, candleName, "BUYEMA", "(CLOSE+HIGH+LOW)/3", "SELLEMA", "BUYEMA");

            this.chartGraph1.SetYScaleField(mainPanelID, new string[] { "HIGH", "LOW" });
            //成交量
            volumePanelID = this.chartGraph1.AddChartPanel(15);
            this.chartGraph1.AddHistogram("VOL", "", candleName, volumePanelID);
            this.chartGraph1.SetHistogramStyle("VOL", Color.Red, Color.SkyBlue, 1, false);
            this.chartGraph1.AddSimpleMovingAverage("VOL-MA1", "MA5", "VOL", 5, volumePanelID);
            this.chartGraph1.SetTrendLineStyle("VOL-MA1", Color.White, Color.White, 1, DashStyle.Solid);
            this.chartGraph1.AddSimpleMovingAverage("VOL-MA2", "MA10", "VOL", 10, volumePanelID);
            this.chartGraph1.SetTrendLineStyle("VOL-MA2", Color.Yellow, Color.Yellow, 1, DashStyle.Solid);
            this.chartGraph1.AddSimpleMovingAverage("VOL-MA3", "MA20", "VOL", 20, volumePanelID);
            this.chartGraph1.SetTrendLineStyle("VOL-MA3", Color.FromArgb(255, 0, 255), Color.FromArgb(255, 0, 255), 1, DashStyle.Solid);
            this.chartGraph1.SetTick(volumePanelID, 1);
            this.chartGraph1.SetDigit(volumePanelID, 0);
            //KDJ
            kdjPanelID = this.chartGraph1.AddChartPanel(15);
            this.chartGraph1.AddStochasticOscillator("K", "D", "J", 9, "CLOSE", "HIGH", "LOW", kdjPanelID);
            //MACD
            macdPanelID = this.chartGraph1.AddChartPanel(15);
            this.chartGraph1.AddMacd("MACD", "DIFF", "DEA", "CLOSE", 26, 12, 9, macdPanelID);
            //Boll
            bollPanelID = this.chartGraph1.AddChartPanel(15);
            this.chartGraph1.AddBollingerBands("MID", "UP", "DOWN", "CLOSE", 20, 2, bollPanelID);
            


        }
        /// <summary>
        /// 临时数据
        /// </summary>
        public void CandleGraphTemp()
        {
            this.ChartGraphTemp.ResetNullGraph();
            this.ChartGraphTemp.UseScrollAddSpeed = true;
            this.ChartGraphTemp.SetXScaleField("日期");
            this.ChartGraphTemp.CanDragSeries = true;
            this.ChartGraphTemp.SetSrollStep(10, 10);
            this.ChartGraphTemp.ShowLeftScale = true;
            this.ChartGraphTemp.ShowRightScale = true;
            this.ChartGraphTemp.LeftPixSpace = 85;
            this.ChartGraphTemp.RightPixSpace = 85;
            //K线图+BS点
            mainPanelID = this.ChartGraphTemp.AddChartPanel(40);//(百分比)整体为100
            string candleName = "K线图-1";
            this.ChartGraphTemp.AddSimpleMovingAverage("Jesse-Livermore", "杰西利弗莫尔线", "CLOSE", 50, mainPanelID);
            this.ChartGraphTemp.SetTrendLineStyle("Jesse-Livermore", Color.FromArgb(255, 0, 255), Color.FromArgb(255, 0, 255), 2, DashStyle.Solid);
            this.ChartGraphTemp.AddCandle(candleName, "OPEN", "HIGH", "LOW", "CLOSE", mainPanelID, true);
           this.ChartGraphTemp.YMBuySellSignal(mainPanelID, candleName, "BUYEMA", "(CLOSE+HIGH+LOW)/3", "SELLEMA", "BUYEMA");
            this.ChartGraphTemp.SetYScaleField(mainPanelID, new string[] { "HIGH", "LOW" });
            //成交量
            volumePanelID = this.ChartGraphTemp.AddChartPanel(20);
            this.ChartGraphTemp.AddHistogram("VOL", "", candleName, volumePanelID);
            this.ChartGraphTemp.SetHistogramStyle("VOL", Color.Red, Color.SkyBlue, 1, false);
            this.ChartGraphTemp.AddSimpleMovingAverage("VOL-MA1", "MA5", "VOL", 5, volumePanelID);
            this.ChartGraphTemp.SetTrendLineStyle("VOL-MA1", Color.White, Color.White, 1, DashStyle.Solid);
            this.ChartGraphTemp.AddSimpleMovingAverage("VOL-MA2", "MA10", "VOL", 10, volumePanelID);
            this.ChartGraphTemp.SetTrendLineStyle("VOL-MA2", Color.Yellow, Color.Yellow, 1, DashStyle.Solid);
            this.ChartGraphTemp.AddSimpleMovingAverage("VOL-MA3", "MA20", "VOL", 20, volumePanelID);
            this.ChartGraphTemp.SetTrendLineStyle("VOL-MA3", Color.FromArgb(255, 0, 255), Color.FromArgb(255, 0, 255), 1, DashStyle.Solid);
            this.ChartGraphTemp.SetTick(volumePanelID, 1);
            this.ChartGraphTemp.SetDigit(volumePanelID, 0);
            //KDJ
            kdjPanelID = this.ChartGraphTemp.AddChartPanel(20);
            this.ChartGraphTemp.AddStochasticOscillator("K", "D", "J", 9, "CLOSE", "HIGH", "LOW", kdjPanelID);
            //MACD
            macdPanelID = this.ChartGraphTemp.AddChartPanel(10);
            this.ChartGraphTemp.AddMacd("MACD", "DIFF", "DEA", "CLOSE", 26, 12, 9, macdPanelID);

            //Boll
            bollPanelID = this.ChartGraphTemp.AddChartPanel(10);
            this.ChartGraphTemp.AddBollingerBands("MID", "UP", "DOWN", "CLOSE", 20, 2, bollPanelID);


        }
        #endregion

        #region 事件
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
        private void TestDayLineStockForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopThreadState();
        }
        /// <summary>
        /// 停止线程
        /// </summary>
        public void StopThreadState()
        {
            if (MyLoopThread.ThreadState == ThreadState.Running)
            {
                MyLoopThread.Abort();
            }
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
            //int processValue = Convert.ToInt32((double)current / (double)total * 100);
            //if (processValue > this.chartGraph1.ProcessBarValue)
            //{
            //    this.chartGraph1.ProcessBarValue = processValue;
            //}
            if (current == total - 2)
            {
                //    this.chartGraph1.ProcessBarValue = 100;   
                this.chartGraph1.RefreshGraph();
            }
        }

 
        /// <summary>
        /// 加载全部
        /// </summary>
        public void UpdateAllLineToGraph()
        {
            //操作读取
            this.ChartGraphTemp.DtAllMsg = new DataTable();
            CandleGraphTemp();
            this.ChartGraphTemp.SetTitle(mainPanelID, "南玻A (000012) 日线");
            this.ChartGraphTemp.SetTitle(kdjPanelID, "KDJ(9,3,3)");
            this.ChartGraphTemp.SetTitle(volumePanelID, "VOL(5,10,20)");
            this.ChartGraphTemp.SetTitle(macdPanelID, "MACD(12,26,9)");
            this.ChartGraphTemp.SetTitle(bollPanelID, "布林通道(BOLL,BOLL,BOLL)");
            this.ChartGraphTemp.RefreshGraph();
            this.ChartGraphTemp.GetLine();//所有数据        

        }
        /// <summary>
        /// 数据的输出
        /// </summary>
        /// <param name="DSI"></param>
        public void SDSDLR_PicLineDrawValue(DayStockInfo DSI, int P)
        {
            this.chartGraph1.SetValue("OPEN", (double)DSI.OpenPrice / 1000, DSI.day);
            this.chartGraph1.SetValue("HIGH", (double)DSI.HighestPrice / 1000, DSI.day);
            this.chartGraph1.SetValue("LOW", (double)DSI.LowestPrice / 1000, DSI.day);
            this.chartGraph1.SetValue("CLOSE", (double)DSI.ClosePrice / 1000, DSI.day);
            this.chartGraph1.SetValue("VOL", DSI.TransCount, DSI.day);
            double ymValue = (Convert.ToDouble(DSI.ClosePrice.ToString()) + Convert.ToDouble(DSI.HighestPrice.ToString()) + Convert.ToDouble(DSI.LowestPrice.ToString())) / 3;
            this.chartGraph1.SetValue("(CLOSE+HIGH+LOW)/3", ymValue, DSI.day);
        }
        /// <summary>
        /// 更新所有的数据的输出
        /// </summary>
        /// <param name="DSI"></param>
        public void Temp_PicLineDrawValue(DayStockInfo DSI, int P)
        {
            this.ChartGraphTemp.SetValue("OPEN", (double)DSI.OpenPrice / 1000, DSI.day);
            this.ChartGraphTemp.SetValue("HIGH", (double)DSI.HighestPrice / 1000, DSI.day);
            this.ChartGraphTemp.SetValue("LOW", (double)DSI.LowestPrice / 1000, DSI.day);
            this.ChartGraphTemp.SetValue("CLOSE", (double)DSI.ClosePrice / 1000, DSI.day);
            this.ChartGraphTemp.SetValue("VOL", DSI.TransCount, DSI.day);
         double ymValue = (Convert.ToDouble(DSI.ClosePrice.ToString()) + Convert.ToDouble(DSI.HighestPrice.ToString()) + Convert.ToDouble(DSI.LowestPrice.ToString())) / 3;
         this.ChartGraphTemp.SetValue("(CLOSE+HIGH+LOW)/3", ymValue, DSI.day);
        }

        public void SDSDLR_PicLineDrawValueOver(DayStockInfo DSI)
        {
            this.chartGraph1.RefreshGraph();
            MyLoopThread = new Thread(new ThreadStart(UpdateAllLineToGraph));
            MyLoopThread.Start();
        }
        public void Temp_PicLineDrawValueOver(DayStockInfo DSI)
        {
            this.chartGraph1.dtAllMsg = this.ChartGraphTemp.dtAllMsg;
            this.chartGraph1.LastVisibleRecord += CurLengthCount;
            this.chartGraph1.FirstVisibleRecord += CurLengthCount;
            this.chartGraph1.CrossOverIndex += CurLengthCount;
        }
        #endregion


  

   

 


        private void Test_Click(object sender, EventArgs e)
        {



            stockPriceList1.ReadOnePanel("sn000012");
           // stockPriceList1.ReadOnePanel("sh600718");
          
        }

  
     

    }
}