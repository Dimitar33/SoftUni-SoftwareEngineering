using System;
using System.Linq;
using System.Text;

namespace _03._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string text = Console.ReadLine();


            while (text != "find")
            {
                string uncoded = "";

                for (int i = 0; i < text.Length; i += 0)
                {
                    for (int j = 0; j < key.Length; j++)
                    {
                        if (i >= text.Length)
                        {
                            break;
                        }
                       uncoded += ((char)(text[i] - key[j]));
                        i++;
                    }
                }
                text = Console.ReadLine();

                int indexStart = uncoded.IndexOf('&');
                int indexEnd = uncoded.LastIndexOf('&');
                int indexDs = uncoded.IndexOf('<');
                int indexStar = uncoded.IndexOf('>');

                string treasure = uncoded.Substring(indexStart + 1, indexEnd - indexStart - 1);
                string coordinates = uncoded.Substring(indexDs + 1, indexStar - indexDs - 1);

                Console.WriteLine($"Found {treasure} at {coordinates}");
            }
        }
    }
}
