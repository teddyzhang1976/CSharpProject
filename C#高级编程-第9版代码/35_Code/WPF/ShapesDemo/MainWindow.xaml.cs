using System.Windows;
using System.Windows.Media;

namespace ShapesDemo
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      mouth.Data = Geometry.Parse("M 40,92 Q 57,75 80,92");
    }
  }
}
