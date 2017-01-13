using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingHotel.Models;

namespace BookingHotel.Controllers
{
    public class KamarController : Controller
    {
        private BookingHotelDbContext db = new BookingHotelDbContext();

        //
        // GET: /Kamar/

        public ActionResult Index()
        {
            return View(db.Kamars.ToList());
        }

        //
        // GET: /Kamar/Details/5

        public ActionResult Details(string id = null)
        {
            Kamar kamar = db.Kamars.Find(id);
            if (kamar == null)
            {
                return HttpNotFound();
            }
            return View(kamar);
        }

        //
        // GET: /Kamar/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Kamar/Create

        [HttpPost]
        public ActionResult Create(Kamar kamar)
        {
            if (ModelState.IsValid)
            {
                db.Kamars.Add(kamar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kamar);
        }

        //
        // GET: /Kamar/Edit/5

        public ActionResult Edit(string id = null)
        {
            Kamar kamar = db.Kamars.Find(id);
            if (kamar == null)
            {
                return HttpNotFound();
            }
            return View(kamar);
        }

        //
        // POST: /Kamar/Edit/5

        [HttpPost]
        public ActionResult Edit(Kamar kamar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kamar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kamar);
        }

        //
        // GET: /Kamar/Delete/5

        public ActionResult Delete(string id = null)
        {
            Kamar kamar = db.Kamars.Find(id);
            if (kamar == null)
            {
                return HttpNotFound();
            }
            return View(kamar);
        }

        //
        // POST: /Kamar/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            Kamar kamar = db.Kamars.Find(id);
            db.Kamars.Remove(kamar);
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