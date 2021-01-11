using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    class Parking
    {
        private List<Car> cars;

        private int capacity;
        public int Count { get; set; }

        public Parking(int capacity)
        {
            this.cars = new List<Car>();

            this.capacity = capacity;
        }

        public string AddCar(Car car)
        {

            if (cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (Count == capacity)
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(car);
                Count++;

                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }

        }

        public string RemoveCar(string regNum)
        {
            if (!cars.Any(c => c.RegistrationNumber == regNum))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                cars.RemoveAll(c => c.RegistrationNumber == regNum);
                Count--;

                return $"Successfully removed {regNum}";

            }
        }

        public string GetCar(string regNum)
        {
            var neededCar = cars.First(c => c.RegistrationNumber == regNum);

            return neededCar.ToString();
        }

        public void RemoveSetOfRegs(List<string> regNums)
        {
            foreach (var item in regNums)
            {
                if (cars.Any(c => c.RegistrationNumber == item))
                {
                   Count -= cars.RemoveAll(c => c.RegistrationNumber == item);
                   
                }
            }
        }


    }
}
