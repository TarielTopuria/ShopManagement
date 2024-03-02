using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductManagementService.Data;
using ProductManagementService.Models;
using ProductManagementService.Repositories.General;
using ProductManagementService.Repositories.Interfaces;

namespace ProductManagementService.Repositories.Implementations
{
    public class GroupRepository(AppDbContext context) : Repository<Group>(context), IGroupRepository
    {
        // Implement any group-specific methods here
    }
}
