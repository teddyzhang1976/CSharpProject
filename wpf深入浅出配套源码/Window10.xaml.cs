using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace WpfApplication1
{
    /// <summary>
    /// Window10.xaml 的交互逻辑
    /// </summary>
    public partial class Window10 : Window
    {
        public Window10()
        {
            InitializeComponent();
            BindingInfo();
        }

        private void BindingInfo()
        {
            //XmlDocument doc = new XmlDocument();
            //doc.Load(@"d:\我的文档\visual studio 2010\Projects\WpfApplication2\WpfApplication1\StudentData.xml");

            XmlDataProvider dp = new XmlDataProvider();
            dp.Source = new Uri(@"d:\我的文档\visual studio 2010\Projects\WpfApplication2\WpfApplication1\StudentData.xml");
           // dp.Document = doc;

            dp.XPath = @"StudentList/Student";
            this.listView1.DataContext = dp;
            this.listView1.SetBinding(ListView.ItemsSourceProperty, new Binding());
        }
    }
}
