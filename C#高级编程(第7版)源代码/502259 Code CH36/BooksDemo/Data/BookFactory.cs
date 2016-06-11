using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Wrox.ProCSharp.WPF.Data
{
    public class BookFactory
    {
        private ObservableCollection<Book> books = new ObservableCollection<Book>();

        public BookFactory()
        	{
            books.Add(new Book("Professional C# 4 with .NET 4", "Wrox Press", "978-0-470-50225-9", "Christian Nagel", "Bill Evjen", "Jay Glynn", "Karli Watson", "Morgan Skinner"));
            books.Add(new Book("Professional C# 2008", "Wrox Press", "978–0-470-19137-8", "Christian Nagel", "Bill Evjen", "Jay Glynn", "Karli Watson", "Morgan Skinner"));
            books.Add(new Book("Beginning Visual C# 2010", "Wrox Press", "978-0-470-50226-6", "Karli Watson", "Christian Nagel", "Jacob Hammer Pedersen", "Jon D. Reid", "Morgan Skinner", "Eric White"));
            books.Add(new Book("Windows 7 Secrets", "Wiley", "978-0-470-50841-1", "Paul Thurrott", "Rafael Rivera"));
            books.Add(new Book("C# 2008 for Dummies", "For Dummies", "978-0-470-19109-5", "Stephen Randy Davis", "Chuck Sphar"));
        	}

        public Book GetTheBook()
        {
            return books[0];
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }


        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

    }
}
