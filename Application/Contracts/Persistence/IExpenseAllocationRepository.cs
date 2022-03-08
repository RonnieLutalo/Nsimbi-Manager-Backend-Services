using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IExpenseAllocationRepository : IGenericRepository<ExpenseAllocation>
    {
        Task<ExpenseAllocation> GetExpenseAllocationWithDetails(int id);
        Task<List<ExpenseAllocation>> GetExpenseAllocationsWithDetails();
        Task<List<ExpenseAllocation>> GetExpenseAllocationsWithDetails(string userId);
        Task<bool> AllocationExists(string userId, int expenseCategoryId, int period);
        Task AddAllocations(List<ExpenseAllocation> allocations);
        Task<ExpenseAllocation> GetUserAllocations(string userId, int expenseCategoryId);
    }
}
