using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Model;

namespace MyBlog.Controllers
{
    public class MessageController : BaseController
    {
        // GET: Message
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Levae()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Levae(FormCollection collection)
        {
            Message message = new Message();
            TryUpdateModel(message);
            service.MessageBLL.AddEntity(message);
            return View();
        }
    }
}