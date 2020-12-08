using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str= Console.ReadLine().Split();

            int result = CharacterMultiplier(str[0],  str[1]);

            Console.WriteLine(result);

           
        }

        private static int CharacterMultiplier(string first, string second)
        {
            string shorter = "";
            string longer = "";

            int sum = 0;

            if (first.Length <second.Length)
            {
                shorter = first;
                longer = second;
            }
            else
            {
                shorter = second;
                longer = first;
            }
            for (int i = 0; i < shorter.Length; i++)
            {
                sum += shorter[i] * longer[i];
            }
            for (int i = 0; i < longer.Length - shorter.Length; i++)
            {
                sum += longer[longer.Length - 1 - i];
            }
            return sum;
        }
    }
}
