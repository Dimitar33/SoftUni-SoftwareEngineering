using System;
using System.IO;

namespace _6._Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder = Console.ReadLine();

            double sum = 0;

            Console.WriteLine(DirectorySize(folder));
           
            
         }
        static double DirectorySize(string folder)
        {
            double sum = 0;
            string[] directories = Directory.GetDirectories(folder);
            string[] files = Directory.GetFiles(folder);
            

            foreach (var item in directories)
            {
               sum +=  DirectorySize(item);
            }
            Console.WriteLine(sum);


            for (int i = 0; i < files.Length; i++)         
            {
                FileInfo info = new FileInfo(files[i]);
                Console.WriteLine($"{info.Name} --> {info.Length} bytes");
                sum += info.Length / 1024000.0;
            }
           return sum ;
        }
    }
}
