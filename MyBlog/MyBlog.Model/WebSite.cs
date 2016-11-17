using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    public class WebSite
    {
        public int WebSiteId { get; set; }

        public string Ip { get; set; }

        public string City { get; set; }
        
        public DateTime AccessTime { get; set; }
    }
}
