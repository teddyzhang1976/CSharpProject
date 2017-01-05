using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// CommonSetting 的摘要说明
/// </summary>
public class CommonSetting
{
    public CommonSetting()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 当日成交线路径
    /// </summary>
public static string RealTimeLinePath = @"F:\公司项目\我赢网v2_1\软件客户端\看盘软件\WYStockRealView\WoYingFinaceService\WoYingFinaceService\bin\Debug\App_data\RealTimeLine\SHASE\";
    /// <summary>
    /// 实时行情传输路径
    /// </summary>
    public static string RemotePath = AppDomain.CurrentDomain.BaseDirectory + @"App_data\remote\";
}
