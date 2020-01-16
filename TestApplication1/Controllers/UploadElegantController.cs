using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApplication1.Models;
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
                
                Employee employeeObject = new Employee()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Section = employee.Section
                };

                string uploadFolder = Request.PhysicalApplicationPath + "Uploads\\";

                if (employee.First != null)
                {
                    string filename = employee.Id + "-activity-master";
                    string fileExtension = Path.GetExtension(employee.First.FileName);
                    string fullFilePath = uploadFolder + filename + fileExtension;
                    employee.First.SaveAs(fullFilePath);
                }

                if (employee.Second != null)
                {
                    string filename2 = employee.Id + "-jv-template-Master";
                    string fileExtension2 = Path.GetExtension(employee.Second.FileName);
                    string fullFilePath = uploadFolder + filename2 + fileExtension2;
                    employee.First.SaveAs(fullFilePath);
                }

                return Json(new { success = true, responseText = "Data recieved Successfully" });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, responseText = ex.StackTrace });
            }
        }
    }
}