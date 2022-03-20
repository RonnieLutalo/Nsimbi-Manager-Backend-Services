using ExpenseTracker.Application.DTOs.Common;
using ExpenseTracker.Application.DTOs.ExpenseCategory;
using ExpenseTracker.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.DTOs.ExpenseAllocation
{
    public class ExpenseAllocationListDto : BaseDto
    {
        public RegularAppUser RegularAppUser { get; set; }
        public string RegularAppUserAccountHolderId { get; set; }
        public ExpenseCategoryDto ExpenseCategory { get; set; }
    }
}
