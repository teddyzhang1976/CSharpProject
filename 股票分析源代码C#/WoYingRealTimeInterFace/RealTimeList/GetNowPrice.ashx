<%@ WebHandler Language="C#" Class="GetNowPrice" %>

using System;
using System.Web;

//获取股票当前行情 sh为上海 sn为深圳
public class GetNowPrice : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
      
        if (context.Request.QueryString["stockcode"] != null)
        {
            string stockcode = context.Request.QueryString["stockcode"];
            context.Response.Write(GetReatNowPrice.GetStockInfo(stockcode));
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}