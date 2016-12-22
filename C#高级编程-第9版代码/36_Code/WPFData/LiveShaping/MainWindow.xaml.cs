using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wrox.ProCSharp.WPF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private LapChart lapChart = new LapChart();
    public MainWindow()
    {
      InitializeComponent();
      this.DataContext = lapChart.GetLapInfo();

      Task.Run(async () =>
        {
          bool raceContinues = true;
          while (raceContinues)
          {
            await Task.Delay(3000);
            raceContinues = lapChart.NextLap();
          }
        });
    }
  }
}
