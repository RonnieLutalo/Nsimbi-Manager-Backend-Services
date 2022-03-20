using ExpenseTracker.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.DTOs.ExpenseAllocation
{
    public class UpdateExpenseAllocationDto : BaseDto, IExpenseAllocationDto
    {
        public int ExpenseCategoryId { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}
