using FashionBlog.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FashionBlog.Model.Entities
{
    public class User : CoreEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? LastLogin  { get; set; }
        public string LastIpAddress { get; set; }

        public virtual List<Post> Posts { get; set; } //table connection


}
}
