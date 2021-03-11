using NUnit.Framework;
using System;
using System.Collections.Generic;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddDriverNullExeption()
        {
            var race = new RaceEntry();
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(null));
        }

        [Test]
        public void AddDriverExistingDriver()
        {
            var race = new RaceEntry();
            var car = new UnitCar("BMW" ,121, 212);
            var driver = new UnitDriver("Pesho", car);
            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver));
        }
        [Test]
        public void AddDriverWorkCorrect()
        {
            var race = new RaceEntry();
            var car = new UnitCar("BMW", 121, 212);
            var driver = new UnitDriver("Pesho", car);
            var resilt = race.AddDriver(driver);


            Assert.AreEqual("Driver Pesho added in race.", resilt);
            Assert.AreEqual(1, race.Counter);
        }
        [Test]
        public void TheRaceCannotStartWithLessThanMinParticipants()
        {
            var race = new RaceEntry();
            var car1 = new UnitCar("BMW", 100, 212);               
            var driver1 = new UnitDriver("Pesho", car1);
                 
            race.AddDriver(driver1);
            
            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }
        [Test]
        public void CalculateAverageHorsePowerWorkCorrect()
        {
            var race = new RaceEntry();
            var car1 = new UnitCar("BMW", 100, 212);
            var car2 = new UnitCar("BMW", 200, 212);
            var car3 = new UnitCar("BMW", 300, 212);
            var driver1 = new UnitDriver("Pesho", car1);
            var driver2 = new UnitDriver("Ivan", car2);
            var driver3 = new UnitDriver("Dragan", car3);
            race.AddDriver(driver1);
            race.AddDriver(driver2);
            race.AddDriver(driver3);


            Assert.AreEqual(200, race.CalculateAverageHorsePower());
        }
    }
}