using System;

namespace _04_April_2020_Group_2__Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string pass = "";

            while (cmd[0] != "Done")
            {
                switch (cmd[0])
                {
                    case "TakeOdd":
                        for (int i = 1; i < input.Length; i += 2)
                        {
                            pass += input[i];
                        }
                        input = pass;
                        Console.WriteLine(input);

                        break;
                    case "Cut":

                        int startIndex = int.Parse(cmd[1]);
                        int lenght = int.Parse(cmd[2]);

                        input = input.Remove(startIndex, lenght);

                        Console.WriteLine(input);

                        break;
                    case "Substitute":

                        if (input.Contains(cmd[1]))
                        {
                            input = input.Replace(cmd[1], cmd[2]);
                            Console.WriteLine(input);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }

                        break;
                    default:
                        break;
                }
                cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Your password is: {input}");
        }
    }
}
