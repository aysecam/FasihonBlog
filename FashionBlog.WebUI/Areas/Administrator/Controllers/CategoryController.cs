using FashionBlog.Core.Service;
using FashionBlog.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FashionBlog.WebUI.Areas.Administrator.Controllers
{
    [Area("Administrator"), Authorize]
    public class CategoryController : Controller
    {

        private readonly ICoreService<Category> _category;
        public CategoryController(ICoreService<Category> category)
        {
            _category = category;
        }

        public IActionResult Index()
        {
            return View(_category.GetAll());
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Category category)
        {
            if (ModelState.IsValid)
            {
                bool result = _category.Add(category);
                if (result)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "An error occurred during the registration process.";
            }
            else
            {
                TempData["Message"] = "The operation failed. Please try again later.";
            }

            return View(category);
        }

        public IActionResult Update(Guid id)
        {
            return View(_category.GetById(id));
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                Category item = _category.GetById(category.ID);
                item.CategoryName = category.CategoryName;
                item.Description = category.Description;

                bool result = _category.Update(item);
                if (result)
                    return RedirectToAction("Index");
                else
                    TempData["Message"] = "An error occurred while updating.";
            }
            else
            {
                TempData["Message"] = "The operation failed. Please try again later.";
            }

            return View(category);
        }

        public IActionResult Delete(Guid id)
        {
            _category.Remove(_category.GetById(id));
            return RedirectToAction("Index");
        }

        public IActionResult Activate(Guid id)
        {
            _category.Activate(id);
            return RedirectToAction("Index");
        }
    }
}
