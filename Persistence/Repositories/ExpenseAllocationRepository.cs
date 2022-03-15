using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ExpenseAllocationRepository : GenericRepository<ExpenseAllocation>, IExpenseAllocationRepository
    {
        private readonly ExpenseTrackerDbContext _dbContext;

        public ExpenseAllocationRepository(ExpenseTrackerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ExpenseAllocation>> GetExpenseAllocationsWithDetails()
        {
            var expenseAllocations = await _dbContext.ExpenseAllocations
                .Include(q => q.ExpenseCategory)
                .ToListAsync();
            return expenseAllocations;
        }

        public async Task<List<ExpenseAllocation>> GetExpenseAllocationsWithDetails(string userId)
        {
            var expenseAllocations = await _dbContext.ExpenseAllocations.Where(q=> q.RegularAppUserAccountHolderId == userId)
                .Include(q => q.ExpenseCategory)
                .ToListAsync();
            return expenseAllocations;
        }

        public async Task<ExpenseAllocation> GetExpenseAllocationWithDetails(int id)
        {
            var expenseAllocation = await _dbContext.ExpenseAllocations
                .Include(q => q.ExpenseCategory)
                .FirstOrDefaultAsync(q => q.Id == id);

            return expenseAllocation;
        }
    }
}
