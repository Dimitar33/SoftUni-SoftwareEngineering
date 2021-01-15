using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    class Tuple<T1, T2>
    {
        public T1 FirstPart { get; set; }

        public T2 SecondPart { get; set; }

        public Tuple(T1 first, T2 second)
        {
            FirstPart = first;
            SecondPart = second;
        }

        public override string ToString()
        {
            return $"{FirstPart} -> {SecondPart}";
        }
    }
}
