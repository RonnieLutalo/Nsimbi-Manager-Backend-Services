﻿using Application.DTOs.Common;

namespace Application.DTOs.ExpenseAllocation
{
    public class UpdateExpenseAllocationDto : BaseDto, IExpenseAllocationDto
    {
        public int ExpenseCategoryId { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}
