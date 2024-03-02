using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProductManagementService.DTOs.GroupDTOs;
using ProductManagementService.Services.Interfaces;

namespace ProductManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController(IGroupService groupService) : ControllerBase
    {
        private readonly IGroupService groupService = groupService;

        [HttpGet]
        public async Task<IActionResult> GetAllGroups()
        {
            try
            {
                var groups = await groupService.GetAllGroupsAsync();
                return Ok(groups);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("createGroup")]
        public async Task<ActionResult<GroupResponseDTO>> CreateGroup(GroupRequestDTO groupDto)
        {
            try
            {
                var newGroup = await groupService.CreateGroupAsync(groupDto);

                return Ok(newGroup);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditGroup(int id, [FromBody] GroupRequestDTO groupUpdateDTO)
        {
            try
            {
                if (groupUpdateDTO == null)
                {
                    return BadRequest("Group update data is null");
                }

                await groupService.EditGroupAsync(id, groupUpdateDTO);

                return NoContent();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException knfEx)
            {
                return NotFound(knfEx.Message);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            try
            {
                await groupService.DeleteGroupAsync(id);
                return Ok($"Group with ID {id} has been successfully deleted.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
