using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    class Cargo
    {
        public string CargoType { get; set; }
        public int CargoWeight { get; set; }

        public Cargo(string cargoType, int cargoWeight)
        {
            CargoType = cargoType;
            CargoWeight = cargoWeight;
        }
    }
}
