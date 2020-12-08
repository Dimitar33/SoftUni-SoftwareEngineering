using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._10_March_2019_Group_2__Seize_the_Fire
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] field = Console.ReadLine().Split(new string[] { " = ", "#" } ,StringSplitOptions.RemoveEmptyEntries);

            int water = int.Parse(Console.ReadLine());
            double effort = 0;            
            int fireExtinguished = 0;
            var extingushed = new List<int>();

            for (int i = 0; i < field.Length -1; i+=2)
            {               

                if (field[i] == "High" &&  int.Parse(field[i +1]) >= 81 && int.Parse(field[i + 1]) <= 125 && int.Parse(field[i + 1]) <= water)
                {
                    water -= int.Parse(field[i + 1]);
                    effort += int.Parse(field[i + 1]) * 0.25;
                    extingushed.Add(int.Parse(field[i + 1]));
                    fireExtinguished += int.Parse(field[i + 1]);
                }
                else if (field[i] == "Medium" && int.Parse(field[i + 1]) >= 51 && int.Parse(field[i + 1]) <= 80 && int.Parse(field[i + 1]) <= water)
                {
                    water -= int.Parse(field[i + 1]);
                    effort += int.Parse(field[i + 1]) * 0.25;
                    extingushed.Add(int.Parse(field[i + 1]));
                    fireExtinguished += int.Parse(field[i + 1]);
                }
                else if (field[i] == "Low" && int.Parse(field[i + 1]) >= 1 && int.Parse(field[i + 1]) <= 50 && int.Parse(field[i + 1]) <= water)
                {
                    water -= int.Parse(field[i + 1]);
                    effort += int.Parse(field[i + 1]) * 0.25;
                    extingushed.Add(int.Parse(field[i + 1]));
                    fireExtinguished += int.Parse(field[i + 1]);
                }                            
            }

            Console.WriteLine("Cells:");
            foreach (var item in extingushed)
            {
                Console.WriteLine($" - {item}");
            }
            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {fireExtinguished}");
        }
    }
}
