using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            string reservations = Console.ReadLine();

            HashSet<string> vip = new HashSet<string>();
            HashSet<string> nonVip = new HashSet<string>();

            while (reservations != "PARTY")
            {
                var match = Regex.Match(reservations, @"^[0-9]");

                if (match.Success)
                {
                    vip.Add(reservations);
                }
                else
                {
                    nonVip.Add(reservations);
                }

                reservations = Console.ReadLine();
            }

            string guest = Console.ReadLine();

            while (guest != "END")
            {
                vip.Remove(guest);
                nonVip.Remove(guest);
                guest = Console.ReadLine();
            }

            Console.WriteLine(vip.Count + nonVip.Count);

            foreach (var item in vip)
            {
                Console.WriteLine(item);
            }
            foreach (var item in nonVip)
            {
                Console.WriteLine(item);
            }

            
        }
    }
}
