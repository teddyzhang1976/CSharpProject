<%@ WebHandler Language="C#" Class="GetPriceList" %>

using System;
using System.Web;
using System.IO;
using System.Data;
using System.Text;
//接口说明：
//stockcode为需要返回的股票每笔值列表
//nowtime为当前的的时间段儿之后的每笔值列表
//使用说明：
//如果nowtime为空，则返回全部值

//格式定义：
//接收：
//stockcode 为股票代码
//nowtime 133030 表达的意思(13:30:30)
//返回：
//以，隔开每四位为一个单元
//array[num]
//num=0，时分秒
//num=1，价格
//num=2，量
//num=3，笔
//num=4，涨或跌（u或p）判断公式如下 u=up涨,p=跌
/*
委卖的5档报价分别是：10，10.01，10.02，10.03，10.05 
委买的5档报价分别是：9.99，9.98，9.97，9.96，9.94 
以委卖的价格成交就是红箭头，
以委买的价格成交就是绿箭头，
如果是以10.04或者9.95的价格成交那么就是没有箭头表示 
至于没有箭头的（也就是你说的白色的）表示该成交价格没有委托挂单 
 */
public class GetPriceList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        
       
        if (context.Request.QueryString["stockcode"] != null)
        {
            if (context.Request.QueryString["nowtime"] != null)
            {
                        context.Response.Write("Hello World");
            }
            else
            {
                string MyCode = context.Request.QueryString["stockcode"];
                DataTable MyTable = new DataTable();
                StringBuilder SB=new StringBuilder(256);
                if (MyCode.Substring(0, 2) == "sh")//上海
                {
                  MyCode = MyCode.Substring(2);
                  MyTable= SqlHelper.SelectTable(SqlHelper.SqlConnStringZX, System.Data.CommandType.Text, "select * from SHASE where gpdm='" + MyCode + "'");
                }
                else
                {
                  MyCode = MyCode.Substring(2);
                  MyTable = SqlHelper.SelectTable(SqlHelper.SqlConnStringZX, System.Data.CommandType.Text, "select * from SZNSE where gpdm='" + MyCode + "'");
                }
                for (int i = 0; i < MyTable.Rows.Count; i++)
                {
                    for (int c = 0; c < MyTable.Columns.Count; c++)
                    {
                        SB.Append(MyTable.Rows[i][c].ToString());
                        SB.Append(",");
                    }
                }
                context.Response.Write(SB.ToString());
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}