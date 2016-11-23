using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary
{
    public partial class SmoothProgressBar : UserControl
    {
        public SmoothProgressBar()
        {
            InitializeComponent();
        }

        int min = 0; // 设置ProgressBar控件变化的最小值
        int max = 100; //设置ProgressBar控件变化的最大值
        int val = 0; //设置ProgressBar控件的当前值
        Color BarColor = Color.Blue; //初始化一种ARGB颜色

        protected override void OnResize(EventArgs e)
        {
            this.Invalidate();//使当前页面无效从而导致重绘
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;//初始化一个GDI+绘图图面对象
            SolidBrush brush = new SolidBrush(BarColor);//初始化一个单色画笔类
            float percent = (float)(val - min) / (float)(max - min);//保存当前滚动条中的值所占总长度的百分比
            Rectangle rect = this.ClientRectangle;//设置当前的工作区
            rect.Width = (int)((float)rect.Width * percent);//计算进度条的宽度
            g.FillRectangle(brush,rect);//用指定的对象填充工作区
            Draw3DBorder(g);//使控件实现3D效果
            brush.Dispose();//释放画刷所占用的资源
            g.Dispose();//释放GDI+绘图图面对象所占用的资源
        }

        public int Minimum
        {
            get
            {
                return min;//返回最小值
            }

            set
            {
                if(value < 0)//当该值小于0时
                {
                    min = 0;//设置最小值为0
                }

                if(value > max)//当该值大于最大值时
                {
                    min = value;//设定最小值为该值
                }

                if(val < min)//当当前值小于最小值时
                {
                    val = min;//设定当前值为最小值
                }

                this.Invalidate();//使当前操作区域无效从而导致重绘事件
            }
        }

        public int Maximum
        {
            get
            {
                return max;//返回最大值
            }

            set
            {
                if(value < min)//当当前值小于最小值时
                {
                    min = value;//设置最小值为当前值
                }

                max = value;//设置最大值为当前值

                if(val > max)//当当前值大于最大值时
                {
                    val = max;//设置当前值为最大值
                }

                this.Invalidate();//使当前操作区域无效并导致重绘事件
            }
        }

        public int Value
        {
            get
            {
                return val;//返回该值
            }

            set
            {
                int oldValue = val;//保存当前值

                if(value < min)//当该值小于最小值时
                {
                    val = min;//设置该值为最小值
                }
                else if(value > max)//当该值大于最大值时
                {
                    val = max;//设置该值为最大值
                }
                else//当该值介于最小值和最大值之间时
                {
                    val = value;//设置当前值为该值
                }

                float percent;//该变量用来保存进度条中的值所占总长度的百分比

                Rectangle newValueRect = this.ClientRectangle;//初始化一个新的工作区域对象
                Rectangle oldValueRect = this.ClientRectangle;//初始化一个旧的工作区域对象

                percent = (float)(val - min) / (float)(max - min);//用进度条的当前值初始化变量percent
                newValueRect.Width = (int)((float)newValueRect.Width * percent);//设置新工作区域对象的宽度

                percent = (float)(oldValue - min) / (float)(max - min);//用进度条的旧值初始化变量percent
                oldValueRect.Width = (int)((float)oldValueRect.Width * percent);//设置就工作区域对象的宽度

                Rectangle updateRect = new Rectangle();//初始化一个更新区域的对象

                if(newValueRect.Width > oldValueRect.Width)//当新工作区域大于旧工作区域时
                {
                    updateRect.X = oldValueRect.Size.Width;//设置更新区域左上角的X坐标
                    updateRect.Width = newValueRect.Width - oldValueRect.Width;//设置更新区域的宽度
                }
                else//当新工作区域小于或等于就工作区域时
                {
                    updateRect.X = newValueRect.Size.Width;//设置更新区域左上角的X坐标
                    updateRect.Width = oldValueRect.Width - newValueRect.Width;//设置更新区域的宽度
                }

                updateRect.Height = this.Height;//设置更新区域的高度

                this.Invalidate(updateRect);//使当前操作区域无效并导致重绘事件
            }
        }

        public Color ProgressBarColor
        {
            get
            {
                return BarColor;//返回进度条的颜色
            }

            set
            {
                BarColor = value;//设置进度条的颜色等于当前值
            }
        }

        private void Draw3DBorder(Graphics g)
        {
            int PenWidth = (int)Pens.White.Width;//保存钢笔类的宽度

            g.DrawLine(Pens.DarkGray, new Point(this.ClientRectangle.Left, this.ClientRectangle.Top),
           new Point(this.ClientRectangle.Width - PenWidth,this.ClientRectangle.Top));//绘制该控件的上边缘
            g.DrawLine(Pens.DarkGray, new Point(this.ClientRectangle.Left, this.ClientRectangle.Top),
                new Point(this.ClientRectangle.Left,this.ClientRectangle.Height - PenWidth));//绘制控件的左边缘
            g.DrawLine(Pens.White, new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - PenWidth),
           new Point(this.ClientRectangle.Width - PenWidth,this.ClientRectangle.Height - PenWidth));//绘制控件的下边缘
            g.DrawLine(Pens.White, new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Top),
            new Point(this.ClientRectangle.Width - PenWidth,this.ClientRectangle.Height - PenWidth));//绘制控件的右边缘
        } 

    }
}
