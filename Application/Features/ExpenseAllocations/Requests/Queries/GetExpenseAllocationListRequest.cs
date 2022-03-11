using Application.DTOs.ExpenseAllocation;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.ExpenseAllocations.Requests.Queries
{
    public class GetExpenseAllocationListRequest : IRequest<List<ExpenseAllocationListDto>>
    {
        public bool IsLoggedInUser { get; set; }
    }
}
