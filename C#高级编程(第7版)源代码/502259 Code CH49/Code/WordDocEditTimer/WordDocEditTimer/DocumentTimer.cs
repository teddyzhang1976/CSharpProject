using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;

namespace WordDocEditTimer
{
   public class DocumentTimer
   {
      public Word.Document Document { get; set; }
      public DateTime LastActive { get; set; }
      public bool IsActive { get; set; }
      public TimeSpan EditTime { get; set; }
   }
}
