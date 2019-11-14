using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApplication1.Models;


namespace TestApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var Student = new Student()
            {
                Name = "Haniel"
            };
            return View(Student);
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

        [HttpGet]
        public ActionResult ChangeContent(string selected)
        {
            Console.WriteLine("selected");

            return Content("This is a changed section:" + selected);
        }
    }
}