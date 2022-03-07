using Application.DTOs;
using Application.DTOs.ExpenseCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ExpenseCategories.Requests.Queries
{
    public class GetExpenseCategoryDetailRequest : IRequest<ExpenseCategoryDto>
    {
        public int Id { get; set; }
    }
}
