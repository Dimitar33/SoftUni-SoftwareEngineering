using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class StationaryPhone : ICall
    {
        public StationaryPhone(int number)
        {
            Number = number;
        }

        public int Number { get; set; }

        public string Call()
        {
            return $"Dialing... {Number}";
        }
    }
}
