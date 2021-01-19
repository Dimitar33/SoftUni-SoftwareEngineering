using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmd = Console.ReadLine();

            List<string> create = new List<string>(cmd.Split().Skip(1)).ToList();

            ListyIterator<string> list = new ListyIterator<string>(create);

            while (cmd != "END")
            {
                switch (cmd)
                {
                    case "Move":

                        list.Move();

                        break;
                    case "HasNext":

                        list.HasNext();

                        break;
                    case "Print":

                        list.Print();

                        break;
                    case "PrintAll":

                        list.PrintAll();

                        break;

                    default:
                        break;
                }
                cmd = Console.ReadLine();
            }
        }
    }
}
