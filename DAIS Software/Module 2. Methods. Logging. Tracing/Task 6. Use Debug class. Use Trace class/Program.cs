using System.Diagnostics;

namespace Task_6._Use_Debug_class._Use_Trace_class_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberss;

            Console.WriteLine("Type a number from 1 to 10");
            string input = Console.ReadLine();

            Debug.Assert(int.TryParse(input, out numberss),
                         string.Format("unable to parse {0} as int", input));

            Debug.WriteLine("The current value of input is {0}", input);
            Debug.WriteLine("The current value of number is {0}", numberss);

            Console.WriteLine("Press enter to finish");
            Console.WriteLine();
        }
    }
}