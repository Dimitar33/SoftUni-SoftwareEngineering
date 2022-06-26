using System.IO;

namespace Task_4._Reverse_file_lines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] buffer = new byte[512];


            using (FileStream reader = new FileStream(@"E:\pas.txt", FileMode.Open, FileAccess.ReadWrite))
            {
                var bytesRead = reader.Read(buffer, 0, buffer.Length);

                while ((reader.Read(buffer, 0, buffer.Length) > 0))
                {
                    Array.Reverse(buffer);

                    for (int i = 0; i < buffer.Length; i++)
                    {
                        buffer[i] = (byte)(buffer[i] + i);
                    }

                    File.WriteAllBytes(@"E:\pass.txt", buffer);

                    Console.WriteLine(String.Join(" ", buffer));
                }

            }

        }
    }
}