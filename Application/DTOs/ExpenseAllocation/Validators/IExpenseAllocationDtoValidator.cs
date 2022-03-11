using FluentValidation;
using Application.Contracts.Persistence;

namespace Application.DTOs.ExpenseAllocation.Validators
{
    public class IExpenseAllocationDtoValidator : AbstractValidator<IExpenseAllocationDto>
    {
        private readonly IExpenseCategoryRepository _expenseCategoryRepository;

        public IExpenseAllocationDtoValidator(IExpenseCategoryRepository expenseCategoryRepository)
        {
            _expenseCategoryRepository = expenseCategoryRepository;
        }
    }
}
