using System.IO;

namespace Task_1._Word_count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dirPath = "E:\\programs";

            var files = Directory.GetFiles(dirPath);

            List<string> words = new List<string>();

            using(DisposableClass forDispose = new DisposableClass())
            {
                words = forDispose.CountWords(dirPath);
            }

            Console.WriteLine(words.Count());
        }
    }

    public class DisposableClass : IDisposable
    {
        public List<string> CountWords(string dirPath)
        {
            var words = new List<string>();

            var files = Directory.GetFiles(dirPath);

            foreach (var file in files)
            {
                StreamReader reader = new StreamReader(file); // using ??

                if (file.Contains(".txt"))
                {
                    words.AddRange(reader.ReadToEnd().Split(" ").ToList());
                }

            }

            return words;
        }
        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }


    }
}