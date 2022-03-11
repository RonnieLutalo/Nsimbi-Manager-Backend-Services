using Application.DTOs.ExpenseCategory;
using MediatR;

namespace Application.Features.ExpenseCategories.Requests.Queries
{
    public class GetExpenseCategoryDetailRequest : IRequest<ExpenseCategoryDto>
    {
        public int Id { get; set; }
    }
}
