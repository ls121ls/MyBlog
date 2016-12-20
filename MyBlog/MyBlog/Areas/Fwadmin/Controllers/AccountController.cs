using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyBlog.BLL;
using MyBlog.Model;

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
            Account account = new Account();
            TryUpdateModel(account);
            ServiceRepository service = new ServiceRepository();
            if (
             service.AccountBLL.GetEntities(
                 d => d.Name == account.Name && d.Password == account.Password).Count == 1)
            {
                HttpContext.Session.Add("CurrentAccount","admin");
                HttpContext.Response.Cookies.Add(new HttpCookie("user","admin"));
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}