using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    interface IAddRemoveCollection : IAddCollection
    {
        public abstract string Remove();
    }
}
