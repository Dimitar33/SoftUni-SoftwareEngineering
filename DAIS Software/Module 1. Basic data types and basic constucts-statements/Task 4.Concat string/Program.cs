using System.Diagnostics;
using System.Text;

namespace Task_4.Concat_string
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            StringBuilder sb = new StringBuilder();

            sw.Start();

            //for (int i = 0; i < 10000; i++)
            //{
            //    sb.Append($"{i } num");
            //}

            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);

            string book = "";

            for (int i = 0; i < 10000; i++)
            {
                book += i + " " + "num";
            }

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}