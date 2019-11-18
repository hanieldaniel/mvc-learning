using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApplication1.Models;

namespace TestApplication1.ViewModel
{
    public class EmployeeViewModel
    {
        public UInt32 Id { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }
        public HttpPostedFileBase First { get; set; }
        public HttpPostedFileBase Second { get; set; }
    }
}