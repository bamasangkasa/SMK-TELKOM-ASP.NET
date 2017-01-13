using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD2tabel.Models;

namespace CRUD2tabel.Controllers
{
    public class MahasiswaController : Controller
    {
        private MyCompaniDBContext db = new MyCompaniDBContext();

        //
        // GET: /Mahasiswa/

        public ActionResult Index(string searchName, string searchFakultas)
        {
            var mahasiswamodels = db.MahasiswaModels.Include(m => m.FakultasModels);

            var mahasiswa = new MahasiswaModels();

            if (!String.IsNullOrEmpty(searchName))
            {

                mahasiswamodels = mahasiswamodels.Where(n => n.nama.Contains(searchName));

            }

            ViewBag.searchFakultas = new SelectList(db.FakultasModels, "Fakultas", "Fakultas", mahasiswa.ID_fakultas);

            if (!String.IsNullOrEmpty(searchFakultas))
            {

                mahasiswamodels = mahasiswamodels.Where(d => d.FakultasModels.Fakultas == searchFakultas);

            }

            return View(mahasiswamodels.ToList());
        }

        //
        // GET: /Mahasiswa/Details/5

        public ActionResult Details(int id = 0)
        {
            MahasiswaModels mahasiswamodels = db.MahasiswaModels.Find(id);
            if (mahasiswamodels == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswamodels);
        }

        //
        // GET: /Mahasiswa/Create

        public ActionResult Create()
        {
            ViewBag.ID_fakultas = new SelectList(db.FakultasModels, "ID_fakultas", "Fakultas");
            return View();
        }

        //
        // POST: /Mahasiswa/Create

        [HttpPost]
        public ActionResult Create(MahasiswaModels mahasiswamodels)
        {
            if (ModelState.IsValid)
            {
                db.MahasiswaModels.Add(mahasiswamodels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_fakultas = new SelectList(db.FakultasModels, "ID_fakultas", "Fakultas", mahasiswamodels.ID_fakultas);
            return View(mahasiswamodels);
        }

        //
        // GET: /Mahasiswa/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MahasiswaModels mahasiswamodels = db.MahasiswaModels.Find(id);
            if (mahasiswamodels == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_fakultas = new SelectList(db.FakultasModels, "ID_fakultas", "Fakultas", mahasiswamodels.ID_fakultas);
            return View(mahasiswamodels);
        }

        //
        // POST: /Mahasiswa/Edit/5

        [HttpPost]
        public ActionResult Edit(MahasiswaModels mahasiswamodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mahasiswamodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_fakultas = new SelectList(db.FakultasModels, "ID_fakultas", "Fakultas", mahasiswamodels.ID_fakultas);
            return View(mahasiswamodels);
        }

        //
        // GET: /Mahasiswa/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MahasiswaModels mahasiswamodels = db.MahasiswaModels.Find(id);
            if (mahasiswamodels == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswamodels);
        }

        //
        // POST: /Mahasiswa/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MahasiswaModels mahasiswamodels = db.MahasiswaModels.Find(id);
            db.MahasiswaModels.Remove(mahasiswamodels);
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