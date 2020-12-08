using System;

namespace _01._Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string text = Console.ReadLine();

                int indexAt = text.IndexOf('@');
                int indexPipe = text.IndexOf('|');
                int indexDs = text.IndexOf('#');
                int indexStar = text.IndexOf('*');

                string name = text.Substring(indexAt + 1, indexPipe - indexAt -1 );
                string age =  text.Substring(indexDs + 1, indexStar - indexDs -1 );

                
                Console.WriteLine($"{name} is {age} years old.");
            }

        }
    }
}
