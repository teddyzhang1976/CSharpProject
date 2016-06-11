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
using Wrox.ProCSharp.WPF.Data;
using System.Collections.ObjectModel;

namespace Wrox.ProCSharp.WPF
{
    /// <summary>
    /// Interaction logic for BooksUC.xaml
    /// </summary>
    public partial class BooksUC : UserControl
    {
        public BooksUC()
        {
            InitializeComponent();
        }

        private void OnAddBook(object sender, RoutedEventArgs e)
        {
            ((this.FindResource("books") as ObjectDataProvider).Data as IList<Book>).Add(new Book(".NET 3.5 Wrox Box", "Wrox Press", "978-0470-38799-3"));
        }
    }
}
