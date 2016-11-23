using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace ProductElectronQuote
{
    public partial class Frm_Main : Form
    {
        Hashtable ht = new Hashtable(); 	//初始化一个哈希表对象
        string str; 					//初始化一个字符串str
        public Frm_Main()
        {
            InitializeComponent();
            str = Application.StartupPath + "\\Image";//保存商品图片所在的路径
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(str);//初始化一个DirectoryInfo类的对象
            GetAllFiles(dir); 					//获取指定路径下的所有文件
            foreach (DictionaryEntry de in ht) 		//循环哈希表中的所有数据
                this.comboBox1.Items.Add(de.Key); 	//向comboBox1中添加内容
        }

        public void GetAllFiles(DirectoryInfo dir)
        {
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos(); 	//初始化一个FileSystemInfo类型的实例
            foreach (FileSystemInfo i in fileinfo) 				//循环遍历fileinfo下的所有内容
            {
                if (i is DirectoryInfo) 			//当在DirectoryInfo中存在i时
                {
                    GetAllFiles((DirectoryInfo)i); 	//获取i下的所有文件
                }
                else						//当在DirectoryInfo中不存在i时
                {
                    string str = i.FullName; 		//记录i的绝对路径
                    int b = str.LastIndexOf("\\");	//获取字符串下与指定项匹配的最后一个索引
                    string strType = str.Substring(b + 1);			//获取文件的后缀名
                    //当图片类型为“jpg”或者“bmp”时
                    if (strType.Substring(strType.Length - 3).ToLower() == "jpg" || strType.Substring(strType.Length - 3).ToLower() == "bmp")
                    {
                        ht.Add(strType.Substring(0, strType.Length - 4), strType);	//向哈希表中添加内容
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ht.Values.Count > 0)
            {
                showPic(ht[this.comboBox1.Text].ToString());
            }
            else
            {
                MessageBox.Show("目前还没有海报信息！！！");
            }
        }

        private void showPic(string name)
        {
            this.pictureBox1.ImageLocation = str + "\\" + name;//设置在pictureBox1中显示图片的路径
        }
    }
}