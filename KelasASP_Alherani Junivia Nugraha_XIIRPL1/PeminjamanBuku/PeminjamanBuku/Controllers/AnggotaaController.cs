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
    public class AnggotaaController : Controller
    {
        private PeminjamanBukuDbContext db = new PeminjamanBukuDbContext();

        //
        // GET: /Anggotaa/

        public ActionResult Index(string searchName)
        {
            var anggotaa = from s in db.Anggotaa
                           select s;
            if(!String.IsNullOrEmpty(searchName))
            {
                anggotaa = anggotaa.Where(a => a.NamaAnggota == searchName);
            }
            return View(anggotaa.ToList());
        }

        //
        // GET: /Anggotaa/Details/5

        public ActionResult Details(int id = 0)
        {
            Anggota anggota = db.Anggotaa.Find(id);
            if (anggota == null)
            {
                return HttpNotFound();
            }
            return View(anggota);
        }

        //
        // GET: /Anggotaa/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Anggotaa/Create

        [HttpPost]
        public ActionResult Create(Anggota anggota)
        {
            if (ModelState.IsValid)
            {
                db.Anggotaa.Add(anggota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anggota);
        }

        //
        // GET: /Anggotaa/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Anggota anggota = db.Anggotaa.Find(id);
            if (anggota == null)
            {
                return HttpNotFound();
            }
            return View(anggota);
        }

        //
        // POST: /Anggotaa/Edit/5

        [HttpPost]
        public ActionResult Edit(Anggota anggota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anggota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anggota);
        }

        //
        // GET: /Anggotaa/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Anggota anggota = db.Anggotaa.Find(id);
            if (anggota == null)
            {
                return HttpNotFound();
            }
            return View(anggota);
        }

        //
        // POST: /Anggotaa/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Anggota anggota = db.Anggotaa.Find(id);
            db.Anggotaa.Remove(anggota);
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