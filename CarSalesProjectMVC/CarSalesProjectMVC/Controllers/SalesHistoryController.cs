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
    public class SalesHistoryController : Controller
    {
        private CarSalesCompanyEntities db = new CarSalesCompanyEntities();

        //
        // GET: /SalesHistory/

        public ActionResult Index()
        {
            var saleshistories = db.SalesHistories.Include(s => s.Person).Include(s => s.Vehicle);
            return View(saleshistories.ToList());
        }

        //
        // GET: /SalesHistory/Details/5

        public ActionResult Details(int id = 0)
        {
            SalesHistory saleshistory = db.SalesHistories.Find(id);
            if (saleshistory == null)
            {
                return HttpNotFound();
            }
            return View(saleshistory);
        }

        //
        // GET: /SalesHistory/Create

        public ActionResult Create()
        {
            ViewBag.Id_Person = new SelectList(db.Persons, "Id_Person", "LastName");
            ViewBag.Id_Vehicle = new SelectList(db.Vehicles, "Id_Vehicle", "Model");
            return View();
        }

        //
        // POST: /SalesHistory/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalesHistory saleshistory)
        {
            if (ModelState.IsValid)
            {
                db.SalesHistories.Add(saleshistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Person = new SelectList(db.Persons, "Id_Person", "LastName", saleshistory.Id_Person);
            ViewBag.Id_Vehicle = new SelectList(db.Vehicles, "Id_Vehicle", "Model", saleshistory.Id_Vehicle);
            return View(saleshistory);
        }

        //
        // GET: /SalesHistory/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SalesHistory saleshistory = db.SalesHistories.Find(id);
            if (saleshistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Person = new SelectList(db.Persons, "Id_Person", "LastName", saleshistory.Id_Person);
            ViewBag.Id_Vehicle = new SelectList(db.Vehicles, "Id_Vehicle", "Model", saleshistory.Id_Vehicle);
            return View(saleshistory);
        }

        //
        // POST: /SalesHistory/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SalesHistory saleshistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saleshistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Person = new SelectList(db.Persons, "Id_Person", "LastName", saleshistory.Id_Person);
            ViewBag.Id_Vehicle = new SelectList(db.Vehicles, "Id_Vehicle", "Model", saleshistory.Id_Vehicle);
            return View(saleshistory);
        }

        //
        // GET: /SalesHistory/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SalesHistory saleshistory = db.SalesHistories.Find(id);
            if (saleshistory == null)
            {
                return HttpNotFound();
            }
            return View(saleshistory);
        }

        //
        // POST: /SalesHistory/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesHistory saleshistory = db.SalesHistories.Find(id);
            db.SalesHistories.Remove(saleshistory);
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