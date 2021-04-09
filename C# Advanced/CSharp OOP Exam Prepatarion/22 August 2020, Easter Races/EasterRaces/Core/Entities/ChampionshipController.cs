using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
         DriverRepository drRepo = new DriverRepository();
        CarRepository carRepo = new CarRepository();
        RaceRepository raceRepo = new RaceRepository();

        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = drRepo.Drivers.FirstOrDefault(x => x.Name == driverName);
            var car = carRepo.Models.FirstOrDefault(x => x.Model == carModel);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }
            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var driver = drRepo.Drivers.FirstOrDefault(x => x.Name == driverName);
            var race = raceRepo.Races.FirstOrDefault(x => x.Name == raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (carRepo.Models.Any(x => x.Model == model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            Car car;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else
            {
                car = new SportsCar(model, horsePower);
            }

            carRepo.Add(car);
            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            Driver driver = new Driver(driverName);
            
            if (drRepo.Drivers.Any(x => x.Name == driverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }
            drRepo.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);

        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepo.Races.Any(x => x.Name == name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            Race race = new Race(name, laps);
            raceRepo.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            var race = raceRepo.Races.FirstOrDefault(x => x.Name == raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            StringBuilder sb = new StringBuilder();

            raceRepo.Remove(race);

            var winers = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).Take(3).ToArray();
            
            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, winers[0].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, winers[1].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, winers[2].Name, race.Name));

            return sb.ToString().Trim();
        }
    }
}
