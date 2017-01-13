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
    public class SiswaController : Controller
    {
        private DataSekolahDbContext db = new DataSekolahDbContext();

        //
        // GET: /Siswa/

        public ActionResult Index(String searchNama)
        {

            var siswaa = db.Siswaa.Include(s => s.Sekolah);
            var siswa = new Siswa();

            if (!String.IsNullOrEmpty(searchNama))
            {
                siswaa = siswaa.Where(n => n.NamaLengkap.Contains(searchNama));
            }

            return View(siswaa.ToList());
        }


        //public ActionResult Index()
        //{
        //    var siswaa = db.Siswaa.Include(s => s.Sekolah);
        //    return View(siswaa.ToList());
        //}

        //
        // GET: /Siswa/Details/5

        public ActionResult Details(int id = 0)
        {
            Siswa siswa = db.Siswaa.Find(id);
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
            ViewBag.IDSekolah = new SelectList(db.Sekolahh, "IDSekolah", "NamaSekolah");
            return View();
        }

        //
        // POST: /Siswa/Create

        [HttpPost]
        public ActionResult Create(Siswa siswa)
        {
            if (ModelState.IsValid)
            {
                db.Siswaa.Add(siswa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDSekolah = new SelectList(db.Sekolahh, "IDSekolah", "NamaSekolah", siswa.IDSekolah);
            return View(siswa);
        }

        //
        // GET: /Siswa/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Siswa siswa = db.Siswaa.Find(id);
            if (siswa == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDSekolah = new SelectList(db.Sekolahh, "IDSekolah", "NamaSekolah", siswa.IDSekolah);
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
            ViewBag.IDSekolah = new SelectList(db.Sekolahh, "IDSekolah", "NamaSekolah", siswa.IDSekolah);
            return View(siswa);
        }

        //
        // GET: /Siswa/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Siswa siswa = db.Siswaa.Find(id);
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
            Siswa siswa = db.Siswaa.Find(id);
            db.Siswaa.Remove(siswa);
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