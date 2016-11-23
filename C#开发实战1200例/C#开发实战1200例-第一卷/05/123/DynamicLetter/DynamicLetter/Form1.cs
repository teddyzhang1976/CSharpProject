using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;

namespace DynamicLetter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Graphics Car_Paint = panel1.CreateGraphics();//实例化绘图对象
            string Car_Str = "编程词典网";//定义要绘制的动态文字
            Character character = new Character();//实例化自定义类对象
            character.CartoonEffect(panel1, Car_Str);//在窗体上显示动态文字
        }
    }
    class Character
    {
        System.Drawing.Graphics g;//定义Graphics对象
        static int[] FSize = new int[3] { 20, 25, 30 };//设置字体的大小
        int Str_block = 5;//字体间的间隔
        Font Str_Font = new Font("宋体", FSize[0], FontStyle.Bold);//定义字体样式
        Color Str_Color = Color.Orange;//定义字体颜色
        float Str_Width = 0;//获取字符串的位置
        float Str_Height = 0;
        float Panel_W = 0;//获取控件的宽度
        float Panel_H = 0;//获取控件的高度
        Color Panel_C;//记录控件的背景颜色
        float Str_Odd_Width = 0;//获取单个文字的宽度
        Thread th;//定义线程

        /// <summary>
        /// 在Panel控件中绘制动画文字
        /// </summary>
        /// <param Panel="C_Panel">显示文字的容器控件</param>
        /// <param string="C_Str">文字字符串</param>
        public void CartoonEffect(Panel C_Panel, string C_Str)
        {
            g = C_Panel.CreateGraphics();//为控件创建Graphics对象
            Panel_H = C_Panel.Height;//获取控件的高度
            Panel_W = C_Panel.Width;//获取控件的宽度
            Panel_C = C_Panel.BackColor;//获取控件背景颜色
            GetTextInfo(C_Str);//获取文字的大小及位置
            g.FillRectangle(new SolidBrush(Panel_C), 0, 0, Panel_W, Panel_H);//用控件背景填充控件
            ProtractText(C_Str, 0);//绘制文字
            //实例化ParameterizedThreadStart委托线程
            th = new Thread(new ParameterizedThreadStart(DynamicText));
            th.Start(C_Str);//传递一个字符串的参数
        }

        /// <summary>
        /// 获取文字的大小及绘制位置
        /// </summary>
        /// <param string="C_Str">文字字符串</param>
        public void GetTextInfo(string C_Str)
        {
            SizeF TitSize = g.MeasureString(C_Str, Str_Font);//将绘制的字符串进行格式化
            Str_Width = TitSize.Width;//获取字符串的宽度
            Str_Height = TitSize.Height;//获取字符串的高度
            Str_Odd_Width = Str_Width / (float)C_Str.Length;//获取单个文字的宽度
            Str_Width = (float)((Str_Odd_Width + Str_block) * C_Str.Length);//获取文字的宽度
            Str_Width = (Panel_W - Str_Width) / 2F;//使文字居中
            Str_Height = Panel_H - Str_Height;//使文字显示在控件底端
        }

        /// <summary>
        /// 绘制全部文字
        /// </summary>
        /// <param string="C_Str">绘制的文字字符串</param>
        public void ProtractText(string C_Str, int n)
        {
            float Str_Place = Str_Width;//单个字符的位置
            for (int i = 0; i < C_Str.Length; i++)//遍历字符串中的文字
            {
                if (i != n)
                    ProtractOddText(C_Str[i].ToString(), Str_Font, Str_Place, Str_Height);//绘制单个文字
                Str_Place += Str_Odd_Width + Str_block;//获取下一个文字的位置
            }
        }

        /// <summary>
        /// 绘制单个文字
        /// </summary>
        /// <param name="C_Odd_Str">单个文字字符串</param>
        /// <param name="S_Font">文本样式</param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        public void ProtractOddText(string C_Odd_Str, Font S_Font, float left, float top)
        {
            g.DrawString(C_Odd_Str, S_Font, new SolidBrush(Str_Color), new PointF(left, top));//绘制字符串中单个文字
        }

        /// <summary>
        /// 通过迭代器实现字符串的遍历
        /// </summary>
        /// <param string="n">文字字符串</param>
        /// <returns>返回单个文字</returns>
        public static IEnumerable<object> Transpose(string n)
        {
            if (n.Length > 0)//如果泛型不为空
            {
                foreach (object i in n)//对字符串进行遍历
                    yield return i;
            }
        }

        /// <summary>
        /// 绘制动态文字
        /// </summary>
        /// <param string="C_Str">绘制的文字字符串</param>
        public void DynamicText(Object C_Str)
        {
            float tem_left = 0;//获取当前文字的左端位置
            float tem_top = 0;//获取当前文字的顶端位置
            float tem_w = 0;//获取文字的宽度
            float tem_h = 0;//获取文字的高度
            float tem_place = Str_Width;//获取起始文字的位置
            Font Tem_Font = new Font("黑体", FSize[0], FontStyle.Bold);//定义字体样式
            int p = 0;//记录字符串中文字的索引号
            int Str_Index = 0;
            try
            {
                foreach (object s in Transpose(C_Str.ToString()))//遍历字符串
                {
                    for (int i = 1; i < 5; i++)//
                    {
                        if (i >= 3)
                            p = Convert.ToInt16(Math.Floor(i / 2F));
                        else
                            p = i;
                        ProtractText(C_Str.ToString(), Str_Index);
                        Tem_Font = new Font("黑体", FSize[p], FontStyle.Bold);//定义字体样式
                        SizeF TitSize = g.MeasureString(s.ToString(), Str_Font);//将绘制的单个文字进行格式化
                        tem_w = TitSize.Width;//获取文字的宽度
                        tem_h = TitSize.Height;//获取文字串的高度
                        tem_left = tem_place - (tem_w - Str_Odd_Width) / 2F;//获取文字改变大小后的左端位置
                        tem_top = Str_Height - (Str_Height - tem_h) / 2F;//获取文字改变大小后的顶端位置
                        ProtractOddText(s.ToString(), Tem_Font, tem_left, tem_top);//绘制单个文字
                        Thread.Sleep(200);//待待0.2秒
                        g.FillRectangle(new SolidBrush(Panel_C), 0, 0, Panel_W, Panel_H);//清空绘制的文字
                    }
                    tem_place += Str_Odd_Width + Str_block;//计算下一个文字的左端位置
                    Str_Index += 1;//将索引号定位到下一个文字
                }
                ProtractText(C_Str.ToString(), -1);//恢复文字的原始绘制样式
                //实例化ParameterizedThreadStart委托线程
                th = new Thread(new ParameterizedThreadStart(DynamicText));
                th.Start(C_Str);//传递一个字符串的参数
            }
            catch//这里之所以用异常语句，是在关闭窗体时关闭线程
            {
                th.Abort();//关闭线程
            }
        }
    }
}
