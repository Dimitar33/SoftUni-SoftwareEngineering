namespace Task_3._Inherit_generic_collection_and_specify_type
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDictionary keyValuePairs = new MyDictionary();
            MyLinkedList ints = new MyLinkedList();
            MyQueue ints1 = new MyQueue();
            MySordetList keyValuePairs1 = new MySordetList();
            MySortedDictionary keyValuePairs2 = new MySortedDictionary();
            MyStack ints2 = new MyStack();
            MyList ints3 = new MyList();

            Console.WriteLine("Hello, World!");
        }

        public class MyList : List<int>
        {

        }
        public class MyLinkedList : LinkedList<int>
        {

        }

        public class MyStack : Stack<int>
        {

        }

        public class MyDictionary : Dictionary<int, string>
        {

        }

        public class MySordetList : SortedList<int, string>
        {

        }

        public class MyQueue : Queue<int>
        {

        }
        public class MySortedDictionary : SortedDictionary<int, string>
        {

        }
    }
}