﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ExpenseAllocation : BaseDomainEntity
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
        public int ExpenseCategoryId { get; set; }
        public string RegularAppUserAccountHolderId { get; set; }
    }
}
