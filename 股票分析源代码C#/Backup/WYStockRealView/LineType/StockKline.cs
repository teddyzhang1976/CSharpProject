using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ZedGraph;
namespace WYStockRealView.LineType
{
    /// <summary>
    /// Summary description for SimpleDemo.
    /// </summary>
    public class StockKLineResponse : StockLineDrawBase
    {
       
        public StockKLineResponse()
            : base("StockLine",
                                    "StockKLineResponseDemo", DemoType.Bar)
        {
            GraphPane myPane = base.GraphPane;

            myPane.Title.Text = "UER/USD(欧/日)";
            myPane.XAxis.Title.Text = "交易日期";
            myPane.YAxis.Title.Text = "价格, $￥";

            StockPointList spl = new StockPointList();
            Random rand = new Random();

            // First day is jan 1st
            XDate xDate = new XDate(2002, 12, 1);
            double open = 50.0;

            for (int i = 0; i < 50; i++)
            {
                double x = xDate.XLDate;
                double close = open + rand.NextDouble() * 10.0 - 5.0;
                double hi = Math.Max(open, close) + rand.NextDouble() * 5.0;
                double low = Math.Min(open, close) - rand.NextDouble() * 3.0;

                StockPt pt = new StockPt(x, hi, low, open, close, 100);
                spl.Add(pt);
                open = close;
                xDate.AddHours(1);
                if (XDate.XLDateToDayOfWeek(xDate.XLDate) == 6)
                    xDate.AddDays(1.0);

            }


            JapaneseCandleStickItem myCurve = myPane.AddJapaneseCandleStick("蜡烛线", spl);
            myCurve.Stick.IsAutoSize = true;
            myCurve.Stick.Color = Color.Blue;

            myPane.XAxis.Type = AxisType.DateAsOrdinal;
            myPane.XAxis.Scale.Min = new XDate(2006, 1, 1);

            myPane.Chart.Fill = new Fill(Color.Black, Color.LightGoldenrodYellow, 45.0f);
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45.0f);

            //myPane.Chart.Fill = new Fill(Color.Black);
            //myPane.Fill = new Fill(Color.Black); 

            base.ZedGraphControl.AxisChange();

        }
    }
}
