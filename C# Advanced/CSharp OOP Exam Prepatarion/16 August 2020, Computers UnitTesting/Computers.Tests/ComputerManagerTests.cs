using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        private Computer comp;
        private ComputerManager cm;

        [SetUp]
        public void Setup()
        {
            comp = new Computer("Assus", "ROG", 2000);
            cm = new ComputerManager();
        }
        [Test]
        public void ComputerCionstructorWorkCorrect()
        {
            Assert.AreEqual("Assus", comp.Manufacturer);
            Assert.AreEqual("ROG", comp.Model);
            Assert.AreEqual(2000, comp.Price);
            Assert.IsNotNull(cm);
        }
       
        [Test]
        public void AddComputerAlreadyExists()
        {
            cm.AddComputer(comp);

            Assert.Throws<ArgumentException>(() =>
            cm.AddComputer(comp));
        }
        [Test]
        public void AddCompNullExeption()
        {
            Assert.Throws<ArgumentNullException>(() => cm.AddComputer(null));
        }
        [Test]
        public void AddCompWorkCorrect()
        {
            cm.AddComputer(comp);

            Assert.AreEqual(1, cm.Count);
        }
        [Test]
        public void RemoveCompWorkCorrect()
        {
            Computer comp1 = new Computer("Dell", "Inspiron", 2000);
            cm.AddComputer(comp);
            cm.AddComputer(comp1);
            var result = cm.RemoveComputer("Assus", "ROG");

            Assert.AreEqual(result, comp);
            Assert.AreEqual(1, cm.Count);

        }

       

        [Test]
        public void GetCompNoCompWithThisManufacturer()
        {
            cm.AddComputer(comp);

            Assert.Throws<ArgumentException>(() => cm.GetComputer("ads", "ROG"));
        }
        [Test]
        public void GetCompWorkCorrect()
        {
            cm.AddComputer(comp);
            var result = cm.GetComputer("Assus", "ROG");
            Assert.AreEqual(comp, result);
        }
        [Test]
        public void GetComputerShouldThrowExceptionWithInvalidData()
        {
            cm.AddComputer(comp);
            Assert.Throws<ArgumentException>(() =>
            {
                cm.GetComputer(
                    "HP", "XC300");
            }, "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputerShouldThrowExceptionWithNullManufacturer()
        {
            Assert.Throws<ArgumentNullException>(() => { cm.GetComputer(null, "ROG"); });
        }

        [Test]
        public void GetComputerShouldThrowExceptionWithNullModel()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                cm.GetComputer("Assus", null);
            });
        }
       
        [Test]
        public void GetComputersByManufacturerNullExeption()
        {
            Computer comp1 = new Computer("Assus", "RG150", 2000);
            Computer comp2 = new Computer("Dell", "Inspiron", 2000);
            ComputerManager cm = new ComputerManager();
            cm.AddComputer(comp1);
            cm.AddComputer(comp2);

            Assert.Throws<ArgumentNullException>(() => cm.GetComputersByManufacturer(null));
        }
        
        [Test]
        public void GetComputersByManufacturerWorkCorrect()
        {
            Computer comp1 = new Computer("Assus", "ROG", 2000);
            Computer comp2 = new Computer("Lenovo", "Yoga", 2000);
            Computer comp3 = new Computer("Assus", "RG150", 2000);
            Computer comp4 = new Computer("Dell", "Inspiron", 2000);
            ComputerManager cm = new ComputerManager();
            cm.AddComputer(comp1);
            cm.AddComputer(comp2);
            cm.AddComputer(comp3);
            cm.AddComputer(comp4);
            ICollection<Computer> comps = new List<Computer>();
            comps.Add(comp1);
            comps.Add(comp3);

            var result = cm.GetComputersByManufacturer("Assus");

            CollectionAssert.AreEqual(comps, result);
            Assert.AreEqual(2, result.Count);

        }
        [Test]
        public void GetComputersByManufacturerZeroRezults()
        {
            Computer comp1 = new Computer("Assus", "ROG", 2000);
          
            ComputerManager cm = new ComputerManager();
            cm.AddComputer(comp1);
           
            ICollection<Computer> comps = new List<Computer>();
            comps.Add(comp1);
        
            var result = cm.GetComputersByManufacturer("Wdsa");

            Assert.AreEqual(0, result.Count);
        }
        [Test]
        public void ValidateNullValueWorcCorrect()
        {

            Assert.Throws<ArgumentNullException>(() =>
            cm.GetComputer(null, "ROG"));
            Assert.Throws<ArgumentNullException>(() =>
            cm.GetComputer("Assus", null));
        }

        // 80/100 judge
    }
}