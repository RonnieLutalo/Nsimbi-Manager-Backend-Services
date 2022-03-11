using Application.DTOs.Common;
using Application.DTOs.ExpenseCategory;
using Application.Models.Identity;

namespace Application.DTOs.ExpenseAllocation
{
    public class ExpenseAllocationListDto : BaseDto
    {
        public RegularAppUser RegularAppUser { get; set; }
        public string RegularAppUserAccountHolderId { get; set; }
        public ExpenseCategoryDto ExpenseCategory { get; set; }
    }
}
