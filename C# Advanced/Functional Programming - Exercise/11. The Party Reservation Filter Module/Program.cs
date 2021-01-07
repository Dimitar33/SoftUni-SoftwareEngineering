using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guestList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string[] cmd = Console.ReadLine().Split(";");

            Dictionary<string, List<string>> filters = new Dictionary<string, List<string>>();

            while (cmd[0] != "Print")
            {
                if (cmd[0] == "Add filter")
                {
                    if (!filters.ContainsKey(cmd[1]))
                    {
                        filters.Add(cmd[1], new List<string>());
                    }
                    filters[cmd[1]].Add(cmd[2]);
                }
                else
                {
                    filters[cmd[1]].Remove(cmd[2]);

                    if (filters[cmd[1]].Count == 0)
                    {
                        filters.Remove(cmd[1]);
                    }
                }

                cmd = Console.ReadLine().Split(";");
            }
            foreach (var item in filters)
            {
                if (item.Key == "Starts with")
                {
                    foreach (var i in item.Value)
                    {
                        guestList = guestList.Where(c => !c.StartsWith(i)).ToList();
                    }
                }
                else if (item.Key == "Ends with")
                {
                    foreach (var i in item.Value)
                    {
                        guestList = guestList.Where(c => !c.EndsWith(i)).ToList();
                    }
                }
                else if (item.Key == "Length")
                {
                    foreach (var i in item.Value)
                    {
                        guestList = guestList.Where(c => c.Length != int.Parse(i)).ToList();
                    }
                }
                else
                {
                    foreach (var i in item.Value)
                    {
                        guestList = guestList.Where(c => !c.Contains(i)).ToList();
                    }
                }
            }
            Console.WriteLine(string.Join(" ", guestList));
        }
    }
}
