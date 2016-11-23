using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;//引用与输入输出文件流有关的命名空间
using System.Xml;//引用与XML有关的命名空间

namespace BindingXML
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }                                                                                          

        private XmlDocument NexusDocument = new XmlDataDocument();//定义一个XML文档对象
        private void BindingXML_Load(object sender, EventArgs e)
        {
            string filePath = "NexusPoint.xml";//定义一个变量保存XML文件的路径
            if(File.Exists(filePath))//当在指定路径下存在该文件时
            {
                NexusDocument.Load(filePath);//加载该路径下的XML文件
                RecursionTreeControl(NexusDocument.DocumentElement,treeView1.Nodes);//将加载完成的XML文件显示在TreeView控件中
                treeView1.ExpandAll();//展开TreeView控件中的所有项
            }
        }
         /// <summary>
         /// RecursionTreeControl:表示将XML文件的内容显示在TreeView控件中
         /// </summary>
         /// <param name="xmlNode">将要加载的XML文件中的节点元素</param>
         /// <param name="nodes">将要加载的XML文件中的节点集合</param>
        private void RecursionTreeControl(XmlNode xmlNode,TreeNodeCollection nodes)
        {
            foreach(XmlNode node in xmlNode.ChildNodes)//循环遍历当前元素的子元素集合
            {
                string temp = (node.Value != null ? node.Value : (node.Attributes != null && node.Attributes.Count > 0) ? node.Attributes[0].Value : node.Name);//表示TreeNode节点的文本内容
                TreeNode new_child = new TreeNode(temp);//定义一个TreeNode节点对象
                nodes.Add(new_child);//向当前TreeNodeCollection集合中添加当前节点
                RecursionTreeControl(node,new_child.Nodes);//调用本方法进行递归
            }
        }
    }
}
