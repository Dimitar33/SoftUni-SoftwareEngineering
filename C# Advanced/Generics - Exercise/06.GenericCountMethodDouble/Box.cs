using System;
using System.Collections.Generic;
using System.Text;

namespace _06.GenericCountMethodDouble
{
   public class Box<T> where T : IComparable
        
    {
        public Box(List<T> items)
        {
            this.items = items;
        }

        public List<T> items { get; set; } = new List<T>();

        

    }
}
