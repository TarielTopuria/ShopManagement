using AutoMapper;
using ProductManagementService.DTOs.GroupDTOs;
using ProductManagementService.Models;

namespace ProductManagementService.Profiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GroupResponseDTO>();
            CreateMap<Group, GroupResponseDTO>().ReverseMap();
            CreateMap<GroupRequestDTO, Group>();
        }
    }
}
