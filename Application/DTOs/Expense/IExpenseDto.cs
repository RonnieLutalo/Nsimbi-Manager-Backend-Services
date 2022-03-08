using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Expense
{
    public interface IExpenseDto
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public int ExpenseCategoryId { get; set; }
    }
}
