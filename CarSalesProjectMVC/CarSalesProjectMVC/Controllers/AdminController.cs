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
    public class AdminController : Controller
    {
        private CarSalesCompanyEntities db = new CarSalesCompanyEntities();

        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllVehicles()
        {
            var vehicles = db.Vehicles.Include(v => v.EngineType1).Include(v => v.Manufacturer).Include(v => v.VehicleExtra).Include(v => v.VehicleType1);
            return View(vehicles.ToList());
        }

        public ActionResult SoldVehicles()
        {
            var vehicles = db.Vehicles.Include(v => v.EngineType1).Include(v => v.Manufacturer).Include(v => v.VehicleExtra).Include(v => v.VehicleType1).Where(v=>v.Sold==true);
            return View(vehicles.ToList());
        }

        public ActionResult SellVehicles()
        {
            var vehicles = db.Vehicles.Include(v => v.EngineType1).Include(v => v.Manufacturer).Include(v => v.VehicleExtra).Include(v => v.VehicleType1).Where(v => v.Sold != true);
            return View(vehicles.ToList());
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(int id = 0)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            ViewBag.EngineType = new SelectList(db.EngineTypes, "TypeOfEngine", "TypeOfEngine");
            ViewBag.Producer = new SelectList(db.Manufacturers, "Name", "Name");
            ViewBag.Id_Extras = new SelectList(db.VehicleExtras, "Id_Extras", "Id_Extras");
            ViewBag.VehicleType = new SelectList(db.VehicleTypes, "TypeOfVehicle", "TypeOfVehicle");
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EngineType = new SelectList(db.EngineTypes, "TypeOfEngine", "TypeOfEngine", vehicle.EngineType);
            ViewBag.Producer = new SelectList(db.Manufacturers, "Name", "Name", vehicle.Producer);
            ViewBag.Id_Extras = new SelectList(db.VehicleExtras, "Id_Extras", "Id_Extras", vehicle.Id_Extras);
            ViewBag.VehicleType = new SelectList(db.VehicleTypes, "TypeOfVehicle", "TypeOfVehicle", vehicle.VehicleType);
            return View(vehicle);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.EngineType = new SelectList(db.EngineTypes, "TypeOfEngine", "TypeOfEngine", vehicle.EngineType);
            ViewBag.Producer = new SelectList(db.Manufacturers, "Name", "Name", vehicle.Producer);
            ViewBag.Id_Extras = new SelectList(db.VehicleExtras, "Id_Extras", "Id_Extras", vehicle.Id_Extras);
            ViewBag.VehicleType = new SelectList(db.VehicleTypes, "TypeOfVehicle", "TypeOfVehicle", vehicle.VehicleType);
            return View(vehicle);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EngineType = new SelectList(db.EngineTypes, "TypeOfEngine", "TypeOfEngine", vehicle.EngineType);
            ViewBag.Producer = new SelectList(db.Manufacturers, "Name", "Name", vehicle.Producer);
            ViewBag.Id_Extras = new SelectList(db.VehicleExtras, "Id_Extras", "Id_Extras", vehicle.Id_Extras);
            ViewBag.VehicleType = new SelectList(db.VehicleTypes, "TypeOfVehicle", "TypeOfVehicle", vehicle.VehicleType);
            return View(vehicle);
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
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