using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using Microsoft.Win32;

namespace Wrox.ProCSharp.Documents
{
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      this.DataContext = this;
    }

    private void OnOpenDocument(object sender, RoutedEventArgs e)
    {
      try
      {
        var dlg = new OpenFileDialog();
        dlg.DefaultExt = "*.xaml";
        dlg.InitialDirectory = Environment.CurrentDirectory;
        if (dlg.ShowDialog() == true)
        {
          using (FileStream xamlFile = File.OpenRead(dlg.FileName))
          {
            var doc = XamlReader.Load(xamlFile) as FlowDocument;
            if (doc != null)
            {
              activedocumentReader.Document = doc;
              activedocumentReader.Visibility = Visibility.Visible;
            }
          }
        }
      }
      catch (XamlParseException ex)
      {
        MessageBox.Show(string.Format("Check content for a Flow document, {0}", ex.Message));
      }
    }

    private void OnReaderSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      dynamic item = (sender as ComboBox).SelectedItem;

      if (activedocumentReader != null)
      {
        activedocumentReader.Visibility = Visibility.Collapsed;
      }
      activedocumentReader = item.Instance;
    }

    private dynamic activedocumentReader = null;

    public IEnumerable<object> Readers
    {
      get
      {
        return GetReaders();
      }
    }

    private List<object> documentReaders = null;
    private IEnumerable<object> GetReaders()
    {
      return documentReaders ?? (documentReaders =
        LogicalTreeHelper.GetChildren(grid1).OfType<FrameworkElement>()
          .Where(el => el.GetType().GetProperties().Where(pi => pi.Name == "Document").Count() > 0)
          .Select(el => new
          {
            Name = el.GetType().Name,
            Instance = el
          }).Cast<object>().ToList());
    }
  }
}
