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
using System.Windows.Media.Animation;

namespace WpfApplication1
{
    /// <summary>
    /// Window63.xaml 的交互逻辑
    /// </summary>
    public partial class Window63 : Window
    {
        public Window63()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //从XAML代码中获取移动路径数据
            PathGeometry pg = this.layoutRoot.FindResource("movePath") as PathGeometry;
            Duration duration = new Duration(TimeSpan.FromMilliseconds(600));

            //创建动画
            DoubleAnimationUsingPath dpX = new DoubleAnimationUsingPath();
            dpX.Duration = duration;
            dpX.PathGeometry = pg;
            dpX.Source = PathAnimationSource.X;

            DoubleAnimationUsingPath dpY = new DoubleAnimationUsingPath();
            dpY.Duration = duration;
            dpY.PathGeometry = pg;
            dpY.Source = PathAnimationSource.Y;

            dpX.AutoReverse = true;
            dpX.RepeatBehavior = RepeatBehavior.Forever;
            dpY.AutoReverse = true;
            dpY.RepeatBehavior = RepeatBehavior.Forever;

            //执行动画
            this.tt.BeginAnimation(TranslateTransform.XProperty,dpX);
            this.tt.BeginAnimation(TranslateTransform.YProperty,dpY);

            
            
        }
    }
}
