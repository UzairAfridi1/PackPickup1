using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using PackPickup1.Models;
using PackPickup1.ViewModels;

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
        public ActionResult New()
        {
            var user = _context.Users.ToList();
            var viewmodel = new DriverViewModel
            {
                User = user,
                Driver =new Driver()

            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Save(Driver driver)
        {
            if(driver.DriverId == 0)
             _context.Drivers.Add(driver);
            else
            {
                var driverInDb = _context.Drivers.Single(d => d.DriverId == driver.DriverId);

                driverInDb.Nationality = driver.Nationality;
                driverInDb.Language = driver.Language;
                driverInDb.Area = driver.Area;
                driverInDb.DateOfBirth = driver.DateOfBirth;
                driverInDb.PhotoId = driver.PhotoId;

            }
            _context.SaveChanges();
            return RedirectToAction("Index" , "Driver");
        }          
        // GET: Driver
        [HttpGet]
        public ActionResult Index()
        {

            var driver = _context.Drivers.Include(u => u.User).ToList();

            return View(driver);
        }

        public  ActionResult Edit(int id)
        {
            var driver = _context.Drivers.SingleOrDefault(d => d.DriverId == id);

            if (driver == null)
                return HttpNotFound();

            var user = _context.Users.ToList();
            var viewmodel = new DriverViewModel
            {
                Driver = driver,
                User = user,
            };

            return View("New", viewmodel);
        }
    }
}