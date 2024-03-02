namespace ProductManagementService.DTOs.GroupDTOs
{
    public class GroupResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GroupResponseDTO> Subgroups { get; set; }
    }
}
