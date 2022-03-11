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
    }
}
