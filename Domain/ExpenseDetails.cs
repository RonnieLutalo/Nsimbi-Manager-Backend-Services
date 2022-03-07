using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    internal class Expense : BaseDomainEntity
    {
        public string Description { get; set; }
        public double Amount { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
