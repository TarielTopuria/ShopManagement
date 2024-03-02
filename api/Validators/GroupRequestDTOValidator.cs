using FluentValidation;
using ProductManagementService.DTOs.GroupDTOs;

namespace ProductManagementService.Validators
{
    public class GroupRequestDTOValidator : AbstractValidator<GroupRequestDTO>
    {
        public GroupRequestDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .Length(1, 100).WithMessage("Name must be between 1 and 100 characters");
        }
    }
}
