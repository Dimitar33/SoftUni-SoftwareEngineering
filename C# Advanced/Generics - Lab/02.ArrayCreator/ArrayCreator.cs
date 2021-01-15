using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    { 
        public static T[] Create<T>(int count, T element)
        {
           T[] Array = new T[count];

            for (int i = 0; i < count; i++)
            {
                Array[i] = element;
            }
            return Array;
        }
    }
}
