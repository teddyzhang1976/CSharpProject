using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;//阴历和阳历日期

namespace BeautifulCalendar
{
    public partial class Calendar : UserControl
    {
        public Calendar()
        {
            InitializeComponent();
        }

        #region 变量及常量
        int yy = 0;//年
        int mm = 0;//月
        int dd = 0;//日
        string yymm = "";//当前年月
        public const string CelestialStem = "甲乙丙丁戊己庚辛壬癸";
        public const string TerrestrialBranch = "子丑寅卯辰巳午未申酉戌亥";
        public const string Animals = "鼠牛虎兔龙蛇马羊猴鸡狗猪";
        public const string ChineseNumber = "〇一二三四五六七八九";
        private static ChineseLunisolarCalendar calendar = new ChineseLunisolarCalendar();
        #endregion

        #region 属性

        private DateTime TDate = DateTime.Now.Date;
        [Browsable(true), Category("设置日期"), Description("设置阳历的日期，其默认值为系统当前日期")] //在“属性”窗口中显示Date属性
        public DateTime Date
        {
            get { return TDate; }
            set
            {
                TDate = value;
                yy = TDate.Year;
                mm = TDate.Month;
                dd = TDate.Day;
                this.Invalidate();
            }
        }

        private bool TGetNowDate = true;
        [Browsable(true), Category("设置日期"), Description("按分钟获取当前系统的时间")] //在“属性”窗口中显示Date属性
        public bool GetNowDate
        {
            get { return TGetNowDate; }
            set
            {
                TGetNowDate = value;
                if (TGetNowDate == true)
                {
                    timer1.Enabled = true;
                    this.Invalidate();
                }
                else
                    timer1.Enabled = false;
            }
        }

        #endregion

        private void DateTimeControl_Paint(object sender, PaintEventArgs e)
        {
            //绘制背景图片
            Image img = new Bitmap(Properties.Resources.backdrop1);
            e.Graphics.DrawImageUnscaled(img, new Point(0, 0));
            //绘制日期
            yymm = yy.ToString() + "年" + "  " + mm.ToString() + "月";
            Font Myfont = new Font("幼圆", 12, FontStyle.Bold);
            float Date_Y = (this.Width - StringSize(yymm, Myfont, true)) / 2F;
            e.Graphics.DrawString(yymm, Myfont, new SolidBrush(Color.White), new PointF(Date_Y, 20F));
            //绘制天
            Myfont = new Font("新宋体", 65,FontStyle.Bold);
            float Date_D = (this.Width - StringSize(dd.ToString(), Myfont, true)) / 2F;
            e.Graphics.DrawString(dd.ToString(), Myfont, new SolidBrush(Color.Black), new PointF(Date_D + 3, 30F));
            e.Graphics.DrawString(dd.ToString(), Myfont, new SolidBrush(Color.White), new PointF(Date_D, 30F));
            //绘制今天是周几
            string MyWeek = GetDayOfWeekString(this.Date);
            Myfont = new Font("幼圆", 12, FontStyle.Bold);
            Date_Y = (this.Width - StringSize(MyWeek, Myfont, true)) / 2F;
            e.Graphics.DrawString(MyWeek, Myfont, new SolidBrush(Color.White), new PointF(Date_Y, 110F));
            //获取阴历年干支
            int tem_n = calendar.GetSexagenaryYear(Date);
            string Armour = CelestialStem.Substring((tem_n - 1) % 10, 1) + TerrestrialBranch.Substring((tem_n - 1) % 12, 1);
            //获取生肖
            tem_n = calendar.GetSexagenaryYear(Date);
            string Resemble = Animals.Substring((tem_n - 1) % 12, 1);
            //阴历日期
            //string Lunar = GetLunarCalendar(Date);
            string tem_embolism = "";
            string tem_Lunardata = "";
            GetLunarCalendar(Date, out tem_embolism, out tem_Lunardata);
            string LunarInfo = Armour + Resemble + tem_embolism + " " + LunarYear(Date.Year) + "年" + tem_Lunardata;
            Myfont = new Font("黑体", 7.5F);
            Date_Y = (this.Width - StringSize(LunarInfo, Myfont, true)) / 2F;
            e.Graphics.DrawString(LunarInfo, Myfont, new SolidBrush(Color.White), new PointF(Date_Y, 130F));
        }

        #region 自定义方法
        /// <summary>
        /// 获取指定字符串的高度或宽度
        /// </summary>
        /// <param str="string">字符串</param>
        /// <param font="Font">字符串的字体</param>
        /// <param n="bool">标识，获取的是高度还是宽度</param>
        /// <returns>高度或宽度(n==true为width)</returns>
        public float StringSize(string str,Font font, bool n)
        {
            Graphics TitG = this.CreateGraphics();//创建Graphics类对象
            SizeF TitSize = TitG.MeasureString(str, font);//将绘制的字符串进行格式化
            float TitWidth = TitSize.Width;//获取字符串的宽度
            float TitHeight = TitSize.Height;//获取字符串的高度
            if (n)
                return TitWidth;
            else
                return TitHeight;
        }

