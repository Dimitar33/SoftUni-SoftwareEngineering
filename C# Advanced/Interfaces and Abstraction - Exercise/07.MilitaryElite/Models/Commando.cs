using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        

        public Commando(int id, string firstName, string lastName, decimal salary, string corps, ICollection<Missions> missionsList) : base(id, firstName, lastName, salary, corps)
        {
            MissionsList = missionsList;
        }

        public ICollection<Missions> MissionsList { get; set; }

        public void CompleteMission(string mission)
        {
            Missions curentMission = MissionsList.FirstOrDefault(c => c.MissionCodeName == mission);

            curentMission.MissionState = "Finished";
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Missions:");

            foreach (var item in MissionsList)
            {
                sb.AppendLine($"  {item.ToString()}");
            }

            return $"{base.ToString()}\nCorps: {Corps}\n{sb.ToString().Trim()}";
        }
    }
}
