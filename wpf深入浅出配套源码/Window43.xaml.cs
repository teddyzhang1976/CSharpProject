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
    /// Window43.xaml 的交互逻辑
    /// </summary>
    public partial class Window43 : Window
    {
        public Window43()
        {
            InitializeComponent();
            InitialInfo();
        }

        private void InitialInfo()
        {
            List<Student38> infos = new List<Student38>() { 
             new Student38(){ Id=2, Name="Darren", Skill="WPF"},
             new Student38(){ Id=1, Name="Tom", Skill="Java"},
             new Student38(){ Id=3, Name="Jacky", Skill="Asp.net"},
             new Student38(){ Id=2, Name="Andy", Skill="C#"},
            };
            this.lbInfos.ItemsSource = infos;
        }
    }
}
