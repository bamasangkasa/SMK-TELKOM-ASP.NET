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
    public class PemesananController : Controller
    {
        private BookingHotelDbContext db = new BookingHotelDbContext();

        //
        // GET: /Pemesanan/

        public ActionResult Index()
        {
            var pesanan = db.Pesanan.Include(p => p.Kamar);
            return View(pesanan.ToList());
        }

        //
        // GET: /Pemesanan/Details/5

        public ActionResult Details(int id = 0)
        {
            Pemesanan pemesanan = db.Pesanan.Find(id);
            if (pemesanan == null)
            {
                return HttpNotFound();
            }
            return View(pemesanan);
        }

        //
        // GET: /Pemesanan/Create

        public ActionResult Create()
        {
            ViewBag.IDJenisKamar = new SelectList(db.Kamars, "IDJenisKamar", "NamaKamar");
            return View();
        }

        //
        // POST: /Pemesanan/Create

        [HttpPost]
        public ActionResult Create(Pemesanan pemesanan)
        {
            if (ModelState.IsValid)
            {
                db.Pesanan.Add(pemesanan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDJenisKamar = new SelectList(db.Kamars, "IDJenisKamar", "NamaKamar", pemesanan.IDJenisKamar);
            return View(pemesanan);
        }

        //
        // GET: /Pemesanan/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Pemesanan pemesanan = db.Pesanan.Find(id);
            if (pemesanan == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDJenisKamar = new SelectList(db.Kamars, "IDJenisKamar", "NamaKamar", pemesanan.IDJenisKamar);
            return View(pemesanan);
        }

        //
        // POST: /Pemesanan/Edit/5

        [HttpPost]
        public ActionResult Edit(Pemesanan pemesanan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pemesanan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDJenisKamar = new SelectList(db.Kamars, "IDJenisKamar", "NamaKamar", pemesanan.IDJenisKamar);
            return View(pemesanan);
        }

        //
        // GET: /Pemesanan/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pemesanan pemesanan = db.Pesanan.Find(id);
            if (pemesanan == null)
            {
                return HttpNotFound();
            }
            return View(pemesanan);
        }

        //
        // POST: /Pemesanan/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Pemesanan pemesanan = db.Pesanan.Find(id);
            db.Pesanan.Remove(pemesanan);
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