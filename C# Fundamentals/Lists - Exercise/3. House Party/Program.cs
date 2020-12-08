using System;
using System.Collections.Generic;

namespace _3._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> pplList = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string[] person = Console.ReadLine().Split();

                if (person.Length == 3)
                {
                    if (pplList.Contains(person[0]))
                    {
                        Console.WriteLine($"{person[0]} is already in the list!");
                    }
                    else
                    {
                        pplList.Add(person[0]);
                    }
                }
                else if (person.Length == 4)
                {
                    if (pplList.Contains(person[0]))
                    {
                        pplList.Remove(person[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{person[0]} is not in the list!");
                    }
                }
            }
            Console.WriteLine(string.Join  (Environment.NewLine , pplList));
        }
    }
}
