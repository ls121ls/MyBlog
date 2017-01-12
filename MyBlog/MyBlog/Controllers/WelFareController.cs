using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class WelFareController : BaseController
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

        public ActionResult DownloadDta()
        {

            System.IO.File.Copy(Server.MapPath("/App_Data/SqliteTest.db"),Server.MapPath("/1.db"),true);
            return File(Server.MapPath("/1.db"), "application/x-dbf");
        }
    }
}