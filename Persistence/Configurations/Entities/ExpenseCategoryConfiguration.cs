using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations.Entities
{
    public class ExpenseCategoryConfiguration : IEntityTypeConfiguration<ExpenseCategory>
    {
        public void Configure(EntityTypeBuilder<ExpenseCategory> builder)
        {
            builder.HasData(
                new ExpenseCategory
                {
                    Id = 1, 
                    CategoryName = "Groceries"
                },
                new ExpenseCategory
                {
                    Id = 2,
                    CategoryName = "Credit Card"
                }
            );
        }
    }
}
