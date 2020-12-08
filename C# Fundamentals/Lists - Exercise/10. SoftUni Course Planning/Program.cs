using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine().Split(", ").ToList();

            string[] cmd = Console.ReadLine().Split(":");

            while (cmd[0] != "course start")
            {
                int index1 = schedule.IndexOf(cmd[1]);
                switch (cmd[0])
                {
                    case "Add":

                        if (!schedule.Contains(cmd[1]))
                        {
                            schedule.Add(cmd[1]);
                        }

                        break;
                    case "Insert":

                        if (!schedule.Contains(cmd[1]))
                        {
                            if (int.Parse(cmd[2]) >= 0 && int.Parse(cmd[2]) < schedule.Count)
                            {
                                schedule.Insert(int.Parse(cmd[2]), cmd[1]);

                            }
                        }

                        break;
                    case "Remove":

                        schedule.Remove(cmd[1]);

                        if (schedule.Contains(cmd[1] + "-Exercise"))
                        {

                            schedule.Remove(cmd[1] + "-Exercise");

                        }

                        break;
                    case "Swap":

                        int index2 = schedule.IndexOf(cmd[2]);

                        if (schedule.Contains(cmd[1]) && schedule.Contains(cmd[2]))
                        {
                            string temp = schedule[index1];
                            schedule[index1] = schedule[index2];
                            schedule[index2] = temp;

                            if (schedule.Contains(cmd[2] + "-Exercise"))
                            {

                                string tempp = cmd[2] + "-Exercise";
                                schedule.Remove(cmd[2] + "-Exercise");

                                int index3 = schedule.IndexOf(cmd[2]);
                                schedule.Insert(index3 + 1, tempp);
                            }

                            if (schedule.Contains(cmd[1] + "-Exercise"))
                            {

                                string tempp = cmd[1] + "-Exercise";
                                schedule.Remove(cmd[1] + "-Exercise");
                                int index3 = schedule.IndexOf(cmd[1]);

                                schedule.Insert(index3 + 1, tempp);
                            }
                        }


                        break;
                    case "Exercise":

                        if (!schedule.Contains(cmd[1] + "-Exercise"))
                        {

                            if (index1 == -1)
                            {
                                schedule.Add(cmd[1]);
                                schedule.Add(cmd[1] + "-Exercise");
                            }
                            else
                            {
                                schedule.Insert(index1 + 1, cmd[1] + "-Exercise");
                            }
                        }
                        break;

                    default:
                        break;
                }
                cmd = Console.ReadLine().Split(":");
            }
            for (int i = 0; i < schedule.Count; i++)
            {

                Console.WriteLine($"{i + 1}.{schedule[i]}");
            }
        }
    }
}
