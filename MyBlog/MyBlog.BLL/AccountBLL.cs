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
    public partial class AccountBLL
    {

        public void Add(Blog blog)
        {
            db.Blogs.Add(blog);
            db.SaveChanges();
        }

        public Account GetUserByLoginName(string name)
        {
            return db.Accounts.FirstOrDefault(d => d.Name == name);
        }


    }
}
