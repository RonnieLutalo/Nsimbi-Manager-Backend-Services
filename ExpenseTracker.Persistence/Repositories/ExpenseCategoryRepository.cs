using ExpenseTracker.Application.Contracts.Persistence;
using ExpenseTracker.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Persistence.Repositories
{
    public class ExpenseCategoryRepository : GenericRepository<ExpenseCategory>, IExpenseCategoryRepository
    {
        private readonly ExpenseTrackerDbContext _dbContext;

        public ExpenseCategoryRepository(ExpenseTrackerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
 