using System.Web.Mvc;

namespace MyBlog.Areas.Fwadmin
{
    public class FwadminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Fwadmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Fwadmin_default",
                "Fwadmin/{controller}/{action}/{id}",
                new {Controller="Home", action = "Index", id = UrlParameter.Optional },
                new string[] {"MyBlog.Areas.Fwadmin.Controllers"}
            );
        }
    }
}