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
    /// Window39.xaml 的交互逻辑
    /// </summary>
    public partial class Window39 : Window
    {
        public Window39()
        {
            InitializeComponent();
        }

        private void txtBoxName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = e.OriginalSource as TextBox; //获取事件发起的源头
            ContentPresenter cp = tb.TemplatedParent as ContentPresenter;//获取模板目标
            Student39 stu = cp.Content as Student39;//获取业务逻辑数据
            this.lvStudent.SelectedItem = stu;//设置ListView选中项
            //访问界面元素
            ListViewItem lvi = this.lvStudent.ItemContainerGenerator.ContainerFromItem(stu) as ListViewItem;
            CheckBox cb = this.FindVisualChild<CheckBox>(lvi);
            MessageBox.Show(cb.Name);

        }

        private ChildType FindVisualChild<ChildType>(DependencyObject obj) where ChildType : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj,i);
                if (child != null && child is ChildType)
                {
                    return child as ChildType;
                }
                else
                {
                    ChildType childOfChild = FindVisualChild<ChildType>(child);
                    if(childOfChild!=null)
                    {
                        return childOfChild;
                    }
                }

            }
            return null;
        }
    }

    public class Student39
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }
        public bool HasJob { get; set; }
    }
}
