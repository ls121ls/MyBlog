using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Common;
using MyBlog.BLL;
using MyBlog.Model;

namespace MyBlog.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.NewBlogs = service.BlogBLL.GetNewBlogs();
            ViewBag.ClickBlogs = service.BlogBLL.GetClickBlogs();
            ViewBag.RecommendBlogs = service.BlogBLL.GetReCommendBlogs();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


        public JsonResult QQCheck(QQModel qqInfo)
        {
            bool result = false;
            if (!String.IsNullOrEmpty(qqInfo.Name) && !String.IsNullOrEmpty(qqInfo.OpenId) &&
                !String.IsNullOrEmpty(qqInfo.AccessToken))
            {
                QQModel qqModel = service.QQModelBLL.GetEntities(d => d.OpenId == qqInfo.OpenId).FirstOrDefault();
                if (qqModel == null)
                {
                    qqInfo.EndDataTime = DateTime.Now;
                    qqInfo.Count = 1;
                    service.QQModelBLL.AddEntity(qqModel);
                    result = true;
                }
                else
                {
                    if ((qqInfo.EndDataTime - qqModel.EndDataTime).TotalMinutes < 1)
                    {
                        return Json(result);
                    }
                    qqModel.Name = qqInfo.Name;
                    qqModel.FigureUrl = qqInfo.FigureUrl;
                    qqModel.EndDataTime = DateTime.Now;
                    qqModel.Count += 1;
                    service.QQModelBLL.UpdateEntity(qqModel);
                    result = true;
                }
            }
            return Json(result);
        }

        public ActionResult Record()
        {
            string result = "";
            if (Request.Files.Count > 0)
            {
                result = "/Record/" + Guid.NewGuid()+".wmv";
                Request.Files[0].SaveAs(Server.MapPath(result));
            }
            return Content(result);
        }



        public ActionResult News()
        {
            ViewBag.ClickBlogs = service.BlogBLL.GetClickBlogs();
            ViewBag.RecommendBlogs = service.BlogBLL.GetReCommendBlogs();
            return PartialView();
        }

        public JsonResult GetFromBd()
        {
            var s = Request["city"];
            var str = "http://api.map.baidu.com/telematics/v3/weather?location=" + s + "&output=json&ak=DGI9qEYfl5E9lRloHIl8pewn";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(str);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            string result = new StreamReader(stream, System.Text.Encoding.UTF8).ReadToEnd();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ErrorTest()
        {
            throw new Exception("test exception");
        }



        public ActionResult Test()
        {
            return Content(System.AppDomain.CurrentDomain.BaseDirectory);
        }

    }
}