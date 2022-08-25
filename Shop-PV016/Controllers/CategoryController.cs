using Microsoft.AspNetCore.Mvc;
using Shop_PV016.Data;
using Shop_PV016.Models;
using System.Collections.Generic;

namespace Shop_PV016.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _db.Categories;

            return View(categories);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int? id)
        {
            var category = _db.Categories.Find(id);
            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            var category = _db.Categories.Find(id);
            return View(category);
        }

        // POST
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _db.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
