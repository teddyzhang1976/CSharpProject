using BookServiceSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookServiceSample.Controllers
{
  //[RoutePrefix("booksamples")]
  public class BookChaptersAttrController : ApiController
  {
    private static List<BookChapter> chapters;
    private static List<Book> books;
    static BookChaptersAttrController()
    {
      chapters = new List<BookChapter>()
      {
        new BookChapter { Number=1, Title=".NET Architecture", Pages=20},
        new BookChapter { Number=2, Title="Core C#", Pages=42},
        new BookChapter { Number=3, Title="Objects and Types", Pages=24},
        new BookChapter { Number=4, Title="Inheritance", Pages=18},
        new BookChapter { Number=5, Title="Generics", Pages=22},
        new BookChapter { Number=17, Title="Visual Studio 2012", Pages=50},
        new BookChapter { Number=42, Title="ASP.NET Dynamic Data", Pages=14}
      };

      books = new List<Book>()
      {
        new Book(1, "Professional C# 5 and .NET 4.5.1", chapters.ToArray()),
        new Book(2, "Professional ASP.NET MVC 4")
      };
    }

    // GET api/bookchapters
    [Route("books/{bookId}")]
    public IEnumerable<BookChapter> GetBookChapters(int bookId)
    {
      return books.Where(b => b.Id == bookId).Single().BookChapters;
    }


    // GET api/bookchapters/5
    [Route("books/{bookId}/chapters/{chapterId}")]
    //[Route("{bookId:int}/{chapterId:int}")]
    public BookChapter GetBookChapter(int bookId, int chapterId)
    {
      return books.Where(b => b.Id == bookId).Single().BookChapters.Where(c => c.Number == chapterId).SingleOrDefault();
    }


    // POST api/bookchapters
    public void PostBookChapter([FromBody]BookChapter value)
    {
      chapters.Add(value);
    }


    // PUT api/bookchapters/5
    public void PutBookChapter(int id, [FromBody]BookChapter value)
    {
      chapters.Remove(chapters.Where(c => c.Number == id).Single());
      chapters.Add(value);
    }


    // DELETE api/bookchapters/5
    public void DeleteBookChapter(int id)
    {
      chapters.Remove(chapters.Where(c => c.Number == id).Single());
    }
  }
}
