﻿using System.Linq;
using System.Web.Mvc;
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
            return View();
        }
        [HttpPost]
        public ActionResult Save(Driver driver)
        {
            if(driver.DriverId == 0)
             _context.Drivers.Add(driver);
            else
            {
                var driverInDb = _context.Drivers.Single(d => d.DriverId == driver.DriverId);

                driverInDb.Name = driver.Name;
                driverInDb.Nationality = driver.Nationality;
                driverInDb.Language = driver.Language;
                driverInDb.Country = driver.Country;
                driverInDb.City = driver.City;
                driverInDb.Area = driver.Area;
                driverInDb.DateOfBirth = driver.DateOfBirth;
                driverInDb.PhotoId = driver.PhotoId;

            }
            _context.SaveChanges();
            return RedirectToAction("New" , "Driver");
        }          
        // GET: Driver
        [HttpGet]
        public ActionResult Index()
        {

            var driver = _context.Drivers.ToList();

            return View(driver);
        }

        public  ActionResult Edit(int id)
        {
            var driver = _context.Drivers.SingleOrDefault(d => d.DriverId == id);

            if (driver == null)
                return HttpNotFound();

            var photo = _context.Photos.ToList();
            var viewmodel = new DriverViewModel
            {
                Driver = driver,
                Photos = photo,
            };

            return View("New", viewmodel);
        }
    }
}