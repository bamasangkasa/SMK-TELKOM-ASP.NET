using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dosen.Controllers
{
    public class DosennController : Controller
    {
        private MyCompanyDbContext db = new MyCompanyDbContext();

        //
        // GET: /Dosenn/

        public ActionResult Index(string searchKode)
        {
            var dosen = from s in db.Dosenn 
                        select s;
            if (!String.IsNullOrEmpty(searchKode))
            {
                dosen = dosen.Where(d => d.KodeDosen == searchKode);
            }

                return View(dosen.ToList());
            }
       

        //
        // GET: /Dosenn/Details/5

        public ActionResult Details(int id = 0)
        {
            Dosen dosen = db.Dosenn.Find(id);
            if (dosen == null)
            {
                return HttpNotFound();
            }
            return View(dosen);
        }

        //
        // GET: /Dosenn/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Dosenn/Create

        [HttpPost]
        public ActionResult Create(Dosen dosen)
        {
            if (ModelState.IsValid)
            {
                db.Dosenn.Add(dosen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dosen);
        }

        //
        // GET: /Dosenn/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Dosen dosen = db.Dosenn.Find(id);
            if (dosen == null)
            {
                return HttpNotFound();
            }
            return View(dosen);
        }

        //
        // POST: /Dosenn/Edit/5

        [HttpPost]
        public ActionResult Edit(Dosen dosen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dosen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dosen);
        }

        //
        // GET: /Dosenn/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Dosen dosen = db.Dosenn.Find(id);
            if (dosen == null)
            {
                return HttpNotFound();
            }
            return View(dosen);
        }

        //
        // POST: /Dosenn/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Dosen dosen = db.Dosenn.Find(id);
            db.Dosenn.Remove(dosen);
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