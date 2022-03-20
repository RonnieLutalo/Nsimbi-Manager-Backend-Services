using ExpenseTracker.Application.DTOs.ExpenseCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Features.ExpenseCategories.Requests.Commands
{
    public class UpdateExpenseCategoryCommand : IRequest<Unit>
    {
        public ExpenseCategoryDto ExpenseCategoryDto { get; set; }

    }
}
