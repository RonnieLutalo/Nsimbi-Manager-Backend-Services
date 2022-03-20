using ExpenseTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain
{
    public class ExpenseCategory : BaseDomainEntity
    {
        public string CategoryName { get; set; }
    }
}
