using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Model;

namespace MyBlog.Controllers
{
    public class BlogController : BaseController
    {
        // GET: Blog
        public ActionResult Index()
        {
            int typeId = Convert.ToInt32(Request["typeId"]);
            int pageSize = 10;
            int pageInex = 1;
            int blogCount = 0;
            ViewBag.Blogs = service.BlogBLL.LoadPageEntities(d => d.IsActive&&d.IsChecked&&d.BlogTypeId==typeId, o => o.BlogId, pageSize, pageInex,
                out blogCount, true);
            return View();
        }

        public ActionResult Detail(int id)
        {
            Blog blog = service.BlogBLL.GetEntity(id);
            blog.ClickCount++;
            service.BlogBLL.AddClickCount(blog.BlogId);
            
            ViewBag.UpBlog = service.BlogBLL.GetUpBlog(id);
            ViewBag.DownBlog = service.BlogBLL.GetDownBlog(id);
            return View(blog);
        }
    }
}