using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VivesShop.Models
{
    public class OrderModel 
    {
        public IList<BeingOrdered> BeingOrdered;

        public IList<MenuItem> MenuItems;
        
    }
}
