using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApplication1.ViewModel;

namespace TestApplication1.Controllers
{
    public class UploadElegantController : Controller
    {
        // GET: UploadElegant
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadData(EmployeeViewModel employee)
        {
            try
            {

                string firstName = "", secondName = "";
                uint sId = employee.Id;
                string Name = employee.Name;
                string sclass = employee.Section;

                if (employee.First.ContentLength > 0)
                {
                     firstName = Path.GetFileName(employee.First.FileName);
                     string pathToSave = Server.MapPath("~/Uploads/Entity");
                     string filename = Path.GetFileName(firstName);
                    employee.First.SaveAs(Path.Combine(pathToSave, filename));
                }
                
                if (employee.Second.ContentLength > 0)
                {
                     secondName = Path.GetFileName(employee.Second.FileName);
                     string pathToSave = Server.MapPath("~/Uploads/JV");
                     string filename2 = Path.GetFileName(secondName);
                    employee.Second.SaveAs(Path.Combine(pathToSave, filename2));
                }

                return Json(new { success = true, responseText = "Sudent Data  recieved Successfully" });
            }
            catch (Exception ex){

                return Json(new { success = false, responseText = ex.StackTrace });
            }
        }
    }
}