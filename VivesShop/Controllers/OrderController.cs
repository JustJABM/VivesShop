using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VivesShop.Core;
using VivesShop.Models;

namespace VivesShop.Controllers
{
    public class OrderController : Controller
    {
        public decimal dTotaalPrijs = 0.00m; 
        private readonly IDatabase _database;
        
        public PreparedModel PreparedModel = new PreparedModel();
        public OrderController(IDatabase database)
        { 
            _database = database;
        }
        public IActionResult Index()
        {
            var shopmodel = new PreparedModel();
            

            var beingorderd = GetOrders();
            var prepareds = GetPrepareds();

            shopmodel.BeingOrdered = beingorderd;

            return View(shopmodel);
        }
        public IList<BeingOrdered> GetOrders()
        {
            return _database.Orders;
        }
        public IList<OrderPrepared> GetPrepareds()
        {
            return _database.Prepareds;
        }
        public OrderPrepared GetPrepare(int id)
        {
            return _database.Prepareds
                .SingleOrDefault(p => p.Id == id);
        }
        public BeingOrdered GetOrder(int id)
        {
            return _database.Orders
                .SingleOrDefault(p => p.Id ==  id);
        }
        
       
        public IActionResult CreatePrepare(List<BeingOrdered> prepared)
        {
            var dbOrder = GetOrder(1);
            var dbPrepare = new OrderPrepared();
            var PreparedId = GetorderTotalId();

            dbPrepare.Id = GetPreparedId();
            dbPrepare.OrderTotalId = PreparedId;
            dbPrepare.Name = dbOrder.Name;
            dbPrepare.Type = dbOrder.Type;
            dbPrepare.Price = dbOrder.Price;
            dbPrepare.OrderDate = DateTime.Now.Date;
            dbPrepare.Status = "Not Prepared";

            _database.Prepareds.Add(dbPrepare);
            

            return RedirectToPage("Index", "Home");
        }

        private int GetorderTotalId()
        {
            var count = _database.Prepareds == null ? 0 : _database.Prepareds.Count();
            var getOrderTotalId = 1;
            if (count > 0)
            {
                getOrderTotalId = _database.Prepareds.Max(p => p.Id);
                getOrderTotalId += 1;
            }

            return getOrderTotalId;
        }
        private int GetPreparedId()
        {
            var count = _database.Prepareds == null ? 0 : _database.Prepareds.Count();
            var getOrderTotalId = 1;
            if (count > 0)
            {
                getOrderTotalId = _database.Prepareds.Max(p => p.Id);
                getOrderTotalId += 1;
            }

            return getOrderTotalId;
        }
    }
}
