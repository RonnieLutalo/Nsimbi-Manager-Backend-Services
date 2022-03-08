using Application.DTOs.Common;
using Application.DTOs.ExpenseAllocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.ExpenseAllocation
{
    public class UpdateExpenseAllocationDto : BaseDto, IExpenseAllocationDto
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public int ExpenseCategoryId { get; set; }
    }
}
