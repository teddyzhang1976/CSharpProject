using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wrox.ProCSharp.Collections
{
  public class Document
  {
    public string Title { get; private set; }
    public string Content { get; private set; }

    public Document(string title, string content)
    {
      this.Title = title;
      this.Content = content;
    }
  }

}
