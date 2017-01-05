using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace StockMonitor.DayLineReader
{
    /*
     *获取权息资料
     *测试用例：StockMonitor.DayLineReader.WGTReader.ReadStockWeights(AppDomain.CurrentDomain.BaseDirectory + @"history/SHASE/weight/600030.wgt");
     *大连英佳网络科技有限公司
     *技术部
     *杨航
     * 所谓复权就是对股价和成交量进行权息修复,按照股票的实际涨跌绘制股价走势图,
     * 并把成交量调整为相同的股本口径。股票除权、除息之后，股价随之产生了变化，
     * 但实际成本并没有变化。
     * 如：原来20元的股票，十送十之后为10元，但实际还是相当于20元。
     * 从K线图上看这个价位看似很低，但很可能就是一个历史高位。
     * 例如某股票除权前日流通盘为5000万股，价格为10元，成交量为500万股，
     * 换手率为10%，10送10之后除权报价为5元，流通盘为1亿股，除权当日走出填权行情
     * ，收盘于 5.5元，上涨10%，成交量为1000万股，换手率也是10%(和前一交易日相比具有同样的成交量水平)。
     * 复权处理后股价为11元，相对于前一日的10元上涨了10%，成交量为500万股，这样在股价走势图上真实反映了股价涨跌，
     * 同时成交量在除权前后也具有可比性。
     * 
     * 前复权：复权后价格＝[(复权前价格-现金红利)＋配(新)股价格×流通股份变动比例]÷(1＋流通股份变动比例) 
     * 后复权：复权后价格＝复权前价格×(1＋流通股份变动比例)-配(新)股价格×流通股份变动比例＋现金红利
     */
    /// <summary>
    /// 读取权息资料类
    /// </summary>
    public class WGTReader
    {
        /// <summary>
        /// 读取权息资料
        /// </summary>
        /// <param name="strPath"></param>
        /// <param name="p_strMarket"></param>
         public static List<StockWeightInfo> ReadStockWeights(string strPath)
        {
            string[] parts = strPath.Split('\\');
            string strStockCode = null;
            for (int i = parts.Length - 1; i >= 0;i-- )
            {
                string strTemp = parts[i];
                if (strTemp.ToUpper().EndsWith(".WGT"))
                {
                    strStockCode = strTemp.Substring(0, strTemp.Length - 4) ;
                    break;
                }
            }

           //Console.WriteLine("Read stock weight from file '" + strPath + "'");
            FileStream stream = new FileStream(strPath, FileMode.Open, FileAccess.Read);
            BinaryReader b_reader = new BinaryReader(stream);
            List<StockWeightInfo> weightInfos = new List<StockWeightInfo>();
            try
            {
                while (stream.CanRead && stream.Position < stream.Length)
                {
                    int[] oneRow = new int[9];
                    for( int i=0;i<9;i++)
                    {
                        oneRow[i] = b_reader.ReadInt32();
                    }
                    if (oneRow[8] != 0)
                    {
                        throw new Exception("Last entry is not empty");
                    }
         
                    int nYear = oneRow[0] >> 20;
                    int nMon = (int)(((uint)(oneRow[0] << 12))>> 28);
                    int nDay = (oneRow[0] & 0xffff)>> 11;

                    DateTime wgtDate;
                    if (nYear == 0 && nMon == 0 && nDay == 0)
                        wgtDate = DateTime.MinValue;
                    else
                            wgtDate = new DateTime(nYear, nMon, nDay);
                    StockWeightInfo wgtInfo = new StockWeightInfo();
                    wgtInfo.m_date = wgtDate;
                    wgtInfo.m_stockCountAsGift = oneRow[1];/**////10000.0f;
                    wgtInfo.m_stockCountForSell = oneRow[2];/**////10000.0f;
                    wgtInfo.m_priceForSell = oneRow[3];/**////1000.0f;
                    wgtInfo.m_bonus = oneRow[4];/**////1000.0f;
                    wgtInfo.m_stockCountOfIncreasement = oneRow[5];/**////10000.0f;
                    wgtInfo.m_stockOwnership = (ulong)oneRow[6];
                    wgtInfo.m_freeStockCount = (ulong)oneRow[7];
                    if (!weightInfos.Contains(wgtInfo))
                    {
                        weightInfos.Add(wgtInfo);
                        //Console.WriteLine();
                        //Console.Write("时间:" + wgtInfo.m_date.ToString() + ",流通股:" + wgtInfo.m_freeStockCount + ",m_priceForSell:" + wgtInfo.m_priceForSell + ",分红:" + wgtInfo.m_bonus + ",送股数:" + wgtInfo.m_stockCountAsGift + ",m_stockCountForSell:" + wgtInfo.m_stockCountForSell + ",转增数:" + wgtInfo.m_stockCountOfIncreasement + ",总股本:" + wgtInfo.m_stockOwnership);//测试部分
                    }
                }
                weightInfos.Sort();
            }
            catch (EndOfStreamException)
            {
                Console.WriteLine("Unexpected end of stream");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
  
            }
            finally
            {
                stream.Close();
            }
            return weightInfos;
        }
        /// <summary>
        /// 获取对应日期下的权息资料
        /// </summary>
        /// <param name="Dtm"></param>
        /// <param name="LSWI"></param>
        /// <returns></returns>
        public static StockWeightInfo GetWeightInfo(DateTime Dtm,List<StockWeightInfo> LSWI)
        {
            //2010-05-08

            //1985-10-29
            //1988-10-22
            //2005-10-10
            //2010-04-08
            //2010-10-10
            //2011-05-01
            StockWeightInfo RtInfo=new StockWeightInfo();
            foreach (StockWeightInfo SWI in LSWI)
            {
                if (Dtm >= SWI.m_date)//
                {
                    RtInfo = SWI;
                }
            }
            return RtInfo;
        }

    }
    /// <summary>
    /// 权息资料
    /// </summary>
    public class StockWeightInfo
    { 
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime m_date = DateTime.Now;
        /// <summary>
        /// 送股数 (35000显示在终端就为3.500)
        /// </summary>
        public int m_stockCountAsGift =0;
        /// <summary>
        /// 配股数
        /// </summary>
        public int m_stockCountForSell = 0;
        /// <summary>
        /// 配股价
        /// </summary>
        public int m_priceForSell = 0;
        /// <summary>
        /// 分红 (37显示在终端为0.0370,1100->1.1000)
        /// </summary>
        public int m_bonus = 0;
        /// <summary>
        /// 转增数 (100000显示在终端为10.000)
        /// </summary>
        public int m_stockCountOfIncreasement = 0;
        /// <summary>
        /// 总股本 (单位为“万”)
        /// </summary>
        public ulong m_stockOwnership = 0;
        /// <summary>
        /// 流通股 (单位为“万”)
        /// </summary>
        public ulong m_freeStockCount =0;
    }
}
