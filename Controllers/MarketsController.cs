using Assignment_P3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_P3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MarketsController : Controller
    {
        // GET: Markets
        private MyDBContext db = new MyDBContext();
        public ActionResult Index()
        {
            return View(db.Markets.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CreateAt,UpdatedAt,Status")] Market market)
        {
            var market1 = db.Markets.FirstOrDefault(m => m.Name == market.Name);
            if (market1 != null)
            {
                ModelState.AddModelError("Name", "Name exist. Please other name.");
                return View(market);
            }
            market.CreateAt = DateTime.Now;
            market.UpdatedAt = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Markets.Add(market);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(market);
        }


    }
}