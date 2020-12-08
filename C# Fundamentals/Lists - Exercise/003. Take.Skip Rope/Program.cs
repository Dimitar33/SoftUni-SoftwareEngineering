using System;
using System.Collections.Generic;
using System.Linq;

namespace _003._Take.Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<int> digits = new List<int>();
            List<string> letters = new List<string>();

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    digits.Add(int.Parse(text[i].ToString()));
                }
                else
                {
                    letters.Add(text[i].ToString());
                }
            }
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int i = 0; i < digits.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(digits[i]);
                }
                else
                {
                    skipList.Add(digits[i]);
                }
            }
            int sum = 0;
            List<string> take = new List<string>();

            for (int i = 0; i < takeList.Count; i++)
            {
                sum += takeList[i];
                if (sum < letters.Count)
                {
                    letters.RemoveRange(sum, skipList[i]);                  
                }

            }
            if (letters.Count > sum)
            {
                letters.RemoveRange(sum, letters.Count - sum);
            }
            Console.WriteLine(string.Join("" , letters));
        }
    }
}
