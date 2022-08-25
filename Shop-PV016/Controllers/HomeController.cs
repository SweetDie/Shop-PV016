using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shop_PV016.Data;
using Shop_PV016.Models;
using Shop_PV016.Models.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;

namespace Shop_PV016.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //var productsCategoriesVM = new ProductsCategoriesVM
            //{
            //    Categories = _context.Categories,
            //    Products = _context.Products.Include(p => p.Category)
            //};
            return View(GetProducts(1));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Index(int currentPageIndex)
        {
            return View(GetProducts(currentPageIndex));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        private ProductsCategoriesVM GetProducts(int currentPage)
        {
            int maxRows = 4;
            ProductsCategoriesVM productsCategoriesVM = new ProductsCategoriesVM();

            productsCategoriesVM.Products = (from product in _context.Products select product)
                        .Include(p => p.Category)
                        .OrderBy(product => product.Id)
                        .Skip((currentPage - 1) * maxRows)
                        .Take(maxRows);
            productsCategoriesVM.Categories = _context.Categories;
            double pageCount = (double)((decimal)_context.Products.Count() / Convert.ToDecimal(maxRows));
            productsCategoriesVM.PageCount = (int)Math.Ceiling(pageCount);

            productsCategoriesVM.CurrentPageIndex = currentPage;

            return productsCategoriesVM;
        }

        public IActionResult ProductDetails(int? id)
        {
            var product = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if(product != null)
            {
                return View(product);
            }
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
