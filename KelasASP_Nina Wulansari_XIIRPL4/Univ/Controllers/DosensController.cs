using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Univ.Models;

namespace Univ.Controllers
{
    public class DosensController : Controller
    {
        private MyCompanyDbContext db = new MyCompanyDbContext();

        // GET: Dosens
        public ActionResult Index(string searchMataKuliah)
        {
            var dosens = from s in db.Dosens select s;
            if(!String.IsNullOrEmpty(searchMataKuliah))
            {
                dosens = dosens.Where(d => d.MataKuliah == searchMataKuliah);
            }

            return View(db.Dosens.ToList());
        }

        // GET: Dosens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dosen dosen = db.Dosens.Find(id);
            if (dosen == null)
            {
                return HttpNotFound();
            }
            return View(dosen);
        }

        // GET: Dosens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dosens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DosenID,NamaDosen,AlamatDosen,MataKuliah")] Dosen dosen)
        {
            if (ModelState.IsValid)
            {
                db.Dosens.Add(dosen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dosen);
        }

        // GET: Dosens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dosen dosen = db.Dosens.Find(id);
            if (dosen == null)
            {
                return HttpNotFound();
            }
            return View(dosen);
        }

        // POST: Dosens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DosenID,NamaDosen,AlamatDosen,MataKuliah")] Dosen dosen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dosen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dosen);
        }

        // GET: Dosens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dosen dosen = db.Dosens.Find(id);
            if (dosen == null)
            {
                return HttpNotFound();
            }
            return View(dosen);
        }

        // POST: Dosens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dosen dosen = db.Dosens.Find(id);
            db.Dosens.Remove(dosen);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
