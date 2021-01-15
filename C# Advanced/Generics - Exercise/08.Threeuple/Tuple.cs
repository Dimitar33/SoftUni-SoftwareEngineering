using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Threeuple
{
    class Threeuple<T1, T2, T3>
    {
        public T1 FirstPart { get; set; }

        public T2 SecondPart { get; set; }

        public T3 ThirdPart { get; set; }

        public Threeuple(T1 first, T2 second, T3 third)
        {
            FirstPart = first;
            SecondPart = second;
            ThirdPart = third;
        }


        public override string ToString()
        {
            return $"{FirstPart} -> {SecondPart} -> {string.Join(" ", ThirdPart)}";
        }
    }
}
