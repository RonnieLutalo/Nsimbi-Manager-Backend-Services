using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Application.DTOs.ExpenseCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Features.ExpenseCategories.Requests.Queries
{
    public class GetExpenseCategoryDetailRequest : IRequest<ExpenseCategoryDto>
    {
        public int Id { get; set; }
    }
}
