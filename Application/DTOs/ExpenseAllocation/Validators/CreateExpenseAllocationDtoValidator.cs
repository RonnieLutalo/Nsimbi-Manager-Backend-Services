using FluentValidation;
using Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DTOs.ExpenseAllocation.Validators
{
    public class CreateExpenseAllocationDtoValidator : AbstractValidator<CreateExpenseAllocationDto>
    {
        private readonly IExpenseCategoryRepository _expenseCategoryRepository;

        public CreateExpenseAllocationDtoValidator(IExpenseCategoryRepository expenseCategoryRepository)
        {
            _expenseCategoryRepository = expenseCategoryRepository;
            Include(new IExpenseAllocationDtoValidator(_expenseCategoryRepository));
        }
    }
}
