using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeautifulRichTextBox
{
    public partial class GuageRichTextBox : UserControl
    {
        public GuageRichTextBox()
        {
            InitializeComponent();
            richTextBox1.WordWrap = false;
            richTextBox1.Top = Distance_X;
            richTextBox1.Left = Distance_Y;
            richTextBox1.Width = this.Width - Distance_X - 2;
            richTextBox1.Height = this.Height - Distance_Y - 2;
        }



        #region 变量及常量
        const int Distance_X = 30;//设置RichTextBox控件的X位置
        const int Distance_Y = 30;//设置RichTextBox控件的Y位置
        const int SpaceBetween = 3;//设置标尺的间距
        public static float thisleft = 0;//设置控件的左边距
        public static float StartBitH = 0;//记录横向滚动条的位置
        public static float StartBitV = 0;//记录纵向滚动条的位置
        const int Scale1 = 3;//设置刻度最短的线长
        const int Scale5 = 6;//设置刻度为5时的线长
        const int Scale10 = 9;//设置刻度为10是垢线长
        public static float Degree = 0;//度数
        public static float CodeSize = 1;//代码编号的宽度
        #endregion

        #region 属性

        [Browsable(true), Category("设置标尺控件"), Description("设置RichTextBox控件的相关属性")] //在“属性”窗口中显示DataStyle属性
        public RichTextBox NRichTextBox
        {
            get { return richTextBox1; }
        }

        public enum Ruler
        {
            Graduation = 0,//刻度
            Rule = 1,//尺子
        }

        private bool TCodeShow = false;
        [Browsable(true), Category("设置标尺控件"), Description("是否在RichTextBox控件的前面添加代码的行号")] //在“属性”窗口中显示DataStyle属性
        public bool CodeShow
        {
            get { return TCodeShow; }
            set
            {
                TCodeShow = value;
                this.Invalidate();
            }
        }

        private Ruler TRulerStyle = Ruler.Graduation;
        [Browsable(true), Category("设置标尺控件"), Description("设置标尺样式：\nGraduation为刻度\nRule为尺子")] //在“属性”窗口中显示DataStyle属性
        public Ruler RulerStyle
        {
            get { return TRulerStyle; }
            set
            {
                TRulerStyle = value;
                this.Invalidate();
            }
        }

        public enum Unit 
        {
            Cm = 0,//厘米
            Pels = 1,//像素
        }

        private Unit TUnitStyle = Unit.Cm;
        [Browsable(true), Category("设置标尺控件"), Description("设置标尺的单位：\nCm为厘米\nPels为像素")] //在“属性”窗口中显示DataStyle属性
        public Unit UnitStyle
        {
            get { return TUnitStyle; }
            set
            {
                TUnitStyle = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 事件
        private void GuageRichTextBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.DarkGray), 0, 0, this.Width - 1, this.Height - 1);//绘制外边框
            if (CodeShow)//如查在文本框左边添加行号
            {
                //获取行号的宽度
                float tem_code = (float)StringSize((Convert.ToInt32(CodeSize+(float)(richTextBox1.Height / (StringSize(CodeSize.ToString(), richTextBox1.Font, false))))).ToString(),this.Font, true);
                richTextBox1.Top = Distance_X;//设置控件的顶端距离
                richTextBox1.Left = Distance_Y + (int)Math.Ceiling(tem_code);//设置控件的左端距离
                richTextBox1.Width = this.Width - Distance_X - 2 - (int)Math.Ceiling(tem_code);//设置控件的宽度
                richTextBox1.Height = this.Height - Distance_Y - 2;//设置控件高度
                thisleft = Distance_Y + tem_code;//设置标尺的左端位置
            }
            else
            {
                richTextBox1.Top = Distance_X;//设置控件的顶端距离
                richTextBox1.Left = Distance_Y;//设置控件的左端距离
                richTextBox1.Width = this.Width - Distance_X - 2;//设置控件的宽度
                richTextBox1.Height = this.Height - Distance_Y - 2;//设置控件高度
                thisleft = Distance_Y;//设置标尺的左端位置
            }
            //绘制文本框的边框
            e.Graphics.DrawRectangle(new Pen(Color.LightSteelBlue), richTextBox1.Location.X - 1, thisleft - 1, richTextBox1.Width + 1, richTextBox1.Height + 1);
            e.Graphics.FillRectangle(new SolidBrush(Color.Silver), 1, 1, this.Width - 2, Distance_Y - 2);//文本框的上边框
            e.Graphics.FillRectangle(new SolidBrush(Color.Silver), 1, 1, Distance_X - 2, this.Height - 2);//文本框的左边框
            e.Graphics.FillRectangle(new SolidBrush(Color.Gray), 3, 3, Distance_X - 7, Distance_Y - 8);//绘制左上角的方块边框
            e.Graphics.DrawRectangle(new Pen(SystemColors.Control), 3, 3, Distance_X - 8, Distance_Y - 8);//绘制左上角的方块
            if (RulerStyle == Ruler.Rule)//标尺
            {
                //绘制上边的标尺背景
                e.Graphics.FillRectangle(new SolidBrush(Color.Gray), thisleft - 3, 3, this.Width - (thisleft - 2) , Distance_Y - 9);//绘制左上角的方块边框
                e.Graphics.DrawLine(new Pen(SystemColors.Control), thisleft - 3, 3, this.Width - 2, 3);//绘制方块的上边线
                e.Graphics.DrawLine(new Pen(SystemColors.Control), thisleft - 3, Distance_Y - 5, this.Width - 2, Distance_Y - 5);//绘制方块的下边线
                e.Graphics.FillRectangle(new SolidBrush(Color.WhiteSmoke), thisleft - 2, 9, this.Width - (thisleft - 2) - 1, Distance_Y - 19);//绘制方块的中间块
                //绘制左边的标尺背景
                e.Graphics.FillRectangle(new SolidBrush(Color.Gray), 3, Distance_Y - 3, Distance_X - 7, this.Height - (Distance_Y - 3) - 2);//绘制左边的方块
                e.Graphics.DrawLine(new Pen(SystemColors.Control), 3, Distance_Y - 3, 3, this.Height - 2);//绘制方块的左边线
                e.Graphics.DrawLine(new Pen(SystemColors.Control), Distance_X - 5, Distance_Y - 3, Distance_X - 5, this.Height - 2);//绘制方块的右边线
                e.Graphics.FillRectangle(new SolidBrush(Color.WhiteSmoke), 9, Distance_Y - 3, Distance_X - 19, this.Height - (Distance_Y - 3) - 2);//绘制方块的中间块
            }
            int tem_temHeight = 0;
            string tem_value = "";
            int tem_n = 0;
            int divide = 5;
            Pen tem_p = new Pen(new SolidBrush(Color.Black));
            //横向刻度的设置
            if (UnitStyle == Unit.Cm)//如果刻度的单位是厘米
                Degree = e.Graphics.DpiX / 25.4F;//将像素转换成毫米
            if (UnitStyle == Unit.Pels)//如果刻度的单位是像素
                Degree = 10;//设置10像素为一个刻度
            int tem_width = this.Width - 3;
            tem_n = (int)StartBitH;//记录横向滚动条的位置
            if (tem_n != StartBitH)//如果横向滚动条的位置值为小数
                StartBitH = (int)StartBitH;//对横向滚动条的位置进行取整
            for (float i = 0; i < tem_width; )//在文本框的项端绘制标尺
            {
                tem_temHeight = Scale1;//设置刻度线的最小长度
                float j = (i + (int)StartBitH) / Degree;//获取刻度值
                tem_value = "";
                j = (int)j;//对刻度值进行取整
                if (j % (divide * 2) == 0)//如果刻度值是10进位
                {
                    tem_temHeight = Scale10;//设置最长的刻度线
                    if (UnitStyle == Unit.Cm)//如果刻度的单位为厘米
                        tem_value = Convert.ToString(j / 10);//记录刻度值
                    if (UnitStyle == Unit.Pels)//如果刻度的单位为像素
                        tem_value = Convert.ToString((int)j * 10);//记录刻度值
                }
                else if (j % divide == 0)//如果刻度值的进位为5
                {
                    tem_temHeight = Scale5;//设置刻度线为中等
                }
                tem_p.Width = 1;
                if (RulerStyle == Ruler.Graduation)//如果是以刻度值进行测量
                {
                    //绘制刻度线
                    e.Graphics.DrawLine(tem_p, i + 1 + thisleft, SpaceBetween, i + 1 + thisleft, SpaceBetween + tem_temHeight);
                    if (tem_value.Length > 0)//如果有刻度值
                        //绘制刻度值
                        ProtractString(e.Graphics, tem_value.Trim(), i + 1 + thisleft, SpaceBetween, i + 1 + thisleft, SpaceBetween + tem_temHeight, 0);
                }
                if (RulerStyle == Ruler.Rule)//如果是以标尺进行测量
                {
                    if (tem_value.Length > 0)//如果有刻度值
                    {
                        e.Graphics.DrawLine(tem_p, i + 1 + thisleft, 4, i + 1 + thisleft, 7);//绘制顶端的刻度线
                        e.Graphics.DrawLine(tem_p, i + 1 + thisleft, Distance_Y - 9, i + 1 + thisleft, Distance_Y - 7);//绘制底端的刻度线
                        float tem_space = 3 + (Distance_X - 19F - 9F - StringSize(tem_value.Trim(),this.Font, false)) / 2F;//设置文本的横向位置
                        //绘制文本
                        ProtractString(e.Graphics, tem_value.Trim(), i + 1 + thisleft, (float)Math.Ceiling(tem_space), i + 1 + thisleft, (float)Math.Ceiling(tem_space) + tem_temHeight, 0);
                    }
                }
                i += Degree;//累加刻度的宽度
            }
            //纵向刻度的设置
            if (UnitStyle == Unit.Cm)//如果刻度的单位是厘米
                Degree = e.Graphics.DpiX / 25.4F;//将像素转换成毫米
            if (UnitStyle == Unit.Pels)//如果刻度的单位是像素
                Degree = 10;//刻度值设为10像素
            int tem_height = this.Height - 3;
            tem_n = (int)StartBitV;//记录纵向滚动条的位置
            if (tem_n != StartBitV)//如果纵向滚动条的位置为小数
                StartBitV = (int)StartBitV;//对其进行取整
            for (float i = 0; i < tem_height; )//在文本框的左端绘制标尺
            {
                tem_temHeight = Scale1;//设置刻度线的最小值
                float j = (i + (int)StartBitV) / Degree;//获取当前的刻度值
                tem_value = "";
                j = (int)j;//对刻度值进行取整
                if (j % 10 == 0)//如果刻度值是10进位
                {
                    tem_temHeight = Scale10;//设置刻度线的长度为最长
                    if (UnitStyle == Unit.Cm)//如果刻度的单位是厘米
                        tem_value = Convert.ToString(j / 10);//获取厘米的刻度值
                    if (UnitStyle == Unit.Pels)//如果刻度的单位是像素
                        tem_value = Convert.ToString((int)j * 10);//获取像素的刻度值
                }
                else if (j % 5 == 0)//如果刻度值是5进位
                {
                    tem_temHeight = Scale5;//设置刻度线的长度为中等
                }
                tem_p.Width = 1;
                if (RulerStyle == Ruler.Graduation)//如果是以刻度值进行测量
                {
                    //绘制刻度线
                    e.Graphics.DrawLine(tem_p, SpaceBetween, i + 1 + Distance_Y, SpaceBetween + tem_temHeight, i + 1 + Distance_Y);
                    if (tem_value.Length > 0)//如果有刻度值
                        //绘制刻度值
                        ProtractString(e.Graphics, tem_value.Trim(), SpaceBetween, i + 1 + Distance_Y, SpaceBetween + tem_temHeight, i + 1 + Distance_Y, 1);
                }
                if (RulerStyle == Ruler.Rule)//如果是以标尺进行测量
                {
                    if (tem_value.Length > 0)//如果有刻度值
                    {
                        e.Graphics.DrawLine(tem_p, 4, i + 1 + Distance_Y, 7, i + 1 + Distance_Y);//绘制左端刻度线
                        e.Graphics.DrawLine(tem_p, Distance_Y - 9, i + 1 + Distance_Y, Distance_Y - 7, i + 1 + Distance_Y);//绘制右端刻度线
                        float tem_space = 3 + (Distance_X - 19F - 9F - StringSize(tem_value.Trim(),this.Font, false)) / 2F;//设置文本的纵向位置
                        //绘制文本
                        ProtractString(e.Graphics, tem_value.Trim(), (float)Math.Floor(tem_space), i + 1 + Distance_Y, (float)Math.Floor(tem_space) + tem_temHeight, i + 1 + Distance_Y, 1);
                    }
                }
                i += Degree;//累加刻度值
            }
            if (CodeShow)//如果显示行号
            {
                //设置文本的高度
                float tem_FontHeight = (float)(richTextBox1.Height / (StringSize(CodeSize.ToString(), richTextBox1.Font, false)));
                float tem_tep = richTextBox1.Top;//获取文本框的顶端位置
                int tem_mark = 0;
                for (int i = 0; i < (int)tem_FontHeight; i++)//绘制行号
                {
                    tem_mark = i + (int)CodeSize;//设置代码编号的宽度
                    //绘制行号
                    e.Graphics.DrawString(tem_mark.ToString(), this.Font, new SolidBrush(Color.Red), new PointF(richTextBox1.Left - StringSize(tem_mark.ToString(), this.Font, true) - 2, tem_tep));
                    tem_tep = tem_tep + StringSize("懂", richTextBox1.Font, false);//设置下一个行号的X坐标值
                }
            }

        }

        private void GuageRichTextBox_Resize(object sender, EventArgs e)
        {
            richTextBox1.Top = Distance_X;//设置控件的顶端位置
            richTextBox1.Left = Distance_Y;//设置控件的左端位置
            richTextBox1.Width = this.Width - Distance_X - 2;//设置控件的宽度
            richTextBox1.Height = this.Height - Distance_Y - 2;//设置控件的高度
            this.Invalidate();
        }

        private void richTextBox1_HScroll(object sender, EventArgs e)
        {
            StartBitH = (int)(Math.Abs((float)richTextBox1.GetPositionFromCharIndex(0).X - 1));//检索控件横向内指定字符索引处的位置
            this.Invalidate();
        }

        private void richTextBox1_VScroll(object sender, EventArgs e)
        {
            StartBitV = (int)(Math.Abs((float)richTextBox1.GetPositionFromCharIndex(0).Y - 1));//检索控件纵向内指定字符索引处的位置
            if (CodeShow)//如果显示行号
                CodeSize = (int)Math.Abs((richTextBox1.GetPositionFromCharIndex(0).Y / StringSize("懂", richTextBox1.Font, false)));//设置行号的高度
            this.Invalidate();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 在指定的位置绘制文本信息
        /// </summary>
        /// <param e="Graphics">封装一个绘图的类对象</param>
        /// <param str="string">文本信息</param> 
        /// <param x1="float">左上角x坐标</param> 
        /// <param y1="float">左上角y坐标</param> 
        /// <param x2="float">右下角x坐标</param> 
        /// <param y2="float">右下角y坐标</param> 
        /// <param n="float">标识,判断是在横向标尺上绘制文字还是在纵向标尺上绘制文字</param> 
        public void ProtractString(Graphics e, string str, float x1, float y1, float x2, float y2, float n)
        {
            float TitWidth = StringSize(str,this.Font, true);//获取字符串的宽度
            if (n == 0)//在横向标尺上绘制文字
                e.DrawString(str, this.Font, new SolidBrush(Color.Black), new PointF(x2 - TitWidth / 2, y2 + 1));
            else//在纵向标尺上绘制文字
            {
                StringFormat drawFormat = new StringFormat();//实例化StringFormat类
                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;//设置文本为垂直对齐
                //绘制指定的文本
                e.DrawString(str, this.Font, new SolidBrush(Color.Black), new PointF(x2 + 1, y2 - TitWidth / 2), drawFormat);
            }
        }

        /// <summary>
        /// 获取文本的高度或宽度
        /// </summary>
        /// <param str="string">文本信息</param>
        /// <param font="Font">字体样式</param> 
        /// <param n="bool">标识,判断返回的是高度还是宽度</param> 
        public float StringSize(string str,Font font,bool n)//n==true为width
        {
            Graphics TitG = this.CreateGraphics();//创建Graphics类对象
            SizeF TitSize = TitG.MeasureString(str, font);//将绘制的字符串进行格式化
            float TitWidth = TitSize.Width;//获取字符串的宽度
            float TitHeight = TitSize.Height;//获取字符串的高度
            if (n)
                return TitWidth;//返回文本信息的宽度
            else
                return TitHeight;//返回文本信息的高度
        }
        #endregion
    }
}
