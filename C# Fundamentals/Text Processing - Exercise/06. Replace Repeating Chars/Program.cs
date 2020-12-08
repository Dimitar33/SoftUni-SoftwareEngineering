using System;
using System.Text;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string letters = Console.ReadLine();

            StringBuilder noRepeat = new StringBuilder(letters);

            for (int i = 0; i < noRepeat.Length -1; i++)
            {
                if (noRepeat[i] == noRepeat[i +1])
                {
                    noRepeat.Remove(i + 1, 1);
                    i--;
                }
            }
            
           Console.WriteLine(noRepeat);
        }
    }
}
