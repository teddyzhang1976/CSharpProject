using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeautifulComboBox
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            beautyComboBox.Items.Add("白菜");//向ComboBox中添加“白菜”字段
            beautyComboBox.Items.Add("萝卜");//向ComboBox中添加“萝卜”字段
            beautyComboBox.Items.Add("土豆");//向ComboBox中添加“土豆”字段
            beautyComboBox.Items.Add("洋葱");//向ComboBox中添加“洋葱”字段
            beautyComboBox.Items.Add("南瓜");//向ComboBox中添加“南瓜”字段
            beautyComboBox.SelectedIndex = 0;//设置ComboBox控件默认选中第一项
        }

        private void beautyComboBox_DrawItem(object sender,DrawItemEventArgs e)
        {
            Graphics gComboBox = e.Graphics;//声明一个GDI+绘图图面类的对象
            Rectangle rComboBox = e.Bounds;//声明一个表示矩形的位置和大小类的对象
            Size imageSize = imageList1.ImageSize;//声明一个有序整数对的对象
            FontDialog typeFace = new FontDialog();//定义一个字体类对象
            Font Style = typeFace.Font;//定义一个定义特定的文本格式类对象
            if(e.Index >= 0)//当绘制的索引项存在时
            {
                string temp = (string)beautyComboBox.Items[e.Index];//获取ComboBox控件索引项下的文本内容
                StringFormat stringFormat = new StringFormat();//定义一个封装文本布局信息类的对象
                stringFormat.Alignment = StringAlignment.Near;//设定文本的布局方式
                if(e.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect))//当绘制项没有键盘加速键和焦点可视化提示时
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red),rComboBox);//用指定的颜色填充自定义矩形的内部
                    imageList1.Draw(e.Graphics,rComboBox.Left,rComboBox.Top,e.Index);//在指定位置绘制指定索引的图片
                    e.Graphics.DrawString(temp,Style,new SolidBrush(Color.Black),rComboBox.Left + imageSize.Width,rComboBox.Top);//在指定的位置并且用指定的Font对象绘制指定的文本字符串
                    e.DrawFocusRectangle();//在指定的边界范围内绘制聚焦框
                }
                else //当绘制项有键盘加速键或者焦点可视化提示时
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue),rComboBox);//用指定的颜色填充自定义矩形的内部
                    imageList1.Draw(e.Graphics,rComboBox.Left,rComboBox.Top,e.Index);//在指定位置绘制指定索引的图片
                    e.Graphics.DrawString(temp,Style,new SolidBrush(Color.Black),rComboBox.Left + imageSize.Width,rComboBox.Top);//在指定的位置并且用指定的Font对象绘制指定的文本字符串
                    e.DrawFocusRectangle();//在指定的边界范围内绘制聚焦框
                }
            }
        }
    }
}
