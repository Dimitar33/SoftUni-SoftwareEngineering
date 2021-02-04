using System;
using System.Collections.Generic;

namespace _04.BorderControl
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            string[] cmd = Console.ReadLine().Split();

            List<IDs> all = new List<IDs>();

            while (cmd[0] != "End")
            {
                if (cmd.Length == 2)
                {
                    Robot robot = new Robot(cmd[0], cmd[1]);

                    all.Add(robot);
                }
                else
                {
                    Human human = new Human(cmd[0], cmd[1], cmd[2]);

                    all.Add(human);
                }

                cmd = Console.ReadLine().Split();
            }

            string fake = Console.ReadLine();

            for (int i = 0; i < all.Count; i++)
            {
                
                if (all[i].Id.EndsWith(fake))
                {
                    Console.WriteLine(all[i].Id);
                }
            }
        }
    }
}
