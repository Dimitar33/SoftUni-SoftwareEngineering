using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Telephony
{
    public class Smartphone : ICall, IWeb
    {
        string sites;
        int number;

        public Smartphone(int number)
        {
            Number = number;
        }

        public Smartphone(string site)
        {
            Site = site;
        }

        public int Number { get ; set; }
        public string Site
        {
            get => Site;
            set
            {
                if (value.Any(c => char.IsDigit(c)))
                {
                   throw new ArgumentException("Invalid URL!");
                }
                Site = sites;
            }
        }

        public List<int> Numbers { get; set; }
        public List<int> Sites { get; set; }

        public string Call()
        {
            return $"Calling... {Number}";
        }

        public int InvalidNumber(string num)
        {
            if (!num.All(char.IsDigit))
            {
               throw new ArgumentException("Invalid number!");
            }

            return int.Parse(num);
        }
    }
}
