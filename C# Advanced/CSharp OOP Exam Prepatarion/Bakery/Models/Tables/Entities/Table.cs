using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Drinks.Entities;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables.Entities
{
    public abstract class Table : ITable
    {
        private int capacity;

        private int numberOfPeople;

        public Table(int tableNumber, int capacity)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
          
        }

        public List<IBakedFood> FoodOrders { get; set; }
        public List<IDrink> DrinkOrders { get; set; }
        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                numberOfPeople = value;
            }
        }

        public virtual decimal PricePerPerson { get;  }

        public bool IsReserved { get; private set; }

        public decimal Price => PricePerPerson * NumberOfPeople;

        public void Clear()
        {
            DrinkOrders.Clear();
            FoodOrders.Clear();
            numberOfPeople = 0;
            IsReserved = false;
        }

        public decimal GetBill()
        {
            return DrinkOrders.Sum(x => x.Price) + FoodOrders.Sum(x => x.Price) + Price;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Price per Person: {PricePerPerson}");

            return sb.ToString().Trim();
        }

        public void OrderDrink(IDrink drink)
        {
            DrinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            FoodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            NumberOfPeople = numberOfPeople;
        }
    }
}
