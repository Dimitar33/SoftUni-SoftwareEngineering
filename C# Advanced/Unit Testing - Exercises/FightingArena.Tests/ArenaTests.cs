//using FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CtorWorkCorect()
        {          
            Arena arena = new Arena();

            var list = new List<Warrior>();

            CollectionAssert.AreEqual(list, arena.Warriors);
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void EnrollWarriorAlreadyEnroled()
        {
            Warrior warr = new Warrior("Illidan", 100, 200);           

            Arena arena = new Arena();
            arena.Enroll(warr);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warr));
        }

        [Test]
        public void EnrollWorkCorect()
        {
            Warrior warr = new Warrior("Illidan", 100, 200);
            Warrior warr2 = new Warrior("Guldan", 100, 300);

            Arena arena = new Arena();
            arena.Enroll(warr);
            arena.Enroll(warr2);

            var list = new List<Warrior>{warr, warr2};

            CollectionAssert.AreEqual(list, arena.Warriors);
            Assert.AreEqual(2, arena.Count);
        }

        [Test]
        public void FightMissingFigterError()
        {
            Warrior warr = new Warrior("Illidan", 100, 200);
            Warrior warr2 = new Warrior("Guldan", 100, 300);

            Arena arena = new Arena();
            arena.Enroll(warr);
         
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Illidan", "Guldan"));
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Guldan", "Illidan"));
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Ivan", "Gosho"));
         
        }

        [Test]
        public void FightkWorkCorect()
        {
            Warrior warr = new Warrior("Illidan", 100, 200);
            Warrior warr2 = new Warrior("Guldan", 100, 300);

            Arena arena = new Arena();
            arena.Enroll(warr);
            arena.Enroll(warr2);

            arena.Fight("Illidan", "Guldan");

            Assert.AreEqual(100, warr.HP);
            Assert.AreEqual(200, warr2.HP);
        }
    }
}
