using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;//添加的命名空间，对文件进行操作
using System.Threading;//线程序的命名空间

namespace RansackFile
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        public static string tempstr = "";
        string Tem_Dir = "";
        private System.Threading.Thread thdAddFile; //创建一个线程
        //private System.Threading.Thread thdOddDocument; //创建一个线程
        public static TreeNode TN_Docu = new TreeNode();//单个文件的节点
        private static TreeView Tem_TView;

        public delegate void AddFile();//定义托管线程
        /// <summary>
        /// 设置托管线程
        /// </summary>
        public void SetAddFile()
        {
            this.Invoke(new AddFile(RunAddFile));//对指定的线程进行托管
        }

        /// <summary>
        /// 设置线程
        /// </summary>
        public void RunAddFile()
        {
            TreeNode TNode = new TreeNode();//实例化一个线程
            Files_Copy(treeView1, tempstr, TNode, 0);
            Thread.Sleep(0);//持起主线程
            thdAddFile.Abort();//执行线程      
        }

        #region  返回上一级目录
        /// <summary>
        /// 返回上一级目录
        /// </summary>
        /// <param dir="string">目录</param>
        /// <returns>返回String对象</returns>
        public string UpAndDown_Dir(string dir)
        {
            string Change_dir = "";
            Change_dir = Directory.GetParent(dir).FullName;
            return Change_dir;
        }
        #endregion

        #region  显示文件夹下所有子文件夹及文件的名称
        /// <summary>
        /// 显示文件夹下所有子文件夹及文件的名称
        /// </summary>
        /// <param Sdir="string">文件夹的目录</param>
        /// <param TNode="TreeNode">节点</param>
        /// <param n="int">标识，判断当前是文件夹，还是文件</param>
        private void Files_Copy(TreeView TV, string Sdir, TreeNode TNode, int n)
        {
            DirectoryInfo dir = new DirectoryInfo(Sdir);
            try
            {
                if (!dir.Exists)//判断所指的文件或文件夹是否存在
                {
                    return;
                }
                DirectoryInfo dirD = dir as DirectoryInfo;//如果给定参数不是文件夹则退出
                if (dirD == null)//判断文件夹是否为空
                {
                    return;
                }
                else
                {
                    if (n == 0)
                    {
                        TNode = TV.Nodes.Add(dirD.Name);//添加文件夹的名称
                        TNode.Tag = 1;
                    }
                    else
                    {
                        TNode = TNode.Nodes.Add(dirD.Name);//添加文件夹里面各文件夹的名称
                        TNode.Tag = 1;
                    }
                }
                FileSystemInfo[] files = dirD.GetFileSystemInfos();//获取文件夹中所有文件和文件夹
                //对单个FileSystemInfo进行判断,如果是文件夹则进行递归操作
                foreach (FileSystemInfo FSys in files)
                {
                    FileInfo file = FSys as FileInfo;
                    if (file != null)//如果是文件的话，进行文件的复制操作
                    {
                        FileInfo SFInfo = new FileInfo(file.DirectoryName + "\\" + file.Name);//获取文件所在的原始路径
                        TNode.Nodes.Add(file.Name);//添加文件
                        TNode.Tag = 1;
                    }
                    else
                    {
                        string pp = FSys.Name;//获取当前搜索到的文件夹名称
                        Files_Copy(TV, Sdir + "\\" + FSys.ToString(), TNode, 1);//如果是文件夹，则进行递归调用
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                tempstr = folderBrowserDialog1.SelectedPath;
                thdAddFile = new Thread(new ThreadStart(SetAddFile));   //创建一个线程
                thdAddFile.Start(); //执行当前线程
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null)
                Tem_Dir = "";
            else
                Tem_Dir = e.Node.Tag.ToString();
            if (Tem_Dir == "")
            {
                Tem_Dir = UpAndDown_Dir(tempstr) + "\\" + e.Node.FullPath;
                System.Diagnostics.Process.Start(@Tem_Dir);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Tem_TView = new TreeView();
            Tem_TView = treeView1;
        }
    }
}
