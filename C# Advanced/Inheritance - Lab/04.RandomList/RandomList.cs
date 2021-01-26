using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList

{
   public class RandomList : List<string>
    {

        public  string RandomString(List<string> list)
        {
            Random rng = new Random();

            var index = rng.Next(0, list.Count);

            var element = list[index];
            list.RemoveAt(index);

            return element;
        }
    }
}
