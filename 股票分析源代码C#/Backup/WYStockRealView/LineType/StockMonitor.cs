using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace StockMonitor.Controls
{
    public class ChartGraph : ContainerControl
    {
        private int axisSpace;
        private IContainer components;
        private Pen coordinateX_Pen;
        private Brush coordinateXFont_Brush;
        private int crossHair_y = -1;
        private int crossOverIndex;
        private Dictionary<int, ChartPanel> dicChartPanel = new Dictionary<int, ChartPanel>();
        private bool drawValuePanelFlag;
        private DataTable dtAllMsg = new DataTable();
        private int firstVisibleRecord;
        private IntervalType interval = IntervalType.Day;
        private DateTime lastMouseMoveTime = DateTime.Now;
        private int lastVisibleRecord;
        private Pen layBorder_Pen;
        private Brush layFont_Pen;
        private Pen leftGrid_Pen;
        private int leftPixSpace;
        private Pen leftY_Pen;
        private Brush leftYFont_Brush;
        private Brush leftyTip_Brush;
        private Brush leftyTipFont_Brush;
        private int panelID;
        public const int PIXSPACE_BOTTOM = 0x19;
        private int processBarValue;
        private object refresh_lock = new object();
        private Pen reticleLine_Pen;
        private Pen rightGrid_Pen;
        private int rightPixSpace;
        private Pen rightY_Pen;
        private Brush rightYFont_Brush;
        private Brush rightyTip_Brush;
        private Brush rightyTipFont_Brush;
        private int scrollStep = 1;
        private object selectedObject;
        private bool showCrossHair;
        private bool showLeftScale;
        [DefaultValue(true)]
        private bool showRightScale;
        private string timekeyField;
        private float titleHeight;
        private int vp_index = -1;
        private Brush xtip_Brush;
        private Brush xtipFont_Brush;

        public ChartGraph()
        {
            this.InitializeComponent();
            base.HandleCreated += new EventHandler(this.ChartGraph_HandleCreated);
        }

        public void AddCandle(string openfield, string highfield, string lowfield, string closefield, int panelID, bool displayTitleField)
        {
            if (((((openfield != null) && (highfield != null)) && ((lowfield != null) && (closefield != null))) && ((!this.dtAllMsg.Columns.Contains(openfield) && !this.dtAllMsg.Columns.Contains(highfield)) && (!this.dtAllMsg.Columns.Contains(lowfield) && !this.dtAllMsg.Columns.Contains(closefield)))) && this.dicChartPanel.ContainsKey(panelID))
            {
                ChartPanel panel = this.dicChartPanel[panelID];
                CandleSeries series = new CandleSeries();
                series = new CandleSeries();
                series.OpenField = openfield;
                series.HighField = highfield;
                series.LowField = lowfield;
                series.CloseField = closefield;
                series.Down_Color = Color.SkyBlue;
                series.Up_Color = Color.Red;
                series.DisplayTitleField = displayTitleField;
                DataColumn column = new DataColumn(openfield);
                DataColumn column2 = new DataColumn(highfield);
                DataColumn column3 = new DataColumn(lowfield);
                DataColumn column4 = new DataColumn(closefield);
                this.dtAllMsg.Columns.Add(column);
                this.dtAllMsg.Columns.Add(column2);
                this.dtAllMsg.Columns.Add(column3);
                this.dtAllMsg.Columns.Add(column4);
                panel.CandleSeries = series;
            }
        }

        public int AddChartPanel(int verticalPercent)
        {
            int y = 0;
            foreach (ChartPanel panel in this.dicChartPanel.Values)
            {
                y += Convert.ToInt32((double)((((double)panel.VerticalPercent) / 100.0) * base.Height));
            }
            int height = Convert.ToInt32((double)((((double)verticalPercent) / 100.0) * base.Height));
            ChartPanel panel2 = new ChartPanel();
            panel2.VerticalPercent = verticalPercent;
            panel2.PanelID = this.GetPanelID();
            panel2.RectPanel = new Rectangle(0, y, 0, height);
            this.dicChartPanel[panel2.PanelID] = panel2;
            return panel2.PanelID;
        }

        public void AddExponentialMovingAverage(string field, string displayName, Color lineColor, int interval, string source, int panelID)
        {
            if (((field != null) && !this.dtAllMsg.Columns.Contains(field)) && this.dicChartPanel.ContainsKey(panelID))
            {
                ChartPanel panel = this.dicChartPanel[panelID];
                TrendLineSeries item = new TrendLineSeries();
                item.LineColor = lineColor;
                item.Field = field;
                item.Source = source;
                item.DisplayName = displayName;
                item.Interval = interval;
                item.LineType = LineType.ExponentialMovingAverage;
                panel.TrendLineSeriesList.Add(item);
                DataColumn column = new DataColumn(field);
                this.dtAllMsg.Columns.Add(column);
            }
        }

        public void AddHistogram(string field, string displayName, Color upColor, Color downColor, int panelID, bool isVolumn)
        {
            if (((field != null) && !this.dtAllMsg.Columns.Contains(field)) && this.dicChartPanel.ContainsKey(panelID))
            {
                ChartPanel panel = this.dicChartPanel[panelID];
                HistogramSeries item = new HistogramSeries();
                item.Up_LineColor = upColor;
                item.IsVolume = isVolumn;
                item.Down_lineColor = downColor;
                item.Field = field;
                item.DisplayName = displayName;
                panel.HistoramSeriesList.Add(item);
                DataColumn column = new DataColumn(field);
                this.dtAllMsg.Columns.Add(column);
            }
        }

        public void AddSimpleMovingAverage(string field, string displayName, Color lineColor, int interval, string source, int panelID)
        {
            if (((field != null) && !this.dtAllMsg.Columns.Contains(field)) && this.dicChartPanel.ContainsKey(panelID))
            {
                ChartPanel panel = this.dicChartPanel[panelID];
                TrendLineSeries item = new TrendLineSeries();
                item.LineColor = lineColor;
                item.Field = field;
                item.DisplayName = displayName;
                item.Source = source;
                item.Interval = interval;
                item.LineType = LineType.SimpleMovingAverage;
                panel.TrendLineSeriesList.Add(item);
                DataColumn column = new DataColumn(field);
                this.dtAllMsg.Columns.Add(column);
            }
        }

        public void AddTrendLine(string field, string displayName, Color lineColor, int panelID)
        {
            if (((field != null) && !this.dtAllMsg.Columns.Contains(field)) && this.dicChartPanel.ContainsKey(panelID))
            {
                ChartPanel panel = this.dicChartPanel[panelID];
                TrendLineSeries item = new TrendLineSeries();
                item.LineColor = lineColor;
                item.Field = field;
                if ((displayName != null) && (displayName.Length > 0))
                {
                    item.DisplayName = displayName;
                }
                panel.TrendLineSeriesList.Add(item);
                DataColumn column = new DataColumn(field);
                this.dtAllMsg.Columns.Add(column);
            }
        }

        public void CalculateExponentialMovingAverage(TrendLineSeries tls, int rowIndex, double closeValue)
        {
            double num = (rowIndex > 0) ? Convert.ToDouble(this.dtAllMsg.Rows[rowIndex - 1][tls.Field].ToString()) : 0.0;
            double num2 = ((closeValue * 2.0) + (num * (tls.Interval - 1))) / ((double)(tls.Interval + 1));
            this.dtAllMsg.Rows[rowIndex][tls.Field] = num2;
        }

        public void CalculateIndicator()
        {
            int num = 0;
            for (int i = 0; i < this.dtAllMsg.Rows.Count; i++)
            {
                DataRow row = this.dtAllMsg.Rows[i];
                foreach (ChartPanel panel in this.dicChartPanel.Values)
                {
                    short num3 = 0;
                    foreach (TrendLineSeries series in panel.TrendLineSeriesList)
                    {
                        foreach (string str in panel.IndKdjField)
                        {
                            if (series.Field == str)
                            {
                                num3 = (short)(num3 + 1);
                            }
                        }
                    }
                    if (num3 == 3)
                    {
                        this.CalculateKDJ(i, panel.PanelID);
                    }
                    if ((panel.TrendLineSeriesList != null) && (panel.TrendLineSeriesList.Count > 0))
                    {
                        foreach (TrendLineSeries series2 in panel.TrendLineSeriesList)
                        {
                            switch (series2.LineType)
                            {
                                case LineType.SimpleMovingAverage:
                                    {
                                        Convert.ToDouble(row[series2.Source].ToString());
                                        this.CalculateSimpleMovingAverage(series2, i);
                                        continue;
                                    }
                                case LineType.ExponentialMovingAverage:
                                    {
                                        if (!(series2.Source == "SLOPE(C,21)+CLOSE"))
                                        {
                                            break;
                                        }
                                        if (panel.CandleSeries != null)
                                        {
                                            double num4 = Convert.ToDouble(row[panel.CandleSeries.CloseField].ToString());
                                            double closeValue = (this.Slope(0x15, i - 1, series2.Field) * 20.0) + Convert.ToDouble(num4);
                                            this.CalculateExponentialMovingAverage(series2, i, closeValue);
                                        }
                                        continue;
                                    }
                                default:
                                    {
                                        continue;
                                    }
                            }
                            if (series2.Source == "(CLOSE+HIGH+LOW)/3")
                            {
                                if (panel.CandleSeries != null)
                                {
                                    double num6 = Convert.ToDouble(row[panel.CandleSeries.CloseField].ToString());
                                    double num7 = Convert.ToDouble(row[panel.CandleSeries.HighField].ToString());
                                    double num8 = Convert.ToDouble(row[panel.CandleSeries.LowField].ToString());
                                    double num9 = ((num6 + num7) + num8) / 3.0;
                                    this.CalculateExponentialMovingAverage(series2, i, num9);
                                }
                            }
                            else
                            {
                                double num10 = Convert.ToDouble(row[series2.Source].ToString());
                                this.CalculateExponentialMovingAverage(series2, i, Convert.ToDouble(num10));
                            }
                        }
                    }
                    if ((panel.IndBuySellField[0] != null) && (panel.IndBuySellField[1] != null))
                    {
                        if (!this.dtAllMsg.Columns.Contains(panel.BsFlagField))
                        {
                            this.dtAllMsg.Columns.Add(panel.BsFlagField);
                        }
                        if (!this.dtAllMsg.Columns.Contains(panel.BsColorField))
                        {
                            this.dtAllMsg.Columns.Add(panel.BsColorField);
                        }
                        double num11 = Convert.ToDouble(row[panel.IndBuySellField[0]]);
                        double num12 = Convert.ToDouble(row[panel.IndBuySellField[1]]);
                        if (num11 >= num12)
                        {
                            if (num != 1)
                            {
                                row[panel.BsFlagField] = 1;
                            }
                            row[panel.BsColorField] = 1;
                            num = 1;
                            continue;
                        }
                        if (num11 < num12)
                        {
                            if (num != 2)
                            {
                                row[panel.BsFlagField] = 2;
                            }
                            row[panel.BsColorField] = 2;
                            num = 2;
                        }
                    }
                }
                int num13 = 50 + Convert.ToInt32((double)((((double)(i + 1)) / ((double)this.dtAllMsg.Rows.Count)) * 50.0));
                if (this.ProcessBarValue < num13)
                {
                    this.ProcessBarValue = num13;
                }
            }
            if (this.showCrossHair)
            {
                this.showCrossHair = !this.showCrossHair;
            }
            this.ProcessBarValue = 100;
        }

        public void CalculateKDJ(int rowIndex, int panelID)
        {
            double num = 50.0;
            double num2 = 50.0;
            if (this.dicChartPanel.ContainsKey(panelID))
            {
                ChartPanel panel = this.dicChartPanel[panelID];
                if (rowIndex > 0)
                {
                    double num3 = Convert.ToDouble(this.dtAllMsg.Rows[rowIndex - 1][panel.IndKdjField[0]]);
                    double num4 = Convert.ToDouble(this.dtAllMsg.Rows[rowIndex - 1][panel.IndKdjField[1]]);
                    num = ((num3 * 2.0) / 3.0) + (this.RSV(9, rowIndex, panel.MainPanelID) / 3.0);
                    num2 = ((num4 * 2.0) / 3.0) + (num / 3.0);
                }
                double num5 = (3.0 * num2) - (2.0 * num);
                this.dtAllMsg.Rows[rowIndex][panel.IndKdjField[0]] = num;
                this.dtAllMsg.Rows[rowIndex][panel.IndKdjField[1]] = num2;
                this.dtAllMsg.Rows[rowIndex][panel.IndKdjField[2]] = num5;
            }
        }

        public void CalculateSimpleMovingAverage(TrendLineSeries tls, int rowIndex)
        {
            double num = 0.0;
            if (rowIndex >= tls.Interval)
            {
                double num2 = Convert.ToDouble(this.dtAllMsg.Rows[rowIndex - 1][tls.Field].ToString());
                double num3 = Convert.ToDouble(this.dtAllMsg.Rows[rowIndex - tls.Interval][tls.Source].ToString());
                double result = 0.0;
                double.TryParse(this.dtAllMsg.Rows[rowIndex][tls.Source].ToString(), out result);
                num = num2 + ((result - num3) / ((double)tls.Interval));
                this.dtAllMsg.Rows[rowIndex][tls.Field] = num;
            }
            else
            {
                for (int i = (rowIndex - tls.Interval) + 1; i <= rowIndex; i++)
                {
                    if ((i >= 0) && (rowIndex >= (tls.Interval - 1)))
                    {
                        double num6 = 0.0;
                        double.TryParse(this.dtAllMsg.Rows[i][tls.Source].ToString(), out num6);
                        num += num6;
                        if (i == rowIndex)
                        {
                            num /= (double)tls.Interval;
                            this.dtAllMsg.Rows[i][tls.Field] = num;
                        }
                    }
                }
            }
        }

        private void ChartGraph_HandleCreated(object sender, EventArgs e)
        {
            this.InitGraph();
        }

        private void ChartGraph_LostFocus(object sender, EventArgs e)
        {
            base.Focus();
        }

        private void ChartGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.showCrossHair)
            {
                this.selectedObject = null;
            }
            if (this.selectedObject != null)
            {
                if (this.lastMouseMoveTime.AddTicks(0xf4240L) < DateTime.Now)
                {
                    this.DrawGraph();
                }
                this.lastMouseMoveTime = DateTime.Now;
                this.drawValuePanelFlag = true;
            }
        }

        private void ChartGraph_SizeChanged(object sender, EventArgs e)
        {
            if ((base.Size.Width != 0) && (base.Size.Height != 0))
            {
                this.ResizeGraph();
                this.RefreshGraph();
            }
        }

        public void checkMouseMoveLoop()
        {
            int num = 0x4c4b40;
            while (true)
            {
                if ((this.lastMouseMoveTime.AddTicks((long)num) <= DateTime.Now) && this.drawValuePanelFlag)
                {
                    this.drawValuePanelFlag = !this.drawValuePanelFlag;
                    if ((this.selectedObject != null) && base.IsHandleCreated)
                    {
                        base.BeginInvoke(new ShowValuePanelDelegate(this.ShowValuePanel));
                    }
                }
                Thread.Sleep(100);
            }
        }

        public void ClearGraph()
        {
            this.dtAllMsg.Clear();
            this.firstVisibleRecord = 0;
            this.lastVisibleRecord = 0;
            this.showCrossHair = false;
            this.RefreshGraph();
        }

        public void CrossHairScrollLeft()
        {
            int crossOverIndex = this.crossOverIndex;
            this.crossOverIndex = crossOverIndex - 1;
            if (this.crossOverIndex < 0)
            {
                this.crossOverIndex = 0;
            }
            if (crossOverIndex < this.firstVisibleRecord)
            {
                this.ScrollLeft(1);
            }
        }

        public void CrossHairScrollRight()
        {
            int crossOverIndex = this.crossOverIndex;
            this.crossOverIndex = crossOverIndex + 1;
            if ((this.dtAllMsg.Rows.Count > 0) && (this.crossOverIndex > (this.dtAllMsg.Rows.Count - 1)))
            {
                this.crossOverIndex = this.dtAllMsg.Rows.Count - 1;
            }
            int num2 = ((base.Width - this.leftPixSpace) - this.rightPixSpace) / this.axisSpace;
            if ((this.dtAllMsg.Rows.Count == 0) && (this.crossOverIndex >= num2))
            {
                this.crossOverIndex = num2;
            }
            if (crossOverIndex >= (this.lastVisibleRecord - 1))
            {
                this.ScrollRight(1);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DrawBackGround(Graphics g)
        {
            foreach (ChartPanel panel in this.dicChartPanel.Values)
            {
                Rectangle rect = new Rectangle(0, panel.RectPanel.Y, base.Width - 2, panel.RectPanel.Height);
                if (panel.BackColor != Color.Black)
                {
                    g.FillRectangle(panel.BgBrush, rect);
                }
                g.DrawRectangle(this.layBorder_Pen, rect);
            }
        }

        public void DrawCrossHair(Graphics g)
        {
            Point crossHairPoint = this.GetCrossHairPoint();
            if (this.crossHair_y != -1)
            {
                crossHairPoint.Y = this.crossHair_y;
            }
            if (this.showCrossHair)
            {
                foreach (ChartPanel panel in this.dicChartPanel.Values)
                {
                    if ((crossHairPoint.Y >= panel.RectPanel.Y) && (crossHairPoint.Y <= ((panel.RectPanel.Y + panel.RectPanel.Height) - 0x19)))
                    {
                        g.DrawLine(this.reticleLine_Pen, this.LeftPixSpace, crossHairPoint.Y, base.Width - this.RightPixSpace, crossHairPoint.Y);
                    }
                    int num = (this.leftPixSpace + (this.axisSpace * ((this.crossOverIndex - this.firstVisibleRecord) + 1))) + (this.axisSpace / 2);
                    g.DrawLine(this.reticleLine_Pen, num, panel.RectPanel.Y, num, (panel.RectPanel.Y + panel.RectPanel.Height) - 0x19);
                    if ((this.crossOverIndex >= (this.firstVisibleRecord - 1)) && (this.crossOverIndex < this.lastVisibleRecord))
                    {
                        Font font = new Font("New Times Roman", 9f, FontStyle.Bold);
                        SizeF ef = g.MeasureString(GetCalenderFormatTimeKey(this.dtAllMsg.Rows[this.crossOverIndex][this.timekeyField].ToString(), this.Interval), font);
                        RectangleF rect = new RectangleF(num - (ef.Width / 2f), (float)(((panel.RectPanel.Y + panel.RectPanel.Height) - 0x19) + 1), ef.Width, ef.Height);
                        g.FillRectangle(this.xtip_Brush, rect);
                        g.DrawString(GetCalenderFormatTimeKey(this.dtAllMsg.Rows[this.crossOverIndex][this.timekeyField].ToString(), this.Interval), font, this.xtipFont_Brush, rect);
                        if ((crossHairPoint.Y >= panel.RectPanel.Y) && (crossHairPoint.Y <= ((panel.RectPanel.Y + panel.RectPanel.Height) - 0x19)))
                        {
                            double currentValue = this.GetCurrentValue();
                            if (this.showLeftScale)
                            {
                                string valueByTick = GetValueByTick(currentValue, panel.YScaleTick);
                                Font font2 = new Font("New Times Roman", 9f, FontStyle.Bold);
                                SizeF ef3 = g.MeasureString(valueByTick, font2);
                                RectangleF ef4 = new RectangleF(this.LeftPixSpace - ef3.Width, crossHairPoint.Y - (ef3.Height / 2f), ef3.Width, ef3.Height);
                                g.FillRectangle(this.leftyTip_Brush, ef4);
                                g.DrawString(valueByTick, font2, this.leftyTipFont_Brush, ef4);
                            }
                            if (this.ShowRightScale)
                            {
                                string text = GetValueByTick(currentValue, panel.YScaleTick);
                                Font font3 = new Font("New Times Roman", 9f, FontStyle.Bold);
                                SizeF ef5 = g.MeasureString(text, font3);
                                RectangleF ef6 = new RectangleF((float)((base.Width - this.RightPixSpace) + 1), crossHairPoint.Y - (ef5.Height / 2f), ef5.Width, ef5.Height);
                                g.FillRectangle(this.rightyTip_Brush, ef6);
                                g.DrawString(text, font3, this.rightyTipFont_Brush, ef6);
                            }
                        }
                    }
                }
            }
        }

        public void DrawGraph()
        {
            this.PaintGraph(this.DisplayRectangle);
        }

        public void DrawGraph(Rectangle drawRectangle)
        {
            this.PaintGraph(drawRectangle);
        }

        public void DrawProcessBar(Graphics g)
        {
            int num = 100;
            g.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle rect = new Rectangle((base.Width / 2) - num, (base.Height / 2) - num, num * 2, num * 2);
            if ((this.processBarValue > 0) && (this.processBarValue <= 100))
            {
                Color skyBlue = Color.SkyBlue;
                StringBuilder builder = new StringBuilder();
                if (this.processBarValue < 50)
                {
                    builder.Append("Loading...\r\n");
                }
                else if ((this.processBarValue >= 50) && (this.processBarValue < 100))
                {
                    builder.Append("Loading...\r\n");
                    skyBlue = Color.Red;
                }
                else
                {
                    builder.Append("Complete\r\n");
                    skyBlue = Color.Teal;
                }
                builder.Append(this.processBarValue.ToString() + "%");
                Brush brush = new SolidBrush(Color.FromArgb(90, skyBlue));
                Pen pen = new Pen(skyBlue, 2f);
                int num2 = 270;
                int num3 = Convert.ToInt32((double)((((double)this.processBarValue) / 100.0) * 360.0));
                g.FillPie(brush, rect, (float)num2, (float)num3);
                Rectangle rectangle2 = new Rectangle(rect.X, rect.Y, rect.Width - 2, rect.Height - 2);
                if (this.processBarValue == 100)
                {
                    g.DrawEllipse(pen, rectangle2);
                    this.processBarValue = 0;
                }
                else
                {
                    g.DrawPie(pen, rectangle2, (float)num2, (float)(num3 + 1));
                }
                Font font = new Font("New Times Roman", 12f, FontStyle.Italic | FontStyle.Bold);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                SizeF ef = g.MeasureString(builder.ToString(), font);
                g.DrawString(builder.ToString(), font, Brushes.White, new PointF((float)(base.Width / 2), (base.Height / 2) - (ef.Height / 2f)), format);
                brush.Dispose();
                pen.Dispose();
                format.Dispose();
            }
            g.SmoothingMode = SmoothingMode.Default;
        }

        public void DrawScale(Graphics g)
        {
        Label_047A:
            foreach (ChartPanel panel in this.dicChartPanel.Values)
            {
                double sMin = 0.0;
                double step = 0.0;
                int n = 0;
                int num4 = panel.RectPanel.Y + panel.RectPanel.Height;
                int workSpaceY = this.GetWorkSpaceY(panel.PanelID);
                if (base.Height >= 0x19)
                {
                    g.DrawLine(this.coordinateX_Pen, 0, num4 - 0x19, base.Width, num4 - 0x19);
                }
                bool flag = false;
                if (this.showLeftScale && (this.leftPixSpace <= base.Width))
                {
                    if (this.LeftPixSpace <= base.Width)
                    {
                        g.DrawLine(this.leftY_Pen, this.leftPixSpace, panel.RectPanel.Y + 1, this.leftPixSpace, num4 - 0x19);
                    }
                    if (this.processBarValue == 0)
                    {
                        Font font = this.Font;
                        SizeF ef = g.MeasureString(" ", font);
                        n = (((int)(((float)workSpaceY) / ef.Height)) * 40) / 30;
                        GridScale(panel.MinValue, panel.MaxValue, n, ref sMin, ref step, panel.YScaleTick);
                        int num6 = 0;
                        int gridInterval = panel.GridInterval;
                        while (sMin <= panel.MaxValue)
                        {
                            if (sMin > panel.MinValue)
                            {
                                if ((num6 != 0) && ((num6 % gridInterval) == 0))
                                {
                                    ef = g.MeasureString(GetValueByTick(sMin, panel.YScaleTick), font);
                                    g.DrawLine(this.leftY_Pen, (float)(this.LeftPixSpace - 10), this.GetValueYPixel(panel, sMin), (float)this.LeftPixSpace, this.GetValueYPixel(panel, sMin));
                                    g.DrawString(GetValueByTick(sMin, panel.YScaleTick), font, this.leftYFont_Brush, new RectangleF((this.LeftPixSpace - 10) - ef.Width, this.GetValueYPixel(panel, sMin) - (ef.Height / 2f), ef.Width, ef.Height));
                                    flag = true;
                                    g.DrawLine(this.leftGrid_Pen, (float)this.RightPixSpace, this.GetValueYPixel(panel, sMin), (float)(base.Width - this.RightPixSpace), this.GetValueYPixel(panel, sMin));
                                }
                                else
                                {
                                    g.DrawLine(this.leftY_Pen, (float)(this.LeftPixSpace - 5), this.GetValueYPixel(panel, sMin), (float)this.LeftPixSpace, this.GetValueYPixel(panel, sMin));
                                }
                            }
                            sMin += step;
                            num6++;
                        }
                    }
                }
                if (this.showRightScale && (this.rightPixSpace <= base.Width))
                {
                    if ((base.Width - this.RightPixSpace) >= this.LeftPixSpace)
                    {
                        g.DrawLine(this.rightY_Pen, (int)(base.Width - this.rightPixSpace), (int)(panel.RectPanel.Y + 1), (int)(base.Width - this.rightPixSpace), (int)(num4 - 0x19));
                    }
                    if (this.processBarValue != 0)
                    {
                        goto Label_047A;
                    }
                    Font font2 = this.Font;
                    SizeF ef2 = g.MeasureString(" ", font2);
                    n = (((int)(((float)workSpaceY) / ef2.Height)) * 40) / 30;
                    GridScale(panel.MinValue, panel.MaxValue, n, ref sMin, ref step, panel.YScaleTick);
                    int num8 = 0;
                    int num9 = panel.GridInterval;
                    while (sMin <= panel.MaxValue)
                    {
                        if (sMin > panel.MinValue)
                        {
                            if ((num8 != 0) && ((num8 % num9) == 0))
                            {
                                g.DrawLine(this.rightY_Pen, (float)(base.Width - this.RightPixSpace), this.GetValueYPixel(panel, sMin), (float)((base.Width - this.RightPixSpace) + 10), this.GetValueYPixel(panel, sMin));
                                g.DrawString(GetValueByTick(sMin, panel.YScaleTick), font2, this.rightYFont_Brush, new RectangleF((float)((base.Width - this.RightPixSpace) + 10), this.GetValueYPixel(panel, sMin) - (ef2.Height / 2f), (float)this.RightPixSpace, ef2.Height));
                                if (!flag)
                                {
                                    flag = true;
                                    g.DrawLine(this.rightGrid_Pen, (float)this.RightPixSpace, this.GetValueYPixel(panel, sMin), (float)(base.Width - this.RightPixSpace), this.GetValueYPixel(panel, sMin));
                                }
                            }
                            else
                            {
                                g.DrawLine(this.rightY_Pen, (float)(base.Width - this.RightPixSpace), this.GetValueYPixel(panel, sMin), (float)((base.Width - this.RightPixSpace) + 5), this.GetValueYPixel(panel, sMin));
                            }
                        }
                        sMin += step;
                        num8++;
                    }
                }
            }
        }

        public void DrawSeries(Graphics g)
        {
            int num = 0;
            int num2 = this.firstVisibleRecord - 1;
            int lastVisibleRecord = this.lastVisibleRecord;
            if ((num2 >= 0) && (lastVisibleRecord >= 1))
            {
                for (int i = num2; i < lastVisibleRecord; i++)
                {
                    string str = this.dtAllMsg.Rows[i][this.timekeyField].ToString();
                    DataRow row = this.dtAllMsg.Rows[i];
                    if (row != null)
                    {
                        float num5 = (this.leftPixSpace + (((i + 2) - this.firstVisibleRecord) * this.axisSpace)) - (this.axisSpace / 2);
                        string calenderFormatTimeKey = GetCalenderFormatTimeKey(str, this.Interval);
                        SizeF ef = g.MeasureString(calenderFormatTimeKey, this.Font);
                        foreach (ChartPanel panel in this.dicChartPanel.Values)
                        {
                            int num6 = panel.RectPanel.Y + panel.RectPanel.Height;
                            if (i == (this.firstVisibleRecord - 1))
                            {
                                g.DrawLine(this.coordinateX_Pen, num5, (float)(num6 - 0x19), num5, (float)((num6 - 0x19) + 6));
                                g.DrawString(calenderFormatTimeKey, this.Font, this.coordinateXFont_Brush, new PointF(num5 - (ef.Width / 2f), (float)((num6 - 0x19) + 6)));
                            }
                            if (((num5 - this.LeftPixSpace) > (ef.Width + 20f)) && (num == 0))
                            {
                                num = i - (this.firstVisibleRecord - 1);
                            }
                            if ((num != 0) && (((i - (this.firstVisibleRecord - 1)) % num) == 0))
                            {
                                g.DrawString(calenderFormatTimeKey, this.Font, this.coordinateXFont_Brush, new PointF(num5 - (ef.Width / 2f), (float)((num6 - 0x19) + 6)));
                                g.DrawLine(this.coordinateX_Pen, num5, (float)(num6 - 0x19), num5, (float)((num6 - 0x19) + 6));
                            }
                            else
                            {
                                g.DrawLine(this.coordinateX_Pen, num5, (float)(num6 - 0x19), num5, (float)((num6 - 0x19) + 3));
                            }
                            if (panel.CandleSeries != null)
                            {
                                double chartValue = Convert.ToDouble(row[panel.CandleSeries.OpenField]);
                                double num8 = Convert.ToDouble(row[panel.CandleSeries.HighField]);
                                double num9 = Convert.ToDouble(row[panel.CandleSeries.LowField]);
                                double num10 = Convert.ToDouble(row[panel.CandleSeries.CloseField]);
                                if (this.GetWorkSpaceY(panel.PanelID) > 0)
                                {
                                    if (this.dtAllMsg.Columns.Contains(panel.BsFlagField) && !(row[panel.BsFlagField] is DBNull))
                                    {
                                        Font font = new Font("ËÎÌו", 12f, FontStyle.Bold);
                                        SizeF ef2 = g.MeasureString("B", font);
                                        switch (Convert.ToInt32(row[panel.BsFlagField]))
                                        {
                                            case 1:
                                                g.DrawString("B", font, Brushes.Red, new PointF(((int)num5) - (ef2.Width / 2f), this.GetValueYPixel(panel, num8) - 20f));
                                                break;

                                            case 2:
                                                g.DrawString("S", font, Brushes.SkyBlue, new PointF(((int)num5) - (ef2.Width / 2f), (this.GetValueYPixel(panel, num9) - 15f) + ef2.Height));
                                                break;
                                        }
                                    }
                                    int num12 = 0;
                                    if (this.dtAllMsg.Columns.Contains(panel.BsColorField) && !(row[panel.BsColorField] is DBNull))
                                    {
                                        num12 = Convert.ToInt32(row[panel.BsColorField]);
                                    }
                                    if (chartValue <= num10)
                                    {
                                        float height = ((num10 - chartValue) != 0.0) ? ((float)(((num10 - chartValue) / (panel.MaxValue - panel.MinValue)) * this.GetWorkSpaceY(panel.PanelID))) : 1f;
                                        if (height < 1f)
                                        {
                                            height = 1f;
                                        }
                                        RectangleF ef3 = new RectangleF((float)(((int)num5) - (this.axisSpace / 4)), this.GetValueYPixel(panel, num10), (float)(((this.axisSpace / 4) * 2) + 1), height);
                                        Brush red = null;
                                        switch (num12)
                                        {
                                            case 0:
                                                red = panel.CandleSeries.UpLine_Brush;
                                                break;

                                            case 1:
                                                red = Brushes.Red;
                                                break;

                                            case 2:
                                                red = Brushes.SkyBlue;
                                                break;
                                        }
                                        Pen pen = new Pen(red);
                                        g.DrawLine(pen, num5, this.GetValueYPixel(panel, num8), num5, this.GetValueYPixel(panel, num9));
                                        g.FillRectangle(panel.BgBrush, new Rectangle(((int)ef3.X) + 1, ((int)ef3.Y) + 1, ((int)ef3.Width) - 2, ((int)ef3.Height) - 1));
                                        g.DrawRectangle(pen, new Rectangle((int)ef3.X, (int)ef3.Y, (int)ef3.Width, (int)ef3.Height));
                                        pen.Dispose();
                                    }
                                    else
                                    {
                                        float num14 = ((chartValue - num10) != 0.0) ? ((float)(((chartValue - num10) / (panel.MaxValue - panel.MinValue)) * this.GetWorkSpaceY(panel.PanelID))) : 1f;
                                        if (num14 < 1f)
                                        {
                                            num14 = 1f;
                                        }
                                        RectangleF rect = new RectangleF((float)(((int)num5) - (this.axisSpace / 4)), this.GetValueYPixel(panel, chartValue), (float)(((this.axisSpace / 4) * 2) + 1), num14);
                                        Brush brush = null;
                                        switch (num12)
                                        {
                                            case 0:
                                                brush = panel.CandleSeries.DownLine_Brush;
                                                break;

                                            case 1:
                                                brush = Brushes.Red;
                                                break;

                                            case 2:
                                                brush = Brushes.SkyBlue;
                                                break;
                                        }
                                        Pen pen2 = new Pen(brush);
                                        g.DrawLine(pen2, num5, this.GetValueYPixel(panel, num8), num5, this.GetValueYPixel(panel, num9));
                                        g.FillRectangle(brush, rect);
                                        pen2.Dispose();
                                    }
                                    if (panel.CandleSeries.HasSelect)
                                    {
                                        if (this.showCrossHair)
                                        {
                                            panel.CandleSeries.HasSelect = false;
                                        }
                                        else
                                        {
                                            int num15 = this.GetMaxVisibleRecord() / 30;
                                            if (num15 < 2)
                                            {
                                                num15 = 3;
                                            }
                                            if ((i % num15) == 0)
                                            {
                                                RectangleF ef5 = new RectangleF((float)(((int)num5) - 3), this.GetValueYPixel(panel, num10), 6f, 6f);
                                                g.FillRectangle(Brushes.White, ef5);
                                            }
                                        }
                                    }
                                }
                            }
                        Label_08D9:
                            foreach (HistogramSeries series in panel.HistoramSeriesList)
                            {
                                if (!(row[series.Field].ToString() != ""))
                                {
                                    goto Label_08D9;
                                }
                                double num16 = Convert.ToDouble(row[series.Field]);
                                RectangleF ef6 = new RectangleF((float)(((int)num5) - (this.axisSpace / 4)), this.GetValueYPixel(panel, num16), (float)(((this.axisSpace / 5) * 2) + 1), (float)(((num16 / panel.MaxValue) * this.GetWorkSpaceY(panel.PanelID)) - 1.0));
                                if ((series.IsVolume && this.dicChartPanel.ContainsKey(panel.MainPanelID)) && (this.dicChartPanel[panel.MainPanelID].CandleSeries != null))
                                {
                                    double num17 = Convert.ToDouble(row[this.dicChartPanel[panel.MainPanelID].CandleSeries.OpenField]);
                                    double num18 = Convert.ToDouble(row[this.dicChartPanel[panel.MainPanelID].CandleSeries.CloseField]);
                                    if (num17 >= num18)
                                    {
                                        g.FillRectangle(panel.BgBrush, ef6);
                                        Pen pen3 = new Pen(series.Up_LineBrush);
                                        g.DrawRectangle(pen3, new Rectangle((int)ef6.X, (int)ef6.Y, (int)ef6.Width, ((int)ef6.Height) + 1));
                                        pen3.Dispose();
                                    }
                                    else
                                    {
                                        g.FillRectangle(series.Down_lineBrush, ef6);
                                    }
                                }
                                else if (num16 >= 0.0)
                                {
                                    g.FillRectangle(panel.BgBrush, ef6);
                                    Pen pen4 = new Pen(series.Up_LineBrush);
                                    g.DrawRectangle(pen4, new Rectangle((int)ef6.X, (int)ef6.Y, (int)ef6.Width, ((int)ef6.Height) + 1));
                                    pen4.Dispose();
                                }
                                else
                                {
                                    g.FillRectangle(series.Up_LineBrush, ef6);
                                }
                                if (series.HasSelect)
                                {
                                    if (this.showCrossHair)
                                    {
                                        series.HasSelect = false;
                                        goto Label_08D9;
                                    }
                                    int num19 = this.GetMaxVisibleRecord() / 30;
                                    if (num19 < 2)
                                    {
                                        num19 = 2;
                                    }
                                    if ((i % num19) == 0)
                                    {
                                        RectangleF ef7 = new RectangleF((float)(((int)num5) - 3), this.GetValueYPixel(panel, num16) - 3f, 6f, 6f);
                                        g.FillRectangle(Brushes.Yellow, ef7);
                                    }
                                }
                            }
                            for (int j = 0; j < panel.TrendLineSeriesList.Count; j++)
                            {
                                TrendLineSeries series2 = panel.TrendLineSeriesList[j];
                                PointF tf = new PointF();
                                PointF tf2 = new PointF();
                                if (row[series2.Field].ToString() != "")
                                {
                                    double num21 = Convert.ToDouble(row[series2.Field]);
                                    if (this.dtAllMsg.Rows.Count == 1)
                                    {
                                        tf = new PointF((float)(((int)num5) - (this.axisSpace / 4)), this.GetValueYPixel(panel, num21));
                                        tf2 = new PointF((float)(((((int)num5) - (this.axisSpace / 4)) + ((this.axisSpace / 4) * 2)) + 1), this.GetValueYPixel(panel, num21));
                                    }
                                    else
                                    {
                                        DataRow row2 = null;
                                        for (int k = i - 1; k >= num2; k--)
                                        {
                                            this.dtAllMsg.Rows[k][this.timekeyField].ToString();
                                            DataRow row3 = this.dtAllMsg.Rows[k];
                                            if (row3[series2.Field].ToString() != "")
                                            {
                                                int num23 = (this.leftPixSpace + (((k + 2) - this.firstVisibleRecord) * this.axisSpace)) - (this.axisSpace / 2);
                                                double num24 = Convert.ToDouble(row3[series2.Field]);
                                                tf = new PointF((float)num23, this.GetValueYPixel(panel, num24));
                                                if (k != (i - 1))
                                                {
                                                    int num25 = (this.leftPixSpace + (((i + 1) - this.firstVisibleRecord) * this.axisSpace)) - (this.axisSpace / 2);
                                                    tf2 = new PointF((float)num25, this.GetValueYPixel(panel, num24));
                                                    if (((tf.Y <= (num6 - 0x19)) && (tf.Y >= (panel.RectPanel.Y + this.titleHeight))) && ((tf2.Y < (num6 - 0x19)) && (tf2.Y >= (panel.RectPanel.Y + this.titleHeight))))
                                                    {
                                                        g.DrawLine(series2.LinePen, tf, tf2);
                                                    }
                                                    tf = new PointF((float)num25, this.GetValueYPixel(panel, num24));
                                                }
                                                row2 = row3;
                                                break;
                                            }
                                        }
                                        tf2 = new PointF((float)((int)num5), this.GetValueYPixel(panel, num21));
                                        if ((((row2 != null) && (tf.Y <= (num6 - 0x19))) && ((tf.Y >= (panel.RectPanel.Y + this.titleHeight)) && (tf2.Y < (num6 - 0x19)))) && (tf2.Y >= (panel.RectPanel.Y + this.titleHeight)))
                                        {
                                            g.DrawLine(series2.LinePen, tf, tf2);
                                        }
                                    }
                                    if (series2.HasSelect)
                                    {
                                        if (this.showCrossHair)
                                        {
                                            series2.HasSelect = false;
                                        }
                                        else
                                        {
                                            int num26 = this.GetMaxVisibleRecord() / 30;
                                            if (num26 < 1)
                                            {
                                                num26 = 1;
                                            }
                                            if ((i % num26) == 0)
                                            {
                                                RectangleF ef8 = new RectangleF((float)(((int)num5) - 3), this.GetValueYPixel(panel, num21) - 3f, 6f, 6f);
                                                if (ef8.Y < (num6 - 0x19))
                                                {
                                                    g.FillRectangle(series2.LineBrush, ef8);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                foreach (ChartPanel panel2 in this.dicChartPanel.Values)
                {
                    if (((panel2.CandleSeries == null) || (this.dtAllMsg.Rows.Count <= 0)) || ((panel2.MaxRecord == -1) || (panel2.MinRecord == -1)))
                    {
                        continue;
                    }
                    int num1 = panel2.RectPanel.Height;
                    DataRow row4 = this.dtAllMsg.Rows[panel2.MaxRecord];
                    double num27 = Convert.ToDouble(row4[panel2.CandleSeries.HighField]);
                    float x = (this.leftPixSpace + (((panel2.MaxRecord + 2) - this.firstVisibleRecord) * this.axisSpace)) - (this.axisSpace / 2);
                    float valueYPixel = this.GetValueYPixel(panel2, num27);
                    SizeF ef9 = g.MeasureString(num27.ToString("0.00"), this.Font);
                    PointF point = new PointF();
                    if (x < (this.leftPixSpace + ef9.Width))
                    {
                        point = new PointF(x, valueYPixel + (ef9.Height / 2f));
                    }
                    else if (x > ((base.Width - this.rightPixSpace) - ef9.Width))
                    {
                        point = new PointF(x - ef9.Width, valueYPixel + (ef9.Height / 2f));
                    }
                    else if (x < (base.Width / 2))
                    {
                        point = new PointF(x - ef9.Width, valueYPixel + (ef9.Height / 2f));
                    }
                    else
                    {
                        point = new PointF(x, valueYPixel + (ef9.Height / 2f));
                    }
                    g.DrawString(num27.ToString("0.00"), this.Font, Brushes.White, point);
                    g.DrawLine(Pens.White, x, valueYPixel, point.X + (ef9.Width / 2f), point.Y);
                    DataRow row5 = this.dtAllMsg.Rows[panel2.MinRecord];
                    double num30 = Convert.ToDouble(row5[panel2.CandleSeries.LowField]);
                    SizeF ef10 = g.MeasureString(num30.ToString("0.00"), this.Font);
                    float num31 = (this.leftPixSpace + (((panel2.MinRecord + 2) - this.firstVisibleRecord) * this.axisSpace)) - (this.axisSpace / 2);
                    float num32 = this.GetValueYPixel(panel2, num30);
                    PointF tf4 = new PointF();
                    if (num31 < (this.leftPixSpace + ef10.Width))
                    {
                        tf4 = new PointF(num31, num32 - ((ef10.Height * 3f) / 2f));
                    }
                    else if (num31 > ((base.Width - this.rightPixSpace) - ef10.Width))
                    {
                        tf4 = new PointF(num31 - ef10.Width, num32 - ((ef10.Height * 3f) / 2f));
                    }
                    else if (num31 < (base.Width / 2))
                    {
                        tf4 = new PointF(num31 - ef10.Width, num32 - ((ef10.Height * 3f) / 2f));
                    }
                    else
                    {
                        tf4 = new PointF(num31, num32 - ((ef10.Height * 3f) / 2f));
                    }
                    g.DrawString(num30.ToString("0.00"), this.Font, Brushes.White, tf4);
                    g.DrawLine(Pens.White, num31, num32, tf4.X + (ef10.Width / 2f), tf4.Y + ef10.Height);
                }
            }
        }

        private void DrawTitle(Graphics g)
        {
            foreach (ChartPanel panel in this.dicChartPanel.Values)
            {
                float leftPixSpace = this.LeftPixSpace;
                Font font = this.Font;
                SizeF ef = g.MeasureString(panel.IssueCodeTitle, font);
                if ((leftPixSpace + ef.Width) <= (base.Width - this.RightPixSpace))
                {
                    g.DrawString(panel.IssueCodeTitle, font, this.layFont_Pen, new PointF(leftPixSpace, (float)(panel.RectPanel.Y + 5)));
                }
                leftPixSpace += ef.Width;
                DataRow row = null;
                if ((this.dtAllMsg.Rows.Count > 0) && ((this.lastVisibleRecord > 0) & (this.processBarValue == 0)))
                {
                    int num2 = this.lastVisibleRecord - 1;
                    if (this.showCrossHair && (this.crossOverIndex <= this.lastVisibleRecord))
                    {
                        num2 = this.crossOverIndex - 1;
                    }
                    this.dtAllMsg.Rows[num2][this.timekeyField].ToString();
                    row = this.dtAllMsg.Rows[num2];
                    foreach (DataColumn column in this.dtAllMsg.Columns)
                    {
                        string columnName = column.ColumnName;
                        string displayName = null;
                        bool flag = false;
                        Color white = Color.White;
                        if ((panel.CandleSeries != null) && panel.CandleSeries.DisplayTitleField)
                        {
                            if (columnName == panel.CandleSeries.OpenField)
                            {
                                white = panel.CandleSeries.OpenTitleColor;
                                flag = true;
                                goto Label_0305;
                            }
                            if (columnName == panel.CandleSeries.HighField)
                            {
                                white = panel.CandleSeries.HighTitleColor;
                                flag = true;
                                goto Label_0305;
                            }
                            if (columnName == panel.CandleSeries.LowField)
                            {
                                white = panel.CandleSeries.LowTitleColor;
                                flag = true;
                                goto Label_0305;
                            }
                            if (columnName == panel.CandleSeries.CloseField)
                            {
                                white = panel.CandleSeries.CloseTitleColor;
                                flag = true;
                                goto Label_0305;
                            }
                        }
                        if ((panel.TrendLineSeriesList != null) && (panel.TrendLineSeriesList.Count > 0))
                        {
                            foreach (TrendLineSeries series in panel.TrendLineSeriesList)
                            {
                                if ((series.Field == columnName) && (series.DisplayName != null))
                                {
                                    white = series.LineColor;
                                    flag = true;
                                    displayName = series.DisplayName;
                                    goto Label_0305;
                                }
                            }
                        }
                        if ((panel.HistoramSeriesList != null) && (panel.HistoramSeriesList.Count > 0))
                        {
                            foreach (HistogramSeries series2 in panel.HistoramSeriesList)
                            {
                                if ((series2.Field == columnName) && (series2.DisplayName != null))
                                {
                                    white = Color.White;
                                    flag = true;
                                    displayName = series2.DisplayName;
                                    break;
                                }
                            }
                        }
                    Label_0305:
                        if (flag)
                        {
                            string text = columnName + " ";
                            if (displayName != null)
                            {
                                text = displayName + " ";
                                if (displayName == string.Empty)
                                {
                                    text = displayName;
                                }
                            }
                            if ((row != null) && this.dtAllMsg.Columns.Contains(columnName))
                            {
                                double result = 0.0;
                                double.TryParse(row[columnName].ToString(), out result);
                                text = text + GetValueByTick(result, panel.YScaleTick);
                            }
                            SizeF ef2 = g.MeasureString(text, font);
                            if ((leftPixSpace + ef2.Width) <= (base.Width - this.RightPixSpace))
                            {
                                Brush brush = new SolidBrush(white);
                                g.DrawString(text, font, brush, new PointF(leftPixSpace, (float)(panel.RectPanel.Y + 5)));
                                brush.Dispose();
                            }
                            leftPixSpace += ef2.Width;
                        }
                    }
                    continue;
                }
            }
        }

        public void DrawValuePanel(Graphics g)
        {
            if (this.selectedObject != null)
            {
                if ((this.vp_index > 0) && (this.vp_index <= (this.lastVisibleRecord - 1)))
                {
                    Point crossHairPoint = this.GetCrossHairPoint();
                    double tick = 0.01;
                    foreach (ChartPanel panel in this.dicChartPanel.Values)
                    {
                        if (((crossHairPoint.Y >= panel.RectPanel.Y) && (crossHairPoint.Y <= (panel.RectPanel.Y + panel.RectPanel.Height))) && (this.GetWorkSpaceY(panel.PanelID) > 0))
                        {
                            tick = panel.YScaleTick;
                        }
                    }
                    DataRow row = this.dtAllMsg.Rows[this.vp_index];
                    new Point(this.GetCrossHairPoint().X + 10, this.GetCrossHairPoint().Y);
                    string text = this.timekeyField + ":" + GetCalenderFormatTimeKey(row[this.timekeyField].ToString(), this.interval);
                    Font font = new Font("New Times Roman", 10f, FontStyle.Bold);
                    SizeF ef = g.MeasureString(text, font);
                    double highValue = 0.0;
                    double num3 = 0.0;
                    List<double> valueList = new List<double>();
                    StringBuilder builder = new StringBuilder();
                    builder.Append(text + "\r\n");
                    Color turquoise = Color.Turquoise;
                    if (this.selectedObject is CandleSeries)
                    {
                        CandleSeries selectedObject = this.selectedObject as CandleSeries;
                        double result = 0.0;
                        double.TryParse(row[selectedObject.OpenField].ToString(), out result);
                        double num5 = 0.0;
                        double.TryParse(row[selectedObject.HighField].ToString(), out num5);
                        double num6 = 0.0;
                        double.TryParse(row[selectedObject.LowField].ToString(), out num6);
                        double num7 = 0.0;
                        double.TryParse(row[selectedObject.CloseField].ToString(), out num7);
                        string str2 = selectedObject.OpenField + ":" + GetValueByTick(result, tick);
                        builder.Append(str2 + "\r\n");
                        SizeF ef2 = g.MeasureString(str2, font);
                        string str3 = selectedObject.HighField + ":" + GetValueByTick(num5, tick);
                        builder.Append(str3 + "\r\n");
                        SizeF ef3 = g.MeasureString(str3, font);
                        string str4 = selectedObject.LowField + ":" + GetValueByTick(num6, tick);
                        builder.Append(str4 + "\r\n");
                        SizeF ef4 = g.MeasureString(str4, font);
                        string str5 = selectedObject.CloseField + ":" + GetValueByTick(num7, tick);
                        builder.Append(str5);
                        SizeF ef5 = g.MeasureString(str5, font);
                        valueList.AddRange(new double[] { (double)ef.Width, (double)ef2.Width, (double)ef3.Width, (double)ef4.Width, (double)ef5.Width });
                        highValue = GetHighValue(valueList);
                        num3 = (((ef.Height + ef2.Height) + ef3.Height) + ef4.Height) + ef5.Height;
                    }
                    else if (this.selectedObject is HistogramSeries)
                    {
                        HistogramSeries series2 = this.selectedObject as HistogramSeries;
                        double num8 = 0.0;
                        double.TryParse(row[series2.Field].ToString(), out num8);
                        string str6 = series2.Field + ":" + GetValueByTick(num8, tick);
                        builder.Append(str6);
                        SizeF ef6 = g.MeasureString(str6, font);
                        valueList.AddRange(new double[] { (double)ef.Width, (double)ef6.Width });
                        highValue = GetHighValue(valueList);
                        num3 = ef.Height + ef6.Height;
                        turquoise = Color.Yellow;
                    }
                    else if (this.selectedObject is TrendLineSeries)
                    {
                        TrendLineSeries series3 = this.selectedObject as TrendLineSeries;
                        double num9 = 0.0;
                        double.TryParse(row[series3.Field].ToString(), out num9);
                        string str7 = series3.DisplayName + ":" + GetValueByTick(num9, tick);
                        builder.Append(str7);
                        SizeF ef7 = g.MeasureString(str7, font);
                        valueList.AddRange(new double[] { (double)ef.Width, (double)ef7.Width });
                        highValue = GetHighValue(valueList);
                        num3 = ef.Height + ef7.Height;
                        turquoise = series3.LineColor;
                    }
                    highValue += 4.0;
                    num3++;
                    Rectangle rect = new Rectangle(this.GetCrossHairPoint().X + 10, this.GetCrossHairPoint().Y, (int)highValue, (int)num3);
                    Brush brush = new SolidBrush(Color.FromArgb(100, Color.Black));
                    Pen pen = new Pen(turquoise);
                    Brush brush2 = new SolidBrush(turquoise);
                    g.FillRectangle(brush, rect);
                    g.DrawRectangle(pen, rect);
                    g.DrawString(builder.ToString(), font, brush2, new PointF((float)(this.GetCrossHairPoint().X + 10), (float)(this.GetCrossHairPoint().Y + 2)));
                    brush.Dispose();
                    pen.Dispose();
                    brush2.Dispose();
                }
                this.vp_index = -1;
            }
        }

        ~ChartGraph()
        {
            if (this.reticleLine_Pen != null)
            {
                this.reticleLine_Pen.Dispose();
            }
            if (this.xtip_Brush != null)
            {
                this.xtip_Brush.Dispose();
            }
            if (this.xtipFont_Brush != null)
            {
                this.xtipFont_Brush.Dispose();
            }
            if (this.leftyTip_Brush != null)
            {
                this.leftyTip_Brush.Dispose();
            }
            if (this.leftyTipFont_Brush != null)
            {
                this.leftyTipFont_Brush.Dispose();
            }
            if (this.rightyTip_Brush != null)
            {
                this.rightyTip_Brush.Dispose();
            }
            if (this.rightyTipFont_Brush != null)
            {
                this.rightyTipFont_Brush.Dispose();
            }
            if (this.layBorder_Pen != null)
            {
                this.layBorder_Pen.Dispose();
            }
            if (this.layFont_Pen != null)
            {
                this.layFont_Pen.Dispose();
            }
            if (this.coordinateX_Pen != null)
            {
                this.coordinateX_Pen.Dispose();
            }
            if (this.coordinateXFont_Brush != null)
            {
                this.coordinateXFont_Brush.Dispose();
            }
            if (this.leftY_Pen != null)
            {
                this.leftY_Pen.Dispose();
            }
            if (this.leftGrid_Pen != null)
            {
                this.leftGrid_Pen.Dispose();
            }
            if (this.leftYFont_Brush != null)
            {
                this.leftYFont_Brush.Dispose();
            }
            if (this.rightY_Pen != null)
            {
                this.rightY_Pen.Dispose();
            }
            if (this.rightGrid_Pen != null)
            {
                this.rightGrid_Pen.Dispose();
            }
            if (this.rightYFont_Brush != null)
            {
                this.rightYFont_Brush.Dispose();
            }
        }

        public static string GetCalenderFormatTimeKey(string value, IntervalType interval)
        {
            string str = string.Empty;
            switch (interval)
            {
                case IntervalType.Minute:
                    return (value.Substring(8, 2) + ":" + value.Substring(10, 2));

                case IntervalType.Day:
                case IntervalType.Week:
                    return (value.Substring(0, 4) + "/" + value.Substring(4, 2) + "/" + value.Substring(6, 2));

                case IntervalType.Month:
                    return (value.Substring(0, 4) + "/" + value.Substring(4, 2));

                case IntervalType.Year:
                    return value.Substring(0, 4);
            }
            return str;
        }

        public Point GetCrossHairPoint()
        {
            int x = base.PointToClient(Control.MousePosition).X;
            int y = base.PointToClient(Control.MousePosition).Y;
            if (y > (base.Height - 0x19))
            {
                y = base.Height - 0x19;
            }
            if (this.showLeftScale && (x < this.leftPixSpace))
            {
                x = this.leftPixSpace;
            }
            if (this.showRightScale && (x > (base.Width - this.rightPixSpace)))
            {
                x = base.Width - this.rightPixSpace;
            }
            return new Point(x, y);
        }

        public int GetCrossOverIndex()
        {
            return ((((this.GetCrossHairPoint().X - this.LeftPixSpace) / this.AxisSpace) + this.firstVisibleRecord) - 1);
        }

        public double GetCurrentValue()
        {
            Point crossHairPoint = this.GetCrossHairPoint();
            foreach (ChartPanel panel in this.dicChartPanel.Values)
            {
                if (((crossHairPoint.Y >= panel.RectPanel.Y) && (crossHairPoint.Y <= (panel.RectPanel.Y + panel.RectPanel.Height))) && (this.GetWorkSpaceY(panel.PanelID) > 0))
                {
                    double num = (panel.MaxValue - panel.MinValue) / ((double)this.GetWorkSpaceY(panel.PanelID));
                    return (panel.MaxValue - (((this.crossHair_y - this.titleHeight) - panel.RectPanel.Y) * num));
                }
            }
            return 0.0;
        }

        public static string GetGuid()
        {
            return Guid.NewGuid().ToString();
        }

        public static int GetHighRecord(List<object[]> dicValues)
        {
            double num = 0.0;
            int num2 = -1;
            for (int i = 0; i < dicValues.Count; i++)
            {
                int num4 = Convert.ToInt32(dicValues[i][0]);
                double num5 = Convert.ToDouble(dicValues[i][1]);
                if (i == 0)
                {
                    num2 = num4;
                    num = num5;
                }
                else if (num < num5)
                {
                    num = num5;
                    num2 = num4;
                }
            }
            return num2;
        }

        public static double GetHighValue(List<double> valueList)
        {
            double num = 0.0;
            for (int i = 0; i < valueList.Count; i++)
            {
                if (i == 0)
                {
                    num = valueList[i];
                }
                else if (num < valueList[i])
                {
                    num = valueList[i];
                }
            }
            return num;
        }

        public static int GetLoweRecord(List<object[]> dicValues)
        {
            double num = 0.0;
            int num2 = -1;
            for (int i = 0; i < dicValues.Count; i++)
            {
                int num4 = Convert.ToInt32(dicValues[i][0]);
                double num5 = Convert.ToDouble(dicValues[i][1]);
                if (i == 0)
                {
                    num2 = num4;
                    num = num5;
                }
                else if (num > num5)
                {
                    num2 = num4;
                    num = num5;
                }
            }
            return num2;
        }

        public static double GetLowValue(List<double> valueList)
        {
            double num = 0.0;
            for (int i = 0; i < valueList.Count; i++)
            {
                if (i == 0)
                {
                    num = valueList[i];
                }
                else if (num > valueList[i])
                {
                    num = valueList[i];
                }
            }
            return num;
        }

        public int GetMaxVisibleRecord()
        {
            if (this.axisSpace == 0)
            {
                return this.GetWorkSpaceX();
            }
            return (this.GetWorkSpaceX() / this.AxisSpace);
        }

        public int GetPanelID()
        {
            return this.panelID++;
        }

        public static string GetTimeKey(DateTime dt)
        {
            string str = (dt.Month.ToString().Length == 1) ? ("0" + dt.Month.ToString()) : dt.Month.ToString();
            string str2 = (dt.Day.ToString().Length == 1) ? ("0" + dt.Day.ToString()) : dt.Day.ToString();
            string str3 = (dt.Hour.ToString().Length == 1) ? ("0" + dt.Hour.ToString()) : dt.Hour.ToString();
            string str4 = (dt.Minute.ToString().Length == 1) ? ("0" + dt.Minute.ToString()) : dt.Minute.ToString();
            return string.Concat(new object[] { dt.Year, str, str2, str3, str4 });
        }

        public static string GetValueByTick(double value, double tick)
        {
            string str = tick.ToString();
            int num = 0;
            StringBuilder builder = new StringBuilder();
            builder.Append("0");
            if (str.IndexOf(".") != -1)
            {
                num = (str.Length - str.IndexOf(".")) - 1;
            }
            if (num > 0)
            {
                builder.Append(".");
                for (int i = 1; i <= num; i++)
                {
                    builder.Append("0");
                }
            }
            return value.ToString(builder.ToString());
        }

        public float GetValueYPixel(ChartPanel chartPanel, double chartValue)
        {
            return Convert.ToSingle((double)(((((chartPanel.MaxValue - chartValue) / (chartPanel.MaxValue - chartPanel.MinValue)) * this.GetWorkSpaceY(chartPanel.PanelID)) + this.titleHeight) + chartPanel.RectPanel.Y));
        }

        public int GetWorkSpaceX()
        {
            return ((base.Width - this.LeftPixSpace) - this.RightPixSpace);
        }

        public int GetWorkSpaceY(int panelID)
        {
            if (this.dicChartPanel.ContainsKey(panelID))
            {
                return ((this.dicChartPanel[panelID].RectPanel.Height - 0x19) - ((int)this.titleHeight));
            }
            return 0;
        }

        public static int GridScale(double XMin, double XMax, int N, ref double SMin, ref double Step, double m_fTick)
        {
            int num;
            double num5;
            int[] numArray = new int[] { 10, 12, 15, 0x10, 20, 0x19, 30, 40, 50, 60, 0x4b, 80, 100, 120, 150 };
            int length = numArray.Length;
            if (XMin > XMax)
            {
                num5 = XMin;
                XMin = XMax;
                XMax = num5;
            }
            if (XMin == XMax)
            {
                XMax = (XMin == 0.0) ? 1.0 : (XMin + (Math.Abs(XMin) / 10.0));
            }
            if (XMax <= 0.0)
            {
                num = 1;
                num5 = XMin;
                XMin = -XMax;
                XMax = -num5;
            }
            else
            {
                num = 0;
            }
            if (N < 2)
            {
                N = 2;
            }
            int num2 = N - 1;
            for (int i = 0; i < 3; i++)
            {
                double num3 = (XMax - XMin) / ((double)num2);
                double num4 = num3;
                int num10 = 0;
                while (num4 < 10.0)
                {
                    num10--;
                    num4 *= 10.0;
                }
                while (num4 > 100.0)
                {
                    num10++;
                    num4 /= 10.0;
                }
                int index = 0;
                while ((index < length) && (num4 > numArray[index]))
                {
                    index++;
                }
                do
                {
                    Step = numArray[index] * Math.Pow(10.0, (double)num10);
                    if (m_fTick != 0.0)
                    {
                        Step = Math.Floor((double)(Step / m_fTick)) * m_fTick;
                    }
                    SMin = Math.Floor((double)(XMin / Step)) * Step;
                    double num6 = SMin + (num2 * Step);
                    if (XMax <= num6)
                    {
                        if (num == 1)
                        {
                            SMin = -num6;
                        }
                        Step *= num2 / (N - 1);
                        return 1;
                    }
                    index++;
                }
                while (index < length);
                num2 *= 2;
            }
            return 0;
        }

        public void InitGraph()
        {
            this.rightPixSpace = 80;
            this.leftPixSpace = 80;
            this.reticleLine_Pen = new Pen(new SolidBrush(Color.White), 1f);
            this.xtip_Brush = new SolidBrush(Color.Red);
            this.xtipFont_Brush = new SolidBrush(Color.White);
            if (this.ShowLeftScale)
            {
                this.leftyTip_Brush = new SolidBrush(Color.Red);
                this.leftyTipFont_Brush = new SolidBrush(Color.White);
                this.leftYFont_Brush = new SolidBrush(Color.White);
                this.leftY_Pen = new Pen(new SolidBrush(Color.Red), 1f);
                this.leftGrid_Pen = new Pen(Color.FromArgb(100, Color.Red), 1f);
                this.leftGrid_Pen.DashStyle = DashStyle.Dash;
            }
            if (this.ShowRightScale)
            {
                this.rightyTip_Brush = new SolidBrush(Color.Red);
                this.rightyTipFont_Brush = new SolidBrush(Color.White);
                this.rightYFont_Brush = new SolidBrush(Color.White);
                this.rightY_Pen = new Pen(new SolidBrush(Color.Red), 1f);
                this.rightGrid_Pen = new Pen(Color.FromArgb(100, Color.Red), 1f);
                this.rightGrid_Pen.DashStyle = DashStyle.Dash;
            }
            this.coordinateXFont_Brush = new SolidBrush(Color.White);
            this.layFont_Pen = new SolidBrush(Color.White);
            this.coordinateX_Pen = new Pen(Color.Red, 1f);
            this.layBorder_Pen = new Pen(Color.SkyBlue, 1f);
            this.layBorder_Pen.DashStyle = DashStyle.Dash;
            base.SizeChanged += new EventHandler(this.ChartGraph_SizeChanged);
            base.Paint += new PaintEventHandler(this.PicGraph_Paint);
            base.PreviewKeyDown += new PreviewKeyDownEventHandler(this.PicGraph_PreviewKeyDown);
            base.MouseDown += new MouseEventHandler(this.PicGraph_MouseDown);
            base.LostFocus += new EventHandler(this.ChartGraph_LostFocus);
            base.MouseMove += new MouseEventHandler(this.ChartGraph_MouseMove);
            Thread thread = new Thread(new ThreadStart(this.checkMouseMoveLoop));
            thread.IsBackground = true;
            thread.Start();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
        }

        private void InitVisibleRecord()
        {
            if (this.dtAllMsg.Rows.Count == 0)
            {
                this.firstVisibleRecord = 0;
                this.lastVisibleRecord = 0;
            }
            else
            {
                int maxVisibleRecord = this.GetMaxVisibleRecord();
                if (this.dtAllMsg.Rows.Count < maxVisibleRecord)
                {
                    this.lastVisibleRecord = this.dtAllMsg.Rows.Count;
                    this.firstVisibleRecord = 1;
                }
                else
                {
                    if ((this.firstVisibleRecord == 0) && (this.lastVisibleRecord == 0))
                    {
                        this.lastVisibleRecord = this.dtAllMsg.Rows.Count;
                    }
                    this.firstVisibleRecord = (this.lastVisibleRecord - maxVisibleRecord) + 1;
                }
            }
        }

        public object JudgeSelectedSeries(int curIndex, int mpY, bool setSelect)
        {
            bool flag = false;
            object candleSeries = null;
            if (((this.firstVisibleRecord != 0) && (this.lastVisibleRecord != 0)) && (this.processBarValue == 0))
            {
                foreach (ChartPanel panel in this.dicChartPanel.Values)
                {
                    if (panel.TrendLineSeriesList.Count > 0)
                    {
                        foreach (TrendLineSeries series in panel.TrendLineSeriesList)
                        {
                            Rectangle rectangle;
                            if (flag)
                            {
                                if (setSelect)
                                {
                                    series.HasSelect = false;
                                }
                                continue;
                            }
                            if ((curIndex > (this.lastVisibleRecord - 1)) || (this.dtAllMsg.Rows[curIndex][series.Field].ToString() == ""))
                            {
                                if (setSelect)
                                {
                                    series.HasSelect = false;
                                }
                                continue;
                            }
                            double chartValue = Convert.ToDouble(this.dtAllMsg.Rows[curIndex][series.Field].ToString());
                            float num2 = (this.leftPixSpace + (((curIndex + 2) - this.firstVisibleRecord) * this.axisSpace)) - (this.axisSpace / 2);
                            int y = Convert.ToInt32(this.GetValueYPixel(panel, chartValue));
                            Point crossHairPoint = this.GetCrossHairPoint();
                            int num4 = 0;
                            float num5 = num2;
                            if (crossHairPoint.X >= num2)
                            {
                                if ((curIndex < (this.lastVisibleRecord - 1)) && (this.dtAllMsg.Rows[curIndex + 1][series.Field].ToString() != ""))
                                {
                                    double num6 = Convert.ToDouble(this.dtAllMsg.Rows[curIndex + 1][series.Field].ToString());
                                    num4 = Convert.ToInt32(this.GetValueYPixel(panel, num6));
                                    if ((num4 <= ((panel.RectPanel.Y + panel.RectPanel.Height) - 0x19)) && (num4 >= (panel.RectPanel.Y + this.titleHeight)))
                                    {
                                        goto Label_02F9;
                                    }
                                    if (setSelect)
                                    {
                                        series.HasSelect = false;
                                    }
                                    continue;
                                }
                                num4 = y;
                            }
                            else
                            {
                                num5 = num2 - this.axisSpace;
                                if ((curIndex > 0) && (this.dtAllMsg.Rows[curIndex - 1][series.Field].ToString() != ""))
                                {
                                    double num7 = Convert.ToDouble(this.dtAllMsg.Rows[curIndex - 1][series.Field].ToString());
                                    num4 = Convert.ToInt32(this.GetValueYPixel(panel, num7));
                                    if ((num4 <= ((panel.RectPanel.Y + panel.RectPanel.Height) - 0x19)) && (num4 >= (panel.RectPanel.Y + this.titleHeight)))
                                    {
                                        goto Label_02F9;
                                    }
                                    if (setSelect)
                                    {
                                        series.HasSelect = false;
                                    }
                                    continue;
                                }
                                num4 = y;
                            }
                        Label_02F9:
                            rectangle = new Rectangle();
                            if (num4 >= y)
                            {
                                rectangle = new Rectangle((int)num5, y, this.axisSpace, ((num4 - y) < 1) ? 1 : (num4 - y));
                            }
                            else
                            {
                                rectangle = new Rectangle((int)num5, num4, this.axisSpace, ((y - num4) < 1) ? 1 : (y - num4));
                            }
                            if (rectangle.Contains(crossHairPoint))
                            {
                                if (setSelect)
                                {
                                    this.selectedObject = series;
                                    series.HasSelect = true;
                                }
                                candleSeries = series;
                                flag = true;
                                continue;
                            }
                            if (setSelect)
                            {
                                series.HasSelect = false;
                            }
                        }
                    }
                    if (panel.HistoramSeriesList.Count > 0)
                    {
                        foreach (HistogramSeries series2 in panel.HistoramSeriesList)
                        {
                            if (flag)
                            {
                                if (setSelect)
                                {
                                    series2.HasSelect = false;
                                }
                                continue;
                            }
                            if ((curIndex > (this.lastVisibleRecord - 1)) || (this.dtAllMsg.Rows[curIndex][series2.Field].ToString() == ""))
                            {
                                series2.HasSelect = false;
                                continue;
                            }
                            double num8 = Convert.ToDouble(this.dtAllMsg.Rows[curIndex][series2.Field].ToString());
                            int num9 = Convert.ToInt32(this.GetValueYPixel(panel, num8));
                            int num10 = Convert.ToInt32(this.GetValueYPixel(panel, 0.0));
                            if ((mpY >= num9) && (mpY <= num10))
                            {
                                if (setSelect)
                                {
                                    this.selectedObject = series2;
                                    series2.HasSelect = true;
                                }
                                candleSeries = series2;
                                flag = true;
                                continue;
                            }
                            if (setSelect)
                            {
                                series2.HasSelect = false;
                            }
                        }
                    }
                    if (panel.CandleSeries != null)
                    {
                        if (flag)
                        {
                            if (setSelect)
                            {
                                panel.CandleSeries.HasSelect = false;
                            }
                            continue;
                        }
                        if (((curIndex > (this.lastVisibleRecord - 1)) || (this.dtAllMsg.Rows[curIndex][panel.CandleSeries.HighField].ToString() == "")) || (this.dtAllMsg.Rows[curIndex][panel.CandleSeries.LowField].ToString() == ""))
                        {
                            if (setSelect)
                            {
                                panel.CandleSeries.HasSelect = false;
                            }
                            continue;
                        }
                        double num11 = Convert.ToDouble(this.dtAllMsg.Rows[curIndex][panel.CandleSeries.HighField].ToString());
                        double num12 = Convert.ToDouble(this.dtAllMsg.Rows[curIndex][panel.CandleSeries.LowField].ToString());
                        int num13 = Convert.ToInt32(this.GetValueYPixel(panel, num11));
                        int num14 = Convert.ToInt32(this.GetValueYPixel(panel, num12));
                        if ((mpY >= num13) && (mpY <= num14))
                        {
                            if (setSelect)
                            {
                                panel.CandleSeries.HasSelect = true;
                                this.selectedObject = panel.CandleSeries;
                            }
                            candleSeries = panel.CandleSeries;
                            flag = true;
                            continue;
                        }
                        if (setSelect)
                        {
                            panel.CandleSeries.HasSelect = false;
                        }
                    }
                }
            }
            return candleSeries;
        }

        public void KDJIndicator(int panelID)
        {
            if (this.dicChartPanel.ContainsKey(panelID))
            {
                ChartPanel panel = this.dicChartPanel[panelID];
                if (panel.MainPanelID != -1)
                {
                    this.AddTrendLine(panel.IndKdjField[0], "K", Color.White, panelID);
                    this.AddTrendLine(panel.IndKdjField[1], "D", Color.Yellow, panelID);
                    this.AddTrendLine(panel.IndKdjField[2], "J", Color.FromArgb(0xff, 0, 0xff), panelID);
                }
            }
        }

        public void LocateCrossHair()
        {
            if (this.dtAllMsg.Rows.Count > 0)
            {
                foreach (ChartPanel panel in this.dicChartPanel.Values)
                {
                    if (((this.crossHair_y >= panel.RectPanel.Y) && (this.crossHair_y <= (panel.RectPanel.Y + panel.RectPanel.Height))) && (this.GetWorkSpaceY(panel.PanelID) > 0))
                    {
                        int height = panel.RectPanel.Height;
                        if (panel.CandleSeries != null)
                        {
                            double chartValue = Convert.ToDouble(this.dtAllMsg.Rows[this.crossOverIndex][panel.CandleSeries.CloseField]);
                            this.crossHair_y = Convert.ToInt32(this.GetValueYPixel(panel, chartValue));
                            break;
                        }
                        if (panel.HistoramSeriesList.Count > 0)
                        {
                            double num2 = Convert.ToDouble(this.dtAllMsg.Rows[this.crossOverIndex][panel.HistoramSeriesList[0].Field]);
                            this.crossHair_y = Convert.ToInt32(this.GetValueYPixel(panel, num2));
                            break;
                        }
                        if (panel.TrendLineSeriesList.Count > 0)
                        {
                            double num3 = Convert.ToDouble(this.dtAllMsg.Rows[this.crossOverIndex][panel.TrendLineSeriesList[0].Field]);
                            this.crossHair_y = Convert.ToInt32(this.GetValueYPixel(panel, num3));
                            break;
                        }
                    }
                }
            }
        }

        public void PaintGraph(Rectangle drawRectangle)
        {
            lock (this.refresh_lock)
            {
                BufferedGraphics graphics = BufferedGraphicsManager.Current.Allocate(base.CreateGraphics(), drawRectangle);
                Graphics g = graphics.Graphics;
                this.DrawBackGround(g);
                this.DrawTitle(g);
                this.DrawScale(g);
                if (this.processBarValue == 0)
                {
                    this.DrawSeries(g);
                    if (this.showCrossHair)
                    {
                        this.DrawCrossHair(g);
                    }
                    this.DrawValuePanel(g);
                }
                this.DrawProcessBar(g);
                graphics.Render();
                graphics.Dispose();
            }
        }

        private void PicGraph_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (this.processBarValue == 0))
            {
                this.crossHair_y = this.GetCrossHairPoint().Y;
                if (e.Clicks == 1)
                {
                    this.crossOverIndex = this.GetCrossOverIndex();
                    this.JudgeSelectedSeries(this.crossOverIndex, this.crossHair_y, true);
                    this.DrawGraph();
                }
                else if (e.Clicks == 2)
                {
                    this.ShowCrossHair = !this.ShowCrossHair;
                    this.crossOverIndex = this.GetCrossOverIndex();
                    this.DrawGraph();
                }
            }
        }

        private void PicGraph_Paint(object sender, PaintEventArgs e)
        {
            this.DrawGraph();
        }

        private void PicGraph_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (this.processBarValue == 0)
            {
                bool flag = false;
                bool flag2 = false;
                switch (e.KeyData)
                {
                    case Keys.Left:
                        flag = true;
                        if (!this.showCrossHair)
                        {
                            this.ScrollLeft(this.scrollStep);
                            break;
                        }
                        this.CrossHairScrollLeft();
                        flag2 = true;
                        break;

                    case Keys.Up:
                        flag = true;
                        this.ZoomIn(1);
                        break;

                    case Keys.Right:
                        flag = true;
                        if (!this.showCrossHair)
                        {
                            this.ScrollRight(this.scrollStep);
                            break;
                        }
                        this.CrossHairScrollRight();
                        flag2 = true;
                        break;

                    case Keys.Down:
                        flag = true;
                        this.ZoomOut(1);
                        break;
                }
                if (flag)
                {
                    this.setVisibleExtremeValue();
                    this.ResetCrossOverRecord();
                    if (flag2)
                    {
                        this.LocateCrossHair();
                    }
                    this.DrawGraph();
                }
            }
        }

        public void RefreshGraph()
        {
            this.InitVisibleRecord();
            this.setVisibleExtremeValue();
            this.ResetCrossOverRecord();
            this.DrawGraph();
        }

        public void RelateMainPanelID(int panelID, int mainPanelID)
        {
            if (this.dicChartPanel.ContainsKey(panelID))
            {
                this.dicChartPanel[panelID].MainPanelID = mainPanelID;
            }
        }

        public void ResetCrossOverRecord()
        {
            if ((this.dtAllMsg.Rows.Count > 0) && this.showCrossHair)
            {
                if (this.crossOverIndex < (this.firstVisibleRecord - 1))
                {
                    this.crossOverIndex = this.firstVisibleRecord - 1;
                }
                if (this.crossOverIndex > (this.lastVisibleRecord - 1))
                {
                    this.crossOverIndex = this.lastVisibleRecord - 1;
                }
            }
        }

        public void ResizeGraph()
        {
            int y = 0;
            foreach (ChartPanel panel in this.dicChartPanel.Values)
            {
                panel.RectPanel = new Rectangle(0, y, 0, Convert.ToInt32((double)((((double)panel.VerticalPercent) / 100.0) * base.Height)));
                y += Convert.ToInt32((double)((((double)panel.VerticalPercent) / 100.0) * base.Height));
            }
        }

        public double RSV(int interval, int rowIndex, int sourcePanelID)
        {
            double num = 0.0;
            if (!this.dicChartPanel.ContainsKey(sourcePanelID))
            {
                return num;
            }
            ChartPanel panel = this.dicChartPanel[sourcePanelID];
            if (panel.CandleSeries == null)
            {
                return num;
            }
            string closeField = panel.CandleSeries.CloseField;
            string highField = panel.CandleSeries.HighField;
            string lowField = panel.CandleSeries.LowField;
            if (rowIndex < interval)
            {
                return num;
            }
            double num2 = Convert.ToDouble(this.dtAllMsg.Rows[rowIndex][closeField]);
            List<double> valueList = new List<double>();
            List<double> list2 = new List<double>();
            for (int i = rowIndex; i >= (rowIndex - interval); i--)
            {
                double item = Convert.ToDouble(this.dtAllMsg.Rows[i][highField]);
                double num5 = Convert.ToDouble(this.dtAllMsg.Rows[i][lowField]);
                valueList.Add(item);
                list2.Add(num5);
            }
            double highValue = GetHighValue(valueList);
            double lowValue = GetLowValue(list2);
            return (((num2 - lowValue) / (highValue - lowValue)) * 100.0);
        }

        private void ScrollLeft(int step)
        {
            if (((this.dtAllMsg.Rows.Count > 1) && (this.firstVisibleRecord > 1)) && (this.dtAllMsg.Rows.Count > this.GetMaxVisibleRecord()))
            {
                if ((this.firstVisibleRecord - step) >= 1)
                {
                    this.firstVisibleRecord -= step;
                    this.lastVisibleRecord -= step;
                }
                else
                {
                    this.lastVisibleRecord -= this.firstVisibleRecord;
                    this.firstVisibleRecord = 1;
                }
            }
        }

        private void ScrollRight(int step)
        {
            if (((this.dtAllMsg.Rows.Count > 1) && (this.lastVisibleRecord < this.dtAllMsg.Rows.Count)) && (this.dtAllMsg.Rows.Count > this.GetMaxVisibleRecord()))
            {
                if ((this.lastVisibleRecord + step) > this.dtAllMsg.Rows.Count)
                {
                    this.firstVisibleRecord += this.dtAllMsg.Rows.Count - this.lastVisibleRecord;
                    this.lastVisibleRecord = this.dtAllMsg.Rows.Count;
                }
                else
                {
                    this.firstVisibleRecord += step;
                    this.lastVisibleRecord += step;
                }
            }
        }

        public void SetCandleTitleColor(Color openColor, Color highColor, Color lowColor, Color closeColor, int panelID)
        {
            if (this.dicChartPanel.ContainsKey(panelID))
            {
                ChartPanel panel = this.dicChartPanel[panelID];
                if (panel.CandleSeries != null)
                {
                    panel.CandleSeries.OpenTitleColor = openColor;
                    panel.CandleSeries.HighTitleColor = highColor;
                    panel.CandleSeries.LowTitleColor = lowColor;
                    panel.CandleSeries.CloseTitleColor = closeColor;
                }
            }
        }

        public void SetPanelBackColor(int panelID, Color bgColor)
        {
            if (this.dicChartPanel.ContainsKey(panelID))
            {
                this.dicChartPanel[panelID].BackColor = bgColor;
            }
        }

        public void SetPanelBuySellField(int panelID, string buyField, string sellField)
        {
            if (this.dicChartPanel.ContainsKey(panelID))
            {
                this.dicChartPanel[panelID].IndBuySellField[0] = buyField;
                this.dicChartPanel[panelID].IndBuySellField[1] = sellField;
            }
        }

        public void SetPanelGridInterval(int panelID, int gridInterval)
        {
            if (this.dicChartPanel.ContainsKey(panelID))
            {
                this.dicChartPanel[panelID].GridInterval = gridInterval;
            }
        }

        public void SetPanelTick(int panelID, double tick)
        {
            if (this.dicChartPanel.ContainsKey(panelID))
            {
                this.dicChartPanel[panelID].YScaleTick = tick;
            }
        }

        public void SetPanelTitle(int panelID, string title)
        {
            if (this.dicChartPanel.ContainsKey(panelID))
            {
                this.dicChartPanel[panelID].IssueCodeTitle = title;
            }
        }

        public void SetValue(string fieldName, object value, DateTime dateTime)
        {
            if (!this.dtAllMsg.Columns.Contains(fieldName))
            {
                this.dtAllMsg.Columns.Add(fieldName);
            }
            string timeKey = GetTimeKey(dateTime);
            DataRow row = this.dtAllMsg.Rows.Find(timeKey);
            if (row != null)
            {
                row[fieldName] = value;
            }
            else
            {
                row = this.dtAllMsg.NewRow();
                row[this.timekeyField] = timeKey;
                row[fieldName] = value;
                this.dtAllMsg.Rows.Add(row);
            }
        }

        private void setVisibleExtremeValue()
        {
            if (this.GetWorkSpaceX() > 0)
            {
                int num = this.firstVisibleRecord - 1;
                int lastVisibleRecord = this.lastVisibleRecord;
                foreach (ChartPanel panel in this.dicChartPanel.Values)
                {
                    List<object[]> dicValues = new List<object[]>();
                    List<double> valueList = new List<double>();
                    if (this.dtAllMsg.Rows.Count > 0)
                    {
                        for (int i = num; i < lastVisibleRecord; i++)
                        {
                            this.dtAllMsg.Rows[i][this.timekeyField].ToString();
                            DataRow row = this.dtAllMsg.Rows[i];
                            if (panel.YScaleField.Count > 0)
                            {
                                foreach (string str in panel.YScaleField)
                                {
                                    double result = 0.0;
                                    double.TryParse(row[str].ToString(), out result);
                                    valueList.Add(result);
                                }
                            }
                            else
                            {
                                if (panel.CandleSeries != null)
                                {
                                    double num5 = 0.0;
                                    double.TryParse(row[panel.CandleSeries.OpenField].ToString(), out num5);
                                    double num6 = 0.0;
                                    double.TryParse(row[panel.CandleSeries.HighField].ToString(), out num6);
                                    double num7 = 0.0;
                                    double.TryParse(row[panel.CandleSeries.LowField].ToString(), out num7);
                                    double num8 = 0.0;
                                    double.TryParse(row[panel.CandleSeries.CloseField].ToString(), out num8);
                                    valueList.Add(num5);
                                    valueList.Add(num6);
                                    valueList.Add(num7);
                                    valueList.Add(num8);
                                }
                                foreach (HistogramSeries series in panel.HistoramSeriesList)
                                {
                                    if (row[series.Field].ToString() != "")
                                    {
                                        double num9 = 0.0;
                                        double.TryParse(row[series.Field].ToString(), out num9);
                                        valueList.Add(0.0);
                                        valueList.Add(num9);
                                    }
                                }
                                foreach (TrendLineSeries series2 in panel.TrendLineSeriesList)
                                {
                                    if (row[series2.Field].ToString() != "")
                                    {
                                        double num10 = 0.0;
                                        double.TryParse(row[series2.Field].ToString(), out num10);
                                        valueList.Add(num10);
                                    }
                                }
                            }
                            if (panel.CandleSeries != null)
                            {
                                double num11 = 0.0;
                                double.TryParse(row[panel.CandleSeries.OpenField].ToString(), out num11);
                                double num12 = 0.0;
                                double.TryParse(row[panel.CandleSeries.HighField].ToString(), out num12);
                                double num13 = 0.0;
                                double.TryParse(row[panel.CandleSeries.LowField].ToString(), out num13);
                                double num14 = 0.0;
                                double.TryParse(row[panel.CandleSeries.CloseField].ToString(), out num14);
                                dicValues.Add(new object[] { i, num11 });
                                dicValues.Add(new object[] { i, num12 });
                                dicValues.Add(new object[] { i, num13 });
                                dicValues.Add(new object[] { i, num14 });
                            }
                        }
                    }
                    panel.MaxValue = GetHighValue(valueList);
                    panel.MinValue = GetLowValue(valueList);
                    panel.MaxRecord = GetHighRecord(dicValues);
                    panel.MinRecord = GetLoweRecord(dicValues);
                }
            }
        }

        public void SetXScaleField(string field)
        {
            if ((this.timekeyField == null) || (this.timekeyField.Length == 0))
            {
                this.timekeyField = field;
                DataColumn column = new DataColumn(this.timekeyField);
                this.dtAllMsg.Columns.Add(column);
                this.dtAllMsg.PrimaryKey = new DataColumn[] { column };
            }
        }

        public void SetYScaleField(int panelID, string[] field)
        {
            if (this.dicChartPanel.ContainsKey(panelID))
            {
                ChartPanel panel = this.dicChartPanel[panelID];
                foreach (string str in field)
                {
                    panel.YScaleField.Add(str);
                }
            }
        }

        public void ShowValuePanel()
        {
            if (this.selectedObject != null)
            {
                int crossOverIndex = this.GetCrossOverIndex();
                if (this.JudgeSelectedSeries(crossOverIndex, this.GetCrossHairPoint().Y, false) == this.selectedObject)
                {
                    this.vp_index = crossOverIndex;
                    this.DrawGraph();
                }
            }
        }

        public double Slope(int interval, int rowIndex, string field)
        {
            double num = 0.0;
            if (rowIndex < interval)
            {
                return num;
            }
            double num2 = 0.0;
            double num3 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
            for (int i = rowIndex; i >= (rowIndex - interval); i--)
            {
                num2 += Convert.ToDouble(this.dtAllMsg.Rows[i][field].ToString()) * (i - interval);
                num3 += i - interval;
                num4 += Convert.ToDouble(this.dtAllMsg.Rows[i][field].ToString());
                num5 = (i - interval) * (i - interval);
            }
            return (((num2 * interval) - (num3 * num4)) / ((interval * num5) - (num3 * num3)));
        }

        public void YmBuySellOne(int panelID)
        {
            this.AddExponentialMovingAverage("BuyEMA", null, Color.White, 6, "(CLOSE+HIGH+LOW)/3", panelID);
            this.AddExponentialMovingAverage("SellEMA", null, Color.Yellow, 5, "BuyEMA", panelID);
            this.SetPanelBuySellField(panelID, "BuyEMA", "SellEMA");
        }

        public void YmBuySellTwo(int panelID, string closeField)
        {
            this.AddExponentialMovingAverage("BuyEMA", null, Color.White, 2, closeField, panelID);
            this.AddExponentialMovingAverage("SellEMA", null, Color.Yellow, 0x2a, "SLOPE(C,21)+CLOSE", panelID);
            this.SetPanelBuySellField(panelID, "BuyEMA", "SellEMA");
        }

        private void ZoomIn(int step)
        {
            if (this.axisSpace < 50)
            {
                int maxVisibleRecord = this.GetMaxVisibleRecord();
                bool flag = false;
                if (this.dtAllMsg.Rows.Count < maxVisibleRecord)
                {
                    flag = true;
                }
                this.axisSpace++;
                int num2 = this.GetMaxVisibleRecord();
                int num3 = maxVisibleRecord - num2;
                if (this.dtAllMsg.Rows.Count >= num2)
                {
                    if (flag)
                    {
                        this.firstVisibleRecord = 1;
                        this.lastVisibleRecord = num2;
                    }
                    else
                    {
                        this.firstVisibleRecord += num3 / 2;
                        this.lastVisibleRecord = (this.firstVisibleRecord + num2) - 1;
                    }
                }
            }
        }

        private void ZoomOut(int step)
        {
            if (this.axisSpace > 1)
            {
                int maxVisibleRecord = this.GetMaxVisibleRecord();
                this.axisSpace--;
                int num3 = this.GetMaxVisibleRecord() - maxVisibleRecord;
                int num4 = this.firstVisibleRecord - (num3 / 2);
                int num5 = this.lastVisibleRecord + (num3 - (num3 / 2));
                if ((num4 < 1) && (num5 > this.dtAllMsg.Rows.Count))
                {
                    this.firstVisibleRecord = 1;
                    this.lastVisibleRecord = this.dtAllMsg.Rows.Count;
                }
                else if (num4 < 1)
                {
                    this.lastVisibleRecord = (this.lastVisibleRecord + num3) - (this.firstVisibleRecord - 1);
                    this.firstVisibleRecord = 1;
                    if (this.lastVisibleRecord > this.dtAllMsg.Rows.Count)
                    {
                        this.lastVisibleRecord = this.dtAllMsg.Rows.Count;
                    }
                }
                else if (num5 > this.dtAllMsg.Rows.Count)
                {
                    this.firstVisibleRecord -= num3 - (this.dtAllMsg.Rows.Count - this.lastVisibleRecord);
                    this.lastVisibleRecord = this.dtAllMsg.Rows.Count;
                    if (this.firstVisibleRecord < 1)
                    {
                        this.firstVisibleRecord = 1;
                    }
                }
                else
                {
                    this.firstVisibleRecord = num4;
                    this.lastVisibleRecord = num5;
                }
            }
        }

        [Browsable(true)]
        public int AxisSpace
        {
            get
            {
                return this.axisSpace;
            }
            set
            {
                this.axisSpace = value;
            }
        }

        [Browsable(false)]
        public int CrossOverIndex
        {
            get
            {
                return this.crossOverIndex;
            }
            set
            {
                this.crossOverIndex = value;
            }
        }

        [Browsable(false)]
        public DataTable DtAllMsg
        {
            get
            {
                return this.dtAllMsg;
            }
            set
            {
                this.dtAllMsg = value;
            }
        }

        [Browsable(false)]
        public int FirstVisibleRecord
        {
            get
            {
                return this.firstVisibleRecord;
            }
            set
            {
                this.firstVisibleRecord = value;
            }
        }

        [Browsable(true)]
        public IntervalType Interval
        {
            get
            {
                return this.interval;
            }
            set
            {
                this.interval = value;
            }
        }

        [Browsable(false)]
        public int LastVisibleRecord
        {
            get
            {
                return this.lastVisibleRecord;
            }
            set
            {
                this.lastVisibleRecord = value;
            }
        }

        [Browsable(true)]
        public int LeftPixSpace
        {
            get
            {
                return this.leftPixSpace;
            }
            set
            {
                this.leftPixSpace = value;
            }
        }

        [Browsable(false)]
        public int ProcessBarValue
        {
            get
            {
                return this.processBarValue;
            }
            set
            {
                if ((value >= 0) && (value <= 100))
                {
                    this.processBarValue = value;
                }
                int num = 100;
                if (base.IsHandleCreated)
                {
                    Rectangle drawRectangle = new Rectangle((base.Width / 2) - num, (base.Height / 2) - num, num * 2, num * 2);
                    this.DrawGraph(drawRectangle);
                }
            }
        }

        [Browsable(true)]
        public int RightPixSpace
        {
            get
            {
                return this.rightPixSpace;
            }
            set
            {
                this.rightPixSpace = value;
            }
        }

        public int ScrollStep
        {
            get
            {
                return this.scrollStep;
            }
            set
            {
                this.scrollStep = value;
            }
        }

        [Browsable(false)]
        public bool ShowCrossHair
        {
            get
            {
                return this.showCrossHair;
            }
            set
            {
                this.showCrossHair = value;
            }
        }

        [Browsable(true)]
        public bool ShowLeftScale
        {
            get
            {
                return this.showLeftScale;
            }
            set
            {
                this.showLeftScale = value;
            }
        }

        [Browsable(true)]
        public bool ShowRightScale
        {
            get
            {
                return this.showRightScale;
            }
            set
            {
                this.showRightScale = value;
            }
        }

        [Browsable(true)]
        public string TimekeyField
        {
            get
            {
                return this.timekeyField;
            }
            set
            {
                this.timekeyField = value;
            }
        }

        [Browsable(true)]
        public float TitleHeight
        {
            get
            {
                return this.titleHeight;
            }
            set
            {
                this.titleHeight = value;
            }
        }

        public class CandleSeries
        {
            private string closeField;
            private Color closeTitleColor = Color.Yellow;
            private bool displayTitleField = true;
            private Color down_Color;
            private Brush downLine_Brush;
            private bool hasSelect;
            private string highField;
            private Color highTitleColor = Color.Red;
            private string lowField;
            private Color lowTitleColor = Color.Orange;
            private string openField;
            private Color openTitleColor = Color.White;
            private Color up_Color;
            private Brush upLine_Brush;

            ~CandleSeries()
            {
                if (this.upLine_Brush != null)
                {
                    this.upLine_Brush.Dispose();
                }
                if (this.downLine_Brush != null)
                {
                    this.downLine_Brush.Dispose();
                }
            }

            public string CloseField
            {
                get
                {
                    return this.closeField;
                }
                set
                {
                    this.closeField = value;
                }
            }

            public Color CloseTitleColor
            {
                get
                {
                    return this.closeTitleColor;
                }
                set
                {
                    this.closeTitleColor = value;
                }
            }

            public bool DisplayTitleField
            {
                get
                {
                    return this.displayTitleField;
                }
                set
                {
                    this.displayTitleField = value;
                }
            }

            public Color Down_Color
            {
                get
                {
                    return this.down_Color;
                }
                set
                {
                    this.down_Color = value;
                    this.downLine_Brush = new SolidBrush(value);
                }
            }

            public Brush DownLine_Brush
            {
                get
                {
                    return this.downLine_Brush;
                }
                set
                {
                    this.downLine_Brush = value;
                }
            }

            public bool HasSelect
            {
                get
                {
                    return this.hasSelect;
                }
                set
                {
                    this.hasSelect = value;
                }
            }

            public string HighField
            {
                get
                {
                    return this.highField;
                }
                set
                {
                    this.highField = value;
                }
            }

            public Color HighTitleColor
            {
                get
                {
                    return this.highTitleColor;
                }
                set
                {
                    this.highTitleColor = value;
                }
            }

            public string LowField
            {
                get
                {
                    return this.lowField;
                }
                set
                {
                    this.lowField = value;
                }
            }

            public Color LowTitleColor
            {
                get
                {
                    return this.lowTitleColor;
                }
                set
                {
                    this.lowTitleColor = value;
                }
            }

            public string OpenField
            {
                get
                {
                    return this.openField;
                }
                set
                {
                    this.openField = value;
                }
            }

            public Color OpenTitleColor
            {
                get
                {
                    return this.openTitleColor;
                }
                set
                {
                    this.openTitleColor = value;
                }
            }

            public Color Up_Color
            {
                get
                {
                    return this.up_Color;
                }
                set
                {
                    this.up_Color = value;
                    this.upLine_Brush = new SolidBrush(value);
                }
            }

            public Brush UpLine_Brush
            {
                get
                {
                    return this.upLine_Brush;
                }
                set
                {
                    this.upLine_Brush = value;
                }
            }
        }

        public class ChartPanel
        {
            private Color backColor = Color.Black;
            private Brush bgBrush = new SolidBrush(Color.Black);
            private string bsColorField = ChartGraph.GetGuid();
            private string bsFlagField = ChartGraph.GetGuid();
            private StockMonitor.Controls.ChartGraph.CandleSeries candleSeries;
            private int gridInterval = 3;
            private List<ChartGraph.HistogramSeries> historamSeriesList = new List<ChartGraph.HistogramSeries>();
            private string[] indBuySellField = new string[2];
            private string[] indKdjField = new string[3];
            private string issueCodeTitle = string.Empty;
            private int mainPanelID;
            private int maxRecord;
            private double maxValue;
            private int minRecord;
            private double minValue;
            private int panelID;
            private Rectangle rectPanel = new Rectangle();
            private string sellSignalField = string.Empty;
            private List<ChartGraph.TrendLineSeries> trendLineSeriesList = new List<ChartGraph.TrendLineSeries>();
            private int verticalPercent;
            private List<string> yScaleField = new List<string>();
            private double yScaleTick = 0.01;

            public ChartPanel()
            {
                this.indKdjField[0] = ChartGraph.GetGuid();
                this.indKdjField[1] = ChartGraph.GetGuid();
                this.indKdjField[2] = ChartGraph.GetGuid();
            }

            ~ChartPanel()
            {
                if (this.bgBrush != null)
                {
                    this.bgBrush.Dispose();
                }
            }

            public Color BackColor
            {
                get
                {
                    return this.backColor;
                }
                set
                {
                    this.backColor = value;
                    this.bgBrush.Dispose();
                    this.bgBrush = new SolidBrush(this.backColor);
                }
            }

            public Brush BgBrush
            {
                get
                {
                    return this.bgBrush;
                }
                set
                {
                    this.bgBrush = value;
                }
            }

            public string BsColorField
            {
                get
                {
                    return this.bsColorField;
                }
            }

            public string BsFlagField
            {
                get
                {
                    return this.bsFlagField;
                }
            }

            public StockMonitor.Controls.ChartGraph.CandleSeries CandleSeries
            {
                get
                {
                    return this.candleSeries;
                }
                set
                {
                    this.candleSeries = value;
                }
            }

            public int GridInterval
            {
                get
                {
                    return this.gridInterval;
                }
                set
                {
                    this.gridInterval = value;
                }
            }

            public List<ChartGraph.HistogramSeries> HistoramSeriesList
            {
                get
                {
                    return this.historamSeriesList;
                }
                set
                {
                    this.historamSeriesList = value;
                }
            }

            public string[] IndBuySellField
            {
                get
                {
                    return this.indBuySellField;
                }
                set
                {
                    this.indBuySellField = value;
                }
            }

            public string[] IndKdjField
            {
                get
                {
                    return this.indKdjField;
                }
                set
                {
                    this.indKdjField = value;
                }
            }

            public string IssueCodeTitle
            {
                get
                {
                    return this.issueCodeTitle;
                }
                set
                {
                    this.issueCodeTitle = value;
                }
            }

            public int MainPanelID
            {
                get
                {
                    return this.mainPanelID;
                }
                set
                {
                    this.mainPanelID = value;
                }
            }

            public int MaxRecord
            {
                get
                {
                    return this.maxRecord;
                }
                set
                {
                    this.maxRecord = value;
                }
            }

            [Browsable(false)]
            public double MaxValue
            {
                get
                {
                    return this.maxValue;
                }
                set
                {
                    this.maxValue = value;
                }
            }

            public int MinRecord
            {
                get
                {
                    return this.minRecord;
                }
                set
                {
                    this.minRecord = value;
                }
            }

            [Browsable(false)]
            public double MinValue
            {
                get
                {
                    return this.minValue;
                }
                set
                {
                    this.minValue = value;
                }
            }

            public int PanelID
            {
                get
                {
                    return this.panelID;
                }
                set
                {
                    this.panelID = value;
                }
            }

            public Rectangle RectPanel
            {
                get
                {
                    return this.rectPanel;
                }
                set
                {
                    this.rectPanel = value;
                }
            }

            [Browsable(false)]
            public string SellSignalField
            {
                get
                {
                    return this.sellSignalField;
                }
                set
                {
                    this.sellSignalField = value;
                }
            }

            public List<ChartGraph.TrendLineSeries> TrendLineSeriesList
            {
                get
                {
                    return this.trendLineSeriesList;
                }
                set
                {
                    this.trendLineSeriesList = value;
                }
            }

            public int VerticalPercent
            {
                get
                {
                    return this.verticalPercent;
                }
                set
                {
                    this.verticalPercent = value;
                }
            }

            public List<string> YScaleField
            {
                get
                {
                    return this.yScaleField;
                }
                set
                {
                    this.yScaleField = value;
                }
            }

            public double YScaleTick
            {
                get
                {
                    return this.yScaleTick;
                }
                set
                {
                    this.yScaleTick = value;
                }
            }
        }

        public class HistogramSeries
        {
            private string displayName = string.Empty;
            private Brush down_lineBrush;
            private Color down_lineColor;
            private string field;
            private bool hasSelect;
            private bool isVolume;
            private Brush up_lineBrush;
            private Color up_lineColor;

            ~HistogramSeries()
            {
                if (this.up_lineBrush != null)
                {
                    this.up_lineBrush.Dispose();
                }
                if (this.down_lineBrush != null)
                {
                    this.down_lineBrush.Dispose();
                }
            }

            public string DisplayName
            {
                get
                {
                    return this.displayName;
                }
                set
                {
                    this.displayName = value;
                }
            }

            public Brush Down_lineBrush
            {
                get
                {
                    return this.down_lineBrush;
                }
                set
                {
                    this.down_lineBrush = value;
                }
            }

            public Color Down_lineColor
            {
                get
                {
                    return this.down_lineColor;
                }
                set
                {
                    this.down_lineColor = value;
                    this.Down_lineBrush = new SolidBrush(value);
                }
            }

            public string Field
            {
                get
                {
                    return this.field;
                }
                set
                {
                    this.field = value;
                }
            }

            public bool HasSelect
            {
                get
                {
                    return this.hasSelect;
                }
                set
                {
                    this.hasSelect = value;
                }
            }

            public bool IsVolume
            {
                get
                {
                    return this.isVolume;
                }
                set
                {
                    this.isVolume = value;
                }
            }

            public Brush Up_LineBrush
            {
                get
                {
                    return this.up_lineBrush;
                }
                set
                {
                    this.up_lineBrush = value;
                }
            }

            public Color Up_LineColor
            {
                get
                {
                    return this.up_lineColor;
                }
                set
                {
                    this.up_lineColor = value;
                    this.up_lineBrush = new SolidBrush(value);
                }
            }
        }

        public enum IntervalType
        {
            Minute,
            Day,
            Week,
            Month,
            Year
        }

        public enum LineType
        {
            TrendLine,
            SimpleMovingAverage,
            ExponentialMovingAverage
        }

        private delegate void ShowValuePanelDelegate();

        public class TrendLineSeries
        {
            private string displayName = string.Empty;
            private string field = string.Empty;
            private bool hasSelect;
            private int interval = 5;
            private Brush lineBrush;
            private Color lineColor;
            private Pen linePen;
            private StockMonitor.Controls.ChartGraph.LineType lineType;
            private string source = string.Empty;

            ~TrendLineSeries()
            {
                if (this.linePen != null)
                {
                    this.linePen.Dispose();
                }
                if (this.lineBrush != null)
                {
                    this.lineBrush.Dispose();
                }
            }

            public string DisplayName
            {
                get
                {
                    return this.displayName;
                }
                set
                {
                    this.displayName = value;
                }
            }

            public string Field
            {
                get
                {
                    return this.field;
                }
                set
                {
                    this.field = value;
                }
            }

            public bool HasSelect
            {
                get
                {
                    return this.hasSelect;
                }
                set
                {
                    this.hasSelect = value;
                }
            }

            public int Interval
            {
                get
                {
                    return this.interval;
                }
                set
                {
                    this.interval = value;
                }
            }

            public Brush LineBrush
            {
                get
                {
                    return this.lineBrush;
                }
                set
                {
                    this.lineBrush = value;
                }
            }

            public Color LineColor
            {
                get
                {
                    return this.lineColor;
                }
                set
                {
                    this.lineColor = value;
                    this.linePen = new Pen(value);
                    this.lineBrush = new SolidBrush(value);
                }
            }

            public Pen LinePen
            {
                get
                {
                    return this.linePen;
                }
                set
                {
                    this.linePen = value;
                }
            }

            public StockMonitor.Controls.ChartGraph.LineType LineType
            {
                get
                {
                    return this.lineType;
                }
                set
                {
                    this.lineType = value;
                }
            }

            public string Source
            {
                get
                {
                    return this.source;
                }
                set
                {
                    this.source = value;
                }
            }
        }
    }
}