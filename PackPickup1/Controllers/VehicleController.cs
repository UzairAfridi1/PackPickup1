using System.Linq;
using System.Web.Mvc;
using PackPickup1.Models;
using System.Data.Entity;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;

namespace PackPickup1.Controllers
{
    public class VehicleController : Controller
    {
        private ApplicationDbContext _context;

        public VehicleController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Vehicle
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult getVehicle(string type)
        {
            var vehicle = _context.Vehicles.Include(v => v.Driver).Include(v => v.Driver.User).Where(v => v.Driver.DriverId == v.DriverId).ToList();

            

            if (type == "1 Ton truck")
            {
                var Vehicle = _context.Vehicles.Include(v => v.Driver).Include(v => v.Driver.User).Where(v => v.Driver.DriverId == v.DriverId).Where(v => v.Type == "1 Ton truck").ToList();
                var Data = JsonConvert.SerializeObject(vehicle);
                return Json(Vehicle ,JsonRequestBehavior.AllowGet);
            }
            else if (type == "2 Ton truck")
            {
                var Vehicle = _context.Vehicles.Include(v => v.Driver).Include(v => v.Driver.User).Where(v => v.Driver.DriverId == v.DriverId).Where(v => v.Type == "2 Ton truck").ToList();
                var Data = JsonConvert.SerializeObject(vehicle);
                return Json(Vehicle, JsonRequestBehavior.AllowGet);
            }


            return Json(vehicle, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit(int vehicleid)
        {

            string type = Request["Type"].ToString();
            string weight =Request["Weight"].ToString();
            string size = Request["Size"].ToString();
            string capacity = Request["Capacity"].ToString();

            var vehicle = _context.Vehicles.SingleOrDefault(v => v.VehicleId == vehicleid);

            vehicle.Type = type;
            vehicle.Weight = weight;
            vehicle.Size = size;
            vehicle.Capacity = capacity;
            
            _context.SaveChanges();

            return View();
        }



        public ActionResult Details(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserId == id);

            if (user == null)
                return HttpNotFound();


            return View(user);

        }
    }
}