using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PackPickup1.Models;
using PackPickup1.ViewModels;
using System.Data.Entity;


namespace PackPickup1.Controllers
{
   
    public class AccountController : Controller
    {
        private ApplicationDbContext _context;

        public AccountController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountViewModel user)
        {
            if (!ModelState.IsValid)
            {
                var User = user;
                return View("Index", User);
            }
            var users = _context.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();

            if (users == null)
                return HttpNotFound();

            else if (users.RoleType.ToLower() == "driver")
            {
                Session["username"] = users.Name;
                Session["User"] = users;
                Session["userid"] = users.UserId;
                return RedirectToAction("Index", "Home");
            }
            else if (users.RoleType.ToLower() == "customer")
            {
                Session["username"] = users.Name;
                Session["User"] = users;
                Session["userid"] = users.UserId;
                return RedirectToAction("Index", "Home");
            }
            else
                return HttpNotFound();

        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
      public ActionResult Save(User user)
        {
            if (!ModelState.IsValid)
            {
                var users = user;
                return View("Registration", users);
            }

            if (user == null)
            {
                user.UserId = 0;           
            }
            else
            {
                var userid = _context.Users.Max(u => u.UserId + 1);
                user.UserId = userid;
                user.RoleType = "Driver";
                _context.Users.Add(user);
                _context.SaveChanges();
            }

            Session["userid"] = user.UserId;
            return RedirectToAction("Driver");
                
        }

        [HttpGet]
        public ActionResult Driver()
        {
            var user = _context.Users.ToList();
            var country = _context.Countries.ToList();
            var state = _context.States.ToList();
            var city = _context.Cities.ToList();

            var viewmodel = new DriverViewModel
            {
                Countries =country,
                States =state,
                Cities =city,
                User =user,
                Driver =new Driver()
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult AddDriver(Driver driver)
        {
            int userid = int.Parse(Session["userid"].ToString());
            var user = _context.Users.Where(u => u.UserId == userid).SingleOrDefault();

            driver.UserId = user.UserId;

            var driverid = _context.Drivers.DefaultIfEmpty().Max(d => d == null ? 0 : d.DriverId + 1);

            driver.DriverId = driverid;
            
            _context.Drivers.Add(driver);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public ActionResult RegisterCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveCustomer(User user)
        {
            if (!ModelState.IsValid)
            {
                var users = user;
                return View("Registration", users);
            }

            if (user == null)
            {
                user.UserId = 0;
            }
            else
            {
                var userid = _context.Users.Max(u => u.UserId + 1);
                user.UserId = userid;
                user.RoleType = "Customer";
                _context.Users.Add(user);
                _context.SaveChanges();
            }

            Session["userid"] = user.UserId;
            return RedirectToAction("Customer");

        }

        [HttpGet]
        public ActionResult Customer()
        {
            var user = _context.Users.ToList();
            var country = _context.Countries.ToList();
            var state = _context.States.ToList();
            var city = _context.Cities.ToList();

            var viewmodel = new CustomerViewModel
            {
                Countries =country,
                States =state,
                Cities =city,
                Users =user,
                Customer =new Customer()
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            int userid = int.Parse(Session["userid"].ToString());
            var user = _context.Users.Where(u => u.UserId == userid).SingleOrDefault();

            customer.UserId = user.UserId;

            var customerid = _context.Customers.DefaultIfEmpty().Max(d => d == null ? 0 : d.CustomerId + 1);

            customer.CustomerId = customerid;
            customer.IsDeleted = false;

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
    }

}