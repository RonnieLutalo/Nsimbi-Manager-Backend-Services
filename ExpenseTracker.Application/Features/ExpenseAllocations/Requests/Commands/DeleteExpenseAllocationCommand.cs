using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Features.ExpenseAllocations.Requests.Commands
{
    public class DeleteExpenseAllocationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
