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
using System.Collections.ObjectModel;

namespace WpfApplication1
{
    /// <summary>
    /// Window8.xaml 的交互逻辑
    /// </summary>
    public partial class Window8 : Window
    {
        ObservableCollection<Student> infos = new ObservableCollection<Student>() { 
            new Student(){ Id=1, Age=11, Name="Tom"},
            new Student(){ Id=2, Age=12, Name="Darren"},
            new Student(){ Id=3, Age=13, Name="Jacky"},
            new Student(){ Id=4, Age=14, Name="Andy"}
            };
        public Window8()
        {
            InitializeComponent();

            
            this.lbStudent.ItemsSource = infos;
            

            this.txtStudentId.SetBinding(TextBox.TextProperty,new Binding("SelectedItem.Id"){ Source=lbStudent});
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            infos[2].Name = "付文军";
        }

        
    }
}
