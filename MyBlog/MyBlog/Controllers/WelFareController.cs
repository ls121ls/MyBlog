using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class WelFareController : Controller
    {
        // GET: WelFare
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult OnLinePlay()
        {
            return View();
        }
    }
}