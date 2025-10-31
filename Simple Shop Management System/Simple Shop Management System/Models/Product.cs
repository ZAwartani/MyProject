using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simple_Shop_Management_System.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="You Don't Enter Name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required , Range(0.01, 9999999.99)]
        public decimal Price { get; set; }
        public string Descriptions { get; set; }
        [Required]
        [DisplayName("Category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
