using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
            Car car = new Car("BMW", "X5", 10, 50);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ConstructorIfMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "X5", 10, 50));
           
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ConstructorIfModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", model, 10, 50));
           
        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void ConstructorIfFuelConsIsNegativeNumber(double cons)
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", "X5", cons, 50));

        }
        [Test]
        public void ConstructorIfFuelcapIsNegativeNumber()
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", "X5", 10, -1));

        }

        //Fuelamount TODO

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelAmountIsNegativeNumber(double refuel)
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", "X5", 10, 44).Refuel(refuel));

        }

        [Test]
        public void DriveAmountIsNegativeNumber()
        {
            Car car = new Car("BMW", "X5", 10, 50);

            car.Refuel(12);

            Assert.Throws<InvalidOperationException>(() => car.Drive(222));

        }

        [Test]
        [TestCase(10, 20, 10)]
        [TestCase(120, 20, 20)]
        public void RefuelWorkCorectly(double capacity , double refuel, double expected)
        {
            Car car = new Car("BMW", "X5", 10, capacity);

            car.Refuel(refuel);
                      
            Assert.AreEqual(expected, car.FuelAmount);  
        }

        [Test]
        public void DriveWorkCorectly()
        {
            Car car = new Car("BMW", "X5", 10, 50);

            car.Refuel(20);
            car.Drive(100);

            var expected = 10;
            var actual = car.FuelAmount;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConstructorWorksCorectrly()
        {
            Car car = new Car("BMW", "X5", 10, 50);

            Assert.AreEqual(50, car.FuelCapacity);
            Assert.AreEqual(10, car.FuelConsumption);
            Assert.AreEqual("BMW", car.Make);
            Assert.AreEqual("X5", car.Model);
            Assert.AreEqual(0, car.FuelAmount);
            
        }
    }
}