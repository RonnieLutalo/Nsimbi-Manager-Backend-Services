using System;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IExpenseAllocationRepository ExpenseAllocationRepository { get; }
        IExpenseCategoryRepository ExpenseCategoryRepository { get; }
        Task Save();
    }
}
