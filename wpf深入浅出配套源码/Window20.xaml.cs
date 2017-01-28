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
    /// Window20.xaml 的交互逻辑
    /// </summary>
    public partial class Window20 : Window
    {
        public Window20()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Human human = new Human();
            School.SetGrade(human, 15);
            int grade = School.GetGrade(human);
            MessageBox.Show(grade.ToString());
        }
    }
}
