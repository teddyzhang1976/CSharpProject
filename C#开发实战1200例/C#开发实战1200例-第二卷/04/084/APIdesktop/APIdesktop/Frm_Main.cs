using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Imaging;
namespace APIdesktop
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        #region 调用API
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfoA")]
        static extern Int32 SystemParametersInfo(Int32 uAction, Int32 uParam, string lpvparam, Int32 fuwinIni);
        private const int SPI_SETDESKWALLPAPER = 20;
        #endregion
        Frm_Browser frm2;
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listView1.Items.Clear();
                string[] files = openFileDialog1.FileNames;
                string[] fileinfo = new string[3];
                for (int i = 0; i < files.Length; i++)
                {
                    string path = files[i].ToString();
                    string fileName = path.Substring(path.LastIndexOf("\\") + 1, path.Length - 1 - path.LastIndexOf("\\"));
                    string filetype = fileName.Substring(fileName.LastIndexOf(".") + 1, fileName.Length - 1 - fileName.LastIndexOf("."));
                    fileinfo[0] = fileName;
                    fileinfo[1] = path;
                    fileinfo[2] = filetype;
                    ListViewItem lvi = new ListViewItem(fileinfo);
                    listView1.Items.Add(lvi);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int x = this.Location.X;
            int y = this.Location.Y;
            frm2 = new Frm_Browser();
            frm2.x = x + this.Width;
            frm2.y = y;
            frm2.Hide();
            openFileDialog1.Filter = "支持的图片格式|*.jpeg;*.png;*.bmp;*.jpg";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);
            }
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton2_Click(sender, e);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 设为桌面背景ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string FPath = listView1.SelectedItems[0].SubItems[1].Text;
                //获取指定图片的扩展名
                string SFileType = FPath.Substring(FPath.LastIndexOf(".") + 1, (FPath.Length - FPath.LastIndexOf(".") - 1));
                //将扩展名转换成小写
                SFileType = SFileType.ToLower();
                //获取文件名
                string SFileName = FPath.Substring(FPath.LastIndexOf("\\") + 1, (FPath.LastIndexOf(".") - FPath.LastIndexOf("\\") - 1));
                //如果图片的类型是bmp则调用API中的方法将其设置为桌面背景
                if (SFileType == "bmp")
                {
                    SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, FPath, 1);
                }
                else
                {
                    string SystemPath = Environment.SystemDirectory;//获取系统路径
                    string path = SystemPath + "\\" + SFileName + ".bmp";
                    FileInfo fi = new FileInfo(path);
                    if (fi.Exists)
                    {
                        fi.Delete();
                        PictureBox pb = new PictureBox();
                        pb.Image = Image.FromFile(FPath);
                        pb.Image.Save(SystemPath + "\\" + SFileName + ".bmp", ImageFormat.Bmp);
                    }
                    else
                    {
                        PictureBox pb = new PictureBox();
                        pb.Image = Image.FromFile(FPath);
                        pb.Image.Save(SystemPath + "\\" + SFileName + ".bmp", ImageFormat.Bmp);
                    }
                    SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, 1);
                }
            }
        }
        
        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (frm2 != null)
                {
                    frm2.Close();
                }
                frm2 = new Frm_Browser();
                string path = listView1.SelectedItems[0].SubItems[1].Text;
                int x = this.Location.X;
                int y = this.Location.Y;
                frm2.x = x + this.Width;
                frm2.y = y;
                frm2.pictureBox1.Image = Image.FromFile(path);
                frm2.Show();
                this.Focus();
            }
            else
            {
                if (frm2 != null)
                {
                    frm2.Close();
                }
                frm2 = new Frm_Browser();
                int x = this.Location.X;
                int y = this.Location.Y;
                frm2.x = x + this.Width;
                frm2.y = y;
                frm2.Hide();
                this.Focus();
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string path = listView1.SelectedItems[0].SubItems[1].Text;
                frm2.pictureBox1.Image = Image.FromFile(path);
                frm2.Show();
                this.Focus();
            }
        }
    }
}
