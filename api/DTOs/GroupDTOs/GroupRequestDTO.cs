namespace ProductManagementService.DTOs.GroupDTOs
{
    public class GroupRequestDTO
    {
        public string Name { get; set; }
        public int? ParentGroupId { get; set; } // Nullable for top-level groups
    }
}
