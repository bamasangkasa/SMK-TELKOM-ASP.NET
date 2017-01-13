using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biodata.Models;

namespace Biodata.Controllers
{
    public class BiodataOrangTuaController : Controller
    {
        private BiodataDbContext db = new BiodataDbContext();

        //
        // GET: /BiodataOrangTua/

        public ActionResult Index()
        {
            var biodataorangtuaa = db.BiodataOrangtuaa.Include(b => b.BiodataAnak);
            return View(biodataorangtuaa.ToList());
        }

        //
        // GET: /BiodataOrangTua/Details/5

        public ActionResult Details(int id = 0)
        {
            BiodataOrangTua biodataorangtua = db.BiodataOrangtuaa.Find(id);
            if (biodataorangtua == null)
            {
                return HttpNotFound();
            }
            return View(biodataorangtua);
        }

        //
        // GET: /BiodataOrangTua/Create

        public ActionResult Create()
        {
            ViewBag.BiodataAnakID = new SelectList(db.BiodataAnakk, "BiodataAnakID", "Nama");
            return View();
        }

        //
        // POST: /BiodataOrangTua/Create

        [HttpPost]
        public ActionResult Create(BiodataOrangTua biodataorangtua)
        {
            if (ModelState.IsValid)
            {
                db.BiodataOrangtuaa.Add(biodataorangtua);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BiodataAnakID = new SelectList(db.BiodataAnakk, "BiodataAnakID", "Nama", biodataorangtua.BiodataAnakID);
            return View(biodataorangtua);
        }

        //
        // GET: /BiodataOrangTua/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BiodataOrangTua biodataorangtua = db.BiodataOrangtuaa.Find(id);
            if (biodataorangtua == null)
            {
                return HttpNotFound();
            }
            ViewBag.BiodataAnakID = new SelectList(db.BiodataAnakk, "BiodataAnakID", "Nama", biodataorangtua.BiodataAnakID);
            return View(biodataorangtua);
        }

        //
        // POST: /BiodataOrangTua/Edit/5

        [HttpPost]
        public ActionResult Edit(BiodataOrangTua biodataorangtua)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biodataorangtua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BiodataAnakID = new SelectList(db.BiodataAnakk, "BiodataAnakID", "Nama", biodataorangtua.BiodataAnakID);
            return View(biodataorangtua);
        }

        //
        // GET: /BiodataOrangTua/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BiodataOrangTua biodataorangtua = db.BiodataOrangtuaa.Find(id);
            if (biodataorangtua == null)
            {
                return HttpNotFound();
            }
            return View(biodataorangtua);
        }

        //
        // POST: /BiodataOrangTua/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            BiodataOrangTua biodataorangtua = db.BiodataOrangtuaa.Find(id);
            db.BiodataOrangtuaa.Remove(biodataorangtua);
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