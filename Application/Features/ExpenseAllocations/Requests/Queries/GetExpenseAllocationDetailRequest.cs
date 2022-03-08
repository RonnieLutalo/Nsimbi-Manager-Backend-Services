using Application.DTOs;
using Application.DTOs.ExpenseAllocation;
using Application.DTOs.ExpenseRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ExpenseAllocations.Requests.Queries
{
    public class GetExpenseAllocationDetailRequest : IRequest<ExpenseAllocationDto>
    {
        public int Id { get; set; }
    }
}
