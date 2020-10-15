using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VivesShop.Models;

namespace VivesShop.Core
{
    public class Database : IDatabase
    {
        public Database()
        {
            
            Items = new List<MenuItem>();
            BeingOrdereds = new List<BeingOrdered>(); 
            Prepareds = new List<OrderPrepared>();
            Orders=new List<BeingOrdered>();
           
        }

        public IList<MenuItem> Items { get; set; }
        public IList<BeingOrdered> Orders { get; set; }
        public IList<OrderPrepared> Prepareds { get; set; }

        public IList<BeingOrdered> BeingOrdereds { get; set; }
        

        public void Initialize()
        {
            Items = new List<MenuItem>
            {
                //Frieten toevoegen
                new MenuItem{Id = 1, Name = "kleine friet", Price = 2.50m, Type = "Friet"},
                new MenuItem{Id = 2, Name = "middel friet", Price = 3.50m, Type = "Friet"},
                new MenuItem{Id = 3, Name = "grote friet", Price = 4.00m, Type = "Friet"},
                //Snacks toevoegen
                new MenuItem{Id = 4, Name = "Mexicano", Price = 3.50m, Type = "Snack"},
                new MenuItem{Id = 5, Name = "Frikandel", Price = 4.00m, Type = "Snack"},
                new MenuItem{Id = 6, Name = "Frikandel Special", Price = 4.50m, Type = "Snack"},
                //Burger
                new MenuItem{Id = 7, Name = "Bickey", Price = 4.50m, Type = "Burger"},
                new MenuItem{Id = 8, Name = "Bickey Bacon", Price = 5.00m, Type = "Burger"},
                new MenuItem{Id = 9, Name = "Cheese", Price = 3.50m, Type = "Burger"},
                //Saus
                new MenuItem{Id = 10, Name = "Mayo", Price = 4.50m, Type = "Saus"},
                new MenuItem{Id = 11, Name = "Ketchup", Price = 5.00m, Type = "Saus"},
                new MenuItem{Id = 12, Name = "Stoofvlees", Price = 3.50m, Type = "Saus"},
                //Drank
                new MenuItem{Id = 13, Name = "cola", Price = 2.50m, Type = "Drank"},
                new MenuItem{Id = 14, Name = "Fanta", Price = 2.50m, Type = "Drank"},
                new MenuItem{Id = 15, Name = "Stella", Price = 2.00m, Type = "Drank"},
            };
            Prepareds = new List<OrderPrepared>
            {
                //Frieten toevoegen
                new OrderPrepared{Id = 1, OrderTotalId = 1, Name = "TestOrder", OrderDate = DateTime.Now.Date, Status = "Done", Price = 2.50m, Type = "Friet"}
            };
        }
    }
        
}

