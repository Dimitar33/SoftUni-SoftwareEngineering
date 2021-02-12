using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    public class AddRemoveCollection : IAddRemoveCollection
    {

        public AddRemoveCollection()
        {
            List = new List<string>(100);
        }
        public List<string> List { get; set; }

        public int Add(string word)
        {
            List.Insert(0, word);

            return 0;
        }
        public string Remove()
        {
            string temp = List[List.Count - 1];
            List.RemoveAt(List.Count - 1);
            return temp;
        }
    }
}
