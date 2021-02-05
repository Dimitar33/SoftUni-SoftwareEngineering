using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public interface IMissions
    {
        public string MissionCodeName { get; set; }
        public string MissionState { get; set; }
    }
}
