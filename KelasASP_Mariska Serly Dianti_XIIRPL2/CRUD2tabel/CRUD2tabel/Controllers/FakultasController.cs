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
    public class FakultasController : Controller
    {
        private MyCompaniDBContext db = new MyCompaniDBContext();

        //
        // GET: /Fakultas/

        public ActionResult Index(string searchFakultas)
        {
            var fakultas = from s in db.FakultasModels select s;
            if (!String.IsNullOrEmpty(searchFakultas))
            {
                fakultas = fakultas.Where(f => f.Fakultas == searchFakultas);

            }
            return View(db.FakultasModels.ToList());
        }

        //
        // GET: /Fakultas/Details/5

        public ActionResult Details(int id = 0)
        {
            FakultasModels fakultasmodels = db.FakultasModels.Find(id);
            if (fakultasmodels == null)
            {
                return HttpNotFound();
            }
            return View(fakultasmodels);
        }

        //
        // GET: /Fakultas/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Fakultas/Create

        [HttpPost]
        public ActionResult Create(FakultasModels fakultasmodels)
        {
            if (ModelState.IsValid)
            {
                db.FakultasModels.Add(fakultasmodels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fakultasmodels);
        }

        //
        // GET: /Fakultas/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FakultasModels fakultasmodels = db.FakultasModels.Find(id);
            if (fakultasmodels == null)
            {
                return HttpNotFound();
            }
            return View(fakultasmodels);
        }

        //
        // POST: /Fakultas/Edit/5

        [HttpPost]
        public ActionResult Edit(FakultasModels fakultasmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fakultasmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fakultasmodels);
        }

        //
        // GET: /Fakultas/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FakultasModels fakultasmodels = db.FakultasModels.Find(id);
            if (fakultasmodels == null)
            {
                return HttpNotFound();
            }
            return View(fakultasmodels);
        }

        //
        // POST: /Fakultas/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            FakultasModels fakultasmodels = db.FakultasModels.Find(id);
            db.FakultasModels.Remove(fakultasmodels);
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