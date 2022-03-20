using FluentValidation;
using ExpenseTracker.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.DTOs.ExpenseAllocation.Validators
{
    public class UpdateExpenseAllocationDtoValidator : AbstractValidator<UpdateExpenseAllocationDto>
    {
        private readonly IExpenseCategoryRepository _expenseCategoryRepository;

        public UpdateExpenseAllocationDtoValidator(IExpenseCategoryRepository expenseCategoryRepository)
        {
            _expenseCategoryRepository = expenseCategoryRepository;
            Include(new IExpenseAllocationDtoValidator(_expenseCategoryRepository));

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
