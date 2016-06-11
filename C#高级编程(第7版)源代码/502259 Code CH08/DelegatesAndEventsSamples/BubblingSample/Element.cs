using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Wrox.ProCSharp.Delegates
{
    public class Element
    {
        Element parent;
        string name;
        public Element(string name, Element parent)
        {
            this.name = name;
            this.parent = parent;
        }

        public event RoutedEventHandler Pre;
        //{
        //    add
        //    {
        //    }
        //    remove
        //    {
        //    }
        //}

        public event RoutedEventHandler Post;

        internal void FirePre(RoutedEventArgs e)
        {
            if (Pre != null)
                Pre(this, e);
        }

        internal void FirePost(RoutedEventArgs e)
        {
            if (parent != null)
            {
                parent.FirePost(e);
            }
            if (Post != null)
                Post(this, e);
        }
    }
}
