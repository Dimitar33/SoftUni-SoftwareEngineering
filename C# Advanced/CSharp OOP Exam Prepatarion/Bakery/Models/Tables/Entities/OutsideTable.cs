using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables.Entities
{
    public class OutsideTable : Table
    {
        public OutsideTable(int tableNumber, int capacity ) : base(tableNumber, capacity)
        {
        }

        public override decimal PricePerPerson { get => 3.5m; }
    }
}
