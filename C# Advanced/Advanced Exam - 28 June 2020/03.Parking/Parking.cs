using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    class Parking
    {
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Cars = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Car> Cars { get; set; }
        public int Count { get => Cars.Count; }

        public void Add(Car car)
        {
            if (Cars.Count < Capacity)
            {
                Cars.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car curentCar = Cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

            if (curentCar == null)
            {
                return false;
            }
            Cars.Remove(curentCar);
            return true;
        }

        public Car GetLatestCar()
        {
            return  Cars.OrderByDescending(c => c.Year).FirstOrDefault();
            
        }

        public Car GetCar(string manufacturer, string model)
        {
            return Cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);


        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (var item in Cars)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
