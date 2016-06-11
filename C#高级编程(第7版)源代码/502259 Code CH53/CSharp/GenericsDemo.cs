using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public static class GenericsDemo
    {
        public static void UseGenerics()
        {
            List<int> intList = new List<int>();
            intList.Add(1);
            intList.Add(2);
            intList.Add(3);
        }
    }

    

    public class MyGeneric<T>
        where T : IComparable<T>
    {
        private List<T> list = new List<T>();

        public void Add(T item)
        {
            list.Add(item);
        }

        public void Sort()
        {
            list.Sort();
        }
    }
}
