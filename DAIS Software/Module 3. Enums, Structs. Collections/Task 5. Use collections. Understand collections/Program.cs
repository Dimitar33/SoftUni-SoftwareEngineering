using System.Collections;
using System.Collections.Specialized;

namespace Task_5._Use_collections._Understand_collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Colections();

            static void Colections()
            {

                ArrayList arrayList = new ArrayList();

                Hashtable hashtable = new Hashtable();

                Queue queue = new Queue();

                Stack stack = new Stack();

                SortedList sortedList = new SortedList();

                ListDictionary listDictionary = new ListDictionary();

                HybridDictionary hybridDictionary = new HybridDictionary();

                OrderedDictionary orderedDictionary = new OrderedDictionary();

                NameValueCollection nameValueCollection = new NameValueCollection();

                StringCollection strings = new StringCollection();

                for (int i = 0; i < 100; i++)
                {
                    arrayList.Add(i);

                    hashtable.Add("i" + i, i);

                    queue.Enqueue(i);

                    stack.Push("i");

                    sortedList.Add(i, "i" + i);

                    listDictionary.Add(i, i); // linked list 10 elements..

                    hybridDictionary.Add(i, i); // linked list when less elements, hastable when many

                    orderedDictionary.Add(i, i);

                    nameValueCollection.Add("i" + i, "i"); // string only, one key can have many values

                    strings.Add("i" + i); // like a StringBuilder ?
                }

                Console.WriteLine(string.Join(" ", arrayList.ToArray().SkipLast(3)));
                Console.WriteLine();

                Console.WriteLine(string.Join(" ", hashtable.Keys.Cast<string>().Skip(3)));
                Console.WriteLine();

                Console.WriteLine(string.Join(" ", queue.ToArray().Skip(3)));
                Console.WriteLine();

                Console.WriteLine(string.Join(" ", stack.ToArray().Skip(3)));
                Console.WriteLine();

                Console.WriteLine(string.Join(" ", (dynamic)sortedList.Keys.Cast<int>().Skip(3)));
                Console.WriteLine();

                Console.WriteLine(string.Join(" ", listDictionary.Keys.Cast<int>().Skip(3)));
                Console.WriteLine();

                Console.WriteLine(string.Join(" ", hybridDictionary.Keys.Cast<int>().Skip(3)));
                Console.WriteLine();

                Console.WriteLine(string.Join(" ", orderedDictionary.Keys.Cast<int>().Skip(3)));
                Console.WriteLine();

                Console.WriteLine(string.Join(" ", nameValueCollection.Keys.Cast<string>().SkipLast(3)));
                Console.WriteLine();

                Console.WriteLine(string.Join(" ", strings.Cast<string>().Skip(3).SkipLast(3)));
                Console.WriteLine();
            }
        }
    }
}