using ExpenseTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Persistence.Configurations.Entities
{
    public class ExpenseAllocationConfiguration : IEntityTypeConfiguration<ExpenseAllocation>
    {
        public void Configure(EntityTypeBuilder<ExpenseAllocation> builder)
        {
            
        }
    }
}
