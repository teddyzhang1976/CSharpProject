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
using System.Data;
using System.Xml.Linq;

namespace WpfApplication1
{
    /// <summary>
    /// Window12.xaml 的交互逻辑
    /// </summary>
    public partial class Window12 : Window
    {
        public Window12()
        {
            InitializeComponent();
            BindingDataByXml();
        }

        private void BindingDataByCLR()
        {
            List<Student> infos = new List<Student>()
            {
                new Student(){Id=1, Age=29, Name="Tim"},
                 new Student(){Id=1, Age=28, Name="Tom"},
                  new Student(){Id=1, Age=27, Name="Kyle"},
                   new Student(){Id=1, Age=26, Name="Tony"},
                    new Student(){Id=1, Age=25, Name="Vina"},
                     new Student(){Id=1, Age=24, Name="Mike"}
            };
            this.listView1.ItemsSource = from stu in infos where stu.Name.StartsWith("T") select stu;
        }


        private void BindingDataByDataTable()
        {
            DataTable dtInfo = CreateDataTable();
            this.listView1.ItemsSource = from row in dtInfo.Rows.Cast<DataRow>()
                                         where Convert.ToString(row["Name"]).StartsWith("T")
                                         select new Student()
                                         {
                                             Id = Convert.ToInt32(row["Id"]), Name=Convert.ToString(row["Name"]),Age=Convert.ToInt32(row["Age"])
                                         };
            
        }

        private void BindingDataByXml()
        {
            XDocument xd = XDocument.Load(@"d:\我的文档\visual studio 2010\Projects\WpfApplication2\WpfApplication1\testDate.xml");

            this.listView1.ItemsSource = from element in xd.Descendants("Student")
                                         where element.Attribute("Name").Value.StartsWith("T")
                                         select new Student()
                                             {
                                                 Name = element.Attribute("Name").Value,
                                                 Id = Convert.ToInt32(element.Attribute("Id").Value),
                                                 Age = Convert.ToInt32(element.Attribute("Age").Value)
                                             };
        }

        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable("newtable");

            DataColumn[] columns = new DataColumn[] { new DataColumn("Id"), new DataColumn("Name"), new DataColumn("Age")};
            dt.Columns.AddRange(columns);
            return dt;
        }
    }
}
