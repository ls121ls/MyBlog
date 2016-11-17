using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class FolderController : BaseController
    {
        // GET: Folder
        public ActionResult Index()
        {
            ViewBag.Folders = service.FolderBLL.GetAllEntities();
            return View();
        }
    }
}