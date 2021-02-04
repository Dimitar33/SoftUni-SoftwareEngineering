using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<IBuyer> allHumans = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                if (data.Length == 3)
                {
                    Rebel rebel = new Rebel(data[0], data[1], data[2]);
                    allHumans.Add(rebel);
                }
                else
                {
                    Citizen human = new Citizen(data[0], data[1], data[2], data[3]);
                    allHumans.Add(human);

                }
            }

            string buying = Console.ReadLine();

            while (buying != "End")
            {

                IBuyer curentHuman = allHumans.FirstOrDefault(c => c.Name == buying);

                if (curentHuman != null)
                {
                    curentHuman.BuyFood();

                }

                buying = Console.ReadLine();
            }

            Console.WriteLine(allHumans.Sum(c => c.Food));
        }
    }
}
