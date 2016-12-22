using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Formula1Demo
{
  /// <summary>
  /// Interaction logic for GridGroupingUC.xaml
  /// </summary>
  public partial class GridGroupingUC : UserControl
  {
    public GridGroupingUC()
    {
      InitializeComponent();
    }


    private void OnGetPage(object sender, RoutedEventArgs e)
    {
      int page = int.Parse(textPageNumber.Text);
      var odp = (sender as FrameworkElement).FindResource("races") as ObjectDataProvider;
      odp.MethodParameters[0] = page;
      odp.Refresh();
    }
  }
}
