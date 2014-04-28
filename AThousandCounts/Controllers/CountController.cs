using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AThousandCounts.Models;
using System.Data.Entity;

namespace AThousandCounts.Controllers
{
    public class CountController : Controller
    {
        CountContext db;

        public CountController()
        {
            this.db = new CountContext();
        }

        public ActionResult Index()
        {
            var r = new Random();
            var number = 0;
            var counts = db.Counts.Where(c => c.Completed == false).ToList();
            var countsLeft = counts.Count();

            if (countsLeft > 0)
            {
                number = counts.ElementAt(r.Next(1, countsLeft)).Count;
            }

            ViewBag.CountsLeft = countsLeft;
            return View(number);
        }

        [HttpPost]
        public PartialViewResult WebCam()
        {
            return PartialView("_WebCam");
        }

        [HttpPost]
        public void CompleteCount(int id)
        {
            var ipAddress = System.Web.HttpContext.Current.Request.UserHostName;
            var count = db.Counts.Where(c => c.Count == id).FirstOrDefault();

            count.IPAddress = ipAddress;
            count.Completed = true;

            db.Counts.Attach(count);
            db.Entry(count).Property(c => c.IPAddress).IsModified = true;
            db.Entry(count).Property(c => c.Completed).IsModified = true;
            
            db.SaveChanges();
        }

    }
}