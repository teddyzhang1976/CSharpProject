using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SearchRootElement
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string xmlFilePath = "Employee.xml";//xml文件存放的路径
            XDocument doc = XDocument.Load(xmlFilePath);//加载xml文件
            label1.Text="根元素为："+doc.Root.Name;//查询根元素
        }
    }
}
