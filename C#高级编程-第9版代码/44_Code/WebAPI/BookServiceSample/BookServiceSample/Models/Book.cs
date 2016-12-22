using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookServiceSample.Models
{
  public class Book
  {
    public Book(int id, string title, params BookChapter[] chapters)
    {
      this.Id = id;
      this.Title = title;
      this.BookChapters = chapters.ToList();
     
    }
    public int Id { get; private set; }
    public string Title { get; private set; }

    public ICollection<BookChapter> BookChapters { get; private set;}
  }
}