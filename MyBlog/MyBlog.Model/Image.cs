using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    public class Image
    {
        public int ImageId { get; set; }
        
        public int FolderId { get; set; }

        public string Title { get; set; }

        public string Intro { get; set; }

        public string Src { get; set; }

        public string Writer { get; set; }

        public DateTime Date { get; set; }

        public int Looked { get; set; }

        public bool IsDelete { get; set; }
    }
}
