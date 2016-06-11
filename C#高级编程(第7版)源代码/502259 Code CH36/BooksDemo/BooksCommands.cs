using System.Windows.Input;


namespace Wrox.ProCSharp.WPF
{
    public static class BooksCommands
    {
        private static RoutedUICommand showBook;
        public static ICommand ShowBook
        {
            get
            {
                if (showBook == null)
                {
                    showBook = new RoutedUICommand("Show Book", "ShowBook", typeof(BooksCommands));
                }
                return showBook;
            }
        }


        private static RoutedUICommand showBooks;
        public static ICommand ShowBooks
        {
            get
            {
                if (showBooks == null)
                {
                    showBooks = new RoutedUICommand("Show Books", "ShowBooks", typeof(BooksCommands));
                    showBook.InputGestures.Add(new KeyGesture(Key.B, ModifierKeys.Alt));
                    
                }
                return showBooks;
            }
        }

        private static RoutedUICommand showAuthors;
        public static ICommand ShowAuthors
        {
            get
            {
                if (showAuthors == null)
                {
                    showAuthors = new RoutedUICommand("Show Authors", "ShowAuthors", typeof(BooksCommands));
                }
                return showAuthors;
            }
        }
    }
}
