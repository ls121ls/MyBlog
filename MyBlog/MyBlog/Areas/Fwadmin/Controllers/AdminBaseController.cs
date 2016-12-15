using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Common;
using MyBlog.BLL;
using MyBlog.Model;

namespace MyBlog.Areas.Fwadmin.Controllers
{
    public class AdminBaseController : Controller
    {
        public ServiceRepository service = new ServiceRepository();


        public AdminBaseController()
        {

            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated == false)
            {
                System.Web.HttpContext.Current.Response.Redirect("/Account/Login");
                System.Web.HttpContext.Current.Response.End();
            }
            else
            {
                Account account = service.AccountBLL.GetUserByLoginName(System.Web.HttpContext.Current.User.Identity.Name);
                CallContext.SetData("Account", account);
            }
            if (System.Web.HttpContext.Current.Request.Cookies["username"] == null)
            {
                WebSite webSiter = new WebSite();
                webSiter.Ip = WebSiteHelper.GetIP();
                webSiter.City = WebSiteHelper.GetCityFromIp(webSiter.Ip);
                webSiter.AccessTime = DateTime.Now;
                service.WebSiteBLL.AddEntity(webSiter);
                System.Web.HttpContext.Current.Response.Cookies["username"].Value = "hz";
                System.Web.HttpContext.Current.Response.Cookies["username"].Expires = DateTime.Now.AddDays(0.5);
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //
            //            if (Session["LoginUser"] == null&& (Request.Cookies["user"]==null||Request.Cookies["user"].Value!="admin"))
            //            {
            //                Response.Redirect("/Fwadmin/Account/Login");
            //            }

            base.OnActionExecuting(filterContext);
        }
    }
}