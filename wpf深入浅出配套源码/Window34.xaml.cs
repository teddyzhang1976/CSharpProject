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
using System.Diagnostics;

namespace WpfApplication1
{
    /// <summary>
    /// Window34.xaml 的交互逻辑
    /// </summary>
    public partial class Window34 : Window
    {
        public Window34()
        {
            InitializeComponent();
            Uri imageURI = new Uri(@"pack://application:,,,/Resource/Image/20090102191236877.gif",UriKind.Absolute);
            this.img0.Source = new BitmapImage(imageURI);
            String StartupPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            StartupPath = "Source/Vidio";
            mediaElement1.Source = new Uri(@"./1.mp3", UriKind.RelativeOrAbsolute);
            mediaElement1.Play();
        }
    }
}
