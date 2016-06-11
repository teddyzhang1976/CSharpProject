using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public interface IDisplay
    {
        void Display();
    }

    public class Person
    {
        public Person()
            : this("unknown", "unknown")
        {
        }


        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.LastName = lastName;
        }


        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName { get; set; }
	
    }
}
