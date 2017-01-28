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
using WpfApplication1.Model;

namespace WpfApplication1
{
    /// <summary>
    /// Window14.xaml 的交互逻辑
    /// </summary>
    public partial class Window14 : Window
    {
        public Window14()
        {
            InitializeComponent();
            SetBinding();
        }

        private void SetBinding()
        {
            ObjectDataProvider objpro = new ObjectDataProvider();
            objpro.ObjectInstance = new Caculate();
          
            objpro.MethodName = "Add";
            objpro.MethodParameters.Add("0");
            objpro.MethodParameters.Add("0");
            Binding bindingToArg1 = new Binding("MethodParameters[0]") { Source=objpro,BindsDirectlyToSource=true, UpdateSourceTrigger= UpdateSourceTrigger.PropertyChanged};
            Binding bindingToArg2 = new Binding("MethodParameters[1]") { Source=objpro,BindsDirectlyToSource=true,UpdateSourceTrigger=UpdateSourceTrigger.PropertyChanged};
            Binding bindToResult = new Binding(".") { Source=objpro};
            this.textBox1.SetBinding(TextBox.TextProperty, bindingToArg1);
            this.textBox2.SetBinding(TextBox.TextProperty, bindingToArg2);
            this.textBox3.SetBinding(TextBox.TextProperty,bindToResult);
        }
    }
}
