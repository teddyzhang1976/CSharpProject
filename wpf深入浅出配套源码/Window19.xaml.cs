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
    /// Window19.xaml 的交互逻辑
    /// </summary>
    public partial class Window19 : Window
    {
        Student0 stu;
        public Window19()
        {
            InitializeComponent();
            stu = new Student0();
            Binding bind = new Binding("Text") { Source=textBox1};

            stu.SetBinding(Student0.NameProperty, bind);
           
            textBox2.SetBinding(TextBox.TextProperty, new Binding("Name") { Source=stu});
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            //Student0 stu = new Student0();
            //stu.SetValue(Student0.NameProperty, textBox1.Text);

            //textBox2.SetValue(TextBox.TextProperty, stu.GetValue(Student0.NameProperty));
            //stu.Name = textBox1.Text;
            //textBox2.Text = stu.Name;
        }
    }

    public class Student0:DependencyObject
    {
        public string Name
        {
            get {
                return (string)GetValue(NameProperty);
            }
            set
            {
                SetValue(NameProperty, value);
            }
        }

        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(Student0));
        public BindingExpressionBase SetBinding(DependencyProperty dp, BindingBase bind)
        {
            return BindingOperations.SetBinding(this,dp,bind);
        }
    }

    public class Human:DependencyObject
    {
       
    }

    public class School : DependencyObject
    {

        public static int GetGrade(DependencyObject obj)
        { 
            return (int)obj.GetValue(GradeProperty);
        }

        public static void SetGrade(DependencyObject obj, int value)
        {
            obj.SetValue(GradeProperty, value);
        }

        // Using a DependencyProperty as the backing store for Grade.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GradeProperty =
            DependencyProperty.RegisterAttached("Grade", typeof(int), typeof(School), new UIPropertyMetadata(0));
        
    }

    
}
