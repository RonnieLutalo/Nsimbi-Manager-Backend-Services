﻿using ExpenseTracker.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ExpenseTrackerDbContext _dbContext;

        public GenericRepository(ExpenseTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        
    }
}
