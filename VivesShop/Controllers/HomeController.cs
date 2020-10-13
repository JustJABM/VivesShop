using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VivesShop.Core;
using VivesShop.Models;

namespace VivesShop.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IDatabase _database;
        public HomeController(IDatabase database)
        {
            _database = database;
        }


        

        public IActionResult Index()
        {
            var items = GetItems();
            
            return View(items);
        }

        private object GetBeingOrdered()
        {
            return _database.Orders;
        }

        public IList<BeingOrdered> GetOrders()
        {

            return new List<BeingOrdered>();
        }
        public IList<MenuItem> GetItems()
        {
            return _database.Items;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create(MenuItem item)
        {
            

            return RedirectToAction("Index");
        }
       

        private int getOrderId()
        {
            if (_database.Orders.Any())
            {
                var getMaxId = _database.Orders.Max(p => p.Id);
                return getMaxId += 1;
            }
            else
            {
                return 1;
            }
        }

        
    }
}
