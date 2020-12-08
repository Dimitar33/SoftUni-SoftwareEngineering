using System;

namespace _005._Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {

               int n = int.Parse(Console.ReadLine());
                int count = 0;
                int mainDigit = 0;
                int offset = 0;

                while (n > 0)
                {

                    mainDigit = n % 10;
                    n /= 10;
                    count++;
                }
                if (mainDigit == 8 || mainDigit == 9)
                {

                    offset = ((mainDigit - 2) * 3) + 1;
                }
                else
                {
                    offset = (mainDigit - 2) * 3;
                }

                int final = (offset + count - 1) + 97;
                if (final == 90)
                {
                    final = 32;
                }


                char dsa = Convert.ToChar(final);

                Console.Write(dsa);


            }
        }
    }
}
