using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Model;

namespace MyBlog.Areas.Fwadmin.Controllers
{
    public class BlogTypeController : AdminBaseController
    {
        // GET: Fwadmin/BlogType
        public ActionResult Index()
        {
            List<BlogType> blogTypes = service.BlogTypeBLL.GetAllEntities().ToList();
            ViewBag.BlogTypes = blogTypes;
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            BlogType model = new BlogType();
            TryUpdateModel(model);
            model.OrderId = 1;
            service.BlogTypeBLL.AddEntity(model);


            List<BlogType> blogTypes = service.BlogTypeBLL.GetAllEntities().ToList();
            ViewBag.BlogTypes = blogTypes;
            return View();
        }

        public JsonResult Create()
        {
            BlogType model = new BlogType();
            TryUpdateModel(model);
            model.OrderId = 1;
            service.BlogTypeBLL.AddEntity(model);
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