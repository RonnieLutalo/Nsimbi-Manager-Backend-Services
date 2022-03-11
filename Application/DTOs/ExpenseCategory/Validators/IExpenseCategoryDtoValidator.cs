using FluentValidation;

namespace Application.DTOs.ExpenseCategory.Validators
{
    public class IExpenseCategoryDtoValidator : AbstractValidator<IExpenseCategoryDto>
    {
        public IExpenseCategoryDtoValidator()
        {
            RuleFor(p => p.CategoryName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
