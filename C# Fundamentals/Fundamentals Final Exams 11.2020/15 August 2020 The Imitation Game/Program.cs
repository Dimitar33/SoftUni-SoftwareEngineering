using System;
using System.Data.SqlTypes;

namespace _15_August_2020_The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] cmd = Console.ReadLine().Split("|");

            while (cmd[0] != "Decode")
            {
                switch (cmd[0])
                {
                    case "Move":

                        string temp = "";

                        temp = input.Substring(0, int.Parse(cmd[1]));
                        input = input.Remove(0, int.Parse(cmd[1]));
                        input += temp;

                        break;
                    case "Insert":

                        input = input.Insert(int.Parse(cmd[1]), cmd[2]);

                        break;
                    case "ChangeAll":

                        input = input.Replace(cmd[1], cmd[2]);

                        break;

                    default:
                        break;
                }
                cmd = Console.ReadLine().Split("|");
            }
            Console.WriteLine($"The decrypted message is: {input}");
        }
    }
}
