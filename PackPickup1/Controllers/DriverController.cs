using Newtonsoft.Json;
using PackPickup1.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace PackPickup1.Controllers
{
    public class DriverController : Controller
    {
        private ApplicationDbContext _context;

        public DriverController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //public ActionResult New()
        //{
        //    var user = _context.Users.ToList();
        //    var json = JsonConvert.SerializeObject(user);
        //    var viewmodel = new DriverViewModel
        //    {
        //        User = user,
        //        Driver = new Driver()

        //    };
        //    return View(viewmodel);
        //}
        //[HttpPost]
        //public ActionResult Save(Driver driver)
        //{
        //    if (driver.DriverId == 0)
        //        _context.Drivers.Add(driver);
        //    else
        //    {
        //        var driverInDb = _context.Drivers.Single(d => d.DriverId == driver.DriverId);

        //        driverInDb.Nationality = driver.Nationality;
        //        driverInDb.Language = driver.Language;
        //        driverInDb.Area = driver.Area;
        //        driverInDb.DateOfBirth = driver.DateOfBirth;

        //    }
        //    _context.SaveChanges();
        //    return Json(driver, JsonRequestBehavior.AllowGet);
        //}
        // GET: Driver
        [HttpGet]
        public ActionResult Index()
        {

            return View();


        }

        [HttpGet]
        public JsonResult getDriver()
        {
            var driver = _context.Drivers.Include(u => u.User).ToList();
            var data = JsonConvert.SerializeObject(driver);
            return Json(driver, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit(int Driverid)
        {
            string nationality = Request["Nationality"].ToString();
            string language = Request["Language"].ToString();
            string name = Request["User[Name]"].ToString();
            DateTime birthday = Convert.ToDateTime(Request["DateOfBirth"].ToString());

            var driver = _context.Drivers.Include(u => u.User).SingleOrDefault(d => d.DriverId == Driverid);

            driver.Nationality = nationality;
            driver.Language = language;
            driver.DateOfBirth = birthday;
            driver.User.Name = name;

            _context.SaveChanges();

            return View();
        }
        
    }
}