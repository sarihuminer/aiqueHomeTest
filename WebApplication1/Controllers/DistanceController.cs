using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class DistanceController : Controller
    {
        // GET: Distance
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            ViewBag.Message = "Address: " + form["txtAddress"];
            ViewBag.Message += "\\nLatitude: " + form["txtLatitude"];
            ViewBag.Message += "\\nLongitude: " + form["txtLongitude"];
            return View();
        }
    }
}