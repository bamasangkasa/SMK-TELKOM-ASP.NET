using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tes2.Models;

namespace tes2.Controllers
{
    public class SekolahController : Controller
    {
        private DataSekolahDbContext db = new DataSekolahDbContext();

        //
        // GET: /Sekolah/

        public ActionResult Index()
        {
            return View(db.Sekolahh.ToList());
        }

        //
        // GET: /Sekolah/Details/5

        public ActionResult Details(int id = 0)
        {
            Sekolah sekolah = db.Sekolahh.Find(id);
            if (sekolah == null)
            {
                return HttpNotFound();
            }
            return View(sekolah);
        }

        //
        // GET: /Sekolah/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Sekolah/Create

        [HttpPost]
        public ActionResult Create(Sekolah sekolah)
        {
            if (ModelState.IsValid)
            {
                db.Sekolahh.Add(sekolah);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sekolah);
        }

        //
        // GET: /Sekolah/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Sekolah sekolah = db.Sekolahh.Find(id);
            if (sekolah == null)
            {
                return HttpNotFound();
            }
            return View(sekolah);
        }

        //
        // POST: /Sekolah/Edit/5

        [HttpPost]
        public ActionResult Edit(Sekolah sekolah)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sekolah).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sekolah);
        }

        //
        // GET: /Sekolah/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Sekolah sekolah = db.Sekolahh.Find(id);
            if (sekolah == null)
            {
                return HttpNotFound();
            }
            return View(sekolah);
        }

        //
        // POST: /Sekolah/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Sekolah sekolah = db.Sekolahh.Find(id);
            db.Sekolahh.Remove(sekolah);
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