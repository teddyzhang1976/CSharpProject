using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DiffuseImage
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        private Bitmap MyBitmap;
        private void button2_Click(object sender, EventArgs e)
        {
            //打开图像文件
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图像文件(JPeg, Gif, Bmp, etc.)|*.jpg;*.jpeg;*.gif;*.bmp;*.tif; *.tiff; *.png| JPeg 图像文件(*.jpg;*.jpeg)|*.jpg;*.jpeg |GIF 图像文件(*.gif)|*.gif |BMP图像文件(*.bmp)|*.bmp|Tiff图像文件(*.tif;*.tiff)|*.tif;*.tiff|Png图像文件(*.png)| *.png |所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //得到原始大小的图像
                Bitmap SourceBitmap = new Bitmap(openFileDialog.FileName);
                //得到缩放后的图像
                MyBitmap = new Bitmap(SourceBitmap, this.pictureBox1.Width, this.pictureBox1.Height);
                this.pictureBox1.Image = MyBitmap;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int width = this.MyBitmap.Width; //图像宽度	
                int height = this.MyBitmap.Height; //图像高度
                Graphics g = this.panel1.CreateGraphics();//实例化Graphics对象
                g.Clear(Color.Gray); //初始为全灰色
                for (int i = 0; i <= width / 2; i++)
                {
                    int j = Convert.ToInt32(i * (Convert.ToSingle(height) / Convert.ToSingle(width)));//获取高和宽的比例
                    Rectangle DestRect = new Rectangle(width / 2 - i, height / 2 - j, 2 * i, 2 * j);//设置缩小后图片的大小
                    Rectangle SrcRect = new Rectangle(0, 0, MyBitmap.Width, MyBitmap.Height);//获取原图片大小
                    g.DrawImage(MyBitmap, DestRect, SrcRect, GraphicsUnit.Pixel);//按照指定的大小绘制原图片
                    System.Threading.Thread.Sleep(10);//线程挂起
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示");
            }
        }
    }
}