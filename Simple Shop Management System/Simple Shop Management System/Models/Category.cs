using System.ComponentModel.DataAnnotations;

namespace Simple_Shop_Management_System.Models
{
    public class Category
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string?  Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
