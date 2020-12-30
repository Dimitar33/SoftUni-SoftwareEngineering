using System;
using System.IO;
using System.Text;

namespace _4._Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamReader fileOne = new StreamReader("../../../FileOne.txt"))
            {
                StreamReader fileTwo = new StreamReader("../../../FileTwo.txt");

                string[] one = fileOne.ReadToEnd().Split();
                string[] two = fileTwo.ReadToEnd().Split();

                using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
                {
                    for (int i = 0; i < one.Length; i++)
                    {
                        writer.Write($"{one[i]}\n\n{two[i]}");
                                         
                    }
                }
            }
        }
    }
}
