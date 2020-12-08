using System;

namespace _1._Encrypt__Sort_and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           
            char[] volew = { 'a', 'o', 'u', 'i', 'e' ,'A' ,'O' , 'U' , 'E' , 'I' };
            int[] order = new int[n];

            for (int k = 0; k < n; k++)
            {
                string word = Console.ReadLine();
                string name = word;
                int sum = 0;

                for (int i = 0; i < word.Length; i++)
                {
                    bool flag = false;
                    foreach (var item in volew)
                    {
                        if (word[i] == item)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        sum += word[i] * word.Length;
                    }
                    else
                    {
                        sum += (word[i] / word.Length);
                    }
                }
                order[k] = sum;
            }
                Array.Sort(order);
                Console.WriteLine(string.Join ("\n" , order));
        }
    }
}
