using ExpenseTracker.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Contracts.Persistence
{
    public interface IExpenseCategoryRepository : IGenericRepository<ExpenseCategory>
    {
    }
}
