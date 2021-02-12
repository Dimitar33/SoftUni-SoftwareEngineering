using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        public AddCollection()
        {
            List = new List<string>(100);
        }
        public List<string> List { get; set; }

        public int Add(string word)
        {
            List.Add(word);
            return List.Count - 1;
        }
    }
}
