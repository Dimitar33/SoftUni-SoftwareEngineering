using System;
using System.IO;

namespace _5._Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = new string[] { "Part-1.txt", "Part-2.txt", "Part-3.txt", "Part-4.txt" };

            using (FileStream bigFile = new FileStream("../../../slice.txt", FileMode.Open))
            {
                long size = bigFile.Length / 4;
            
                for (int i = 0; i < 4; i++)
                {
                    using (var parts = new FileStream(files[i], FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];
                        int count = 0;

                        while (count < buffer)
                        {

                        }
                    }
                }
            }
        }
    }
}
