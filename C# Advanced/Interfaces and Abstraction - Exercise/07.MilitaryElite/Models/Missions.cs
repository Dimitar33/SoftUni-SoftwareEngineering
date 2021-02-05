using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class Missions
    {
        private string missionState = "";

        public Missions(string missionCodeName, string missionState)
        {
            MissionCodeName = missionCodeName;
            MissionState = missionState;
        }

        public string MissionCodeName { get; set; }
        public string MissionState
        {
            get => missionState;
            set
            {
                if (value != "inProgress" && value != "Finished")
                {
                    throw new Exception();
                }
                missionState = value;


            }
        }

        
        public override string ToString()
        {
            return $"Code Name: {MissionCodeName} State: {missionState}";
        }
    }
}
