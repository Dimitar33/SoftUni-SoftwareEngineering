using System;
using System.Collections.Generic;
using System.Text;

namespace Create_Custom_Data_Structures
{
    public class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] array;

        public int Count { get; set; }

        private bool invalidIndex(int index)
           => index < 0 || index >= Count;

        public int this[int index]
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
            array = new int[InitialCapacity];
        }

        private void Resize()
        {
            int[] copy = new int[array.Length * 2];

            for (int i = 0; i < array.Length; i++)
            {
                copy[i] = array[i];
            }
            array = copy;
        }

      

        public void Add(int item)
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
            int[] copy = new int[array.Length / 2];

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

        public int RemoveAt(int index)
        {
            if (invalidIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }
            int temp = array[index];

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
        public void Insert(int index, int item)
        {
            if (invalidIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            ShiftRight(index);

            array[index] = item;
            Count++;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < Count; i++)
            {           
                if (array[i] == item)
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

            int temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