        /// <summary>
        /// 获取星期的中文字符串
        /// </summary>
        /// <param name="date">当前日期</param>
        /// <returns>星期几</returns>
        private string GetDayOfWeekString(DateTime date)
        {
            string weekday = "";
            switch ((int)date.DayOfWeek)
            {
                case 1: weekday = "星期一 "; break;
                case 2: weekday = "星期二 "; break;
                case 3: weekday = "星期三 "; break;
                case 4: weekday = "星期四 "; break;
                case 5: weekday = "星期五 "; break;
                case 6: weekday = "星期六 "; break;
                case 0: weekday = "星期日 "; break;
            }
            return weekday;
        }

        /// <summary>
        /// 获取农历的年份
        /// </summary>
        /// <param name="date">阳历年份</param>
        /// <returns>农历年份</returns>
        public string LunarYear(int Y)
        {
            string m_LunarYearText = "";
            StringBuilder sb = new StringBuilder();
            int year = Y;
            int d;
            do
            {
                d = year % 10;
                sb.Insert(0, ChineseNumber[d]);
                year = year / 10;
            } while (year > 0);
            m_LunarYearText = sb.ToString();
            return m_LunarYearText;
        }

        #region 农历数据
        /// <summary>
        /// 农历数据
        /// </summary>
        private static int[] LunarData =    {2635,333387,1701,1748,267701,694,2391,133423,1175,396438
            ,3402,3749,331177,1453,694,201326,2350,465197,3221,3402
            ,400202,2901,1386,267611,605,2349,137515,2709,464533,1738
            ,2901,330421,1242,2651,199255,1323,529706,3733,1706,398762
            ,2741,1206,267438,2647,1318,204070,3477,461653,1386,2413
            ,330077,1197,2637,268877,3365,531109,2900,2922,398042,2395
            ,1179,267415,2635,661067,1701,1748,398772,2742,2391,330031
            ,1175,1611,200010,3749,527717,1452,2742,332397,2350,3222
            ,268949,3402,3493,133973,1386,464219,605,2349,334123,2709
            ,2890,267946,2773,592565,1210,2651,395863,1323,2707,265877};
        //农历日期
        private static string[] DayName =   {"*","初一","初二","初三","初四","初五",
             "初六","初七","初八","初九","初十",
             "十一","十二","十三","十四","十五",
             "十六","十七","十八","十九","二十",
             "廿一","廿二","廿三","廿四","廿五",      
             "廿六","廿七","廿八","廿九","三十"};

        //农历月份
        private static string[] MonthName = { "*", "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "腊" };

        //公历月计数天
        private static int[] MonthAdd = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };
        #endregion

        #region 获取对应日期的农历及其他信息
        /// <summary>
        /// 获取对应日期的农历及其他信息
        /// </summary>
        /// <param name="dtDay">公历日期</param>
        /// <returns>农历信息</returns>
        public static void GetLunarCalendar(DateTime dtDay, out string embolism, out string Lunardata)
        {
            string sYear = dtDay.Year.ToString();
            string sMonth = dtDay.Month.ToString();
            string sDay = dtDay.Day.ToString();
            int year;
            int month;
            int day;
            try
            {
                year = int.Parse(sYear);
                month = int.Parse(sMonth);
                day = int.Parse(sDay);
            }
            catch
            {
                year = DateTime.Now.Year;
                month = DateTime.Now.Month;
                day = DateTime.Now.Day;
            }
            int nTheDate;
            int nIsEnd;
            int k, m, n, nBit, i;
            string calendar = string.Empty;
            //计算到初始时间1921年2月8日的天数：1921-2-8(正月初一)
            nTheDate = (year - 1921) * 365 + (year - 1921) / 4 + day + MonthAdd[month - 1] - 38;
            if ((year % 4 == 0) && (month > 2))
                nTheDate += 1;
            //计算天干，地支，月，日
            nIsEnd = 0;
            m = 0;
            k = 0;
            n = 0;
            while (nIsEnd != 1)
            {
                if (LunarData[m] < 4095)
                    k = 11;
                else
                    k = 12;
                n = k;
                while (n >= 0)
                {
                    //获取LunarData[m]的第n个二进制位的值
                    nBit = LunarData[m];
                    for (i = 1; i < n + 1; i++)
                        nBit = nBit / 2;
                    nBit = nBit % 2;
                    if (nTheDate <= (29 + nBit))
                    {
                        nIsEnd = 1;
                        break;
                    }
                    nTheDate = nTheDate - 29 - nBit;
                    n = n - 1;
                }
                if (nIsEnd == 1)
                    break;
                m = m + 1;
            }
            year = 1921 + m;
            month = k - n + 1;
            day = nTheDate;

            #region 格式化日期显示为三月廿四
            if (k == 12)
            {
                if (month == LunarData[m] / 65536 + 1)
                    month = 1 - month;
                else if (month > LunarData[m] / 65536 + 1)
                    month = month - 1;
            }
            //农历月
            if (month < 1)
            {
                embolism = "闰";
                Lunardata = MonthName[-1 * month].ToString() + "月";
            }
            else
            {
                embolism = "";
                Lunardata = MonthName[month].ToString() + "月";
            }

            //农历日
            Lunardata += DayName[day].ToString();

            #endregion
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Date != DateTime.Now.Date)
                Date = DateTime.Now.Date;
        }



        #endregion
    }
}
