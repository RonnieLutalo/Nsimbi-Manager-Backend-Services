
using AutoMapper;
using Application.Constants;
using Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IExpenseCategoryRepository _expenseCategoryRepository;

        public UnitOfWork(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this._httpContextAccessor = httpContextAccessor;
        }

        public IExpenseCategoryRepository ExpenseCategoryRepository =>
            _expenseCategoryRepository ??= new ExpenseCategoryRepository(_context);
        
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
