using System;
using System.Collections.Generic;
using System.Linq;


namespace SoftUniParking
{
    class Parking
    {
        private List<Car> cars;

        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }
        public int Count => this.cars.Count;

        public string AddCar(Car car)
        {

            if (cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (cars.Count == capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";


        }

        public string RemoveCar(string registrationNumber)
        {

            Car car = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }

            cars.Remove(car);

            return $"Successfully removed {registrationNumber}";


        }

        public Car GetCar(string registrationNumber)
        {
            return cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
          
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumber)
        {
            foreach (var item in registrationNumber)
            {

                var car = cars.FirstOrDefault(c => c.RegistrationNumber == item);
                cars.Remove(car);

            }
        }


    }
}
