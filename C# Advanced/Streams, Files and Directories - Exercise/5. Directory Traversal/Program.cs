using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _5._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            string[] files = Directory.GetFiles(path);

            Dictionary<string, Dictionary<string, double>> dict = new Dictionary<string, Dictionary<string, double>>();

            foreach (var item in files)
            {
                FileInfo info = new FileInfo(item);

                if (!dict.ContainsKey(info.Extension))
                {
                    dict.Add(info.Extension, new Dictionary<string, double>());
                }
                if (!dict[info.Extension].ContainsKey(info.Name))
                {
                    dict[info.Extension].Add(info.Name, info.Length);
                }
            }

            using (StreamWriter write = new StreamWriter($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\DirectoryTraversal.txt"))
            {

                foreach (var item in dict.OrderByDescending(c => c.Key.Count()))
                {
                    write.WriteLine(item.Key);

                    foreach (var file in item.Value.OrderBy(c => c.Value))
                    {
                        write.WriteLine($"--{file.Key} - {file.Value / 1024:f3}kb");

                    }

                }

            }
        }
    }
}
