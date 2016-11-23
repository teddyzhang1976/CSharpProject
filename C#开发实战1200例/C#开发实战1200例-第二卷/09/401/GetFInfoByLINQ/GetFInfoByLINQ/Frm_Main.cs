using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GetFInfoByLINQ
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                listView1.Items.Clear();
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                List<FileInfo> myFiles = new List<FileInfo>();//创建List泛型对象
                foreach (string strFile in Directory.GetFiles(textBox1.Text))//遍历选择文件夹中的所有文件
                {
                    myFiles.Add(new FileInfo(strFile));//将遍历的所有文件添加到List对象中
                }
                var values = from strFile in myFiles//使用LINQ从List对象中查找文件
                             group strFile by strFile.Extension into FExten
                             orderby FExten.Key
                             select FExten;
                foreach (var vFiles in values)
                {
                    foreach (var f in vFiles)
                        listView1.Items.Add(f.FullName);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                FileInfo myFile = new FileInfo(listView1.SelectedItems[0].Text);//创建FileInfo对象
                //定义一个字符串数组，用来存储文件的相关属性
                string[] strAttribute = new string[] { myFile.Name, Convert.ToDouble(myFile.Length / 1024).ToString(), myFile.Extension, myFile.CreationTime.ToString(), myFile.IsReadOnly.ToString(), myFile.LastWriteTime.ToString() };
                var values = from str in strAttribute//使用LINQ为文件属性赋值
                             select new
                             {
                                 Name = strAttribute[0].ToString(),
                                 Size = strAttribute[1].ToString(),
                                 Exten = strAttribute[2].ToString(),
                                 CTime = strAttribute[3].ToString(),
                                 ReadOnly = strAttribute[4].ToString(),
                                 WTime = strAttribute[5].ToString()
                             };
                foreach (var v in values)
                {
                    textBox2.Text = v.Name.ToString();//显示文件名
                    textBox4.Text = v.Size.ToString();//显示文件大小
                    textBox3.Text = v.Exten.ToString();//显示文件扩展名
                    textBox5.Text = v.CTime.ToString();//显示文件创建时间
                    textBox6.Text = v.WTime.ToString();//显示文件最后修改时间
                    textBox7.Text = v.ReadOnly.ToString();//显示文件是否只读
                }
            }
        }
    }
}
