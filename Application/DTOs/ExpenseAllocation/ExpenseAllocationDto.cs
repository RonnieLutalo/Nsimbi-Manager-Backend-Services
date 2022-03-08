﻿using Application.DTOs.Common;
using Application.DTOs.ExpenseCategory;
using Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.ExpenseAllocation
{
    public class ExpenseAllocationDto : BaseDto
    {
        public ExpenseCategoryDto ExpenseCategory { get; set; }
        public int ExpenseCategoryId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }

    }
}