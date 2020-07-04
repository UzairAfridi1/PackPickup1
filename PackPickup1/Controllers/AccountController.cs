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

            else if (users.RoleType.ToLower() == "Driver")
            {
                Session["username"] = users.Name;
                Session["User"] = users;
                Session["userid"] = users.UserId;
                return RedirectToAction("Index", "Home");
            }
            else
                return HttpNotFound();

        }

        public ActionResult Registration()
        {
            return View();
        }

      public ActionResult Save(User user)
        {
            if (!ModelState.IsValid)
            {
                var users = user;
                return View("Registration", users);
            }

            if (user == null)
            {
                return HttpNotFound();
            }
            else
            {
                user.RoleType = "Driver";
                _context.Users.Add(user);
                _context.SaveChanges();
            }

            Session["userid"] = user.UserId;
            return RedirectToAction("Login");
                
        }
    }
}