using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    public class BlogType
    {
        public int BlogTypeId { get; set; }

        public string Value { get; set; }

        public int ParentId { get; set; }

        public int OrderId { get; set; }

        public string Remark { get; set; }
    }
}
