using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MyBlog.BLL;
using MyBlog.Model;

namespace MyBlog.Expand
{
    public static class MyHttpExtensions
    {
        private static ServiceRepository service = new ServiceRepository();
        public static string GetBlogTypes(this HtmlHelper helper, string name)
        {
            StringBuilder sb = new StringBuilder();
            var models=service.BlogTypeBLL.GetAllEntities();
            sb.Append($"<select class='select' id='sel_Sub' name='{name}' onChange='SetSubID(this);'><option value='0'>顶级分类</option>");
            foreach (var model in models.Where(d => d.ParentId == 0))
            {
                sb.Append("<option value='"+model.BlogTypeId+"'>├"+model.Value+"</option>");
                foreach (var m in models.Where(d => d.ParentId == model.BlogTypeId))
                {
                    sb.Append("<option value='" + m.BlogTypeId + "'>  ├" + m.Value + "</option>");
                }
            }
            sb.Append("</select>");
            return sb.ToString();
        }

        public static string GetBlogTypes(this HtmlHelper helper, string name,int id,bool isArticle=false)
        {
            StringBuilder sb = new StringBuilder();
            var mm = service.BlogTypeBLL.GetEntity(id);
            sb.Append($"<select class='select' id='sel_Sub' name='{name}' onChange='SetSubID(this);'>");
            if (isArticle)
            {
                var models = service.BlogTypeBLL.GetAllEntities().ToList();
                if (id == 0)
                {
                    sb.Append(RecBlogs(models, 0, 0, "&nbsp;&nbsp;"));
                }
                else
                {
                    sb.Append(RecBlogs(models, 0, mm.BlogTypeId, "&nbsp;&nbsp;"));
                }
            }
            else
            {
                var models = service.BlogTypeBLL.GetEntities(d => d.BlogTypeId != id);
                if (id == 0 || mm.ParentId == 0)
                {
                    sb.Append("<option value='0' selected='selected'>顶级分类</option>");
                    sb.Append(RecBlogs(models, 0, 0, "&nbsp;&nbsp;"));
                }
                else
                {
                    sb.Append("<option value='0'>顶级分类</option>");
                    sb.Append(RecBlogs(models, 0, mm.ParentId, "&nbsp;&nbsp;"));
                }
            }
            sb.Append("</select>");
            return sb.ToString();
        }

        public static string RecBlogs(List<BlogType> models,int parentId,int index,string strAppend)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var model in models.Where(d => d.ParentId == parentId))
            {
                if (index == model.BlogTypeId)
                {
                    sb.Append("<option value='" + model.BlogTypeId + "'  selected='selected'>"+strAppend+"├ " + model.Value + "</option>");
                }
                else
                {
                    sb.Append("<option value='" + model.BlogTypeId + "'>"+strAppend+"├ " + model.Value + "</option>");
                }
                sb.Append(RecBlogs(models, model.BlogTypeId, index,strAppend+ "&nbsp;&nbsp;"));
            }
            return sb.ToString();
        }
    }
}