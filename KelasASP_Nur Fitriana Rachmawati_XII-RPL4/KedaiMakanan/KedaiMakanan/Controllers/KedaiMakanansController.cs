using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KedaiMakanan.Models;

namespace KedaiMakanan.Controllers
{
    public class KedaiMakanansController : Controller
    {
        private KedaiMakananDbContext db = new KedaiMakananDbContext();

        // GET: KedaiMakanans
        public ActionResult Index(string searchPelanggan)
        {
            var kedaiMakanan = from s in db.KedaiMakanan
                               select s;
            if(!String.IsNullOrEmpty(searchPelanggan))
            {
                kedaiMakanan = kedaiMakanan.Where(d => d.NamaMenu == searchPelanggan);
            }
            return View(kedaiMakanan.ToList());
        }

        // GET: KedaiMakanans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu kedaiMakanan = db.KedaiMakanan.Find(id);
            if (kedaiMakanan == null)
            {
                return HttpNotFound();
            }
            return View(kedaiMakanan);
        }

        // GET: KedaiMakanans/Create
        public ActionResult Create()
        {
            ViewBag.MenuID = new SelectList(db.KedaiMakanan, "MenuID", "NamaMenu");
            return View();
        }

        // POST: KedaiMakanans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PelangganID,NamaPelaggan,MenuMakanan,TanggalPembelian,MenuID")] Menu kedaiMakanan)
        {
            if (ModelState.IsValid)
            {
                db.MenuMakanan.Add(KedaiMakanan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MenuID = new SelectList(db.KedaiMakanan, "MenuID", "NamaMenu", kedaiMakanan.MenuID);
            return View(kedaiMakanan);
        }

        // GET: KedaiMakanans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu kedaiMakanan = db.KedaiMakanan.Find(id);
            if (kedaiMakanan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuID = new SelectList(db.KedaiMakanan, "MenuID", "NamaMenu", kedaiMakanan.MenuID);
            return View(kedaiMakanan);
        }

        // POST: KedaiMakanans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PelangganID,NamaPelaggan,MenuMakanan,TanggalPembelian,MenuID")] Menu kedaiMakanan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kedaiMakanan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuID = new SelectList(db.KedaiMakanan, "MenuID", "NamaMenu", kedaiMakanan.MenuID);
            return View(kedaiMakanan);
        }

        // GET: KedaiMakanans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu kedaiMakanan = db.KedaiMakanan.Find(id);
            if (kedaiMakanan == null)
            {
                return HttpNotFound();
            }
            return View(kedaiMakanan);
        }

        // POST: KedaiMakanans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menu kedaiMakanan = db.KedaiMakanan.Find(id);
            db.MenuMakanan.Remove(KedaiMakanan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
