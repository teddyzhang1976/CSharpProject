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
    /// Window21.xaml 的交互逻辑
    /// </summary>
    public partial class Window21 : Window
    {
        public Window21()
        {
            InitializeComponent();
            InitializeLayout();
        }

        private void InitializeLayout()
        {
            Grid gd = new Grid();
            gd.ShowGridLines = true;
            gd.RowDefinitions.Add(new RowDefinition());
            gd.RowDefinitions.Add(new RowDefinition());
            gd.RowDefinitions.Add(new RowDefinition());
            gd.ColumnDefinitions.Add(new ColumnDefinition());
            gd.ColumnDefinitions.Add(new ColumnDefinition());
            gd.ColumnDefinitions.Add(new ColumnDefinition());
            Button btn = new Button() { Content="Test"};
            Grid.SetColumn(btn, 1);
            Grid.SetRow(btn, 1);
            gd.Children.Add(btn);
            this.Content = gd;
        }
    }
}
