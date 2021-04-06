 using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void AddItemCellDoesnExist()
        {
            BankVault safe = new BankVault();
            Item item = new Item("Pesho", "gold");
            Assert.Throws<ArgumentException>(() => safe.AddItem("asd", item));
        }
        [Test]

        public void AddItemCellTaken()
        {
            BankVault safe = new BankVault();
            Item item = new Item("Pesho", "gold");
            safe.AddItem("A2", item);
            Assert.Throws<ArgumentException>(() => safe.AddItem("A2", item));
        }
        [Test]
        public void AddItemAlreadyInACell()
        {
            BankVault safe = new BankVault();
            Item item = new Item("Pesho", "gold");
            safe.AddItem("A2", item);
            Assert.Throws<InvalidOperationException>(() => safe.AddItem("A3", item));
        }
        [Test]
        public void AddItemWorkCorrect()
        {
            BankVault safe = new BankVault();
            Item item = new Item("Pesho", "gold");
            string result = safe.AddItem("A2", item);

            Assert.AreEqual(result, "Item:gold saved successfully!");
        }
        [Test]
        public void RemoveItemCellDoesntExist()
        {
            BankVault safe = new BankVault();
            Item item = new Item("Pesho", "gold");
            Assert.Throws<ArgumentException>(() => safe.RemoveItem("asd", item));
        }
        [Test]
        public void RemoveItemNotInThatCell()
        {
            BankVault safe = new BankVault();
            Item item = new Item("Pesho", "gold");
            safe.AddItem("A2", item);
            Assert.Throws<ArgumentException>(() => safe.RemoveItem("A3", item));
        }
        [Test]
        public void RemoveItemWorkCorrect()
        {
            BankVault safe = new BankVault();
            Item item = new Item("Pesho", "gold");
            safe.AddItem("A2", item);
            string result = safe.RemoveItem("A2", item);

            Assert.AreEqual(result, "Remove item:gold successfully!");
        }
    }
}