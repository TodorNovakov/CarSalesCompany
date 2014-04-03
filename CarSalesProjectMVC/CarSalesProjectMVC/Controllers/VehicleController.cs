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
    public class VehicleController : Controller
    {
        private CarSalesCompanyEntities db = new CarSalesCompanyEntities();

        //
        // GET: /Vehicle/

        public ActionResult Index()
        {
            var vehicles = db.Vehicles.Include(v => v.EngineType1).Include(v => v.Manufacturer).Include(v => v.VehicleExtra).Include(v => v.VehicleType1).Where(v=>v.Sold==false);
            return View(vehicles.ToList());
        }

        //
        // GET: /Vehicle/Details/5

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
        // GET: /Vehicle/Create

        public ActionResult Create()
        {
            ViewBag.EngineType = new SelectList(db.EngineTypes, "TypeOfEngine", "TypeOfEngine");
            ViewBag.Producer = new SelectList(db.Manufacturers, "Name", "Name");
            ViewBag.Id_Extras = new SelectList(db.VehicleExtras, "Id_Extras", "Id_Extras");
            ViewBag.VehicleType = new SelectList(db.VehicleTypes, "TypeOfVehicle", "TypeOfVehicle");
            return View();
        }

        //
        // POST: /Vehicle/Create

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
        // GET: /Vehicle/Edit/5

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
        // POST: /Vehicle/Edit/5

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
        // GET: /Vehicle/Delete/5

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
        // POST: /Vehicle/Delete/5

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