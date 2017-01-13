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
    public class ClassController : Controller
    {
        private MyCompanyDbContext db = new MyCompanyDbContext();

        //
        // GET: /Class/

        public ActionResult Index()
        {
            return View(db.Kelass.ToList());
        }

        //
        // GET: /Class/Details/5

        public ActionResult Details(int id = 0)
        {
            Kelas kelas = db.Kelass.Find(id);
            if (kelas == null)
            {
                return HttpNotFound();
            }
            return View(kelas);
        }

        //
        // GET: /Class/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Class/Create

        [HttpPost]
        public ActionResult Create(Kelas kelas)
        {
            if (ModelState.IsValid)
            {
                db.Kelass.Add(kelas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kelas);
        }

        //
        // GET: /Class/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Kelas kelas = db.Kelass.Find(id);
            if (kelas == null)
            {
                return HttpNotFound();
            }
            return View(kelas);
        }

        //
        // POST: /Class/Edit/5

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
        // GET: /Class/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Kelas kelas = db.Kelass.Find(id);
            if (kelas == null)
            {
                return HttpNotFound();
            }
            return View(kelas);
        }

        //
        // POST: /Class/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Kelas kelas = db.Kelass.Find(id);
            db.Kelass.Remove(kelas);
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