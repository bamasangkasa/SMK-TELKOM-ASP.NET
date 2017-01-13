using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DealerMobil.Models;

namespace DealerMobil.Controllers
{
    public class DealerController : Controller
    {
        private DealerDbCotext db = new DealerDbCotext();

        //
        // GET: /Dealer/

        public ActionResult Index(string searchNama,string searchMobil)
        {
            var dealers = db.Dealers.Include(d => d.Mobil);
            var dealer = new Dealer();

            if (!String.IsNullOrEmpty(searchNama))
            {
                dealers = dealers.Where(n => n.namadealer.Contains(searchNama));
            }

            ViewBag.searchMobil = new SelectList(db.Mobils, "namamobil", "namamobil", dealer.idmobil);

            if (!String.IsNullOrEmpty(searchMobil))
            {
                dealers = dealers.Where(n => n.Mobil.namamobil == searchMobil);
            }

            return View(dealers.ToList());
        }

        //
        // GET: /Dealer/Details/5

        public ActionResult Details(int id = 0)
        {
            Dealer dealer = db.Dealers.Find(id);
            if (dealer == null)
            {
                return HttpNotFound();
            }
            return View(dealer);
        }

        //
        // GET: /Dealer/Create

        public ActionResult Create()
        {
            ViewBag.idmobil = new SelectList(db.Mobils, "idmobil", "namamobil");
            return View();
        }

        //
        // POST: /Dealer/Create

        [HttpPost]
        public ActionResult Create(Dealer dealer)
        {
            if (ModelState.IsValid)
            {
                db.Dealers.Add(dealer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idmobil = new SelectList(db.Mobils, "idmobil", "namamobil", dealer.idmobil);
            return View(dealer);
        }

        //
        // GET: /Dealer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Dealer dealer = db.Dealers.Find(id);
            if (dealer == null)
            {
                return HttpNotFound();
            }
            ViewBag.idmobil = new SelectList(db.Mobils, "idmobil", "namamobil", dealer.idmobil);
            return View(dealer);
        }

        //
        // POST: /Dealer/Edit/5

        [HttpPost]
        public ActionResult Edit(Dealer dealer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dealer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idmobil = new SelectList(db.Mobils, "idmobil", "namamobil", dealer.idmobil);
            return View(dealer);
        }

        //
        // GET: /Dealer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Dealer dealer = db.Dealers.Find(id);
            if (dealer == null)
            {
                return HttpNotFound();
            }
            return View(dealer);
        }

        //
        // POST: /Dealer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Dealer dealer = db.Dealers.Find(id);
            db.Dealers.Remove(dealer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}