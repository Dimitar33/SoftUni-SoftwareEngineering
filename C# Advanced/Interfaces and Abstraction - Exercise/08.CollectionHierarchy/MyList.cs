using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    public class MyList : IMyList
    {
        public MyList()
        {
            Stak = new Stack<string>(100);
        }

        public Stack<string> Stak { get; set; }

        public int Used { get => Stak.Count;}

        public int Add(string word)
        {
            Stak.Push(word);
            return 0;
        }

        public string Remove()
        {
            return Stak.Pop();
        }
    }
}
