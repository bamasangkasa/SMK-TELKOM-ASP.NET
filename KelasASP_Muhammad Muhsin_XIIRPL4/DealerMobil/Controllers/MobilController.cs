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
    public class MobilController : Controller
    {
        private DealerDbCotext db = new DealerDbCotext();

        //
        // GET: /Mobil/

        public ActionResult Index(string searchMerk)
        {
            var mobils = from s in db.Mobils select s;

            if (!String.IsNullOrEmpty(searchMerk))
            {
                mobils = mobils.Where(d => d.merkmobil == searchMerk);
            }

            return View(mobils.ToList());
        }

        //
        // GET: /Mobil/Details/5

        public ActionResult Details(int id = 0)
        {
            Mobil mobil = db.Mobils.Find(id);
            if (mobil == null)
            {
                return HttpNotFound();
            }
            return View(mobil);
        }

        //
        // GET: /Mobil/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Mobil/Create

        [HttpPost]
        public ActionResult Create(Mobil mobil)
        {
            if (ModelState.IsValid)
            {
                db.Mobils.Add(mobil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mobil);
        }

        //
        // GET: /Mobil/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Mobil mobil = db.Mobils.Find(id);
            if (mobil == null)
            {
                return HttpNotFound();
            }
            return View(mobil);
        }

        //
        // POST: /Mobil/Edit/5

        [HttpPost]
        public ActionResult Edit(Mobil mobil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mobil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mobil);
        }

        //
        // GET: /Mobil/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Mobil mobil = db.Mobils.Find(id);
            if (mobil == null)
            {
                return HttpNotFound();
            }
            return View(mobil);
        }

        //
        // POST: /Mobil/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Mobil mobil = db.Mobils.Find(id);
            db.Mobils.Remove(mobil);
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