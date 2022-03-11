﻿using Application.DTOs.Common;
using Application.DTOs.ExpenseCategory;
using Application.Models.Identity;

namespace Application.DTOs.ExpenseAllocation
{
    public class ExpenseAllocationDto : BaseDto
    {
        public RegularAppUser RegularAppUser { get; set; }
        public string RegularAppUserAccountHolderId { get; set; }
        public ExpenseCategoryDto ExpenseCategory { get; set; }
        public int ExpenseCategoryId { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}
