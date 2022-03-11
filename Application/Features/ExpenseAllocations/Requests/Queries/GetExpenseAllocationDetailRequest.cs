using Application.DTOs.ExpenseAllocation;
using MediatR;

namespace Application.Features.ExpenseAllocations.Requests.Queries
{
    public class GetExpenseAllocationDetailRequest : IRequest<ExpenseAllocationDto>
    {
        public int Id { get; set; }
    }
}
