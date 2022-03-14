using Application.DTOs.ExpenseCategory;
using Application.Responses;
using MediatR;

namespace Application.Features.ExpenseCategories.Requests.Commands
{
    public class CreateExpenseCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateExpenseCategoryDto ExpenseCategoryDto { get; set; }

    }
}
