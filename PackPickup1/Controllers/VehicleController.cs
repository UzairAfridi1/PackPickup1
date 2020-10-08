using System.Linq;
using System.Web.Mvc;
using PackPickup1.Models;
using System.Data.Entity;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using PackPickup1.ViewModels;
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
        [HttpPost]
        public ActionResult Create(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public JsonResult getVehicle(string type)
        {

            var vehicle = _context.Vehicles.Include(v =>v.Photo).Include(v => v.Driver).Include(v => v.Driver.User).Where(v => v.Driver.DriverId == v.DriverId).Where(v => v.Type == type).ToList();

            return Json(vehicle, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit(int vehicleid)
        {

            string type = Request["Type"].ToString();
            string weight =Request["Weight"].ToString();
            string size = Request["Size"].ToString();
            string capacity = Request["Capacity"].ToString();
            //string Image = Request["Photo.Image"].ToString();

            var vehicle = _context.Vehicles.SingleOrDefault(v => v.VehicleId == vehicleid);

            vehicle.Type = type;
            vehicle.Weight = weight;
            vehicle.Size = size;
            vehicle.Capacity = capacity;
            //vehicle.Photo.Image = Image;
            
            _context.SaveChanges();

            return View();
        }
        [HttpGet]
        public JsonResult FilterType()
        {
            var data = _context.Vehicles.Select(v => v.Type);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ListView(string type)
        {
            ViewBag.type = type;
            return View();
        }
        [HttpPost]
        public JsonResult GetDriver(int id)
        {
            var driver = _context.Drivers.Include(v=> v.User).Include(v => v.Country).Include(v => v.State).Include(v => v.City).Where(v => v.DriverId == id).SingleOrDefault();
            return Json(driver ,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserId == id);

            if (user == null)
                return HttpNotFound();


            return View(user);

        }

        public ActionResult ComingSoon()
        {
            return View();
        }
    }
}