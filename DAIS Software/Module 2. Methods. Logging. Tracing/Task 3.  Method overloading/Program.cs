namespace Task_3.__Method_overloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MyMethod());
        }

        static (string, string) MyMethod(ref int num, bool isTrue)
        {

            num += 4232;

            if (num > 3)
            {
                return ("true", num.ToString());
            }

            return ("false", num.ToString());
        }

        static (string, string) MyMethod(int num, string name, string[] args)
        {

            if (num > 3)
            {
                return ("true", num.ToString());
            }

            return ("false", num.ToString());
        }
        static (string, string) MyMethod(string name = "no name", int num = 0, params int[] numbers)
        {

            if (num > 3)
            {
                return ("true", num.ToString());
            }

            return ("false", num.ToString());
        }
    }
}