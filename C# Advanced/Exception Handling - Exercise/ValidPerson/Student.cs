using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidPerson
{
    class Student
    {
        private string name;

        public Student(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name
        {
            get => name;
            set
            {
                if (!value.All(c => char.IsLetter(c)))
                {
                    throw new InvalidPersonNameException("value", "Name must contain only leters");
                }
                name = value;
            }
        }

        public string Email { get; set; }
    }
}
