using ImageFilters.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters.Repository.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ImageFiltersContext _context;
        DbSet<TEntity> _dbSet;

        public GenericRepository(ImageFiltersContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            return _dbSet.Add(entity).Entity;
        }
        public TEntity Update(TEntity entity)
        {
            return _dbSet.Update(entity).Entity;
        }
        public virtual async Task Delete(int id)
        {
            TEntity entityToDelete =  _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual async Task Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }
        public async Task<TEntity?> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }
        public async Task<IList<TEntity>> GetData(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
        
    }
}
