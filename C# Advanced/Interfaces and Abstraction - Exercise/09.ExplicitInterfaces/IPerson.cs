using System;
using System.Collections.Generic;
using System.Text;

namespace _09.ExplicitInterfaces
{
    interface IPerson
    {
        public string Name { get; set; }
        public string Age { get; set; }

        public string GetName();
    }
}
