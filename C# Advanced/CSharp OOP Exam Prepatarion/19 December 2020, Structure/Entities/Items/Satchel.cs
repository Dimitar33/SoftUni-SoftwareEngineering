using System;
using System.Collections.Generic;
using System.Text;

namespace WarCroft.Entities.Items
{
    public class Satchel : Bag
    {
        public override int Capacity => 20;
        public override Item GetItem(string name)
        {
            throw new NotImplementedException();
        }
    }
}
