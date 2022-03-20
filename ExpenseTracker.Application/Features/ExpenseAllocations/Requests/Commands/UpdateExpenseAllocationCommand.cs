using ExpenseTracker.Application.DTOs.ExpenseAllocation;
using ExpenseTracker.Application.DTOs.ExpenseCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Features.ExpenseAllocations.Requests.Commands
{
    public class UpdateExpenseAllocationCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public UpdateExpenseAllocationDto ExpenseAllocationDto { get; set; }
    }
}
