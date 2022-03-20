using System;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IExpenseAllocationRepository ExpenseAllocationRepository { get; }
        IExpenseCategoryRepository ExpenseCategoryRepository { get; }
        Task Save();
    }
}
