namespace Task_1._Create_methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MyMethod(23, true));
        }

        static (string, string) MyMethod(int num, bool isTrue)
        {

            if (num > 3)
            {
                return ("true", num.ToString());
            }

            return ("false", num.ToString());
        }
    }
}