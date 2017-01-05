using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
/// <summary>
/// SecondeLine 的摘要说明
/// </summary>
public class SecondeLine
{
    /// <summary>
    /// 创造一个分时线
    /// </summary>
    /// <param name="TXTpath">文件路径</param>
    /// <param name="dsi">日线信息</param>
    public void CreateSencond(string TXTpath, SencondLineInfo dsi)
    {
        FileStream stream = new FileStream(TXTpath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
        BinaryWriter b_reader = new BinaryWriter(stream);       
        b_reader.Write(dsi.ShiFen.ToString("mmss"));
        b_reader.Write(dsi.ChengJiao);
        b_reader.Write(dsi.ZhangDie);
        b_reader.Write(dsi.FuDu);
        b_reader.Write(dsi.MaiRu);
        b_reader.Write(dsi.MaiChu);
        b_reader.Write(dsi.Liang);
        b_reader.Write(dsi.BiShu);
        b_reader.Write(dsi.Backup);
        b_reader.Write(dsi.time.ToString("HHmmss"));
        stream.Close();
    }
    /// <summary>
    /// 获取日期到结束
    /// </summary>
    /// <param name="DateStr">日期</param>
    /// <param name="p_strFileName">股票文件</param>
    /// <returns></returns>
    public List<SencondLineInfo> GetAreaLineToNow(DateTime DateStr, string p_strFileName)
    {
        List<SencondLineInfo> ldsi = new List<SencondLineInfo>();
        int MyDateTime = 0;
        //获取日期下的偏移地址
        int StartPostion = GetDayPostion(DateStr, p_strFileName);
        int CountValue = 0;
        FileStream stream = new FileStream(p_strFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        BinaryReader b_reader = new BinaryReader(stream);
        stream.Position = (long)StartPostion * 40;
        while (stream.CanRead && stream.Position < stream.Length)
        {
            SencondLineInfo dsi = new SencondLineInfo();
            dsi.ShiFen = b_reader.ReadInt32();
            dsi.ChengJiao = b_reader.ReadInt32();
            dsi.ZhangDie = b_reader.ReadInt32();
            dsi.FuDu = b_reader.ReadInt32();
            dsi.MaiRu = b_reader.ReadInt32();
            dsi.MaiChu = b_reader.ReadInt32();
            dsi.Liang = b_reader.ReadInt32();
            dsi.BiShu = b_reader.ReadInt32();
            dsi.Backup = b_reader.ReadInt32();
            try
            {
                MyDateTime = b_reader.ReadInt32();
            }
            catch (Exception ex)
            {

            }
            DateTime day = new DateTime();
            try
            {
                int yeari = MyDateTime / 10000;
                int monthi = (MyDateTime % 10000) / 100;
                int dayi = MyDateTime % 100;
                day = new DateTime(yeari, monthi, dayi);
            }
            catch (Exception exp)
            {

            }
            dsi.time = day;
            ldsi.Add(dsi);
            CountValue++;
        }
        return ldsi;
    }

    /// <summary>
    /// 获取K线，并按过程输出
    /// </summary>
    /// <param name="p_strFileName"></param>
    public List<SencondLineInfo> GetLine(string p_strFileName)
    {
        List<SencondLineInfo> ldsi = new List<SencondLineInfo>();
        int CountValue = 0;
        int MyDateTime = 0;
        FileStream stream = new FileStream(p_strFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        BinaryReader b_reader = new BinaryReader(stream);
  
        while (stream.CanRead && stream.Position < stream.Length)
        {
            SencondLineInfo dsi = new SencondLineInfo();
            dsi.ShiFen = b_reader.ReadInt32();
            dsi.ChengJiao = b_reader.ReadInt32();
            dsi.ZhangDie = b_reader.ReadInt32();
            dsi.FuDu = b_reader.ReadInt32();
            dsi.MaiRu = b_reader.ReadInt32();
            dsi.MaiChu = b_reader.ReadInt32();
            dsi.Liang = b_reader.ReadInt32();
            dsi.BiShu = b_reader.ReadInt32();
            dsi.Backup = b_reader.ReadInt32();
            try
            {
                MyDateTime = b_reader.ReadInt32();
            }
            catch (Exception ex)
            {

            }
            DateTime day = new DateTime();
            try
            {
                int yeari = MyDateTime / 10000;
                int monthi = (MyDateTime % 10000) / 100;
                int dayi = MyDateTime % 100;
                day = new DateTime(yeari, monthi, dayi);
            }
            catch (Exception exp)
            {

            }
            dsi.time = day;
            ldsi.Add(dsi);
            CountValue++;
        }
        return ldsi;

    }
    /// <summary>
    /// 折半方法获取偏移位置
    /// </summary>
    /// <param name="DateStr">日期</param>
    /// <param name="p_strFileName">文件路径</param>
    /// <returns></returns>
    public int GetDayPostion(DateTime DateStr, string p_strFileName)
    {
        int MyDateTime = 0;
        //长度
        int rowLength = 40;
        //日期
        int MyDate = int.Parse(DateStr.ToString("HHmm"));
        FileStream stream = new FileStream(p_strFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        BinaryReader b_reader = new BinaryReader(stream);
        //文件长度
        long fileLength = stream.Length;
        //记录条数
        int recCount = (int)(fileLength / rowLength);
        //开始位置
        int recStart = 0;
        //结束位置
        int recEnd = recCount;
        //选择的位置
        int curRowNo = 0;
        //结果位置
        int result;
        //先折半
        curRowNo = (recStart + recEnd) / 2;
        //需要循环
        bool NeedLoop = true;
        while (NeedLoop)
        {
            // Console.WriteLine(curRowNo.ToString() +"-"+ DateTime.ToString());
            stream.Position = (long)(curRowNo * rowLength);
            MyDateTime = b_reader.ReadInt32();

            //如果取的时间小于折半时间，游标上移
            if (MyDate < MyDateTime)
            {
                recEnd = curRowNo;
                curRowNo = (recStart + curRowNo) / 2;

                if (curRowNo == 0)
                {
                    stream.Position = (long)(curRowNo * rowLength);
                    MyDateTime = b_reader.ReadInt32();
                    if (MyDateTime == MyDate)
                    {
                        return 0;
                    }
                    else
                    { break; }
                }
            }
            //如果取的时间大于折半时间，游标下移
            if (MyDate > MyDateTime)
            {
                recStart = curRowNo;
                curRowNo = (curRowNo + recEnd) / 2;

                if ((recEnd - curRowNo) <= 1)
                {
                    stream.Position = (long)(curRowNo * rowLength);
                    MyDateTime = b_reader.ReadInt32();
                    if (MyDateTime == MyDate)
                    {
                        return curRowNo;
                    }
                    else
                    { break; }
                }
            }
            //如果相等，位置就在此了
            if (MyDate == MyDateTime)
            {
                NeedLoop = false;
                return curRowNo;
            }
        }
        stream.Close();
        return -1;



    }
    public SecondeLine()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
}
public class SencondLineInfo
{
    /// <summary>
    /// 时间
    /// </summary>
    public DateTime time = new DateTime();
    /// <summary>
    /// 时分 930(9:20) 1020(10:20)
    /// </summary>
    public int ShiFen = 930;
    /// <summary>
    /// 成交价 2310为23.10(数除以100)
    /// </summary>
    public int ChengJiao = 0;
    /// <summary>
    /// 涨跌 10为10/100(0.10),4为4/100(0.04)
    /// </summary>
    public int ZhangDie = 0;
    /// <summary>
    /// 幅度 10为10/100(0.10),4为4/100(0.04)
    /// </summary>
    public int FuDu = 0;
    /// <summary>
    /// 当时买入价格 2310为23.10(数除以100)
    /// </summary>
    public int MaiRu = 0;
    /// <summary>
    /// 当时卖出价格 2310为23.10(数除以100)
    /// </summary>
    public int MaiChu = 0;
    /// <summary>
    /// 现量，及为卖出或买入时的量
    /// </summary>
    public int Liang = 0;
    /// <summary>
    /// 笔数，level1上海没有笔数
    /// </summary>
    public int BiShu = 0;
    /// <summary>
    /// 备注连接
    /// </summary>
    public int Backup = 0;
}
