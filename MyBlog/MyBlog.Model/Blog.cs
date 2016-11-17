using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    public class Blog
    {
        public Blog()
        {
            IsActive = true;
            ClickCount = 0;
        }

        public int BlogId { get; set; }

         /// <summary>
        /// If checked in the UI
        /// </summary>
        public bool IsChecked { get; set; }

        /// <summary>
        /// Blog name
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Active status
        /// </summary>
        public bool IsActive { get; set; }

        public string ImgUrl { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public bool IsOriginal { get; set; }

        public int ClickCount { get; set; }

        public string Password { get; set; }


        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
        
        public int BlogTypeId { get; set; }
        public virtual BlogType BlogType { get; set; }
    }
}
