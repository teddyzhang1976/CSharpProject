using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.IO;
using System.Threading;
using System.Drawing.Imaging;
namespace MusicViewDesk
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        string path;

        private void 关闭电脑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           baseClass.ExitWindowsEx(baseClass.EWX_SHUTDOWN, 0);
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 设置桌面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("desk.cpl");
        }

        private void 系统信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("MSINFO32.exe");
        }

        private void 隐藏任务栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (隐藏任务栏ToolStripMenuItem.CheckState== CheckState.Unchecked)
            {
                baseClass.ShowWindow(baseClass.FindWindow("Shell_TrayWnd", null), 0);
                隐藏任务栏ToolStripMenuItem.Checked = true;
            }
            else
            {
                baseClass.ShowWindow(baseClass.FindWindow("Shell_TrayWnd", null), 5);
                隐藏任务栏ToolStripMenuItem.Checked = false;
            }
        }

        private void 隐藏桌面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (隐藏桌面ToolStripMenuItem.CheckState == CheckState.Unchecked)
            {
                baseClass.ShowWindow(baseClass.FindWindow("progman", null), 0);
                隐藏桌面ToolStripMenuItem.Checked = true;
            }
            else
            {
                baseClass.ShowWindow(baseClass.FindWindow("progman", null), 5);
                隐藏桌面ToolStripMenuItem.Checked = false;
            }
        }

        private void 壁纸居中ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseClass.SetDesk(0);
        }

        private void 平铺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseClass.SetDesk(1);
        }

        private void 壁纸拉伸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseClass.SetDesk(2);
        }

        private void 系统设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Set frm2 = new Frm_Set();
            frm2.ShowDialog();
        }

        string musicPath;//音乐路径 
        string picPath;//图片路径
        string pictime;//时间间隔
        string screenpath;//屏保路径
        private bool getinfo()
        {
            bool flag = false;
            musicPath = baseClass.IniReadValue("setup", "musicpath", path);
            picPath = baseClass.IniReadValue("setup", "picpath", path);
            pictime = baseClass.IniReadValue("setup", "pictime", path);
            screenpath = baseClass.IniReadValue("setup", "screen", path);
            if (musicPath != "" && pictime != "" && picPath != "" && screenpath != "")
            {
                DirectoryInfo di = new DirectoryInfo(musicPath);
                DirectoryInfo di1 = new DirectoryInfo(picPath);
                if (di.Exists||di1.Exists)
                {
                    flag = true;
                }
            }
            return flag;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            path = Application.StartupPath.ToString();
            path = path.Substring(0, path.LastIndexOf("\\"));
            path = path.Substring(0, path.LastIndexOf("\\"));
            path += @"\Setup.ini";
            CheckForIllegalCrossThreadCalls = false;
            if (!getinfo())
            {
                MessageBox.Show("请先对系统进行设置！");
            }
        }
        private void 开启音乐屏保ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getinfo())
            {
                baseClass.ScreenStart();
                axWindowsMediaPlayer1.URL = musicPath;
            }
        }


        private void 启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getinfo())
            {
                if ((int)axWindowsMediaPlayer1.playState == 2)
                {
                    timer1.Interval = Convert.ToInt32(pictime) * 1000;
                    timer1.Start();
                    启动ToolStripMenuItem.Enabled = false;
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                }
                else
                {
                    timer1.Interval = Convert.ToInt32(pictime) * 1000;
                    timer1.Start();
                    启动ToolStripMenuItem.Enabled = false;
                    axWindowsMediaPlayer1.URL = musicPath;
                }
            }
            else
            {
                MessageBox.Show("请先对系统进行设置！");
            }
        }

        private void ConvertType()
        {
            string FPath = picp;
            //获取指定图片的扩展名
            string SFileType = FPath.Substring(FPath.LastIndexOf(".") + 1, (FPath.Length - FPath.LastIndexOf(".") - 1));
            //将扩展名转换成小写
            SFileType = SFileType.ToLower();
            //获取文件名
            string SFileName = FPath.Substring(FPath.LastIndexOf("\\") + 1, (FPath.LastIndexOf(".") - FPath.LastIndexOf("\\") - 1));
            //如果图片的类型是bmp则调用API中的方法将其设置为桌面背景
            if (SFileType == "bmp")
            {
                baseClass.SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, FPath, 1);
            }
            else
            {
                if (SFileType != "db")
                {
                    string SystemPath = Environment.SystemDirectory;//获取系统路径
                    
                    DirectoryInfo di = new DirectoryInfo(SystemPath + "\\WildWolf");
                    if (di.Exists)
                    {
                        di.Delete(true);
                        Directory.CreateDirectory(SystemPath + "\\WildWolf");
                    }
                    else
                    {
                        Directory.CreateDirectory(SystemPath + "\\WildWolf");
                    }
                    string path = SystemPath + "\\WildWolf\\" + SFileName + ".bmp";
                    FileInfo fi = new FileInfo(path);
                    if (fi.Exists)
                    {
                        fi.Delete();
                        PictureBox pb = new PictureBox();
                        pb.Image = Image.FromFile(FPath);
                        pb.Image.Save(SystemPath + "\\WildWolf\\" + SFileName + ".bmp", ImageFormat.Bmp);
                    }
                    else
                    {
                        PictureBox pb = new PictureBox();
                        pb.Image = Image.FromFile(FPath);
                        pb.Image.Save(SystemPath + "\\WildWolf\\" + SFileName + ".bmp", ImageFormat.Bmp);
                    }
                    baseClass.SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, 1);
                }
            }
        }

        int i = 0;
        string[] pic;
        string picp;
        private const int SPI_SETDESKWALLPAPER = 20;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pic = Directory.GetFiles(picPath);
            int plength = pic.Length;
            if (i <plength)
            {
                picp = pic[i].ToString();
                ConvertType();
                i++;
            }
            else
            {
                i = 0;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void 暂停ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            启动ToolStripMenuItem.Enabled = true;
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }
    }
}
