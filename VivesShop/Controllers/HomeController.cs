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

        public OrderModel shopmodel = new OrderModel();
        private readonly IDatabase _database;
        public HomeController(IDatabase database)
        {
            _database = database;
            
        }

        public IActionResult Index()
        {

            
            var items = GetItems();
            var beingorderd = GetOrders();
            shopmodel.MenuItems = items;
            
            
            shopmodel.BeingOrdered = beingorderd;

            
            return View(shopmodel);
        }


        public IList<BeingOrdered> GetOrders()
        {
            return _database.Orders;
        }
        public IList<MenuItem> GetItems()
        {
            return _database.Items;
        }
        
        public MenuItem GetMenu(int id)
        {
            return _database.Items
                .SingleOrDefault(p => p.Id == id);
        }
        public  BeingOrdered GetOrder(int id)
        {
            return _database.Orders
                .SingleOrDefault(p => p.Id == id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
        public IActionResult Toevoegen(int id)
        {
            //Validation
            

            var dbItem = GetMenu(id);
            var dbOrder = new BeingOrdered();
            shopmodel.dTotaalPrijs += dbOrder.Price;

            dbOrder.Id = getOrderId();
            dbOrder.Name = dbItem.Name;
            dbOrder.Type = dbItem.Type;
            dbOrder.Price = dbItem.Price;

            _database.Orders.Add(dbOrder);

            return RedirectToAction("Index");

        }


        private int getOrderId()
        {
            var count = _database.Orders == null ? 0 : _database.Orders.Count();
            var getMaxId = 1;
            if (count > 0)
            {
                getMaxId = _database.Orders.Max(p => p.Id);
                getMaxId += 1;
            }

            return getMaxId;
        }

        

        private bool IsValid(MenuItem item)
        {
            if (item == null)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(item.Name))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(item.Type))
            {
                return false;
            }

            return true;
        }


        public IActionResult DeleteOrder(int id)
        {
            var dbOrder = GetOrder(id);
            shopmodel.dTotaalPrijs -= dbOrder.Price;
            if (dbOrder == null)
            {
                return RedirectToAction("Index");
            }

            _database.Orders.Remove(dbOrder);

            return RedirectToAction("Index");
        }


        
    }
}
