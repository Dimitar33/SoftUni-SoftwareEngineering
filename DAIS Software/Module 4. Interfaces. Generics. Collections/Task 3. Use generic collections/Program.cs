using System.Collections;
using System.Collections.Specialized;

namespace Task_3._Use_generic_collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Colections();
        }

        public static void Colections()
        {
            List<string> list = new List<string>();

            LinkedList<string> linkedList = new LinkedList<string>();

            Queue queue = new Queue();

            Stack stack = new Stack();

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            SortedList sortedList = new SortedList();

            SortedDictionary<int, int> sordedDictionary = new SortedDictionary<int, int>();


            for (int i = 0; i < 10; i++)
            {
                list.Add("i" + i);

                linkedList.AddFirst("i" + i);

                queue.Enqueue(i);

                stack.Push("i");

                dictionary.Add("i" + i, i);

                sortedList.Add(i, "i");

                sordedDictionary.Add(i, i);
            }

            Console.WriteLine(string.Join(" ", list.Skip(3).SkipLast(3)));
            Console.WriteLine();

            Console.WriteLine(string.Join(" ", linkedList.ToArray().Skip(3)));
            Console.WriteLine();

            Console.WriteLine(string.Join(" ", queue.ToArray().Skip(3)));
            Console.WriteLine();

            Console.WriteLine(string.Join(" ", stack.ToArray().Skip(3)));
            Console.WriteLine();

            Console.WriteLine(string.Join(" ", dictionary.Keys.Cast<string>().Skip(3)));
            Console.WriteLine();

            Console.WriteLine(string.Join(" ", (dynamic)sortedList.Keys.Cast<int>().Skip(3)));
            Console.WriteLine();

            Console.WriteLine(string.Join(" ", sordedDictionary.Keys.Cast<int>().Skip(3)));
            Console.WriteLine();

        }
    }
}
