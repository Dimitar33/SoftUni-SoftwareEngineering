using System;

namespace _01._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] cmd = Console.ReadLine().Split();

            while (cmd[0] != "Finish")
            {
                switch (cmd[0])
                {
                    case "Replace":

                        input = input.Replace(cmd[1], cmd[2]);

                        Console.WriteLine(input);

                        break;
                    case "Cut":

                        int startIndex = int.Parse(cmd[1]);
                        int endIndex = int.Parse(cmd[2]);

                        if (startIndex >= 0 && startIndex <= endIndex && endIndex < input.Length) // =<
                        {
                            input = input.Remove(startIndex, (endIndex - startIndex + 1));

                            Console.WriteLine(input);
                        }
                        else
                        {
                            Console.WriteLine("Invalid indices!");
                        }

                        break;
                    case "Make":

                        if (cmd[1] == "Upper")
                        {
                            input = input.ToUpper();
                        }
                        else
                        {
                            input = input.ToLower();
                        }
                        Console.WriteLine(input);

                        break;
                    case "Check":

                        if (input.Contains(cmd[1]))
                        {
                            Console.WriteLine($"Message contains {cmd[1]}");
                        }
                        else
                        {
                            Console.WriteLine($"Message doesn't contain {cmd[1]}");
                        }

                        break;
                    case "Sum":

                        int start = int.Parse(cmd[1]);
                        int end = int.Parse(cmd[2]);

                        if (start >= 0 && start <= end && end < input.Length)
                        {
                            string sub = input.Substring(start, end - start + 1); 
                            int sum = 0;

                            for (int i = 0; i < sub.Length; i++)
                            {
                                sum += sub[i];
                            }
                            Console.WriteLine(sum);
                        }
                        else
                        {
                            Console.WriteLine("Invalid indices!");
                        }
                        break;
                    default:
                        break;
                }
                cmd = Console.ReadLine().Split();
            }
        }
    }
}
