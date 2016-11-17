using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    public class QQModel
    {
        public int QQMOdelId { get; set; }

        public string Name { get; set; }

        public string OpenId { get; set; }

        public string AccessToken { get; set; }

        public string FigureUrl { get; set; }

        public DateTime EndDataTime { get; set; }

        public int Count { get; set; }
    }
}
