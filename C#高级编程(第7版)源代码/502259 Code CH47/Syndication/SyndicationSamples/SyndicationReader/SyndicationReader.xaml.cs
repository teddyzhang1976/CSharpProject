using System.Net;
using System.Windows;
using System.Xml;
using System.ServiceModel.Syndication;

namespace Wrox.ProCSharp.Syndication
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SyndicationReaderWindow : Window
    {
        public SyndicationReaderWindow()
        {
            InitializeComponent();
        }

        private void OnGetFeed(object sender, RoutedEventArgs e)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(textUrl.Text))
                {
                    var formatter = new Rss20FeedFormatter();
                    formatter.ReadFrom(reader);
                    this.DataContext = formatter.Feed;
                    this.feedContent.DataContext = formatter.Feed.Items;
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message, "Syndication Reader");
            }

        }
    }
}
