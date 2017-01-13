using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySchools.Models;

namespace MySchools.Controllers
{
    public class YayasanController : Controller
    {
        private MySchoolsDbContext db = new MySchoolsDbContext();

        //
        // GET: /Yayasan/

        public ActionResult Index(string searchAddress)
        {
            var yayasann = from s in db.Yayasann select s;
            if (!String.IsNullOrEmpty(searchAddress))
            {
                var y = yayasann.Where(d => d.Address == searchAddress);
            }
            
            return View(db.Yayasann.ToList());
        }

        //
        // GET: /Yayasan/Details/5

        public ActionResult Details(int id = 0)
        {
            Yayasan yayasan = db.Yayasann.Find(id);
            if (yayasan == null)
            {
                return HttpNotFound();
            }
            return View(yayasan);
        }

        //
        // GET: /Yayasan/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Yayasan/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Yayasan yayasan)
        {
            if (ModelState.IsValid)
            {
                db.Yayasann.Add(yayasan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yayasan);
        }

        //
        // GET: /Yayasan/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Yayasan yayasan = db.Yayasann.Find(id);
            if (yayasan == null)
            {
                return HttpNotFound();
            }
            return View(yayasan);
        }

        //
        // POST: /Yayasan/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Yayasan yayasan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yayasan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yayasan);
        }

        //
        // GET: /Yayasan/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Yayasan yayasan = db.Yayasann.Find(id);
            if (yayasan == null)
            {
                return HttpNotFound();
            }
            return View(yayasan);
        }

        //
        // POST: /Yayasan/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yayasan yayasan = db.Yayasann.Find(id);
            db.Yayasann.Remove(yayasan);
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