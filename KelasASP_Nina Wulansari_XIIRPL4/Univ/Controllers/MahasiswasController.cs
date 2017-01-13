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
    public class MahasiswasController : Controller
    {
        private MyCompanyDbContext db = new MyCompanyDbContext();

        // GET: Mahasiswas
        public ActionResult Index(string searchName, string searchDosen)
        {
            var mahasiswas = db.Mahasiswas.Include(m => m.Dosen);
            var mahasiswa = new Mahasiswa();

            if (!String.IsNullOrEmpty(searchName))
            {
                mahasiswas = mahasiswas.Where(n => n.FirstName.Contains(searchName) || n.LastName.Contains(searchName));
            }

            ViewBag.searchDosen = new SelectList(db.Dosens, "NamaDosen", "NamaDosen", mahasiswa.DosenID);

            if (!String.IsNullOrEmpty(searchDosen))
            {
                mahasiswas = mahasiswas.Where(d => d.Dosen.NamaDosen == searchDosen);
            }
            return View(mahasiswas.ToList());
        }

        // GET: Mahasiswas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahasiswa mahasiswa = db.Mahasiswas.Find(id);
            if (mahasiswa == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswa);
        }

        // GET: Mahasiswas/Create
        public ActionResult Create()
        {
            ViewBag.DosenID = new SelectList(db.Dosens, "DosenID", "NamaDosen");
            return View();
        }

        // POST: Mahasiswas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MahasiswaID,FirstName,LastName,Jurusan,Email,DosenID")] Mahasiswa mahasiswa)
        {
            if (ModelState.IsValid)
            {
                db.Mahasiswas.Add(mahasiswa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DosenID = new SelectList(db.Dosens, "DosenID", "NamaDosen", mahasiswa.DosenID);
            return View(mahasiswa);
        }

        // GET: Mahasiswas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahasiswa mahasiswa = db.Mahasiswas.Find(id);
            if (mahasiswa == null)
            {
                return HttpNotFound();
            }
            ViewBag.DosenID = new SelectList(db.Dosens, "DosenID", "NamaDosen", mahasiswa.DosenID);
            return View(mahasiswa);
        }

        // POST: Mahasiswas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MahasiswaID,FirstName,LastName,Jurusan,Email,DosenID")] Mahasiswa mahasiswa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mahasiswa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DosenID = new SelectList(db.Dosens, "DosenID", "NamaDosen", mahasiswa.DosenID);
            return View(mahasiswa);
        }

        // GET: Mahasiswas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahasiswa mahasiswa = db.Mahasiswas.Find(id);
            if (mahasiswa == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswa);
        }

        // POST: Mahasiswas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mahasiswa mahasiswa = db.Mahasiswas.Find(id);
            db.Mahasiswas.Remove(mahasiswa);
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
