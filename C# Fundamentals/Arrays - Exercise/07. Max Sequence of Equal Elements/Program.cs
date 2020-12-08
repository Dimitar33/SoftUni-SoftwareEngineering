using System;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] n = Console.ReadLine().Split();

            string bigestArr = "";
            int bigestCount = 0;

            for (int i = 0; i < n.Length; i++)
            {
                int count = 0;
                string arr = "";

                for (int j = i; j < n.Length; j++)
                {
                    if (n[i] == n[j])
                    {
                        arr += n[i] + " ";
                        count++;
                        if (count > bigestCount)
                        {
                            bigestCount = count;
                            bigestArr = arr;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

            }
            Console.Write(bigestArr);
        }
    }
}
