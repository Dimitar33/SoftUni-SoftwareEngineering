using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1.__Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                using (StreamWriter write = new StreamWriter("../../../result.txt"))
                {
                    string line = reader.ReadLine();

                    int count = 0;

                    string regex = @"[-,.!?]";

                    while (line != null)
                    {
                        if (count % 2 == 0)
                        {
                            line = Regex.Replace(line, regex, "@");
                            var reverse = line.Split().ToArray().Reverse();
                            Console.WriteLine(string.Join(" ", reverse));

                            write.WriteLine(string.Join(" ", reverse));

                        }
                        line = reader.ReadLine();
                        count++;
                    }
                }
            }
        }
    }
}
