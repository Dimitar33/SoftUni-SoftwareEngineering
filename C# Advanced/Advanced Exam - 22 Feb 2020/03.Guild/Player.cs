using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        private string discription = "n/a";

        private string rank = "Trial";
        public Player(string name, string clas)
        {
            Name = name;
            Class = clas;
        }

        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get => rank; set => rank = value; }
        public string Description { get => discription; set => discription = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Player {Name}: {Class}");
            sb.AppendLine($"Rank: {Rank}");
            sb.AppendLine($"Description: {Description}");

            return sb.ToString().Trim();  
        }
  
    }
}
