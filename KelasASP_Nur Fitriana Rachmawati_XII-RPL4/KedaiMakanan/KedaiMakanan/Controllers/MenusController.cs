using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KedaiMakanan.Models;

namespace KedaiMakanan.Controllers
{
    public class MenusController : Controller
    {
        private KedaiMakananDbContext db = new KedaiMakananDbContext();

        // GET: Menus
        public ActionResult Index(string searchName, string searchMenu)
        {
            var MenuMakanan = db.MenuMakanan.Include(e => e.MenuMakanan);
            var kedaiMakanan = new Menu();

            if(!String.IsNullOrEmpty(searchName))
            {
                MenuMakanan = MenuMakanan.Where(n => n.MenuMakanan.Contains(searchName));
            }

            ViewBag.searchMenu = new SelectList(db.KedaiMakanan, "MenuName", "MenuName", kedaiMakanan.MenuID);

            if (!String.IsNullOrEmpty(searchMenu))
            {
                MenuMakanan = MenuMakanan.Where(d => d.MenuMakanan.NamaMenu == searchMenu);
            }

            return View(MenuMakanan.ToList());
        }

        // GET: Menus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.KedaiMakanan.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: Menus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuID,NamaMenu,HargaMenu")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.KedaiMakanan.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menu);
        }

        // GET: Menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.KedaiMakanan.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuID,NamaMenu,HargaMenu")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        // GET: Menus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.KedaiMakanan.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menu menu = db.KedaiMakanan.Find(id);
            db.KedaiMakanan.Remove(menu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
