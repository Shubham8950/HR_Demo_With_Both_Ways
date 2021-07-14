using HR_Demo_With_Both_Ways.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR_Demo_With_Both_Ways.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            DepartmentService obj = new DepartmentService();
            var list=obj.GetDEPARTMENTS();
            return View(list);
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
    }
}