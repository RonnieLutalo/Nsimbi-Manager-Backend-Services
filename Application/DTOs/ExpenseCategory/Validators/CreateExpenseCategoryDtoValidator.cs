using FluentValidation;

namespace Application.DTOs.ExpenseCategory.Validators
{
    public class CreateExpenseCategoryDtoValidator : AbstractValidator<CreateExpenseCategoryDto>
    {
        public CreateExpenseCategoryDtoValidator()
        {
            Include(new IExpenseCategoryDtoValidator());
        }
    }
}
