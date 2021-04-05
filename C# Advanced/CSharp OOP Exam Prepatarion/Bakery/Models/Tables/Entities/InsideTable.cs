using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables.Entities
{
    public class InsideTable : Table
    {
        public InsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity)
        {
        }

        public override decimal PricePerPerson { get => 2.5m; }
    }
}
