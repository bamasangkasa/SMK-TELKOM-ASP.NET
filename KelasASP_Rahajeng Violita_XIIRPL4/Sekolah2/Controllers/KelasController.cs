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
    public class KelasController : Controller
    {
        private SekolahDbContext db = new SekolahDbContext();

        //
        // GET: /Kelas/

        public ActionResult Index(string searchJurusan)
        {
            var kelaskelas = from s in db.KelasKelas
                              select s;
            if (!String.IsNullOrEmpty(searchJurusan))
            {
                kelaskelas = kelaskelas.Where(d => d.Jurusan == searchJurusan);
            }
                return View(kelaskelas.ToList());
        }

        //
        // GET: /Kelas/Details/5

        public ActionResult Details(int id = 0)
        {
            Kelas kelas = db.KelasKelas.Find(id);
            if (kelas == null)
            {
                return HttpNotFound();
            }
            return View(kelas);
        }

        //
        // GET: /Kelas/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Kelas/Create

        [HttpPost]
        public ActionResult Create(Kelas kelas)
        {
            if (ModelState.IsValid)
            {
                db.KelasKelas.Add(kelas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kelas);
        }

        //
        // GET: /Kelas/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Kelas kelas = db.KelasKelas.Find(id);
            if (kelas == null)
            {
                return HttpNotFound();
            }
            return View(kelas);
        }

        //
        // POST: /Kelas/Edit/5

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
        // GET: /Kelas/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Kelas kelas = db.KelasKelas.Find(id);
            if (kelas == null)
            {
                return HttpNotFound();
            }
            return View(kelas);
        }

        //
        // POST: /Kelas/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Kelas kelas = db.KelasKelas.Find(id);
            db.KelasKelas.Remove(kelas);
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