using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainExample
{
    /// <summary>
    /// Defines a class which will be used to display data on screen
    /// </summary>
    public class Person
    {
        public Person(string name, Sex sex, DateTime dob)
        {
            _name = name;
            _sex = sex;
            _dateOfBirth = dob;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Sex Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        private string _name;
        private Sex _sex;
        private DateTime _dateOfBirth;
    }
}
