using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Items
{
    public abstract class Bag : IBag
    {
        private List<Item> items;
        private int capacity = 100;
        private int load;
        public virtual int Capacity { get => capacity; set => capacity = value; }

        public int Load { get => load; set => load = value; }

        public IReadOnlyCollection<Item> Items => items;

        public void AddItem(Item item)
        {
            if (Load + item.Weight > items.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            Load += item.Weight;
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Any(c => c.GetType() == name ))
            {

            }
        }             
        
    }
}
