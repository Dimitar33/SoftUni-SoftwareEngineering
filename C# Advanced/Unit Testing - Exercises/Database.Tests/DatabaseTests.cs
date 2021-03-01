using NUnit.Framework;
using System;
using System.Linq;


    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void arrayCapacityMustBeExactly16Integers()
        {
            int[] nums = Enumerable.Range(1, 16).ToArray();

            Database data = new Database(nums);

            var expectedResult = 16;
            var actualResult = data.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddOperationShouldAddElementAtNextFreeCell()
        {
            int[] nums = Enumerable.Range(1, 11).ToArray();

            Database data = new Database(nums);

            data.Add(5);

            int expectedResult = 5;
            var array = data.Fetch();
            int actualResult = array[11];

            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void RemoveEllementAtLastIndex()
        {
            //Arrange
            int[] nums = Enumerable.Range(1, 10).ToArray();

            Database data = new Database(nums);

            //Act
            data.Remove();

            int expectedResult = 9;

            int actualResult = data.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void SizeOfTheArrayTooLong()
        {
            int[] nums = Enumerable.Range(1, 16).ToArray();
            Database data = new Database(nums);

            Assert.Throws<InvalidOperationException>(() => data.Add(12));
        }

        [Test]

        public void removeRlementFromEmptDatabase()
        {
            Database data = new Database();

            Assert.Throws<InvalidOperationException>(() => data.Remove());
        }

        [Test]
        public void FetchMethodShouldReturnElementsAsArray()
        {
            //Arrange
            int[] nums = Enumerable.Range(1, 3).ToArray();
            Database data = new Database(nums);

            //Act

            var expected = new int[]{ 1, 2, 3};
            var actual = data.Fetch();

            //Assert

            Assert.AreEqual(expected, actual);
        }
    }
