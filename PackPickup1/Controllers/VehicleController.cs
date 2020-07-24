using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PackPickup1.Models;
using System.Data.Entity;



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
        public ActionResult Index(string type)
        {
            if (type == "1 Ton truck")
            {
                var vehicle = _context.Vehicles.Include(v => v.Driver).Include(v => v.Driver.User) .Where(v => v.Driver.DriverId == v.DriverId).Where(v => v.Type == "1 Ton truck").ToList();
                return View(vehicle);
            }
            else if (type == "2 Ton truck")
            {
                var vehicle = _context.Vehicles.Include(v => v.Driver).Include(v => v.Driver.User).Where(v => v.Driver.DriverId == v.DriverId).Where(v => v.Type == "2 Ton truck").ToList();
                return View(vehicle);
            }
            else
            {
                var vehicle = _context.Vehicles.Include(v => v.Driver).Include(v => v.Driver.User).Where(v => v.Driver.DriverId == v.DriverId).ToList();
                return View(vehicle);
            }

            
        }
    }
}