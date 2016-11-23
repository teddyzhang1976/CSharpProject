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

namespace JPGChangeBMP
{
    public partial class Frm_Main : Form
    {
        Bitmap bitmap;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.jpg|*.jpg";
            openFileDialog.Title = "打开图像文件";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (bitmap != null)
                {
                    bitmap.Dispose();
                }
                string fileName = openFileDialog.FileName;
                bitmap = new Bitmap(fileName);
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
                pictureBox.Image = bitmap;
                FileInfo f = new FileInfo(fileName);
                this.Text = "图像转换:" + f.Name;
                this.label1.Text = f.Name;
                buttonConvert.Enabled = true;
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

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedItem == null)							//如果没有选定项
            {
                return;											//退出本次操作
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();		//实例化SaveFileDialog类
                saveFileDialog.Title = "转化为:";						//设置“另存为”对话框的题标
                saveFileDialog.OverwritePrompt = true;					//如果文件名存在则提示
                saveFileDialog.CheckPathExists = true; 					//如果文件的路径不存在则提示
                saveFileDialog.Filter = comboBox.Text + "|" + comboBox.Text;	//设置文件类型
                if (saveFileDialog.ShowDialog() == DialogResult.OK)		//打开“另存为”对话框
                {
                    string fileName = saveFileDialog.FileName;			//获取另存为文件的路径及名称
                    bitmap.Save(fileName, ImageFormat.Bmp); 			//调用Save方法将图片保存为Bmp格式
                    FileInfo f = new FileInfo(fileName);					//实例化FileInfo类
                    this.Text = "图像转换:" + f.Name;					//设置窗体标题栏
                    label1.Text = f.Name;
                }
            }
        }
    }
}