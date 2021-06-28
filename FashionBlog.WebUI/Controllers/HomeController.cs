using FashionBlog.Core.Service;
using FashionBlog.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionBlog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICoreService<Category> _category;
        private readonly ICoreService<Post> _post;
        private readonly ICoreService<User> _user;

       public HomeController(ICoreService<Category> category, ICoreService<Post> post, ICoreService<User> user)
        {//injekion burada yapılıdı
            _category = category;
            _post = post;
            _user = user;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
