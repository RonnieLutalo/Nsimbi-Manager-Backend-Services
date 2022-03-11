using Application.DTOs.ExpenseCategory;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.ExpenseCategories.Requests.Queries
{
    public class GetExpenseCategoryListRequest : IRequest<List<ExpenseCategoryDto>>
    {
    }
}
