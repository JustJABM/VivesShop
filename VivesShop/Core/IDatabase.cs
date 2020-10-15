using System.Collections.Generic;
using VivesShop.Models;

namespace VivesShop.Core
{
    public interface IDatabase
    {
        IList<MenuItem> Items { get; set; }
        IList<BeingOrdered> Orders { get; set; }
        public IList<OrderPrepared> Prepareds { get; set; }

        void Initialize();
    }
}