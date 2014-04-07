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
    public class SearchVehicleController : Controller
    {
        private CarSalesCompanyEntities db = new CarSalesCompanyEntities();

        //
        // GET: /SearchVehicle/



        public ActionResult Index(string model,string producer,string vehicleType,string engine)
        {
            var producerList = new List<string>();

            var producerQuery = from pr in db.Manufacturers
                                orderby pr.Name
                                select pr.Name;
            producerList.AddRange(producerQuery);

            ViewBag.producer = new SelectList(producerList);

            var types = new List<String>();
            var typesQuery = from type in db.VehicleTypes
                             orderby type.TypeOfVehicle
                             select type.TypeOfVehicle;
            types.AddRange(typesQuery);
            ViewBag.vehicleType = new SelectList(types);

            var result = from vehicle in db.Vehicles
                         where vehicle.Sold==false
                         select vehicle;

            var engineList = new List<string>();

            var engineQuery=from e in db.EngineTypes
                            select e.TypeOfEngine;

            engineList.AddRange(engineQuery);

            ViewBag.engine = new SelectList(engineList);



            if (!String.IsNullOrEmpty(model))
            {
                result = result.Where(v => v.Model == model);
            }

            if (!String.IsNullOrEmpty(producer))
            {
                result = result.Where(v => v.Manufacturer.Name == producer);
            }

            if (!String.IsNullOrEmpty(vehicleType))
            {
                result = result.Where(v => v.VehicleType == vehicleType);
            }

            if (!String.IsNullOrEmpty(engine))
            {
                result = result.Where(v => v.EngineType ==engine);
            }

            return View(result);
        }

        //
        // GET: /SearchVehicle/Details/5

        public ActionResult Details(int id = 0)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}