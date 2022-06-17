using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task_1.Web_Api_to_return_data_to_client_apps_systems.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext data = new AppDbContext();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
