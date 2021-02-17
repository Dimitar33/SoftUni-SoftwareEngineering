using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidPerson
{    
    class InvalidPersonNameException : Exception
    {
        private string name;

        public InvalidPersonNameException(string name, string message) : base(message)
        {
            Name = name;
        }


        public string Name { get; set; }
    }
}
