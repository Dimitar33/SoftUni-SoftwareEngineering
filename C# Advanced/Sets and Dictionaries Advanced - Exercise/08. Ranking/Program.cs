using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(":");

            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, string> exams = new Dictionary<string, string>();

            while (input[0] != "end of contests")
            {
                exams.Add(input[0], input[1]);

                input = Console.ReadLine().Split(":");
            }

            string[] candidate = Console.ReadLine().Split("=>");

            while (candidate[0] != "end of submissions")
            {
                if (exams.ContainsKey(candidate[0]) && exams.ContainsValue(candidate[1]))
                {
                    int score = int.Parse(candidate[3]);

                    if (!users.ContainsKey(candidate[2]))
                    {
                        users.Add(candidate[2], new Dictionary<string, int>());
                        users[candidate[2]].Add(candidate[0], score);
                    }
                    if (!users[candidate[2]].ContainsKey(candidate[0]))
                    {
                        users[candidate[2]].Add(candidate[0], score);
                    }
                    else if(users.ContainsKey(candidate[2]) && users[candidate[2]][candidate[0]] < score)
                    {
                        users[candidate[2]][candidate[0]] = score;
                    }
                }

                candidate = Console.ReadLine().Split("=>");
            }
            string bestSudent = "";
            int best = 0;
            foreach (var item in users)
            {
                if (item.Value.Values.Sum() > best)
                {
                    bestSudent = item.Key;
                    best = item.Value.Values.Sum();
                }
            }           

            Console.WriteLine($"Best candidate is {bestSudent} with total {best} points.");
            Console.WriteLine("Ranking:");

            foreach (var item in users.OrderBy(c => c.Key))
            {
                Console.WriteLine(item.Key);

                foreach (var student in item.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"#  {student.Key} -> {student.Value}");
                }
            }
        }
    }
}
