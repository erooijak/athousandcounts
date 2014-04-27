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
            var counts = db.Counts.Where(c => c.Completed == false).ToList();
            var count = counts.ElementAt(r.Next(1, counts.Count()));
   
            return View(count.Count);
        }

        public void SaveIPAddress(CountModel count)
        {
            var ipAddress = System.Web.HttpContext.Current.Request.UserHostName;

            db.Counts.Attach(count);
            db.Entry(count).Property(c => c.IPAddress).IsModified = true;
            
            db.SaveChanges();
        }

    }
}