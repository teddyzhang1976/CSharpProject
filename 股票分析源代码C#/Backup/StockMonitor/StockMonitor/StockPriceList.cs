using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
namespace StockMonitor
{

    ////0证券代码
    ////1证券简称
    ////2昨日收盘价
    ////3今日开盘价
    ////4最近成交价
    ////5成交数量
    ////6成交金额
    ////7成交笔数
    ////8最高成交价
    ////9最低成交价
    ////10市盈率1
    ////11卖价位五
    ////12卖数量五
    ////13卖价位四
    ////14卖数量四
    ////15卖价位三
    ////16卖数量三
    ////17卖价位二
    ////18卖数量二
    ////19卖价位一/叫卖揭示价
    ////20卖数量一
    ////21买价位一/叫买揭示价
    ////22买数量一
    ////23买价位二
    ////24买数量二
    ////25买价位三
    ////26买数量三
    ////27买价位四
    ////28买数量四
    ////29买价位五
    ////30买数量五
    /*
     委比

委比--是用以衡量一段时间内买卖盘相对强度的指标,其计算公式为： 
  委比＝〖(委买手数-委卖手数)÷（委买手数＋委卖手数)〗×100% 

  委买手数：现在所有个股委托买入下三档之手数相加之总和。 

委卖手数：现在所有个股委托卖出上三档之手数相加之总和。 

  委比值变化范围为＋100%至-100%。 

  当委比值为正值并且委比数大,说明市场买盘强劲；当委比值为负值并且负值大,说明市场抛盘较强；委比值从-100%至＋100%,说明买盘逐渐增强,卖盘逐渐减弱的一个过程。相反, 从＋100%至-100%,说明买盘逐渐减弱,卖盘逐渐增强的一个过程。 

换手率

“换手率”也称“周转率”，指在一定时间内市场中股票转手买卖的频率，是反映股票流通性强弱的指标之一。其计算公式为： 

  周转率(换手率)＝(某一段时期内的成交量)/(发行总股数)x100% 

  例如，某只股票在一个月内成交了2000万股，而该股票的总股本为 l亿股，则该股票在这个月的换手率为20%。在我国，股票分为可在二级市场流通的社会公众股和不可在二级市场流通的国家股和法人股两个部分，一般只对可流通部分的股票计算换手率，以更真实和准确地反映出股票的流通性。按这种计算方式，上例中那只股票的流通股本如果为200O万，则其换手率高达100%。在国外，通常是用某一段时期的成交金额与某一时点上的市值之间的比值来计算周转率。 

  换手率的高低往往意味着这样几种情况： 

  (l)股票的换手率越高，意味着该只股票的交投越活跃，人们购买该只股票的意愿越高，属于热门股；反之，股票的换手率越低，则表明该只股票少人关注，属于冷门股。 

  (2)换手率高一般意味着股票流通性好，进出市场比较容易，不会出现想买买不到、想卖卖不出的现象，具有较强的变现能力。然而值得注意的是，换手率较高的股票，往往也是短线资金追逐的对象，投机性较强，股价起伏较大，风险也相对较大。 

  (3)将换手率与股价走势相结合，可以对未来的股价做出一定的预测和判断。某只股票的换手率突然上升，成交量放大，可能意味着有投资者在大量买进，股价可能会随之上扬。如果某只股票持续上涨了一个时期后，换手率又迅速上升，则可能意昧着一些获利者要套现，股价可能会下跌。 

  一般而言，新兴市场的换手率要高于成熟市场的换手率。其根本原因在于新兴市场规模扩张快，新上市股票较多，再加上投资者投资理念不强，使新兴市场交投较活跃。换手率的高低还取决于以下几方面的因素： 

  (l)交易方式。证券市场的交易方式，经历了口头唱报、上板竞价、微机撮合、大型电脑集中撮合等从人工到电脑的各个阶段。随着技术手段的日益进步、技术功能的日益强大，市场容量、交易潜力得到日益拓展，换手率也随之有较大提高。 

  (2)交收期。一般而言，交收期越短，换手率越高。 

  (3)投资者结构。以个人投资者为主体的证券市场，换手率往往较高；以基金等机构投资者为主体的证券市场，换手率相对较低。 

  世界各国主要证券市场的换手率各不相同，相差甚远，相比之下，中国股市的换手率位于各国前列。 

量比

量比--是衡量相对成交量的指标。它是开市后每分钟的平均成交量与过去5个交易日每分钟平均成交量之比。 

  其计算公式为：量比＝现成交总手/〖(过去5个交易日平均每分钟成交量)×当日累计开市时间(分)〗 

当量比大于1时,说明当日每分钟的平均成交量大于过去5日的平均值,交易比过去5日火爆；当量比小于1时,说明当日成交量小于过去5日的平均水平。 
量比=(当天即时成交量/开盘至今地累计N分钟)/(前五天总成量 /1200分钟) 
振幅

振幅是指开盘后最高价、最低价之差的绝对值与股价的百分比。



相关知识:外盘、内盘

内盘：以买入价成交的交易，买入成交数量统计加入内盘。

 
外盘：以卖出价成交的交易。卖出量统计加入外盘。内盘，外盘这两个数据 大体可以用来判断买卖力量的强弱。若外盘数量大于内盘，则表现买方力量较强，若 内盘数量大于外盘则说明卖方力量较强。 

通过外盘、内盘数量的大小和比例，投资者通常可能发现主动性的买盘多还是主动性的抛盘多，并在很多时候可以发现庄家动向，是一个较有效的短线指标。 

但投资者在使用外盘和内盘时，要注意结合股价在低位、中位和高位的成交情况以及该股的总成交量情况。因为外盘、内盘的数量并不是在所有时间都有效，在许多时候外盘大，股价并不一定上涨；内盘大，股价也并不一定下跌。 

庄家可以利用外盘、内盘的数量来进行欺骗。在大量的实践中，我们发现如下情况： 

1、股价经过了较长时间的数浪下跌，股价处于较低价位，成交量极度萎缩。此后，成交量温和放量，当日外盘数量增加，大于内盘数量，股价将可能上涨，此种情况较可靠。 

2、在股价经过了较长时间的数浪上涨，股价处于较高价位，成交量巨大，并不能再继续增加，当日内盘数量放大，大于外盘数量，股价将可能继续下跌。 

3、在股价阴跌过程中，时常会发现外盘大、内盘小，此种情况并不表明股价一定会上涨。因为有些时候庄家用几笔抛单将股价打至较低位置，然后在卖1、卖2挂卖单，并自己买自己的卖单，造成股价暂时横盘或小幅上升。此时的外盘将明显大于内盘，使投资者认为庄家在吃货，而纷纷买入，结果次日股价继续下跌。 

4、在股价上涨过程中，时常会发现内盘大、外盘小，此种情况并不表示股价一定会下跌。因为有些时候庄家用几笔买单将股价拉至一个相对的高位，然后在股价小跌后，在买1、买2挂买单，一些者认为股价会下跌，纷纷以叫买价卖出股票，但庄家分步挂单，将抛单通通接走。这种先拉高后低位挂买单的手法，常会显示内盘大、外盘小，达到欺骗投资者的目的，待接足筹码后迅速继续推高股价。 

5、股价已上涨了较大的涨幅，如某日外盘大量增加，但股价却不涨，投资者要警惕庄家制造假象，准备出货。 

6、当股价已下跌了较大的幅度，如某日内盘大量增加，但股价却不跌，投资者要警惕庄家制造假象，假打压真吃货. 

     */
    public partial class StockPriceList : UserControl
    {
        public StockPriceList()
        {
            InitializeComponent();
        }
        public string GetValueURL = "http://www.iwind.com.cn/iwind/RealTimeList/GetNowPrice.ashx?stockcode=";
        public List<StockMonitor.DayLineReader.StockWeightInfo> lsdalrswi = null;
        private void StockPriceList_Load(object sender, EventArgs e)
        {
            //string WgtPath = AppDomain.CurrentDomain.BaseDirectory + @"history/SHASE/weight/600030.wgt";
            //List<StockMonitor.DayLineReader.StockWeightInfo> LS = StockMonitor.DayLineReader.WGTReader.ReadStockWeights(WgtPath);
        }
        private void BTDDBL_Click(object sender, EventArgs e)
        {
         
        }
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
        public void ReadOnePanel(string stockcode)
        {
                   string[] RtStr=WebBack(stockcode).Split(new string[]{","},StringSplitOptions.RemoveEmptyEntries);
                   labelStockCode.Text = RtStr[0];////0证券代码
                   label1StockCode.Text = RtStr[1];////1证券简称
                  //NowPrice_Label.Text = RtStr[2];////2昨日收盘价
                  //NowPrice_Label.Text = RtStr[3];////3今日开盘价
                  //NowPrice_Label.Text = RtStr[4];////4最近成交价
                  //NowPrice_Label.Text = RtStr[5];////5成交数量
                  //NowPrice_Label.Text = RtStr[6];////6成交金额
                  //NowPrice_Label.Text = RtStr[7];////7成交笔数
                  //NowPrice_Label.Text = RtStr[8];////8最高成交价
                  //NowPrice_Label.Text = RtStr[9];////9最低成交价
                  //NowPrice_Label.Text = RtStr[10];////10市盈率

                  SellValue5_label.Text = double.Parse(RtStr[11]).ToString("#0.00");////11卖价位五
                  SellValuePlus5_label.Text = (double.Parse(RtStr[12]) / 100).ToString();////12卖数量五
                  SellValue4_label.Text =double.Parse(RtStr[13]).ToString("#0.00");////13卖价位四
                  SellValuePlus4_label.Text = (double.Parse(RtStr[14]) / 100).ToString();////14卖数量四
                  SellValue3_label.Text =double.Parse( RtStr[15]).ToString("#0.00");////15卖价位三
                  SellValuePlus3_label.Text = (double.Parse(RtStr[16]) / 100).ToString();////16卖数量三
                  SellValue2_label.Text = double.Parse(RtStr[17]).ToString("#0.00");////17卖价位二
                  SellValuePlus2_label.Text = (double.Parse(RtStr[18]) / 100).ToString();////18卖数量二
                  SellValue1_label.Text = double.Parse(RtStr[19]).ToString("#0.00");////19卖价位一/叫卖揭示价
                  SellValuePlus1_label.Text = (double.Parse(RtStr[20]) / 100).ToString();////20卖数量一

                  BuyValue1_label.Text = double.Parse(RtStr[21]).ToString("#0.00");////21买价位一/叫买揭示价
                  BuyValuePlus1_label.Text = (double.Parse(RtStr[22]) / 100).ToString();////22买数量一
                  BuyValue2_label.Text = double.Parse(RtStr[23]).ToString("#0.00");////23买价位二
                  BuyValuePlus2_label.Text = (double.Parse(RtStr[24]) / 100).ToString();////24买数量二
                  BuyValue3_label.Text = double.Parse(RtStr[25]).ToString("#0.00");////25买价位三
                  BuyValuePlus3_label.Text = (double.Parse(RtStr[26]) / 100).ToString();////26买数量三
                  BuyValue4_label.Text = double.Parse(RtStr[27]).ToString("#0.00");////27买价位四
                  BuyValuePlus4_label.Text = (double.Parse(RtStr[28]) / 100).ToString();////28买数量四
                  BuyValue5_label.Text = double.Parse(RtStr[29]).ToString("#0.00");////29买价位五
                  BuyValuePlus5_label.Text = (double.Parse(RtStr[30]) / 100).ToString();////30买数量五
                  #region 内容
                  NowPrice_Label.Text = double.Parse(RtStr[4]).ToString("#0.00");//成交
                  double ZDValue=double.Parse(RtStr[4]) - double.Parse(RtStr[2]);
                  ZhangDie_Lable.Text = ZDValue.ToString("#0.00");//涨跌
                  labelZF.Text = (ZDValue * 100 / double.Parse(RtStr[2])).ToString("#0.00") + "%";
                  labelLow.Text = double.Parse(RtStr[9]).ToString("#0.00");////9最低成交价
                  labelHigh.Text = double.Parse(RtStr[8]).ToString("#0.00");////8最高成交价
                  labelOpen.Text = double.Parse(RtStr[3]).ToString("#0.00");////3今日开盘价
                  labelShiYing.Text = double.Parse(RtStr[10]).ToString("#0.00");////10市盈率
                  labelJinE.Text = (double.Parse(RtStr[6]) / 10000).ToString("#0");////6成交金额
                  labelvol.Text = (int.Parse(RtStr[5]) / 100).ToString();////5成交数量
                  #region 停板
                  double nv=double.Parse(RtStr[3]);
                  double tb = nv * 0.1;
                  string ztjg = (tb + nv).ToString("#0.000");
                   string dtjg=(nv - tb).ToString("#0.000");
                   labelUpToStop.Text = ztjg.Substring(0, ztjg.Length - 1);
                   labelDownToStop.Text = dtjg.Substring(0, dtjg.Length - 1);
                  #endregion
                   #region 委托比率
                   int SellVol = 0;
                   SellVol+=int.Parse(RtStr[12]);////12卖数量五
                   SellVol+= int.Parse(RtStr[14]);////14卖数量四
                   SellVol+= int.Parse(RtStr[16]);////16卖数量三
                   SellVol+= int.Parse(RtStr[18]);////18卖数量二
                   SellVol+= int.Parse(RtStr[20]);////20卖数量一   
                   int BuyVol = 0;
                   BuyVol+=int.Parse(RtStr[22]);////22买数量一
                   BuyVol += int.Parse(RtStr[24]);////24买数量二
                   BuyVol += int.Parse(RtStr[26]);////26买数量三
                   BuyVol += int.Parse(RtStr[28]);////28买数量四
                   BuyVol += int.Parse(RtStr[30]);////30买数量五
                   labelWTBL.Text = ((((double)BuyVol - (double)SellVol) / ((double)BuyVol + (double)SellVol)) * 100).ToString("#0.00")+"%";
                   Ave_Label.Text = (BuyVol + SellVol) / 1000;//均价
                   #endregion
                   #region 换手率
                     StockMonitor.DayLineReader.StockWeightInfo MyIF=  StockMonitor.DayLineReader.WGTReader.GetWeightInfo(DateTime.Now, lsdalrswi);
                     double LTG =double.Parse(MyIF.m_freeStockCount.ToString());
                     double HSV = double.Parse(RtStr[5])/100 / LTG;
                     HSV_Lable.Text = HSV.ToString("#0.00")+"%";
                   #endregion




                  #endregion
               }
    }
}
