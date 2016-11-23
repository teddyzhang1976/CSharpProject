using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShowBusStation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static IList<object> items = new List<object>();//定义一个泛型对象，用于存储对象
        /// <summary>
        /// 通过迭代器获取泛型中的所有对象值
        /// </summary>
        /// <param Node="n">泛型对象</param>
        /// <returns>IEnumerable<object></returns>
        public static IEnumerable<object> GetValues()
        {
            if (items != null)//如果泛型不为空
            {
                foreach (object i in items)//遍历泛型中的对象
                    yield return i;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //向泛型集合中添加站点数据
            items.Add("长新东路");
            items.Add("同康路");
            items.Add("农行干校");
            items.Add("八里堡");
            items.Add("东荣大路");
            items.Add("二木材");
            items.Add("胶合板厂");
            items.Add("阜丰路");
            items.Add("荣光路");
            items.Add("东盛路");
            items.Add("安乐路");
            items.Add("岭东路");
            items.Add("公平路");
            items.Add(108);
            items.Add(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (object i in GetValues())//遍历泛型集合
                listView1.Items.Add(i.ToString());//在列表视图中显示公交车站点
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();//关闭当前窗体
        }
    }
}
