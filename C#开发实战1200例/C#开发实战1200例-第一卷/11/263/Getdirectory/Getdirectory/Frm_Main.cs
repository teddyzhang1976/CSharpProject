using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Getdirectory
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TreeNode CountNode = new TreeNode("我的电脑");//初始化TreeView控件添加总结点
            TreeViewFile.Nodes.Add(CountNode);
            ListViewShow(CountNode);	//初始化ListView控件
        }

        private void ListViewShow(TreeNode NodeDir)//初始化ListView控件，把TrreView控件中的数据添加进来
        {
            ListViewFile.Clear();
            if (NodeDir.Parent == null)// 如果当前TreeView的父结点为空，就把我的电脑下的分区名称添加进来
            {
                foreach (string DrvName in Directory.GetLogicalDrives())//获得硬盘分区名
                {
                    ListViewItem ItemList = new ListViewItem(DrvName);
                    ListViewFile.Items.Add(ItemList);//添加进来
                }
            }
            else//如果当前TreeView的父结点不为空，把点击的结点，做为一个目录文件的总结点
            {
                foreach (string DirName in Directory.GetDirectories((string)NodeDir.Tag))//编历当前分区或文件夹所有目录
                {
                    ListViewItem ItemList = new ListViewItem(DirName);
                    ListViewFile.Items.Add(ItemList);
                }
                foreach (string FileName in Directory.GetFiles((string)NodeDir.Tag))//编历当前分区或文件夹所有目录的文件
                {
                    ListViewItem ItemList = new ListViewItem(FileName);
                    ListViewFile.Items.Add(ItemList);
                }
            }
        }
        private void ListViewShow(string DirFileName)//获取当有文件夹内的文件和目录
        {
            ListViewFile.Clear();//清空控件内容
            foreach (string DirName in Directory.GetDirectories(DirFileName))
            {
                ListViewItem ItemList = //创建控件项
                    new ListViewItem(DirName);
                ListViewFile.Items.Add(ItemList);//向控件添加项
            }
            foreach (string FileName in Directory.GetFiles(DirFileName))
            {
                ListViewItem ItemList = //创建控件项
                    new ListViewItem(FileName);
                ListViewFile.Items.Add(ItemList);//向控件添加项
            }
        }

        private void TreeViewShow(TreeNode NodeDir)//初始化TreeView控件
        {
            if (NodeDir.Nodes.Count == 0)//判断节点数量是否为0
            {
                if (NodeDir.Parent == null)//如果结点为空显示硬盘分区
                {
                    foreach (string DrvName in Directory.GetLogicalDrives())
                    {
                        TreeNode aNode = new TreeNode(DrvName);//创建节点对象
                        aNode.Tag = DrvName;//向控件中添加数据
                        NodeDir.Nodes.Add(aNode);//添加节点
                    }
                }
                else// 不为空，显示分区下文件夹
                {
                    foreach (string DirName in Directory.GetDirectories((string)NodeDir.Tag))
                    {
                        TreeNode aNode = new TreeNode(DirName);//创建节点对象
                        aNode.Tag = DirName;//向控件中添加数据
                        NodeDir.Nodes.Add(aNode);//添加节点
                    }
                }
            }
        }


        private void TreeViewFile_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ListViewShow(e.Node);//初始化ListView控件
            TreeViewShow(e.Node);//初始化TreeView控件
        }

        private void ListViewFile_DoubleClick(object sender, EventArgs e)
        {
            foreach (int ListIndex in ListViewFile.SelectedIndices)
            {
                ListViewShow(//获取文件和目录
                    ListViewFile.Items[ListIndex].Text);
            }
        }
    }
}