using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IExpenseRepository : IGenericRepository<Expense>
    {
        Task<Expense> GetExpensesWithDetails(int id);
        Task<List<Expense>> GetExpensesWithDetails();
        Task<List<Expense>> GetExpensesWithDetails(string userId);
        Task<bool> ExpenseExists(string userId, int expenseCategoryId, int period);
        Task AddAllocations(List<Expense> allocations);
        Task<Expense> GetUserAllocations(string userId, int leaveTypeId);
    }
}
