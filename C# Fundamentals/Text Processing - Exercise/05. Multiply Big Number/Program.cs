using System;
using System.Text;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string bigNum = Console.ReadLine().TrimStart('0');

            int num = int.Parse(Console.ReadLine());
            string result = "";
            if (bigNum == "" || num == 0)
            {
                Console.WriteLine(0);
                return;
            }

            string reversed = "";
            int sum = 0;
            int remaining = 0;

            for (int i = 0; i < bigNum.Length; i++)
            {
                sum = int.Parse(bigNum[bigNum.Length - 1 - i].ToString()) * num + remaining;
                reversed += sum % 10;

                remaining = 0;

                while (sum > 9)
                {
                    remaining = sum / 10;
                    sum /= 10;
                }
            }
            if (remaining > 0)
            {
                reversed += remaining;
            }
            

            for (int i = 0; i < reversed.Length; i++)
            {
                result += reversed[reversed.Length - 1 - i];
            }
            Console.WriteLine(result);
        }
    }
}
