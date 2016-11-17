using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Model;

namespace MyBlog.BLL
{
    public partial class PictureBLL
    {
        public void Initialization()
        {

            for (int i = 0; i < 10; i++)
            {
                Picture pic = new Picture();
                pic.Url= "/Images/2.jpg";
                pic.Remark = "image" + i;
                AddEntity(pic);
            }
            db.SaveChanges();
        }
    }
}
