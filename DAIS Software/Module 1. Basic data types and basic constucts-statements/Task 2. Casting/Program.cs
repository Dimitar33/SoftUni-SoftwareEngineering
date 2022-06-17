namespace Task_2._Casting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            sbyte sbyteNum = 22;

            short shortt = sbyteNum;
            int intt = shortt;
            long longg = intt;
            float floatt = longg;
            double doublee = floatt;
            decimal decimall = (decimal)doublee;

            sbyteNum = (sbyte)shortt;
            shortt = (short)intt;
            intt = (int)longg;
            longg = (long)floatt;
            floatt = (float)doublee;
            doublee = (double)decimall;

            char simbol = 'a';
            int num = 115;
            float flot = float.Parse(simbol.ToString());

            simbol = (char)num;
            Console.WriteLine(simbol);
        }
    }
}