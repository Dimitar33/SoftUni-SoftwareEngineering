using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Telephony
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phonesInput = Console.ReadLine().Split();

            string[] sitesInput = Console.ReadLine().Split();

            List<IWeb> sites = new List<IWeb>();
            List<ICall> numbers = new List<ICall>();

            foreach (var item in phonesInput)
            {
                if (!item.All(char.IsDigit))
                {
                    Console.WriteLine("Invalid number!");
                }
                if (item.Length == 7)
                {
                    ICall number = new StationaryPhone(int.Parse(item));
                    numbers.Add(number);
                }
                else
                {
                    ICall number = new Smartphone(int.Parse(item));
                    numbers.Add(number);
                }
            }

            foreach (var item in sitesInput)
            {
                IWeb site = new Smartphone(item);

                sites.Add(site);
            }

            foreach (var item in numbers)
            {
                Console.WriteLine(item.Number);
            }
        }
    }
}
