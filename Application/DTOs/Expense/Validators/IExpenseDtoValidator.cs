using FluentValidation;
using Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DTOs.Expense.Validators
{
    public class IExpenseDtoValidator : AbstractValidator<IExpenseDto>
    {
        private readonly IExpenseCategoryRepository _expenseCategoryRepository;

        public IExpenseDtoValidator(IExpenseCategoryRepository expenseCategoryRepository)
        {
            _expenseCategoryRepository = expenseCategoryRepository;

            RuleFor(p => p.ExpenseCategoryId)
                .GreaterThan(0)
                .MustAsync(async (id, token) => 
                {
                    var expenseCategoryExists = await _expenseCategoryRepository.Exists(id);
                    return expenseCategoryExists;
                })
                .WithMessage("{PropertyName} does not exist.");
            
        }
    }
}
