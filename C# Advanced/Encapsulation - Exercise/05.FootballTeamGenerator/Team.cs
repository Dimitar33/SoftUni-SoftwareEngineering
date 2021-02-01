using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    class Team
    {
        public string name;

        public Team(string name)
        {
            Name = name;
            Players = new List<Player>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public List<Player> Players { get; set; }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }
        public void RemovePlayer(string player)
        {
            Player toRemove = Players.First(c => c.Name == player);
            Players.Remove(toRemove);
        }

        public int Raiting { get => RaitingCalc();}

        private int RaitingCalc()
        {
            return (int)Math.Ceiling(Players.Average(c => c.Raiting));
        }
    }
}
