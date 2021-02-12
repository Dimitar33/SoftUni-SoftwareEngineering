using System;
using System.Text;

namespace _08.CollectionHierarchy
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            AddCollection addColection = new AddCollection();
            AddRemoveCollection addRemColl = new AddRemoveCollection();
            MyList myList = new MyList();

            for (int i = 0; i < input.Length; i++)
            {
                addColection.Add(input[i]);
                addRemColl.Add(input[i]);
                myList.Add(input[i]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(0 + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(0 + " ");
            }
            Console.WriteLine();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                sb.Append(addRemColl.Remove() + " ");
            }

            Console.WriteLine(sb.ToString());
            sb.Clear();
            for (int i = 0; i < n; i++)
            {
                sb.Append(myList.Remove() + " ");
            }

            Console.WriteLine(sb.ToString());

        }
    }
}
