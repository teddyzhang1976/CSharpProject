using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DateToTreeView
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        //声明本程序需要的变量
        public static string[,] recordInfo;

        //窗体加载时，显示原有的数据
        private void Form1_Load(object sender,EventArgs e)
        {
            string P_Connection = string.Format(//创建数据库连接字符串
             "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test.mdb;User Id=Admin");
            OleDbDataAdapter P_OLeDbDataAdapter = new OleDbDataAdapter(
                "select au_id as 用户编号,au_lname as 用户名,phone as 联系电话  from authors",
                P_Connection);
            DataSet ds = new DataSet();
            P_OLeDbDataAdapter.Fill(ds,"UserInfo");
            dataGridView1.DataSource = ds.Tables["UserInfo"].DefaultView;
            TreeNode treeNode = new TreeNode("用户信息",0,0);
            treeView1.Nodes.Add(treeNode);
            //默认情况下追加节点
            追加节点ToolStripMenuItem.Checked = true;
        }

        //DataGridView的按下鼠标事件
        private void dataGridView1_MouseDown(object sender,MouseEventArgs e)
        {
            if(dataGridView1.SelectedCells.Count != 0)
            {
                //定义一个二维数组，数组中的每一行代表DataGridView中的一条记录
                recordInfo = new string[dataGridView1.Rows.Count,dataGridView1.Columns.Count];

                //当按下鼠标左键时，首先获取选定行，记录每一行对应的信息
                for(int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if(dataGridView1.Rows[i].Selected)
                    {
                        for(int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            recordInfo[i,j] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
            }
        }

        //当鼠标进入TreeView控件时，触发的操作
        private void treeView1_MouseEnter(object sender,EventArgs e)
        {
            if(追加节点ToolStripMenuItem.Checked == true)
            {
                #region 代码区域
                if(recordInfo != null && recordInfo.Length != 0)
                {
                    //用双重for循环遍历数组recordInfo中的内容
                    for(int i = 0; i < recordInfo.GetLength(0); i++)
                    {
                        for(int j = 0; j < recordInfo.GetLength(1); j++)
                        {
                            //判断数组中的值是否为空
                            if(recordInfo[i,j] != null)
                            {
                                if(j == 0)
                                {
                                    //向TreeView中加入节点
                                    TreeNode Node1 = new TreeNode(recordInfo[i,j].ToString());
                                    treeView1.SelectedNode.Nodes.Add(Node1);
                                    treeView1.SelectedNode = Node1;
                                }
                                else
                                {
                                    //添加子级节点下的子节点
                                    TreeNode Node2 = new TreeNode(recordInfo[i,j].ToString());
                                    treeView1.SelectedNode.Nodes.Add(Node2);
                                }
                            }

                        }
                        treeView1.SelectedNode = treeView1.Nodes[0];
                        treeView1.ExpandAll();
                    }
                    //清空recordInfo中的记录
                    for(int m = 0; m < recordInfo.GetLength(0); m++)
                    {
                        for(int n = 0; n < recordInfo.GetLength(1); n++)
                        {
                            recordInfo[m,n] = null;
                        }
                    }
                }

                #endregion
            }
            if(清空内容ToolStripMenuItem.Checked == true)
            {
                if(treeView1.SelectedNode.Nodes.Count != 0)
                {
                    treeView1.SelectedNode.Remove();
                    TreeNode treeNode = new TreeNode("用户信息",0,0);
                    treeView1.Nodes.Add(treeNode);
                    treeView1.SelectedNode = treeNode;
                    #region 代码区域
                    if(recordInfo != null && recordInfo.Length != 0)
                    {
                        //用双重for循环遍历数组recordInfo中的内容
                        for(int i = 0; i < recordInfo.GetLength(0); i++)
                        {
                            for(int j = 0; j < recordInfo.GetLength(1); j++)
                            {
                                //判断数组中的值是否为空
                                if(recordInfo[i,j] != null)
                                {
                                    if(j == 0)
                                    {
                                        //向TreeView中加入节点
                                        TreeNode Node1 = new TreeNode(recordInfo[i,j].ToString());
                                        treeView1.SelectedNode.Nodes.Add(Node1);
                                        treeView1.SelectedNode = Node1;
                                    }
                                    else
                                    {
                                        //添加子级节点下的子节点
                                        TreeNode Node2 = new TreeNode(recordInfo[i,j].ToString());
                                        treeView1.SelectedNode.Nodes.Add(Node2);
                                    }
                                }

                            }
                            treeView1.SelectedNode = treeView1.Nodes[0];
                            treeView1.ExpandAll();
                        }
                        //清空recordInfo中的记录
                        for(int m = 0; m < recordInfo.GetLength(0); m++)
                        {
                            for(int n = 0; n < recordInfo.GetLength(1); n++)
                            {
                                recordInfo[m,n] = null;
                            }
                        }
                    }

                    #endregion
                    追加节点ToolStripMenuItem.Checked = true;
                    清空内容ToolStripMenuItem.Checked = false;
                }

            }
        }

        #region 默认项的设置
        private void 清空内容ToolStripMenuItem_Click(object sender,EventArgs e)
        {
            if(追加节点ToolStripMenuItem.Checked == true)
            {
                清空内容ToolStripMenuItem.Checked = true;
                追加节点ToolStripMenuItem.Checked = false;
            }
        }

        private void 追加节点ToolStripMenuItem_Click(object sender,EventArgs e)
        {
            if(清空内容ToolStripMenuItem.Checked == true)
            {
                追加节点ToolStripMenuItem.Checked = true;
                清空内容ToolStripMenuItem.Checked = false;
            }
        }

        #endregion
    }
}
