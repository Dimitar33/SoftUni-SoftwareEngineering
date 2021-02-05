using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class Repairs : IRepairs
    {
        public Repairs(string repairName, int repairDuration)
        {
            RepairName = repairName;
            RepairDuration = repairDuration;
        }

        public string RepairName { get; set; }
        public int RepairDuration { get; set; }

        public override string ToString()
        {
            return $"Part Name: {RepairName} Hours Worked: {RepairDuration}";
        }
    }
}
