using System.Collections.ObjectModel;

namespace Wrox.ProCSharp.Async
{
  public class SearchInfo : BindableBase
  {
    public SearchInfo()
    {
      list = new ObservableCollection<SearchItemResult>();
      list.CollectionChanged += delegate { OnPropertyChanged("List"); };
    }

    private string searchTerm;

    public string SearchTerm
    {
      get { return searchTerm; }
      set { SetProperty(ref searchTerm, value); }
    }

    private ObservableCollection<SearchItemResult> list;
    public ObservableCollection<SearchItemResult> List
    {
      get
      {
        return list;
      }
    }
  } 
}
