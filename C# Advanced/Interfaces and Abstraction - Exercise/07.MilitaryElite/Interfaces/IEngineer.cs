using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public interface IEngineer
    {
        public ICollection<Repairs> RepairList { get; set; }
    }
}
