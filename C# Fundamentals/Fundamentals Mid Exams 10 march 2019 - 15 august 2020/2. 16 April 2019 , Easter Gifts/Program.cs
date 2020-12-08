using System;
using System.Linq;

namespace _2._16_April_2019___Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] giftsList = Console.ReadLine().Split();

            string end = Console.ReadLine();

            while (end != "No Money")
            {
                string [] cmd = end.Split();
                switch (cmd[0])
                {

                    case "OutOfStock":

                        for (int i = 0; i < giftsList.Length; i++)
                        {
                            if (giftsList[i] == cmd[1])
                            {
                                giftsList[i] = "None";
                            }
                        }

                        break;
                    case "Required":

                        int index = int.Parse(cmd[2]);

                        if (index > 0 && index < giftsList.Length)
                        {
                            giftsList[index] = cmd[1];
                        }

                        break;
                    case "JustInCase":

                        giftsList[giftsList.Length - 1] = cmd[1];

                        break;

                    default:
                        break;
                }
                end = Console.ReadLine();
            }

            
            giftsList = giftsList.Where(c => c != "None").ToArray();
            Console.WriteLine(string.Join(" ", giftsList));
        }
    }
}
