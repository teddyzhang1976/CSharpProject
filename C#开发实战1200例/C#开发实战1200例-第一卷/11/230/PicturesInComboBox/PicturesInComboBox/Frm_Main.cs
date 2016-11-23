using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PicturesInComboBox
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private ImageList G_ImageList;//声明ImageList字段


        private void cbox_DisplayPictures_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (G_ImageList != null)//判断ImageList是否为空
            {
                Graphics g = e.Graphics;//得到绘图对象
                Rectangle r = e.Bounds;//得到绘图范围
                Size imageSize = G_ImageList.ImageSize;//获取图像大小
                if (e.Index >= 0)//判断是否有绘制项
                {
                    Font fn = new Font("宋体", 10, FontStyle.Bold);//创建字体对象
                    string s = cbox_DisplayPictures.Items[e.Index].ToString();//得到绘制项的字符串
                    DrawItemState dis = e.State;
                    if (e.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect))
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.LightYellow), r);//画条目背景
                        G_ImageList.Draw(e.Graphics, r.Left, r.Top, e.Index);//绘制图像
                        e.Graphics.DrawString(s, fn, new SolidBrush(Color.Black),//显示字符串
                            r.Left + imageSize.Width, r.Top);
                        e.DrawFocusRectangle();//显示取得焦点时的虚线框
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.LightGreen), r);//画条目背景
                        G_ImageList.Draw(e.Graphics, r.Left, r.Top, e.Index);//绘制图像
                        e.Graphics.DrawString(s, fn, new SolidBrush(Color.Black),//显示字符串 
                            r.Left + imageSize.Width, r.Top);
                        e.DrawFocusRectangle();//显示取得焦点时的虚线框 
                    }
                }
            }
        }

        private void btn_Begin_Click(object sender, EventArgs e)
        {
            btn_Begin.Enabled = false;//停用开始按钮
            cbox_DisplayPictures.DrawMode = DrawMode.OwnerDrawFixed;//设置绘制元素方式
            cbox_DisplayPictures.DropDownStyle = //设置组合框样式
                ComboBoxStyle.DropDownList;
            cbox_DisplayPictures.Items.Add("小车");//添加项
            cbox_DisplayPictures.Items.Add("卡车");//添加项
            cbox_DisplayPictures.Items.Add("工具");//添加项
            cbox_DisplayPictures.Items.Add("朋友");//添加项
            G_ImageList = new ImageList();//创建ImageList对象
            G_ImageList.Images.Add(global::PicturesInComboBox.Properties.Resources.a);//添加图片
            G_ImageList.Images.Add(global::PicturesInComboBox.Properties.Resources.b);//添加图片
            G_ImageList.Images.Add(global::PicturesInComboBox.Properties.Resources.c);//添加图片
            G_ImageList.Images.Add(global::PicturesInComboBox.Properties.Resources.d);//添加图片
        }
    }
}
