using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Runtime.InteropServices;


namespace FileIco
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
                GetListViewItem(textBox1.Text, imageList1, listView1);
        }

        [DllImport("shell32.dll", EntryPoint = "SHGetFileInfo")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttribute, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint Flags);
        [DllImport("User32.dll", EntryPoint = "DestroyIcon")]
        public static extern int DestroyIcon(IntPtr hIcon);
        [DllImport("shell32.dll")]
        public static extern uint ExtractIconEx(string lpszFile, int nIconIndex, int[] phiconLarge, int[] phiconSmall, uint nIcons);
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        public void GetListViewItem(string path, ImageList imglist, ListView lv)//获取指定路径下所有文件及其图标
        {
            lv.Items.Clear();
            SHFILEINFO shfi = new SHFILEINFO();//实例化SHFILEINFO类
            try
            {
                string[] dirs = Directory.GetDirectories(path);//获取指定目录中子目录的名称
                string[] files = Directory.GetFiles(path);//获取目录中文件的名称
                for (int i = 0; i < dirs.Length; i++)//遍历子文件夹
                {
                    string[] info = new string[4];//定义一个数组
                    DirectoryInfo dir = new DirectoryInfo(dirs[i]);//根据文件夹的路径实例化DirectoryInfo类
                    if (!(dir.Name == "RECYCLER" || dir.Name == "RECYCLED" || dir.Name == "Recycled" || dir.Name == "System Volume Information"))
                    {
                        SHGetFileInfo(dirs[i], (uint)0x80, ref shfi, (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi), (uint)(0x100 | 0x400)); //获取文件夹的图标及类型
                        imglist.Images.Add(dir.Name, (Icon)Icon.FromHandle(shfi.hIcon).Clone());//添加图标
                        info[0] = dir.Name;//获取文件夹的名称
                        info[1] = "";//获取文件夹的大小
                        info[2] = "文件夹";//获取类型
                        info[3] = dir.LastWriteTime.ToString();//获取更改时间
                        ListViewItem item = new ListViewItem(info, dir.Name);//实例化ListViewItem类
                        lv.Items.Add(item);//添加当前文件夹的基本信息
                        DestroyIcon(shfi.hIcon);//销毁图标
                    }
                }
                for (int i = 0; i < files.Length; i++)//遍历文件
                {
                    string[] info = new string[4];//定义一个数组
                    FileInfo fi = new FileInfo(files[i]);//根据文件的路径实例化FileInfo类
                    string Filetype = fi.Name.Substring(fi.Name.LastIndexOf(".") + 1, fi.Name.Length - fi.Name.LastIndexOf(".") - 1);//获取文件的类型
                    string newtype = Filetype.ToLower();//将文件类型转换为小写
                    if (!(newtype == "sys" || newtype == "ini" || newtype == "bin" || newtype == "log" || newtype == "com" || newtype == "bat" || newtype == "db"))
                    {
                        SHGetFileInfo(files[i], (uint)0x80, ref shfi, (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi), (uint)(0x100 | 0x400)); //获取文件的图标及类型
                        imglist.Images.Add(fi.Name, (Icon)Icon.FromHandle(shfi.hIcon).Clone());//添加图标
                        info[0] = fi.Name;//获取文件的名称
                        info[1] = fi.Length.ToString();//获取文件的大小
                        info[2] = fi.Extension.ToString();//获取文件的类型
                        info[3] = fi.LastWriteTime.ToString();//获取文件的更改时间
                        ListViewItem item = new ListViewItem(info, fi.Name);//实例化ListViewItem类
                        lv.Items.Add(item);//添加当前文件的基本信息
                        DestroyIcon(shfi.hIcon);//销毁图标
                    }
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}
