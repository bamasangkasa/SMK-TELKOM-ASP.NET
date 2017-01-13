using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCompany.Models;

namespace Siswa.Controllers
{
    public class StudentController : Controller
    {
        private MyCompanyDbContext db = new MyCompanyDbContext();

        //
        // GET: /Student/

        public ActionResult Index()
        {
            var muridd = db.Muridd.Include(m => m.Kelas);
            return View(muridd.ToList());
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id = 0)
        {
            Murid murid = db.Muridd.Find(id);
            if (murid == null)
            {
                return HttpNotFound();
            }
            return View(murid);
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            ViewBag.KelasID = new SelectList(db.Kelass, "KelasID", "Nama");
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        public ActionResult Create(Murid murid)
        {
            if (ModelState.IsValid)
            {
                db.Muridd.Add(murid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KelasID = new SelectList(db.Kelass, "KelasID", "Nama", murid.KelasID);
            return View(murid);
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Murid murid = db.Muridd.Find(id);
            if (murid == null)
            {
                return HttpNotFound();
            }
            ViewBag.KelasID = new SelectList(db.Kelass, "KelasID", "Nama", murid.KelasID);
            return View(murid);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        public ActionResult Edit(Murid murid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(murid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KelasID = new SelectList(db.Kelass, "KelasID", "Nama", murid.KelasID);
            return View(murid);
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Murid murid = db.Muridd.Find(id);
            if (murid == null)
            {
                return HttpNotFound();
            }
            return View(murid);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Murid murid = db.Muridd.Find(id);
            db.Muridd.Remove(murid);
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