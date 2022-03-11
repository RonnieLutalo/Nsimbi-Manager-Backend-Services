
namespace Application.DTOs.ExpenseAllocation
{
    public class CreateExpenseAllocationDto : IExpenseAllocationDto
    {
        public int ExpenseCategoryId { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}
