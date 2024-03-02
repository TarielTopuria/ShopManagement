using System.ComponentModel.DataAnnotations;

namespace ProductManagementService.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public double Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        // Navigation properties
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
