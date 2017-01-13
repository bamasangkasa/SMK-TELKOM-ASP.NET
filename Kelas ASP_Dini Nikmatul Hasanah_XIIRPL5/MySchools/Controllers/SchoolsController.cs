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
    public class SchoolsController : Controller
    {
        private MySchoolsDbContext db = new MySchoolsDbContext();

        //
        // GET: /Schools/

        public ActionResult Index(string searchName, string searchYayasan)
        {
            var schoolss = db.Schoolss.Include(s => s.Yayasan);
            var schools = new Schools();

            if (!String.IsNullOrEmpty(searchName))
            {
                schoolss = schoolss.Where(n => n.SchoolName.Contains(searchName));
            }

            ViewBag.searchYayasan = new SelectList(db.Yayasann, "NamaYayasan", "NamaYayasan", schools.YayasanID);

            if (!String.IsNullOrEmpty(searchYayasan))
            {
                schoolss = schoolss.Where(d => d.Yayasan.NamaYayasan == searchYayasan);
            }
            return View(schoolss.ToList());
        }

        //
        // GET: /Schools/Details/5

        public ActionResult Details(int id = 0)
        {
            Schools schools = db.Schoolss.Find(id);
            if (schools == null)
            {
                return HttpNotFound();
            }
            return View(schools);
        }

        //
        // GET: /Schools/Create

        public ActionResult Create()
        {
            ViewBag.YayasanID = new SelectList(db.Yayasann, "YayasanID", "NamaYayasan");
            return View();
        }

        //
        // POST: /Schools/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Schools schools)
        {
            if (ModelState.IsValid)
            {
                db.Schoolss.Add(schools);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.YayasanID = new SelectList(db.Yayasann, "YayasanID", "NamaYayasan", schools.YayasanID);
            return View(schools);
        }

        //
        // GET: /Schools/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Schools schools = db.Schoolss.Find(id);
            if (schools == null)
            {
                return HttpNotFound();
            }
            ViewBag.YayasanID = new SelectList(db.Yayasann, "YayasanID", "NamaYayasan", schools.YayasanID);
            return View(schools);
        }

        //
        // POST: /Schools/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Schools schools)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schools).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.YayasanID = new SelectList(db.Yayasann, "YayasanID", "NamaYayasan", schools.YayasanID);
            return View(schools);
        }

        //
        // GET: /Schools/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Schools schools = db.Schoolss.Find(id);
            if (schools == null)
            {
                return HttpNotFound();
            }
            return View(schools);
        }

        //
        // POST: /Schools/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schools schools = db.Schoolss.Find(id);
            db.Schoolss.Remove(schools);
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