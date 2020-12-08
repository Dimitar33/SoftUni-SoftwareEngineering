using System;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace _9._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string n1 = Console.ReadLine();
            string n2 = Console.ReadLine();

            string result = GetMax(type, n1, n2);

            Console.WriteLine(result);
        }

        private static string GetMax(string type, string n1, string n2)
        {
            if (type == "int")
            {
               int big =Math.Max( int.Parse(n1), int.Parse(n2));
                return big.ToString();
            }
            else if (type == "char")
            {
                char ch1 = char.Parse(n1);
                char ch2 = char.Parse(n2);
                if (ch1 > ch2)
                {
                    return ch1.ToString();
                }
                else
                {
                    return ch2.ToString();
                }
            }
            else
            {
                int textComparison = n1.CompareTo(n2);
                if (textComparison > 0)
                {
                    return n1;
                }
                else
                {
                    return n2;
                }
            }
        }
    }
}
