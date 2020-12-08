using System;
using System.Collections.Generic;
using System.Linq;

namespace Magic_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> deck = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries).ToList();

            string[] cmd = Console.ReadLine().Split();

            List<string> hand = new List<string>();

            while (cmd[0] != "Ready")
            {
                string cardName = cmd[1];

                switch (cmd[0])
                {

                    case "Add":

                        if (deck.Contains(cardName))
                        {
                            hand.Add(cardName);
                        }
                        else
                        {
                            Console.WriteLine("Card not found.");
                        }

                        break;
                    case "Insert":

                        int index = int.Parse(cmd[2]);

                        if (!deck.Contains(cardName) || index < 0 || index >= deck.Count)
                        {
                            Console.WriteLine("Error!");
                        }
                        else
                        {
                            hand.Insert(index, cardName);
                        }

                        break;
                    case "Remove":

                        if (hand.Contains(cardName))
                        {
                            hand.Remove(cardName);
                        }
                        else
                        {
                            Console.WriteLine("Card not found.");
                        }
                        break;
                    case "Swap":

                        int index1 = hand.IndexOf(cardName);
                        int index2 = hand.IndexOf(cmd[2]);

                        hand[index1] = cmd[2];
                        hand[index2] = cardName;

                        break;

                    default:

                        hand.Reverse();

                        break;
                }
                cmd = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", hand));
        }
    }
}
