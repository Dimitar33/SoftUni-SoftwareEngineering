using System;
using System.Collections.Generic;
using System.Text;

namespace _04.GenericSwapMethodInt
{
   public class Box<T>
    {
        public Box(List<T> items)
        {
            this.items = items;
        }

        public List<T> items { get; set; } = new List<T>();

        public void Swap( int index1, int index2)
        {
            T temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
    
        }
        public override string ToString()
        {
            return $"System.Int32: {string.Join("\nSystem.Int32: ", items)}";
        }
    }
}
