using FluentValidation;
using ProductManagementService.DTOs.CountryDTOs;

namespace ProductManagementService.Validators
{
    public class CountryRequestDTOValidator : AbstractValidator<CountryRequestDTO>
    {
        public CountryRequestDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .Length(1, 100).WithMessage("Name must be between 1 and 100 characters");
        }
    }
}
