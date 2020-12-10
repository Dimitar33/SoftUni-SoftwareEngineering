using System;
using System.Linq;
using System.Text;

namespace _04_April_2020_Group_1_Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();          

            string[] cmd = Console.ReadLine().Split(">>>");

            while (cmd[0] != "Generate")
            {
                switch (cmd[0])
                {
                    case "Contains":

                        if (data.Contains(cmd[1]))
                        {
                            Console.WriteLine($"{data} contains {cmd[1]}");                        
                        }
                        else
                        {
                            Console.WriteLine($"Substring not found!");
                        }

                        break;
                    case "Flip":
                        int startIndex = int.Parse(cmd[2]);
                        int endIndex = int.Parse(cmd[3]);

                        string substring1 = data.Substring(0, startIndex);
                        string substring2 = data.Substring(startIndex, endIndex - startIndex);
                        string substring3 = data.Substring(endIndex);

                        if (cmd[1] == "Upper")
                        {
                            substring2 = substring2.ToUpper();
                            data = substring1 + substring2 + substring3;
                        }
                        else
                        {
                            substring2 = substring2.ToLower();
                            data = substring1 + substring2 + substring3;
                        }

                        Console.WriteLine(data);

                        break;
                    case "Slice":

                        data = data.Remove(int.Parse(cmd[1]), int.Parse(cmd[2]) - int.Parse(cmd[1]));

                        Console.WriteLine(data);

                        break;

                    default:
                        break;
                }
                cmd = Console.ReadLine().Split(">>>");
            }
            Console.WriteLine($"Your activation key is: {data}");
        }
    }
}
