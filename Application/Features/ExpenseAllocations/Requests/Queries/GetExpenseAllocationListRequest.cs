using Application.DTOs;
using Application.DTOs.ExpenseAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ExpenseAllocations.Requests.Queries
{
    public class GetExpenseAllocationListRequest : IRequest<List<ExpenseAllocationListDto>>
    {
        public bool IsLoggedInUser { get; set; }
    }
}
