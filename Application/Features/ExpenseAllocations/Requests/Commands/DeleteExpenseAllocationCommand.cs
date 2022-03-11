using MediatR;

namespace Application.Features.ExpenseAllocations.Requests.Commands
{
    public class DeleteExpenseAllocationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
