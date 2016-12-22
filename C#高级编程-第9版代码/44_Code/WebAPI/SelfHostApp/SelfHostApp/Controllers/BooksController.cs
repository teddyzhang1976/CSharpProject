using SelfHostApp.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace SelfHostApp.Controllers
{
  [RoutePrefix("Books")]
  public class BooksController : ApiController
  {

    [Route("TheOne")]
    public IEnumerable<Book> GetBooks()
    {
      return new List<Book>()
      {
        new Book { Publisher="Wrox Press", Title="Professional C# 5"}
      };
    }
  }
}
