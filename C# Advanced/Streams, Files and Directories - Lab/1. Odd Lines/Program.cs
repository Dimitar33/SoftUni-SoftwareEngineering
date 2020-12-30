using System;
using System.IO;

namespace _1._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../../../input.txt");

            using (reader)
            {
                string line = reader.ReadLine();
                int count = 0;

                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    while (line != null)
                    {
                        if (count % 2 != 0)
                        {
                            writer.WriteLine(line);
                            Console.WriteLine(line);
                        }
                        count++;
                        line = reader.ReadLine();

                    }
                }
            }
        }
    }
}
