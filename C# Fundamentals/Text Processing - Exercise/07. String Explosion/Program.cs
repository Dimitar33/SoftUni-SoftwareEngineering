using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string field = Console.ReadLine();

            StringBuilder sb = new StringBuilder(field);

            List<char> result = new List<char>();

            int power = 0;

            for (int i = 0; i < field.Length; i++)
            {
                if (field[i] == '>')
                {
                    power += int.Parse(field[i + 1].ToString());
                   
                }
                if (power > 0 && field[i] != '>')
                {
                    
                    power--;
                    continue;
                }
                result.Add(field[i]);
                

            }
            Console.WriteLine(string.Join("", result));
        }
    }
}
