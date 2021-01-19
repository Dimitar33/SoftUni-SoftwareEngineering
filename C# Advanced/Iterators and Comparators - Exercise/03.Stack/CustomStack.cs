using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        public CustomStack()
        {
            Items = new Stack<T>();
        }

        public Stack<T> Items { get; set; }

        public void Push(params T[] item)
        {
            foreach (var i in item)
            {
                Items.Push(i);
            }
        }

        public T Pop() => Items.Pop();

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in Items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
