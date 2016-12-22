using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Formula1Demo
{
  /// <summary>
  /// Interaction logic for GridUC.xaml
  /// </summary>
  public partial class GridUC : UserControl
  {
    private int currentPage = 0;
    private int pageSize = 50;
    private Formula1Entities data = new Formula1Entities();
    public GridUC()
    {
      InitializeComponent();
      this.DataContext = Races;
    }

    public IEnumerable<object> Races
    {
      get
      {
        var q = (from r in data.Races
                 from rr in r.RaceResults
                 orderby r.Date ascending
                 select new
                 {                  
                   r.Date.Year,
                   r.Circuit.Country,
                   rr.Position,
                   Racer = rr.Racer.FirstName + " " + rr.Racer.LastName,
                   Car = rr.Team.Name
                 }).Skip(currentPage * pageSize).Take(pageSize);
        return q.ToList();
      }
    }


    private void OnPrevious(object sender, RoutedEventArgs e)
    {
      if (currentPage > 0)
      {
        currentPage--;
        this.DataContext = Races;
      }
    }

    private void OnNext(object sender, RoutedEventArgs e)
    {
      currentPage++;
      this.DataContext = Races;
    }
  }
}
