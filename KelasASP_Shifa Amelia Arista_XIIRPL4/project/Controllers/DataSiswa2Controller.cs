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
    public class DataSiswa2Controller : Controller
    {
        private MyCompanyDbContext db = new MyCompanyDbContext();

        //
        // GET: /DataSiswa2/

        public ActionResult Index(string searchName, string searchKelas)
        {
            var datasiswa2 = db.DataSiswa2.Include(d => d.Kelas);
            var datasiswa = new DataSiswa();

            if (!String.IsNullOrEmpty(searchName))
            {
                datasiswa2 = datasiswa2.Where(n => n.NamaLengkap.Contains(searchName));
            }

            ViewBag.searchKelas = new SelectList(db.Kelas2, "NamaKelas", "NamaKelas");

            if (!String.IsNullOrEmpty(searchKelas))
            {
                datasiswa2 = datasiswa2.Where(d => d.Kelas.NamaKelas == searchKelas);
            }

            return View(datasiswa2.ToList());

        }

        //
        // GET: /DataSiswa2/Details/5

        public ActionResult Details(int id = 0)
        {
            DataSiswa datasiswa = db.DataSiswa2.Find(id);
            if (datasiswa == null)
            {
                return HttpNotFound();
            }
            return View(datasiswa);
        }

        //
        // GET: /DataSiswa2/Create

        public ActionResult Create()
        {
            ViewBag.KodeKelas = new SelectList(db.Kelas2, "KodeKelas", "NamaKelas");
            return View();
        }

        //
        // POST: /DataSiswa2/Create

        [HttpPost]
        public ActionResult Create(DataSiswa datasiswa)
        {
            if (ModelState.IsValid)
            {
                db.DataSiswa2.Add(datasiswa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KodeKelas = new SelectList(db.Kelas2, "KodeKelas", "NamaKelas", datasiswa.KodeKelas);
            return View(datasiswa);
        }

        //
        // GET: /DataSiswa2/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DataSiswa datasiswa = db.DataSiswa2.Find(id);
            if (datasiswa == null)
            {
                return HttpNotFound();
            }
            ViewBag.KodeKelas = new SelectList(db.Kelas2, "KodeKelas", "NamaKelas", datasiswa.KodeKelas);
            return View(datasiswa);
        }

        //
        // POST: /DataSiswa2/Edit/5

        [HttpPost]
        public ActionResult Edit(DataSiswa datasiswa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datasiswa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KodeKelas = new SelectList(db.Kelas2, "KodeKelas", "NamaKelas", datasiswa.KodeKelas);
            return View(datasiswa);
        }

        //
        // GET: /DataSiswa2/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DataSiswa datasiswa = db.DataSiswa2.Find(id);
            if (datasiswa == null)
            {
                return HttpNotFound();
            }
            return View(datasiswa);
        }

        //
        // POST: /DataSiswa2/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            DataSiswa datasiswa = db.DataSiswa2.Find(id);
            db.DataSiswa2.Remove(datasiswa);
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