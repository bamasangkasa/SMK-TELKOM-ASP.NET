using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dosen.Controllers
{
    public class MapellController : Controller
    {
        private MyCompanyDbContext db = new MyCompanyDbContext();

        //
        // GET: /Mapell/

        public ActionResult Index(string searchName, string searchMapel)
        {
            var mapell = db.MaPell.Include(k => k.Dosen);
            var kuliah = new Kuliah();

            if (!String.IsNullOrEmpty(searchName))
            {
                mapell = mapell.Where(n => n.NamaPelajaran.Contains(searchName));
            }

            ViewBag.searchMapel = new SelectList(db.Dosenn, "NamaDosen", "KodeDosen", kuliah.DosenID);

            if (!String.IsNullOrEmpty(searchMapel))
            {
                mapell = mapell.Where(d => d.Dosen.KodeDosen == searchMapel);
            }
            return View(mapell.ToList());
        }

        //
        // GET: /Mapell/Details/5

        public ActionResult Details(int id = 0)
        {
            Kuliah kuliah = db.MaPell.Find(id);
            if (kuliah == null)
            {
                return HttpNotFound();
            }
            return View(kuliah);
        }

        //
        // GET: /Mapell/Create

        public ActionResult Create()
        {
            ViewBag.DosenID = new SelectList(db.Dosenn, "DosenID", "NamaDosen");
            return View();
        }

        //
        // POST: /Mapell/Create

        [HttpPost]
        public ActionResult Create(Kuliah kuliah)
        {
            if (ModelState.IsValid)
            {
                db.MaPell.Add(kuliah);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DosenID = new SelectList(db.Dosenn, "DosenID", "NamaDosen", kuliah.DosenID);
            return View(kuliah);
        }

        //
        // GET: /Mapell/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Kuliah kuliah = db.MaPell.Find(id);
            if (kuliah == null)
            {
                return HttpNotFound();
            }
            ViewBag.DosenID = new SelectList(db.Dosenn, "DosenID", "NamaDosen", kuliah.DosenID);
            return View(kuliah);
        }

        //
        // POST: /Mapell/Edit/5

        [HttpPost]
        public ActionResult Edit(Kuliah kuliah)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kuliah).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DosenID = new SelectList(db.Dosenn, "DosenID", "NamaDosen", kuliah.DosenID);
            return View(kuliah);
        }

        //
        // GET: /Mapell/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Kuliah kuliah = db.MaPell.Find(id);
            if (kuliah == null)
            {
                return HttpNotFound();
            }
            return View(kuliah);
        }

        //
        // POST: /Mapell/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Kuliah kuliah = db.MaPell.Find(id);
            db.MaPell.Remove(kuliah);
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