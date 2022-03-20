using ExpenseTracker.Application.DTOs.ExpenseAllocation;
using ExpenseTracker.Application.DTOs.ExpenseCategory;
using ExpenseTracker.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Features.ExpenseAllocations.Requests.Commands
{
    public class CreateExpenseAllocationCommand : IRequest<BaseCommandResponse>
    {
        public CreateExpenseAllocationDto ExpenseAllocationDto { get; set; }

    }
}
