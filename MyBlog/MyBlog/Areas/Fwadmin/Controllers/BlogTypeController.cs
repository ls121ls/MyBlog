using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Model;

namespace MyBlog.Areas.Fwadmin.Controllers
{
    public class BlogTypeController : AdminController
    {
        // GET: Fwadmin/BlogType
        public ActionResult Index()
        {
            List<BlogType> blogTypes = service.BlogTypeBLL.GetAllEntities().ToList();
            ViewBag.BlogTypes = blogTypes;
            return View();
        }

        public JsonResult Create(string value)
        {
            BlogType blogType = new BlogType();
            blogType.Value = value;
            service.BlogTypeBLL.AddEntity(blogType);
            return Json(1);
        }

        public ActionResult Edit(int id)
        {
            BlogType blogType = service.BlogTypeBLL.GetEntity(id);
            return PartialView(blogType);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            BlogType blogType = new BlogType();
            TryUpdateModel(blogType);
            service.BlogTypeBLL.UpdateEntity(blogType);
            return View("Successed");
        }
    }
}