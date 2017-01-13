using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project.Models;

namespace project.Controllers
{
    public class Kelas2Controller : Controller
    {
        private MyCompanyDbContext db = new MyCompanyDbContext();

        //
        // GET: /Kelas2/

        public ActionResult Index( string searchKelas)
        {
            var kelas2 = from s in db.Kelas2 select s;

            if(!String.IsNullOrEmpty(searchKelas))
            {
                kelas2 = kelas2.Where(d => d.NamaKelas == searchKelas);
            }

            return View(db.Kelas2.ToList());
        }

        //
        // GET: /Kelas2/Details/5

        public ActionResult Details(int id = 0)
        {
            Kelas kelas = db.Kelas2.Find(id);
            if (kelas == null)
            {
                return HttpNotFound();
            }
            return View(kelas);
        }

        //
        // GET: /Kelas2/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Kelas2/Create

        [HttpPost]
        public ActionResult Create(Kelas kelas)
        {
            if (ModelState.IsValid)
            {
                db.Kelas2.Add(kelas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kelas);
        }

        //
        // GET: /Kelas2/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Kelas kelas = db.Kelas2.Find(id);
            if (kelas == null)
            {
                return HttpNotFound();
            }
            return View(kelas);
        }

        //
        // POST: /Kelas2/Edit/5

        [HttpPost]
        public ActionResult Edit(Kelas kelas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kelas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kelas);
        }

        //
        // GET: /Kelas2/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Kelas kelas = db.Kelas2.Find(id);
            if (kelas == null)
            {
                return HttpNotFound();
            }
            return View(kelas);
        }

        //
        // POST: /Kelas2/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Kelas kelas = db.Kelas2.Find(id);
            db.Kelas2.Remove(kelas);
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