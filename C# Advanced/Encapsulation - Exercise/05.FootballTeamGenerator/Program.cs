using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] cmd = Console.ReadLine().Split(";");

            List<Team> teams = new List<Team>();

            while (cmd[0] != "END")
            {
                try
                {
                    switch (cmd[0])
                    {

                        case "Team":

                            Team team = new Team(cmd[1]);

                            teams.Add(team);

                            break;
                        case "Add":

                            Team teamToAdd = teams.First(c => c.name == cmd[1]);

                            if (teamToAdd == null)
                            {
                                Console.WriteLine($"Team {cmd[1]} does not exist.");
                            }
                            else
                            {
                                string name = cmd[2];
                                int endurance = int.Parse(cmd[3]);
                                int sprint = int.Parse(cmd[4]);
                                int dribble = int.Parse(cmd[5]);
                                int passing = int.Parse(cmd[6]);
                                int shooting = int.Parse(cmd[7]);

                                Player player = new Player(name, endurance, sprint, dribble, passing, shooting);

                                teamToAdd.AddPlayer(player);
                            }

                            break;
                        case "Remove":

                            Team teamToRemove = teams.First(c => c.name == cmd[1]);

                            teamToRemove.RemovePlayer(cmd[2]);

                            break;
                        case "Rating":

                            Team teamRairing = teams.First(c => c.name == cmd[1]);

                            if (teamRairing == null)
                            {
                                Console.WriteLine($"Team {cmd[1]} does not exist.");
                            }
                            else
                            {
                                Console.WriteLine($"{cmd[1]} - {teamRairing.Raiting}");
                            }

                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException e)
                {

                    Console.WriteLine(e.Message);
                }

                cmd = Console.ReadLine().Split(";");
            }
        }
    }
}

