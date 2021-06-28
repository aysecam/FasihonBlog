using FashionBlog.Core.Service;
using FashionBlog.Model.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FashionBlog.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICoreService<User> _user;
        public AccountController(ICoreService<User> user)
        {//bilgiler doldurduktan sonra kontrol et
            _user = user;
        }
        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {

            if (_user.Any(x => x.Email == user.Email && x.Password == user.Password))
            {
                var logged = _user.GetByDefault(x => x.Email == user.Email && x.Password == user.Password);

                var claims = new List<Claim>()
                {
                    new Claim("ID", logged.ID.ToString()),
                    new Claim(ClaimTypes.Name, logged.FirstName),
                    new Claim(ClaimTypes.Surname, logged.LastName),
                    new Claim(ClaimTypes.Email, logged.Email),
                    new Claim("Image", logged.Image)
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home", new { area = "Administrator" });
            }

            return RedirectToAction("Index", "Home", new { area = "Administrator" });
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
