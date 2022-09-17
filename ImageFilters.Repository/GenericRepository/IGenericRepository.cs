using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ImageFilters.Repository.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        Task Delete(int id);
        Task<TEntity?> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<IList<TEntity>> GetData(Expression<Func<TEntity, bool>> predicate);

    }
}