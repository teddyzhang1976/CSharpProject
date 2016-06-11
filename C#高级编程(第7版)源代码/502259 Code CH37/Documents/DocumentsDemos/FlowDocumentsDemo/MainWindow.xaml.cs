using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Markup;

namespace FlowDocumentsDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FileStream xamlFile = File.OpenRead("ParagraphDemo.xaml");
            FlowDocument doc = XamlReader.Load(xamlFile) as FlowDocument;

            reader.Document = doc;
        }
    }
}
