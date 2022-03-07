using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

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
