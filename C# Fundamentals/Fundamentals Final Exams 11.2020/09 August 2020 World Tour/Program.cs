using System;

namespace _09_August_2020_World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            string[] cmd = Console.ReadLine().Split(":");

            while (cmd[0] != "Travel")
            {
                switch (cmd[0])
                {
                    case "Add Stop":

                        int index = int.Parse(cmd[1]);

                        if (index >= 0 && index < input.Length)
                        {
                            input = input.Insert(index, cmd[2]);
                        }
                            Console.WriteLine(input);

                        break;
                    case "Remove Stop":

                        int startIndex = int.Parse(cmd[1]);
                        int endIndex = int.Parse(cmd[2]);

                        if (startIndex >= 0 && startIndex <= endIndex && endIndex < input.Length)
                        {
                            input = input.Remove(startIndex, endIndex - startIndex + 1);
                        }
                            Console.WriteLine(input);

                        break;
                    case "Switch":

                       
                        
                            input = input.Replace(cmd[1], cmd[2]);
                        
                            Console.WriteLine(input);


                        break;
                    default:
                        break;
                }
                cmd = Console.ReadLine().Split(":");
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
        }
    }
}
