using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DummyKey
{
    public partial class FecitButton : Button
    {
        public FecitButton()
        {
            InitializeComponent();
            base.Font = new Font("宋体", 9.75F, FontStyle.Bold);
            base.Width = 26;
            base.Height = 25;
        }

        private Color Color_Brush = Color.MediumPurple;
        private Color Color_Pen = Color.Indigo;
        public static bool MouseE = false;

        private bool TChecked = false;
        [Browsable(true), Category("按钮操作"), Description("设置按钮是否被按下，如按下，则为true")]
        public bool Checked
        {
            get { return TChecked; }
            set
            {
                TChecked = value;
                Invalidate();
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Color tem_colorb = Color_Brush;
            Color tem_colorp = Color_Pen;
            if (Checked)
            {
                Color_Brush = Color.Pink;
                Color_Pen = Color.PaleVioletRed;
            }
            else
            {
                Color_Brush = tem_colorb;
                Color_Pen = tem_colorp;
            }
            SolidBrush tem_Brush = new SolidBrush(Color_Brush);
            Pen tem_Pen = new Pen(new SolidBrush(Color_Pen), 2);
            e.Graphics.FillRectangle(tem_Brush, 0, 0, this.Width, this.Height);
            e.Graphics.DrawRectangle(tem_Pen, 1, 1, this.Width - 2, this.Height - 2);
            ProtractText(e.Graphics);
        }

        /// <summary>
        /// 鼠标移入控件的可见区域时触发
        /// </summary>
        protected override void OnMouseEnter(EventArgs e)
        {
            Color_Brush = Color.LightSteelBlue;
            Color_Pen = Color.LightSlateGray;
            Invalidate();
            base.OnMouseEnter(e);
        }

        /// <summary>
        /// 鼠标移出控件的可见区域时触发
        /// </summary>
        protected override void OnMouseLeave(EventArgs e)
        {
            Color_Brush = Color.MediumPurple;
            Color_Pen = Color.Indigo;
            Invalidate();
            base.OnMouseLeave(e);
        }

        private void ProtractText(Graphics g)
        {
            Graphics TitG = this.CreateGraphics();//创建Graphics类对象
            string TitS = base.Text;//获取图表标题的名称
            SizeF TitSize = TitG.MeasureString(TitS, this.Font);//将绘制的字符串进行格式化
            float TitWidth = TitSize.Width;//获取字符串的宽度
            float TitHeight = TitSize.Height;//获取字符串的高度
            float TitX = 0;//标题的横向坐标
            float TitY = 0;//标题的纵向坐标
            if (this.Height > TitHeight)
                TitY = (this.Height - TitHeight) / 2F;
            else
                TitY = 1;
            if (this.Width > TitWidth)
                TitX = (this.Width - TitWidth) / 2F;
            else
                TitX = 2;
            Rectangle rect = new Rectangle((int)Math.Floor(TitX), (int)Math.Floor(TitY), (int)Math.Ceiling(TitWidth), (int)Math.Ceiling(TitHeight));
            g.DrawString(TitS, base.Font,new SolidBrush(base.ForeColor), new PointF(TitX, TitY));

        }
    }
}
