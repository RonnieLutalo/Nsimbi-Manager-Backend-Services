using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.DTOs.ExpenseCategory.Validators
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
