using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasksInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] threadsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int taskToKill = int.Parse(Console.ReadLine());

            Queue<int> threads = new Queue<int>();
            Stack<int> tasks = new Stack<int>();

            for (int i = 0; i < tasksInput.Length; i++)
            {
                tasks.Push(tasksInput[i]);
            }
            for (int i = 0; i < threadsInput.Length; i++)
            {
                threads.Enqueue(threadsInput[i]);
            }

            while (true)
            {

                if (tasks.Peek() == taskToKill)
                {

                    break;
                }
                int curentThread = threads.Dequeue();

                if (curentThread >= tasks.Peek())
                {
                    
                    tasks.Pop();

                }
            }
            Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToKill}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
