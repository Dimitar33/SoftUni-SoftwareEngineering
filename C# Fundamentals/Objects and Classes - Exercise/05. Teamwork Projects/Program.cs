using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < n; i++)
            {
                string[] create = Console.ReadLine().Split("-");

                if (teams.Exists(c => c.TeamName == create[1]))
                {
                    Console.WriteLine($"Team {create[1]} was already created!");
                    continue;
                }
                if (teams.Exists(c => c.Creator == create[0]))
                {
                    Console.WriteLine($"{create[0]} cannot create another team!");
                    continue;
                }
                else
                {
                    Team team = new Team(create[0], create[1]);
                    teams.Add(team);
                    Console.WriteLine($"Team {create[1]} has been created by {create[0]}!");

                }
            }

            string[] asingment = Console.ReadLine().Split("->");

            while (asingment[0] != "end of assignment")
            {

                if (teams.Exists(c => c.TeamName == asingment[1]))
                {
                    bool isTrue = teams.Select(c => c.Members).Any(c => c.Contains(asingment[0])) || teams.Exists(c => c.Creator == asingment[0]);

                    if (isTrue) 
                    {
                        Console.WriteLine($"Member {asingment[0]} cannot join team {asingment[1]}!");
                    }
                    else
                    {

                        int index = teams.FindIndex(c => c.TeamName == asingment[1]);
                        teams[index].Members.Add(asingment[0]);
                    }
                }
                else
                {
                    Console.WriteLine($"Team {asingment[1]} does not exist!");
                }



                asingment = Console.ReadLine().Split("->");
            }

            Team[] disband = teams.OrderBy(c => c.TeamName).Where(c => c.Members.Count == 0).ToArray();

            Team[] legitTeams = teams.OrderByDescending(c => c.Members.Count).ThenBy(c => c.TeamName).Where(c => c.Members.Count > 0).ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (Team team in legitTeams)
            {
                sb.AppendLine($"{team.TeamName}");
                sb.AppendLine($"- {team.Creator}");

                foreach (var item in team.Members.OrderBy(c =>c))
                {
                   sb.AppendLine($"-- {item}");
                }
            }
            

            Console.Write(sb.ToString());
            Console.WriteLine("Teams to disband:");
            Console.WriteLine(string.Join(Environment.NewLine, disband.Select(c => c.TeamName)));
        }
        class Team
        {
            public Team(string creator, string name)
            {
                TeamName = name;
                Creator = creator;
                Members = new List<string>();
            }

            public string TeamName { get; set; }
            public string Creator { get; set; }
            public List<string> Members { get; set; }

        }
    }
}
