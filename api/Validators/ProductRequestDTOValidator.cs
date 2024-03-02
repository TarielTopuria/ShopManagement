using FluentValidation;
using ProductManagementService.DTOs.ProductDTOs;

namespace ProductManagementService.Validators
{
    public class ProductRequestDTOValidator : AbstractValidator<ProductRequestDTO>
    {
        public ProductRequestDTOValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code is required.")
                .Length(3, 10).WithMessage("Code must be between 3 and 10 characters.")
                .Matches("^[0-9]+$").WithMessage("Code must be numeric.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot be more than 100 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(x => x.StartDate)
                .LessThan(x => x.EndDate).WithMessage("Start Date must be earlier than End Date.");

            RuleFor(x => x.CountryId)
                .GreaterThan(0).WithMessage("Invalid Country ID: Country ID must be greater than 0");

            RuleFor(x => x.GroupId)
                .GreaterThan(0).WithMessage("Invalid Group ID.");
        }
    }
}
