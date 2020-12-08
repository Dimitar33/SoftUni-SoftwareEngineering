using System;
using System.Linq;

namespace _2._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();

            int result = vowelCount(word);

            Console.WriteLine(result);

        }

        private static int vowelCount(string word)
        {
            int count = 0;
            char[] vowels = { 'a', 'e' , 'o' , 'u' ,'i' };

            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < vowels.Length; j++)
                {
                    if (word[i] == vowels[j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
