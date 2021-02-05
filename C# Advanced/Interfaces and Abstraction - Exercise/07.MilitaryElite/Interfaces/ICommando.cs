using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public interface ICommando
    {
        public ICollection<Missions> MissionsList { get; set; }
    }
}
