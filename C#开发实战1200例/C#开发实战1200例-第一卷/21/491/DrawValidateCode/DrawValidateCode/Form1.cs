using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawValidateCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CodeImage(CheckCode());
        }

        private string CheckCode()								//此方法生成
        {
            int number;
            char code;
            string checkCode = String.Empty;					//声明变量存储随机生成的4位英文或数字
            Random random = new Random();						//生成随机数
            for (int i = 0; i < 4; i++)
            {
                number = random.Next();							//返回非负随机数
                if (number % 2 == 0)							//判断数字是否为偶数
                    code = (char)('0' + (char)(number % 10));
                else											//如果不是偶数
                    code = (char)('A' + (char)(number % 26));
                checkCode += " " + code.ToString();				//累加字符串
            }
            return checkCode;									//返回生成的字符串
        }

        private void CodeImage(string checkCode)
        {
            if (checkCode == null || checkCode.Trim() == String.Empty)
                return;
            System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 9.5)), 22);
            Graphics g = Graphics.FromImage(image);					//创建Graphics对象
            try
            {
                Random random = new Random();						//生成随机生成器
                g.Clear(Color.White); 								//清空图片背景色
                for (int i = 0; i < 3; i++)							//画图片的背景噪音线
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);
                }
                Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold));
                g.DrawString(checkCode, font, new SolidBrush(Color.Red), 2, 2);
                for (int i = 0; i < 150; i++)						//画图片的前景噪音点
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                this.pictureBox1.Width = image.Width;				//设置PictureBox的宽度
                this.pictureBox1.Height = image.Height;				//设置PictureBox的高度
                this.pictureBox1.BackgroundImage = image;			//设置PictureBox的背景图像
            }
            catch
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CodeImage(CheckCode());

        }
    }
}