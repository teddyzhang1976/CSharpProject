using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using System.Windows;


namespace WpfApplication1.Model
{
    public class Human
    {
        private int age;

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (age > 0 && age < 100)
                {
                    age = value;
                }
                else
                {
                    throw new OverflowException("age overflow!");
                }
            }
        }
    }

    public class Main
    {
        public void Run()
        {
            //....
            Human human = new Human();
            human.Age = -20;
            human.Age = 2000;
            //...
        }
    }

   
}
