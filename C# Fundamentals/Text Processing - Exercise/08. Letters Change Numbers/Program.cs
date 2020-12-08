using System;
using System.Linq;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            double total = 0;

            for (int i = 0; i < data.Length; i++)
            {

                double sum = 0;
                string letter = data[i];
                string number = "";

                for (int j = 1; j < letter.Length - 1; j++)
                {
                    number += letter[j];
                }
                bool isUpper = char.IsUpper(letter[0]);
                bool isLower = char.IsLower(letter[letter.Length - 1]);

                double letterPosition = 0;

                if (isUpper)
                {
                    letterPosition = letter[0] - 64;
                    sum += double.Parse(number) / letterPosition;
                }
                else
                {
                    letterPosition = letter[0] - 96;
                    sum += double.Parse(number) * letterPosition;
                }
                if (isLower)
                {
                    letterPosition = letter[letter.Length - 1] - 96;
                    sum += letterPosition;
                }
                else
                {
                    letterPosition = letter[letter.Length - 1] - 64;
                    sum -= letterPosition;
                }
                total += sum;
            }
            Console.WriteLine($"{total:f2}");
        }
    }
}
