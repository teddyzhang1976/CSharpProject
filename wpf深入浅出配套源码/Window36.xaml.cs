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
    /// Window36.xaml 的交互逻辑
    /// </summary>
    public partial class Window36 : Window
    {
        public Window36()
        {
            InitializeComponent();
            InitialCarList();
        }

        private void InitialCarList()
        {
            List<Car> infos = new List<Car>() { 
            new Car(){ AutoMark="Aodi", Name="Aodi", TopSpeed="200", Year="1990"},
            new Car(){ AutoMark="Aodi", Name="Aodi", TopSpeed="250", Year="1998"},
            new Car(){ AutoMark="Aodi", Name="Aodi", TopSpeed="300", Year="2002"},
            new Car(){ AutoMark="Aodi", Name="Aodi", TopSpeed="350", Year="2011"},
            new Car(){ AutoMark="Aodi", Name="Aodi", TopSpeed="500", Year="2020"}
            };
            this.lbInfos.ItemsSource = infos;
        }
    }
}
