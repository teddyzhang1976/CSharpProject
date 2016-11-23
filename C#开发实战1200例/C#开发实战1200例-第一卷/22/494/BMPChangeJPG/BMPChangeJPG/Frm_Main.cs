using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace BMPChangeJPG
{
    public partial class Frm_Main : Form
    {
        Bitmap bitmap;//定义Bitmap类
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();		//实例化OpenFileDialog类
            openFileDialog.Filter = "*.bmp|*.bmp";						//设置文件类型
            openFileDialog.Title = "打开图像文件";						//设置“打开文件”对话框的标题
            openFileDialog.Multiselect = false;							//只能选择一个文件
            if (openFileDialog.ShowDialog() == DialogResult.OK)			//打开文件对话框
            {
                if (bitmap != null)									//如果bitmap不为空
                {
                    bitmap.Dispose();								//释放资源
                }
                string fileName = openFileDialog.FileName;					//获取选择文件的路径
                bitmap = new Bitmap(fileName);							//实例化bitmapod 
                if (bitmap.Width > bitmap.Height)							//如果图片的宽度大于高度
                {
                    pictureBox.Width = panel2.Width;						//设置控件的宽度
                    pictureBox.Height = (int)((double)bitmap.Height * panel2.Width / bitmap.Width);		//设置控件的高度
                }
                else
                {
                    pictureBox.Height = panel2.Height;						//设置控件的高度
                    pictureBox.Width = (int)((double)bitmap.Width * panel2.Height / bitmap.Height);		//设置控件的宽度
                }
                pictureBox.Image = bitmap;								//显示图片
                FileInfo f = new FileInfo(fileName);							//实例化FileInfo类
                this.Text = "图像转换:" + f.Name;							//在窗体标题栏中显示图片的名称
                this.label1.Text = f.Name;								//显示图片的名称
                buttonConvert.Enabled = true;
            }
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedItem == null)								//如果没有选择项
            {
                return;//退出本次操作
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();			//实例化SaveFileDialog类
                saveFileDialog.Title = "转化为:";							//设置标题
                saveFileDialog.OverwritePrompt = true;						//如果文件名存在则提示
                saveFileDialog.CheckPathExists = true;						//如果文件的路径不存在则提示
                saveFileDialog.Filter = comboBox.Text + "|" + comboBox.Text;		//设置文件类型
                if (saveFileDialog.ShowDialog() == DialogResult.OK)			//打开“另存为”对话框
                {
                    string fileName = saveFileDialog.FileName;				//获取另存为的文件路径和文件名
                    bitmap.Save(fileName, ImageFormat.Jpeg); 				//调用Save方法将图片保存为Jpeg格式
                    FileInfo f = new FileInfo(fileName);						//实例化FileInfo类
                    this.Text = "图像转换:" + f.Name;						//在窗体标题栏中显示转换的文件名
                    label1.Text = f.Name;
                }
            }
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            pictureBox.Top = panel1.Top;
            pictureBox.Left = panel1.Left;
            if (bitmap != null)
            {
                if (bitmap.Width > bitmap.Height)
                {
                    pictureBox.Width = panel2.Width;
                    pictureBox.Height = (int)((double)bitmap.Height * panel2.Width / bitmap.Width);
                }
                else
                {
                    pictureBox.Height = panel2.Height;
                    pictureBox.Width = (int)((double)bitmap.Width * panel2.Height / bitmap.Height);
                }
            }
            else
            {
                pictureBox.Width = panel2.Width;
                pictureBox.Height = panel2.Height;
            }
            pictureBox.Refresh();
        }
    }
}