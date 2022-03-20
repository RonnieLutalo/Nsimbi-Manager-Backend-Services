using ExpenseTracker.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.DTOs.ExpenseCategory
{
    public class CreateExpenseCategoryDto : IExpenseCategoryDto
    {
        public string CategoryName { get; set; }
    }
}
