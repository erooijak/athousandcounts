using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AThousandCounts.Models;

namespace AThousandCounts.Controllers
{
    public class CountController : Controller
    {
        ICountContext db;

        public CountController()
        {
            this.db = new CountContext();
        }

        public CountController(ICountContext db)
        {
            this.db = db;
        }
        public ActionResult Index()
        {
            var r = new Random();
            var counts = db.Counts.Where(c => c.Completed == false).ToList();
            var count = counts.ElementAt(r.Next(1, counts.Count()));
   
            return View(count.Count);
        }

        public void SaveIPAddress(int count)
        {
            var ipAddress = System.Web.HttpContext.Current.Request.UserHostName;

            var countModel = new CountModel
            {
                IPAddress = ipAddress,
            };

            db.Counts.Add(countModel);
            db.SaveChanges();

        }

    }
}