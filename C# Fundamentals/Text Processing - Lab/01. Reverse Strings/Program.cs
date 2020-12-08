using System;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            while (word != "end")
            {
                string reversed = "";

                for (int i = 0; i < word.Length; i++)
                {
                    reversed += word[(word.Length - 1) - i];

                }
                Console.WriteLine($"{word} = {reversed}");
                word = Console.ReadLine();
            }

        }
    }
}
