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
        public ActionResult Index(int id=0)
        {
            ViewBag.BlogTypes = service.BlogTypeBLL.GetEntities(d=>d.ParentId==id).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            BlogType model = new BlogType();
            TryUpdateModel(model);
            model.OrderId = 1;
            service.BlogTypeBLL.AddEntity(model);



            GetViewBag();
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
            GetViewBag();
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


        public void GetViewBag()
        {
            ViewBag.BlogTypes = service.BlogTypeBLL.GetAllEntities().ToList();
        }
    }
}