using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;
namespace ImgMicroimage
{
    public partial class Frm_Main : Form
    {
        public class CustomListView : ListView
        {
            public CustomListView()
            {
                SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
                UpdateStyles();
            }
        }
        CustomListView clv = new CustomListView();
        
        public Frm_Main()
        {
            InitializeComponent();
        }
        string filePath;
        public Image ResourceImage;
        private int ImageWidth;
        private int ImageHeight;
        public string ErrMessage;
        public Thread td;
        public bool GetReducedImage(double Percent, string targetFilePath)
        {
            try
            {
                Bitmap bt = new Bitmap(120, 120);							//创建Bitmap实例
                Graphics g = Graphics.FromImage(bt);						//创建Graphics实例
                g.Clear(Color.White);									//设置画布背景颜色为白色
                Image ReducedImage;									//缩略图
                Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                ImageWidth = Convert.ToInt32(ResourceImage.Width * Percent);		//设置宽度
                ImageHeight = Convert.ToInt32(ResourceImage.Height * Percent);	//设置高度
                //获取所谓图
                ReducedImage = ResourceImage.GetThumbnailImage(ImageWidth, ImageHeight, callb, IntPtr.Zero);
                if (ImageWidth > ImageHeight)							//如果原图宽度大于高度
                {
                    //缩放图片
                    g.DrawImage(ReducedImage, 0, (int)(120 - ImageHeight) / 2, ImageWidth, ImageHeight);
                }
                else
                {
                    g.DrawImage(ReducedImage, (int)(120 - ImageWidth) / 2, 0, ImageWidth, ImageHeight);
                }
                g.DrawRectangle(new Pen(Color.Gray), 0, 0, 119, 119);			//绘制缩略图的边框
                bt.Save(@targetFilePath, ImageFormat.Jpeg);					//保存缩略图
                bt.Dispose();											//释放对象
                ReducedImage.Dispose();								//释放对象
                return true;
            }
            catch (Exception e)
            {
                ErrMessage = e.Message;
                return false;
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }
        private void a()
        {
            double percent;
            string[] a = new string[2];
            DirectoryInfo di = new DirectoryInfo(filePath);
            FileSystemInfo[] fi = di.GetFileSystemInfos();
            DirectoryInfo di2 = new DirectoryInfo("c:\\LsTemp");
            for (int i = 0; i < fi.Length; i++)
            {
                string imgType = fi[i].ToString().Substring(fi[i].ToString().LastIndexOf(".") + 1, fi[i].ToString().Length - 1 - fi[i].ToString().LastIndexOf("."));
                if (imgType.ToLower() == "jpeg" || imgType.ToLower() == "gif" || imgType.ToLower() == "png" || imgType.ToLower() == "jpg" || imgType.ToLower() == "bmp")
                {
                    string imgName = fi[i].ToString();
                    imgName = imgName.Remove(imgName.LastIndexOf("."));
                    string newPath;
                    if (filePath.Length == 3)
                    {
                        newPath = filePath + imgName + "." + imgType;
                    }
                    else
                    {
                        newPath = filePath + "\\" + imgName + "." + imgType;
                    }
                    ResourceImage = Image.FromFile(newPath);
                    if (ResourceImage.Width < ResourceImage.Height)
                    {
                        percent = (double)120 / ResourceImage.Height;
                    }
                    else
                    {
                        percent = (double)120 / ResourceImage.Width;
                    }
                    if (!di2.Exists)
                    {
                        Directory.CreateDirectory("c:\\LsTemp");
                        if (GetReducedImage(percent, "c:\\LsTemp\\_" + imgName + ".JPG"))
                        {
                            imageList1.Images.Add(i.ToString(), Image.FromFile("c:\\LsTemp\\_" + imgName + ".JPG"));
                            a[0] = imgName + "." + imgType;
                            ListViewItem lvi = new ListViewItem(a);
                            lvi.ImageKey = i.ToString();
                            clv.Items.Add(lvi);
                        }
                    }
                    else
                    {
                        if (GetReducedImage(percent, "c:\\LsTemp\\_" + imgName + ".JPG"))
                        {
                            imageList1.Images.Add(i.ToString(), Image.FromFile("c:\\LsTemp\\_" + imgName + ".JPG"));
                            a[0] = imgName + "." + imgType;
                            ListViewItem lvi = new ListViewItem(a);
                            lvi.ImageKey = i.ToString();
                            clv.Items.Add(lvi);
                        }
                    }
                    ResourceImage.Dispose();
                }
                tsslText.Text = "共有" + this.clv.Items.Count.ToString() + "张图片";
            }
            td.Abort();
        }
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                clv.Items.Clear();
                filePath = folderBrowserDialog1.SelectedPath;
                td = new Thread(new ThreadStart(a));
                td.Start();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void deletefile()
        {
            try
            {
                DirectoryInfo di2 = new DirectoryInfo("c:\\LsTemp");
                if (di2.Exists)
                {
                    Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
                    fso.DeleteFolder("c:\\LsTemp", true);
                }
            }
            catch
            {
                deletefile();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (td != null)
            {
                td.Abort();
            }
            deletefile();

        }

        private void clv_Click(object sender, EventArgs e)
        {
            if (clv.SelectedItems.Count > 0)
            {
                string pName = clv.SelectedItems[0].Text;
                if (filePath.Length == 3)
                {
                    tsslPath.Text = "图片路径：" + filePath + pName;
                }
                else
                {
                    tsslPath.Text = "图片路径：" + filePath + "\\" + pName;
                }
            }
        }

        private void clv_DoubleClick(object sender, EventArgs e)
        {
            if (clv.SelectedItems.Count > 0)
            {
                string pName = clv.SelectedItems[0].Text;
                if (filePath.Length == 3)
                {
                    System.Diagnostics.Process.Start(filePath + pName);
                    tsslPath.Text = "图片路径：" + filePath + pName;
                }
                else
                {
                    System.Diagnostics.Process.Start(filePath + "\\" + pName);
                    tsslPath.Text = "图片路径：" + filePath + "\\" + pName;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            panel1.Controls.Add(clv);
            clv.Dock = DockStyle.Fill;
            clv.LargeImageList = imageList1;
            clv.View = View.LargeIcon;
            clv.DoubleClick += new EventHandler(clv_DoubleClick);
            clv.Click+=new EventHandler(clv_Click);   
        }
    }
}
