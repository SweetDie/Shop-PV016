using System.Collections.Generic;

namespace Shop_PV016.Models.ViewModels
{
    public class ProductsCategoriesVM
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int PageCount { get; set; }
        public int CurrentPageIndex { get; set; }
    }
}
