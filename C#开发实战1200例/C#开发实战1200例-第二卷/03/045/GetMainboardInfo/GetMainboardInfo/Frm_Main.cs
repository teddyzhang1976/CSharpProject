using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace GetMainboardInfo
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            SelectQuery Query = new SelectQuery("SELECT * FROM Win32_BaseBoard");//查询主板
            ManagementObjectSearcher driveID = new ManagementObjectSearcher(Query);//创建WMI查询对象
            //获取查询结果
            ManagementObjectCollection.ManagementObjectEnumerator data = driveID.Get().GetEnumerator();
            data.MoveNext();//循环读取
            ManagementBaseObject board = data.Current;//获取当前主板
            textBox1.Text = board.GetPropertyValue("SerialNumber").ToString();//获取主板编号
            textBox2.Text = board.GetPropertyValue("Manufacturer").ToString();//获取主板制造商
            textBox3.Text = board.GetPropertyValue("Product").ToString();//获取主板型号
        }
    }
}
