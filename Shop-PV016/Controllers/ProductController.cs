using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_PV016.Data;
using Shop_PV016.Models;
using System.Collections.Generic;

namespace Shop_PV016.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _db.Products.Include(p => p.Category);

            return View(products);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int? id)
        {
            var product = _db.Products.Find(id);
            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            var product = _db.Products.Find(id);
            return View(product);
        }

        // POST
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _db.Update(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _db.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
