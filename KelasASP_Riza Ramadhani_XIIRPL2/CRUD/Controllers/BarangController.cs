using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class BarangController : Controller
    {
        private MyCompanyDBContext db = new MyCompanyDBContext();

        //
        // GET: /Barang/

        public ActionResult Index(string searchName, string searchKasir)
        {
            var barang = db.Barang.Include(b => b.Kasir);
            var barang1 = new Barang();

            if (!String.IsNullOrEmpty(searchName))
            {
                barang = barang.Where(n => n.NamaBarang.Contains(searchName));
            }

            ViewBag.searchKasir = new SelectList(db.Kasir, "NamaKasir", "NamaKasir", barang1.IDBarang);

            if (!String.IsNullOrEmpty(searchKasir))
            {
                barang = barang.Where(m => m.Kasir.NamaKasir == searchKasir);
            }

            return View(barang.ToList());
        }

        //
        // GET: /Barang/Details/5

        public ActionResult Details(int id = 0)
        {
            Barang barang = db.Barang.Find(id);
            if (barang == null)
            {
                return HttpNotFound();
            }
            return View(barang);
        }

        //
        // GET: /Barang/Create

        public ActionResult Create()
        {
            ViewBag.IDKasir = new SelectList(db.Kasir, "IDKasir", "NamaKasir");
            return View();
        }

        //
        // POST: /Barang/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Barang barang)
        {
            if (ModelState.IsValid)
            {
                db.Barang.Add(barang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDKasir = new SelectList(db.Kasir, "IDKasir", "NamaKasir", barang.IDKasir);
            return View(barang);
        }

        //
        // GET: /Barang/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Barang barang = db.Barang.Find(id);
            if (barang == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDKasir = new SelectList(db.Kasir, "IDKasir", "NamaKasir", barang.IDKasir);
            return View(barang);
        }

        //
        // POST: /Barang/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Barang barang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDKasir = new SelectList(db.Kasir, "IDKasir", "NamaKasir", barang.IDKasir);
            return View(barang);
        }

        //
        // GET: /Barang/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Barang barang = db.Barang.Find(id);
            if (barang == null)
            {
                return HttpNotFound();
            }
            return View(barang);
        }

        //
        // POST: /Barang/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barang barang = db.Barang.Find(id);
            db.Barang.Remove(barang);
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