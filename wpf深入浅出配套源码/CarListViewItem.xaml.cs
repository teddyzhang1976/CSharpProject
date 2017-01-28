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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// CarListViewItem.xaml 的交互逻辑
    /// </summary>
    public partial class CarListViewItem : UserControl
    {
        public CarListViewItem()
        {
            InitializeComponent();
        }

        private Car car;

        public Car Car
        {
            get { return car; }
            set
            {
                car = value;
                this.txtBlockName.Text = car.Name;
                this.txtBlockYear.Text = car.Year;
                this.igLogo.Source = new BitmapImage(new Uri(@"Resource/Image/"+car.AutoMark+".png",UriKind.Relative));
            }
        }
    }
}
