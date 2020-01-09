using Assignment_P3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Assignment_P3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CoinsController : Controller
    {
        // GET: Coins
       
        private MyDBContext db = new MyDBContext();

        public ActionResult Index()
        {
            var coins = db.Coins.Include(c => c.Market);
            return View(coins.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coin coin = db.Coins.Find(id);
            if (coin == null)
            {
                return HttpNotFound();
            }
            return View(coin);
        }

        // GET: Coins/Create
        public ActionResult Create()
        {
            ViewBag.MarketId = new SelectList(db.Markets, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,BaseAsset,QuoteAsset,LastPrice,Volumn24h,MarketId,CreateAt,UpdatedAt,Status")] Coin coin)
        {
            coin.Id = coin.BaseAsset + "_" + coin.QuoteAsset + "_" + coin.MarketId;
            coin.CreateAt = DateTime.Now;
            coin.UpdatedAt = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Coins.Add(coin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MarketId = new SelectList(db.Markets, "Id", "Name", coin.MarketId);
            return View(coin);
        }

    }
}