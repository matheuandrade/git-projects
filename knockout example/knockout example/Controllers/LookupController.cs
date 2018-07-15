using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using knockout_example.Models;
using knockout_example.DAL;

namespace knockout_example.Controllers
{
    public class LookupController : Controller
    {
        private KnockoutExampleModelContext db = new KnockoutExampleModelContext();

        //
        // GET: /Lookup/

        public ActionResult Index()
        {
            return View(db.Lookup.ToList());
        }

        //
        // GET: /Lookup/Details/5

        public ActionResult Details(int id = 0)
        {
            Lookup lookup = db.Lookup.Find(id);
            if (lookup == null)
            {
                return HttpNotFound();
            }
            return View(lookup);
        }

        //
        // GET: /Lookup/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Lookup/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Lookup lookup)
        {
            if (ModelState.IsValid)
            {
                db.Lookup.Add(lookup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lookup);
        }

        //
        // GET: /Lookup/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Lookup lookup = db.Lookup.Find(id);
            if (lookup == null)
            {
                return HttpNotFound();
            }
            return View(lookup);
        }

        //
        // POST: /Lookup/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Lookup lookup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lookup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lookup);
        }

        //
        // GET: /Lookup/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Lookup lookup = db.Lookup.Find(id);
            if (lookup == null)
            {
                return HttpNotFound();
            }
            return View(lookup);
        }

        //
        // POST: /Lookup/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lookup lookup = db.Lookup.Find(id);
            db.Lookup.Remove(lookup);
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