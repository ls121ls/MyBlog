using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    public class Account
    {
        public int AccountId { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string NickName { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Count { get; set; }
    }
}
