
using AutoMapper;
using Application.Constants;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Contracts.Persistence;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ExpenseTrackerDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IExpenseCategoryRepository _expenseCategoryRepository;
        private IExpenseAllocationRepository _expenseAllocationRepository;


        public UnitOfWork(ExpenseTrackerDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this._httpContextAccessor = httpContextAccessor;
        }

        public IExpenseCategoryRepository ExpenseCategoryRepository => 
            _expenseCategoryRepository ??= new ExpenseCategoryRepository(_context);
        public IExpenseAllocationRepository ExpenseAllocationRepository => 
            _expenseAllocationRepository ??= new ExpenseAllocationRepository(_context);
        
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save() 
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

            await _context.SaveChangesAsync(username);
        }
    }
}
