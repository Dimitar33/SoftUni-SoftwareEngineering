namespace Task_1._Data_types
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int maxInt = unchecked(int.MaxValue + 1);
            int minInt = unchecked(int.MinValue - 5);

            long maxLong = checked(long.MaxValue + 1);
            long minLong = unchecked(long.MinValue - 5);

            float maxFloat = checked(float.MaxValue + 1);
            float minFloat = (float.MinValue - 5);

            double maxDouble = checked(double.MaxValue + 1);
            double minDouble = (double.MinValue - 5);

            decimal maxDecimal = unchecked(decimal.MaxValue + 1);
            decimal minDecimal = decimal.MinValue - 1;

            DateTime dateMax = checked(DateTime.MaxValue.AddDays(2));

            string str = checked("dasdasd");

            char cha = unchecked ((char)(char.MaxValue + 1));
            char charr = checked ((char)(char.MaxValue + 1));

            Console.WriteLine(cha);
        }
    }
}