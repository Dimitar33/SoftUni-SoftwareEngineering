using Microsoft.VisualBasic;
using System;
using System.Text;

namespace _10_April_2020_Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string[] cmd = Console.ReadLine().Split(":|:");

            StringBuilder sb = new StringBuilder(message);
            
            while (cmd[0] != "Reveal")
            {
                switch (cmd[0])
                {
                    case "InsertSpace":

                       message = message.Insert(int.Parse(cmd[1]), " ");

                        Console.WriteLine(message);

                        break;
                    case "Reverse":

                        if (message.Contains(cmd[1]))
                        {
                            int index = message.IndexOf(cmd[1]);
                            message = message.Remove(index, cmd[1].Length);

                            char[] rev = cmd[1].ToCharArray();
                            Array.Reverse(rev);
                            string reverce = new string(rev);

                            message += reverce;

                            Console.WriteLine(message);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "ChangeAll":

                        message = message.Replace(cmd[1], cmd[2]);

                        Console.WriteLine(message);
                        break;

                    default:
                        break;
                }
                cmd = Console.ReadLine().Split(":|:");
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
