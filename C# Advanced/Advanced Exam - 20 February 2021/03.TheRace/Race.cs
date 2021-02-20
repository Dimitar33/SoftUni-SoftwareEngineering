using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    class Race
    {
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Racers = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Racer> Racers { get; set; }
        public int Count { get => Racers.Count;  }
        public void Add(Racer Racer)
        {
            if (Racers.Count < Capacity)
            {
                Racers.Add(Racer);
            }
        }
        public bool Remove(string name)
        {
            Racer racer = Racers.FirstOrDefault(c => c.Name == name);

            if (racer == null)
            {
                return false;
            }
            Racers.Remove(racer);
            return true;
        }

        public Racer GetOldestRacer()
        {
            return Racers.OrderByDescending(c => c.Age).First();
        }

        public Racer GetRacer(string name)
        {
            return Racers.FirstOrDefault(x => x.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return Racers.OrderByDescending(x => x.car.Speed).First();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {Name}:");

            foreach (var item in Racers)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
