using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyBlog.BLL;
using MyBlog.Model;

namespace MyBlog.Areas.Fwadmin.Controllers
{
    public class AccountController : AdminBaseController
    {
        // GET: Fwadmin/Account
        public ActionResult Index()
        {
            ViewBag.Models = service.AccountBLL.GetEntities(d => d.IsDelete == false).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            Account model = new Account();
            TryUpdateModel(model);
            if (String.IsNullOrEmpty(model.AccountName) || String.IsNullOrEmpty(model.Password))
            {
                ViewBag.Models = service.AccountBLL.GetEntities(d => d.IsDelete == false).ToList();
                return View();
            }
            if (service.AccountBLL.GetEntities(d => d.AccountName == model.AccountName).Count > 0)
            {
                ViewBag.Models = service.AccountBLL.GetEntities(d => d.IsDelete == false).ToList();
                return View();
            }
            model.CreateDate = DateTime.Now;
            model.LastTime = DateTime.Now;
            model.IsDelete = false;
            model.IsShow = true;
            model.Count = 1;
            service.AccountBLL.AddEntity(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = service.AccountBLL.GetEntity(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var model = service.AccountBLL.GetEntity(id);
                TryUpdateModel(model);
                model.IsShow = (Request["isshow"] == "1");
                service.AccountBLL.UpdateEntity(model);
                return View("Successed");
            }
            catch (Exception)
            {

                var model = service.AccountBLL.GetEntity(id);
                return View(model);
            }
        }


        public ActionResult Delete(int id)
        {
            var model = service.AccountBLL.GetEntity(id);
            model.IsDelete = true;
            service.AccountBLL.UpdateEntity(model);
            return Json("1", JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChangeShow(int id)
        {
            var model = service.AccountBLL.GetEntity(id);
            model.IsShow = !model.IsShow;
            service.AccountBLL.UpdateEntity(model);
            return Json("1", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login()
        {
            if (!service.AccountBLL.GetAllEntities().Any())
            {
                Account model = new Account();
                model.Type = 1;
                model.AccountName = "jyadmin";
                model.Password = "123456";
                model.CreateDate = DateTime.Now;
                model.LastTime = DateTime.Now;
                model.IsDelete = false;
                model.IsShow = true;
                model.Count = 1;
                service.AccountBLL.AddEntity(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            Account account = new Account();
            TryUpdateModel(account);
            if (
                service.AccountBLL.GetEntities(
                    d => d.AccountName == account.AccountName && d.Password == account.Password && d.Type == 1 && d.IsDelete == false && d.IsShow).Count == 1)
            {
                HttpContext.Session.Add("CurrentAccount", "admin");
                HttpContext.Response.Cookies.Add(new HttpCookie("user", "admin"));
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}