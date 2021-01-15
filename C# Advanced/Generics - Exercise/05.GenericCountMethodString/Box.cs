using System;
using System.Collections.Generic;
using System.Text;

namespace _05.GenericCountMethodString
{
   public class Box<T> where T : IComparable
        
    {
        public Box(List<T> items)
        {
            this.items = items;
        }

        public List<T> items { get; set; } = new List<T>();

        
       public int Compare( T item)
        {
            int count = 0;

            foreach (var i in items)
            {
                if (i.CompareTo(item) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
