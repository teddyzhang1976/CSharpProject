using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SumElement
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            string path = "new.xml";//取XML文件全路径
            XElement xe = XElement.Load(path);//加载XML文件
            //用LINQ查询Person元素
            IEnumerable<XElement> element = from ee in xe.Elements("Person")
                                            select ee;
            decimal ageSum = element.Sum(itm => Convert.ToDecimal(itm.Element("Age").Value));//计算年龄合计
            label1.Text = "年龄合计:" + ageSum.ToString() + "岁";//输出合计值
        }
    }
}
