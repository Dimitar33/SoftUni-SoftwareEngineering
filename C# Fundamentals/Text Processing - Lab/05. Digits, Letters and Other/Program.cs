using System;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string digits = "";
            string letters = "";
            string simbols = "";

            for (int i = 0; i < text.Length; i++)                    
            {
                if ( char.IsDigit(text[i]))
                {
                    digits += text[i];
                }
               else if (char.IsLetter(text[i]))
                {
                    letters += text[i];
                }
                else
                {
                    simbols += text[i];
                }
            }
            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(simbols);
        }
    }
}
