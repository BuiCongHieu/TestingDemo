using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RatingDemoTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult _Nav()
        {
            return PartialView();
        }
    }
}