using System;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyWord = Console.ReadLine().ToLower();
            string text = Console.ReadLine();

            int index = text.IndexOf(keyWord);

            while (index != -1)
            {
                text = text.Remove(index, keyWord.Length);
                index = text.IndexOf(keyWord);
            }

            Console.WriteLine(text);
        }
    }
}
