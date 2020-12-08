using System;

namespace _5_July_2020_SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int employe1 = int.Parse(Console.ReadLine());
            int employe2 = int.Parse(Console.ReadLine());
            int employe3 = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            
            int count = 0;
            int employePower = employe1 + employe2 + employe3;

            while (students > 0)
            {
                students -= employePower;
                count++;

                if (count % 4 == 0)
                {
                    count++;
                }
            }
            Console.WriteLine($"Time needed: {count}h.");
        }
    }
}
