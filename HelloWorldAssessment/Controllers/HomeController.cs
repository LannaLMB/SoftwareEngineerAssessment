using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldAssessment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Project Overview";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Lanna Brasure - Computer Software Engineer";

            return View();
        }

        public ActionResult RegistrationForm()
        {
            return View();
        }


    }
}