using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using MyBlog.BLL;
using MyBlog.Model;

namespace MyBlog.Controllers
{
    public class BaseController : Controller
    {
        public ServiceRepository service = new ServiceRepository();

        public BaseController()
        {
            if (System.Web.HttpContext.Current.Request.Cookies["username"] == null)
            {
                WebSite webSiter = new WebSite();
                webSiter.Ip = WebSiteHelper.GetIP();
                webSiter.City = WebSiteHelper.GetCityFromIp(webSiter.Ip);
                webSiter.AccessTime = DateTime.Now;
                service.WebSiteBLL.AddEntity(webSiter);
                System.Web.HttpContext.Current.Response.Cookies["username"].Value = "ls";
                System.Web.HttpContext.Current.Response.Cookies["username"].Expires = DateTime.Now.AddDays(0.5);
            }
        }
    }
}