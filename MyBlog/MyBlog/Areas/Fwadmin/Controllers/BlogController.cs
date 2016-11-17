using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using MyBlog.Model;

namespace MyBlog.Areas.Fwadmin.Controllers
{
    public class BlogController : AdminController
    {
        // GET: Blog
        public ActionResult Index()
        {
            int pageSize = 10;
            int pageInex = 1;
            int blogCount = 0;
            ViewBag.Blogs = service.BlogBLL.LoadPageEntities(d => d.IsActive, o => o.BlogId, pageSize, pageInex,
                out blogCount, true);
            ViewBag.BlogCount = blogCount;
            return View();
        }

        public ActionResult Create()
        {
            List<BlogType> blogTypes = service.BlogTypeBLL.GetAllEntities().ToList();
            ViewBag.BlogTypes = new SelectList(blogTypes, "BlogTypeId", "Value");
            return PartialView();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(FormCollection collection)
        {
            Blog blog = new Blog();
            TryUpdateModel(blog);
            DateTime dt = DateTime.Now;
            blog.CreateDate = dt;
            blog.EditDate = dt;
            blog.ImgUrl = UploadImage(blog.ImgUrl);
            service.BlogBLL.AddEntity(blog);
            return View("Successed");
        }


        public string UploadImage(string url)
        {
            HttpPostedFileBase image = Request.Files["ImgUrl"];
            if (image != null && image.ContentLength > 0&&(image.FileName.EndsWith(".jpg")|| image.FileName.EndsWith(".png")|| image.FileName.EndsWith(".bmp")))
            {
                string fileName = DateTime.Now.ToString("yyyyMMdd") + "-" + Path.GetFileName(image.FileName);
                string filePath = Path.Combine(Server.MapPath("~/Temp"), fileName);
                image.SaveAs(filePath);
                string filePath3 = "/UploadImages/" + HashEncode.GetMD5HashFromFile(filePath) +
                                   Path.GetExtension(filePath);
                string filePath2 = Server.MapPath(filePath3);
                System.IO.File.Copy(filePath,filePath2,true);
                System.IO.File.Delete(filePath);
                return filePath3;
            }
            return url;
        }

        public ActionResult Edit(int id)
        {
            Blog blog = service.BlogBLL.GetEntity(id);
            List<BlogType> blogTypes = service.BlogTypeBLL.GetAllEntities().ToList();
            ViewBag.BlogTypes = new SelectList(blogTypes, "BlogTypeId", "Value", blog.BlogTypeId);
            return PartialView(blog);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Blog blog = service.BlogBLL.GetEntity(id);
            TryUpdateModel(blog);
            DateTime dt = DateTime.Now;
            blog.EditDate = dt;
            blog.ImgUrl = UploadImage(blog.ImgUrl);
            service.BlogBLL.UpdateEntity(blog);
            return View("Successed");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Blog blog = service.BlogBLL.GetEntity(id);
            blog.IsActive = false;
            service.BlogBLL.UpdateEntity(blog);
            return Content("1");
        }
    }
}