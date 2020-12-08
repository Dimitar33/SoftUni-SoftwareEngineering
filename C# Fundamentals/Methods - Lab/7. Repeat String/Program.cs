using System;
using System.Text;

namespace _7._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            Newstring(word, count);
            string result = Newstring(word, count);

            Console.WriteLine(result);
        }

        private static string Newstring(string word, int count)
        {
            StringBuilder addedString = new StringBuilder();

            for (int i = 1; i <= count; i++)
            {
                addedString.Append(word);
            }
            return addedString.ToString();
        }
    }
}
