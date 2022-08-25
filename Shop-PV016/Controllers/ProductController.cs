using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop_PV016.Data;
using Shop_PV016.Models;
using Shop_PV016.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Shop_PV016.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _db.Products.Include(p => p.Category);

            return View(products);
        }

        // GET
        public IActionResult CreateUpdate(int? id)
        {
            ProductVM productVM = new ProductVM()
            {
                product = new Product(),
                CategorySelectList = _db.Categories.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            if(id == null)
            {
                return View(productVM);
            }
            else
            {
                productVM.product = _db.Products.Find(id);
                if(productVM.product == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(productVM);
                }
            }
        }

        // POST
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CreateUpdate(ProductVM productVM)
        {
            if(ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;
                string upload = webRootPath + Settings.ImagePath;

                if (productVM.product.Id != 0)
                {
                    var product = _db.Products.AsNoTracking().FirstOrDefault(p => p.Id == productVM.product.Id);
                    if (files.Count > 0)
                    {
                        var oldFile = upload + product.Image;
                        if (System.IO.File.Exists(oldFile))
                        {
                            System.IO.File.Delete(oldFile);
                        }

                        var file = files[0];
                        var fileName = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(file.FileName);

                        using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                        productVM.product.Image = fileName + extension;
                    }
                    _db.Update(productVM.product);
                    _db.SaveChanges();
                }
                else
                {
                    if (files.Count > 0)
                    {
                        var file = files[0];
                        var fileName = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(file.FileName);

                        using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                        productVM.product.Image = fileName + extension;
                    }

                    _db.Add(productVM.product);
                    _db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View(productVM);
        }

        // GET
        public IActionResult Delete(int? id)
        {
            var product = _db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            Product productDB = _db.Products.Find(product.Id);
            if(productDB != null)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                string folderPath = webRootPath + Settings.ImagePath;
                string filePath = folderPath + productDB.Image;
                if(System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                _db.Remove(productDB);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
