using Application.DTOs.ExpenseAllocation;
using MediatR;

namespace Application.Features.ExpenseAllocations.Requests.Commands
{
    public class UpdateExpenseAllocationCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public UpdateExpenseAllocationDto ExpenseAllocationDto { get; set; }
    }
}
