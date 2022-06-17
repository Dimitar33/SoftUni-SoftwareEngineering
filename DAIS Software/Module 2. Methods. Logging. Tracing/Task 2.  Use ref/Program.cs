namespace Task_2.__Use_ref
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 12;
            Console.WriteLine(MyMethod(ref num, false));
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
    }
}