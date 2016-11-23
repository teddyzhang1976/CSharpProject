using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace BeautifulButton
{
    public partial class TransparencyButton : UserControl
    {
        public TransparencyButton()
        {
            InitializeComponent();
        }

        #region 公共变量
        public static SmoothingMode sm;
        public static bool pub_ButtonClick = true;//判断按钮是否按下（false为按下）
        public static int pub_Degree = 0;//记录四角弧度的大小范围
        public static int pub_RGB_r0 = 0x130;//按钮背景的R色值
        public static int pub_RGB_r1 = 0x99;//按钮其它颜色的R色值
        #endregion

        #region 添加属性
        private string BNText = "";
        [Browsable(true), Category("透明按钮的属性设置"), Description("设置显示的文本")]   //在“属性”窗口中显示NText属性
        public string NText
        {
            get { return BNText; }
            set
            {
                BNText = value;
                if (BNText.Length > 0)
                    Invalidate();
            }
        }

        private int BDegree = 1;
        [Browsable(true), Category("透明按钮的属性设置"), Description("设置按钮四个角的弧度")]   //在“属性”窗口中显示Degree属性
        public int Degree
        {
            get { return BDegree; }
            set
            {
                BDegree = value;
                if (this.Width >= this.Height)
                    pub_Degree = (int)(this.Height / 2);
                else
                    pub_Degree = (int)(this.Width / 2);
                if (BDegree <= 0)
                    BDegree = 1;
                if (BDegree > pub_Degree)
                    BDegree = pub_Degree;
                if (BDegree > 0)
                    Invalidate();
            }
        }

        private Color DShineColor = Color.Black;
        [Browsable(true), Category("透明按钮的属性设置"), Description("设置按钮的光泽度颜色")]   //在“属性”窗口中显示ShineColor属性
        public Color ShineColor
        {
            get { return DShineColor; }
            set
            {
                DShineColor = value;
                Invalidate();
            }
        }

        private Color DUndersideShine = Color.LightGray;
        [Browsable(true), Category("透明按钮的属性设置"), Description("设置按钮的下部的光泽度")]   //在“属性”窗口中显示UndersideShine属性
        public Color UndersideShine
        {
            get { return DUndersideShine; }
            set
            {
                DUndersideShine = value;
                Invalidate();
            }
        }

        private int DCTransparence = 0;
        [Browsable(true), Category("透明按钮的属性设置"), Description("设置按钮的透明度数")]   //在“属性”窗口中显示CTransparence属性
        public int CTransparence
        {
            get { return DCTransparence; }
            set
            {
                DCTransparence = value;
                if (DCTransparence > 20)
                    DCTransparence = 20;
                if (DCTransparence < 0)
                    DCTransparence = 0;
                if (DCTransparence >= 0)
                    Invalidate();
            }
        }

        private int DCFontDeepness = 1;
        [Browsable(true), Category("透明按钮的属性设置"), Description("设置按钮文本的深度")]   //在“属性”窗口中显示CFontDeepness属性
        public int CFontDeepness
        {
            get { return DCFontDeepness; }
            set
            {
                DCFontDeepness = value;
                if (DCFontDeepness > 20)
                    DCFontDeepness = 20;
                if (DCFontDeepness < 0)
                    DCFontDeepness = 0;
                if (DCFontDeepness >= 0)
                    Invalidate();
            }
        }

        #endregion

        #region 事件
        private void TransparencyButton_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.Transparent;//使当前控件透明
            sm = e.Graphics.SmoothingMode;//设置呈现质量
            Color shineColor = Color.Black;
            Rectangle rect2 = new Rectangle(0, 0, this.Width, this.Height);//设置绘制按钮的矩形区域
            Rectangle rect1 = new Rectangle(0, this.Height / 2, this.Width, this.Height / 2);//设置绘制按钮下半部的矩形区域
            if (this.CTransparence == 0)//如果按钮的透明度为0
            {
                CobOblongDown(rect2, e.Graphics);//绘制按扭的背景
                CobOblong(rect2, e.Graphics, this.ShineColor);//绘制按扭的背景
            }
            else
            {
                if (this.CTransparence > 0)//如果按钮的透明度不为0
                {
                    CobOblongDown(rect2, e.Graphics);//绘制按扭的背景
                    for (int i = 0; i < CTransparence; i++)
                    {
                        CobOblong(rect2, e.Graphics, this.ShineColor);//绘制按扭的背景颜色
                    }
                }
            }

            int tem_n = (int)(this.CTransparence / 3);//获取一个值，用于设置下半部按钮的颜色深度
            if (tem_n == 0)//如果为0
                CobAjar(rect1, e.Graphics, this.ShineColor);//绘制按扭的下半部背景
            else
            {
                if (tem_n > 0)//如果不为0
                {
                    for (int i = 0; i < tem_n; i++)//加深下部按钮的颜色
                    {
                        CobAjar(rect1, e.Graphics, this.ShineColor);//绘制按扭的下半部背景颜色
                    }
                }
            }
            CobOblong(rect2, e.Graphics, this.UndersideShine);//设置下半部按钮的光泽度
            if (pub_ButtonClick == false)//判断按钮是否按下（false为按下）
            {
                CobOblongDown(rect2, e.Graphics);//绘制按扭的背景
            }
            if (this.NText.Length > 0)//如果Text属性中有值
                ProtractText(e.Graphics);//绘制透明按钮的文本信息
        }

        private void TransparencyButton_SizeChanged(object sender, EventArgs e)
        {
            Invalidate();//对控件进行重绘
        }

        private void TransparencyButton_MouseDown(object sender, MouseEventArgs e)
        {
            pub_ButtonClick = false;//按下按钮
            Invalidate();//对控件进行重绘
        }

        private void TransparencyButton_MouseUp(object sender, MouseEventArgs e)
        {
            pub_ButtonClick = true;//松开按钮
            Invalidate();//对控件进行重绘
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 绘制透明按扭的文本
        /// </summary>
        /// <param g="Graphics">封装一个绘图的类对象</param>
        private void ProtractText(Graphics g)
        {
            Graphics TitG = this.CreateGraphics();//创建Graphics类对象
            string TitS = this.NText;//获取图表标题的名称
            SizeF TitSize = TitG.MeasureString(TitS, this.Font);//将绘制的字符串进行格式化
            float TitWidth = TitSize.Width;//获取字符串的宽度
            float TitHeight = TitSize.Height;//获取字符串的高度
            float TitX = 0;//标题的横向坐标
            float TitY = 0;//标题的纵向坐标
            if (this.Height > TitHeight)//如果按钮的高度大于文本的高度
                TitY = (this.Height - TitHeight) / 2;//使文本水平方向局中
            else
                TitY = this.BDegree;//文本置顶
            if (this.Width > TitWidth)//如果按钮的宽度大于文本的宽度
                TitX = (this.Width - TitWidth) / 2;//使文本水平局中
            else
                TitX = this.BDegree;//文本置左
            //设置文本的绘制区域
            Rectangle rect = new Rectangle((int)Math.Floor(TitX), (int)Math.Floor(TitY), (int)Math.Ceiling(TitWidth), (int)Math.Ceiling(TitHeight));
            int opacity = pub_RGB_r1;//设置R色值
            opacity = (int)(.4f * opacity + .5f);//设置渐变值
            for (int i = 0; i < DCFontDeepness; i++)//设置文本的深度
            {
                //设置文本的渐变颜色
                using (LinearGradientBrush br = new LinearGradientBrush(rect, Color.FromArgb(opacity, this.ForeColor), Color.FromArgb(opacity, this.ForeColor), LinearGradientMode.Vertical))
                {
                    g.DrawString(TitS, this.Font, br, new PointF(TitX, TitY));//绘制带有渐变效果的文本
                }
            }
        }

        /// <summary>
        /// 绘制透明按扭的背景色
        /// </summary>
        /// <param rect="Rectangle">绘制按钮的区域</param>
        /// <param g="Graphics">封装一个绘图的类对象</param>
        /// <param fillColor="Color">填充的颜色</param>
        private void CobOblong(Rectangle rect, Graphics g, Color fillColor)
        {
            using (GraphicsPath bh = CreateCobOblong(rect, this.BDegree))//绘制一个圆角矩形
            {
                int opacity = pub_RGB_r0;//设置按钮的R色值
                opacity = (int)(.4f * opacity + .5f);//设置渐变的变化值
                //设置按钮的渐变颜色
                using (LinearGradientBrush br = new LinearGradientBrush(rect, Color.FromArgb(opacity / 5, fillColor), Color.FromArgb(opacity, fillColor), LinearGradientMode.Vertical))
                {
                    g.FillPath(br, bh);//填充按钮背景
                }
                g.SmoothingMode = sm;//设置呈现的质量
            }
        }

        /// <summary>
        /// 绘制透明按扭的下半部背景色
        /// </summary>
        /// <param rect="Rectangle">绘制按钮的下半部区域</param>
        /// <param g="Graphics">封装一个绘图的类对象</param>
        /// <param fillColor="Color">填充的颜色</param>
        private void CobAjar(Rectangle rect, Graphics g, Color fillColor)
        {
            using (GraphicsPath bh = CreateCobAjar(rect, this.BDegree))
            {
                int opacity = pub_RGB_r1;
                opacity = (int)(.4f * opacity + .5f);
                using (LinearGradientBrush br = new LinearGradientBrush(rect, Color.FromArgb(opacity, fillColor), Color.FromArgb(pub_RGB_r1 / 5, fillColor), LinearGradientMode.Vertical))
                {
                    g.FillPath(br, bh);//填充按钮背景
                }
                g.SmoothingMode = sm;//设置呈现的质量
            }
        }

        /// <summary>
        /// 绘制透明按扭按下时的效果
        /// </summary>
        /// <param rect="Rectangle">绘制按钮的区域</param>
        /// <param g="Graphics">封装一个绘图的类对象</param>
        private void CobOblongDown(Rectangle rect, Graphics g)
        {
            using (GraphicsPath bh = CreateCobOblong(rect, this.BDegree))//按钮的圆角绘制
            {
                int opacity = pub_RGB_r1;//设置按钮的R色值
                Color tem_Color = Color.Black;//设置按钮的背景颜色为黑色
                if (pub_ButtonClick == true)//如果按钮没有按下
                {
                    opacity = pub_RGB_r0;//设置按钮的R色值
                    tem_Color = Color.White;//设置按钮的背景颜色为白色
                }
                opacity = (int)(.4f * opacity + .5f);//设置渐变的变化值
                //设置按钮的渐变颜色
                using (LinearGradientBrush br = new LinearGradientBrush(rect, Color.FromArgb(opacity + 20, tem_Color), Color.FromArgb(opacity, tem_Color), LinearGradientMode.Vertical))
                {
                    g.FillPath(br, bh);//填充按钮背景
                }
                g.SmoothingMode = sm;//设置呈现的质量
            }
        }

        /// <summary>
        /// 按钮的圆角绘制
        /// </summary>
        /// <param rect="Rectangle">绘制按钮的区域</param>
        /// <param radius="int">圆角的度数</param>
        private static GraphicsPath CreateCobOblong(Rectangle rectangle, int radius)
        {
            GraphicsPath path = new GraphicsPath();//实例化GraphicsPath类
            int l = rectangle.Left;//获取矩形左上角的X坐标
            int t = rectangle.Top;//获取矩形左上角的Y坐标
            int w = rectangle.Width;//获取矩形的宽度
            int h = rectangle.Height;//获取矩形的高度
            path.AddArc(l, t, 2 * radius, 2 * radius, 180, 90);//在矩形的左上角绘制圆角
            path.AddLine(l + radius, t, l + w - radius, t);//绘制左上角圆角与右上角之间的线段
            path.AddArc(l + w - 2 * radius, t, 2 * radius, 2 * radius, 270, 90);//绘制右上角的圆角
            path.AddLine(l + w, t + radius, l + w, t + h - radius);//绘制左上角、右上角和右下角所形成的三角形
            path.AddArc(l + w - 2 * radius, t + h - 2 * radius, 2 * radius, 2 * radius, 0, 90);//绘制右下角圆角
            path.AddLine(l + radius, t + h, l + w - radius, t + h);//绘制右下角圆角与左上角圆之间的线段
            path.AddArc(l, t + h - 2 * radius, 2 * radius, 2 * radius, 90, 90);//绘制左下角的圆角
            path.AddLine(l, t + radius, l, t + h - radius);//绘制左上角、左下角和右下角之间的三角形
            return path;
        }

        /// <summary>
        /// 按钮的下半个圆角绘制
        /// </summary>
        /// <param rect="Rectangle">绘制下半部按钮的区域</param>
        /// <param radius="int">圆角的度数</param>
        private static GraphicsPath CreateCobAjar(Rectangle rectangle, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int l = rectangle.Left;//获取矩形左上角的X坐标
            int t = rectangle.Top;//获取矩形左上角的Y坐标
            int w = rectangle.Width;//获取矩形的宽度
            int h = rectangle.Height;//获取矩形的高度
            path.AddArc(l, t, 2 * radius, 2 * radius, 0, 0);//绘制左上角的点
            path.AddLine(l, t, l + w, t);//绘制左上角与右上角之间的线段
            path.AddArc(l + w, t, 2 * radius, 2 * radius, 0, 0);//绘制右上角的点
            path.AddLine(l + w, t + radius, l + w, t + h - radius);//绘制左上角、右上角和右下角所形成的三角形
            path.AddArc(l + w - 2 * radius, t + h - 2 * radius, 2 * radius, 2 * radius, 0, 90);//绘制右下角圆角
            path.AddLine(l + radius, t + h, l + w - radius, t + h);//绘制右下角圆角与左上角圆之间的线段
            path.AddArc(l, t + h - 2 * radius, 2 * radius, 2 * radius, 90, 90);//绘制左下角的圆角
            path.AddLine(l, t + radius, l, t + h - radius);//绘制左上角、左下角和右下角之间的三角形
            return path;
        }
        #endregion
    }
}
