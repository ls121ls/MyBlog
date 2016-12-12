using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Model;

namespace MyBlog.Controllers
{
    public class ImageController : BaseController
    {
        // GET: Image
        public ActionResult Index(int folderId)
        {
            int count;
            ViewBag.Images = service.ImageModelBLL.LoadPageEntities(d=>d.Src!=""&&d.FolderId==folderId,d=>d.ImageModelId , 8, 1,out count, true);
            ViewBag.Count = count;
            return View();
        }

        public JsonResult GetMoreImages(int pageIndex)
        {
            int count;
            var data = service.ImageModelBLL.LoadPageEntities(d => d.Src != "", d => d.ImageModelId, 8, pageIndex, out count, true);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}