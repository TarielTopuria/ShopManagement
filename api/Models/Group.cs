using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductManagementService.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // Self-referencing navigation property for subgroups
        [ForeignKey("ParentGroupId")]
        public ICollection<Group> Subgroups { get; set; }

        public int? ParentGroupId { get; set; }
        public Group ParentGroup { get; set; }
    }
}
