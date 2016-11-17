using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyBlog.Filters
{
    public class PermissionValidateAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["CurrentUser"] == null)
            {
                if (HttpContext.Current.Request.Cookies["User"] == null)
                {
                    HttpContext.Current.Response.Redirect("/Fwadmin/Account/Login");
                }
                else
                {
//                    ModelDBContainer db = new ModelDBContainer();
//                    HttpContext.Current.Session["Account"] = db.Account.Find(Convert.ToInt32(HttpContext.Current.Request.Cookies["User"].Value));
                }
            }
        }

        private bool IsLogin()
        {
            if (HttpContext.Current.Session["User"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}