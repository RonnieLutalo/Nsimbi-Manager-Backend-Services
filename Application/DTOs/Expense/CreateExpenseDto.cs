using Application.DTOs.Common;
using Application.DTOs.ExpenseCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Expense
{
    public class CreateExpenseDto
    {
        public int ExpenseCategoryId { get; set; }
    }
}
