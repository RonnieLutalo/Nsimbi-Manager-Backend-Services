using MediatR;

namespace Application.Features.ExpenseCategories.Requests.Commands
{
    public class DeleteExpenseCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
