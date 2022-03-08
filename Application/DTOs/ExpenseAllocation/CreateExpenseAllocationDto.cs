using Application.DTOs.Common;
using Application.DTOs.ExpenseCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.ExpenseAllocation
{
    public class CreateExpenseAllocationDto
    {
        public int ExpenseCategoryId { get; set; }
    }
}
