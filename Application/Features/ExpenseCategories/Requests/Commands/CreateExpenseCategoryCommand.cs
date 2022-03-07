using Application.DTOs.ExpenseCategory;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ExpenseCategories.Requests.Commands
{
    public class CreateExpenseCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateExpenseCategoryDto ExpenseCategoryDto { get; set; }

    }
}
