using Application.DTOs.Common;

namespace Application.DTOs.ExpenseCategory
{
    public class ExpenseCategoryDto : BaseDto, IExpenseCategoryDto
    {
        public string CategoryName { get; set; }
    }
}
