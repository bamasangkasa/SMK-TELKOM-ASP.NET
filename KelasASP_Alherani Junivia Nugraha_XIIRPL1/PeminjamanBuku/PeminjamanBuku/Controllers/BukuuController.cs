using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PeminjamanBuku.Models;

namespace PeminjamanBuku.Controllers
{
    public class BukuuController : Controller
    {
        private PeminjamanBukuDbContext db = new PeminjamanBukuDbContext();

        //
        // GET: /Bukuu/

        public ActionResult Index(string searchName, string searchAnggota)
        {
            var bukuu = db.Bukuu.Include(b => b.Anggota);
            var buku = new Buku();

            if (!String.IsNullOrEmpty(searchName))
            {
                bukuu = bukuu.Where(n => n.Judul.Contains(searchName));
            }

            ViewBag.searchAnggota = new SelectList(db.Anggotaa, "NamaAnggota", "NamaAnggota", buku.NoAnggota);
            if (!String.IsNullOrEmpty(searchAnggota))
            {
                bukuu = bukuu.Where(d => d.Anggota.NamaAnggota == searchAnggota);
            }
            return View(bukuu.ToList());
        }

        //
        // GET: /Bukuu/Details/5

        public ActionResult Details(int id = 0)
        {
            Buku buku = db.Bukuu.Find(id);
            if (buku == null)
            {
                return HttpNotFound();
            }
            return View(buku);
        }

        //
        // GET: /Bukuu/Create

        public ActionResult Create()
        {
            ViewBag.NoAnggota = new SelectList(db.Anggotaa, "NoAnggota", "NamaAnggota");
            return View();
        }

        //
        // POST: /Bukuu/Create

        [HttpPost]
        public ActionResult Create(Buku buku)
        {
            if (ModelState.IsValid)
            {
                db.Bukuu.Add(buku);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NoAnggota = new SelectList(db.Anggotaa, "NoAnggota", "NamaAnggota", buku.NoAnggota);
            return View(buku);
        }

        //
        // GET: /Bukuu/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Buku buku = db.Bukuu.Find(id);
            if (buku == null)
            {
                return HttpNotFound();
            }
            ViewBag.NoAnggota = new SelectList(db.Anggotaa, "NoAnggota", "NamaAnggota", buku.NoAnggota);
            return View(buku);
        }

        //
        // POST: /Bukuu/Edit/5

        [HttpPost]
        public ActionResult Edit(Buku buku)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buku).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NoAnggota = new SelectList(db.Anggotaa, "NoAnggota", "NamaAnggota", buku.NoAnggota);
            return View(buku);
        }

        //
        // GET: /Bukuu/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Buku buku = db.Bukuu.Find(id);
            if (buku == null)
            {
                return HttpNotFound();
            }
            return View(buku);
        }

        //
        // POST: /Bukuu/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Buku buku = db.Bukuu.Find(id);
            db.Bukuu.Remove(buku);
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