using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagementService.DTOs.GroupDTOs;
using ProductManagementService.Models;
using ProductManagementService.Services.Interfaces;
using ProductManagementService.UnitOfWork.Interfaces;
using ProductManagementService.Validators;

namespace ProductManagementService.Services.Implementations
{
    public class GroupService(IUnitOfWork unitOfWork, IMapper mapper) : IGroupService
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;
        private readonly IMapper mapper = mapper;

        public async Task<IEnumerable<GroupResponseDTO>> GetAllGroupsAsync()
        {
            try
            {
                var topLevelGroups = await unitOfWork.Groups.Query().Where(x => x.ParentGroupId == null).ToListAsync();
                var groupDtos = new List<GroupResponseDTO>();

                foreach (var group in topLevelGroups)
                {
                    var groupDto = mapper.Map<GroupResponseDTO>(group);
                    await LoadSubgroups(groupDto);
                    groupDtos.Add(groupDto);
                }

                return mapper.Map<List<GroupResponseDTO>>(groupDtos);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Error occurred in getting all groups: {ex.Message}", ex);
            }
        }

        public async Task<GroupResponseDTO> CreateGroupAsync(GroupRequestDTO groupDto)
        {
            var validator = new GroupRequestDTOValidator();
            var validationResult = await validator.ValidateAsync(groupDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            try
            {
                var group = mapper.Map<Group>(groupDto);
                await unitOfWork.Groups.InsertAsync(group);
                await unitOfWork.SaveAsync();

                return mapper.Map<GroupResponseDTO>(group);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Error occurred while creating a group: {ex.Message}", ex);
            }
        }

        public async Task<GroupResponseDTO> EditGroupAsync(int id, [FromBody] GroupRequestDTO groupDto)
        {
            var validator = new GroupRequestDTOValidator();
            var validationResult = await validator.ValidateAsync(groupDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            try
            {
                var group = await unitOfWork.Groups.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Group with ID {id} not found.");

                mapper.Map(groupDto, group);
                unitOfWork.Groups.Update(group);
                await unitOfWork.SaveAsync();

                return mapper.Map<GroupResponseDTO>(group);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Error occurred while creating a group: {ex.Message}", ex);
            }
        }

        public async Task DeleteGroupAsync(int groupId)
        {
            try
            {
                var group = await unitOfWork.Groups.GetByIdAsync(groupId) ?? throw new KeyNotFoundException($"Group with ID {groupId} not found.");

                await unitOfWork.Groups.DeleteAsync(groupId);
                await unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Error occurred while creating a group: {ex.Message}", ex);
            }
        }

        private async Task LoadSubgroups(GroupResponseDTO groupDto)
        {
            var subgroups = await unitOfWork.Groups.Query()
                .Where(g => g.ParentGroupId == groupDto.Id)
                .ToListAsync();

            foreach (var subgroup in subgroups)
            {
                var subgroupDto = mapper.Map<GroupResponseDTO>(subgroup);
                await LoadSubgroups(subgroupDto);
                groupDto.Subgroups.Add(subgroupDto);
            }
        }
    }
}
