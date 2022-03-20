using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Features.ExpenseCategories.Requests.Commands
{
    public class DeleteExpenseCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
