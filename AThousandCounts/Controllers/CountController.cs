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
  
            return View();
        }

        public ActionResult CreateVideo()
        {
           
            return View();  

        }

        [HttpPost]
        public ActionResult GetIPAddress()
        {
            var ipAddress = System.Web.HttpContext.Current.Request.UserHostName;

            var countModel = new CountModel
            {
                IPAddress = ipAddress,
                WebcamVideo = new WebcamVideo(),
            };

            db.Counts.Add(countModel);
            db.SaveChanges();

            return View();
        }

    }
}