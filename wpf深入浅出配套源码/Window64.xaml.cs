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
    /// Window64.xaml 的交互逻辑
    /// </summary>
    public partial class Window64 : Window
    {
        public Window64()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Duration duration = new Duration(TimeSpan.FromMilliseconds(600));

            //红色小球匀速运动
            DoubleAnimation daRx = new DoubleAnimation();
            daRx.Duration = duration;
            daRx.To = 400;

            //绿色小球做变速运动
            DoubleAnimationUsingKeyFrames dakGx = new DoubleAnimationUsingKeyFrames();
            dakGx.Duration = duration;
            SplineDoubleKeyFrame kfg = new SplineDoubleKeyFrame(400,KeyTime.FromPercent(1));
            kfg.KeySpline = new KeySpline(1,0,0,1);
            dakGx.KeyFrames.Add(kfg);

            //蓝色小球变速运动
            DoubleAnimationUsingKeyFrames dakBx = new DoubleAnimationUsingKeyFrames();
            dakBx.Duration = duration;
            SplineDoubleKeyFrame kfb = new SplineDoubleKeyFrame(400,KeyTime.FromPercent(1));
            kfb.KeySpline = new KeySpline(0,1,1,0);
            dakBx.KeyFrames.Add(kfb);

            //创建场景
            Storyboard storyBoard = new Storyboard();
            Storyboard.SetTargetName(daRx,"ttR");
            Storyboard.SetTargetProperty(daRx, new PropertyPath(TranslateTransform.XProperty));

            Storyboard.SetTargetName(dakGx, "ttG");
            Storyboard.SetTargetProperty(dakGx, new PropertyPath(TranslateTransform.XProperty));

            Storyboard.SetTargetName(dakBx, "ttB");
            Storyboard.SetTargetProperty(dakBx, new PropertyPath(TranslateTransform.XProperty));

            storyBoard.Duration = duration;
            storyBoard.Children.Add(daRx);
            storyBoard.Children.Add(dakBx);
            storyBoard.Children.Add(dakGx);

            storyBoard.Begin(this);
            storyBoard.Completed += (a, b) => { MessageBox.Show(ttR.X.ToString()); };
        }
    }
}
