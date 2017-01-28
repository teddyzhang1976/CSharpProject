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
    /// Window38.xaml 的交互逻辑
    /// </summary>
    public partial class Window38 : Window
    {
        public Window38()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBlock tb = this.cp.ContentTemplate.FindName("txtBlockName", this.cp) as TextBlock;
            MessageBox.Show(tb.Text);

            //Student38 stu = this.cp.Content as Student38;
            //MessageBox.Show(stu.Name);
        }

        
    }
    public class Student38
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }
        public bool HasJob { get; set; }
    }
}
