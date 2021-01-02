using System;
using System.IO;

namespace _4._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream copy = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                using (FileStream paste = new FileStream("../../../pasteMe.png", FileMode.Create))
                {
                    byte[] bufer = new byte[4096];
                    int count = 0;
                    while (count < copy.Length)
                    {
                        copy.Read(bufer, 0, bufer.Length);
                        paste.Write(bufer, 0, bufer.Length);

                        count += bufer.Length;
                    }
                }

            }
        }
    }
}
