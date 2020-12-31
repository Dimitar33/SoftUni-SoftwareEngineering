using System;
using System.IO;

namespace _5._Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = new string[] { "Part-1.txt", "Part-2.txt", "Part-3.txt", "Part-4.txt" };

            using (FileStream bigFile = new FileStream("../../../sliceMe.txt", FileMode.Open))
            {
                long size = (long)Math.Ceiling((double)bigFile.Length / 4);
            
                for (int i = 0; i < 4; i++)
                {
                    using (var parts = new FileStream($"../../../{files[i]}", FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];
                        long count = 0;

                        while (count <= size)
                        {
                            bigFile.Read(buffer, 0, buffer.Length);
                            parts.Write(buffer, 0, buffer.Length);
                            count += buffer.Length;
                          
                            
                        }
                    }
                }
            }
        }
    }
}
