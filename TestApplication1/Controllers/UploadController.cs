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
        public ActionResult Uploading(Student student)
        {

            try
            {
                string firstName = "";
                string secondName = "";
                uint sId = student.Id;
                string Name = student.Name;
                string sclass = student.Class;


                if (student.First.Length > 0)
                {
                    firstName = student.FirstName;
                    string[] splited = student.First.Split(',');
                    string b64 = splited[1];                 
                    string filePath = Server.MapPath("~/App_Data/Uploads/Entity/" + firstName);
                    byte[] imageBytes = Convert.FromBase64String(b64);
                    System.IO.File.WriteAllBytes(filePath, imageBytes);

                    /* firstName = Path.GetFileName(first.FileName);
                     string pathToSave = Server.MapPath("~/App_Data/Uploads/Entity");
                     string filename = Path.GetFileName(firstName);
                     first.SaveAs(Path.Combine(pathToSave, filename));*/
                }
                if (student.Second.Length > 0)
                {
                    secondName = student.SecondName;
                    string[] splited = student.Second.Split(',');
                    string b64 = splited[1];
                    string filePath = Server.MapPath("~/App_Data/Uploads/Entity/" + secondName);
                    byte[] imageBytes = Convert.FromBase64String(b64);
                    System.IO.File.WriteAllBytes(filePath, imageBytes);

                    /*  secondName = Path.GetFileName(second.FileName);
                      string pathToSave = Server.MapPath("~/App_Data/Uploads/JV");
                      string filename = Path.GetFileName(secondName);
                      second.SaveAs(Path.Combine(pathToSave, filename)); */
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