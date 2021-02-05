using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, string corps, ICollection<Repairs> repairList)
            : base(id, firstName, lastName, salary, corps)
        {
            RepairList = repairList;
        }

        public ICollection<Repairs> RepairList { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Repairs:");

            foreach (var item in RepairList)
            {
                sb.AppendLine($"  {item.ToString()}");
            }

            return $"{base.ToString()}\nCorps: {Corps}\n{sb.ToString().Trim()}";
        }
    }
}
