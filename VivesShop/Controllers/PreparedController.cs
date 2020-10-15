using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VivesShop.Core;
using VivesShop.Models;

namespace VivesShop.Controllers
{
    public class PreparedController : Controller
    {
        private readonly IDatabase _database;
        public PreparedModel PreparedModel = new PreparedModel();
        public PreparedController(IDatabase database)
        {
            _database = database;

        }

        public IActionResult Index()
        {
            var preparedModel = new PreparedModel();
            var prepareds = GetPrepareds();
            
            preparedModel.BeingPrepared = prepareds;


            return View(preparedModel);
        }

        public IList<OrderPrepared> GetPrepareds()
        {
            return _database.Prepareds;
        }
        public OrderPrepared Get(int id)
        {
            return _database.Prepareds
                .SingleOrDefault(p => p.Id == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OrderPrepared prepared)
        {
            //Validation
            if (!IsValid(prepared))
            {
                return null;
            }

            var dbItem = Get(prepared.Id);

            if (dbItem == null)
            {
                return null;
            }


            dbItem.Status = "Done";
            

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var prepared = _database.Prepareds.SingleOrDefault(p => p.Id == id);

            if (prepared == null)
            {
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        private bool IsValid(OrderPrepared prepared)
        {
            if (prepared == null)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(prepared.Name))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(prepared.Type))
            {
                return false;
            }

            return true;
        }
    }
}
