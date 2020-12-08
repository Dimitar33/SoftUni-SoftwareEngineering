using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _6._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            //string result = 
            midChar(word);

            //Console.WriteLine(midChar(word));
        }

        private static void midChar(string word)
        {
            int count = 0;

            for (int i = 0; i < word.Length; i++)
            {
                count++;
                if (word.Length % 2 != 0)
                {
                    if (count == word.Length / 2 + 1)
                    {
                        Console.WriteLine(word[i]);
                    }
                }
                else
                {
                    if (count == word.Length / 2 )
                    {
                        Console.Write($"{word[i]}{word[i +1]}" );
                    }
                }
            }



        }
    }
}
