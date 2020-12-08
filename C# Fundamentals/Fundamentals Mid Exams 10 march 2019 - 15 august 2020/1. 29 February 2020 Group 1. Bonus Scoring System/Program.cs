using System;

namespace _1._29_February_2020_Group_1._Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int inicialBonus = int.Parse(Console.ReadLine());
            double maxBonus = 0;
            double bonus = 0;
            double student = 0;

            for (int i = 0; i < studentsCount; i++)
            {
                double attendances = double.Parse(Console.ReadLine());

                bonus = attendances / lecturesCount * (5 + inicialBonus);

                if (bonus > maxBonus)
                {
                    maxBonus =  bonus;
                    student = attendances;
                }
            }

            Console.WriteLine($"Max Bonus: {(int)Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {student} lectures.");
        }
    }
}
