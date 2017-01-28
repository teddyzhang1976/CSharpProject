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
    /// Window62.xaml 的交互逻辑
    /// </summary>
    public partial class Window62 : Window
    {
        public Window62()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //创建动画
            DoubleAnimationUsingKeyFrames dakX = new DoubleAnimationUsingKeyFrames();
            dakX.Duration = new Duration(TimeSpan.FromMilliseconds(1000));

            //创建、添加关键帧
            SplineDoubleKeyFrame kf = new SplineDoubleKeyFrame();
            kf.KeyTime = KeyTime.FromPercent(1);
            kf.Value = 400;

            KeySpline ks = new KeySpline();
            ks.ControlPoint1 = new Point(0,1);
            ks.ControlPoint2 = new Point(1,0);

            kf.KeySpline = ks;
            dakX.KeyFrames.Add(kf);

            //执行动画
            this.tt.BeginAnimation(TranslateTransform.XProperty ,dakX);
        }
    }
}
