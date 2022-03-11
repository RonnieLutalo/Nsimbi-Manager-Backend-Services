using FluentValidation;

namespace Application.DTOs.ExpenseCategory.Validators
{
    public class UpdateExpenseCategoryDtoValidator : AbstractValidator<ExpenseCategoryDto>
    {
        public UpdateExpenseCategoryDtoValidator()
        {
            Include(new IExpenseCategoryDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
