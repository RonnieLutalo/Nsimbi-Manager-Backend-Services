using ExpenseTracker.Application.DTOs.ExpenseCategory;
using ExpenseTracker.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Features.ExpenseCategories.Requests.Commands
{
    public class CreateExpenseCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateExpenseCategoryDto ExpenseCategoryDto { get; set; }

    }
}
