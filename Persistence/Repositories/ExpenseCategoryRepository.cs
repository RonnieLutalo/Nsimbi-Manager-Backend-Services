using Application.Contracts.Persistence;
using Domain;

namespace Persistence.Repositories
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
 