using System;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var carPark = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] user = Console.ReadLine().Split();

                string name = user[1];

                if (user[0] == "register")
                {
                    if (carPark.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {user[2]}");
                    }
                    else
                    {
                        carPark.Add(name, user[2]);
                        Console.WriteLine($"{name} registered {user[2]} successfully");
                    }
                }
                else if (user[0] == "unregister")
                {
                    if (carPark.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} unregistered successfully");
                        carPark.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                }

            }
            foreach (var item in carPark)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
