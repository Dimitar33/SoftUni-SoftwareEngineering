using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
   public class Program
    {
        static void Main(string[] args)
        {
            string start = Console.ReadLine();
            string end = Console.ReadLine();

            DateModifier date = new DateModifier();

            Console.WriteLine(date.GetDateDiff(start, end));

            
        
        }

    }
}
