using Application.DTOs.ExpenseAllocation;
using Application.Responses;
using MediatR;

namespace Application.Features.ExpenseAllocations.Requests.Commands
{
    public class CreateExpenseAllocationCommand : IRequest<BaseCommandResponse>
    {
        public CreateExpenseAllocationDto ExpenseAllocationDto { get; set; }

    }
}
