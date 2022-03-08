using Application.DTOs.ExpenseAllocation;
using Application.DTOs.ExpenseCategory;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ExpenseAllocations.Requests.Commands
{
    public class CreateExpenseAllocationCommand : IRequest<BaseCommandResponse>
    {
        public CreateExpenseAllocationDto ExpenseAllocationDto { get; set; }
    }
}
