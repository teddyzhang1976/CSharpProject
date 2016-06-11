using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Windows;

namespace UserSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string username;
        private string password;
        private string hostname;
        private string schemaNamingContext;
        private string defaultNamingContext;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoadProperties(object sender, RoutedEventArgs e)
        {
            try
            {
                SetLogonInformation();

                SetNamingContext();

                SetUserProperties(schemaNamingContext);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("check your input! {0}", ex.Message));
            }
        }

        private void SetUserProperties(string schemaNamingContext)
        {
            var properties = from p in GetSchemaProperties(schemaNamingContext, "User").Concat(
                                 GetSchemaProperties(schemaNamingContext, "Organizational-Person")).Concat(
                                 GetSchemaProperties(schemaNamingContext, "Top"))
                             orderby p
                             select p;

            listBoxProperties.DataContext = properties;
        }

        private IEnumerable<string> GetSchemaProperties(string schemaNamingContext, string objectType)
        {
            IEnumerable<string> data;
            using (var de = new DirectoryEntry())
            {
                de.Username = username;
                de.Password = password;

                de.Path = String.Format("LDAP://{0}CN={1},{2}", hostname, objectType, schemaNamingContext);

                PropertyValueCollection values = de.Properties["systemMayContain"];
                data = from s in values.Cast<string>()
                       orderby s
                       select s;
            }
            return data;
        }

        private void SetNamingContext()
        {
            using (var de = new DirectoryEntry())
            {
                string path = "LDAP://" + hostname + "rootDSE";
                de.Username = username;
                de.Password = password;
                de.Path = path;
                schemaNamingContext = de.Properties["schemaNamingContext"][0].ToString();
                defaultNamingContext = de.Properties["defaultNamingContext"][0].ToString();
            }
        }

        private void SetLogonInformation()
        {
            username = (textUsername.Text == "" ? null : textUsername.Text);
            password = (textPassword.Password == "" ? null : textPassword.Password);
            hostname = textDC.Text;
            if (hostname != "")
            {
                hostname += "/";
            }
        }

        private void OnSearch(object sender, RoutedEventArgs e)
        {
            try
            {
                FillResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("check your input! {0}", ex.Message));
            }
        }

        private void FillResult()
        {
            using (var root = new DirectoryEntry())
            {
                root.Username = username;
                root.Password = password;
                root.Path = String.Format("LDAP://{0}{1}", hostname, defaultNamingContext);
                using (var searcher = new DirectorySearcher())
                {
                    searcher.SearchRoot = root;
                    searcher.SearchScope = SearchScope.Subtree;
                    searcher.Filter = textFilter.Text;
                    searcher.PropertiesToLoad.AddRange(listBoxProperties.SelectedItems.Cast<string>().ToArray());

                    SearchResultCollection results = searcher.FindAll();
                    var summary = new StringBuilder();
                    foreach (SearchResult result in results)
                    {
                        foreach (string propName in result.Properties.PropertyNames)
                        {
                            foreach (object p in result.Properties[propName])
                            {
                                summary.AppendFormat(" {0}: {1}", propName, p);
                                summary.AppendLine();
                            }
                        }
                        summary.AppendLine();
                    }
                    textResult.Text = summary.ToString();
                }
            }
        }
    }
}
