using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class KasirController : Controller
    {
        private MyCompanyDBContext db = new MyCompanyDBContext();

        //
        // GET: /Kasir/

        public ActionResult Index(string searchAlamat)
        {
            var kasir = from s in db.Kasir
                        select s;
            if (!String.IsNullOrEmpty(searchAlamat))
            {
                kasir = kasir.Where(d => d.Alamat == searchAlamat);
            }
            return View(kasir.ToList());
                //(db.Kasir.ToList());
        }

        //
        // GET: /Kasir/Details/5

        public ActionResult Details(int id = 0)
        {
            Kasir kasir = db.Kasir.Find(id);
            if (kasir == null)
            {
                return HttpNotFound();
            }
            return View(kasir);
        }

        //
        // GET: /Kasir/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Kasir/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kasir kasir)
        {
            if (ModelState.IsValid)
            {
                db.Kasir.Add(kasir);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kasir);
        }

        //
        // GET: /Kasir/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Kasir kasir = db.Kasir.Find(id);
            if (kasir == null)
            {
                return HttpNotFound();
            }
            return View(kasir);
        }

        //
        // POST: /Kasir/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kasir kasir)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kasir).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kasir);
        }

        //
        // GET: /Kasir/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Kasir kasir = db.Kasir.Find(id);
            if (kasir == null)
            {
                return HttpNotFound();
            }
            return View(kasir);
        }

        //
        // POST: /Kasir/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kasir kasir = db.Kasir.Find(id);
            db.Kasir.Remove(kasir);
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