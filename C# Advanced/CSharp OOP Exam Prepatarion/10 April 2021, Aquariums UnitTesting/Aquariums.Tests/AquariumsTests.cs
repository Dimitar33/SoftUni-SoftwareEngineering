namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void NameIsNull(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, 22));
        }
        [Test]
        public void CapacityLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("ASd", -1));
        }
        [Test]
        public void AddFishAquariumFull()
        {
            var aquarium = new Aquarium("Aqua", 1);
            var fish1 = new Fish("Spot");
            var fish2 = new Fish("Fishey");

            aquarium.Add(fish1);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish2));
        }
        [Test]
        public void AddFishWorkCorect()
        {
            var aquarium = new Aquarium("Aqua", 1);
            var fish1 = new Fish("Spot");
          
            aquarium.Add(fish1);

            Assert.AreEqual(1, aquarium.Count);
        }
        [Test]
        public void RemoveFishDoesntExist()
        {
            var aquarium = new Aquarium("Aqua", 1);
            var fish1 = new Fish("Spot");

            aquarium.Add(fish1);

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Nofish"));
        }
        [Test]
        public void RemoveWorkCorrect()
        {
            var aquarium = new Aquarium("Aqua", 1);
            var fish1 = new Fish("Spot");

            aquarium.Add(fish1);
            aquarium.RemoveFish("Spot");
            Assert.AreEqual(0, aquarium.Count);
        }
        [Test]
        public void SellFishDoesntExist()
        {
            var aquarium = new Aquarium("Aqua", 1);
            var fish1 = new Fish("Spot");

            aquarium.Add(fish1);

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Nofish"));
        }
        [Test]
        public void SellFishWorkCorrect()
        {
            var aquarium = new Aquarium("Aqua", 1);
            var fish1 = new Fish("Spot");

            aquarium.Add(fish1);
            var result = aquarium.SellFish("Spot");

            Assert.AreEqual(result, fish1);
        }
        [Test]
        public void ReportWorkCorrect()
        {
            var aquarium = new Aquarium("Aqua", 1);
            var fish1 = new Fish("Spot");

            aquarium.Add(fish1);

            string report = aquarium.Report();
            string result = "Fish available at Aqua: Spot";

            Assert.AreEqual(report, result);
        }
      
    }
}
