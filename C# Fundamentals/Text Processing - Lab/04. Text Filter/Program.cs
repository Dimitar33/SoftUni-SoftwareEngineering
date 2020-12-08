using System;

namespace _04._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");

            string text = Console.ReadLine();

            for (int i = 0; i < bannedWords.Length; i++)
            {
                string censured = "";
                for (int j = 0; j < bannedWords[i].Length; j++)
                {
                    censured += "*";
                }

                int index = text.IndexOf(bannedWords[i]);

                while (index != -1)
                {
                    text = text.Replace(bannedWords[i], censured);
                    index = text.IndexOf(bannedWords[i]);
                }

            }
            Console.WriteLine(text);
        }
    }
}
