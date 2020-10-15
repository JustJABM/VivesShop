using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VivesShop.Models
{
    public class OrderPrepared
    {
        public int Id { get; set; }
        public int OrderTotalId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }

        public DateTime OrderDate { get; set; }
        public string Status{ get; set; }
    }
}
