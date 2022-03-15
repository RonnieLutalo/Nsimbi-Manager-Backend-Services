using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.ExpenseCategory
{
    public class CreateExpenseCategoryDto : IExpenseCategoryDto
    {
        public string CategoryName { get; set; }
    }
}
