using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarSalesCompanyModels;

namespace CarSalesProjectMVC.Controllers
{
    public class EngineTypeController : Controller
    {
        private CarSalesCompanyEntities db = new CarSalesCompanyEntities();

        //
        // GET: /EngineType/
        

        public ActionResult Index()
        {
            return View(db.EngineTypes.ToList());
        }

        //
        // GET: /EngineType/Details/5

        public ActionResult Details(string id = null)
        {
            EngineType enginetype = db.EngineTypes.Find(id);
            if (enginetype == null)
            {
                return HttpNotFound();
            }
            return View(enginetype);
        }

        //
        // GET: /EngineType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /EngineType/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EngineType enginetype)
        {
            if (ModelState.IsValid)
            {
                db.EngineTypes.Add(enginetype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enginetype);
        }

        //
        // GET: /EngineType/Edit/5

        public ActionResult Edit(string id = null)
        {
            EngineType enginetype = db.EngineTypes.Find(id);
            if (enginetype == null)
            {
                return HttpNotFound();
            }
            return View(enginetype);
        }

        //
        // POST: /EngineType/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EngineType enginetype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enginetype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enginetype);
        }

        //
        // GET: /EngineType/Delete/5

        public ActionResult Delete(string id = null)
        {
            EngineType enginetype = db.EngineTypes.Find(id);
            if (enginetype == null)
            {
                return HttpNotFound();
            }
            return View(enginetype);
        }

        //
        // POST: /EngineType/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EngineType enginetype = db.EngineTypes.Find(id);
            db.EngineTypes.Remove(enginetype);
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