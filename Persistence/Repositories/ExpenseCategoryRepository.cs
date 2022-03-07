using Application.Contracts.Persistence;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories
{
    public class ExpenseCategoryRepository : GenericRepository<ExpenseCategory>, IExpenseCategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public ExpenseCategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
 