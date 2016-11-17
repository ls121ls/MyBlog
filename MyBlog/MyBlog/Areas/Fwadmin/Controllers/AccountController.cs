using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyBlog.Areas.Fwadmin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Fwadmin/Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            if (Request["name"] == "admin" && Request["password"] == "admin")
            {
                HttpContext.Session.Add("CurrentUser","admin");
                HttpContext.Response.Cookies.Add(new HttpCookie("user","admin"));
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}