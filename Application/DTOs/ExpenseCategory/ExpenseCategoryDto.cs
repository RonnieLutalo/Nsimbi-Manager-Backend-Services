﻿using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.ExpenseCategory
{
    public class ExpenseCategoryDto : BaseDto, IExpenseCategoryDto
    {
        public string CategoryName { get; set; }
    }
}
