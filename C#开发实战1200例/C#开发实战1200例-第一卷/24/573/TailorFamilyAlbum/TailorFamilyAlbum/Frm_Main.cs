using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TailorFamilyAlbum
{
    public partial class Frm_Main : Form
    {
        string strPath;
        string strInfo="";
        string[] strName=null;
        int Num = 0;
        int Count = 0;
        public Frm_Main()
        {
            InitializeComponent();
            strPath = System.Environment.CurrentDirectory+"\\Image";
        }

        public void GetAllFiles(DirectoryInfo dir)
        {
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos(); 	//初始化一个FileSystemInfo类型的数组
            foreach (FileSystemInfo i in fileinfo) 					//循环遍历fileinfo中的每一个记录
            {
                if (i is DirectoryInfo) 						//当i在类DirectoryInfo中存在时
                {
                    GetAllFiles((DirectoryInfo)i); 				//获取i下的所有文件
                }
                else										//当不存在该i时
                {
                    string str = i.FullName; 				//记录变量i的全名
                    int b = str.LastIndexOf("\\");				//在此示例中获取最后一个匹配项的索引
                    string strType = str.Substring(b + 1); 	//保存文件的后缀
                    //当文件格式为“jpg”或者“bmp”时
                    if (strType.Substring(strType.Length - 3) == "jpg" || strType.Substring(strType.Length - 3) == "bmp")
                    {
                        strInfo += strType + "#";			//为变量strInfo赋值
                    }
                }
            }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(strPath); 			//实例化一个DirectoryInfo类对象
            GetAllFiles(dir); 								//获取dir下的所有文件
            if (strInfo != "")								//当字符串不为空时
            {
                strName = strInfo.Split('#'); 					//获取文件名
                Num = 0; 								//初始化Num的值
                showPic(Num); 							//显示图片
                Count = strName.Length - 1; 					//记录Array中的元素数
            }
            else										//当字符串为空时
            {
                MessageBox.Show("影集里没有照片");			//弹出信息提示
            }
        }

        private void showPic(int X)
        {
            this.pictureBox1.ImageLocation = strPath + "\\" + strName[X];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Num += 1;
            if (Count >Num)
            {
                showPic(Num);
            }
            else
            {
                Num = 0;
                showPic(Num);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Num -= 1;
            if (Num>=0)
            {
                showPic(Num);
            }
            else
            {
                Num = Count-1;
                showPic(Num);
            }   
        }
    }
}