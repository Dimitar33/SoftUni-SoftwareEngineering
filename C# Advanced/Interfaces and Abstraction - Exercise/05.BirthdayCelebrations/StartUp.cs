using System;
using System.Collections.Generic;

namespace _04.BorderControl
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            string[] cmd = Console.ReadLine().Split();

            List<Birthdays> birthdays = new List<Birthdays>();

            while (cmd[0] != "End")
            {

                switch (cmd[0])
                {
                    case "Citizen":

                        Human human = new Human(cmd[1], cmd[2], cmd[3],cmd[4]);
                        birthdays.Add(human);

                        break;
                    case "Pet":

                        Pet pet = new Pet(cmd[1], cmd[2]);
                        birthdays.Add(pet);

                        break;
                    case "Robot":

                        Robot robot = new Robot(cmd[1], cmd[2]);
                      

                        break;

                    default:
                        break;
                }

                cmd = Console.ReadLine().Split();
            }

            string year = Console.ReadLine();

           

            for (int i = 0; i < birthdays.Count; i++)
            {
                if (birthdays[i].Birthday.EndsWith(year))
                {
                  
                    Console.WriteLine(birthdays[i].Birthday);
                }
            }
           
        }
    }
}
