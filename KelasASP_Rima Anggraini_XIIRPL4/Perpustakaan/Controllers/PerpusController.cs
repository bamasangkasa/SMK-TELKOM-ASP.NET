using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Perpustakaan.Models;

namespace Perpustakaan.Controllers
{
    public class PerpusController : Controller
    {
        private PerpustakaanDbContext db = new PerpustakaanDbContext();

        //
        // GET: /Perpus/

        public ActionResult Index(String SearchName)
        {

            var perpustakaans = db.Pinjam.Include(p => p.Buku);
            
            if (!string.IsNullOrEmpty(SearchName))
            {
                perpustakaans = perpustakaans.Where(a => a.Nama_Peminjam.Contains(SearchName));
            }

           
            return View(perpustakaans.ToList());
        }

        //
        // GET: /Perpus/Details/5

        public ActionResult Details(int id = 0)
        {
            Peminjaman perpustakaan = db.Pinjam.Find(id);
            if (perpustakaan == null)
            {
                return HttpNotFound();
            }
            return View(perpustakaan);
        }

        //
        // GET: /Perpus/Create

        public ActionResult Create()
        {
            ViewBag.Id_Buku = new SelectList(db.Bukus, "Id_Buku", "Nama_Buku");
            return View();
        }

        //
        // POST: /Perpus/Create

        [HttpPost]
        public ActionResult Create(Peminjaman perpustakaan)
        {
            if (ModelState.IsValid)
            {
                db.Pinjam.Add(perpustakaan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Buku = new SelectList(db.Bukus, "Id_Buku", "Nama_Buku", perpustakaan.Id_Buku);
            return View(perpustakaan);
        }

        //
        // GET: /Perpus/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Peminjaman perpustakaan = db.Pinjam.Find(id);
            if (perpustakaan == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Buku = new SelectList(db.Bukus, "Id_Buku", "Nama_Buku", perpustakaan.Id_Buku);
            return View(perpustakaan);
        }

        //
        // POST: /Perpus/Edit/5

        [HttpPost]
        public ActionResult Edit(Peminjaman perpustakaan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perpustakaan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Buku = new SelectList(db.Bukus, "Id_Buku", "Nama_Buku", perpustakaan.Id_Buku);
            return View(perpustakaan);
        }

        //
        // GET: /Perpus/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Peminjaman perpustakaan = db.Pinjam.Find(id);
            if (perpustakaan == null)
            {
                return HttpNotFound();
            }
            return View(perpustakaan);
        }

        //
        // POST: /Perpus/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Peminjaman perpustakaan = db.Pinjam.Find(id);
            db.Pinjam.Remove(perpustakaan);
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