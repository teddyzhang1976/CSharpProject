using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace DrawTool
{
    public partial class Frm_Main : Form
    {
        //布尔型变量，是否正在绘图
        private bool isDrawing = false;
        //绘图时记录鼠标的位置
        private Point startPoint, oldPoint;
        //枚举类型，各种绘图工具
        private enum drawTools
        {
            Pen = 0, Line, Ellipse, Rectangle, String, Rubber, None
        };
        //当前使用的工具
        private drawTools drawTool = drawTools.None;
        //当前编辑的文件名
        private string editFileName;
        //进行操作的位图
        private Image theImage;
        //绘制位图的Graphics实例
        private Graphics ig;
        //绘图使用的色彩
        private Color foreColor = Color.Black;
        private Color backColor = Color.White;

        public Frm_Main()
        {
            InitializeComponent();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.bmp;*.wmf;*.ico;*.cur;*.jgp)|*.bmp;*.wmf;*.ico;*.cur;*.jpg";
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //修改窗口标题
                this.Text = "MyDraw\t" + openFileDialog1.FileName;
                editFileName = openFileDialog1.FileName;
                theImage = Image.FromFile(openFileDialog1.FileName);
                Graphics g = this.CreateGraphics();
                g.DrawImage(theImage, this.ClientRectangle);
                ig = Graphics.FromImage(theImage);
                ig.DrawImage(theImage, this.ClientRectangle);
                //ToolBar可以使用了
                toolStrip1.Enabled = true;
            }
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(backColor);
            toolStrip1.Enabled = true;
            //创建一个Bitmap
            theImage = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            editFileName = "新建文件";
            //修改窗口标题
            this.Text = "MyDraw\t" + editFileName;
            ig = Graphics.FromImage(theImage);
            ig.Clear(backColor);
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "图像(*.bmp)|*.bmp";
            saveFileDialog1.FileName = editFileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                theImage.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
                this.Text = "MyDraw\t" + saveFileDialog1.FileName;
                editFileName = saveFileDialog1.FileName;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                foreColor = colorDialog1.Color;
            }
        }

        private void Frm_Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //如果选择文字输入，则打开strInput窗体
                if (drawTool == drawTools.String)
                {
                    Frm_Text inputBox = new Frm_Text();
                    inputBox.StartPosition = FormStartPosition.CenterParent;
                    if (inputBox.ShowDialog() == DialogResult.OK)
                    {
                        Graphics g = this.CreateGraphics();
                        Font theFont = this.Font;
                        g.DrawString(inputBox.textBox1.Text, theFont, new SolidBrush(foreColor), e.X, e.Y);
                        ig.DrawString(inputBox.textBox1.Text, theFont, new SolidBrush(foreColor), e.X, e.Y);
                    }
                }
                //如果开始绘制，则开始记录鼠标位置
                else if ((isDrawing = !isDrawing) == true)
                {
                    startPoint = new Point(e.X, e.Y);
                    oldPoint = new Point(e.X, e.Y);
                }
            }
        }

        private void Frm_Main_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g;
            g = this.CreateGraphics();

            if (isDrawing)
            {
                switch (drawTool)
                {
                    case drawTools.None:
                        break;
                    case drawTools.Pen:
                        //从上一个点到当前点绘制线段
                        g.DrawLine(new Pen(foreColor, 1), oldPoint, new Point(e.X, e.Y));
                        ig.DrawLine(new Pen(foreColor, 1), oldPoint, new Point(e.X, e.Y));
                        oldPoint.X = e.X;
                        oldPoint.Y = e.Y;
                        break;
                    case drawTools.Line:
                        //首先恢复此次操作之前的图像，然后再添加Line
                        this.Frm_Main_Paint(this, new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle));
                        g.DrawLine(new Pen(foreColor, 1), startPoint, new Point(e.X, e.Y));
                        break;
                    case drawTools.Ellipse:
                        //首先恢复此次操作之前的图像，然后再添加Ellipse
                        this.Frm_Main_Paint(this, new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle));
                        g.DrawEllipse(new Pen(foreColor, 1), startPoint.X, startPoint.Y, e.X - startPoint.X, e.Y - startPoint.Y);
                        break;
                    case drawTools.Rectangle:
                        //首先恢复此次操作之前的图像，然后再添加Rectangle
                        this.Frm_Main_Paint(this, new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle));
                        g.DrawRectangle(new Pen(foreColor, 1), startPoint.X, startPoint.Y, e.X - startPoint.X, e.Y - startPoint.Y);
                        break;
                    case drawTools.String:
                        break;
                    case drawTools.Rubber:
                        //用背景色绘制宽线段
                        g.DrawLine(new Pen(backColor, 20), oldPoint, new Point(e.X, e.Y));
                        ig.DrawLine(new Pen(backColor, 20), oldPoint, new Point(e.X, e.Y));
                        oldPoint.X = e.X;
                        oldPoint.Y = e.Y;
                        break;
                }
            }
        }

        private void Frm_Main_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
            switch (drawTool)
            {
                case drawTools.Line:
                    ig.DrawLine(new Pen(foreColor, 1), startPoint, new Point(e.X, e.Y));
                    break;
                case drawTools.Ellipse:
                    ig.DrawEllipse(new Pen(foreColor, 1), startPoint.X, startPoint.Y, e.X - startPoint.X, e.Y - startPoint.Y);
                    break;
                case drawTools.Rectangle:
                    ig.DrawRectangle(new Pen(foreColor, 1), startPoint.X, startPoint.Y, e.X - startPoint.X, e.Y - startPoint.Y);
                    break;
            }
        }

        private void Frm_Main_Paint(object sender, PaintEventArgs e)
        {
            //将Image中保存的图像，绘制出来
            Graphics g = this.CreateGraphics();
            if (theImage != null)
            {
                g.Clear(Color.White);
                g.DrawImage(theImage, this.ClientRectangle);
            }
        }

        private void Frm_Main_SizeChanged(object sender, EventArgs e)
        {
            this.Frm_Main_Paint(this, new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle));
        }

        private void pen_Click(object sender, EventArgs e)
        {
            drawTool = drawTools.Pen;
        }

        private void line_Click(object sender, EventArgs e)
        {
            drawTool = drawTools.Line;
        }

        private void rectangle_Click(object sender, EventArgs e)
        {
            drawTool = drawTools.Rectangle;
        }

        private void ellipse_Click(object sender, EventArgs e)
        {
            drawTool = drawTools.Ellipse;
        }

        private void text_Click(object sender, EventArgs e)
        {
            drawTool = drawTools.String;
        }

        private void rubber_Click(object sender, EventArgs e)
        {
            drawTool = drawTools.Rubber;
        }
    }
}