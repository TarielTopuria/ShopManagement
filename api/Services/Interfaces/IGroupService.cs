using ProductManagementService.DTOs.GroupDTOs;

namespace ProductManagementService.Services.Interfaces
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupResponseDTO>> GetAllGroupsAsync();
        Task<GroupResponseDTO> CreateGroupAsync(GroupRequestDTO groupDto);
        Task<GroupResponseDTO> EditGroupAsync(int id, GroupRequestDTO groupDto);
        Task DeleteGroupAsync(int groupId);
    }
}
