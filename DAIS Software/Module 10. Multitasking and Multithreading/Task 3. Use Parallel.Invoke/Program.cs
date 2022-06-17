using System.Diagnostics;
using System.Numerics;

namespace Task_3._Use_Parallel.Invoke
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long count = 0;
            int logicalProcesors = 16;

            List<Task> tasks = new List<Task>();

            for (int i = 0; i < logicalProcesors; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    for (int j = 0; j < 1000_0000; j++)       // without lock
                    {
                        count++;
                    }
                }));
            }

            Parallel.Invoke(() => tasks.ToArray());

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine($"Paralel Invoke {count}");

            Stopwatch sw = new Stopwatch();

            sw.Start();

            Parallel.For(0, 1000_000_000, i =>        
            {
                    var num = i * i;

            });

            sw.Stop();
            Console.WriteLine($"Paralel For miliseconds {sw.ElapsedMilliseconds}");

            sw.Restart();

            for (int i = 0; i < 1000_000_000; i++)
            {
                
                    var num = i * i;

            }

            sw.Stop();

            Console.WriteLine($"Normal For miliseconds {sw.ElapsedMilliseconds}");

            var list = Enumerable.Range(0, 1000_000_000).ToList();

            sw.Restart();

            Parallel.ForEach(list, item =>
            {
                var num = item * item;
            });

            sw.Stop();

            Console.WriteLine($"Paralel ForEach miliseconds {sw.ElapsedMilliseconds}");

            sw.Restart();

            foreach (var item in list)
            {
                var num = item * item;
            }

            sw.Stop();

            Console.WriteLine($"Normal ForEach miliseconds {sw.ElapsedMilliseconds}");
        }
    }
}