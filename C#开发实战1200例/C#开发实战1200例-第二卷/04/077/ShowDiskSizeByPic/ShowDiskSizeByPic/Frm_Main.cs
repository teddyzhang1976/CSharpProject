using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.IO;

namespace ShowDiskSizeByPic
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SelectQuery selectQuery = new SelectQuery("select * from win32_logicaldisk");//查询磁盘信息
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);//创建WMI查询对象
            foreach (ManagementObject disk in searcher.Get())//遍历所有磁盘
            {
                comboBox1.Items.Add(disk["Name"].ToString());//将磁盘名称添加到下拉列表中
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DriveInfo dinfo = new DriveInfo(comboBox1.Text);//实例化DriveInfo
            float tsize = dinfo.TotalSize;//获得磁盘的总容量
            float fsize = dinfo.TotalFreeSpace;//获取剩余容量
            Graphics graphics = this.CreateGraphics();//创建Graphics绘图对象
            Pen pen1 = new Pen(Color.Red);//创建画笔对象
            Brush brush1 = new SolidBrush(Color.WhiteSmoke);//创建笔刷
            Brush brush2 = new SolidBrush(Color.LimeGreen);//创建笔刷
            Brush brush3 = new SolidBrush(Color.RoyalBlue);//创建笔刷
            Font font1 = new Font("Courier New", 16, FontStyle.Bold);//设置字体
            Font font2 = new Font("宋体", 9);//设置字体
            graphics.DrawString("磁盘容量分析", font1, brush2, new Point(60, 50));//绘制文本
            float angle1 = Convert.ToSingle((360 * (Convert.ToSingle(fsize / 100000000000) / Convert.ToSingle(tsize / 100000000000))));//计算绿色饼形图的范围
            float angle2 = Convert.ToSingle((360 * (Convert.ToSingle((tsize - fsize) / 100000000000) / Convert.ToSingle(tsize / 100000000000))));//计算蓝色饼形图的范围
            //调用Graphics对象的FillPie方法绘制饼形图
            graphics.FillPie(brush2, 60, 80, 150, 150, 0, angle1);
            graphics.FillPie(brush3, 60, 80, 150, 150, angle1, angle2);
            graphics.DrawRectangle(pen1, 30, 235, 200, 50);
            graphics.FillRectangle(brush2, 35, 245, 20, 10);
            graphics.DrawString("磁盘剩余容量:" + dinfo.TotalFreeSpace / 1000 + "KB", font2, brush2, 55, 245);
            graphics.FillRectangle(brush3, 35, 265, 20, 10);
            graphics.DrawString("磁盘已用容量:" + (dinfo.TotalSize - dinfo.TotalFreeSpace) / 1000 + "KB", font2, brush3, 55, 265);
        }
    }
}