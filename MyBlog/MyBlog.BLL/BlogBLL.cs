using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using MyBlog.DAL;
using MyBlog.Model;

namespace MyBlog.BLL
{
    public partial class BlogBLL
    {
        public void Initialization()
        {
            for (int i = 0; i < 10; i++)
            {
                Blog blog = new Blog();
                blog.Title = "博客" + i;
                blog.Author = "云深不知处";
                blog.Content = RandomGeneration.CreateGBChar(100).ToString();
                blog.IsActive = true;
                blog.IsChecked = true;
                blog.ImgUrl = "/Images/2.jpg";
                db.Blogs.Add(blog);
            }
            db.SaveChanges();
        }

        public void Add(Blog blog)
        {
            db.Blogs.Add(blog);
            db.SaveChanges();
        }

        public List<Blog> GetIndexBlogs()
        {
            return db.Blogs.Take(10).ToList();
        }

        public List<Blog> GetNewBlogs()
        {
            return db.Blogs.Where(d=>d.IsActive).OrderByDescending(d=>d.CreateDate).Take(5).Include("BlogType").ToList();
        }

        public List<Blog> GetClickBlogs()
        {
            return db.Blogs.Where(d => d.IsActive).OrderByDescending(d => d.ClickCount).Take(5).ToList();
        }

        public List<Blog> GetReCommendBlogs()
        {
            return db.Blogs.Where(d => d.IsActive).OrderByDescending(d => d.ClickCount).Take(8).ToList();
        }

        public void AddClickCount(long id)
        {
            db.Blogs.SqlQuery("update Blog set ClickCount=ClickCount+1 where BlogId=" + id);
            db.SaveChanges();
        }

        public Blog GetUpBlog(int id)
        {
            return db.Blogs.Where(d => d.IsActive).OrderByDescending(d => d.BlogId).FirstOrDefault(d => d.BlogId < id);
        }

        public Blog GetDownBlog(int id)
        {
            return db.Blogs.Where(d => d.IsActive).FirstOrDefault(d => d.BlogId > id);
        }
    }
}
