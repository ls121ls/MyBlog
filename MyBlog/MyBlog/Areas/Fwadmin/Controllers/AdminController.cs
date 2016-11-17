using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using MyBlog.BLL;
using MyBlog.Model;

namespace MyBlog.Areas.Fwadmin.Controllers
{
    public class AdminController : Controller
    {
        public ServiceRepository service = new ServiceRepository();

        public AdminController()
        {
          
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