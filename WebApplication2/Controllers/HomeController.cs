using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private Logger logger =
            LogManager.GetCurrentClassLogger();

        public ActionResult Index()
        {
            ViewBag.Message = "Heelo";

            logger.Error("Test Error");

            return View("TestView");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GroupTest()
        {
            return View();
        }

        public ActionResult TestView()
        {
            return View();
        }

        
        public ActionResult TestPartialView()
        {
            return PartialView("");
        }
    }
}