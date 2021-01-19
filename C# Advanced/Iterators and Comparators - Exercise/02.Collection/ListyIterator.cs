using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        public ListyIterator(List<T> elements)
        {
            Elements = new List<T>(elements);
        }

        private List<T> Elements { get; set; }

        private int index = 0;

        public bool Move()
        {
            if (this.index >= Elements.Count - 1)
            {
                Console.WriteLine("False");
                return false;
            }
            Console.WriteLine("True");
            this.index++;
            return true;
        }

        public bool HasNext()
        {
            if (this.index + 1 >= Elements.Count)
            {
                Console.WriteLine("False");
                return false;
            }
            Console.WriteLine("True");
            return true;
        }

        public void Print()
        {
            try
            {
                Console.WriteLine(Elements[this.index]);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Operation!");
            }

        }
        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ", Elements));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                yield return Elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
