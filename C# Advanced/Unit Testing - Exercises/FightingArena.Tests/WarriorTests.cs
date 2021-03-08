using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Illidan", 120, 1110)]
        [TestCase("Guldan", 140, 2210)]
        [TestCase("Aziro", 60, 0)]
        public void CtorWorkingCorectly(string name, int dps, int hp)
        {
            Warrior warr = new Warrior(name, dps, hp);

            Assert.AreEqual(name, warr.Name);
            Assert.AreEqual(dps, warr.Damage);
            Assert.AreEqual(hp, warr.HP);
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("   ")]
        [TestCase("")]
        public void NameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            new Warrior(name , 122, 1222));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]       
        public void DamageIsNegativeOrZero(int dps)
        {
            Assert.Throws<ArgumentException>(() => 
            new Warrior("Illidan", dps, 1222));
        }
        [Test]            
        [TestCase(-5)]      
        [TestCase(-1)]      
        public void HPIsLessThanZero(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            new Warrior("Illidan", 121, hp));
        }
        [Test]
        [TestCase(21)]      
        [TestCase(30)]
        public void AttackerHPLessThanMinimum(int hp)
        {
            Warrior warr = new Warrior("Illidan", 121, hp);
            Warrior warr1 = new Warrior("Guldan", 121, 200);

            Assert.Throws<InvalidOperationException>(() => warr.Attack(warr1));
       
            //May be more
        }
        [Test]
        [TestCase(21)]    
        [TestCase(30)]    
        public void DefenderHPLessThanMinimum(int hp)
        {
            Warrior warr = new Warrior("Illidan", 121, 200);
            Warrior warr1 = new Warrior("Guldan", 121, hp);

            Assert.Throws<InvalidOperationException>(() => warr.Attack(warr1));

            //May be more
        }

        [Test]
        [TestCase(67)]
        [TestCase(41)]
        [TestCase(50)]
        public void CantAttackStrongerEnemy(int dmg)
        {
            Warrior warr = new Warrior("Illidan", 10, 40);
            Warrior warr1 = new Warrior("Guldan", dmg, 40);

            Assert.Throws<InvalidOperationException>(() => warr.Attack(warr1));

            //May be more
        }
        [Test]      
        public void AttackWorksCorect()
        {
            Warrior warr1 = new Warrior("Illidan", 100, 200);
            Warrior warr2 = new Warrior("Guldan", 100, 300);           

            warr1.Attack(warr2);
           
            var expectedWarr1Hp = 100;
            var expectedWarr2Hp = 200;
            
            Assert.AreEqual(expectedWarr1Hp, warr1.HP);
            Assert.AreEqual(expectedWarr2Hp, warr2.HP);
            
           
        }

        [Test]
        [TestCase(50, 100)]
        [TestCase(100, 300)]
        public void AttackWorksCorectWithMoreDmg(int dmg, int hp)
        {
            Warrior warr1 = new Warrior("Illidan", dmg, hp);
            Warrior warr2 = new Warrior("Guldan", 10, 50);
            

            warr1.Attack(warr2);            
          
            var expectedWarr3Hp = 0;

            Assert.AreEqual(expectedWarr3Hp, warr2.HP);

        }
    }
}