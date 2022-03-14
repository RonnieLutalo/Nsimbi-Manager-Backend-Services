using Application.DTOs.ExpenseCategory;
using MediatR;

namespace Application.Features.ExpenseCategories.Requests.Commands
{
    public class UpdateExpenseCategoryCommand : IRequest<Unit>
    {
        public ExpenseCategoryDto ExpenseCategoryDto { get; set; }

    }
}
