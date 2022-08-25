using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Shop_PV016.Models.ViewModels
{
    public class ProductVM
    {
        public Product product { get; set; }
        public IEnumerable<SelectListItem> CategorySelectList { get; set; }
    }
}
