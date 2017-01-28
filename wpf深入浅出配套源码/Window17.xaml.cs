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
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Window17.xaml 的交互逻辑
    /// </summary>
    public partial class Window17 : Window
    {
        public Window17()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load按钮事件处理器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            List<Plane> infos = new List<Plane>() { 
            new Plane(){ category= Category.Bomber,name="B-1", state= State.Unknown},
            new Plane(){ category= Category.Bomber,name="B-2", state= State.Unknown},
            new Plane(){ category= Category.Fighter,name="F-22", state= State.Locked},
            new Plane(){ category= Category.Fighter,name="Su-47", state= State.Unknown},
            new Plane(){ category= Category.Bomber,name="B-52", state= State.Available},
            new Plane(){ category= Category.Fighter,name="J-10", state= State.Unknown},
            };
            this.listBox1.ItemsSource = infos;
        }
        /// <summary>
        /// Save按钮事件处理器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Plane item in listBox1.Items)
            {
                sb.AppendLine(string.Format("Categroy={0},State={1},Name={2}",item.category,item.state,item.name));
            }
            File.WriteAllText(@"D:\PlaneList.text",sb.ToString());
        }

    }

    public enum Category
    {
        Bomber,
        Fighter
    }

    public enum State
    {
        Available,
        Locked,
        Unknown
    }

    public class Plane
    {
        public Category category { get; set; }
        public State state { get; set; }
        public string name { get; set; }
    }
}
