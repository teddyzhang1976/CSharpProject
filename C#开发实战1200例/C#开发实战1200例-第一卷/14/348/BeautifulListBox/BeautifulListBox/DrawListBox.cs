using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace BeautifulListBox
{
    public partial class DrawListBox : ListBox
    {
        public DrawListBox()
        {
            InitializeComponent();
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox_DrawItem);
        }

        #region 变量
        private static Brush[] listBoxBrushes;//该数组用来存储绘制listBox1背景的Brush对象
        private static int place = -1;//颜色位置的取值
        private static bool naught = true;//判断是否重绘
        #endregion

        #region 属性
        
        private bool TGradualC = false;
        [Browsable(true), Category("控件的重绘设置"), Description("判断是否进行渐变色的设置")] //在“属性”窗口中显示DataStyle属性
        public bool GradualC
        {
            get { return TGradualC; }
            set
            {
                TGradualC = value;
                this.Invalidate();
            }
        }

        private Color TColorSelect = Color.Gainsboro;
        [Browsable(true), Category("控件的重绘设置"), Description("项被选中后的高亮度颜色")] //在“属性”窗口中显示DataStyle属性
        public Color ColorSelect
        {
            get { return TColorSelect; }
            set
            {
                TColorSelect = value;
                this.Invalidate();
            }
        }

        private Color TColor1 = Color.CornflowerBlue;
        [Browsable(true), Category("控件的重绘设置"), Description("第一个颜色的设置")] //在“属性”窗口中显示DataStyle属性
        public Color Color1
        {
            get { return TColor1; }
            set
            {
                TColor1 = value;
                this.Invalidate();
            }
        }

        private Color TColor1Gradual = Color.Thistle;
        [Browsable(true), Category("控件的重绘设置"), Description("第一个颜色的渐变色设置")] //在“属性”窗口中显示DataStyle属性
        public Color Color1Gradual
        {
            get { return TColor1Gradual; }
            set
            {
                TColor1Gradual = value;
                this.Invalidate();
            }
        }

        private Color TColor2 = Color.PaleGreen;
        [Browsable(true), Category("控件的重绘设置"), Description("第二个颜色的设置")] //在“属性”窗口中显示DataStyle属性
        public Color Color2
        {
            get { return TColor2; }
            set
            {
                TColor2 = value;
                this.Invalidate();
            }
        }

        private Color TColor2Gradual = Color.DarkKhaki;
        [Browsable(true), Category("控件的重绘设置"), Description("第二个颜色的渐变色设置")] //在“属性”窗口中显示DataStyle属性
        public Color Color2Gradual
        {
            get { return TColor2Gradual; }
            set
            {
                TColor2Gradual = value;
                this.Invalidate();
            }
        }
        #endregion

        #region 事件
        /// <summary>
        /// 鼠标移出控件的可见区域时触发
        /// </summary>
        protected virtual void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            Rectangle r = new Rectangle(0, 0, this.Width, this.Height);//设置重绘的区域
            SolidBrush SolidB1 = new SolidBrush(this.Color1);//设置上一行颜色
            SolidBrush SolidB2 = new SolidBrush(this.Color2);//设置下一行颜色
            //设置上一行的渐变色
            LinearGradientBrush LinearG1 = new LinearGradientBrush(r, this.Color1, this.Color1Gradual, LinearGradientMode.BackwardDiagonal);
            //设置下一行的渐变色
            LinearGradientBrush LinearG2 = new LinearGradientBrush(r, this.Color2, this.Color2Gradual, LinearGradientMode.BackwardDiagonal);
            //将单色与渐变色存入Brush数组中
            listBoxBrushes = new Brush[] { SolidB1, LinearG1, SolidB2, LinearG2 };
            e.DrawBackground();
            if (this.Items.Count <= 0)//如果当前控件为空
                return;
            if (e.Index == (this.Items.Count - 1))//如果绘制的是最后一个项
            {
                bool tem_bool = true;
                if (e.Index == 0 && tem_bool)//如果当前绘制的是第一个或最后一个项
                    naught = false;//不进行重绘
            }
            if (naught)//对控件进行重绘
            {
                //获取当前绘制的颜色值
                Brush brush = listBoxBrushes[place = (GradualC) ? (((e.Index % 2) == 0) ? 1 : 3) : (((e.Index % 2) == 0) ? 0 : 2)];
                e.Graphics.FillRectangle(brush, e.Bounds);//用指定的画刷填充列表项范围所形成的矩形
                bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ? true : false;//判断当前项是否被选取中
                if (selected)//如果当前项被选中
                {
                    e.Graphics.FillRectangle(new SolidBrush(ColorSelect), e.Bounds);//绘制当前项
                }
                e.Graphics.DrawString(this.Items[e.Index].ToString(), this.Font, Brushes.Black, e.Bounds);//绘制当前项中的文本
            }
            e.DrawFocusRectangle();//绘制聚焦框
        }

        #endregion
    }
}
