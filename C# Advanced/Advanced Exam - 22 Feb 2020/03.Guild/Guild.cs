using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    class Guild
    {
        public Guild(string name, int capaciry)
        {
            Name = name;
            Capacity = capaciry;
            Rooster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get => Rooster.Count; }
        public List<Player> Rooster { get; set; }

        public void AddPlayer(Player player)
        {
            if (Rooster.Count < Capacity)
            {
                Rooster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = Rooster.FirstOrDefault(c => c.Name == name);

            if (player == null)
            {
                return false;
            }

            Rooster.Remove(player);
            return true;
        }

        public void PromotePlayer(string name)
        {
            Player player = Rooster.First(c => c.Name == name);
            player.Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            Player player = Rooster.First(c => c.Name == name);
            player.Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string clas)
        {
            Player[] playersKicked = Rooster.Where(c => c.Class == clas).ToArray();

            Rooster = Rooster.Where(c => c.Class != clas).ToList();

            return playersKicked;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");

            foreach (var item in Rooster)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
