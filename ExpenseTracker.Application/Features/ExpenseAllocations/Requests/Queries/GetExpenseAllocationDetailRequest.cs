using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Application.DTOs.ExpenseAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Features.ExpenseAllocations.Requests.Queries
{
    public class GetExpenseAllocationDetailRequest : IRequest<ExpenseAllocationDto>
    {
        public int Id { get; set; }
    }
}
