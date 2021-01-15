using System;
using System.Collections.Generic;
using System.Text;

namespace Create_Custom_Data_Structures
{
    public class CustomList<T> where T : ICloneable
    {
        private const int InitialCapacity = 2;

        private T[] array;

        public int Count { get; set; }

        private bool invalidIndex(int index)
           => index < 0 || index >= Count;

        public T this[int index]
        {
            get
            {
                if (invalidIndex(index))
                {
                    throw new ArgumentOutOfRangeException();
                }
                return array[index];
            }
            set
            {
                if (invalidIndex(index))
                {
                    throw new ArgumentOutOfRangeException();
                }
                array[index] = value;
            }
        }
        public CustomList()
        {
            array = new T[InitialCapacity];
        }

        private void Resize()
        {
            T[] copy = new T[array.Length * 2];

            for (int i = 0; i < array.Length; i++)
            {
                copy[i] = array[i];
            }
            array = copy;
        }

      

        public void Add(T item)
        {
            if (Count == array.Length)
            {
                Resize();
            }
            array[Count] = item;
            Count++;
        }

        private void Shrink()
        {
            T[] copy = new T[array.Length / 2];

            for (int i = 0; i < copy.Length; i++)
            {
                copy[i] = array[i];
            }
            array = copy;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < array.Length -1; i++)
            {
                array[i] = array[i + 1];
            }
             
        }

        public T RemoveAt(int index)
        {
            if (invalidIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }
            T temp = array[index];

            ShiftLeft(index);
            Count--;

            if (Count * 4 <= array.Length)
            {
                Shrink();
            }

            return temp;         

        }
        private void ShiftRight(int index)
        {
            
            for (int i = 0; i < Count - index ; i++)
            {
                array[Count - i] = array[Count - i - 1];
            }
        }
        public void Insert(int index, T item)
        {
            if (invalidIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            ShiftRight(index);

            array[index] = item;
            Count++;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {           
                if (array[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int first, int second)
        {
            if (invalidIndex(first) || invalidIndex(second))
            {
                throw new ArgumentOutOfRangeException();
            }

            T temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
