using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biodata.Models;

namespace Biodata.Controllers
{
    public class BiodataAnakController : Controller
    {
        private BiodataDbContext db = new BiodataDbContext();

        //
        // GET: /BiodataAnak/

        public ActionResult Index(String SearchName, String SearchOrangTua)
        {
            var biodataanakk = db.BiodataAnakk.Include(e => e.BiodataOrangTuaa);
            var biodataanak = new BiodataAnak();
            if (!String.IsNullOrEmpty(SearchName))
            {
                biodataanakk = biodataanakk.Where(n => n.Nama.Contains(SearchName));
            }

            return View(db.BiodataAnakk.ToList());
        }

        //
        // GET: /BiodataAnak/Details/5

        public ActionResult Details(int id = 0)
        {
            BiodataAnak biodataanak = db.BiodataAnakk.Find(id);
            if (biodataanak == null)
            {
                return HttpNotFound();
            }
            return View(biodataanak);
        }

        //
        // GET: /BiodataAnak/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BiodataAnak/Create

        [HttpPost]
        public ActionResult Create(BiodataAnak biodataanak)
        {
            if (ModelState.IsValid)
            {
                db.BiodataAnakk.Add(biodataanak);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(biodataanak);
        }

        //
        // GET: /BiodataAnak/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BiodataAnak biodataanak = db.BiodataAnakk.Find(id);
            if (biodataanak == null)
            {
                return HttpNotFound();
            }
            return View(biodataanak);
        }

        //
        // POST: /BiodataAnak/Edit/5

        [HttpPost]
        public ActionResult Edit(BiodataAnak biodataanak)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biodataanak).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(biodataanak);
        }

        //
        // GET: /BiodataAnak/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BiodataAnak biodataanak = db.BiodataAnakk.Find(id);
            if (biodataanak == null)
            {
                return HttpNotFound();
            }
            return View(biodataanak);
        }

        //
        // POST: /BiodataAnak/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            BiodataAnak biodataanak = db.BiodataAnakk.Find(id);
            db.BiodataAnakk.Remove(biodataanak);
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