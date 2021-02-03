using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    interface ICall
    {
        public int Number { get; set; }

        public string Call();
    }
}
