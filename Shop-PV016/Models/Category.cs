using System.ComponentModel.DataAnnotations;

namespace Shop_PV016.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, uint.MaxValue, ErrorMessage = "You need order more then 0")]
        public int ShowOrder { get; set; }
    }
}
