﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NotesVaultApp.Data.Repository.Interface;

namespace NotesVaultApp.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly NotesVaultDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(NotesVaultDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> GetAllAttached() => this._dbSet.AsQueryable();

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }
    }
}
