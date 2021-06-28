using FashionBlog.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FashionBlog.Model.Entities
{
    public class PostInfo : CoreEntity
    {
        public string PostComment { get; set; }

        public virtual List<Post> Posts  { get; set; }

    }
}
