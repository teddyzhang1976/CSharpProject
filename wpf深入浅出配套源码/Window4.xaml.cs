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

namespace WpfApplication1
{
    /// <summary>
    /// Window4.xaml 的交互逻辑
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
            List<Contry> infos = new List<Contry>() { new Contry() { Name = "中国", Provinces= new List<Province>(){ new Province(){ Name="四川",Citys=new List<City>(){new  City(){Name="绵阳市"
            }}}}}};
            this.textBox1.SetBinding(TextBox.TextProperty, new Binding("/Name") { Source=infos});
            this.textBox2.SetBinding(TextBox.TextProperty, new Binding("/Provinces/Name") { Source = infos });
            this.textBox3.SetBinding(TextBox.TextProperty, new Binding("/Provinces/Citys/Name") { Source = infos });
        }
    }

     class City
    {
        public string Name { set; get; }
    }

    class Province
    {
        public string Name { set; get; }
        public List<City> Citys { set; get; }
    }

    class Contry
    {
        public string Name { set; get; }
        public List<Province> Provinces { get; set; }
    }
}
