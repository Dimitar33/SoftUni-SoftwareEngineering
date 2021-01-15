using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
   public class Box<T>
    {
        public Box()
        {
            Stack = new Stack<T>();
        }

        public int Count => Stack.Count; 

        public Stack<T> Stack { get; set; }

        public void Add(T item)
        {
            Stack.Push(item);        
        }

        public T Remove()
        {         
           return Stack.Pop();
        }
    }
}
