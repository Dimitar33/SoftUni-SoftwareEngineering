using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> pplComing = Console.ReadLine().Split().ToList();

            string[] cmd = Console.ReadLine().Split();



            while (cmd[0] != "Party!")
            {
                if (cmd[0] == "Remove")
                {
                    if (cmd[1] == "StartsWith")
                    {

                        pplComing = pplComing.Where(c => !c.StartsWith(cmd[2])).ToList();
                    }
                    else if (cmd[1] == "EndsWith")
                    {
                        pplComing = pplComing.Where(c => !c.EndsWith(cmd[2])).ToList();
                    }
                    else
                    {
                        pplComing = pplComing.Where(c => !(c.Length == int.Parse(cmd[2]))).
                            ToList();
                    }

                }
                else
                {
                    List<string> tempList = new List<string>();

                    if (cmd[1] == "StartsWith")
                    {
                        pplComing.AddRange(pplComing.Where(c => c.StartsWith(cmd[2])).
                            ToList());
                    }
                    else if (cmd[1] == "EndsWith")
                    {
                        pplComing.AddRange(pplComing.Where(c => c.EndsWith(cmd[2])).ToList());
                    }
                    else
                    {
                        pplComing.AddRange(pplComing.Where(c => c.Length == int.Parse(cmd[2])).
                            ToList());
                    }


                }
                cmd = Console.ReadLine().Split();
            }

          

            if (pplComing.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine( $"{string.Join(", ", pplComing)} are going to the party!");
            }
        }
    }
}
