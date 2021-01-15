using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
{
    class Box<T>
    {
        public Box(T body)
        {
            Body = body;
        }

        public T Body { get; set; }

        public override string ToString()
        {
            return $"System.Int32: {Body.ToString()}";
        }
    }
}
