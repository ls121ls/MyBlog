namespace MyBlog.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ImageModel
    {
        public long ImageModelId { get; set; }

        public long FolderId { get; set; }

        [StringLength(2147483647)]
        public string Title { get; set; }

        [StringLength(2147483647)]
        public string Intro { get; set; }

        [StringLength(2147483647)]
        public string Src { get; set; }

        [StringLength(2147483647)]
        public string Writer { get; set; }

        public DateTime Date { get; set; }

        public long Looked { get; set; }

        public bool IsDelete { get; set; }
    }
}
