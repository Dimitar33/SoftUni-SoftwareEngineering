using System;

namespace _01._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] word = Console.ReadLine().Split();

            Random rng = new Random();

            for (int i = 0; i < word.Length; i++)
            {
               int n = rng.Next(0, word.Length);

                string temp = word[i];
                word[i] = word[n];
                word[n] = temp;

            }
            Console.WriteLine(string.Join(Environment.NewLine, word));
        }
    }
}
