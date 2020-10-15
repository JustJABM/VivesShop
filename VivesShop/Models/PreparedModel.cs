using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VivesShop.Models
{
    public class PreparedModel
    {
        public IList<BeingOrdered> BeingOrdered;

        public IList<OrderPrepared> BeingPrepared;

        public decimal dTotaalPrijs = 0.00m;

    }
}
