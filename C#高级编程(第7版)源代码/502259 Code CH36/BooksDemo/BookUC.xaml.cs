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

namespace Wrox.ProCSharp.WPF
{
    /// <summary>
    /// Interaction logic for BookUC.xaml
    /// </summary>
    public partial class BookUC : UserControl
    {
        public BookUC()
        {
            InitializeComponent();

            //var binding = new Binding { Path = new PropertyPath("Value"), Source = slider1 };
            //BindingOperations.SetBinding(scale1, ScaleTransform.ScaleXProperty, binding);
            //BindingOperations.SetBinding(scale1, ScaleTransform.ScaleYProperty, binding);
        }

        private void OnShowBook(object sender, RoutedEventArgs e)
        {
            Book theBook = this.DataContext as Book;
            if (theBook != null)
                MessageBox.Show(theBook.Title, theBook.Isbn);
        }

        private void OnChangeBook(object sender, RoutedEventArgs e)
        {
            Book theBook = this.DataContext as Book;
            if (theBook != null)
            {
                theBook.Title = "Professional C# 4 with .NET 4";
                theBook.Isbn = "978-0-470-50225-9";
            }
         
        }
    }
}
