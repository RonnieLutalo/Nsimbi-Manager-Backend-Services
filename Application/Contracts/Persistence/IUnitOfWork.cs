using System;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IExpenseCategoryRepository ExpenseCategoryRepository { get; }
        Task Save();
    }
}
