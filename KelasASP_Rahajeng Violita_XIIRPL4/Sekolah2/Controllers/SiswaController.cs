using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sekolah2.Models;

namespace Sekolah2.Controllers
{
    public class SiswaController : Controller
    {
        private SekolahDbContext db = new SekolahDbContext();

        //
        // GET: /Siswa/

        public ActionResult Index(string searchName, string searchKelas)
        {
            var parasiswa = db.ParaSiswa.Include(s => s.Kelas);
            var siswa = new Siswa();

            if (!String.IsNullOrEmpty(searchName))
            {
                parasiswa = parasiswa.Where(n => n.NamaSiswa.Contains(searchName));

            }

            return View(parasiswa.ToList());
        }

        //
        // GET: /Siswa/Details/5

        public ActionResult Details(int id = 0)
        {
            Siswa siswa = db.ParaSiswa.Find(id);
            if (siswa == null)
            {
                return HttpNotFound();
            }
            return View(siswa);
        }

        //
        // GET: /Siswa/Create

        public ActionResult Create()
        {
            ViewBag.KelasID = new SelectList(db.KelasKelas, "KelasID", "NamaKelas");
            return View();
        }

        //
        // POST: /Siswa/Create

        [HttpPost]
        public ActionResult Create(Siswa siswa)
        {
            if (ModelState.IsValid)
            {
                db.ParaSiswa.Add(siswa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KelasID = new SelectList(db.KelasKelas, "KelasID", "NamaKelas", siswa.KelasID);
            return View(siswa);
        }

        //
        // GET: /Siswa/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Siswa siswa = db.ParaSiswa.Find(id);
            if (siswa == null)
            {
                return HttpNotFound();
            }
            ViewBag.KelasID = new SelectList(db.KelasKelas, "KelasID", "NamaKelas", siswa.KelasID);
            return View(siswa);
        }

        //
        // POST: /Siswa/Edit/5

        [HttpPost]
        public ActionResult Edit(Siswa siswa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siswa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KelasID = new SelectList(db.KelasKelas, "KelasID", "NamaKelas", siswa.KelasID);
            return View(siswa);
        }

        //
        // GET: /Siswa/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Siswa siswa = db.ParaSiswa.Find(id);
            if (siswa == null)
            {
                return HttpNotFound();
            }
            return View(siswa);
        }

        //
        // POST: /Siswa/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Siswa siswa = db.ParaSiswa.Find(id);
            db.ParaSiswa.Remove(siswa);
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