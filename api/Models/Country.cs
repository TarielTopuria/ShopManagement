using System.ComponentModel.DataAnnotations;

namespace ProductManagementService.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // Navigation property for products
        public ICollection<Product> Products { get; set; }
    }
}
