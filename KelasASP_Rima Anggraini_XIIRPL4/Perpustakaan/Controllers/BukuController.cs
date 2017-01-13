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
    public class BukuController : Controller
    {
        private PerpustakaanDbContext db = new PerpustakaanDbContext();

        //
        // GET: /Buku/

        public ActionResult Index( String SearchJudul)
        {
            var dep = from s in db.Bukus
                      select s;
            if (!string.IsNullOrEmpty(SearchJudul))
            {
               dep = dep.Where(u => u.Nama_Pengarang.Contains(SearchJudul));
            }
            return View(db.Bukus.ToList());
        }

        //
        // GET: /Buku/Details/5

        public ActionResult Details(int id = 0)
        {
            Buku buku = db.Bukus.Find(id);
            if (buku == null)
            {
                return HttpNotFound();
            }
            return View(buku);
        }

        //
        // GET: /Buku/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Buku/Create

        [HttpPost]
        public ActionResult Create(Buku buku)
        {
            if (ModelState.IsValid)
            {
                db.Bukus.Add(buku);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(buku);
        }

        //
        // GET: /Buku/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Buku buku = db.Bukus.Find(id);
            if (buku == null)
            {
                return HttpNotFound();
            }
            return View(buku);
        }

        //
        // POST: /Buku/Edit/5

        [HttpPost]
        public ActionResult Edit(Buku buku)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buku).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buku);
        }

        //
        // GET: /Buku/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Buku buku = db.Bukus.Find(id);
            if (buku == null)
            {
                return HttpNotFound();
            }
            return View(buku);
        }

        //
        // POST: /Buku/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Buku buku = db.Bukus.Find(id);
            db.Bukus.Remove(buku);
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