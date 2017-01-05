using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageOfStock
{
    /*日线的流长度为40标准
     * 折半查找是最快的读取K线范围方式
     * string codepath=AppDomain.CurrentDomain.BaseDirectory + @"history\SZNSE\day\000012.day";
     * 获取天数方法
     * （用例）
     * 
     * SDSDLR.GetAllLineCount(codepath).ToString()
     * long count = SDSDLR.GetDayToNowCount(DateTime.Parse("2010-07-01"), codepath);
     * long count = SDSDLR.GetDayToDayCount(DateTime.Parse("2010-07-01"),DateTime.Parse("2010-07-07"), codepath);
     * 
     * 输出K线
     * （用例）
     * SDSDLR.GetLine(AppDomain.CurrentDomain.BaseDirectory + @"history\SZNSE\day\000012.day");
     * SDSDLR.GetAreaLineToNow(DateTime.Parse("2010-07-01"), codepath);
     * SDSDLR.GetAreaLineToNow(DateTime.Parse("2010-07-01"),DateTime.Parse("2010-07-06"), codepath);
     * 
     * 指标方法
     * （用例）
     * double my = SDSDLR.StockValueMA("CLOSE", 50, DateTime.Parse("1992-06-02"), codepath);
     * 
     *大连英佳网络科技有限公司
     *技术部
     *杨航
     */

    /// <summary>
    /// 股票数据输出代理
    /// </summary>
    /// <param name="DSI"></param>
    public delegate void StockInfoLayOut(DayStockInfo DSI,int process);
    /// <summary>
    /// 股票数据输出代理结束
    /// </summary>
    /// <param name="DSI"></param>
    public delegate void StockInfoLayOutOver(DayStockInfo DSI);
    /// <summary>
    /// 股票日线信息
    /// </summary>
    public class DayStockInfo
    {
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime day=new DateTime();
        /// <summary>
        /// 开盘
        /// </summary>
        public int OpenPrice = 0;
        /// <summary>
        /// 最高
        /// </summary>
        public int HighestPrice = 0;
        /// <summary>
        /// 最低
        /// </summary>
        public int LowestPrice = 0;
        /// <summary>
        /// 收盘
        /// </summary>
        public int ClosePrice=0;
        /// <summary>
        /// 成交金额
        /// </summary>
        public int Amount = 0;
        /// <summary>
        /// 成交量
        /// </summary>
        public int TransCount = 0;

        public int Padding1 = 0;

        public int Padding2 = 0;
        
        public int Padding3 = 0;
    }
    /// <summary>
    /// 日线类别
    /// </summary>
    public enum DAYLINETYPE
    {
        /// <summary>
        /// 收盘
        /// </summary>
       CLOSE=0,
        /// <summary>
        /// 开盘
        /// </summary>
        OPEN=1, 
        /// <summary>
        /// 量
        /// </summary>
        VOL=2,   
        /// <summary>
        /// 总金额
        /// </summary>
        AMOUNT=3, 
        /// <summary>
        /// 最高价格
        /// </summary>
        HIGH=4, 
        /// <summary>
        /// 最低价格
        /// </summary>
        LOW=5 
    }
}
