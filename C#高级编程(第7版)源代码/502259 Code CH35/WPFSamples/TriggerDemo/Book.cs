using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriggerDemo
{
    public class Book
    {
        public string Title { get; set; }
        public string Publisher { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
