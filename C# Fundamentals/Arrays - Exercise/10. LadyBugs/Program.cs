using System;
using System.Linq;

namespace _10._LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] inicialBugs = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            string input = Console.ReadLine();
            int[] field = new int[fieldSize];
            int jumpPosition = 0;

            for (int i = 0; i < inicialBugs.Length; i++)
            {
                int bug = inicialBugs[i];

                if (bug >= 0 && bug < field.Length)
                {
                    field[bug] = 1;
                }

            }
            while (input != "end")
            {
                string[] position = input.Split().ToArray();
                int flightLenght = int.Parse(position[2]);
                bool isTrue = true;
                jumpPosition = int.Parse(position[0]);
                int start = int.Parse(position[0]);

                if ((jumpPosition > field.Length - 1 || jumpPosition < 0) || (field[jumpPosition] == 0) || flightLenght == 0)
                {
                    input = Console.ReadLine();
                    continue;
                }
                while (field[jumpPosition] == 1)
                {
                    if (position[1] == "right" || (position[1] == "left" && flightLenght < 0))
                    {
                        jumpPosition += Math.Abs(flightLenght);

                    }
                    else if (position[1] == "left" || (position[1] == "right" && flightLenght < 0))
                    {
                        jumpPosition -= Math.Abs(flightLenght);
                    }
                    if (jumpPosition > field.Length - 1 || jumpPosition < 0)
                    {
                        isTrue = false;
                        break;
                    }

                }
                if (isTrue)
                {
                    field[jumpPosition] = 1;

                }
                field[start] = 0;


                input = Console.ReadLine();

            }
            Console.WriteLine(string.Join(" ", field));
        }
    }
}
