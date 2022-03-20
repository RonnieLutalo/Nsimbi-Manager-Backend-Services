using FluentValidation;
using ExpenseTracker.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.DTOs.ExpenseAllocation.Validators
{
    public class IExpenseAllocationDtoValidator : AbstractValidator<IExpenseAllocationDto>
    {
        private readonly IExpenseCategoryRepository _expenseCategoryRepository;

        public IExpenseAllocationDtoValidator(IExpenseCategoryRepository expenseCategoryRepository)
        {
            _expenseCategoryRepository = expenseCategoryRepository;

            RuleFor(p => p.ExpenseCategoryId)
                .GreaterThan(0)
                .MustAsync(async (id, token) => {
                    var expenseCategoryExists = await _expenseCategoryRepository.Exists(id);
                    return expenseCategoryExists;
                })
                .WithMessage("{PropertyName} does not exist.");

            RuleFor(p => p.Amount)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");
        }
    }
}
