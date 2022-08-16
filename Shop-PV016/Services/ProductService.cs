using Microsoft.EntityFrameworkCore;
using Shop_PV016.Data;
using Shop_PV016.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop_PV016.Services
{
    public class ProductService
    {
        private ApplicationDbContext _dbContext;
        private DbSet<Product> _dbSet;

        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Product>();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbSet.AsNoTracking().ToList();
        }
    }
}
