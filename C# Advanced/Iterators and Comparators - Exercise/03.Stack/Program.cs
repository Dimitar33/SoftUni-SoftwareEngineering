using System;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmd = Console.ReadLine();

            CustomStack<string> stak = new CustomStack<string>();

            while (cmd != "END")
            {
                if (cmd.Contains("Push"))
                {
                    string[] itemsToPush = cmd.Split(new string[] {",", " " }, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
                    stak.Push(itemsToPush);
                }
                else
                {
                    if (stak.Count() == 0)
                    {
                        Console.WriteLine("No elements");
                        return;
                    }
                    stak.Pop();
                }

                cmd = Console.ReadLine();
            }

            foreach (var item in stak)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stak)
            {
                Console.WriteLine(item);
            }
        }
    }
}
