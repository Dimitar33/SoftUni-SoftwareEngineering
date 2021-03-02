
using ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Linq;




public class ExtendedDatabaseTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void arrayCapacityMustBeExactly16Integers()
    {
        Person[] people = new Person[16];

        ExtendedDatabase.ExtendedDatabase data = new ExtendedDatabase.ExtendedDatabase(people);

        var expectedResult = 16;
        var actualResult = data.Count;

        Assert.AreEqual(expectedResult, actualResult);
    }

    //[Test]
    //public void AddOperationShouldAddElementAtNextFreeCell()
    //{
    //    int[] nums = Enumerable.Range(1, 11).ToArray();

    //    Database data = new Database(nums);

    //    data.Add(5);

    //    int expectedResult = 5;
    //    var array = data.Fetch();
    //    int actualResult = array[11];

    //    Assert.AreEqual(expectedResult, actualResult);

    //}

    [Test]
    public void RemoveEllementAtLastIndex()
    {
        //Arrange
        Person person1 = new Person(12, "A");
        Person person2 = new Person(13, "B");

        ExtendedDatabase.ExtendedDatabase data = new ExtendedDatabase.ExtendedDatabase(person1, person2);

        //Act
        data.Remove();

        int expectedResult = 1;

        int actualResult = data.Count;

        //Assert
        Assert.AreEqual(expectedResult, actualResult);

    }

    [Test]
    public void SizeOfTheArrayTooLong()
    {
        Person[] people = new Person[17];


        Assert.Throws<ArgumentException>(() => new ExtendedDatabase.ExtendedDatabase(people));
    }

    [Test]
    public void RemovelementFromEmptDatabase()
    {
        ExtendedDatabase.ExtendedDatabase data = new ExtendedDatabase.ExtendedDatabase();

        Assert.Throws<InvalidOperationException>(() => data.Remove());
    }



    [Test]
    public void AddTheSameUserNameError()
    {
        Person person = new Person(123, "Pesho");
        Person person1 = new Person(1223, "Pesho");

        ExtendedDatabase.ExtendedDatabase data = new ExtendedDatabase.ExtendedDatabase(person);

        Assert.Throws<InvalidOperationException>(() => data.Add(person1));
    }
    [Test]
    public void AddTheSameUserIdError()
    {
        Person person = new Person(123, "Pesho");
        Person person1 = new Person(123, "Gosho");

        ExtendedDatabase.ExtendedDatabase data = new ExtendedDatabase.ExtendedDatabase(person);

        Assert.Throws<InvalidOperationException>(() => data.Add(person1));
    }
    [Test]
    public void FindByUsernameIfNoSuchUser()
    {
        Person person = new Person(123, "Pesho");

        ExtendedDatabase.ExtendedDatabase data = new ExtendedDatabase.ExtendedDatabase(person);

        Assert.Throws<InvalidOperationException>(() => data.FindByUsername("Gosho"));
    }
    [Test]
    public void FindByUsernameIfParameterIsNull()
    {
        Person person = new Person(123, "Pesho");

        ExtendedDatabase.ExtendedDatabase data = new ExtendedDatabase.ExtendedDatabase(person);

        Assert.Throws<ArgumentNullException>(() => data.FindByUsername(null));
    }
    [Test]
    public void FindByIdIfNoUserPresent()
    {
        Person person = new Person(123, "Pesho");

        ExtendedDatabase.ExtendedDatabase data = new ExtendedDatabase.ExtendedDatabase(person);

        Assert.Throws<InvalidOperationException>(() => data.FindById(222));
    }

    [Test]
    public void FindByIdIfNegativeInput()
    {
        Person person = new Person(123, "Pesho");

        ExtendedDatabase.ExtendedDatabase data = new ExtendedDatabase.ExtendedDatabase(person);

        Assert.Throws<ArgumentOutOfRangeException>(() => data.FindById(-21));
    }

    [Test]
    public void AddNewPersonCorectly()
    {
        Person person = new Person(123, "Pesho");

        ExtendedDatabase.ExtendedDatabase data = new ExtendedDatabase.ExtendedDatabase();

        data.Add(person);

        var expected = 1;
        var actual = data.Count;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void AddErrorIfMoreThanCapacityAdded()
    {
        Person person1 = new Person(1223, "Peesho");
        Person person2 = new Person(1232, "Peswho");
        Person person3 = new Person(1223, "Pesho");
        Person person4 = new Person(123, "Peshqo");
        Person person5 = new Person(12213, "Peasho");
        Person person6 = new Person(12123, "Peaasho");
        Person person7 = new Person(12313, "Pefdsho");
        Person person8 = new Person(12333, "Pedssho");
        Person person9 = new Person(1234, "Pesgfho");
        Person person10 = new Person(12433, "Pehgsho");
        Person person11 = new Person(12653, "Peddsho");
        Person person12 = new Person(12763, "Pesjho");
        Person person13 = new Person(12843, "Pesytho");
        Person person14 = new Person(12443, "Pestyho");
        Person person15 = new Person(124773, "Peuisho");
        Person person16 = new Person(123546, "Pesopho");

        ExtendedDatabase.ExtendedDatabase data = new ExtendedDatabase.ExtendedDatabase();

        data.Add(person1);

        var expected = person;
        var actual = data[0];

        Assert.AreEqual(expected, actual);
    }
}
