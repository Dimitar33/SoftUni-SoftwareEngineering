using System;
using System.Collections.Generic;
using System.Text;

namespace ValidPerson
{
    class Person
    {
        private string firstName;

        private string lastName;

        private int age;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName 
        { 
            get => firstName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value","First Name can not be empty");
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value","Last Name can not be empty");
                }
                lastName = value;
            }
        }
        public int Age 
        { 
            get => age;
            set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("value","Age must be between 0 and 120");
                }
                age = value;
            }
        }
    }
}
