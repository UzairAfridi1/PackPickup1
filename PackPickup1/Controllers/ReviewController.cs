using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PackPickup1.Models;

namespace PackPickup1.Controllers
{
    public class ReviewController : Controller
    {
        private  ApplicationDbContext _context;

        public ReviewController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Review
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveReview(Review obj)
        {
            obj.CustomerId = _context.Customers.Select(c => c.CustomerId).SingleOrDefault(); 
            obj.CreateAt = DateTime.Now;
            _context.Reviews.Add(obj);
            _context.SaveChanges();

            return Json("" , JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetReviews(int id)
        {
            var review = _context.Reviews.Where(r => r.DriverId == id).ToList();



            return Json(review ,JsonRequestBehavior.AllowGet);
        }
    }
}