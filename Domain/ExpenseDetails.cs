using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ExpenseDetails : BaseDomainEntity
    {
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}
