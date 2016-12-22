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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml;
using Microsoft.Win32;
using System.Windows.Baml2006;
using System.IO;
using System.Reflection;

namespace LoadXAML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoadXaml(object sender, RoutedEventArgs e)
        {
            Person p1 = new Person { FirstName = "Stephanie", LastName = "Nagel" };
            string s = XamlServices.Save(p1);
            XamlServices.Save("person.xaml", p1);


            var writer = new XamlObjectWriter(new XamlSchemaContext());
            FileStream fStream = File.OpenRead("LoadXAML.exe");
            var bamlReader = new Baml2006Reader(fStream, new XamlReaderSettings { LocalAssembly = Assembly.GetExecutingAssembly() });

            // Baml2006Reader bamlReader = new Baml2006Reader("../../../XAMLIntro/bin/debug/XAMLIntro.exe");
            FileStream stream = File.Create("myfile.xaml");
            XamlSchemaContext schemaContext = new XamlSchemaContext(
                    new XamlSchemaContextSettings
                    {
                        FullyQualifyAssemblyNamesInClrNamespaces = true,
                        SupportMarkupExtensionsWithDuplicateArity = true
                    });
            XamlXmlWriter xmlWriter = new XamlXmlWriter(stream, schemaContext);
            XamlServices.Transform(bamlReader, xmlWriter, true);
            
            XamlServices.Transform(new XamlXmlReader("person.xaml"), writer, true);
            // string s2 = XamlServices.Save(this);

            
            //OpenFileDialog dlg = new OpenFileDialog();
            //if (dlg.ShowDialog() == true)
            //{
            //    object xaml = XamlServices.Load(dlg.FileName);
            //    XamlSchemaContext schema = new XamlSchemaContext(
            //        new XamlSchemaContextSettings
            //        {
            //            FullyQualifyAssemblyNamesInClrNamespaces = true,
            //            SupportMarkupExtensionsWithDuplicateArity = true
            //        });
            //    XamlWriter writer = new XamlXmlWriter(stream, schema);
            //    XamlServices.Save(
        }

        private void OnTest(object sender, RoutedEventArgs e)
        {
            //object tree = XamlServices.Load("Demo1.xaml");
            //container1.Children.Add(tree as UIElement);
            FileStream stream = File.OpenRead("Demo1.xaml");
            object tree = System.Windows.Markup.XamlReader.Load(stream);

            container1.Children.Add(tree as UIElement);
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("button connected");
        }
    }
}
