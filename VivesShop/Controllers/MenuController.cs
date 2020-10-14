using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VivesShop.Core;
using VivesShop.Models;

namespace VivesShop.Controllers
{
    public class MenuController : Controller
    {
        private readonly IDatabase _database;
        public MenuController(IDatabase database)
        {
            _database = database;
        }

        public IActionResult Index()
        {
            
            var shopmodel = new OrderModel();
            var items = GetItems();
            var beingorderd = GetOrders();
            shopmodel.MenuItems = items;
            shopmodel.BeingOrdered = beingorderd;


            return View(shopmodel);
        }

        //Get (one)
        public MenuItem Get(int id)
        {
            return _database.Items
                .SingleOrDefault(p => p.Id == id);
        }
        public IList<BeingOrdered> GetOrders()
        {
            return _database.Orders;
        }
        public IList<MenuItem> GetItems()
        {
            return _database.Items;
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private int getItemId()
        {
            if (_database.Items.Count == null)
            {
                return 1;
            }
            else if (_database.Items.Any())
            {
                var getMaxId = _database.Items.Max(p => p.Id);
                return getMaxId += 1;
            }
            else
            {
                return 1;
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MenuItem item)
        {
            item.Id = getItemId();
            _database.Items.Add(item);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MenuItem item)
        {
            //Validation
            if (!IsValid(item))
            {
                return null;
            }

            var dbItem = Get(item.Id);

            if (dbItem == null)
            {
                return null;
            }

            dbItem.Name = item.Name;
            dbItem.Type = item.Type;
            dbItem.Price = item.Price;

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _database.Items.SingleOrDefault(p => p.Id == id);

            if (item == null)
            {
                return RedirectToAction("Index");
            }

            return View(item);
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
        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var dbItem = Get(id);

            if (dbItem == null)
            {
                return RedirectToAction("Index");
            }

            _database.Items.Remove(dbItem);

            return RedirectToAction("Index");
        }
        public IActionResult Toevoegen(int id)
        {
            /*var item = _database.Items.SingleOrDefault(a => a.Id == id);

            {
                //Frieten toevoegen
                new BeingOrdered { Id = getOrderId(), Name = item.Name, Price = item.Price, Type = item.Type };


            }
            */
            return RedirectToAction("Index");
        }
        
    }
}
