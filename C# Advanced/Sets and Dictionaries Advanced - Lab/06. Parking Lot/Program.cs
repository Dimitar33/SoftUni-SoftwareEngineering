using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] car = Console.ReadLine().Split(", ");

            HashSet<string> carNumbers = new HashSet<string>();

            while (car[0] != "END")
            {
                if (car[0] == "IN")
                {
                    carNumbers.Add(car[1]);
                }
                else 
                {
                    carNumbers.Remove(car[1]);
                }

                car = Console.ReadLine().Split(", ");
            }
            if (carNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var item in carNumbers)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
