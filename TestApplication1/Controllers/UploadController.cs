using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApplication1.Models;

namespace TestApplication1.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        //File upload Function
        [HttpPost]
        //public ActionResult Uploading(Student student)
        public ActionResult Uploading(HttpPostedFileBase first, HttpPostedFileBase second)
        {

            try
            {
                string firstName = "";
                string secondName = "";
                //string Name = student.Name;



                if (first.ContentLength > 0)
                {
                    firstName = Path.GetFileName(first.FileName);
                    string pathToSave = Server.MapPath("~/App_Data/Uploads/Entity");
                    string filename = Path.GetFileName(firstName);
                    first.SaveAs(Path.Combine(pathToSave, filename));
                }
                if (second.ContentLength > 0)
                {
                    secondName = Path.GetFileName(second.FileName);
                    string pathToSave = Server.MapPath("~/App_Data/Uploads/JV");
                    string filename = Path.GetFileName(secondName);
                    second.SaveAs(Path.Combine(pathToSave, filename));
                }

                return Json(new { success = true, responseText = "Sudent Data  recieved Successfully" });
            }
            catch
            {
                return Json(new { success = false, responseText = "Request failed" });
            }

        }
    }
}