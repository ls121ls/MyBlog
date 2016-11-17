using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    public class Message
    {
        public int MessageId { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string RecordUrl { get; set; }
    }
}
