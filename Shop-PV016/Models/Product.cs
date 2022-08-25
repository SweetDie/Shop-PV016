using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_PV016.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Field name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field description is required")]
        public string Description { get; set; }

        public string ShortDescription { get; set; }

        [Range(1, uint.MaxValue, ErrorMessage = "Min price 1 max price 4294967295")]
        public double Price { get; set; }
        public string Image { get; set; }

        [Display(Name="Category Type")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

    }
}
